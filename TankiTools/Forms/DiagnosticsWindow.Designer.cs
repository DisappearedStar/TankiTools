namespace TankiTools
{
    partial class DiagnosticsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiagnosticsWindow));
            this.DiagnosticsWindow_TabControl = new System.Windows.Forms.TabControl();
            this.Tab_SystemInfo = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.forProcessor = new System.Windows.Forms.Label();
            this.forMemory = new System.Windows.Forms.Label();
            this.forGraphics = new System.Windows.Forms.Label();
            this.forResolution = new System.Windows.Forms.Label();
            this.forOS = new System.Windows.Forms.Label();
            this.forDriver = new System.Windows.Forms.Label();
            this.Label_Processor = new System.Windows.Forms.Label();
            this.Label_Memory = new System.Windows.Forms.Label();
            this.Label_Graphics = new System.Windows.Forms.Label();
            this.Label_Driver = new System.Windows.Forms.Label();
            this.Label_OS = new System.Windows.Forms.Label();
            this.Label_Resolution = new System.Windows.Forms.Label();
            this.forIpAddress = new System.Windows.Forms.Label();
            this.Label_IpAddress = new System.Windows.Forms.Label();
            this.Tab_Flash_Player = new System.Windows.Forms.TabPage();
            this.labelCheckFlashInfo = new System.Windows.Forms.Label();
            this.btnCheckFlash = new System.Windows.Forms.Button();
            this.Tab_Network = new System.Windows.Forms.TabPage();
            this.txbNetworkResults = new System.Windows.Forms.TextBox();
            this.labelNetworkResults = new System.Windows.Forms.Label();
            this.btnTrace = new System.Windows.Forms.Button();
            this.btnPing = new System.Windows.Forms.Button();
            this.btnCheckPorts = new System.Windows.Forms.Button();
            this.DiagnosticsWindow_TabControl.SuspendLayout();
            this.Tab_SystemInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.Tab_Flash_Player.SuspendLayout();
            this.Tab_Network.SuspendLayout();
            this.SuspendLayout();
            // 
            // DiagnosticsWindow_TabControl
            // 
            this.DiagnosticsWindow_TabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.DiagnosticsWindow_TabControl.Controls.Add(this.Tab_SystemInfo);
            this.DiagnosticsWindow_TabControl.Controls.Add(this.Tab_Flash_Player);
            this.DiagnosticsWindow_TabControl.Controls.Add(this.Tab_Network);
            this.DiagnosticsWindow_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DiagnosticsWindow_TabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.DiagnosticsWindow_TabControl.ItemSize = new System.Drawing.Size(50, 100);
            this.DiagnosticsWindow_TabControl.Location = new System.Drawing.Point(0, 0);
            this.DiagnosticsWindow_TabControl.Multiline = true;
            this.DiagnosticsWindow_TabControl.Name = "DiagnosticsWindow_TabControl";
            this.DiagnosticsWindow_TabControl.SelectedIndex = 0;
            this.DiagnosticsWindow_TabControl.Size = new System.Drawing.Size(543, 278);
            this.DiagnosticsWindow_TabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.DiagnosticsWindow_TabControl.TabIndex = 0;
            this.DiagnosticsWindow_TabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DiagnosticsWindow_TabControl_DrawItem);
            this.DiagnosticsWindow_TabControl.Leave += new System.EventHandler(this.DiagnosticsWindow_TabControl_Leave);
            // 
            // Tab_SystemInfo
            // 
            this.Tab_SystemInfo.Controls.Add(this.tableLayoutPanel1);
            this.Tab_SystemInfo.Location = new System.Drawing.Point(104, 4);
            this.Tab_SystemInfo.Name = "Tab_SystemInfo";
            this.Tab_SystemInfo.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_SystemInfo.Size = new System.Drawing.Size(435, 270);
            this.Tab_SystemInfo.TabIndex = 0;
            this.Tab_SystemInfo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.forProcessor, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.forMemory, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.forGraphics, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.forResolution, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.forOS, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.forDriver, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Label_Processor, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Label_Memory, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Label_Graphics, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.Label_Driver, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.Label_OS, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Label_Resolution, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.forIpAddress, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.Label_IpAddress, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(429, 264);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // forProcessor
            // 
            this.forProcessor.AutoSize = true;
            this.forProcessor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forProcessor.Location = new System.Drawing.Point(3, 0);
            this.forProcessor.Name = "forProcessor";
            this.forProcessor.Size = new System.Drawing.Size(0, 13);
            this.forProcessor.TabIndex = 0;
            // 
            // forMemory
            // 
            this.forMemory.AutoSize = true;
            this.forMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forMemory.Location = new System.Drawing.Point(3, 34);
            this.forMemory.Name = "forMemory";
            this.forMemory.Size = new System.Drawing.Size(0, 13);
            this.forMemory.TabIndex = 1;
            // 
            // forGraphics
            // 
            this.forGraphics.AutoSize = true;
            this.forGraphics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forGraphics.Location = new System.Drawing.Point(3, 65);
            this.forGraphics.Name = "forGraphics";
            this.forGraphics.Size = new System.Drawing.Size(0, 13);
            this.forGraphics.TabIndex = 2;
            // 
            // forResolution
            // 
            this.forResolution.AutoSize = true;
            this.forResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forResolution.Location = new System.Drawing.Point(3, 193);
            this.forResolution.Name = "forResolution";
            this.forResolution.Size = new System.Drawing.Size(0, 13);
            this.forResolution.TabIndex = 4;
            // 
            // forOS
            // 
            this.forOS.AutoSize = true;
            this.forOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forOS.Location = new System.Drawing.Point(3, 159);
            this.forOS.Name = "forOS";
            this.forOS.Size = new System.Drawing.Size(0, 13);
            this.forOS.TabIndex = 3;
            // 
            // forDriver
            // 
            this.forDriver.AutoSize = true;
            this.forDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forDriver.Location = new System.Drawing.Point(3, 112);
            this.forDriver.Name = "forDriver";
            this.forDriver.Size = new System.Drawing.Size(0, 13);
            this.forDriver.TabIndex = 5;
            // 
            // Label_Processor
            // 
            this.Label_Processor.AutoSize = true;
            this.Label_Processor.Location = new System.Drawing.Point(110, 0);
            this.Label_Processor.Name = "Label_Processor";
            this.Label_Processor.Size = new System.Drawing.Size(0, 13);
            this.Label_Processor.TabIndex = 6;
            // 
            // Label_Memory
            // 
            this.Label_Memory.AutoSize = true;
            this.Label_Memory.Location = new System.Drawing.Point(110, 34);
            this.Label_Memory.Name = "Label_Memory";
            this.Label_Memory.Size = new System.Drawing.Size(0, 13);
            this.Label_Memory.TabIndex = 7;
            // 
            // Label_Graphics
            // 
            this.Label_Graphics.AutoSize = true;
            this.Label_Graphics.Location = new System.Drawing.Point(110, 65);
            this.Label_Graphics.Name = "Label_Graphics";
            this.Label_Graphics.Size = new System.Drawing.Size(0, 13);
            this.Label_Graphics.TabIndex = 8;
            // 
            // Label_Driver
            // 
            this.Label_Driver.AutoSize = true;
            this.Label_Driver.Location = new System.Drawing.Point(110, 112);
            this.Label_Driver.Name = "Label_Driver";
            this.Label_Driver.Size = new System.Drawing.Size(0, 13);
            this.Label_Driver.TabIndex = 9;
            // 
            // Label_OS
            // 
            this.Label_OS.AutoSize = true;
            this.Label_OS.Location = new System.Drawing.Point(110, 159);
            this.Label_OS.Name = "Label_OS";
            this.Label_OS.Size = new System.Drawing.Size(0, 13);
            this.Label_OS.TabIndex = 10;
            // 
            // Label_Resolution
            // 
            this.Label_Resolution.AutoSize = true;
            this.Label_Resolution.Location = new System.Drawing.Point(110, 193);
            this.Label_Resolution.Name = "Label_Resolution";
            this.Label_Resolution.Size = new System.Drawing.Size(0, 13);
            this.Label_Resolution.TabIndex = 11;
            // 
            // forIpAddress
            // 
            this.forIpAddress.AutoSize = true;
            this.forIpAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forIpAddress.Location = new System.Drawing.Point(3, 227);
            this.forIpAddress.Name = "forIpAddress";
            this.forIpAddress.Size = new System.Drawing.Size(0, 13);
            this.forIpAddress.TabIndex = 12;
            // 
            // Label_IpAddress
            // 
            this.Label_IpAddress.AutoSize = true;
            this.Label_IpAddress.Location = new System.Drawing.Point(110, 227);
            this.Label_IpAddress.Name = "Label_IpAddress";
            this.Label_IpAddress.Size = new System.Drawing.Size(0, 13);
            this.Label_IpAddress.TabIndex = 13;
            // 
            // Tab_Flash_Player
            // 
            this.Tab_Flash_Player.Controls.Add(this.labelCheckFlashInfo);
            this.Tab_Flash_Player.Controls.Add(this.btnCheckFlash);
            this.Tab_Flash_Player.Location = new System.Drawing.Point(104, 4);
            this.Tab_Flash_Player.Name = "Tab_Flash_Player";
            this.Tab_Flash_Player.Size = new System.Drawing.Size(435, 270);
            this.Tab_Flash_Player.TabIndex = 2;
            this.Tab_Flash_Player.UseVisualStyleBackColor = true;
            this.Tab_Flash_Player.Leave += new System.EventHandler(this.DiagnosticsWindow_TabControl_Leave);
            // 
            // labelCheckFlashInfo
            // 
            this.labelCheckFlashInfo.Location = new System.Drawing.Point(113, 184);
            this.labelCheckFlashInfo.Name = "labelCheckFlashInfo";
            this.labelCheckFlashInfo.Size = new System.Drawing.Size(212, 23);
            this.labelCheckFlashInfo.TabIndex = 1;
            this.labelCheckFlashInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCheckFlash
            // 
            this.btnCheckFlash.Location = new System.Drawing.Point(165, 97);
            this.btnCheckFlash.Name = "btnCheckFlash";
            this.btnCheckFlash.Size = new System.Drawing.Size(115, 56);
            this.btnCheckFlash.TabIndex = 0;
            this.btnCheckFlash.UseVisualStyleBackColor = true;
            this.btnCheckFlash.Click += new System.EventHandler(this.btnCheckFlash_Click);
            // 
            // Tab_Network
            // 
            this.Tab_Network.Controls.Add(this.txbNetworkResults);
            this.Tab_Network.Controls.Add(this.labelNetworkResults);
            this.Tab_Network.Controls.Add(this.btnTrace);
            this.Tab_Network.Controls.Add(this.btnPing);
            this.Tab_Network.Controls.Add(this.btnCheckPorts);
            this.Tab_Network.Location = new System.Drawing.Point(104, 4);
            this.Tab_Network.Name = "Tab_Network";
            this.Tab_Network.Size = new System.Drawing.Size(435, 270);
            this.Tab_Network.TabIndex = 3;
            this.Tab_Network.UseVisualStyleBackColor = true;
            this.Tab_Network.Leave += new System.EventHandler(this.DiagnosticsWindow_TabControl_Leave);
            // 
            // txbNetworkResults
            // 
            this.txbNetworkResults.Location = new System.Drawing.Point(163, 52);
            this.txbNetworkResults.Multiline = true;
            this.txbNetworkResults.Name = "txbNetworkResults";
            this.txbNetworkResults.ReadOnly = true;
            this.txbNetworkResults.Size = new System.Drawing.Size(231, 185);
            this.txbNetworkResults.TabIndex = 4;
            // 
            // labelNetworkResults
            // 
            this.labelNetworkResults.AutoSize = true;
            this.labelNetworkResults.Location = new System.Drawing.Point(245, 25);
            this.labelNetworkResults.Name = "labelNetworkResults";
            this.labelNetworkResults.Size = new System.Drawing.Size(0, 13);
            this.labelNetworkResults.TabIndex = 3;
            // 
            // btnTrace
            // 
            this.btnTrace.Location = new System.Drawing.Point(20, 145);
            this.btnTrace.Name = "btnTrace";
            this.btnTrace.Size = new System.Drawing.Size(108, 35);
            this.btnTrace.TabIndex = 2;
            this.btnTrace.UseVisualStyleBackColor = true;
            this.btnTrace.Click += new System.EventHandler(this.btnTrace_Click);
            // 
            // btnPing
            // 
            this.btnPing.Location = new System.Drawing.Point(20, 104);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(108, 35);
            this.btnPing.TabIndex = 1;
            this.btnPing.UseVisualStyleBackColor = true;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // btnCheckPorts
            // 
            this.btnCheckPorts.Location = new System.Drawing.Point(20, 75);
            this.btnCheckPorts.Name = "btnCheckPorts";
            this.btnCheckPorts.Size = new System.Drawing.Size(108, 23);
            this.btnCheckPorts.TabIndex = 0;
            this.btnCheckPorts.UseVisualStyleBackColor = true;
            this.btnCheckPorts.Click += new System.EventHandler(this.btnCheckPorts_Click);
            // 
            // DiagnosticsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 278);
            this.Controls.Add(this.DiagnosticsWindow_TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DiagnosticsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DiagnosticsWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DiagnosticsWindow_FormClosed);
            this.DiagnosticsWindow_TabControl.ResumeLayout(false);
            this.Tab_SystemInfo.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Tab_Flash_Player.ResumeLayout(false);
            this.Tab_Network.ResumeLayout(false);
            this.Tab_Network.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl DiagnosticsWindow_TabControl;
        private System.Windows.Forms.TabPage Tab_SystemInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label forProcessor;
        private System.Windows.Forms.Label forMemory;
        private System.Windows.Forms.Label forGraphics;
        private System.Windows.Forms.Label forResolution;
        private System.Windows.Forms.Label forOS;
        private System.Windows.Forms.Label forDriver;
        private System.Windows.Forms.Label Label_Processor;
        private System.Windows.Forms.Label Label_Memory;
        private System.Windows.Forms.Label Label_Graphics;
        private System.Windows.Forms.Label Label_Driver;
        private System.Windows.Forms.Label Label_OS;
        private System.Windows.Forms.Label Label_Resolution;
        private System.Windows.Forms.Label forIpAddress;
        private System.Windows.Forms.Label Label_IpAddress;
        private System.Windows.Forms.TabPage Tab_Flash_Player;
        private System.Windows.Forms.TabPage Tab_Network;
        private System.Windows.Forms.Button btnCheckFlash;
        private System.Windows.Forms.Label labelCheckFlashInfo;
        private System.Windows.Forms.Button btnTrace;
        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.Button btnCheckPorts;
        private System.Windows.Forms.TextBox txbNetworkResults;
        private System.Windows.Forms.Label labelNetworkResults;
    }
}