namespace KeyBoard
{
    partial class FloatingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FloatingForm));
            this.SuspendLayout();
            // 
            // FloatingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KeyBoard.Properties.Resources.kb;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(78, 44);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FloatingForm";
            this.Opacity = 0.8D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FloatingForm";
            this.Load += new System.EventHandler(this.FloatingForm_Load);
            this.Click += new System.EventHandler(this.FloatingForm_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FloatingForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FloatingForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FloatingForm_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}