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
                Label_IpAddress.Text = "Невозможно получить IP-адрес. Возможно, отсутствует подключение к Интернету";
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
            labelCheckFlashInfo.Text = "Подготовка...";
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
                labelCheckFlashInfo.Text = "Открывается браузер...";
                System.Diagnostics.Process.Start(query);
            }
            catch (Exception)
            {
                labelCheckFlashInfo.Text = "Ошибка: не удалось загрузить информацию с сайта Adobe";
                return;
            }

        }

        private void btnCheckPorts_Click(object sender, EventArgs e)
        {
            txbNetworkResults.Text = string.Empty;
            var closed = Network.GetPortsStatus().Where(x => x.isOpen == false);
            if(closed.Count() > 0)
            {
                txbNetworkResults.Text = $"Следующие порты закрыты:\n{string.Join(", ",closed.Select(x => x.port))}\nИз-за этого игра может загружаться медленнее, чем должна.";
                txbNetworkResults.ForeColor = Color.Red;
            }
            else
            {
                txbNetworkResults.Text = "Все порты открыты";
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
            txbNetworkResults.Text = "Идет проверка...";
            switch(await Network.Ping())
            {
                case Network.TraceStatus.ServerUnavailable:
                    txbNetworkResults.Lines = new string[] { "Сервер недоступен",
                        "Возможно, технические работы на сервере или проблемы с вашим интернет-соединением" };
                    break;
                case Network.TraceStatus.PacketsLoss:
                    txbNetworkResults.Lines = new string[] { "Сервер доступен",
                        "Обнаружена потеря пакетов, возможны проблемы с интернет-соединением" };
                    break;
                case Network.TraceStatus.TooBigPingFluctuactions:
                    txbNetworkResults.Lines = new string[] { "Сервер доступен",
                        "Обнаружены скачки пинга, возможны проблемы с интернет-соединением" };
                    break;
                case Network.TraceStatus.BadPing:
                    txbNetworkResults.Lines = new string[] { "Сервер доступен",
                        "Очень высокий пинг, возможны проблемы с интернет-соединением" };
                    break;
                case Network.TraceStatus.HighPing:
                    txbNetworkResults.Lines = new string[] { "Сервер доступен",
                        "Высокий пинг, удовлетворительное качество связи" };
                    break;
                case Network.TraceStatus.NormalPing:
                    txbNetworkResults.Lines = new string[] { "Сервер доступен",
                        "Нормальный пинг, хорошее качество связи" };
                    break;
                case Network.TraceStatus.LowPing:
                    txbNetworkResults.Lines = new string[] { "Сервер доступен",
                        "Низкий пинг, отличное качество связи" };
                    break;
            }
        }

        private async void btnTrace_Click(object sender, EventArgs e)
        {
            txbNetworkResults.Text = "Трассировка...";
            var trace = await Network.Trace();
            var lost = trace.Where(x => x.status == Network.TraceStatus.PacketsLoss);
            var badping = trace.Where(x => x.status == Network.TraceStatus.BadPing);
            string res = "";
            txbNetworkResults.Text = "";
            if(lost.Count() == 0 || lost.Count() == 0)
            {
                res = "Проблем не выявлено";
            }
            else
            {
                if (lost.Count() > 0)
                {
                    res += "\nОбнаружена потеря пакетов, возможны проблемы с интернет-соединением:";
                    foreach (var item in lost)
                    {
                        res += "\n" + item.ToString();
                    }
                }
                if (lost.Count() > 0)
                {
                    res += "\nОчень высокий пинг, возможны проблемы с интернет-соединением:";
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
