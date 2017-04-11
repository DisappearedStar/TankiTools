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
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Diagnostics_Click(object sender, EventArgs e)
        {
            DiagnosticsWindow dw = new DiagnosticsWindow();
            this.Hide();
            dw.ShowDialog();
            this.Show();
        }
    }
}
