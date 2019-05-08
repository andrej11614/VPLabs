namespace Pacman
{
    partial class Form1
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
            this.tbpoeni = new System.Windows.Forms.TextBox();
            this.pbpoints = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // tbpoeni
            // 
            this.tbpoeni.CausesValidation = false;
            this.tbpoeni.Enabled = false;
            this.tbpoeni.Location = new System.Drawing.Point(13, 411);
            this.tbpoeni.Name = "tbpoeni";
            this.tbpoeni.ReadOnly = true;
            this.tbpoeni.Size = new System.Drawing.Size(100, 20);
            this.tbpoeni.TabIndex = 200000;
            this.tbpoeni.TabStop = false;
            // 
            // pbpoints
            // 
            this.pbpoints.Location = new System.Drawing.Point(13, 437);
            this.pbpoints.Name = "pbpoints";
            this.pbpoints.Size = new System.Drawing.Size(599, 23);
            this.pbpoints.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 471);
            this.Controls.Add(this.pbpoints);
            this.Controls.Add(this.tbpoeni);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbpoeni;
        private System.Windows.Forms.ProgressBar pbpoints;
    }
}

