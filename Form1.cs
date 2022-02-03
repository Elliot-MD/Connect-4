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
        Label[,] lbl = new Label[7, 6];
        int PlayerNumber = 1;
        bool validMove = true;
        bool won;

        public Form1()
        {
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
                    lbl[x, y].SetBounds(60 + (60 * x), 60 + (60 * y), 40, 40);
                    lbl[x, y].BackColor = Color.Gray;
                    lbl[x, y].ForeColor = lbl[x, y].BackColor;
                    Controls.Add(lbl[x, y]);
                }
            }
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

            if (lbl[x, 1].BackColor == Color.Yellow || lbl[x, 1].BackColor == Color.Red)
            {
                validMove = false;
                string msg = "Invalid move, please re-enter";
                MessageBox.Show(msg);
            }else
            {
                validMove = true;
            }
            if (PlayerNumber == 1)
            {
                lbl[x, y].BackColor = Color.Red;
            }else if (PlayerNumber == 2)
            {
                lbl[x, y].BackColor = Color.Yellow;
            }
            //TODO ADD INVALID INPUT CLAUSE

            if (PlayerNumber == 1)
            {
                if (validMove == true)
                {
                    PlayerNumber = 2;
                }
            }else if(PlayerNumber == 2)
            {
                if (validMove == true)
                {
                    PlayerNumber = 1;
                }
            }

            checkSurroundings(x, y);

            if (won)
            {
                MessageBox.Show(lbl[x,y].BackColor + " has won!");
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        lbl[j,i].BackColor = Color.Gray;
                    }
                }
                won = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //checks surrounding for labels with same colour
        void checkSurroundings(int x, int y)
        {
            for(int i = -1; i < 2; i++)
            {
                for(int j = -1; j < 2; j++)
                {
                    if((i == 0 && j== 0) || i + x > 6 || i + x < 0 || j + y > 5 || j + y < 0)
                    {
                        continue;
                    }
                    else if(lbl[x+i,y+j].BackColor == lbl[x, y].BackColor)
                    {
                        countDisk(x, y, i, j);
                    }
                }
            }
        }

        //counts labels with same colour in same row
        //sets won as true when it finds 4 labels in the same row
        void countDisk(int xCur, int yCur, int xDif, int yDif)
        {
            Label next = lbl[xCur, yCur];
            int x = xCur;
            int y = yCur;
            int counter = 0;

            //goes to one end of disks with the same colour
            while(next.BackColor == lbl[xCur,yCur].BackColor)
            {
                if (x + xDif > 6 || x + xDif < 0 || y + yDif > 5 || y + yDif < 0)
                {
                    break;
                }
                else if(lbl[x+xDif,y+yDif].BackColor != lbl[xCur, yCur].BackColor)
                {
                    break;
                }
                x += xDif;
                y += yDif;
                next = lbl[x, y];
            }

            //starts to count disk in same line from one ende
            while(next.BackColor == lbl[xCur,yCur].BackColor && !won)
            {
                counter++;
                if(counter == 4)
                {
                    won = true;
                    break;
                }
                else if (x - xDif > 6 || x - xDif < 0 || y - yDif > 5 || y - yDif < 0)
                {
                    break;
                }
                x -= xDif;
                y -= yDif;
                next = lbl[x, y];
                
            }

        }
    }
}
