using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//The icon for the game and menu was taken from https://apptopia.com/google-play/app/com.owgun.connectboard/intelligence

namespace Connect4_Personal
{
    public partial class Form2 : Form
    {
        //Players' score
        public int scorePlayer1;
        public int scorePlayer2;

        //Players' colours
        public Color player1Colour;
        public Color player2Colour;

        //Bools for the opponents and the difficulty level
        public bool  computer;
        public bool hard;

        public Form2()
        {
            InitializeComponent();
            scorePlayer1 = 0;
            scorePlayer2 = 0;

            player1Colour = Color.Crimson;
            player2Colour = Color.Gold;

            //Left arrow to change the opponent
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            PointF[] points = new PointF[3];
            points[0] = new Point(29, 3);
            points[1] = new Point(29,29);
            points[2] = new Point(9, 16);
            path.AddPolygon(points);
            this.btnArrowLeft.Region = new Region(path);

            //Right arrow to change the opponent
            path = new System.Drawing.Drawing2D.GraphicsPath();
            points = new PointF[3];
            points[0] = new Point(4, 3);
            points[1] = new Point(4,29);
            points[2] = new Point(24, 16);
            path.AddPolygon(points);
            this.btnArrowRight.Region = new Region(path);

            //The colour buttons have the same code as the pieces in the game to make them round
            //Player 1's colour
            path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(3,3, btnPlayer1Colour.Width-7, btnPlayer1Colour.Height-7);
            this.btnPlayer1Colour.Region = new Region(path);

            //Player 2's colour
            path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(3,3, btnPlayer2Colour.Width-7, btnPlayer2Colour.Height-7);
            this.btnPlayer2Colour.Region = new Region(path);
        }
        
        //Event handler for the left button to change the opponent of player 1
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

        //Event handler for the right button to change the opponent of player 1
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

        //Event handler for the play button
        private void btnPlay_Click(object sender, EventArgs e)
        {
            //specific bools will be set based on the chosen opponent
            if(lblOpponent.Text == "    Player 2")
            {
                computer = false;
            }
            else
            {
                computer = true;
                if(lblOpponent.Text == "Computer (hard)")
                {
                    hard = true;
                }
                else
                {
                    hard = false;
                }
            }

            //The game will open up in a new form and the menu will close
            Form1 game = new Form1(this);
            game.ShowDialog();
            this.Close();
        }
        
        //The player can switch between gold and yellow for the colour of his pieces
        void btnColour_Click(object sender, EventArgs e)
        {
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

        //Button to close the menu
        private void btnToQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }
    }
}
