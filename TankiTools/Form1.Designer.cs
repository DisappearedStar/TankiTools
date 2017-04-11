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
            this.MainWindow_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.Button_Master = new System.Windows.Forms.Button();
            this.Button_Settings = new System.Windows.Forms.Button();
            this.Button_Diagnostics = new System.Windows.Forms.Button();
            this.Button_Troubleshooting = new System.Windows.Forms.Button();
            this.Button_Other = new System.Windows.Forms.Button();
            this.Button_Exit = new System.Windows.Forms.Button();
            this.MainWindow_Layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainWindow_Layout
            // 
            this.MainWindow_Layout.ColumnCount = 2;
            this.MainWindow_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainWindow_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainWindow_Layout.Controls.Add(this.Button_Master, 0, 0);
            this.MainWindow_Layout.Controls.Add(this.Button_Settings, 1, 0);
            this.MainWindow_Layout.Controls.Add(this.Button_Diagnostics, 0, 1);
            this.MainWindow_Layout.Controls.Add(this.Button_Troubleshooting, 1, 1);
            this.MainWindow_Layout.Controls.Add(this.Button_Other, 0, 2);
            this.MainWindow_Layout.Controls.Add(this.Button_Exit, 1, 2);
            this.MainWindow_Layout.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.MainWindow_Layout.Location = new System.Drawing.Point(12, 12);
            this.MainWindow_Layout.Name = "MainWindow_Layout";
            this.MainWindow_Layout.RowCount = 3;
            this.MainWindow_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.MainWindow_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.MainWindow_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.MainWindow_Layout.Size = new System.Drawing.Size(283, 358);
            this.MainWindow_Layout.TabIndex = 0;
            // 
            // Button_Master
            // 
            this.Button_Master.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Master.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Master.Location = new System.Drawing.Point(3, 3);
            this.Button_Master.Name = "Button_Master";
            this.Button_Master.Size = new System.Drawing.Size(135, 113);
            this.Button_Master.TabIndex = 0;
            this.Button_Master.TabStop = false;
            this.Button_Master.Text = "Мастер диагностики и исправления";
            this.Button_Master.UseVisualStyleBackColor = true;
            // 
            // Button_Settings
            // 
            this.Button_Settings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Settings.Location = new System.Drawing.Point(144, 3);
            this.Button_Settings.Name = "Button_Settings";
            this.Button_Settings.Size = new System.Drawing.Size(136, 113);
            this.Button_Settings.TabIndex = 1;
            this.Button_Settings.TabStop = false;
            this.Button_Settings.Text = "Настройки";
            this.Button_Settings.UseVisualStyleBackColor = true;
            // 
            // Button_Diagnostics
            // 
            this.Button_Diagnostics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Diagnostics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Diagnostics.Location = new System.Drawing.Point(3, 122);
            this.Button_Diagnostics.Name = "Button_Diagnostics";
            this.Button_Diagnostics.Size = new System.Drawing.Size(135, 113);
            this.Button_Diagnostics.TabIndex = 2;
            this.Button_Diagnostics.TabStop = false;
            this.Button_Diagnostics.Text = "Диагностика и информация";
            this.Button_Diagnostics.UseVisualStyleBackColor = true;
            // 
            // Button_Troubleshooting
            // 
            this.Button_Troubleshooting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Troubleshooting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Troubleshooting.Location = new System.Drawing.Point(144, 122);
            this.Button_Troubleshooting.Name = "Button_Troubleshooting";
            this.Button_Troubleshooting.Size = new System.Drawing.Size(136, 113);
            this.Button_Troubleshooting.TabIndex = 3;
            this.Button_Troubleshooting.TabStop = false;
            this.Button_Troubleshooting.Text = "Исправление проблем";
            this.Button_Troubleshooting.UseVisualStyleBackColor = true;
            // 
            // Button_Other
            // 
            this.Button_Other.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button_Other.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Other.Location = new System.Drawing.Point(3, 241);
            this.Button_Other.Name = "Button_Other";
            this.Button_Other.Size = new System.Drawing.Size(135, 114);
            this.Button_Other.TabIndex = 4;
            this.Button_Other.TabStop = false;
            this.Button_Other.Text = "Другое";
            this.Button_Other.UseVisualStyleBackColor = true;
            // 
            // Button_Exit
            // 
            this.Button_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Exit.Location = new System.Drawing.Point(205, 332);
            this.Button_Exit.Name = "Button_Exit";
            this.Button_Exit.Size = new System.Drawing.Size(75, 23);
            this.Button_Exit.TabIndex = 5;
            this.Button_Exit.TabStop = false;
            this.Button_Exit.Text = "Выход";
            this.Button_Exit.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 382);
            this.Controls.Add(this.MainWindow_Layout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TankiTools";
            this.MainWindow_Layout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainWindow_Layout;
        private System.Windows.Forms.Button Button_Master;
        private System.Windows.Forms.Button Button_Settings;
        private System.Windows.Forms.Button Button_Diagnostics;
        private System.Windows.Forms.Button Button_Troubleshooting;
        private System.Windows.Forms.Button Button_Other;
        private System.Windows.Forms.Button Button_Exit;
    }
}

