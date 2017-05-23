namespace TankiTools
{
    partial class OtherWindow
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
            this.btnUploadScreenshot = new System.Windows.Forms.Button();
            this.btnUploadVideo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUploadScreenshot
            // 
            this.btnUploadScreenshot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadScreenshot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUploadScreenshot.Location = new System.Drawing.Point(12, 12);
            this.btnUploadScreenshot.Name = "btnUploadScreenshot";
            this.btnUploadScreenshot.Size = new System.Drawing.Size(274, 47);
            this.btnUploadScreenshot.TabIndex = 0;
            this.btnUploadScreenshot.Text = "Загрузить скриншот";
            this.btnUploadScreenshot.UseVisualStyleBackColor = true;
            this.btnUploadScreenshot.Click += new System.EventHandler(this.btnUploadScreenshot_Click);
            // 
            // btnUploadVideo
            // 
            this.btnUploadVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUploadVideo.Location = new System.Drawing.Point(12, 65);
            this.btnUploadVideo.Name = "btnUploadVideo";
            this.btnUploadVideo.Size = new System.Drawing.Size(274, 47);
            this.btnUploadVideo.TabIndex = 1;
            this.btnUploadVideo.Text = "Загрузить видео";
            this.btnUploadVideo.UseVisualStyleBackColor = true;
            this.btnUploadVideo.Click += new System.EventHandler(this.btnUploadVideo_Click);
            // 
            // OtherWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 122);
            this.Controls.Add(this.btnUploadVideo);
            this.Controls.Add(this.btnUploadScreenshot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "OtherWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Другое";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnUploadScreenshot;
        private System.Windows.Forms.Button btnUploadVideo;
    }
}