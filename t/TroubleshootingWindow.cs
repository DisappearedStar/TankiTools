using System;
using System.Windows.Forms;

namespace TankiTools
{
    public partial class TroubleshootingWindow : Form
    {
        public static TroubleshootingWindow self { get; private set; } = null;
        public TroubleshootingWindow()
        {
            InitializeComponent();
            #region Localizing
            this.Text = L18n.Get("TroubleshootingWindow", "Troubleshooting_name");
            this.groupClients.Text = L18n.Get("TroubleshootingWindow", "GroupBox_groupClients");
            this.groupNetwork.Text = L18n.Get("TroubleshootingWindow", "GroupBox_groupNetwork");
            this.labelWarning.Text = L18n.Get("TroubleshootingWindow", "Label_labelWarning");
            this.btnClearCache.Text = L18n.Get("TroubleshootingWindow", "Button_btnClearCache");
            this.btnClearShared.Text = L18n.Get("TroubleshootingWindow", "Button_btnClearShared");
            this.btnIncreaseCache.Text = L18n.Get("TroubleshootingWindow", "Button_btnIncreaseCache");
            this.btnOpenPorts.Text = L18n.Get("TroubleshootingWindow", "Button_btnOpenPorts");
            this.btnSetNetworkThrottling.Text = L18n.Get("TroubleshootingWindow", "Button_btnSet");
            this.btnSetTcpAck.Text = L18n.Get("TroubleshootingWindow", "Button_btnSet");
            this.btnResetNetworkThrottling.Text = L18n.Get("TroubleshootingWindow", "Button_btnReset");
            this.btnResetTcpAck.Text = L18n.Get("TroubleshootingWindow", "Button_btnReset");
            this.labelTcpAck.Text = L18n.Get("TroubleshootingWindow", "Label_labelTcpAck");
            this.labelNetworkThrottling.Text = L18n.Get("TroubleshootingWindow", "Label_labelNetworkThrottling");
            #endregion
            if (Browsers.GetClientByString(SettingsManager.client_name) != Clients.Firefox 
            || Browsers.GetClientByString(SettingsManager.client_name) != Clients.IE)
            {
                btnIncreaseCache.Visible = false;
            }
            labelWarning.Text += Browsers.GetClientLocalizedName(Browsers.GetClientByString(SettingsManager.client_name));
            toolTipForTcp.SetToolTip(this.labelTcpAck, L18n.Get("TroubleshootingWindow", "Tooltip_TcpAck"));
            toolTipForThrottling.SetToolTip(this.labelNetworkThrottling, L18n.Get("TroubleshootingWindow", "Tooltip_NetworkThrottling"));
            if(SettingsManager.lang == "ru")
            {
                linkToWikiArticle.LinkClicked += (o, e) =>
                    System.Diagnostics.Process.Start(@"https://ru.tankiwiki.com/Экспериментальное_решение_проблем_с_лагами_и_дисконнектами");
            }
            else
            {
                linkToWikiArticle.Visible = false;
            }
            self = this;
        }

        private void btnClearCache_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_areyousure"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Browsers.ClearCache(Browsers.GetClientByString(SettingsManager.client_name));
                    MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_cachecleared"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_cacheerror"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearShared_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_areyousure"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Browsers.ClearSharedObjects(Browsers.GetClientByString(SettingsManager.client_name));
                    MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_sharedcleared"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_sharederror"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIncreaseCache_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_areyousure"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Browsers.IncreaseCacheSize(Browsers.GetClientByString(SettingsManager.client_name));
                    MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_cacheincreased"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_increaseerror"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TroubleshootingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            self = null;
        }

        private void btnOpenPorts_Click(object sender, EventArgs e)
        {
            try
            {
                if (Network.OpenPorts(Network.GetPortsStatus()))
                {
                    MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_done"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_nochange"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_openportserror"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSetTcpAck_Click(object sender, EventArgs e)
        {
            try
            {
                Network.SetTcpAck(true);
                MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_done"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_adminerror"), 
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetTcpAck_Click(object sender, EventArgs e)
        {
            try
            {
                Network.SetTcpAck(false);
                MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_done"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_adminerror"),
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSetNetworkThrottling_Click(object sender, EventArgs e)
        {
            try
            {
                Network.SetNetworkThrottling(true);
                MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_done"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_adminerror"),
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetNetworkThrottling_Click(object sender, EventArgs e)
        {
            try
            {
                Network.SetNetworkThrottling(false);
                MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_done"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(L18n.Get("TroubleshootingWindow", "Text_adminerror"),
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
