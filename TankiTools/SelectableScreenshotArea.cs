﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TankiTools
{
    public partial class SelectableScreenshotArea : Form
    {
        Point p0;
        Point p1;
        Bitmap original = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        public Pen selectPen = new Pen(Color.GreenYellow, 1);
        
        bool start = false;

        public SelectableScreenshotArea()
        {
            InitializeComponent();
            this.Hide();

            selectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            
            using (Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            using (Graphics g = Graphics.FromImage(bmp as Image))
            using (Brush brush = new SolidBrush(Color.FromArgb(200, Color.Black)))
            using (MemoryStream s = new MemoryStream())
            {
                g.CopyFromScreen(0, 0, 0, 0, bmp.Size);
                g.FillRectangle(brush, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(s, ImageFormat.Bmp);
                SplashScreen.Size = new Size(this.Width, this.Height);
                SplashScreen.Image = Image.FromStream(s);
            }
            Graphics orig = Graphics.FromImage(original as Image);
            orig.CopyFromScreen(0, 0, 0, 0, original.Size);
            Cursor = Cursors.Cross;
            this.Show();
        }

        private void SelectableScreenshotArea_Load(object sender, EventArgs e)
        {
            //Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            //Location = new Point(Screen.PrimaryScreen.Bounds.Left, Screen.PrimaryScreen.Bounds.Top);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (SplashScreen.Image == null) return;
            if (start)
            {
                SplashScreen.Refresh();
                SplashScreen.CreateGraphics().DrawRectangle(selectPen, RectByTwoPoints(p0, e.Location));
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!start)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p0 = e.Location;
                    //MessageBox.Show($"{e.X} {e.Y}");
                }
                SplashScreen.Refresh();
                start = true;
            }
            else
            {
                if (SplashScreen.Image == null) return;
                if (e.Button == MouseButtons.Left)
                {
                    SplashScreen.Refresh();
                    p1 = e.Location;
                    SplashScreen.CreateGraphics().DrawRectangle(selectPen, RectByTwoPoints(p0, e.Location));
                }
                start = false;
                Save();
            }
        }
        private void Save()
        {
            Rectangle rect = RectByTwoPoints(p0, p1);
            Bitmap OriginalImage = original;
            Bitmap _img = new Bitmap(rect.Width, rect.Height);
            Graphics g = Graphics.FromImage(_img);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);
            Clipboard.SetImage(_img);
            this.Close();
        }

        private void SplashScreen_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && start == true && p0 != e.Location && SplashScreen.Image != null)
            {
                SplashScreen.Refresh();
                p1 = e.Location;
                SplashScreen.CreateGraphics().DrawRectangle(selectPen, RectByTwoPoints(p0, e.Location));
                start = false;
                Save();
            }
        }

        /// <summary>
        /// Creates a Rectangle by 2 given Points.
        /// </summary>
        /// <param name="p0">First point</param>
        /// <param name="p1">Second point</param>
        /// <returns>Rectangle object</returns>
        private Rectangle RectByTwoPoints(Point p0, Point p1)
        {
            int width = Math.Abs(p0.X - p1.X) != 0 ? Math.Abs(p0.X - p1.X) : 1;
            int height = Math.Abs(p0.Y - p1.Y) != 0 ? Math.Abs(p0.Y - p1.Y) : 1;
            int rootX = p0.X >= p1.X ? p1.X : p0.X;
            int rootY = p0.Y >= p1.Y ? p1.Y : p0.Y;
            return new Rectangle(rootX, rootY, width, height);
        }
    }
}