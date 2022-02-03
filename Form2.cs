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
        public int scoreR;
        public int scoreY;
        public bool p1Red;

        public Form2()
        {
            InitializeComponent();
            p1Red = true;
            btnC1.Click += new EventHandler(this.btnColour_Click);
            btnC2.Click += new EventHandler(this.btnColour_Click);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void btnStrt_Click(object sender, EventArgs e)
        {
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

            if(btnC1.BackColor == Color.Red)
            {
                btnC1.BackColor = Color.Yellow;
                btnC2.BackColor = Color.Red;
                p1Red = false;
            }
            else
            {
                btnC2.BackColor = Color.Yellow;
                btnC1.BackColor = Color.Red;
                p1Red = true;
            }
        }
        public void rstScore()
        {
            scoreR = 0;
            scoreY = 0;
        }
    }
}
