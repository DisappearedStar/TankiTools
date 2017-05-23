using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video.FFMPEG;
using AForge.Video;
using AutoUpdaterDotNET;
using System.Globalization;

namespace TankiTools
{
    public partial class MainWindow : Form
    {
        DiagnosticsWindow dw;

        
        public MainWindow()
        {
            InitializeComponent();
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(SettingsManager).TypeHandle);
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(MediaHistoryManager).TypeHandle);
            SystemInfo.onInit += Enable;
            SystemInfo.Init();
            dw = new DiagnosticsWindow();
            //AutoUpdater.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");
            //AutoUpdater.Start(@"http://217.71.139.74/~user119/Povshedny_test/version.xml");
            
        }

        private void Enable()
        {
            Button_Diagnostics.Enabled = true;
        }
        private void Button_Diagnostics_Click(object sender, EventArgs e)
        {
            this.Hide();
            dw.ShowDialog();
            this.Show();
        }

        private void Button_Settings_Click(object sender, EventArgs e)
        {
            this.Hide();
            Settings settings = new Settings();
            settings.ShowDialog();
            this.Show();
        }

        private void Button_Other_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new OtherWindow();
            f.ShowDialog();
            this.Show();
        }
    }
}
