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
            this.components = new System.ComponentModel.Container();
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
            this.Tab_Drivers = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.DiagnosticsWindow_TabControl.SuspendLayout();
            this.Tab_SystemInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.Tab_Drivers.SuspendLayout();
            this.SuspendLayout();
            // 
            // DiagnosticsWindow_TabControl
            // 
            this.DiagnosticsWindow_TabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.DiagnosticsWindow_TabControl.Controls.Add(this.Tab_SystemInfo);
            this.DiagnosticsWindow_TabControl.Controls.Add(this.Tab_Drivers);
            this.DiagnosticsWindow_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DiagnosticsWindow_TabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.DiagnosticsWindow_TabControl.ItemSize = new System.Drawing.Size(50, 100);
            this.DiagnosticsWindow_TabControl.Location = new System.Drawing.Point(0, 0);
            this.DiagnosticsWindow_TabControl.Multiline = true;
            this.DiagnosticsWindow_TabControl.Name = "DiagnosticsWindow_TabControl";
            this.DiagnosticsWindow_TabControl.SelectedIndex = 0;
            this.DiagnosticsWindow_TabControl.Size = new System.Drawing.Size(543, 402);
            this.DiagnosticsWindow_TabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.DiagnosticsWindow_TabControl.TabIndex = 0;
            this.DiagnosticsWindow_TabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DiagnosticsWindow_TabControl_DrawItem);
            // 
            // Tab_SystemInfo
            // 
            this.Tab_SystemInfo.Controls.Add(this.tableLayoutPanel1);
            this.Tab_SystemInfo.Location = new System.Drawing.Point(104, 4);
            this.Tab_SystemInfo.Name = "Tab_SystemInfo";
            this.Tab_SystemInfo.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_SystemInfo.Size = new System.Drawing.Size(435, 394);
            this.Tab_SystemInfo.TabIndex = 0;
            this.Tab_SystemInfo.Text = "Информация о системе";
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
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(429, 388);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // forProcessor
            // 
            this.forProcessor.AutoSize = true;
            this.forProcessor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forProcessor.Location = new System.Drawing.Point(3, 0);
            this.forProcessor.Name = "forProcessor";
            this.forProcessor.Size = new System.Drawing.Size(76, 13);
            this.forProcessor.TabIndex = 0;
            this.forProcessor.Text = "Процессор:";
            // 
            // forMemory
            // 
            this.forMemory.AutoSize = true;
            this.forMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forMemory.Location = new System.Drawing.Point(3, 38);
            this.forMemory.Name = "forMemory";
            this.forMemory.Size = new System.Drawing.Size(98, 13);
            this.forMemory.TabIndex = 1;
            this.forMemory.Text = "Объем памяти:";
            // 
            // forGraphics
            // 
            this.forGraphics.AutoSize = true;
            this.forGraphics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forGraphics.Location = new System.Drawing.Point(3, 76);
            this.forGraphics.Name = "forGraphics";
            this.forGraphics.Size = new System.Drawing.Size(81, 13);
            this.forGraphics.TabIndex = 2;
            this.forGraphics.Text = "Видеокарта:";
            // 
            // forResolution
            // 
            this.forResolution.AutoSize = true;
            this.forResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forResolution.Location = new System.Drawing.Point(3, 190);
            this.forResolution.Name = "forResolution";
            this.forResolution.Size = new System.Drawing.Size(84, 26);
            this.forResolution.TabIndex = 4;
            this.forResolution.Text = "Разрешение монитора:";
            // 
            // forOS
            // 
            this.forOS.AutoSize = true;
            this.forOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forOS.Location = new System.Drawing.Point(3, 152);
            this.forOS.Name = "forOS";
            this.forOS.Size = new System.Drawing.Size(97, 26);
            this.forOS.TabIndex = 3;
            this.forOS.Text = "Операционная система:";
            // 
            // forDriver
            // 
            this.forDriver.AutoSize = true;
            this.forDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forDriver.Location = new System.Drawing.Point(3, 114);
            this.forDriver.Name = "forDriver";
            this.forDriver.Size = new System.Drawing.Size(67, 26);
            this.forDriver.TabIndex = 5;
            this.forDriver.Text = "Версия драйвера:";
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
            this.Label_Memory.Location = new System.Drawing.Point(110, 38);
            this.Label_Memory.Name = "Label_Memory";
            this.Label_Memory.Size = new System.Drawing.Size(0, 13);
            this.Label_Memory.TabIndex = 7;
            // 
            // Label_Graphics
            // 
            this.Label_Graphics.AutoSize = true;
            this.Label_Graphics.Location = new System.Drawing.Point(110, 76);
            this.Label_Graphics.Name = "Label_Graphics";
            this.Label_Graphics.Size = new System.Drawing.Size(0, 13);
            this.Label_Graphics.TabIndex = 8;
            // 
            // Label_Driver
            // 
            this.Label_Driver.AutoSize = true;
            this.Label_Driver.Location = new System.Drawing.Point(110, 114);
            this.Label_Driver.Name = "Label_Driver";
            this.Label_Driver.Size = new System.Drawing.Size(0, 13);
            this.Label_Driver.TabIndex = 9;
            // 
            // Label_OS
            // 
            this.Label_OS.AutoSize = true;
            this.Label_OS.Location = new System.Drawing.Point(110, 152);
            this.Label_OS.Name = "Label_OS";
            this.Label_OS.Size = new System.Drawing.Size(0, 13);
            this.Label_OS.TabIndex = 10;
            // 
            // Label_Resolution
            // 
            this.Label_Resolution.AutoSize = true;
            this.Label_Resolution.Location = new System.Drawing.Point(110, 190);
            this.Label_Resolution.Name = "Label_Resolution";
            this.Label_Resolution.Size = new System.Drawing.Size(0, 13);
            this.Label_Resolution.TabIndex = 11;
            // 
            // forIpAddress
            // 
            this.forIpAddress.AutoSize = true;
            this.forIpAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.forIpAddress.Location = new System.Drawing.Point(3, 228);
            this.forIpAddress.Name = "forIpAddress";
            this.forIpAddress.Size = new System.Drawing.Size(62, 13);
            this.forIpAddress.TabIndex = 12;
            this.forIpAddress.Text = "IP-адрес:";
            // 
            // Label_IpAddress
            // 
            this.Label_IpAddress.AutoSize = true;
            this.Label_IpAddress.Location = new System.Drawing.Point(110, 228);
            this.Label_IpAddress.Name = "Label_IpAddress";
            this.Label_IpAddress.Size = new System.Drawing.Size(0, 13);
            this.Label_IpAddress.TabIndex = 13;
            // 
            // Tab_Drivers
            // 
            this.Tab_Drivers.Controls.Add(this.button5);
            this.Tab_Drivers.Controls.Add(this.button4);
            this.Tab_Drivers.Controls.Add(this.textBox1);
            this.Tab_Drivers.Controls.Add(this.button3);
            this.Tab_Drivers.Controls.Add(this.button2);
            this.Tab_Drivers.Controls.Add(this.button1);
            this.Tab_Drivers.Location = new System.Drawing.Point(104, 4);
            this.Tab_Drivers.Name = "Tab_Drivers";
            this.Tab_Drivers.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Drivers.Size = new System.Drawing.Size(435, 394);
            this.Tab_Drivers.TabIndex = 1;
            this.Tab_Drivers.Text = "Информация о драйверах";
            this.Tab_Drivers.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(28, 213);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Скрин";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(183, 199);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(208, 157);
            this.textBox1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(183, 170);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(80, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(286, 42);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // DiagnosticsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 402);
            this.Controls.Add(this.DiagnosticsWindow_TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DiagnosticsWindow";
            this.Text = "Инструменты диагностики";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DiagnosticsWindow_FormClosed);
            this.DiagnosticsWindow_TabControl.ResumeLayout(false);
            this.Tab_SystemInfo.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Tab_Drivers.ResumeLayout(false);
            this.Tab_Drivers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl DiagnosticsWindow_TabControl;
        private System.Windows.Forms.TabPage Tab_SystemInfo;
        private System.Windows.Forms.TabPage Tab_Drivers;
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}