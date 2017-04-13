using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

namespace TankiTools
{
    static class Screenshot
    {
        public static string UploadToImgurAnonymously(string path)
        {
            using (var w = new WebClient())
            {
                var values = new System.Collections.Specialized.NameValueCollection
                {
                    {"image", Convert.ToBase64String(File.ReadAllBytes(path))},
                    {"type", "base64"}
                };
                ///TODO: Make async upload
                w.Headers.Add("Authorization", "Client-ID 821902a6107ddf6");
                var response = Encoding.Default.GetString(w.UploadValues(@"https://api.imgur.com/3/image.xml", values));
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(response);
                return xml.GetElementsByTagName("link")[0].InnerText;
            }
        }
    }
}
