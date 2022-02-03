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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
