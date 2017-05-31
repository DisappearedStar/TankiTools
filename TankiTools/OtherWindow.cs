using System;
using System.Windows.Forms;

namespace TankiTools
{
    public partial class OtherWindow : Form
    {
        public static OtherWindow self { get; private set; } = null;

        public OtherWindow()
        {
            InitializeComponent();
            self = this;
        }

        private void btnUploadScreenshot_Click(object sender, EventArgs e)
        {
            if (OtherHelper.self == null)
            {
                this.Hide();
                OtherHelper window = new OtherHelper();
                window.CreateForm(OtherHelper.OtherType.UploadScreenshot);
                window.ShowDialog();
                this.Show();
            }
            else
            {
                if (OtherHelper.self.WindowState == FormWindowState.Minimized)
                    OtherHelper.self.WindowState = FormWindowState.Normal;
                else OtherHelper.self.Show();
            }
        }

        private void btnUploadVideo_Click(object sender, EventArgs e)
        {
            if (OtherHelper.self == null)
            {
                this.Hide();
                OtherHelper window = new OtherHelper();
                window.CreateForm(OtherHelper.OtherType.UploadVideo);
                window.ShowDialog();
                this.Show();
            }
            else
            {
                if (OtherHelper.self.WindowState == FormWindowState.Minimized)
                    OtherHelper.self.WindowState = FormWindowState.Normal;
                else OtherHelper.self.Show();
            }
        }

        private void btnOpenMediaHistory_Click(object sender, EventArgs e)
        {
            if (MediaHistory.self == null)
            {
                this.Hide();
                MediaHistory window = new MediaHistory();
                window.ShowDialog();
                this.Show();
            }
            else
            {
                if (MediaHistory.self.WindowState == FormWindowState.Minimized)
                    MediaHistory.self.WindowState = FormWindowState.Normal;
                else MediaHistory.self.Show();
            }
        }

        private void OtherWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            self = null;
        }
    }
}
