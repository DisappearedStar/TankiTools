using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using AForge.Video.FFMPEG;
using AForge.Video;

namespace TankiTools
{
    public static class VideoRecorder1
    {
        public static bool _isRecording;
        private static VideoFileWriter _writer;
        private static int _width;
        private static int _height;
        private static ScreenCaptureStream _streamVideo;
        private static Rectangle _screenArea;
        static int screenLeft, screenTop = 0;
        static bool useArea = false;
        static VideoCodec codec = VideoCodec.MPEG4;
        static int bitrate = 4000000;
        static private int fps = 9;

        static DateTime now = new DateTime();
        static string name = "";
        static string path = "";

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
       
        [DllImport("user32.dll")]
        static extern bool GetCursorInfo(out CURSORINFO pci);
        
        [DllImport("user32.dll")]
        static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

        const Int32 CURSOR_SHOWING = 0x00000001;

        static VideoRecorder1()
        {
            _isRecording = false;
            _width = SystemInformation.VirtualScreen.Width;
            _height = SystemInformation.VirtualScreen.Height;
            _screenArea = Rectangle.Empty;
            _writer = new VideoFileWriter();
        }

        public static void StartRec(CaptureTypes type)
        {
            if (_isRecording == false)
            {
                SetScreenArea(type);
                _isRecording = true;
                now = DateTime.Now;
                name = $"{now.ToString().Replace(" ", "_").Replace(".", "_").Replace(":", "_") }.avi";
                path = Path.Combine(SettingsManager.videos_path, name);

                _writer.Open(path, _width, _height, fps, codec, bitrate);
                _streamVideo = new ScreenCaptureStream(_screenArea);
                _streamVideo.NewFrame += new NewFrameEventHandler(video_NewFrame);
                _streamVideo.Start();
            }
        }

        private static void SetScreenArea(CaptureTypes type)
        {
            screenLeft = screenTop = 0;
            useArea = false;
            
            if (type == CaptureTypes.VideoArea)
            {
                using (SelectableVideoArea f = new SelectableVideoArea())
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        _screenArea = f.AreaBounds;

                        decimal prop = (decimal)4 / 3;
                        decimal realProp = (decimal)f.w / f.h + 1;
                        bool makeLonger = realProp < prop;
                        int w = Convert.ToInt32(makeLonger ? f.h * prop : f.w);
                        int h = Convert.ToInt32(makeLonger ? f.h : f.w / prop);

                        if ((w & 1) != 0)
                            w = w + 1;
                        if ((h & 1) != 0)
                            h = h + 1;

                        _width = w;
                        _height = h;
                        screenLeft = f.AreaBounds.Left;
                        screenTop = f.AreaBounds.Top;
                        useArea = true;
                    }
                }
            }
            if (type == CaptureTypes.VideoFull)
            {
                _screenArea = Screen.PrimaryScreen.Bounds;
                _width = _screenArea.Width;
                _height = _screenArea.Height;
            }
        }

        private static void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (_isRecording)
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

                _writer.WriteVideoFrame(frame);
            }
            else
            {
                _streamVideo.SignalToStop();
                Thread.Sleep(500);
                _writer.Close();
                Save();
            }
        }

        private static void Save()
        {
            MediaHistoryManager.SaveEntryToHistory(new MediaHistoryManager.HistoryEntry(
                MediaHistoryManager.MediaType.Video, string.Empty, name, now));
        }
    }
}
