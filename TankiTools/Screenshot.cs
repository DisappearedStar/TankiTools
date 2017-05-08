using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace TankiTools
{
    static class Screenshot
    {
        //public delegate string ImgurUploader(string path);
        static DiagnosticsWindow diag = new DiagnosticsWindow();

        public static void UploadToImgurAnonymously(string path)
        {
            //object[] o = ((object[])vars)[0];
            //string path = ((object[])vars)[0].ToString();
            //string link = ((object[])vars)[1].ToString();
            using (var client = new WebClient())
            {
               /* var values = new System.Collections.Specialized.NameValueCollection
                {
                    {"image", Convert.ToBase64String(File.ReadAllBytes(path))},
                    {"type", "base64"}
                };*/
                client.Headers.Add("Authorization", "Client-ID 821902a6107ddf6");
                //var response = Encoding.Default.GetString(
                client.UploadDataCompleted += ImgurUploadAnonComplete;
                client.UploadDataAsync(new Uri(@"https://api.imgur.com/3/image.xml"), File.ReadAllBytes(path));


                /*
                client.UploadValues(@"https://api.imgur.com/3/image.xml", values));
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(response);
                return xml.GetElementsByTagName("link")[0].InnerText;*/
            }
        }


        public static void ImgurUploadAnonComplete(object sender, UploadDataCompletedEventArgs e)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(Encoding.Default.GetString(e.Result));
            string link = xml.GetElementsByTagName("link")[0].InnerText;
            //MessageBox.Show(xml.GetElementsByTagName("link")[0].InnerText);
            Clipboard.SetText(link);
            diag.TestPutText(link);
        }


        public static void MakeScreenshot()
        {
            using (Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                {
                    g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                     Screen.PrimaryScreen.Bounds.Y,
                                     0, 0,
                                     bmpScreenCapture.Size,
                                     CopyPixelOperation.SourceCopy);
                }
                string path = String.Format(@"{0}\{1}.jpg", Application.StartupPath, DateTime.Now.ToString().Replace(" ", "_").Replace(".", "_").Replace(":", "_"));
                //path = path.Replace(" ", "_");
                //path = path.Replace(".", "_");
                //MessageBox.Show(path);
                bmpScreenCapture.Save(path, ImageFormat.Png);
                //UploadToImgurAnonymously(path);
            }
        }
    }
}
