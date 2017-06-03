using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace TankiTools
{

    public partial class OtherHelper : Form
    {
        public static OtherHelper self { get; private set; } = null;

        CancellationTokenSource video_token;

        public enum OtherType { UploadScreenshot, UploadVideo }
        FileDialog OpenFileDialog = new OpenFileDialog();
        TableLayoutPanel wrapper = new TableLayoutPanel();
        Label label = new Label();
        Button btnChoose = new Button();
        Button btnUpload = new Button();
        TextBox txbLink = new TextBox();
        GroupBox group = new GroupBox();
        RadioButton rbPrivate = new RadioButton();
        RadioButton rbPublic = new RadioButton();
        RadioButton rbUnlisted = new RadioButton();
        ProgressBar bar = new ProgressBar();

        private delegate void ChangeProgressBarDelegate(int value);
        private delegate void UploadVideoCompletedDelegate(string id, string filename);


        public OtherHelper()
        {
            InitializeComponent();
            #region Init
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            OpenFileDialog.CheckFileExists = true;
            OpenFileDialog.CheckPathExists = true;
            wrapper.Dock = DockStyle.Fill;
            wrapper.RowCount = 0;
            wrapper.ColumnCount = 0;
            wrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            wrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            label.Text = L18n.Get("OtherHelper", "Text_nofile");
            label.Anchor = AnchorStyles.None;
            label.AutoSize = true;
            btnChoose.Text = L18n.Get("OtherHelper", "Text_choosefile");
            btnChoose.Anchor = AnchorStyles.None;
            btnChoose.Click += Choose_Click;
            btnUpload.Text = L18n.Get("OtherHelper", "Text_upload");
            btnUpload.Anchor = AnchorStyles.None;
            btnUpload.Enabled = false;
            txbLink.ReadOnly = true;
            txbLink.Anchor = AnchorStyles.None;
            //txbLink.AutoSize = true;
            txbLink.Size = new Size(200, 23);
            txbLink.Enabled = false;
            txbLink.Click += link_Click;
            group.Text = L18n.Get("OtherHelper", "Text_videoaccess");
            group.Dock = DockStyle.Fill;
            rbPublic.Checked = true;
            rbPrivate.Text = L18n.Get("OtherHelper", "Text_private");
            rbPublic.Text = L18n.Get("OtherHelper", "Text_public");
            rbUnlisted.Text = L18n.Get("OtherHelper", "Text_unlisted");
            rbPrivate.Location = new Point(215, 15);
            rbPublic.Location = new Point(5, 15);
            rbUnlisted.Location = new Point(110, 15);
            group.Controls.Add(rbPrivate);
            group.Controls.Add(rbPublic);
            group.Controls.Add(rbUnlisted);
            bar.Anchor = AnchorStyles.Left;
            bar.Size = new Size(208, 23);
            #endregion
            self = this;
        }
        public void CreateForm(OtherType type)
        {
            switch (type)
            {
                case OtherType.UploadScreenshot:
                    #region UploadScreenshot
                    this.Size = new Size(257, 129);
                    OpenFileDialog.InitialDirectory = SettingsManager.screenshots_path;
                    OpenFileDialog.Filter = L18n.Get("OtherHelper", "Text_imgexts");
                    wrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                    wrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                    btnUpload.Click += UploadScreenshot_Click;
                    wrapper.Controls.Add(label, 0, 0);
                    wrapper.Controls.Add(btnChoose, 1, 0);
                    wrapper.Controls.Add(txbLink, 0, 1);
                    wrapper.Controls.Add(btnUpload, 1, 1);
                    this.Controls.Add(wrapper);
                    #endregion
                    break;
                case OtherType.UploadVideo:
                    #region UploadVideo
                    this.Size = new Size(322, 144);
                    OpenFileDialog.InitialDirectory = SettingsManager.videos_path;
                    OpenFileDialog.Filter = L18n.Get("OtherHelper", "Text_videoexts");
                    wrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
                    wrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
                    wrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
                    btnUpload.Click += UploadVideo_Click;
                    wrapper.Controls.Add(label, 0, 0);
                    wrapper.Controls.Add(btnChoose, 1, 0);
                    wrapper.Controls.Add(group, 0, 1);
                    wrapper.SetColumnSpan(group, 3);
                    wrapper.Controls.Add(btnUpload, 1, 2);
                    this.Controls.Add(wrapper);
                    #endregion
                    break;
            }
        }

        private void Choose_Click(object sender, EventArgs e)
        {
            if(OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                label.ForeColor = Color.Black;
                label.Text = OpenFileDialog.FileName;
                btnUpload.Enabled = true;
            }
            else
            {
                try
                {
                    Path.GetFullPath(label.Text);
                }
                catch (Exception)
                {
                    btnUpload.Enabled = false;
                }
            }
        }

        private void link_Click(object sender, EventArgs e)
        {
            var textbox = sender as TextBox;
            if (!Util.CheckNullOrEmpty(textbox.Text))
            {
                Clipboard.SetText(textbox.Text);
                textbox.SelectAll();
            }
        }

        private async void UploadScreenshot_Click(object sender, EventArgs e)
        {
            btnUpload.Text = L18n.Get("OtherHelper", "Text_cancel");
            btnUpload.Click -= UploadScreenshot_Click;
            btnUpload.Click += UploadScreenshotCanceled;
            txbLink.Text = "";
            txbLink.Enabled = false;
            try
            {
                var filename = Path.GetFileName(label.Text);
                txbLink.Text = await Screenshot.UploadScreenshot(label.Text);
                MediaHistoryManager.AddLinkToEntry(filename, txbLink.Text, MediaHistoryManager.MediaType.Screenshot);
                label.Text = L18n.Get("OtherHelper", "Text_uploaded");
                label.ForeColor = Color.Green;
                txbLink.Enabled = true;
                btnUpload.Enabled = false;
            }
            catch (OperationCanceledException) { }
            finally
            {
                btnUpload.Click -= UploadScreenshotCanceled;
                btnUpload.Click += UploadScreenshot_Click;
                btnUpload.Text = L18n.Get("OtherHelper", "Text_upload");
            }
        }

        private async void UploadVideo_Click(object sender, EventArgs e)
        {
            if (video_token == null)
            {
                wrapper.Controls.Remove(txbLink);
                string state = rbPrivate.Checked ? "private" : (rbPublic.Checked ? "public" : "unlisted");
                wrapper.Controls.Add(bar, 0, 2);
                bar.Value = 0;
                video_token = new CancellationTokenSource();
                btnUpload.Text = L18n.Get("OtherHelper", "Text_cancel");
                try
                {
                    await YouTube.Upload(this, label.Text, state, video_token.Token);
                }
                catch (OperationCanceledException) { }                
                finally
                {
                    video_token = null;
                    wrapper.Controls.Remove(bar);
                    btnUpload.Text = L18n.Get("OtherHelper", "Text_upload");
                }
            }
            else
            {
                video_token.Cancel();
                video_token = null;
            }
        }

        public void ChangeProgressBar(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new ChangeProgressBarDelegate(ChangeProgressBar), new object[] { value });
                return;
            }
            if (bar.Value < value)
            {
                bar.Value = value;
            }
        }

        private void UploadScreenshotCanceled(object sender, EventArgs e)
        {
            try
            {
                Screenshot.CancelUpload();
            }
            catch (OperationCanceledException) { }
        }

        public void UploadVideoCompleted(string id, string filename)
        {
            if (InvokeRequired)
            {
                this.Invoke(new UploadVideoCompletedDelegate(UploadVideoCompleted), new object[] { id, filename });
                return;
            }
            try
            {
                wrapper.Controls.Remove(bar);
                wrapper.Controls.Remove(txbLink);
            }
            catch (Exception) { }
            label.Text = L18n.Get("OtherHelper", "Text_uploaded");
            label.ForeColor = Color.Green;
            txbLink.Text = $@"https://youtu.be/{id}";
            MediaHistoryManager.AddLinkToEntry(filename, txbLink.Text, MediaHistoryManager.MediaType.Video);
            txbLink.Enabled = true;
            wrapper.Controls.Add(txbLink, 0, 2);
            btnUpload.Enabled = false;
        }

        private void OtherHelper_FormClosing(object sender, FormClosingEventArgs e)
        {
            self = null;
        }
    }
}
