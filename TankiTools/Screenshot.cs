using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading;

namespace TankiTools
{
    static class Screenshot
    {
        //static DiagnosticsWindow diag = new DiagnosticsWindow();
        private static WebClient client;

        public static void CancelUpload()
        {
            if(client != null)
            {
                client.CancelAsync();
                client.Dispose();
            }
        }

        public static async Task<string> UploadScreenshot(Bitmap image)
        {
            byte[] response;
            client = new WebClient();
            client.Headers.Add("Authorization", "Client-ID 821902a6107ddf6");
            Uri api = new Uri(@"https://api.imgur.com/3/image.xml");
            response = await client.UploadDataTaskAsync(api, "POST", ImageToByte(image as Image));
            client.Dispose();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(Encoding.Default.GetString(response));
            return xml.GetElementsByTagName("link")[0].InnerText;
        }

        public static async Task<string> UploadScreenshot(string path)
        {
            byte[] response;
            byte[] image = File.ReadAllBytes(path);
            client = new WebClient();

            client.UploadDataCompleted += (s, e) =>
            {
                if (e.Cancelled)
                {
                    client.Dispose();
                    //throw new OperationCanceledException();
                }
            };

            client.Headers.Add("Authorization", "Client-ID 821902a6107ddf6");
            Uri api = new Uri(@"https://api.imgur.com/3/image.xml");
            response = await client.UploadDataTaskAsync(api, "POST", image);
            client.Dispose();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(Encoding.Default.GetString(response));
            return xml.GetElementsByTagName("link")[0].InnerText;
        }

        private static void Client_UploadDataCompleted(object sender, UploadDataCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static async Task CaptureFullScreen()
        {
            Screen screen = Screen.PrimaryScreen;
            Bitmap bmp = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
            await Save(bmp, "");
        }

        public static async Task Save(Bitmap img, string prefix)
        {
            ImageFormat format;
            ImageCodecInfo encoder;
            EncoderParameters encParams;
            DateTime now = DateTime.Now;
            string name = $"{prefix}{now.ToString().Replace(" ", "_").Replace(".", "_").Replace(":", "_")}.{SettingsManager.screenshots_format}";
            string path = Path.Combine(SettingsManager.screenshots_path, name);
            
            if (SettingsManager.screenshots_format == "jpg" || SettingsManager.screenshots_format == "jpeg")
            {
                format = ImageFormat.Jpeg;
                encoder = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                encParams = new EncoderParameters()
                {
                    Param = new[] { new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L) }
                };
            }
            else
            {
                format = ImageFormat.Png;
                encoder = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Png.Guid);
                encParams = new EncoderParameters()
                {
                    Param = new[] { new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L) }
                };
            }
            string link = string.Empty;
            img.Save(path, encoder, encParams);
            if (SettingsManager.screenshots_upload)
            {
                link = await UploadScreenshot(img);
            }
            MediaHistoryManager.SaveEntryToHistory(new MediaHistoryManager.HistoryEntry(
                MediaHistoryManager.MediaType.Screenshot, link, name, now));
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        public static byte[] ImageToByte(Image img)
        {
            return (byte[])new ImageConverter().ConvertTo(img, typeof(byte[]));
        }
    }
}
