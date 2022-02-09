
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
            this.btnQt = new System.Windows.Forms.Button();
            this.lblP1 = new System.Windows.Forms.Label();
            this.lblOpponent = new System.Windows.Forms.Label();
            this.btnC1 = new System.Windows.Forms.Button();
            this.btnC2 = new System.Windows.Forms.Button();
            this.btnArrowLeft = new System.Windows.Forms.Button();
            this.btnArrowRight = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnQt
            // 
            resources.ApplyResources(this.btnQt, "btnQt");
            this.btnQt.BackColor = System.Drawing.Color.Transparent;
            this.btnQt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQt.FlatAppearance.BorderColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnQt.FlatAppearance.BorderSize = 0;
            this.btnQt.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.btnQt.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.btnQt.Name = "btnQt";
            this.btnQt.UseVisualStyleBackColor = false;
            this.btnQt.Click += new System.EventHandler(this.btnQt_Click);
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
            // btnC1
            // 
            this.btnC1.BackColor = System.Drawing.Color.Crimson;
            resources.ApplyResources(this.btnC1, "btnC1");
            this.btnC1.Name = "btnC1";
            this.btnC1.UseVisualStyleBackColor = false;
            // 
            // btnC2
            // 
            this.btnC2.BackColor = System.Drawing.Color.Gold;
            this.btnC2.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnC2, "btnC2");
            this.btnC2.Name = "btnC2";
            this.btnC2.UseVisualStyleBackColor = false;
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
            this.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnArrowRight);
            this.Controls.Add(this.btnArrowLeft);
            this.Controls.Add(this.btnC2);
            this.Controls.Add(this.btnC1);
            this.Controls.Add(this.lblOpponent);
            this.Controls.Add(this.lblP1);
            this.Controls.Add(this.btnQt);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnQt;
        private System.Windows.Forms.Label lblP1;
        private System.Windows.Forms.Label lblOpponent;
        private System.Windows.Forms.Button btnC1;
        private System.Windows.Forms.Button btnC2;
        private System.Windows.Forms.Button btnArrowLeft;
        private System.Windows.Forms.Button btnArrowRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPlay;
    }
}