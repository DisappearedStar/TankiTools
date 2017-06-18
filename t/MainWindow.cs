using System;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using AutoUpdaterDotNET;

namespace TankiTools
{
    public partial class MainWindow : Form
    {
        public static NotifyIcon TrayApp { get; set; } = new NotifyIcon();

        public MainWindow()
        {

            InitializeComponent();
            #region Localizing
            this.Button_Diagnostics.Text = L18n.Get("MainWindow", "Button_Diagnostics");
            this.Button_Troubleshooting.Text = L18n.Get("MainWindow", "Button_Troubleshooting");
            this.Button_Settings.Text = L18n.Get("MainWindow", "Button_Settings");
            this.Button_Other.Text = L18n.Get("MainWindow", "Button_Other");
            this.Button_Exit.Text = L18n.Get("MainWindow", "Button_Exit");
            #endregion
            #region TrayApp
            TrayApp.BalloonTipIcon = ToolTipIcon.None;
            TrayApp.Icon = Properties.Resources.TankiToolsIcon;
            TrayApp.Text = "TankiTools";
            TrayApp.Visible = true;
            TrayApp.BalloonTipTitle = "TankiTools";
            var menu = new ContextMenuStrip();
            menu.Items.Add("TankiTools", Properties.Resources.TankiToolsIcon.ToBitmap(), (o, ea) =>
            {
                if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;
                else this.Show();
            });
            menu.Items.Add(L18n.Get("TrayApp", "ItemSettings"), Properties.Resources.Settings_small, Button_Settings_Click);
            menu.Items.Add(L18n.Get("TrayApp", "ItemHistory"), Properties.Resources.Mediahistory_small, OpenMediaHistory);
            menu.Items.Add($"[{SettingsManager.screenshots_fullKeys}] {L18n.Get("TrayApp", "ItemScreenshotFull")}", null, (o, ea) => Screenshot.CaptureFullScreen());
            menu.Items.Add($"[{SettingsManager.screenshots_areaKeys}] {L18n.Get("TrayApp", "ItemScreenshotArea")}", null, (o, ea) => new SelectableScreenshotArea());
            menu.Items.Add($"[{SettingsManager.videos_fullKeys}] {L18n.Get("TrayApp", "ItemVideoFull")}", null, (o, ea) =>
            {
                if (!VideoRecorder1._isRecording) VideoRecorder1.StartRec(CaptureTypes.VideoFull);
                else VideoRecorder1._isRecording = false;
            });
            menu.Items.Add($"[{SettingsManager.videos_areaKeys}] {L18n.Get("TrayApp", "ItemVideoArea")}", null, (o, ea) =>
            {
                if (!VideoRecorder1._isRecording) VideoRecorder1.StartRec(CaptureTypes.VideoArea);
                else VideoRecorder1._isRecording = false;
            });
            menu.Items.Add(L18n.Get("TrayApp", "ItemExit"), Properties.Resources.Exit_small, (o, ea) => 
            {
                SettingsManager.UnsetGlobalHotkeys();
                Program.Shutdown();
            });
            TrayApp.ContextMenuStrip = menu;
            #endregion
            Util.Main = this;
        }
        
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == SettingsManager.WM_HOTKEY_MSG_ID && (int)m.WParam == SettingsManager.HotkeyIds[CaptureTypes.ScreenArea])
            {
                var f = new SelectableScreenshotArea();
            }
            if (m.Msg == SettingsManager.WM_HOTKEY_MSG_ID && (int)m.WParam == SettingsManager.HotkeyIds[CaptureTypes.ScreenFull])
            {
                Screenshot.CaptureFullScreen();
            }
            if (m.Msg == SettingsManager.WM_HOTKEY_MSG_ID && (int)m.WParam == SettingsManager.HotkeyIds[CaptureTypes.VideoArea])
            {
                if (!VideoRecorder1._isRecording)
                    VideoRecorder1.StartRec(CaptureTypes.VideoArea);
                else
                    VideoRecorder1._isRecording = false;
            }
            if (m.Msg == SettingsManager.WM_HOTKEY_MSG_ID && (int)m.WParam == SettingsManager.HotkeyIds[CaptureTypes.VideoFull])
            {
                if (!VideoRecorder1._isRecording)
                    VideoRecorder1.StartRec(CaptureTypes.VideoFull);
                else
                    VideoRecorder1._isRecording = false;
            }
            base.WndProc(ref m);
        }


        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                SettingsManager.UnsetGlobalHotkeys();
                Program.Shutdown();
            }
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
        }

        #region Button handlers

        private void Button_Diagnostics_Click(object sender, EventArgs e)
        {
            if (DiagnosticsWindow.self == null)
            {
                this.Hide();
                DiagnosticsWindow window = new DiagnosticsWindow();
                window.ShowDialog();
                this.Show();
            }
            else
            {
                if (DiagnosticsWindow.self.WindowState == FormWindowState.Minimized)
                    DiagnosticsWindow.self.WindowState = FormWindowState.Normal;
                else DiagnosticsWindow.self.Show();
            }
        }

        private void Button_Settings_Click(object sender, EventArgs e)
        {
            if (Settings.self == null)
            {
                this.Hide();
                Settings window = new Settings();
                window.ShowDialog();
                this.Show();
            }
            else
            {
                if (Settings.self.WindowState == FormWindowState.Minimized)
                    Settings.self.WindowState = FormWindowState.Normal;
                else Settings.self.Show();
            }
        }

        private void OpenMediaHistory(object sender, EventArgs e)
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

        private void Button_Other_Click(object sender, EventArgs e)
        {
            if (OtherWindow.self == null)
            {
                this.Hide();
                OtherWindow window = new OtherWindow();
                window.ShowDialog();
                this.Show();
            }
            else
            {
                if (OtherWindow.self.WindowState == FormWindowState.Minimized)
                    OtherWindow.self.WindowState = FormWindowState.Normal;
                else OtherWindow.self.Show();
            }
        }

        private void Button_Troubleshooting_Click(object sender, EventArgs e)
        {
            if (TroubleshootingWindow.self == null)
            {
                this.Hide();
                TroubleshootingWindow window = new TroubleshootingWindow();
                window.ShowDialog();
                this.Show();
            }
            else
            {
                if (TroubleshootingWindow.self.WindowState == FormWindowState.Minimized)
                    TroubleshootingWindow.self.WindowState = FormWindowState.Normal;
                else TroubleshootingWindow.self.Show();
            }
        }
        private void Button_Exit_Click(object sender, EventArgs e)
        {
            SettingsManager.UnsetGlobalHotkeys();
            Program.Shutdown();
        }
        #endregion
    }
}
