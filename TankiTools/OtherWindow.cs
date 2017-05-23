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
    public partial class OtherWindow : Form
    {
        public OtherWindow()
        {
            InitializeComponent();
        }

        private void btnUploadScreenshot_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new OtherHelper();
            f.CreateForm(OtherHelper.OtherType.UploadScreenshot);
            f.ShowDialog();
            this.Show();
        }

        private void btnUploadVideo_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new OtherHelper();
            f.CreateForm(OtherHelper.OtherType.UploadVideo);
            f.ShowDialog();
            this.Show();
        }
    }
}
