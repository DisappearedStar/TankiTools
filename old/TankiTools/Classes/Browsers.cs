using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TankiTools
{
    public enum Clients
    {
        Chrome,
        Firefox,
        Opera,
        Yandex,
        IE,
        Edge,
        SAFP,
        OfficialClient,
        OtherBrowser,
        ThirdPartyClient
    }

    static class Browsers
    {
        static public string GetClientLocalizedName(Clients client)
        {
            switch (client)
            {
                case Clients.Chrome: return L18n.Get("Browsers", "Chrome");
                case Clients.Edge: return L18n.Get("Browsers", "Edge");
                case Clients.Firefox: return L18n.Get("Browsers", "Firefox");
                case Clients.IE: return L18n.Get("Browsers", "IE");
                case Clients.OfficialClient: return L18n.Get("Browsers", "OfficialClient");
                case Clients.Opera: return L18n.Get("Browsers", "Opera");
                case Clients.Yandex: return L18n.Get("Browsers", "Yandex");
                case Clients.SAFP: return L18n.Get("Browsers", "SAFP");
                case Clients.OtherBrowser: return L18n.Get("Browsers", "OtherBrowser");
                case Clients.ThirdPartyClient: return L18n.Get("Browsers", "ThirdPartyClient");
                default: return "";
            }
        }

        static public Clients GetClientByString(string str)
        {
            foreach (Clients client in Enum.GetValues(typeof(Clients)))
            {
                if (client.ToString() == str) return client;
            }
            return GetDefaultBrowser();
        }

        static public List<Clients> GetInstalledBrowsers()
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Clients\StartMenuInternet") ??
                             Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
            
            List<string> browserNames = rk.GetSubKeyNames().Select(x => x.ToLower()).ToList();
            List<Clients> browsers = new List<Clients>();
            foreach (string name in browserNames)
            {
                if (name.Contains("firefox")) browsers.Add(Clients.Firefox);
                if (name.Contains("chrome")) browsers.Add(Clients.Chrome);
                if (name.Contains("iexplore")) browsers.Add(Clients.IE);
                if (name.Contains("operastable")) browsers.Add(Clients.Opera);
                if (name.Contains("yandex")) browsers.Add(Clients.Yandex);
            }
            if(browserNames.Count != browsers.Count) browsers.Add(Clients.OtherBrowser);
            string productName = (string)Registry.LocalMachine.OpenSubKey(
                @"SOFTWARE\Microsoft\Windows NT\CurrentVersion").GetValue("ProductName");
            if (productName.StartsWith("Windows 10")) browsers.Add(Clients.Edge);
            return browsers;
        }

        static public Clients GetDefaultBrowser()
        {
            const string defaultBrowser = @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice";
            string progId;
            using (RegistryKey userChoiceKey = Registry.CurrentUser.OpenSubKey(defaultBrowser))
            {
                progId = userChoiceKey.GetValue("Progid").ToString();
                if (progId.Contains("YandexHTML")) return Clients.Yandex;
                switch (progId)
                {
                    case "IE.HTTP":
                        return Clients.IE;
                    case "FirefoxURL":
                        return Clients.Firefox;
                    case "ChromeHTML":
                        return Clients.Chrome;
                    case "OperaStable":
                        return Clients.Opera;
                    case "AppXq0fevzme2pys62n3e0fbqa7peapykr8v":
                        return Clients.Edge;
                    default:
                        return Clients.OtherBrowser;
                }
            }
        }


        /// <summary>
        /// Returns full paths to Shared Objects directories related to Tanki Online found by given path.
        /// </summary>
        /// <param name="path">Full path to target directory.</param>
        /// <returns>Full paths to Shared Objects directories.</returns>
        static public string[] GetSharedObjectsDirs(string path)
        {
            List<string> t = new List<string>();
            string[] dirs = Directory.GetDirectories(path);
            foreach (string so in dirs)
            {
                foreach (string site in Directory.GetDirectories(so, "*tankionline.com"))
                {
                    t.Add(site);
                }
            }
            return t.ToArray();
        }

        /// <summary>
        /// Erases Flash Player temporary store.
        /// </summary>
        /// <param name="client">Tanki Online client-side application.</param>
        static public void ClearSharedObjects(Clients client)
        {
            if (client == Clients.Chrome)
            {
                string path = Path.Combine(Util.AppDataLocal, @"Google\Chrome\User Data");
                string so_dir = @"Pepper Data\Shockwave Flash\WritableRoot\#SharedObjects";
                List<string> shareds = new List<string>();
                shareds.Add(Path.Combine(path, "Default", so_dir));
                foreach (string profile in Directory.GetDirectories(path, "Profile *"))
                {
                    shareds.Add(Path.Combine(profile, so_dir));
                }
                foreach (string dir in shareds)
                {
                    foreach (string site in GetSharedObjectsDirs(dir))
                    {
                        Directory.Delete(site, true);
                    }
                }
            }
            if (client == Clients.Yandex)
            {
                string path = Path.Combine(Util.AppDataLocal, @"Yandex\YandexBrowser\User Data");
                string so_dir = @"Pepper Data\Shockwave Flash\WritableRoot\#SharedObjects";
                List<string> shareds = new List<string>();
                shareds.Add(Path.Combine(path, "Default", so_dir));
                foreach (string profile in Directory.GetDirectories(path, "Profile *"))
                {
                    shareds.Add(Path.Combine(profile, so_dir));
                }
                foreach (string dir in shareds)
                {
                    foreach (string site in GetSharedObjectsDirs(dir))
                    {
                        Directory.Delete(site, true);
                    }
                }
            }
            if (client == Clients.Opera)
            {
                string path = Path.Combine(Util.AppDataRoaming,
                        @"Opera Software\Opera Stable\Pepper Data\Shockwave Flash\WritableRoot\#SharedObjects");
                foreach (string site in GetSharedObjectsDirs(path))
                {
                    Directory.Delete(site, true);
                }
            }
            if (client == Clients.OfficialClient)
            {
                string path = Path.Combine(Util.AppDataRoaming, @"TankiOnline\Local Store\#SharedObjects");
                Util.EmptyDirectory(path);
            }

            else
            {
                string path = Path.Combine(Util.AppDataRoaming, @"Macromedia\Flash Player\#SharedObjects");
                foreach (string site in GetSharedObjectsDirs(path))
                {
                    Directory.Delete(site, true);
                }
            }
        }

        /// <summary>
        /// Erases client's temporary store.
        /// </summary>
        /// <param name="client">Tanki Online client-side application.</param>
        static public void ClearCache(Clients client)
        {
            if (client == Clients.OfficialClient)
            {
                string path = Path.Combine(Util.AppDataRoaming, @"TankiOnline\Local Store\cache");
                Util.EmptyDirectory(path);
            }

            if (client == Clients.Edge)
            {
                string edge = Directory.GetDirectories(Path.Combine(Util.AppDataLocal, "Packages"), "Microsoft.MicrosoftEdge_*")[0];
                string path = Path.Combine(edge, @"AC\#!001\MicrosoftEdge\Cache\");
                Util.EmptyDirectory(path);
            }

            if (client == Clients.Firefox)
            {
                string path = Path.Combine(Util.AppDataLocal, @"Mozilla\Firefox\Profiles");
                var profiles = Directory.GetDirectories(path);
                foreach(string profile in profiles)
                {
                    Util.EmptyDirectory(Path.Combine(profile, @"\cache2\entries\"));
                }
            }

            if (client == Clients.Opera)
            {
                string[] caches = new string[] 
                {
                    Path.Combine(Util.AppDataRoaming, @"Opera Software\Opera Stable\GPUCache"),
                    Path.Combine(Util.AppDataRoaming, @"Opera Software\Opera Stable\ShaderCache\GPUCache"),
                    Path.Combine(Util.AppDataLocal, @"Opera Software\Opera Stable\Opera Stable\Cache"),
                    Path.Combine(Util.AppDataLocal, @"Opera Software\Opera Stable\Cache")
                };
                foreach (string path in caches)
                {
                    Util.EmptyDirectory(path);
                }
            }

            if (client == Clients.Chrome)
            {
                string data = Path.Combine(Util.AppDataLocal, @"Google\Chrome\User Data");
                List<string> caches = new List<string>();

                caches.Add(Path.Combine(data, @"ShaderCache\GPUCache"));
                caches.Add(Path.Combine(data, @"Default\Cache"));
                caches.Add(Path.Combine(data, @"Default\GPUCache"));
                foreach (string profile in Directory.GetDirectories(data, "Profile *"))
                {
                    caches.Add(Path.Combine(profile, @"GPUCache"));
                    caches.Add(Path.Combine(profile, @"Cache"));
                }
                foreach (string path in caches)
                {
                    Util.EmptyDirectory(path);
                }
            }

            if (client == Clients.Yandex)
            {
                string data = Path.Combine(Util.AppDataLocal, @"Yandex\YandexBrowser\User Data");
                List<string> caches = new List<string>();

                caches.Add(Path.Combine(data, @"ShaderCache\GPUCache"));
                caches.Add(Path.Combine(data, @"Default\Cache"));
                caches.Add(Path.Combine(data, @"Default\GPUCache"));
                foreach (string profile in Directory.GetDirectories(data, "Profile *"))
                {
                    caches.Add(Path.Combine(profile, @"GPUCache"));
                    caches.Add(Path.Combine(profile, @"Cache"));
                }
                foreach (string path in caches)
                {
                    Util.EmptyDirectory(path);
                }
            }

            else
            {
                string path = (string)Registry.CurrentUser.OpenSubKey
                    (@"Software\Microsoft\Windows\CurrentVersion\Explorer\User Shell Folders").GetValue("Cache");
                Util.EmptyDirectory(path);
            }
        }

        /// <summary>
        /// Increases the size of client's temporary store.
        /// </summary>
        /// <param name="client">Tanki Online client-side application.</param>
        static public void IncreaseCacheSize(Clients client)
        {
            if (client == Clients.IE)
            {
                string regpath = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings\5.0\Cache\Content";
                try
                {
                    string value = Convert.ToString(Registry.GetValue(regpath, "CacheLimit", 0));
                    if (value == Util.MaxCacheSize)
                    {
                        MessageBox.Show("Кэш и так макс. размера");
                        return;
                    }
                    Registry.SetValue(regpath, "CacheLimit", Util.MaxCacheSize, RegistryValueKind.DWord);
                }
                catch (Exception) { }
            }

            if (client == Clients.Firefox)
            {
                string path = Path.Combine(Util.AppDataRoaming, @"Mozilla\Firefox\Profiles");
                var profiles = Directory.GetDirectories(path);
                foreach (string profile in profiles)
                {
                    string pathToPrefs = Path.Combine(profile, @"prefs.js");
                    string option = "\"browser.cache.disk.capacity\", ";
                    string str = string.Empty;
                    try
                    {
                        StreamReader sr = new StreamReader(pathToPrefs);
                        while (!sr.EndOfStream)
                        {
                            str += sr.ReadLine() + "\n";
                        }
                        sr.Close();
                    }
                    catch (Exception) {  }

                    int index = str.IndexOf(option) + option.Length;
                    int index1 = index;
                    string oldValue = string.Empty;
                    string newValue = Util.MaxCacheSize;

                    while (true)
                    {
                        if (str[index1].Equals(')') == true)
                        {
                            break;
                        }
                        else
                        {
                            oldValue += str[index1];
                            index1++;
                        }
                    }
                    if (oldValue == newValue)
                    {
                        MessageBox.Show("Кэш и так макс. размера");
                        return;
                    }

                    string oldLine = option + oldValue;
                    string newLine = option + newValue;
                    string str1 = str.Replace(oldLine, newLine);

                    try
                    {
                        FileStream file = new FileStream(pathToPrefs, FileMode.Truncate);
                        file.Close();
                        StreamWriter sw = new StreamWriter(pathToPrefs);
                        sw.Flush();
                        sw.Write(str1);
                        sw.Close();
                    }
                    catch (Exception) { }
                }
            }
        }
    }
}
