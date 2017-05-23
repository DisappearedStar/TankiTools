using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Xml;

namespace TankiTools
{
    public partial class DiagnosticsWindow : Form
    {
        
        public DiagnosticsWindow()
        {
            InitializeComponent();
            FillSystemInfo();
        }

        private void FillSystemInfo()
        {
            
            Label_Processor.Text = SystemInfo.Info["CPU"];
            Label_Memory.Text = SystemInfo.Info["RAM"];
            Label_Graphics.Text = SystemInfo.Info["GPU"];
            Label_Driver.Text = SystemInfo.Info["Drivers"];
            Label_OS.Text = SystemInfo.Info["OS"];
            Label_Resolution.Text = SystemInfo.Info["Resolution"];
            Label_IpAddress.Text = Network.GetMyIpAddress();
            Network.GetPortsStatus(new int[] { 4444, 5222, 5223, 14444, 15222, 15223 });

            Network.OpenPorts(new int[] { 4444, 5222, 5223, 14444, 15222, 15223 });
            
        }


        private void DiagnosticsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void DiagnosticsWindow_TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = DiagnosticsWindow_TabControl.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = DiagnosticsWindow_TabControl.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.LightGray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Microsoft Sans Serif", (float)12, FontStyle.Regular, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Network.SetNetworkThrottling(true);
            Network.SetTcpAck(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Network.SetNetworkThrottling(false);
            Network.SetTcpAck(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Thread uploader = new Thread(new ParameterizedThreadStart(Screenshot.UploadToImgurAnonymously));
            //uploader.Start(new object[] { @"C:\Users\Dima\Desktop\kekus.jpg", screenshotUrl });
            //Screenshot.UploadToImgurAnonymously(@"C:\Users\Dima\Desktop\NewLobby1.png");
        }
        
        public void TestPutText(string text)
        {
            //textBox1.Text = text;
            notifyIcon1.Icon = SystemIcons.Exclamation;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipTitle = "Скриншот загружен";
            notifyIcon1.BalloonTipText = text;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(2000);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Screenshot.CaptureFullScreen();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //var f = new MediaHistory();
            //var f = new VideoRecorder();
            //var f = new SelectableScreenshotArea();
            //f.ShowDialog();
            try
            {
                //YouTube.Upload();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            
            //this.Show();

        }
    }
}
