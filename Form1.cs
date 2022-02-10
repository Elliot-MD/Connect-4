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
        private readonly Color EmptyTile = Color.Gray;
        private readonly Color Player1Tile;
        private readonly Color Player2Tile;
        private readonly bool Computer;
        private int turns = 1;

        Button[] btnArray = new Button[7];
        Label[,] lblArray = new Label[7, 6];
        private Form2 form2 = null;
        Label scoreR = new Label();
        Label scoreY = new Label();

       

        public Form1()
        {
            InitializeComponent();
            
        }

        public Form1(Form menu)
        {
            form2 = menu as Form2;

            Player1Tile = form2.Player1Color;
            Player2Tile = form2.Player2Color;
            Computer = form2.Computer;

            InitializeComponent();
            Size = new Size(500, 550);

            //Score
            scoreR.SetBounds(125, 35, 50, 40);
            scoreR.Font = new Font(scoreR.Font.Name, 25);
            scoreR.Text = Convert.ToString(form2.scoreR);
            scoreR.ForeColor = Color.Crimson;
            Controls.Add(scoreR);

            scoreY.SetBounds(325, 35, 50, 40);
            scoreY.Font = new Font(scoreR.Font.Name, 25);
            scoreY.Text = Convert.ToString(form2.scoreY);
            scoreY.ForeColor = Color.Gold;
            Controls.Add(scoreY);

            for (int x = 0; x < 7; x++)
            {
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                btnArray[x] = new Button();
                btnArray[x].SetBounds(60 + (60 * x), 60, 40, 40);
                btnArray[x].BackColor = Color.Blue;
                btnArray[x].Text = Convert.ToString(x);
                btnArray[x].Click += new EventHandler(this.btnEvent_Click);
                Controls.Add(btnArray[x]);
                PointF[] points = new PointF[3];
                points[0] = new Point(5,3);
                points[1] = new Point(35,3);
                points[2] = new Point(20,20);

                path.AddPolygon(points);
                this.btnArray[x].Cursor = Cursors.Hand;
                this.btnArray[x].Region = new Region(path);
                if (form2.p1Red)
                {
                    btnArray[x].BackColor = Color.Crimson;
                }
                else
                {
                    btnArray[x].BackColor = Color.Gold;
                }
            }

            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                //https://stackoverflow.com/questions/11347576/how-to-make-a-circle-shape-label-in-window-form
                    var path = new System.Drawing.Drawing2D.GraphicsPath();
                    lblArray[x, y] = new Label();
                    lblArray[x, y].SetBounds(60 + (60 * x), 120 + (60 * y), 40, 40);
                    lblArray[x, y].BackColor = Color.Gray;
                    lblArray[x, y].ForeColor = lblArray[x, y].BackColor;
                    lblArray[x, y].Name = Convert.ToString(x) + "," + Convert.ToString(y);
                    path.AddEllipse(0, 0, lblArray[x,y].Width, lblArray[x,y].Height);
                    this.lblArray[x,y].Region = new Region(path);
                    Controls.Add(lblArray[x, y]);
                }
            }
            //frame for the discs/labels
            Label background = new Label();
            background.SetBounds(30, 120, 420, 360);
            background.BackColor = Color.RoyalBlue;
            Controls.Add(background);
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
        private Label VersusComputer()
        {
            Label chosenOne = null;

            //to find all the labels with the computer's colour
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {

                    //it will choose the one with the most labels of the right colour near which are in one line
                    if (Player1Tile == Color.Red && lblArray[i,j].BackColor == Color.Yellow)
                    {
                        if(chosenOne == null || this.getCounter(lblArray[i,j]) > this.getCounter(chosenOne))
                        {
                            chosenOne = lblArray[i, j];
                        }
                    }
                    else if (Player1Tile != Color.Red && lblArray[i, j].BackColor == Color.Red)
                    {
                        if (chosenOne == null || this.getCounter(lblArray[i, j]) > this.getCounter(chosenOne))
                        {
                            chosenOne = lblArray[i, j];
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
                //it first will try to choose a label at one end and then at the other
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
                            else if (lblArray[xC + i, yC + j].BackColor == Color.Gray)
                            {
                                x = xC + i;

                            }
                        }
                    }
                }
                else if (!this.OutOfRange(end, chosenOne))
                {
                    Label nextEnd = lblArray[this.getX(end) + this.getDifX(chosenOne), this.getY(end) + this.getDifY(chosenOne)];
                    if(this.checkCol(nextEnd) && nextEnd.BackColor == Color.Gray)
                    {
                        x = this.getX(nextEnd);
                    }
                    else if (!this.OutOfRange(start, chosenOne))
                    {
                        Label nextStart = lblArray[this.getX(start) - this.getDifX(chosenOne), this.getY(start) - this.getDifY(chosenOne)];
                        if(this.checkCol(nextStart) && nextStart.BackColor == Color.Gray)
                        {
                            x = this.getX(nextStart);
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
                if (lblArray[x, i].BackColor == Color.Gray)
                {
                    y = i;
                }
                else if (i == 5 && y == -1)
                {
                    i = 0;
                    x = rnd.Next(0, 7);
                }
            }

            return lblArray[x, y];
        }
        
        private Label chooseLabel(int counter, List<Label> labels)
        {
            Label end = this.getEnd(labels[counter], "negative");
            Label start = this.getEnd(labels[counter], "positive");
            Label chosenOne = null;

            //when ther is only one label or not a line of label the computer can continue,
            //it will choose a label around a label of its colour
            if ((this.getCounter(end) == 1 && !hard)  stillLabelsLeft)
            {
                int xC = this.getX(end);
                int yC = this.getY(end);

                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if ((i == 0 && j == 0)  i + xC > 6  i + xC < 0  j + yC > 5 || j + yC < 0)
                        {
                            continue;
                        }
                        else if (lbl[xC + i, yC + j].BackColor == Color.WhiteSmoke && this.checkCol(lbl[xC + i, yC + j])) 
                        {
                            chosenOne = lbl[xC + i, yC + j];
                            labels.Clear();
                            stillLabelsLeft = false;

                        }
                    }
                }
                //if no label is suitable around the given label, it will remove this label from the list
                if(chosenOne == null)
                {
                    labels.Remove(end);
                }
            }
//if there is a line of labels the computer will try to continue the line somehow
            else if (!this.OutOfRange(end, labels[counter]))
            {
                Label nextEnd = lbl[this.getX(end) - this.getDifX(labels[counter]), this.getY(end) - this.getDifY(labels[counter])];
                if (this.checkCol(nextEnd) && nextEnd.BackColor == Color.WhiteSmoke)
                {
                    Console.WriteLine(5678);
                    chosenOne = nextEnd;
                    return chosenOne;
                }
                else if (!this.OutOfRange(start, end))
                {
                    Label nextStart = lbl[this.getX(start) + this.getDifX(labels[counter]), this.getY(start) + this.getDifY(labels[counter])];
                    if (this.checkCol(nextStart) && nextStart.BackColor == Color.WhiteSmoke)
                    {
                        Console.WriteLine(7890);
                        chosenOne = nextStart;
                        return chosenOne;
                    }
                }

            }
            else if (!this.OutOfRange(start, labels[counter]))
            {
                Label nextStart = lbl[this.getX(start) + this.getDifX(labels[counter]), this.getY(start) + this.getDifY(labels[counter])];
                if (this.checkCol(nextStart) && nextStart.BackColor == Color.WhiteSmoke)
                {
                    Console.WriteLine(1234);
                    chosenOne = nextStart;
                    return chosenOne;
                }
            }
            return chosenOne;
        }
        
        //Method to sort the list of labels by the number of labels it has the same colour of in the same line
        private void sortList()
        {
            for (int i = 0; i < chosenLabels.Count; i++)
            {
                for (int j = 0; j < chosenLabels.Count; j++)
                {
                    if(this.getCounter(chosenLabels[i]) < this.getCounter(chosenLabels[j]))
                    {
                        Label label = chosenLabels[i];
                        chosenLabels[i] = chosenLabels[j];
                        chosenLabels[j] = label;
                    }
                }
            }
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
                else if(lblArray[x,y].BackColor == Color.Gray)
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

            if (lblArray[x, 0].BackColor != EmptyTile)
            {
                string msg = "Invalid move, please re-enter";
                MessageBox.Show(msg);
                return;
            }

            for (int i = 0; i < 6; i++)
            {
                if (lblArray[x, i].BackColor == Color.Gray)
                {
                    y = i;
                }
            }

            switch (turns % 2)
            {
                case 0:
                    lblArray[x, y].BackColor = Player2Tile;
                    break;
                case 1:
                    lblArray[x, y].BackColor = Player1Tile;
                    break;
            }
            
            if (CheckIfWin(x, y) || CheckIfPlayable())
            {
                return;
            }
            
            turns++;

            if (Computer == false) {
                return;
            }
            else if (Computer == true)
            {
                VersusComputer().BackColor = Player2Tile;
            } 

            if (CheckIfWin(x, y) || CheckIfPlayable())
            {
                return;
            }
            turns++;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private bool CheckIfWin(int x, int y)
        {
            if (this.getCounter(lblArray[x, y]) == 4)
            {
                switch (turns % 2)
                {
                    case 0:
                        MessageBox.Show("Player 2 has won!");
                        break;
                    case 1:
                        MessageBox.Show("Player 1 has won!");
                        break;
                }
                if (lblArray[x, y].BackColor == Color.Crimson)
                    {
                        form2.scoreR++;
                        scoreR.Text = Convert.ToString(form2.scoreR);
                    }
                    else
                    {
                        form2.scoreY++;
                        scoreY.Text = Convert.ToString(form2.scoreY);
                    }
                ResetGame();
                return true;
            }
            return false;
        }

        private bool CheckIfPlayable()
        {
            for (int x = 0; x < 6; x++)
            {
                if (lblArray[x, 0].BackColor == Color.Gray)
                {
                    return false;
                }
            }

            MessageBox.Show("Draw! No winners this time :)");
            ResetGame();
            return true;
            
        }

        private void ResetGame()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    lblArray[j, i].BackColor = EmptyTile;
                }
            }
            turns = 1;
        }

        //Returns a counter of all labels of one colour in the same line
        private int countDisks(Label label, int xDif, int yDif)
        {
            int x = this.getX(label);
            int y = this.getY(label);
            Label next = lblArray[x, y];
            int counter = 0;

            while (next.BackColor == label.BackColor)
            {
                if ((xDif == 0 && yDif == 0) || x + xDif > 6 || x + xDif < 0 || y + yDif > 5 || y + yDif < 0)
                {
                    break;
                }
                else if (lblArray[x + xDif, y + yDif].BackColor != label.BackColor)
                {
                    break;
                }
                x += xDif;
                y += yDif;
                next = lblArray[x, y];
            }

            while (next.BackColor == label.BackColor)
            {
                counter++;
                if ((xDif == 0 && yDif == 0) || x - xDif > 6 || x - xDif < 0 || y - yDif > 5 || y - yDif < 0)
                {
                    break;
                }
                else if (lblArray[x - xDif, y - yDif].BackColor != label.BackColor)
                {
                    break;
                }
                x -= xDif;
                y -= yDif;
                next = lblArray[x, y];
            }
            return counter;
        }

        //Returns either end of the line of same coloured labels as the given label
        //The given string decides if the calculated difference should be added or subtracted
        private Label getEnd(Label label, string side)
        {
            int x = this.getX(label);
            int y = this.getY(label);
            Label next = lblArray[x,y];
            int xDif= this.getDifX(label);
            int yDif = this.getDifY(label);

            if (side == "negative")
            {
                xDif = -xDif;
                yDif = -yDif;
            }

            //it will move on to the next label until there is no label of the same colour or no label at all
            while (next.BackColor == label.BackColor)
            {
                if ((xDif == 0 && yDif == 0) || x + xDif > 6 || x + xDif < 0 || y + yDif > 5 || y + yDif < 0)
                {
                    break;
                }
                else if (lblArray[x + xDif, y + yDif].BackColor != label.BackColor)
                {
                    break;
                }
                x += xDif;
                y += yDif;
                next = lblArray[x, y];
            }
            return next;

        }
        
        //Returns the difference of the x coordinate of the given label and the label next to it with the same colour
        private int getDifX(Label label)
        {
            int x = this.getX(label);
            int y = this.getY(label);
            int counter = 0;
            int xDif = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if ((i == 0 && j == 0) || i + x > 6 || i + x < 0 || j + y > 5 || j + y < 0)
                    {
                        continue;
                    }
                    else if (lblArray[x + i, y + j].BackColor == lblArray[x, y].BackColor)
                    {
                        if (this.countDisks(label, i, j) > counter)
                        {
                            counter = this.countDisks(label, i, j);
                            xDif = i;
                        }

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
            int counter = 0;
            int yDif = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if ((i == 0 && j == 0) || i + x > 6 || i + x < 0 || j + y > 5 || j + y < 0)
                    {
                        continue;
                    }
                    else if (lblArray[x + i, y + j].BackColor == lblArray[x, y].BackColor)
                    {
                        if (this.countDisks(label,i,j) > counter)
                        {
                            counter = this.countDisks(label, i, j);
                            yDif = j;
                        }

                    }
                }
            }
            return yDif;
        }
        
        private int getCounter(Label label)
        {
            int x = this.getDifX(label);
            int y = this.getDifY(label);

            return this.countDisks(label,x,y);
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
                    lblArray[j, i].BackColor = Color.Gray;
                }
            }
        }

        private void licenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Created by Elliot Morgan-Davies, Pia Schroeter and Jerry Deligiannis at Dundee University (c)", "Licence", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void changeModesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 menu = new Form2();
            this.Hide();
            menu.ShowDialog();
        }  
       
    }
}
