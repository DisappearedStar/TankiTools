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
        string screen = "area";
        private VideoFileWriter _writer;
        private int _width;
        private int _height;
        private ScreenCaptureStream _streamVideo;
        private Stopwatch _stopWatch;
        private Rectangle _screenArea;
        int screenLeft, screenTop = 0;
        bool useArea = false;
        VideoCodec codec = VideoCodec.MPEG4;
        int bitrate = 4000000;
        private int fps = 9;

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

        [StructLayout(LayoutKind.Sequential)]
        public struct ICONINFO
        {
            public bool fIcon;
            public Int32 xHotspot;
            public Int32 yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);

        [DllImport("user32.dll")]
        public static extern IntPtr CopyIcon(IntPtr hIcon);

        [DllImport("user32.dll")]
        public static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO piconinfo);

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
            this.Load += new EventHandler(VideoRecorder_Load);
            this._isRecording = false;
            this._width = SystemInformation.VirtualScreen.Width;
            this._height = SystemInformation.VirtualScreen.Height;
            this._stopWatch = new Stopwatch();
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
            Start(false);
        }

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
        }

        private void StartRec(bool selectArea)
        {
            if (_isRecording == false)
            {
                this.SetScreenArea(selectArea);
                this._isRecording = true;
                DateTime now = DateTime.Now;
                string name = $"{now.ToString().Replace(" ", "_").Replace(".", "_").Replace(":", "_") }.avi";
                string fullName = $@"{SettingsManager.videos_path}\{name}";

                _writer.Open(fullName, _width, _height, fps, codec, bitrate);
                this.StartRecord();
            }
        }

        private void SetScreenArea(bool selectArea)
        {
            screenLeft = screenTop = 0;
            useArea = false;

            // get entire desktop area size
            //if (string.Compare(screenName, @"Select ALL", StringComparison.OrdinalIgnoreCase) == 0)
            if(screen == "all")
            {
                foreach (Screen screen in Screen.AllScreens)
                {
                    this._screenArea = Rectangle.Union(_screenArea, screen.Bounds);
                    this._width = _screenArea.Width;
                    this._height = _screenArea.Height;
                }
            }
            //else if (string.Compare(screenName, @"Custom screen area", StringComparison.OrdinalIgnoreCase) == 0)
            else if (screen == "area")
            {
                using (SelectableVideoArea f = new SelectableVideoArea())
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        this.WindowState = FormWindowState.Minimized;
                        this._screenArea = f.AreaBounds;

                        decimal prop = (decimal)4 / 3;
                        decimal realProp = (decimal)f.w / f.h;
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
            else
            {
                this._screenArea = Screen.AllScreens.First(scr => scr.DeviceName.Equals(screen)).Bounds;
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
                pci.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(CURSORINFO));

                if (GetCursorInfo(out pci))
                {
                    if (pci.flags == CURSOR_SHOWING)
                    {
                        int x = pci.ptScreenPos.x - screenLeft;
                        int y = pci.ptScreenPos.y - screenTop;

                        Color c = Color.Yellow;
                        float width = 2;
                        int radius = 30;
                        if ((Control.MouseButtons & MouseButtons.Left) != 0 || (Control.MouseButtons & MouseButtons.Right) != 0)
                        {
                            c = Color.OrangeRed;
                            width = 4;
                            radius = 35;
                        }
                        Pen p = new Pen(c, width);

                        graphics.DrawEllipse(p, x - radius / 2, y - radius / 2, radius, radius);
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
                _stopWatch.Reset();
                Thread.Sleep(500);
                _streamVideo.SignalToStop();
                Thread.Sleep(500);
                _writer.Close();
            }
        }

        private void VideoRecorder_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                _isRecording = false;
            }
        }

        private void StartRecord()
        {
            this._streamVideo = new ScreenCaptureStream(this._screenArea);
            this._streamVideo.NewFrame += new NewFrameEventHandler(this.video_NewFrame);
            this._streamVideo.Start();
            this._stopWatch.Start();
        }

    }
}
