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
            if(Browsers.GetClientByString(SettingsManager.client_name) != Clients.Firefox 
            || Browsers.GetClientByString(SettingsManager.client_name) != Clients.IE)
            {
                btnIncreaseCache.Visible = false;
            }
            labelWarning.Text += Browsers.GetClientLocalizedName(Browsers.GetClientByString(SettingsManager.client_name));
            toolTipForTcp.SetToolTip(this.labelTcpAck, "Установка/сброс минимальной задержки при отправке подтверждений TCP");
            toolTipForThrottling.SetToolTip(this.labelNetworkThrottling, "Установка/сброс минимальной задержки обработки мультимедиа данных");
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
                if(MessageBox.Show("Вы уверены?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Browsers.ClearCache(Browsers.GetClientByString(SettingsManager.client_name));
                    MessageBox.Show("Кэш очищен", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка: не удалось очистить кэш.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearShared_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Browsers.ClearSharedObjects(Browsers.GetClientByString(SettingsManager.client_name));
                    MessageBox.Show("Shared Objects очищены", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка: не удалось очистить Shared Objects.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIncreaseCache_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Browsers.IncreaseCacheSize(Browsers.GetClientByString(SettingsManager.client_name));
                    MessageBox.Show("Кэш увеличен до максимума", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка: не удалось увеличить кэш.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Готово", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Изменений не требуется", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка: не удалось открыть порты.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSetTcpAck_Click(object sender, EventArgs e)
        {
            try
            {
                Network.SetTcpAck(true);
                MessageBox.Show("Готово", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка. Попробуйте запустить программу от имени администратора", 
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetTcpAck_Click(object sender, EventArgs e)
        {
            try
            {
                Network.SetTcpAck(false);
                MessageBox.Show("Готово", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка. Попробуйте запустить программу от имени администратора",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSetNetworkThrottling_Click(object sender, EventArgs e)
        {
            try
            {
                Network.SetNetworkThrottling(true);
                MessageBox.Show("Готово", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка. Попробуйте запустить программу от имени администратора",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetNetworkThrottling_Click(object sender, EventArgs e)
        {
            try
            {
                Network.SetNetworkThrottling(false);
                MessageBox.Show("Готово", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка. Попробуйте запустить программу от имени администратора",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
