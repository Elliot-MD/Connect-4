
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
            this.btnToStartVSPlayers = new System.Windows.Forms.Button();
            this.btnToQuit = new System.Windows.Forms.Button();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.btnPlayer1Color = new System.Windows.Forms.Button();
            this.btnPlayer2Color = new System.Windows.Forms.Button();
            this.btnToStartVsComputer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnToStartVSPlayers
            // 
            this.btnToStartVSPlayers.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnToStartVSPlayers, "btnToStartVSPlayers");
            this.btnToStartVSPlayers.Name = "btnToStartVSPlayers";
            this.btnToStartVSPlayers.UseVisualStyleBackColor = false;
            this.btnToStartVSPlayers.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnToQuit
            // 
            resources.ApplyResources(this.btnToQuit, "btnToQuit");
            this.btnToQuit.Name = "btnToQuit";
            this.btnToQuit.UseVisualStyleBackColor = true;
            this.btnToQuit.Click += new System.EventHandler(this.btnToQuit_Click);
            // 
            // lblPlayer1
            // 
            resources.ApplyResources(this.lblPlayer1, "lblPlayer1");
            this.lblPlayer1.Name = "lblPlayer1";
            // 
            // lblPlayer2
            // 
            resources.ApplyResources(this.lblPlayer2, "lblPlayer2");
            this.lblPlayer2.Name = "lblPlayer2";
            // 
            // btnPlayer1Color
            // 
            this.btnPlayer1Color.BackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.btnPlayer1Color, "btnPlayer1Color");
            this.btnPlayer1Color.Name = "btnPlayer1Color";
            this.btnPlayer1Color.UseVisualStyleBackColor = false;
            this.btnPlayer1Color.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnPlayer2Color
            // 
            this.btnPlayer2Color.BackColor = System.Drawing.Color.Yellow;
            resources.ApplyResources(this.btnPlayer2Color, "btnPlayer2Color");
            this.btnPlayer2Color.Name = "btnPlayer2Color";
            this.btnPlayer2Color.UseVisualStyleBackColor = false;
            this.btnPlayer2Color.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnToStartVsComputer
            // 
            this.btnToStartVsComputer.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnToStartVsComputer, "btnToStartVsComputer");
            this.btnToStartVsComputer.Name = "btnToStartVsComputer";
            this.btnToStartVsComputer.UseVisualStyleBackColor = false;
            this.btnToStartVsComputer.Click += new System.EventHandler(this.btnToStartVsComputer_Click);
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnToStartVsComputer);
            this.Controls.Add(this.btnPlayer2Color);
            this.Controls.Add(this.btnPlayer1Color);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblPlayer1);
            this.Controls.Add(this.btnToQuit);
            this.Controls.Add(this.btnToStartVSPlayers);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnToStartVSPlayers;
        private System.Windows.Forms.Button btnToQuit;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Button btnPlayer1Color;
        private System.Windows.Forms.Button btnPlayer2Color;
        private System.Windows.Forms.Button btnToStartVsComputer;
    }
}
