﻿namespace TankiTools
{
    partial class MediaHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaHistory));
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.PanelWrapper = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Status
            // 
            this.Status.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(400, 17);
            this.Status.Spring = true;
            this.Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 326);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(415, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // PanelWrapper
            // 
            this.PanelWrapper.AutoScroll = true;
            this.PanelWrapper.AutoSize = true;
            this.PanelWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelWrapper.Location = new System.Drawing.Point(0, 0);
            this.PanelWrapper.Name = "PanelWrapper";
            this.PanelWrapper.Size = new System.Drawing.Size(415, 326);
            this.PanelWrapper.TabIndex = 1;
            // 
            // MediaHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(415, 348);
            this.Controls.Add(this.PanelWrapper);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(355, 115);
            this.Name = "MediaHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MediaHistory_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel PanelWrapper;
    }
}