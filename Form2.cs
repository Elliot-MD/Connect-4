using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Icon address : https://apptopia.com/google-play/app/com.owgun.connectboard/intelligence

namespace Connect4_Personal
{
    public partial class Form2 : Form
    {
        public int scorePlayer1;
        public int scorePlayer2;
        public Color player1Colour;
        public Color player2Colour;
        public bool  computer;

        public Form2()
        {
            InitializeComponent();
            player1Colour = Color.Crimson;
            player2Colour = Color.Gold;

            var path = new System.Drawing.Drawing2D.GraphicsPath();
            PointF[] points = new PointF[3];
            points[0] = new Point(29, 3);
            points[1] = new Point(29,29);
            points[2] = new Point(9, 16);
            path.AddPolygon(points);
            this.btnArrowLeft.Region = new Region(path);

            path = new System.Drawing.Drawing2D.GraphicsPath();
            points = new PointF[3];
            points[0] = new Point(4, 3);
            points[1] = new Point(4,29);
            points[2] = new Point(24, 16);
            path.AddPolygon(points);
            this.btnArrowRight.Region = new Region(path);

            path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(3,3, btnPlayer1Colour.Width-7, btnPlayer1Colour.Height-7);
            this.btnPlayer1Colour.Region = new Region(path);

            path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(3,3, btnPlayer2Colour.Width-7, btnPlayer2Colour.Height-7);
            this.btnPlayer2Colour.Region = new Region(path);
        }


        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void btnToQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnColour_Click(object sender, EventArgs e)
        {
            this.resetScore();

            if(btnPlayer1Colour.BackColor == Color.Crimson)
            {
                btnPlayer1Colour.BackColor = Color.Gold;
                btnPlayer2Colour.BackColor = Color.Crimson;
                player1Colour = Color.Gold;
                player2Colour = Color.Crimson;
            }
            else
            {
                btnPlayer2Colour.BackColor = Color.Gold;
                btnPlayer1Colour.BackColor = Color.Crimson;
                player2Colour = Color.Gold;
                player1Colour = Color.Crimson;
            }
        }
        public void resetScore()
        {
            scorePlayer1 = 0;
            scorePlayer2 = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            computer = true;
            Form1 game = new Form1(this);
            game.ShowDialog();
            this.Close();
        }

        private void btnArrowLeft_Click(object sender, EventArgs e)
        {
            if(lblOpponent.Text == "    Player 2")
            {
                lblOpponent.Text = "Computer (hard)";
            }
            else if(lblOpponent.Text == "Computer (hard)")
            {
                lblOpponent.Text = "Computer (easy)";
            }
            else if(lblOpponent.Text == "Computer (easy)")
            {
                lblOpponent.Text = "    Player 2";
            }
        }

        private void btnArrowRight_Click(object sender, EventArgs e)
        {
            if (lblOpponent.Text == "    Player 2")
            {
                lblOpponent.Text = "Computer (easy)";
            }
            else if (lblOpponent.Text == "Computer (easy)")
            {
                lblOpponent.Text = "Computer (hard)";
            }
            else if (lblOpponent.Text == "Computer (hard)")
            {
                lblOpponent.Text = "    Player 2";
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if(lblOpponent.Text == "    Player 2")
            {
                computer = false;
            }
            else
            {
                computer = true;
            }

            Form1 game = new Form1(this);
            game.ShowDialog();
            this.Close();
        }
    }
}
