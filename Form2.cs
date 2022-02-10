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
        public int scoreR;
        public int scoreY;
        public bool p1Red;
        public bool computer;

        public Form2()
        {
            InitializeComponent();
            p1Red = true;

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
            path.AddEllipse(3,3, btnC1.Width-7, btnC1.Height-7);
            this.btnC1.Region = new Region(path);

            path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(3,3, btnC2.Width-7, btnC2.Height-7);
            this.btnC2.Region = new Region(path);

            btnC1.Click += new EventHandler(this.btnColour_Click);
            btnC2.Click += new EventHandler(this.btnColour_Click);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void btnStrt_Click(object sender, EventArgs e)
        {
            computer = false;
            Form1 game = new Form1(this);
            game.ShowDialog();
            this.Close();
        }

        private void btnQt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnColour_Click(object sender, EventArgs e)
        {
            this.rstScore();

            if(btnC1.BackColor == Color.Crimson)
            {
                btnC1.BackColor = Color.Gold;
                btnC2.BackColor = Color.Crimson;
                p1Red = false;
            }
            else
            {
                btnC2.BackColor = Color.Gold;
                btnC1.BackColor = Color.Crimson;
                p1Red = true;
            }
        }
        public void rstScore()
        {
            scoreR = 0;
            scoreY = 0;
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
