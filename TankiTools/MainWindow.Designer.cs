namespace TankiTools
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.MainWindow_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.Button_Other = new System.Windows.Forms.Button();
            this.Button_Troubleshooting = new System.Windows.Forms.Button();
            this.Button_Diagnostics = new System.Windows.Forms.Button();
            this.Button_Settings = new System.Windows.Forms.Button();
            this.Button_Exit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.MainWindow_Layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MainWindow_Layout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 271);
            this.panel1.TabIndex = 0;
            // 
            // MainWindow_Layout
            // 
            this.MainWindow_Layout.ColumnCount = 2;
            this.MainWindow_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainWindow_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainWindow_Layout.Controls.Add(this.Button_Other, 1, 1);
            this.MainWindow_Layout.Controls.Add(this.Button_Troubleshooting, 0, 1);
            this.MainWindow_Layout.Controls.Add(this.Button_Diagnostics, 0, 0);
            this.MainWindow_Layout.Controls.Add(this.Button_Settings, 1, 0);
            this.MainWindow_Layout.Controls.Add(this.Button_Exit, 1, 2);
            this.MainWindow_Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainWindow_Layout.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.MainWindow_Layout.Location = new System.Drawing.Point(0, 0);
            this.MainWindow_Layout.Name = "MainWindow_Layout";
            this.MainWindow_Layout.RowCount = 3;
            this.MainWindow_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.MainWindow_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.MainWindow_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.MainWindow_Layout.Size = new System.Drawing.Size(252, 271);
            this.MainWindow_Layout.TabIndex = 1;
            // 
            // Button_Other
            // 
            this.Button_Other.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Other.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Other.Image = global::TankiTools.Properties.Resources.Other;
            this.Button_Other.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button_Other.Location = new System.Drawing.Point(129, 116);
            this.Button_Other.Name = "Button_Other";
            this.Button_Other.Size = new System.Drawing.Size(120, 107);
            this.Button_Other.TabIndex = 8;
            this.Button_Other.TabStop = false;
            this.Button_Other.Text = "Другое";
            this.Button_Other.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Button_Other.UseVisualStyleBackColor = true;
            this.Button_Other.Click += new System.EventHandler(this.Button_Other_Click);
            // 
            // Button_Troubleshooting
            // 
            this.Button_Troubleshooting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Troubleshooting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Troubleshooting.Image = global::TankiTools.Properties.Resources.Troubleshooting;
            this.Button_Troubleshooting.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button_Troubleshooting.Location = new System.Drawing.Point(3, 116);
            this.Button_Troubleshooting.Name = "Button_Troubleshooting";
            this.Button_Troubleshooting.Size = new System.Drawing.Size(120, 107);
            this.Button_Troubleshooting.TabIndex = 7;
            this.Button_Troubleshooting.TabStop = false;
            this.Button_Troubleshooting.Text = "Исправление проблем";
            this.Button_Troubleshooting.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Button_Troubleshooting.UseVisualStyleBackColor = true;
            this.Button_Troubleshooting.Click += new System.EventHandler(this.Button_Troubleshooting_Click);
            // 
            // Button_Diagnostics
            // 
            this.Button_Diagnostics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Button_Diagnostics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Diagnostics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Diagnostics.Image = global::TankiTools.Properties.Resources.Diagnostics;
            this.Button_Diagnostics.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button_Diagnostics.Location = new System.Drawing.Point(3, 3);
            this.Button_Diagnostics.Name = "Button_Diagnostics";
            this.Button_Diagnostics.Size = new System.Drawing.Size(120, 107);
            this.Button_Diagnostics.TabIndex = 6;
            this.Button_Diagnostics.TabStop = false;
            this.Button_Diagnostics.Text = "Диагностика и информация";
            this.Button_Diagnostics.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Button_Diagnostics.UseVisualStyleBackColor = true;
            this.Button_Diagnostics.Click += new System.EventHandler(this.Button_Diagnostics_Click);
            // 
            // Button_Settings
            // 
            this.Button_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Settings.Image = global::TankiTools.Properties.Resources.Settings;
            this.Button_Settings.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Button_Settings.Location = new System.Drawing.Point(129, 3);
            this.Button_Settings.Name = "Button_Settings";
            this.Button_Settings.Size = new System.Drawing.Size(120, 107);
            this.Button_Settings.TabIndex = 1;
            this.Button_Settings.TabStop = false;
            this.Button_Settings.Text = "Настройки";
            this.Button_Settings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Button_Settings.UseVisualStyleBackColor = true;
            this.Button_Settings.Click += new System.EventHandler(this.Button_Settings_Click);
            // 
            // Button_Exit
            // 
            this.Button_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Exit.Location = new System.Drawing.Point(163, 245);
            this.Button_Exit.Name = "Button_Exit";
            this.Button_Exit.Size = new System.Drawing.Size(86, 23);
            this.Button_Exit.TabIndex = 9;
            this.Button_Exit.Text = "Выход";
            this.Button_Exit.UseVisualStyleBackColor = true;
            this.Button_Exit.Click += new System.EventHandler(this.Button_Exit_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 271);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TankiTools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.panel1.ResumeLayout(false);
            this.MainWindow_Layout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel MainWindow_Layout;
        private System.Windows.Forms.Button Button_Other;
        private System.Windows.Forms.Button Button_Troubleshooting;
        private System.Windows.Forms.Button Button_Diagnostics;
        private System.Windows.Forms.Button Button_Settings;
        private System.Windows.Forms.Button Button_Exit;
        //private System.Windows.Forms.NotifyIcon TrayApp;
    }
}

