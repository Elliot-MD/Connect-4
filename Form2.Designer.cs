
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
            this.btnStrt = new System.Windows.Forms.Button();
            this.btnQt = new System.Windows.Forms.Button();
            this.lblP1 = new System.Windows.Forms.Label();
            this.lblP2 = new System.Windows.Forms.Label();
            this.btnC1 = new System.Windows.Forms.Button();
            this.btnC2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStrt
            // 
            resources.ApplyResources(this.btnStrt, "btnStrt");
            this.btnStrt.Name = "btnStrt";
            this.btnStrt.UseVisualStyleBackColor = true;
            this.btnStrt.Click += new System.EventHandler(this.btnStrt_Click);
            // 
            // btnQt
            // 
            resources.ApplyResources(this.btnQt, "btnQt");
            this.btnQt.Name = "btnQt";
            this.btnQt.UseVisualStyleBackColor = true;
            this.btnQt.Click += new System.EventHandler(this.btnQt_Click);
            // 
            // lblP1
            // 
            resources.ApplyResources(this.lblP1, "lblP1");
            this.lblP1.Name = "lblP1";
            // 
            // lblP2
            // 
            resources.ApplyResources(this.lblP2, "lblP2");
            this.lblP2.Name = "lblP2";
            // 
            // btnC1
            // 
            this.btnC1.BackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.btnC1, "btnC1");
            this.btnC1.Name = "btnC1";
            this.btnC1.UseVisualStyleBackColor = false;
            // 
            // btnC2
            // 
            this.btnC2.BackColor = System.Drawing.Color.Yellow;
            resources.ApplyResources(this.btnC2, "btnC2");
            this.btnC2.Name = "btnC2";
            this.btnC2.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnC2);
            this.Controls.Add(this.btnC1);
            this.Controls.Add(this.lblP2);
            this.Controls.Add(this.lblP1);
            this.Controls.Add(this.btnQt);
            this.Controls.Add(this.btnStrt);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStrt;
        private System.Windows.Forms.Button btnQt;
        private System.Windows.Forms.Label lblP1;
        private System.Windows.Forms.Label lblP2;
        private System.Windows.Forms.Button btnC1;
        private System.Windows.Forms.Button btnC2;
    }
}