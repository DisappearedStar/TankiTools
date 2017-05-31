namespace TankiTools
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.Wrapper = new System.Windows.Forms.TableLayoutPanel();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.tabProgram = new System.Windows.Forms.TabPage();
            this.labelLang = new System.Windows.Forms.Label();
            this.cmbLang = new System.Windows.Forms.ComboBox();
            this.chbAutoupdate = new System.Windows.Forms.CheckBox();
            this.chbAutostart = new System.Windows.Forms.CheckBox();
            this.tabClients = new System.Windows.Forms.TabPage();
            this.cmbSelectedClient = new System.Windows.Forms.ComboBox();
            this.labelSelectedClient = new System.Windows.Forms.Label();
            this.tabScreenshots = new System.Windows.Forms.TabPage();
            this.cmbAreaScreen = new System.Windows.Forms.ComboBox();
            this.chbAreaScreenShift = new System.Windows.Forms.CheckBox();
            this.chbAreaScreenAlt = new System.Windows.Forms.CheckBox();
            this.chbAreaScreenCtrl = new System.Windows.Forms.CheckBox();
            this.cmbFullScreen = new System.Windows.Forms.ComboBox();
            this.chbFullScreenShift = new System.Windows.Forms.CheckBox();
            this.chbFullScreenAlt = new System.Windows.Forms.CheckBox();
            this.chbFullScreenCtrl = new System.Windows.Forms.CheckBox();
            this.labelAreaScreen = new System.Windows.Forms.Label();
            this.labelFullScreen = new System.Windows.Forms.Label();
            this.chbUploadImage = new System.Windows.Forms.CheckBox();
            this.groupScreenshots = new System.Windows.Forms.GroupBox();
            this.txbScreenshotsPath = new System.Windows.Forms.TextBox();
            this.btnChooseScreenshotsPath = new System.Windows.Forms.Button();
            this.labelImageFormat = new System.Windows.Forms.Label();
            this.cmbImageFormat = new System.Windows.Forms.ComboBox();
            this.tabVideos = new System.Windows.Forms.TabPage();
            this.cmbAreaVideo = new System.Windows.Forms.ComboBox();
            this.chbAreaVideoShift = new System.Windows.Forms.CheckBox();
            this.chbAreaVideoAlt = new System.Windows.Forms.CheckBox();
            this.chbAreaVideoCtrl = new System.Windows.Forms.CheckBox();
            this.cmbFullVideo = new System.Windows.Forms.ComboBox();
            this.chbFullVideoShift = new System.Windows.Forms.CheckBox();
            this.chbFullVideoAlt = new System.Windows.Forms.CheckBox();
            this.chbFullVideoCtrl = new System.Windows.Forms.CheckBox();
            this.labelAreaVideo = new System.Windows.Forms.Label();
            this.labelFullVideo = new System.Windows.Forms.Label();
            this.groupVideos = new System.Windows.Forms.GroupBox();
            this.txbVideosPath = new System.Windows.Forms.TextBox();
            this.btnChooseVideosPath = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSetToDefault = new System.Windows.Forms.Button();
            this.ChoosePath = new System.Windows.Forms.FolderBrowserDialog();
            this.Wrapper.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.tabProgram.SuspendLayout();
            this.tabClients.SuspendLayout();
            this.tabScreenshots.SuspendLayout();
            this.groupScreenshots.SuspendLayout();
            this.tabVideos.SuspendLayout();
            this.groupVideos.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Wrapper
            // 
            this.Wrapper.ColumnCount = 1;
            this.Wrapper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Wrapper.Controls.Add(this.Tabs, 0, 0);
            this.Wrapper.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.Wrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Wrapper.Location = new System.Drawing.Point(0, 0);
            this.Wrapper.Name = "Wrapper";
            this.Wrapper.RowCount = 2;
            this.Wrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Wrapper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Wrapper.Size = new System.Drawing.Size(402, 210);
            this.Wrapper.TabIndex = 0;
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.tabProgram);
            this.Tabs.Controls.Add(this.tabClients);
            this.Tabs.Controls.Add(this.tabScreenshots);
            this.Tabs.Controls.Add(this.tabVideos);
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.Location = new System.Drawing.Point(3, 3);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(396, 164);
            this.Tabs.TabIndex = 1;
            // 
            // tabProgram
            // 
            this.tabProgram.Controls.Add(this.labelLang);
            this.tabProgram.Controls.Add(this.cmbLang);
            this.tabProgram.Controls.Add(this.chbAutoupdate);
            this.tabProgram.Controls.Add(this.chbAutostart);
            this.tabProgram.Location = new System.Drawing.Point(4, 22);
            this.tabProgram.Name = "tabProgram";
            this.tabProgram.Padding = new System.Windows.Forms.Padding(3);
            this.tabProgram.Size = new System.Drawing.Size(388, 138);
            this.tabProgram.TabIndex = 0;
            this.tabProgram.Text = "Программа";
            this.tabProgram.UseVisualStyleBackColor = true;
            // 
            // labelLang
            // 
            this.labelLang.AutoSize = true;
            this.labelLang.Location = new System.Drawing.Point(255, 19);
            this.labelLang.Name = "labelLang";
            this.labelLang.Size = new System.Drawing.Size(35, 13);
            this.labelLang.TabIndex = 3;
            this.labelLang.Text = "Язык";
            // 
            // cmbLang
            // 
            this.cmbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLang.FormattingEnabled = true;
            this.cmbLang.Location = new System.Drawing.Point(296, 16);
            this.cmbLang.Name = "cmbLang";
            this.cmbLang.Size = new System.Drawing.Size(79, 21);
            this.cmbLang.TabIndex = 2;
            // 
            // chbAutoupdate
            // 
            this.chbAutoupdate.AutoSize = true;
            this.chbAutoupdate.Location = new System.Drawing.Point(22, 69);
            this.chbAutoupdate.Name = "chbAutoupdate";
            this.chbAutoupdate.Size = new System.Drawing.Size(223, 17);
            this.chbAutoupdate.TabIndex = 1;
            this.chbAutoupdate.Text = "Включить автообновление программы";
            this.chbAutoupdate.UseVisualStyleBackColor = true;
            // 
            // chbAutostart
            // 
            this.chbAutostart.AutoSize = true;
            this.chbAutostart.Location = new System.Drawing.Point(22, 46);
            this.chbAutostart.Name = "chbAutostart";
            this.chbAutostart.Size = new System.Drawing.Size(196, 17);
            this.chbAutostart.TabIndex = 0;
            this.chbAutostart.Text = "Автостарт при загрузке системы";
            this.chbAutostart.UseVisualStyleBackColor = true;
            // 
            // tabClients
            // 
            this.tabClients.Controls.Add(this.cmbSelectedClient);
            this.tabClients.Controls.Add(this.labelSelectedClient);
            this.tabClients.Location = new System.Drawing.Point(4, 22);
            this.tabClients.Name = "tabClients";
            this.tabClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabClients.Size = new System.Drawing.Size(388, 138);
            this.tabClients.TabIndex = 1;
            this.tabClients.Text = "Клиенты";
            this.tabClients.UseVisualStyleBackColor = true;
            // 
            // cmbSelectedClient
            // 
            this.cmbSelectedClient.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbSelectedClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectedClient.FormattingEnabled = true;
            this.cmbSelectedClient.Location = new System.Drawing.Point(147, 23);
            this.cmbSelectedClient.Name = "cmbSelectedClient";
            this.cmbSelectedClient.Size = new System.Drawing.Size(168, 21);
            this.cmbSelectedClient.TabIndex = 0;
            // 
            // labelSelectedClient
            // 
            this.labelSelectedClient.AutoSize = true;
            this.labelSelectedClient.Location = new System.Drawing.Point(19, 26);
            this.labelSelectedClient.Name = "labelSelectedClient";
            this.labelSelectedClient.Size = new System.Drawing.Size(122, 13);
            this.labelSelectedClient.TabIndex = 1;
            this.labelSelectedClient.Text = "Я использую для игры";
            // 
            // tabScreenshots
            // 
            this.tabScreenshots.Controls.Add(this.cmbAreaScreen);
            this.tabScreenshots.Controls.Add(this.chbAreaScreenShift);
            this.tabScreenshots.Controls.Add(this.chbAreaScreenAlt);
            this.tabScreenshots.Controls.Add(this.chbAreaScreenCtrl);
            this.tabScreenshots.Controls.Add(this.cmbFullScreen);
            this.tabScreenshots.Controls.Add(this.chbFullScreenShift);
            this.tabScreenshots.Controls.Add(this.chbFullScreenAlt);
            this.tabScreenshots.Controls.Add(this.chbFullScreenCtrl);
            this.tabScreenshots.Controls.Add(this.labelAreaScreen);
            this.tabScreenshots.Controls.Add(this.labelFullScreen);
            this.tabScreenshots.Controls.Add(this.chbUploadImage);
            this.tabScreenshots.Controls.Add(this.groupScreenshots);
            this.tabScreenshots.Controls.Add(this.labelImageFormat);
            this.tabScreenshots.Controls.Add(this.cmbImageFormat);
            this.tabScreenshots.Location = new System.Drawing.Point(4, 22);
            this.tabScreenshots.Name = "tabScreenshots";
            this.tabScreenshots.Size = new System.Drawing.Size(388, 138);
            this.tabScreenshots.TabIndex = 2;
            this.tabScreenshots.Text = "Скриншоты";
            this.tabScreenshots.UseVisualStyleBackColor = true;
            // 
            // cmbAreaScreen
            // 
            this.cmbAreaScreen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAreaScreen.FormattingEnabled = true;
            this.cmbAreaScreen.Location = new System.Drawing.Point(292, 61);
            this.cmbAreaScreen.Name = "cmbAreaScreen";
            this.cmbAreaScreen.Size = new System.Drawing.Size(51, 21);
            this.cmbAreaScreen.TabIndex = 14;
            // 
            // chbAreaScreenShift
            // 
            this.chbAreaScreenShift.AutoSize = true;
            this.chbAreaScreenShift.Location = new System.Drawing.Point(239, 63);
            this.chbAreaScreenShift.Name = "chbAreaScreenShift";
            this.chbAreaScreenShift.Size = new System.Drawing.Size(47, 17);
            this.chbAreaScreenShift.TabIndex = 13;
            this.chbAreaScreenShift.Text = "Shift";
            this.chbAreaScreenShift.UseVisualStyleBackColor = true;
            // 
            // chbAreaScreenAlt
            // 
            this.chbAreaScreenAlt.AutoSize = true;
            this.chbAreaScreenAlt.Location = new System.Drawing.Point(195, 63);
            this.chbAreaScreenAlt.Name = "chbAreaScreenAlt";
            this.chbAreaScreenAlt.Size = new System.Drawing.Size(38, 17);
            this.chbAreaScreenAlt.TabIndex = 12;
            this.chbAreaScreenAlt.Text = "Alt";
            this.chbAreaScreenAlt.UseVisualStyleBackColor = true;
            // 
            // chbAreaScreenCtrl
            // 
            this.chbAreaScreenCtrl.AutoSize = true;
            this.chbAreaScreenCtrl.Location = new System.Drawing.Point(148, 63);
            this.chbAreaScreenCtrl.Name = "chbAreaScreenCtrl";
            this.chbAreaScreenCtrl.Size = new System.Drawing.Size(41, 17);
            this.chbAreaScreenCtrl.TabIndex = 11;
            this.chbAreaScreenCtrl.Text = "Ctrl";
            this.chbAreaScreenCtrl.UseVisualStyleBackColor = true;
            // 
            // cmbFullScreen
            // 
            this.cmbFullScreen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFullScreen.FormattingEnabled = true;
            this.cmbFullScreen.Location = new System.Drawing.Point(292, 35);
            this.cmbFullScreen.Name = "cmbFullScreen";
            this.cmbFullScreen.Size = new System.Drawing.Size(51, 21);
            this.cmbFullScreen.TabIndex = 10;
            // 
            // chbFullScreenShift
            // 
            this.chbFullScreenShift.AutoSize = true;
            this.chbFullScreenShift.Location = new System.Drawing.Point(239, 37);
            this.chbFullScreenShift.Name = "chbFullScreenShift";
            this.chbFullScreenShift.Size = new System.Drawing.Size(47, 17);
            this.chbFullScreenShift.TabIndex = 9;
            this.chbFullScreenShift.Text = "Shift";
            this.chbFullScreenShift.UseVisualStyleBackColor = true;
            // 
            // chbFullScreenAlt
            // 
            this.chbFullScreenAlt.AutoSize = true;
            this.chbFullScreenAlt.Location = new System.Drawing.Point(195, 37);
            this.chbFullScreenAlt.Name = "chbFullScreenAlt";
            this.chbFullScreenAlt.Size = new System.Drawing.Size(38, 17);
            this.chbFullScreenAlt.TabIndex = 8;
            this.chbFullScreenAlt.Text = "Alt";
            this.chbFullScreenAlt.UseVisualStyleBackColor = true;
            // 
            // chbFullScreenCtrl
            // 
            this.chbFullScreenCtrl.AutoSize = true;
            this.chbFullScreenCtrl.Location = new System.Drawing.Point(148, 37);
            this.chbFullScreenCtrl.Name = "chbFullScreenCtrl";
            this.chbFullScreenCtrl.Size = new System.Drawing.Size(41, 17);
            this.chbFullScreenCtrl.TabIndex = 7;
            this.chbFullScreenCtrl.Text = "Ctrl";
            this.chbFullScreenCtrl.UseVisualStyleBackColor = true;
            // 
            // labelAreaScreen
            // 
            this.labelAreaScreen.AutoSize = true;
            this.labelAreaScreen.Location = new System.Drawing.Point(10, 65);
            this.labelAreaScreen.Name = "labelAreaScreen";
            this.labelAreaScreen.Size = new System.Drawing.Size(101, 13);
            this.labelAreaScreen.TabIndex = 6;
            this.labelAreaScreen.Text = "Скриншот области";
            // 
            // labelFullScreen
            // 
            this.labelFullScreen.AutoSize = true;
            this.labelFullScreen.Location = new System.Drawing.Point(10, 38);
            this.labelFullScreen.Name = "labelFullScreen";
            this.labelFullScreen.Size = new System.Drawing.Size(96, 13);
            this.labelFullScreen.TabIndex = 5;
            this.labelFullScreen.Text = "Скриншот экрана";
            // 
            // chbUploadImage
            // 
            this.chbUploadImage.AutoSize = true;
            this.chbUploadImage.Location = new System.Drawing.Point(135, 9);
            this.chbUploadImage.Name = "chbUploadImage";
            this.chbUploadImage.Size = new System.Drawing.Size(248, 17);
            this.chbUploadImage.TabIndex = 4;
            this.chbUploadImage.Text = "Загружать на хостинг и копировать ссылку";
            this.chbUploadImage.UseVisualStyleBackColor = true;
            // 
            // groupScreenshots
            // 
            this.groupScreenshots.Controls.Add(this.txbScreenshotsPath);
            this.groupScreenshots.Controls.Add(this.btnChooseScreenshotsPath);
            this.groupScreenshots.Location = new System.Drawing.Point(3, 96);
            this.groupScreenshots.Name = "groupScreenshots";
            this.groupScreenshots.Size = new System.Drawing.Size(382, 39);
            this.groupScreenshots.TabIndex = 3;
            this.groupScreenshots.TabStop = false;
            this.groupScreenshots.Text = "Папка для сохранения скриншотов";
            // 
            // txbScreenshotsPath
            // 
            this.txbScreenshotsPath.Location = new System.Drawing.Point(0, 19);
            this.txbScreenshotsPath.Name = "txbScreenshotsPath";
            this.txbScreenshotsPath.ReadOnly = true;
            this.txbScreenshotsPath.Size = new System.Drawing.Size(298, 20);
            this.txbScreenshotsPath.TabIndex = 3;
            // 
            // btnChooseScreenshotsPath
            // 
            this.btnChooseScreenshotsPath.Location = new System.Drawing.Point(304, 17);
            this.btnChooseScreenshotsPath.Name = "btnChooseScreenshotsPath";
            this.btnChooseScreenshotsPath.Size = new System.Drawing.Size(76, 23);
            this.btnChooseScreenshotsPath.TabIndex = 2;
            this.btnChooseScreenshotsPath.Text = "Выбрать...";
            this.btnChooseScreenshotsPath.UseVisualStyleBackColor = true;
            this.btnChooseScreenshotsPath.Click += new System.EventHandler(this.btnChooseScreenshotsPath_Click);
            // 
            // labelImageFormat
            // 
            this.labelImageFormat.AutoSize = true;
            this.labelImageFormat.Location = new System.Drawing.Point(5, 10);
            this.labelImageFormat.Name = "labelImageFormat";
            this.labelImageFormat.Size = new System.Drawing.Size(49, 13);
            this.labelImageFormat.TabIndex = 1;
            this.labelImageFormat.Text = "Формат";
            // 
            // cmbImageFormat
            // 
            this.cmbImageFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImageFormat.FormattingEnabled = true;
            this.cmbImageFormat.Location = new System.Drawing.Point(60, 7);
            this.cmbImageFormat.Name = "cmbImageFormat";
            this.cmbImageFormat.Size = new System.Drawing.Size(56, 21);
            this.cmbImageFormat.TabIndex = 0;
            // 
            // tabVideos
            // 
            this.tabVideos.Controls.Add(this.cmbAreaVideo);
            this.tabVideos.Controls.Add(this.chbAreaVideoShift);
            this.tabVideos.Controls.Add(this.chbAreaVideoAlt);
            this.tabVideos.Controls.Add(this.chbAreaVideoCtrl);
            this.tabVideos.Controls.Add(this.cmbFullVideo);
            this.tabVideos.Controls.Add(this.chbFullVideoShift);
            this.tabVideos.Controls.Add(this.chbFullVideoAlt);
            this.tabVideos.Controls.Add(this.chbFullVideoCtrl);
            this.tabVideos.Controls.Add(this.labelAreaVideo);
            this.tabVideos.Controls.Add(this.labelFullVideo);
            this.tabVideos.Controls.Add(this.groupVideos);
            this.tabVideos.Location = new System.Drawing.Point(4, 22);
            this.tabVideos.Name = "tabVideos";
            this.tabVideos.Size = new System.Drawing.Size(388, 138);
            this.tabVideos.TabIndex = 3;
            this.tabVideos.Text = "Видео";
            this.tabVideos.UseVisualStyleBackColor = true;
            // 
            // cmbAreaVideo
            // 
            this.cmbAreaVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAreaVideo.FormattingEnabled = true;
            this.cmbAreaVideo.Location = new System.Drawing.Point(262, 36);
            this.cmbAreaVideo.Name = "cmbAreaVideo";
            this.cmbAreaVideo.Size = new System.Drawing.Size(49, 21);
            this.cmbAreaVideo.TabIndex = 24;
            // 
            // chbAreaVideoShift
            // 
            this.chbAreaVideoShift.AutoSize = true;
            this.chbAreaVideoShift.Location = new System.Drawing.Point(209, 38);
            this.chbAreaVideoShift.Name = "chbAreaVideoShift";
            this.chbAreaVideoShift.Size = new System.Drawing.Size(47, 17);
            this.chbAreaVideoShift.TabIndex = 23;
            this.chbAreaVideoShift.Text = "Shift";
            this.chbAreaVideoShift.UseVisualStyleBackColor = true;
            // 
            // chbAreaVideoAlt
            // 
            this.chbAreaVideoAlt.AutoSize = true;
            this.chbAreaVideoAlt.Location = new System.Drawing.Point(165, 38);
            this.chbAreaVideoAlt.Name = "chbAreaVideoAlt";
            this.chbAreaVideoAlt.Size = new System.Drawing.Size(38, 17);
            this.chbAreaVideoAlt.TabIndex = 22;
            this.chbAreaVideoAlt.Text = "Alt";
            this.chbAreaVideoAlt.UseVisualStyleBackColor = true;
            // 
            // chbAreaVideoCtrl
            // 
            this.chbAreaVideoCtrl.AutoSize = true;
            this.chbAreaVideoCtrl.Location = new System.Drawing.Point(118, 38);
            this.chbAreaVideoCtrl.Name = "chbAreaVideoCtrl";
            this.chbAreaVideoCtrl.Size = new System.Drawing.Size(41, 17);
            this.chbAreaVideoCtrl.TabIndex = 21;
            this.chbAreaVideoCtrl.Text = "Ctrl";
            this.chbAreaVideoCtrl.UseVisualStyleBackColor = true;
            // 
            // cmbFullVideo
            // 
            this.cmbFullVideo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFullVideo.FormattingEnabled = true;
            this.cmbFullVideo.Location = new System.Drawing.Point(262, 10);
            this.cmbFullVideo.Name = "cmbFullVideo";
            this.cmbFullVideo.Size = new System.Drawing.Size(49, 21);
            this.cmbFullVideo.TabIndex = 20;
            // 
            // chbFullVideoShift
            // 
            this.chbFullVideoShift.AutoSize = true;
            this.chbFullVideoShift.Location = new System.Drawing.Point(209, 12);
            this.chbFullVideoShift.Name = "chbFullVideoShift";
            this.chbFullVideoShift.Size = new System.Drawing.Size(47, 17);
            this.chbFullVideoShift.TabIndex = 19;
            this.chbFullVideoShift.Text = "Shift";
            this.chbFullVideoShift.UseVisualStyleBackColor = true;
            // 
            // chbFullVideoAlt
            // 
            this.chbFullVideoAlt.AutoSize = true;
            this.chbFullVideoAlt.Location = new System.Drawing.Point(165, 12);
            this.chbFullVideoAlt.Name = "chbFullVideoAlt";
            this.chbFullVideoAlt.Size = new System.Drawing.Size(38, 17);
            this.chbFullVideoAlt.TabIndex = 18;
            this.chbFullVideoAlt.Text = "Alt";
            this.chbFullVideoAlt.UseVisualStyleBackColor = true;
            // 
            // chbFullVideoCtrl
            // 
            this.chbFullVideoCtrl.AutoSize = true;
            this.chbFullVideoCtrl.Location = new System.Drawing.Point(118, 12);
            this.chbFullVideoCtrl.Name = "chbFullVideoCtrl";
            this.chbFullVideoCtrl.Size = new System.Drawing.Size(41, 17);
            this.chbFullVideoCtrl.TabIndex = 17;
            this.chbFullVideoCtrl.Text = "Ctrl";
            this.chbFullVideoCtrl.UseVisualStyleBackColor = true;
            // 
            // labelAreaVideo
            // 
            this.labelAreaVideo.AutoSize = true;
            this.labelAreaVideo.Location = new System.Drawing.Point(10, 39);
            this.labelAreaVideo.Name = "labelAreaVideo";
            this.labelAreaVideo.Size = new System.Drawing.Size(82, 13);
            this.labelAreaVideo.TabIndex = 16;
            this.labelAreaVideo.Text = "Видео области";
            // 
            // labelFullVideo
            // 
            this.labelFullVideo.AutoSize = true;
            this.labelFullVideo.Location = new System.Drawing.Point(10, 12);
            this.labelFullVideo.Name = "labelFullVideo";
            this.labelFullVideo.Size = new System.Drawing.Size(77, 13);
            this.labelFullVideo.TabIndex = 15;
            this.labelFullVideo.Text = "Видео экрана";
            // 
            // groupVideos
            // 
            this.groupVideos.Controls.Add(this.txbVideosPath);
            this.groupVideos.Controls.Add(this.btnChooseVideosPath);
            this.groupVideos.Location = new System.Drawing.Point(3, 96);
            this.groupVideos.Name = "groupVideos";
            this.groupVideos.Size = new System.Drawing.Size(382, 39);
            this.groupVideos.TabIndex = 4;
            this.groupVideos.TabStop = false;
            this.groupVideos.Text = "Папка для сохранения видео";
            // 
            // txbVideosPath
            // 
            this.txbVideosPath.Location = new System.Drawing.Point(0, 19);
            this.txbVideosPath.Name = "txbVideosPath";
            this.txbVideosPath.ReadOnly = true;
            this.txbVideosPath.Size = new System.Drawing.Size(298, 20);
            this.txbVideosPath.TabIndex = 3;
            // 
            // btnChooseVideosPath
            // 
            this.btnChooseVideosPath.Location = new System.Drawing.Point(304, 17);
            this.btnChooseVideosPath.Name = "btnChooseVideosPath";
            this.btnChooseVideosPath.Size = new System.Drawing.Size(76, 23);
            this.btnChooseVideosPath.TabIndex = 2;
            this.btnChooseVideosPath.Text = "Выбрать...";
            this.btnChooseVideosPath.UseVisualStyleBackColor = true;
            this.btnChooseVideosPath.Click += new System.EventHandler(this.btnChooseVideosPath_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.btnSaveSettings, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSetToDefault, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 173);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(396, 34);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSaveSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveSettings.Location = new System.Drawing.Point(316, 3);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(77, 28);
            this.btnSaveSettings.TabIndex = 0;
            this.btnSaveSettings.Text = "Сохранить";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.Location = new System.Drawing.Point(7, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(143, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Выйти без сохранения";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSetToDefault
            // 
            this.btnSetToDefault.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSetToDefault.Location = new System.Drawing.Point(161, 5);
            this.btnSetToDefault.Name = "btnSetToDefault";
            this.btnSetToDefault.Size = new System.Drawing.Size(88, 23);
            this.btnSetToDefault.TabIndex = 2;
            this.btnSetToDefault.Text = "По умолчанию";
            this.btnSetToDefault.UseVisualStyleBackColor = true;
            this.btnSetToDefault.Click += new System.EventHandler(this.btnSetToDefault_Click);
            // 
            // ChoosePath
            // 
            this.ChoosePath.HelpRequest += new System.EventHandler(this.ChooseScreenshotsPath_HelpRequest);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 210);
            this.Controls.Add(this.Wrapper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Wrapper.ResumeLayout(false);
            this.Tabs.ResumeLayout(false);
            this.tabProgram.ResumeLayout(false);
            this.tabProgram.PerformLayout();
            this.tabClients.ResumeLayout(false);
            this.tabClients.PerformLayout();
            this.tabScreenshots.ResumeLayout(false);
            this.tabScreenshots.PerformLayout();
            this.groupScreenshots.ResumeLayout(false);
            this.groupScreenshots.PerformLayout();
            this.tabVideos.ResumeLayout(false);
            this.tabVideos.PerformLayout();
            this.groupVideos.ResumeLayout(false);
            this.groupVideos.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Wrapper;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSetToDefault;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage tabProgram;
        private System.Windows.Forms.TabPage tabClients;
        private System.Windows.Forms.Label labelLang;
        private System.Windows.Forms.ComboBox cmbLang;
        private System.Windows.Forms.CheckBox chbAutoupdate;
        private System.Windows.Forms.CheckBox chbAutostart;
        private System.Windows.Forms.TabPage tabScreenshots;
        private System.Windows.Forms.TabPage tabVideos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelImageFormat;
        private System.Windows.Forms.ComboBox cmbImageFormat;
        private System.Windows.Forms.FolderBrowserDialog ChoosePath;
        private System.Windows.Forms.CheckBox chbUploadImage;
        private System.Windows.Forms.GroupBox groupScreenshots;
        private System.Windows.Forms.TextBox txbScreenshotsPath;
        private System.Windows.Forms.Button btnChooseScreenshotsPath;
        private System.Windows.Forms.ComboBox cmbAreaScreen;
        private System.Windows.Forms.CheckBox chbAreaScreenShift;
        private System.Windows.Forms.CheckBox chbAreaScreenAlt;
        private System.Windows.Forms.CheckBox chbAreaScreenCtrl;
        private System.Windows.Forms.ComboBox cmbFullScreen;
        private System.Windows.Forms.CheckBox chbFullScreenShift;
        private System.Windows.Forms.CheckBox chbFullScreenAlt;
        private System.Windows.Forms.CheckBox chbFullScreenCtrl;
        private System.Windows.Forms.Label labelAreaScreen;
        private System.Windows.Forms.Label labelFullScreen;
        private System.Windows.Forms.ComboBox cmbAreaVideo;
        private System.Windows.Forms.CheckBox chbAreaVideoShift;
        private System.Windows.Forms.CheckBox chbAreaVideoAlt;
        private System.Windows.Forms.CheckBox chbAreaVideoCtrl;
        private System.Windows.Forms.ComboBox cmbFullVideo;
        private System.Windows.Forms.CheckBox chbFullVideoShift;
        private System.Windows.Forms.CheckBox chbFullVideoAlt;
        private System.Windows.Forms.CheckBox chbFullVideoCtrl;
        private System.Windows.Forms.Label labelAreaVideo;
        private System.Windows.Forms.Label labelFullVideo;
        private System.Windows.Forms.GroupBox groupVideos;
        private System.Windows.Forms.TextBox txbVideosPath;
        private System.Windows.Forms.Button btnChooseVideosPath;
        private System.Windows.Forms.Label labelSelectedClient;
        private System.Windows.Forms.ComboBox cmbSelectedClient;
    }
}