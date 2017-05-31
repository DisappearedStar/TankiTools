namespace TankiTools
{
    partial class TroubleshootingWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TroubleshootingWindow));
            this.labelWarning = new System.Windows.Forms.Label();
            this.btnIncreaseCache = new System.Windows.Forms.Button();
            this.btnClearShared = new System.Windows.Forms.Button();
            this.btnClearCache = new System.Windows.Forms.Button();
            this.groupClients = new System.Windows.Forms.GroupBox();
            this.groupNetwork = new System.Windows.Forms.GroupBox();
            this.btnOpenPorts = new System.Windows.Forms.Button();
            this.btnSetTcpAck = new System.Windows.Forms.Button();
            this.btnResetTcpAck = new System.Windows.Forms.Button();
            this.btnSetNetworkThrottling = new System.Windows.Forms.Button();
            this.btnResetNetworkThrottling = new System.Windows.Forms.Button();
            this.labelTcpAck = new System.Windows.Forms.Label();
            this.labelNetworkThrottling = new System.Windows.Forms.Label();
            this.toolTipForTcp = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipForThrottling = new System.Windows.Forms.ToolTip(this.components);
            this.linkToWikiArticle = new System.Windows.Forms.LinkLabel();
            this.groupClients.SuspendLayout();
            this.groupNetwork.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWarning
            // 
            this.labelWarning.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelWarning.Location = new System.Drawing.Point(6, 45);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(190, 56);
            this.labelWarning.TabIndex = 7;
            this.labelWarning.Text = "Внимание: действия применяются к браузеру/клиенту, выбранному в настройках програ" +
    "ммы: ";
            // 
            // btnIncreaseCache
            // 
            this.btnIncreaseCache.Location = new System.Drawing.Point(100, 127);
            this.btnIncreaseCache.Name = "btnIncreaseCache";
            this.btnIncreaseCache.Size = new System.Drawing.Size(97, 23);
            this.btnIncreaseCache.TabIndex = 6;
            this.btnIncreaseCache.Text = "Увеличить кэш";
            this.btnIncreaseCache.UseVisualStyleBackColor = true;
            // 
            // btnClearShared
            // 
            this.btnClearShared.Location = new System.Drawing.Point(6, 156);
            this.btnClearShared.Name = "btnClearShared";
            this.btnClearShared.Size = new System.Drawing.Size(144, 23);
            this.btnClearShared.TabIndex = 5;
            this.btnClearShared.Text = "Очистить Shared Objects";
            this.btnClearShared.UseVisualStyleBackColor = true;
            // 
            // btnClearCache
            // 
            this.btnClearCache.Location = new System.Drawing.Point(6, 127);
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(88, 23);
            this.btnClearCache.TabIndex = 4;
            this.btnClearCache.Text = "Очистить кэш";
            this.btnClearCache.UseVisualStyleBackColor = true;
            // 
            // groupClients
            // 
            this.groupClients.Controls.Add(this.btnClearShared);
            this.groupClients.Controls.Add(this.labelWarning);
            this.groupClients.Controls.Add(this.btnClearCache);
            this.groupClients.Controls.Add(this.btnIncreaseCache);
            this.groupClients.Location = new System.Drawing.Point(12, 12);
            this.groupClients.Name = "groupClients";
            this.groupClients.Size = new System.Drawing.Size(204, 185);
            this.groupClients.TabIndex = 8;
            this.groupClients.TabStop = false;
            this.groupClients.Text = "Браузеры и клиенты";
            // 
            // groupNetwork
            // 
            this.groupNetwork.Controls.Add(this.linkToWikiArticle);
            this.groupNetwork.Controls.Add(this.labelNetworkThrottling);
            this.groupNetwork.Controls.Add(this.labelTcpAck);
            this.groupNetwork.Controls.Add(this.btnResetNetworkThrottling);
            this.groupNetwork.Controls.Add(this.btnSetNetworkThrottling);
            this.groupNetwork.Controls.Add(this.btnResetTcpAck);
            this.groupNetwork.Controls.Add(this.btnSetTcpAck);
            this.groupNetwork.Controls.Add(this.btnOpenPorts);
            this.groupNetwork.Location = new System.Drawing.Point(222, 12);
            this.groupNetwork.Name = "groupNetwork";
            this.groupNetwork.Size = new System.Drawing.Size(173, 185);
            this.groupNetwork.TabIndex = 9;
            this.groupNetwork.TabStop = false;
            this.groupNetwork.Text = "Сеть";
            // 
            // btnOpenPorts
            // 
            this.btnOpenPorts.Location = new System.Drawing.Point(6, 19);
            this.btnOpenPorts.Name = "btnOpenPorts";
            this.btnOpenPorts.Size = new System.Drawing.Size(159, 23);
            this.btnOpenPorts.TabIndex = 0;
            this.btnOpenPorts.Text = "Открыть закрытые порты";
            this.btnOpenPorts.UseVisualStyleBackColor = true;
            this.btnOpenPorts.Click += new System.EventHandler(this.btnOpenPorts_Click);
            // 
            // btnSetTcpAck
            // 
            this.btnSetTcpAck.Location = new System.Drawing.Point(6, 78);
            this.btnSetTcpAck.Name = "btnSetTcpAck";
            this.btnSetTcpAck.Size = new System.Drawing.Size(75, 23);
            this.btnSetTcpAck.TabIndex = 1;
            this.btnSetTcpAck.Text = "Установка";
            this.btnSetTcpAck.UseVisualStyleBackColor = true;
            this.btnSetTcpAck.Click += new System.EventHandler(this.btnSetTcpAck_Click);
            // 
            // btnResetTcpAck
            // 
            this.btnResetTcpAck.Location = new System.Drawing.Point(90, 78);
            this.btnResetTcpAck.Name = "btnResetTcpAck";
            this.btnResetTcpAck.Size = new System.Drawing.Size(75, 23);
            this.btnResetTcpAck.TabIndex = 2;
            this.btnResetTcpAck.Text = "Сброс";
            this.btnResetTcpAck.UseVisualStyleBackColor = true;
            this.btnResetTcpAck.Click += new System.EventHandler(this.btnResetTcpAck_Click);
            // 
            // btnSetNetworkThrottling
            // 
            this.btnSetNetworkThrottling.Location = new System.Drawing.Point(6, 130);
            this.btnSetNetworkThrottling.Name = "btnSetNetworkThrottling";
            this.btnSetNetworkThrottling.Size = new System.Drawing.Size(75, 23);
            this.btnSetNetworkThrottling.TabIndex = 3;
            this.btnSetNetworkThrottling.Text = "Установка";
            this.btnSetNetworkThrottling.UseVisualStyleBackColor = true;
            this.btnSetNetworkThrottling.Click += new System.EventHandler(this.btnSetNetworkThrottling_Click);
            // 
            // btnResetNetworkThrottling
            // 
            this.btnResetNetworkThrottling.Location = new System.Drawing.Point(90, 130);
            this.btnResetNetworkThrottling.Name = "btnResetNetworkThrottling";
            this.btnResetNetworkThrottling.Size = new System.Drawing.Size(75, 23);
            this.btnResetNetworkThrottling.TabIndex = 4;
            this.btnResetNetworkThrottling.Text = "Сброс";
            this.btnResetNetworkThrottling.UseVisualStyleBackColor = true;
            this.btnResetNetworkThrottling.Click += new System.EventHandler(this.btnResetNetworkThrottling_Click);
            // 
            // labelTcpAck
            // 
            this.labelTcpAck.AutoSize = true;
            this.labelTcpAck.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelTcpAck.Location = new System.Drawing.Point(63, 62);
            this.labelTcpAck.Name = "labelTcpAck";
            this.labelTcpAck.Size = new System.Drawing.Size(50, 13);
            this.labelTcpAck.TabIndex = 5;
            this.labelTcpAck.Text = "TCP Ack";
            // 
            // labelNetworkThrottling
            // 
            this.labelNetworkThrottling.AutoSize = true;
            this.labelNetworkThrottling.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelNetworkThrottling.Location = new System.Drawing.Point(7, 114);
            this.labelNetworkThrottling.Name = "labelNetworkThrottling";
            this.labelNetworkThrottling.Size = new System.Drawing.Size(158, 13);
            this.labelNetworkThrottling.TabIndex = 6;
            this.labelNetworkThrottling.Text = "Задержка обработки пакетов";
            // 
            // toolTipForTcp
            // 
            this.toolTipForTcp.IsBalloon = true;
            // 
            // toolTipForThrottling
            // 
            this.toolTipForThrottling.IsBalloon = true;
            // 
            // linkToWikiArticle
            // 
            this.linkToWikiArticle.AutoSize = true;
            this.linkToWikiArticle.Location = new System.Drawing.Point(95, 161);
            this.linkToWikiArticle.Name = "linkToWikiArticle";
            this.linkToWikiArticle.Size = new System.Drawing.Size(72, 13);
            this.linkToWikiArticle.TabIndex = 7;
            this.linkToWikiArticle.TabStop = true;
            this.linkToWikiArticle.Text = "Подробнее...";
            // 
            // TroubleshootingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 209);
            this.Controls.Add(this.groupNetwork);
            this.Controls.Add(this.groupClients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TroubleshootingWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Исправление проблем";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TroubleshootingWindow_FormClosing);
            this.groupClients.ResumeLayout(false);
            this.groupNetwork.ResumeLayout(false);
            this.groupNetwork.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Button btnIncreaseCache;
        private System.Windows.Forms.Button btnClearShared;
        private System.Windows.Forms.Button btnClearCache;
        private System.Windows.Forms.GroupBox groupClients;
        private System.Windows.Forms.GroupBox groupNetwork;
        private System.Windows.Forms.Button btnOpenPorts;
        private System.Windows.Forms.Label labelNetworkThrottling;
        private System.Windows.Forms.Label labelTcpAck;
        private System.Windows.Forms.Button btnResetNetworkThrottling;
        private System.Windows.Forms.Button btnSetNetworkThrottling;
        private System.Windows.Forms.Button btnResetTcpAck;
        private System.Windows.Forms.Button btnSetTcpAck;
        private System.Windows.Forms.ToolTip toolTipForTcp;
        private System.Windows.Forms.ToolTip toolTipForThrottling;
        private System.Windows.Forms.LinkLabel linkToWikiArticle;
    }
}