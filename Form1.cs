using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4_Personal
{
    public partial class Form1 : Form
    {
        Button[] btn = new Button[7];
        Label[,] lbl = new Label[7, 7];
        int PlayerNumber = 1;
        bool validMove = true;
        private Form2 form2 = null;
        
        public Form1()
        {
            InitializeComponent();
            
        }

        public Form1(Form menu)
        {
            form2 = menu as Form2;
            InitializeComponent();
            for (int x = 0; x < 7; x++)
            {
                btn[x] = new Button();
                btn[x].SetBounds(60 + (60 * x), 60, 40, 40);
                btn[x].BackColor = Color.Blue;
                btn[x].Text = Convert.ToString(x);
                btn[x].Click += new EventHandler(this.btnEvent_Click);
                Controls.Add(btn[x]);
            }

            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    lbl[x, y] = new Label();
                    lbl[x, y].SetBounds(60 + (60 * x), 120 + (60 * y), 40, 40);
                    lbl[x, y].BackColor = Color.Gray;
                    lbl[x, y].ForeColor = lbl[x, y].BackColor;
                    lbl[x, y].Name = Convert.ToString(x) + "," + Convert.ToString(y);
                    Controls.Add(lbl[x, y]);
                }
            }
            form2.Hide();
        }

        //Returns x coordinate from given label
        private int getX(Label label)
        {
            string[] coords = label.Name.Split(',');
            return Convert.ToInt32(coords[0]);

        }

        //Returns y coordinate from given label
        private int getY(Label label)
        {
            string[] coords = label.Name.Split(',');
            return Convert.ToInt32(coords[1]);

        }
        
        //Computes a label for the computer to choose
        //it will look for the most labels in a line and try to add a label to that line
        private Label vsComputer()
        {
            Label chosenOne = null;

            //to find all the labels with the computer's colour
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {

                    //it will choose the one with the most labels of the right colour near which are in one line
                    if (form2.p1Red && lbl[i,j].BackColor == Color.Yellow)
                    {
                        if(chosenOne == null || this.getCounter(lbl[i,j]) > this.getCounter(chosenOne))
                        {
                            chosenOne = lbl[i, j];
                        }
                    }
                    else if (!form2.p1Red && lbl[i, j].BackColor == Color.Red)
                    {
                        if (chosenOne == null || this.getCounter(lbl[i, j]) > this.getCounter(chosenOne))
                        {
                            chosenOne = lbl[i, j];
                        }
                    }
                }
            }
            
            Random rnd = new Random();
            int y = -1;
            int x = -1;

            //if there is no label of that colour yet, it will choose randomly
            if (chosenOne == null)
            {
                x = rnd.Next(0, 7);
            }
            else
            {
                //it first will try to choose a label at one ende and then at the other
                Label end = this.getEnd(chosenOne, "positive");
                Label start = this.getEnd(chosenOne, "negative");

                //if there is only one label currently available, it will choose a label next to it
                if (this.getCounter(chosenOne) == 1)
                {
                    int xC = this.getX(chosenOne);
                    int yC = this.getY(chosenOne);

                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -1; j < 2; j++)
                        {
                            if ((i == 0 && j == 0) ||i + xC > 6 || i + xC < 0 || j + yC > 5 || j + yC < 0)
                            {
                                continue;
                            }
                            else if (lbl[xC + i, yC + j].BackColor == Color.Gray)
                            {
                                x = xC + i;

                            }
                        }
                    }
                }
                else if (!this.OutOfRange(end, chosenOne))
                {
                    Label nextEnd = lbl[this.getX(end) + this.getDifX(chosenOne), this.getY(end) + this.getDifY(chosenOne)];
                    if(this.checkCol(nextEnd) && nextEnd.BackColor == Color.Gray)
                    {
                        x = this.getX(nextEnd);
                    }
                    else if (!this.OutOfRange(start, chosenOne))
                    {
                        Label nextStart = lbl[this.getX(start) - this.getDifX(chosenOne), this.getY(start) - this.getDifY(chosenOne)];
                        if(this.checkCol(nextStart) && nextStart.BackColor == Color.Gray)
                        {
                            x = this.getX(start);
                        }
                    }
                    
                }
            }

            //if none of the suggested labels work, it will choose randomly
            if(x == -1)
            {
                x = rnd.Next(0, 7);
            }

            //it will choose the label at the given column in the lowest row possible
            for (int i = 0; i < 6; i++)
            {
                if (lbl[x, i].BackColor == Color.Gray)
                {
                    y = i;
                }
                else if (i == 5 && y == -1)
                {
                    i = 0;
                    x = rnd.Next(0, 7);
                }
            }

            return lbl[x, y];
        }

        //Bool to check if there is an empy/grey label underneath the given label
        private bool checkCol(Label label)
        {
            int x = this.getX(label);
            for (int y = 5; y >= 0; y--)
            {

                if(y == this.getY(label))
                {
                    return true;
                }
                else if(lbl[x,y].BackColor == Color.Gray)
                {
                    return false;
                }

            }
            return false;
        }

        //Bool to check if the next label is out of range of the given array
        private bool OutOfRange(Label label1, Label label2)
        {
            int xL1 = this.getX(label1);
            int yL1 = this.getY(label1);

            int xL2 = this.getDifX(label2);
            int yL2 = this.getDifY(label2);

            if (xL1 + xL2 > 6 || xL1 + xL2 < 0 || yL1 + yL2 > 5 || yL1 + yL2 < 0)
            {
                return true;
            }
            else if (xL1 - xL2 > 6 || xL1 - xL2 < 0 || yL1 - yL2 > 5 || yL1 - yL2 < 0)
            {
                return true;
            }
            return false;
        }

        void btnEvent_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(((Button)sender).Text);
            int y = 0;
            
            for (int i = 0; i < 6; i++)
            {
                if (lbl[x, i].BackColor == Color.Gray)
                {
                    y = i;
                }
            }

            if (lbl[x, 0].BackColor == Color.Yellow || lbl[x, 0].BackColor == Color.Red)
            {
                validMove = false;
                string msg = "Invalid move, please re-enter";
                MessageBox.Show(msg);
            }else
            {
                validMove = true;
            }

            //Player will either play vs a computer or player, based on their choice in the menu
            if (form2.computer && validMove)
            {
                //first the label of the player is coloured in
                if (form2.p1Red)
                {
                    lbl[x, y].BackColor = Color.Red;
                }
                else
                {
                    lbl[x, y].BackColor = Color.Yellow;
                }

                //if the player has not won, the computer will choose its label
                if (this.getCounter(lbl[x,y]) < 4)
                {
                    Label chosenOne = vsComputer();

                    //the colour can be change in the menu for the computer as well
                    if (!form2.p1Red)
                    {
                        chosenOne.BackColor = Color.Red;
                    }
                    else
                    {
                        chosenOne.BackColor = Color.Yellow;
                    }

                    //it counts again the labels of the computer. If they are over 3, it has won
                    if (this.getCounter(chosenOne) >= 4)
                    {
                        MessageBox.Show("The computer has won!");
                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                lbl[j, i].BackColor = Color.Gray;
                            }
                        }
                    }
                }

                //if the player has 4 labels in row, the computer will not choose a label
                else
                {
                    MessageBox.Show("You have won!");
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            lbl[j, i].BackColor = Color.Gray;
                        }
                    }
                }
                
            }
            //Player vs Player
            else if(!form2.computer && validMove)
            {
                if ((PlayerNumber == 1 && form2.p1Red) || (PlayerNumber == 2 && !form2.p1Red))
                {
                    lbl[x, y].BackColor = Color.Red;
                }
                else
                {
                    lbl[x, y].BackColor = Color.Yellow;
                }

                if (PlayerNumber == 1)
                {
                    if (validMove == true)
                    {
                        PlayerNumber = 2;
                    }
                }
                else if (PlayerNumber == 2)
                {
                    if (validMove == true)
                    {
                        PlayerNumber = 1;
                    }
                }
                if (this.getCounter(lbl[x,y]) >= 4)
                {
                    if (lbl[x, y].BackColor == Color.Red)
                    {
                        form2.scoreR++;
                        MessageBox.Show("Red has won!");
                    }
                    else
                    {
                        form2.scoreY++;
                        MessageBox.Show("Yellow has won!");
                    }

                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            lbl[j, i].BackColor = Color.Gray;
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Returns a counter of all labels of one colour in the same line
        private int getCounter(Label label)
        {
            //calculates the end and beginning of the line of same coloured labels
            Label end = this.getEnd(label, "positive");
            Label start = this.getEnd(label, "negative");

            //counter is set to one, since there is a least one label of the same colour as the given one
            int counter = 1;

            //calculates the difference between the labels in the same line
            int xDif = this.getDifX(label);
            int yDif = this.getDifY(label);

            Label next = start;
            //it counts every label from start to end
            while(next != end)
            {
                counter++;
                next = lbl[getX(next) + xDif, getY(next) + yDif];
            }
            return counter;
        }


        //Returns either end of the line of same coloured labels as the given label
        //The given string decides if the calculated difference should be added or subtracted
        private Label getEnd(Label label, string side)
        {
            int x = this.getX(label);
            int y = this.getY(label);
            Label next = lbl[x,y]; 
            int xDif = this.getDifX(label);
            int yDif = this.getDifY(label);

            if (side == "negative")
            {
                xDif = -xDif;
                yDif = -yDif;
            }

            //it will move on to the next label until there is no label of the same colour or no label at all
            while (next.BackColor == label.BackColor)
            {
                if ((xDif == 0 && yDif == 0) ||x + xDif > 6 || x + xDif < 0 || y + yDif > 5 || y + yDif < 0)
                {
                    break;
                }
                else if (lbl[x + xDif, y + yDif].BackColor != label.BackColor)
                {
                    break;
                }
                x += xDif;
                y += yDif;
                next = lbl[x, y];
            }
            return next;

        }

        //Returns the difference of the x coordinate of the given label and the label next to it with the same colour
        private int getDifX(Label label)
        {
            int x = this.getX(label);
            int y = this.getY(label);
            int xDif = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if ((i == 0 && j == 0) || i + x > 6 || i + x < 0 || j + y > 5 || j + y < 0)
                    {
                        continue;
                    }
                    else if (lbl[x + i, y + j].BackColor == lbl[x, y].BackColor)
                    {
                        xDif = i;

                    }
                }
            }
            return xDif;
        }

        //Returns the difference of the y coordinate of the given label and the label next to it with the same colour
        private int getDifY(Label label)
        {
            int x = this.getX(label);
            int y = this.getY(label);
            int yDif = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if ((i == 0 && j == 0) || i + x > 6 || i + x < 0 || j + y > 5 || j + y < 0)
                    {
                        continue;
                    }
                    else if (lbl[x + i, y + j].BackColor == lbl[x, y].BackColor)
                    {
                        yDif = j;

                    }
                }
            }
            return yDif;
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rulesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("The rules are to connect four of your coloured pieces in a row, may that be horizontally, vertically or diagonal. Click a button at the top and your coloured piece will be placed in that column.", "Rules", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void startNewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    lbl[j, i].BackColor = Color.Gray;
                }
            }
        }

        private void licenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Created by Elliot Morgan-Davies, Pia Schroeter and Jerry Deligiannis at Dundee University (c)", "Licence", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
