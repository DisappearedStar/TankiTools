using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TankiTools
{
    public partial class SelectableVideoArea : Form
    {
        bool inProgress = false;
        Panel p = new Panel();

        public Rectangle AreaBounds
        {
            get
            {
                return p.Bounds;
            }
        }

        public int t, l, w, h = 0;

        public SelectableVideoArea()
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.BackColor = Color.White;
            this.TransparencyKey = Color.Gray;
            this.Opacity = 0.4;
            p.BackColor = Color.Gray;
            p.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Cross;
            this.FormClosing += SelectableVideoArea_FormClosing;
            this.MouseDown += SelectableVideoArea_MouseDown;
            this.MouseUp += SelectableVideoArea_MouseUp;
        }

        private void SelectableVideoArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (inProgress)
            {
                w = p.Width;
                h = p.Height;
                this.MouseMove -= SelectableVideoArea_MouseMove;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void SelectableVideoArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (!inProgress)
            {
                inProgress = true;
                this.Controls.Add(p);
                p.Left = l = e.X;
                p.Top = t = e.Y;
                this.MouseMove += SelectableVideoArea_MouseMove;
            }
        }

        private void SelectableVideoArea_MouseMove(object sender, MouseEventArgs e)
        {
            this.SuspendLayout();
            p.SuspendLayout();
            p.Width = e.X - p.Left;
            p.Height = e.Y - p.Top;
            p.ResumeLayout();
            this.ResumeLayout();

        }

        private void SelectableVideoArea_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
    }
}
