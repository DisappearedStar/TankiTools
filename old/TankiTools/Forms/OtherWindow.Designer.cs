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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OtherWindow));
            this.btnUploadScreenshot = new System.Windows.Forms.Button();
            this.btnUploadVideo = new System.Windows.Forms.Button();
            this.btnOpenMediaHistory = new System.Windows.Forms.Button();
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
            this.btnUploadVideo.UseVisualStyleBackColor = true;
            this.btnUploadVideo.Click += new System.EventHandler(this.btnUploadVideo_Click);
            // 
            // btnOpenMediaHistory
            // 
            this.btnOpenMediaHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenMediaHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpenMediaHistory.Location = new System.Drawing.Point(12, 118);
            this.btnOpenMediaHistory.Name = "btnOpenMediaHistory";
            this.btnOpenMediaHistory.Size = new System.Drawing.Size(274, 47);
            this.btnOpenMediaHistory.TabIndex = 2;
            this.btnOpenMediaHistory.UseVisualStyleBackColor = true;
            this.btnOpenMediaHistory.Click += new System.EventHandler(this.btnOpenMediaHistory_Click);
            // 
            // OtherWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 177);
            this.Controls.Add(this.btnOpenMediaHistory);
            this.Controls.Add(this.btnUploadVideo);
            this.Controls.Add(this.btnUploadScreenshot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OtherWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OtherWindow_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnUploadScreenshot;
        private System.Windows.Forms.Button btnUploadVideo;
        private System.Windows.Forms.Button btnOpenMediaHistory;
    }
}