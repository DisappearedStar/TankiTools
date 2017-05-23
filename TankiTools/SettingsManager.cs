using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace TankiTools
{
    static class SettingsManager
    {
        public static readonly string SettingsFile = Path.Combine(Util.StartupPath, "settings.xml");
        public static readonly string[] Keys = 
        {
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",
            "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12"
        };
        public static readonly string[] Languages = { "Русский", "English" };
        public static readonly string[] ImageFormats = { "PNG", "JPG" };

        public static bool autostart { get; private set; }
        public static bool autoupdate { get; private set; }
        public static string lang { get; private set; }
        public static string client_name { get; private set; }
        public static string screenshots_format { get; private set; }
        public static string screenshots_path { get; private set; }
        public static bool screenshots_upload { get; private set; }
        public static string screenshots_fullKeys { get; private set; }
        public static string screenshots_areaKeys { get; private set; }
        public static string videos_path { get; private set; }
        public static string videos_fullKeys { get; private set; }
        public static string videos_areaKeys { get; private set; }

        static SettingsManager()
        {
            if (IsFirstRun())
            {
                SetDefaultSettings();
                SaveSettingsToFile();
            }
            else
            {
                if (File.Exists(SettingsFile))
                {
                    GetSettingsFromFile();
                }
                else
                {
                    SetDefaultSettings();
                    SaveSettingsToFile();
                }
            }
        }

        public static void SetDefaultSettings()
        {
            autostart = DefaultSettings.autostart;
            autoupdate = DefaultSettings.autoupdate;
            lang = DefaultSettings.lang;
            client_name = DefaultSettings.client_name;
            screenshots_format = DefaultSettings.screenshots_format;
            screenshots_path = DefaultSettings.screenshots_path;
            screenshots_upload = DefaultSettings.screenshots_upload;
            screenshots_fullKeys = DefaultSettings.screenshots_fullKeys;
            screenshots_areaKeys = DefaultSettings.screenshots_areaKeys;
            videos_path = DefaultSettings.videos_path;
            videos_fullKeys = DefaultSettings.videos_fullKeys;
            videos_areaKeys = DefaultSettings.videos_areaKeys;
        }

        public static void SaveSettingsToFile()
        {
            XDocument settings = new XDocument(
                new XElement("settings",
                    new XElement("program",
                        new XAttribute("autostart", autostart.ToString().ToLower()),
                        new XAttribute("autoupdate", autoupdate.ToString().ToLower()),
                        new XAttribute("lang", lang)
                    ),
                    new XElement("client",
                        new XAttribute("name", client_name)
                    ),
                    new XElement("screenshots",
                        new XAttribute("format", screenshots_format),
                        new XAttribute("path", screenshots_path),
                        new XAttribute("upload", screenshots_upload.ToString().ToLower()),
                        new XAttribute("fullKeys", screenshots_fullKeys),
                        new XAttribute("areaKeys", screenshots_areaKeys)
                    ),
                    new XElement("videos",
                        new XAttribute("path", videos_path),
                        new XAttribute("fullKeys", videos_fullKeys),
                        new XAttribute("areaKeys", videos_areaKeys)
                    )
                )
            );
            using (StreamWriter w = new StreamWriter(SettingsFile, false))
            {
                settings.Save(w);
            }
        }

        
        public static void SetSettingsFromGui(Dictionary<string, string> state)
        {
            autostart = Convert.ToBoolean(state["chbAutostart"]);
            autoupdate = Convert.ToBoolean(state["chbAutoupdate"]);
            lang = state["cmbLang"] == "English" ? "en" : "ru";
            client_name = state["cmbSelectedClient"];
            screenshots_format = state["cmbImageFormat"];
            screenshots_upload = Convert.ToBoolean(state["chbUploadImage"]);
            screenshots_path = state["txbScreenshotsPath"];
            var _keys = new List<string>();
            if (Convert.ToBoolean(state["chbFullScreenCtrl"])) _keys.Add("Ctrl");
            if (Convert.ToBoolean(state["chbFullScreenAlt"])) _keys.Add("Alt");
            if (Convert.ToBoolean(state["chbFullScreenShift"])) _keys.Add("Shift");
            _keys.Add(state["cmbFullScreen"]);
            screenshots_fullKeys = string.Join("+", _keys);
            _keys.Clear();
            if (Convert.ToBoolean(state["chbAreaScreenCtrl"])) _keys.Add("Ctrl");
            if (Convert.ToBoolean(state["chbAreaScreenAlt"])) _keys.Add("Alt");
            if (Convert.ToBoolean(state["chbAreaScreenShift"])) _keys.Add("Shift");
            _keys.Add(state["cmbAreaScreen"]);
            screenshots_areaKeys = string.Join("+", _keys);
            _keys.Clear();
            videos_path = state["txbVideosPath"];
            if (Convert.ToBoolean(state["chbFullVideoCtrl"])) _keys.Add("Ctrl");
            if (Convert.ToBoolean(state["chbFullVideoAlt"])) _keys.Add("Alt");
            if (Convert.ToBoolean(state["chbFullVideoShift"])) _keys.Add("Shift");
            _keys.Add(state["cmbFullVideo"]);
            videos_fullKeys = string.Join("+", _keys);
            _keys.Clear();
            if (Convert.ToBoolean(state["chbAreaVideoCtrl"])) _keys.Add("Ctrl");
            if (Convert.ToBoolean(state["chbAreaVideoAlt"])) _keys.Add("Alt");
            if (Convert.ToBoolean(state["chbAreaVideoShift"])) _keys.Add("Shift");
            _keys.Add(state["cmbAreaVideo"]);
            videos_areaKeys = string.Join("+", _keys);
            _keys.Clear();
        }

        public static void GetSettingsFromFile()
        {
            XDocument settings;
            try
            {
                using (FileStream stream = new FileStream(SettingsFile, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    settings = XDocument.Load(stream);
                }
            }
            catch (Exception)
            {
                SetDefaultSettings();
                return;
            }
            XElement root = settings.Root;
            try
            {
                var _autostart = root.Element("program").Attribute("autostart").Value;
                autostart = Util.CheckNullOrEmpty(_autostart) ? DefaultSettings.autostart : Convert.ToBoolean(_autostart);
            }
            catch (Exception)
            {
                autostart = DefaultSettings.autostart;
            }
            try
            {
                var _autoupdate = root.Element("program").Attribute("autoupdate").Value;
                autoupdate = Util.CheckNullOrEmpty(_autoupdate) ? DefaultSettings.autoupdate : Convert.ToBoolean(_autoupdate);
            }
            catch (Exception)
            {
                autoupdate = DefaultSettings.autoupdate;
            }
            try
            {
                var _lang = root.Element("program").Attribute("lang").Value;
                lang = Util.CheckNullOrEmpty(_lang) ? DefaultSettings.lang : (_lang == "en" ? _lang : "ru");
            }
            catch (Exception)
            {
                lang = DefaultSettings.lang;
            }
            try
            {
                var _name = root.Element("client").Attribute("name").Value;
                client_name = Util.CheckNullOrEmpty(_name) ? DefaultSettings.client_name : _name;
            }
            catch (Exception)
            {
                client_name = DefaultSettings.client_name;
            }
            try
            {
                var _format = root.Element("screenshots").Attribute("format").Value;
                screenshots_format = Util.CheckNullOrEmpty(_format) ? DefaultSettings.screenshots_format :_format;
            }
            catch (Exception)
            {
                screenshots_format = DefaultSettings.screenshots_format;
            }
            try
            {
                var _path = root.Element("screenshots").Attribute("path").Value;
                screenshots_path = Util.CheckNullOrEmpty(_path) ? DefaultSettings.screenshots_path :_path;
            }
            catch (Exception)
            {
                screenshots_path = DefaultSettings.screenshots_path;
            }
            try
            {
                var _upload = root.Element("screenshots").Attribute("upload").Value;
                screenshots_upload = Util.CheckNullOrEmpty(_upload) ? DefaultSettings.screenshots_upload : Convert.ToBoolean(_upload);
            }
            catch (Exception)
            {
                screenshots_upload = DefaultSettings.screenshots_upload;
            }
            try
            {
                var _full = root.Element("screenshots").Attribute("fullKeys").Value;
                screenshots_fullKeys = Util.CheckNullOrEmpty(_full) ? DefaultSettings.screenshots_fullKeys :_full;
            }
            catch (Exception)
            {
                screenshots_fullKeys = DefaultSettings.screenshots_fullKeys;
            }
            try
            {
                var _area = root.Element("screenshots").Attribute("areaKeys").Value;
                screenshots_areaKeys = Util.CheckNullOrEmpty(_area) ? DefaultSettings.screenshots_areaKeys : _area;
            }
            catch (Exception)
            {
                screenshots_areaKeys = DefaultSettings.screenshots_areaKeys;
            }
            try
            {
                var _path = root.Element("videos").Attribute("path").Value;
                videos_path = Util.CheckNullOrEmpty(_path) ? DefaultSettings.videos_path : _path;
            }
            catch (Exception)
            {
                videos_path = DefaultSettings.videos_path;
            }
            try
            {
                var _full = root.Element("videos").Attribute("fullKeys").Value;
                videos_fullKeys = Util.CheckNullOrEmpty(_full) ? DefaultSettings.videos_fullKeys : _full;
            }
            catch (Exception)
            {
                videos_fullKeys = DefaultSettings.videos_fullKeys;
            }
            try
            {
                var _area = root.Element("videos").Attribute("areaKeys").Value;
                videos_areaKeys = Util.CheckNullOrEmpty(_area) ? DefaultSettings.videos_areaKeys : _area;
            }
            catch (Exception)
            {
                videos_areaKeys = DefaultSettings.videos_areaKeys;
            }
        }


        public static bool IsFirstRun()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\TankiTools", true);
            if(rk != null)
            {
                var flag = rk.GetValue("FirstRun");
                if (flag != null)
                {
                    if((int)flag == 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    rk.SetValue("FirstRun", 1);
                    return true;
                }
            }
            else
            {
                Registry.CurrentUser.OpenSubKey(@"SOFTWARE", true).CreateSubKey("TankiTools").SetValue("FirstRun", 1);
                return true;
            }
        }

        public static void SetAutostart(bool state)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (state)
            {
                rk.SetValue("TankiTools", Application.ExecutablePath, RegistryValueKind.String);
            }
            else
            {
                if (rk.GetValue("TankiTools") != null)
                {
                    rk.DeleteValue("TankiTools");
                }
                
            }
        }

        public static Dictionary<string, string> MakeClientsList()
        {
            List<Clients> list = Browsers.GetInstalledBrowsers();
            list.Add(Clients.ThirdPartyClient);
            list.Add(Clients.SAFP);
            if (Directory.Exists(Path.Combine(Util.AppDataRoaming, "TankiOnline")))
            {
                list.Add(Clients.OfficialClient);
            }
            var dict = new Dictionary<string, string>();
            foreach(var c in list)
            {
                dict.Add(Browsers.GetClientLocalizedName(c), c.ToString());
            }
            return dict;
        }

        public static class DefaultSettings
        {
            public const bool autostart = false;
            public const bool autoupdate = false;
            public const string lang = "ru";
            public static readonly string client_name = Browsers.GetDefaultBrowser().ToString();
            public const string screenshots_format = "png";
            public static readonly string screenshots_path = Path.Combine(Util.StartupPath, @"media\screenshots");
            public const bool screenshots_upload = true;
            public const string screenshots_fullKeys = "Alt+F12";
            public const string screenshots_areaKeys = "Alt+1";
            public static readonly string videos_path = Path.Combine(Util.StartupPath, @"media\videos");
            public const string videos_fullKeys = "Shift+F12";
            public const string videos_areaKeys = "Shift+F1";
        }
    }
}
