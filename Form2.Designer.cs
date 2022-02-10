
namespace Connect4_Personal
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.btnQuit = new System.Windows.Forms.Button();
            this.lblP1 = new System.Windows.Forms.Label();
            this.lblOpponent = new System.Windows.Forms.Label();
            this.btnPlayer1Colour = new System.Windows.Forms.Button();
            this.btnPlayer2Colour = new System.Windows.Forms.Button();
            this.btnArrowLeft = new System.Windows.Forms.Button();
            this.btnArrowRight = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            resources.ApplyResources(this.btnQuit, "btnQuit");
            this.btnQuit.BackColor = System.Drawing.Color.Transparent;
            this.btnQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuit.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnQuit.FlatAppearance.BorderSize = 0;
            this.btnQuit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.btnQuit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnToQuit_Click);
            // 
            // lblP1
            // 
            resources.ApplyResources(this.lblP1, "lblP1");
            this.lblP1.Name = "lblP1";
            // 
            // lblOpponent
            // 
            resources.ApplyResources(this.lblOpponent, "lblOpponent");
            this.lblOpponent.Name = "lblOpponent";
            // 
            // btnPlayer1Colour
            // 
            this.btnPlayer1Colour.BackColor = System.Drawing.Color.Crimson;
            resources.ApplyResources(this.btnPlayer1Colour, "btnPlayer1Colour");
            this.btnPlayer1Colour.Name = "btnPlayer1Colour";
            this.btnPlayer1Colour.UseVisualStyleBackColor = false;
            this.btnPlayer1Colour.Click += new System.EventHandler(this.btnColour_Click);
            // 
            // btnPlayer2Colour
            // 
            this.btnPlayer2Colour.BackColor = System.Drawing.Color.Gold;
            this.btnPlayer2Colour.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnPlayer2Colour, "btnPlayer2Colour");
            this.btnPlayer2Colour.Name = "btnPlayer2Colour";
            this.btnPlayer2Colour.UseVisualStyleBackColor = false;
            this.btnPlayer2Colour.Click += new System.EventHandler(this.btnColour_Click);
            // 
            // btnArrowLeft
            // 
            this.btnArrowLeft.BackColor = System.Drawing.Color.Black;
            this.btnArrowLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnArrowLeft, "btnArrowLeft");
            this.btnArrowLeft.Name = "btnArrowLeft";
            this.btnArrowLeft.UseVisualStyleBackColor = false;
            this.btnArrowLeft.Click += new System.EventHandler(this.btnArrowLeft_Click);
            // 
            // btnArrowRight
            // 
            this.btnArrowRight.BackColor = System.Drawing.Color.Black;
            this.btnArrowRight.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnArrowRight, "btnArrowRight");
            this.btnArrowRight.Name = "btnArrowRight";
            this.btnArrowRight.UseVisualStyleBackColor = false;
            this.btnArrowRight.Click += new System.EventHandler(this.btnArrowRight_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnPlay
            // 
            resources.ApplyResources(this.btnPlay, "btnPlay");
            this.btnPlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlay.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Purple;
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkMagenta;
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnArrowRight);
            this.Controls.Add(this.btnArrowLeft);
            this.Controls.Add(this.btnPlayer2Colour);
            this.Controls.Add(this.btnPlayer1Colour);
            this.Controls.Add(this.lblOpponent);
            this.Controls.Add(this.lblP1);
            this.Controls.Add(this.btnQuit);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lblP1;
        private System.Windows.Forms.Label lblOpponent;
        private System.Windows.Forms.Button btnPlayer1Colour;
        private System.Windows.Forms.Button btnPlayer2Colour;
        private System.Windows.Forms.Button btnArrowLeft;
        private System.Windows.Forms.Button btnArrowRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPlay;
    }
}