using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using AForge.Video.FFMPEG;
using AForge.Video;
using System.Diagnostics;
using System.Reflection;
namespace TankiTools
{
    public partial class VideoRecorder : Form
    {
        private bool _isRecording;
        //private List<string> _screenNames;
        //private UInt32 _frameCount;

        /*!!!!*///string screen = @"\\.\DISPLAY1";
        string screen = @"area";
        private VideoFileWriter _writer;
        private int _width;
        private int _height;
        private ScreenCaptureStream _streamVideo;
        private Rectangle _screenArea;
        int screenLeft, screenTop = 0;
        bool useArea = false;
        VideoCodec codec = VideoCodec.MPEG4;
        int bitrate = 4000000;
        private int fps = 9;

        DateTime now = new DateTime();
        string name = "";
        string path = "";

        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public POINTAPI ptScreenPos;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct POINTAPI
        {
            public int x;
            public int y;
        }
        /*
        [StructLayout(LayoutKind.Sequential)]
        public struct ICONINFO
        {
            public bool fIcon;
            public Int32 xHotspot;
            public Int32 yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }*/

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);

        //[DllImport("user32.dll")]
        //public static extern IntPtr CopyIcon(IntPtr hIcon);

        //[DllImport("user32.dll")]
        //public static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO piconinfo);

        [DllImport("user32.dll")]
        static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

        const Int32 CURSOR_SHOWING = 0x00000001;

        void VideoRecorder_Load(object sender, EventArgs e)
        {
            this.Size = new Size(0, 0);
        }

        public VideoRecorder()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.Size = new Size(0, 0);
            //this.Load += new EventHandler(VideoRecorder_Load);
            this._isRecording = false;
            this._width = SystemInformation.VirtualScreen.Width;
            this._height = SystemInformation.VirtualScreen.Height;
            this._screenArea = Rectangle.Empty;

            //this.bt_Save.Enabled = false;
            this._writer = new VideoFileWriter();

            //_screenNames = new List<string>();
            //_screenNames.Add(@"Select ALL");
            //_screenNames.Add(@"Custom screen area");
            /*foreach (var screen in Screen.AllScreens)
            {
                _screenNames.Add(screen.DeviceName);
            }*/
            //StartRec(SettingsManager.CaptureTypes.);
        }
        /*
        private void Start(bool selectArea)
        {
            try
            {
                this.StartRec(selectArea);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }*/

        private void StartRec(CaptureTypes type)
        {
            if (_isRecording == false)
            {
                this.SetScreenArea(type);
                this._isRecording = true;
                now = DateTime.Now;
                name = $"{now.ToString().Replace(" ", "_").Replace(".", "_").Replace(":", "_") }.avi";
                path = Path.Combine(SettingsManager.videos_path, name);

                _writer.Open(path, _width, _height, fps, codec, bitrate);
                this._streamVideo = new ScreenCaptureStream(this._screenArea);
                this._streamVideo.NewFrame += new NewFrameEventHandler(this.video_NewFrame);
                this._streamVideo.Start();
            }
        }

        private void SetScreenArea(CaptureTypes type)
        {
            screenLeft = screenTop = 0;
            useArea = false;

            /*if(type == SettingsManager.CaptureTypes.VideoFull)
            {
                foreach (Screen screen in Screen.AllScreens)
                {
                    this._screenArea = Rectangle.Union(_screenArea, screen.Bounds);
                    this._width = _screenArea.Width;
                    this._height = _screenArea.Height;
                }
            }*/
            if (type == CaptureTypes.VideoArea)
            {
                using (SelectableVideoArea f = new SelectableVideoArea())
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        this.WindowState = FormWindowState.Minimized;
                        this._screenArea = f.AreaBounds;

                        decimal prop = (decimal)4 / 3;
                        decimal realProp = (decimal)f.w / f.h + 1;
                        bool makeLonger = realProp < prop;
                        int w = Convert.ToInt32(makeLonger ? f.h * prop : f.w);
                        int h = Convert.ToInt32(makeLonger ? f.h : f.w / prop);

                        if ((w & 1) != 0)
                            w = w + 1;
                        if ((h & 1) != 0)
                            h = h + 1;

                        this._width = w;
                        this._height = h;
                        screenLeft = f.AreaBounds.Left;
                        screenTop = f.AreaBounds.Top;
                        useArea = true;
                    }
                }
            }
            if (type == CaptureTypes.VideoFull)
            {
                this._screenArea = Screen.PrimaryScreen.Bounds;
                this._width = this._screenArea.Width;
                this._height = this._screenArea.Height;
            }
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (this._isRecording)
            {
                Bitmap frame = eventArgs.Frame;
                Graphics graphics = Graphics.FromImage(frame);
                CURSORINFO pci;
                pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));

                if (GetCursorInfo(out pci))
                {
                    if (pci.flags == CURSOR_SHOWING)
                    {
                        int x = pci.ptScreenPos.x - screenLeft;
                        int y = pci.ptScreenPos.y - screenTop;
                        DrawIcon(graphics.GetHdc(), x, y, pci.hCursor);
                        graphics.ReleaseHdc();
                    }
                }
                if (useArea)
                {
                    var destRect = new Rectangle(Convert.ToInt32((_width - frame.Width) / 2), 
                        Convert.ToInt32((_height - frame.Height) / 2), frame.Width, frame.Height);
                    var destImage = new Bitmap(_width, _height);
                    destImage.SetResolution(frame.HorizontalResolution, frame.VerticalResolution);

                    graphics = Graphics.FromImage(destImage);
                    graphics.DrawImage(frame, destRect, 0, 0, frame.Width, frame.Height, GraphicsUnit.Pixel, null);
                    frame = destImage;
                }

                this._writer.WriteVideoFrame(frame);
            }
            else
            {
                _streamVideo.SignalToStop();
                Thread.Sleep(500);
                _writer.Close();
                Save();
            }
        }

        public void Save()
        {
            MediaHistoryManager.SaveEntryToHistory(new MediaHistoryManager.HistoryEntry(
                MediaHistoryManager.MediaType.Video, string.Empty, name, now));
        }
    }
}
