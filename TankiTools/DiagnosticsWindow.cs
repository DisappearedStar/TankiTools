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
    public partial class DiagnosticsWindow : Form
    {
        
        public DiagnosticsWindow()
        {
            InitializeComponent();
            FillSystemInfo();
        }

        private void FillSystemInfo()
        {
            Label_Processor.Text = SystemInfo.Info["CPU"];
            Label_Memory.Text = SystemInfo.Info["RAM"];
            Label_Graphics.Text = SystemInfo.Info["GPU"];
            Label_Driver.Text = SystemInfo.Info["Drivers"];
            Label_OS.Text = SystemInfo.Info["OS"];
            Label_Resolution.Text = SystemInfo.Info["Resolution"];
        }


        private void DiagnosticsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void DiagnosticsWindow_TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = DiagnosticsWindow_TabControl.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = DiagnosticsWindow_TabControl.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.LightGray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Microsoft Sans Serif", (float)12, FontStyle.Regular, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }
    }
}
