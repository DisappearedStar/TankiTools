using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TankiTools
{
    public partial class MainWindow : Form
    {
        DiagnosticsWindow dw;
        SystemInfo info;

        public MainWindow()
        {
            InitializeComponent();
            info = new SystemInfo();
            //SystemInfo.Init();
            dw = new DiagnosticsWindow();
            info.onInit += (sender, args) => { Enable(); };
        }

        private void Enable()
        {
            MessageBox.Show("slovil");
            Button_Diagnostics.Enabled = true;
        }
        private void Button_Diagnostics_Click(object sender, EventArgs e)
        {
            this.Hide();
            dw.ShowDialog();
            this.Show();
        }
    }
}
