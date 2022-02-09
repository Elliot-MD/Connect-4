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
    public partial class Form2 : Form
    {
        public int ScorePlayer1;
        public int ScorePlayer2;
        public Color Player1Color;
        public Color Player2Color;

        public bool Computer = false;

        public Form2()
        {
            InitializeComponent();
            Player1Color = Color.Red;
            Player2Color = Color.Yellow;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        //Button to start
        private void btnStart_Click(object sender, EventArgs e)
        {
            Computer = true;
            Form1 GameVersusPlayers = new Form1(this);
            GameVersusPlayers.ShowDialog();
            this.Close();
        }

        //Button to quit
        private void btnToQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void btnColor_Click(object sender, EventArgs e)
        {
            this.ResetScore();

            if(btnPlayer1Color.BackColor == Color.Red)
            {
                btnPlayer1Color.BackColor = Color.Yellow;
                btnPlayer2Color.BackColor = Color.Red;
                Player1Color = Color.Yellow;
                Player2Color = Color.Red;
            }
            else
            {
                btnPlayer2Color.BackColor = Color.Yellow;
                btnPlayer1Color.BackColor = Color.Red;
                Player1Color = Color.Red;
                Player2Color = Color.Yellow;
            }
        }
        public void ResetScore()
        {
            ScorePlayer1 = 0;
            ScorePlayer2 = 0;
        }

        private void btnToStartVsComputer_Click(object sender, EventArgs e)
        {
            Computer = true;
            Form1 GameVersusComputer = new Form1(this);
            GameVersusComputer.ShowDialog();
            this.Close();
        }
    }
}
