using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace TankiTools
{
    public partial class DiagnosticsWindow : Form
    {
        public static DiagnosticsWindow self { get; private set; } = null;
        public DiagnosticsWindow()
        {
            InitializeComponent();
            #region Localizing
            this.Text = L18n.Get("DiagnosticsWindow", "DiagnosticsWindow_name");
            this.Tab_SystemInfo.Text = L18n.Get("DiagnosticsWindow", "Tab_SystemInfo");
            this.Tab_Flash_Player.Text = L18n.Get("DiagnosticsWindow", "Tab_Flash_Player");
            this.Tab_Network.Text = L18n.Get("DiagnosticsWindow", "Tab_Network");

            this.forProcessor.Text = L18n.Get("DiagnosticsWindow", "Label_forProcessor");
            this.forMemory.Text = L18n.Get("DiagnosticsWindow", "Label_forMemory");
            this.forGraphics.Text = L18n.Get("DiagnosticsWindow", "Label_forGraphics");
            this.forDriver.Text = L18n.Get("DiagnosticsWindow", "Label_forDriver");
            this.forOS.Text = L18n.Get("DiagnosticsWindow", "Label_forOS");
            this.forResolution.Text = L18n.Get("DiagnosticsWindow", "Label_forResolution");
            this.forIpAddress.Text = L18n.Get("DiagnosticsWindow", "Label_forIpAddress");
            this.btnCheckFlash.Text = L18n.Get("DiagnosticsWindow", "Button_btnCheckFlash");
            this.btnCheckPorts.Text = L18n.Get("DiagnosticsWindow", "Button_btnCheckPorts");
            this.btnPing.Text = L18n.Get("DiagnosticsWindow", "Button_btnPing");
            this.btnTrace.Text = L18n.Get("DiagnosticsWindow", "Button_btnTrace");
            this.labelNetworkResults.Text = L18n.Get("DiagnosticsWindow", "Label_labelNetworkResults");
            #endregion;
            FillSystemInfo();
            self = this;
        }

        private void FillSystemInfo()
        {
            
            Label_Processor.Text = SystemInfo.Info["CPU"];
            Label_Memory.Text = SystemInfo.Info["RAM"];
            Label_Graphics.Text = SystemInfo.Info["GPU"];
            Label_Driver.Text = SystemInfo.Info["Drivers"];
            Label_OS.Text = SystemInfo.Info["OS"];
            Label_Resolution.Text = SystemInfo.Info["Resolution"];
            try
            {
                Label_IpAddress.Text = Network.GetMyIpAddress();
            }
            catch (Exception)
            {
                Label_IpAddress.Text = L18n.Get("DiagnosticsWindow", "Label_IpAddress_error");
            }
        }


        private void DiagnosticsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void DiagnosticsWindow_TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;
            TabPage _tabPage = DiagnosticsWindow_TabControl.TabPages[e.Index];
            Rectangle _tabBounds = DiagnosticsWindow_TabControl.GetTabRect(e.Index);
            if (e.State == DrawItemState.Selected)
            {
                _textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.LightGray, e.Bounds);
            }
            else
            {
                _textBrush = new SolidBrush(e.ForeColor);
                e.DrawBackground();
            }
            Font _tabFont = new Font("Microsoft Sans Serif", (float)12, FontStyle.Regular, GraphicsUnit.Pixel);
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private async void btnCheckFlash_Click(object sender, EventArgs e)
        {
            labelCheckFlashInfo.Text = L18n.Get("DiagnosticsWindow", "Label_labelCheckFlashInfo_prepare");
            string ppapi, npapi, activex;
            string[] urls = 
            {
                @"http://fpdownload.macromedia.com/get/flashplayer/update/current/xml/version_en_win_ax.xml",
                @"http://fpdownload.macromedia.com/get/flashplayer/update/current/xml/version_en_win_pep.xml",
                @"http://fpdownload.macromedia.com/get/flashplayer/update/current/xml/version_en_win_pl.xml"
            };
            try
            {
                using (WebClient c = new WebClient())
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(await c.DownloadStringTaskAsync(urls[0]));
                    activex = doc.GetElementsByTagName("update")[0].Attributes["version"].Value.Replace(",", ".");
                    doc.LoadXml(await c.DownloadStringTaskAsync(urls[1]));
                    ppapi = doc.GetElementsByTagName("update")[0].Attributes["version"].Value.Replace(",", ".");
                    doc.LoadXml(await c.DownloadStringTaskAsync(urls[2]));
                    npapi = doc.GetElementsByTagName("update")[0].Attributes["version"].Value.Replace(",", ".");
                }
                string query = $@"http://217.71.139.74/~user119/Povshedny_test/test.html?latest_ppapi={ppapi}&latest_npapi={npapi}&latest_activex={activex}";
                labelCheckFlashInfo.Text = L18n.Get("DiagnosticsWindow", "Label_labelCheckFlashInfo_opening");
                System.Diagnostics.Process.Start(query);
            }
            catch (Exception)
            {
                labelCheckFlashInfo.Text = L18n.Get("DiagnosticsWindow", "Label_labelCheckFlashInfo_error");
                return;
            }

        }

        private void btnCheckPorts_Click(object sender, EventArgs e)
        {
            txbNetworkResults.Text = string.Empty;
            var closed = Network.GetPortsStatus().Where(x => x.isOpen == false);
            if(closed.Count() > 0)
            {
                txbNetworkResults.Text = $"{L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_portsclosed1")} {string.Join(", ",closed.Select(x => x.port))}. {L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_portsclosed2")}";
                txbNetworkResults.ForeColor = Color.Red;
            }
            else
            {
                txbNetworkResults.Text = L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_portsopen");
                txbNetworkResults.ForeColor = Color.Green;
            }
        }

        private void DiagnosticsWindow_TabControl_Leave(object sender, EventArgs e)
        {
            labelCheckFlashInfo.Text = string.Empty;
            txbNetworkResults.Text = string.Empty;
            txbNetworkResults.ForeColor = Color.Black;
        }

        private async void btnPing_Click(object sender, EventArgs e)
        {
            txbNetworkResults.Text = L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_pinging");
            switch (await Network.Ping())
            {
                #region Switch results
                case Network.TraceStatus.ServerUnavailable:
                    txbNetworkResults.Lines = new string[] 
                    {
                        L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_serverunavailable1"),
                        L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_serverunavailable2")
                    };
                    break;
                case Network.TraceStatus.PacketsLoss:
                    txbNetworkResults.Lines = new string[] 
                    {
                        L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_serveravailable"),
                        L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_packetsloss")
                    };
                    break;
                case Network.TraceStatus.TooBigPingFluctuactions:
                    txbNetworkResults.Lines = new string[] 
                    {
                        L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_serveravailable"),
                        L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_pingfluctuations")
                    };
                    break;
                case Network.TraceStatus.BadPing:
                    txbNetworkResults.Lines = new string[] 
                    {
                        L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_serveravailable"),
                        L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_badping")
                    };
                    break;
                case Network.TraceStatus.HighPing:
                    txbNetworkResults.Lines = new string[] 
                    {
                        L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_serveravailable"),
                        L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_highping")
                    };
                    break;
                case Network.TraceStatus.NormalPing:
                    txbNetworkResults.Lines = new string[] 
                    {
                        L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_serveravailable"),
                        L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_normalping")
                    };
                    break;
                case Network.TraceStatus.LowPing:
                    txbNetworkResults.Lines = new string[] 
                    {
                        L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_serveravailable"),
                        L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_lowping")
                    };
                    break;
                    #endregion
            }
        }

        private async void btnTrace_Click(object sender, EventArgs e)
        {
            txbNetworkResults.Text = L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_tracing");
            var trace = await Network.Trace();
            var lost = trace.Where(x => x.status == Network.TraceStatus.PacketsLoss);
            var badping = trace.Where(x => x.status == Network.TraceStatus.BadPing);
            string res = "";
            txbNetworkResults.Text = "";
            if(lost.Count() == 0 || lost.Count() == 0)
            {
                res = L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_noproblem");
            }
            else
            {
                if (lost.Count() > 0)
                {
                    res += "\n" + L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_packetsloss");
                    foreach (var item in lost)
                    {
                        res += "\n" + item.ToString();
                    }
                }
                if (badping.Count() > 0)
                {
                    res += "\n" + L18n.Get("DiagnosticsWindow", "TextBox_txbNetworkResults_badping");
                    foreach (var item in badping)
                    {
                        res += "\n" + item.ToStringWithPing();
                    }
                }
            }
            txbNetworkResults.Lines = res.Split('\n');
        }

        private void DiagnosticsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            self = null;
        }
    }
}
