namespace TankiTools
{
    partial class SelectableScreenshotArea
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
            this.SplashScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SplashScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // SplashScreen
            // 
            this.SplashScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplashScreen.InitialImage = null;
            this.SplashScreen.Location = new System.Drawing.Point(0, 0);
            this.SplashScreen.Name = "SplashScreen";
            this.SplashScreen.Size = new System.Drawing.Size(284, 262);
            this.SplashScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SplashScreen.TabIndex = 0;
            this.SplashScreen.TabStop = false;
            this.SplashScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.SplashScreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.SplashScreen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SplashScreen_MouseUp);
            // 
            // SelectableScreenshotArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.SplashScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectableScreenshotArea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SelectableScreenshotArea_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SplashScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SplashScreen;
    }
}