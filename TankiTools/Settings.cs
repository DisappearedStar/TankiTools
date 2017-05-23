using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace TankiTools
{
    public partial class Settings : Form
    {
        Dictionary<string, string> current;
        Dictionary<string, string> clients;
        public Settings()
        {
            InitializeComponent();
            clients = SettingsManager.MakeClientsList();
            Init();
            current = GetCurrentGuiSettings();
            
        }

        private void Init()
        {
            foreach (Control c in GetAllControls(this))
            {
                if (c is ComboBox) (c as ComboBox).Items.Clear();
                if (c is CheckBox) (c as CheckBox).Checked = false;
                if (c is TextBox) (c as TextBox).Text = "";
            }
            cmbImageFormat.Items.AddRange(SettingsManager.ImageFormats);
            cmbLang.Items.AddRange(SettingsManager.Languages);
            cmbSelectedClient.Items.AddRange(clients.Keys.ToArray());
            cmbAreaScreen.Items.AddRange(SettingsManager.Keys);
            cmbFullScreen.Items.AddRange(SettingsManager.Keys);
            cmbAreaVideo.Items.AddRange(SettingsManager.Keys);
            cmbFullVideo.Items.AddRange(SettingsManager.Keys);

            chbAutostart.Checked = SettingsManager.autostart;
            chbAutoupdate.Checked = SettingsManager.autoupdate;

            foreach(var k in clients.Keys.ToList())
            {
                if(SettingsManager.client_name == clients[k])
                {
                    cmbSelectedClient.SelectedItem = k;
                }
            }
            if (SettingsManager.lang == "en")
            {
                cmbLang.SelectedItem = "English";
            }
            else
            {
                cmbLang.SelectedItem = "Русский";
            }
            if (SettingsManager.screenshots_format == "jpg")
            {
                cmbImageFormat.SelectedItem = "JPG";
            }
            else
            {
                cmbImageFormat.SelectedItem = "PNG";
            }
            chbUploadImage.Checked = SettingsManager.screenshots_upload;

            var _keys = SettingsManager.screenshots_fullKeys.Split('+');
            foreach (string key in _keys)
            {
                if (key == "Ctrl") chbFullScreenCtrl.Checked = true;
                if (key == "Alt") chbFullScreenAlt.Checked = true;
                if (key == "Shift") chbFullScreenShift.Checked = true;
                if (SettingsManager.Keys.Contains(key))
                {
                    cmbFullScreen.SelectedItem = key;
                }
                else
                {
                    cmbFullScreen.SelectedItem = "1";
                }
            }
            _keys = SettingsManager.screenshots_areaKeys.Split('+');
            foreach (string key in _keys)
            {
                if (key == "Ctrl") chbAreaScreenCtrl.Checked = true;
                if (key == "Alt") chbAreaScreenAlt.Checked = true;
                if (key == "Shift") chbAreaScreenShift.Checked = true;
                if (SettingsManager.Keys.Contains(key))
                {
                    cmbAreaScreen.SelectedItem = key;
                }
                else
                {
                    cmbAreaScreen.SelectedItem = "1";
                }
            }
            txbScreenshotsPath.Text = SettingsManager.screenshots_path;

            _keys = SettingsManager.videos_fullKeys.Split('+');
            foreach (string key in _keys)
            {
                if (key == "Ctrl") chbFullVideoCtrl.Checked = true;
                if (key == "Alt") chbFullVideoAlt.Checked = true;
                if (key == "Shift") chbFullVideoShift.Checked = true;
                if (SettingsManager.Keys.Contains(key))
                {
                    cmbFullVideo.SelectedItem = key;
                }
                else
                {
                    cmbFullVideo.SelectedItem = "1";
                }
            }
            _keys = SettingsManager.videos_areaKeys.Split('+');
            foreach (string key in _keys)
            {
                if (key == "Ctrl") chbAreaVideoCtrl.Checked = true;
                if (key == "Alt") chbAreaVideoAlt.Checked = true;
                if (key == "Shift") chbAreaVideoShift.Checked = true;
                if (SettingsManager.Keys.Contains(key))
                {
                    cmbAreaVideo.SelectedItem = key;
                }
                else
                {
                    cmbAreaVideo.SelectedItem = "1";
                }
            }
            txbVideosPath.Text = SettingsManager.videos_path;
        }

        private void btnChooseScreenshotsPath_Click(object sender, EventArgs e)
        {
            if(ChoosePath.ShowDialog() == DialogResult.OK)
            {
                txbScreenshotsPath.Text = ChoosePath.SelectedPath;
            }
        }

        private void btnChooseVideosPath_Click(object sender, EventArgs e)
        {
            if (ChoosePath.ShowDialog() == DialogResult.OK)
            {
                txbVideosPath.Text = ChoosePath.SelectedPath;
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            SettingsManager.SetSettingsFromGui(GetCurrentGuiSettings());
            SettingsManager.SetAutostart(SettingsManager.autostart);
            SettingsManager.SaveSettingsToFile();
            this.Close();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetToDefault_Click(object sender, EventArgs e)
        {
            SettingsManager.SetDefaultSettings();
            Init();
            SettingsManager.SetSettingsFromGui(current);
        }
        private Dictionary<string, string> GetCurrentGuiSettings()
        {
            var dict = new Dictionary<string, string>();
            dict.Add(chbAutostart.Name, chbAutostart.Checked.ToString().ToLower());
            dict.Add(chbAutoupdate.Name, chbAutoupdate.Checked.ToString().ToLower());
            dict.Add(cmbLang.Name, cmbLang.SelectedItem.ToString());
            dict.Add(cmbSelectedClient.Name, clients[cmbSelectedClient.SelectedItem.ToString()]);
            dict.Add(cmbImageFormat.Name, cmbImageFormat.SelectedItem.ToString().ToLower());
            dict.Add(chbUploadImage.Name, chbUploadImage.Checked.ToString().ToLower());
            dict.Add(txbScreenshotsPath.Name, txbScreenshotsPath.Text);
            dict.Add(cmbFullScreen.Name, cmbFullScreen.SelectedItem.ToString());
            dict.Add(cmbAreaScreen.Name, cmbAreaScreen.SelectedItem.ToString());
            dict.Add(chbFullScreenCtrl.Name, chbFullScreenCtrl.Checked.ToString().ToLower());
            dict.Add(chbFullScreenAlt.Name, chbFullScreenAlt.Checked.ToString().ToLower());
            dict.Add(chbFullScreenShift.Name, chbFullScreenShift.Checked.ToString().ToLower());
            dict.Add(chbAreaScreenCtrl.Name, chbAreaScreenCtrl.Checked.ToString().ToLower());
            dict.Add(chbAreaScreenAlt.Name, chbAreaScreenAlt.Checked.ToString().ToLower());
            dict.Add(chbAreaScreenShift.Name, chbAreaScreenShift.Checked.ToString().ToLower());
            dict.Add(cmbFullVideo.Name, cmbFullVideo.SelectedItem.ToString());
            dict.Add(cmbAreaVideo.Name, cmbAreaVideo.SelectedItem.ToString());
            dict.Add(chbFullVideoCtrl.Name, chbFullVideoCtrl.Checked.ToString().ToLower());
            dict.Add(chbFullVideoAlt.Name, chbFullVideoAlt.Checked.ToString().ToLower());
            dict.Add(chbFullVideoShift.Name, chbFullVideoShift.Checked.ToString().ToLower());
            dict.Add(chbAreaVideoCtrl.Name, chbAreaVideoCtrl.Checked.ToString().ToLower());
            dict.Add(chbAreaVideoAlt.Name, chbAreaVideoAlt.Checked.ToString().ToLower());
            dict.Add(chbAreaVideoShift.Name, chbAreaVideoShift.Checked.ToString().ToLower());
            dict.Add(txbVideosPath.Name, txbVideosPath.Text);
            return dict;
        }
        public IEnumerable<Control> GetAllControls(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControls(ctrl)).Concat(controls).Where(c => typeof(Control).IsInstanceOfType(c));
        }
        private void ChooseScreenshotsPath_HelpRequest(object sender, EventArgs e) { }
    }
}
