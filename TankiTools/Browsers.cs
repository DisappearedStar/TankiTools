using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TankiTools
{
    public enum Clients
    {
        Chrome,//shared + cache + increase -
        Firefox,//shared + cache + increase -
        Opera,//shared + cache + increase -
        OperaOld,//shared - cache - increase -
        Yandex,//shared - cache - increase -
        IE,//shared - cache - increase -
        Edge,//shared - cache - increase -
        SAFP,//shared - cache - increase -
        OfficialClient,//shared + cache +
        OtherBrowser,
        ThirdPartyClient
    }

    class Browsers
    {
        public void ClearSharedObjects(Clients client)
        {
            string path;
            switch (client)
            {
                case Clients.Chrome:
                    path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                        @"Google\Chrome\User Data\Default\Pepper Data\Shockwave Flash\WritableRoot\#SharedObjects");
                    path = Directory.GetDirectories(path, "????????")[0];
                    foreach(string dir in Directory.GetDirectories(path, "*.tankionline.com"))
                    {
                        Directory.Delete(dir, true);
                    }
                    break;

                case Clients.Opera:
                    path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        @"Opera Software\Opera Stable\Pepper Data\Shockwave Flash\WritableRoot\#SharedObjects");
                    path = Directory.GetDirectories(path, "????????")[0];
                    foreach (string dir in Directory.GetDirectories(path, "*.tankionline.com"))
                    {
                        Directory.Delete(dir, true);
                    }
                    break;

                case Clients.OfficialClient:
                    path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        @"TankiOnline\Local Store\#SharedObjects");
                    Util.EmptyDirectory(path);
                    break;

                default:
                    path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
                        @"Macromedia\Flash Player\#SharedObjects");
                    path = Directory.GetDirectories(path, "????????")[0];
                    foreach (string dir in Directory.GetDirectories(path, "*.tankionline.com"))
                    {
                        Directory.Delete(dir, true);
                    }
                    break;
            }
        }

        public void ClearCache(Clients client)
        {
            if (client == Clients.OfficialClient)
            {
                string path = Path.Combine(Util.AppDataRoaming, @"TankiOnline\Local Store\cache");
                Util.EmptyDirectory(path);
            }

            if (client == Clients.Firefox)
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        @"Mozilla\Firefox\Profiles");
                var profiles = Directory.GetDirectories(path);

                foreach(string profile in profiles)
                {
                     Util.EmptyDirectory(profile);
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
        }
    }
}
