using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace TankiTools
{
    public partial class MediaHistory : Form
    {
        string screenshotsPath = @"D:\Projects\TankiTools\TankiTools\bin\Debug\media\screenshots";
        string videosPath = @"D:\Projects\TankiTools\TankiTools\bin\Debug\media\videos";
        public MediaHistory()
        {
            InitializeComponent();

            TableLayoutPanel Wrapper = new TableLayoutPanel();
            Wrapper.AutoScroll = true;
            Wrapper.AutoSize = true;
            Wrapper.Dock = DockStyle.Top;
            Wrapper.Controls.Clear();
            Wrapper.RowCount = 0;
            Wrapper.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            Wrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.Controls.Add(Wrapper);

            XmlDocument xml = new XmlDocument();
            xml.Load(Path.Combine(Application.StartupPath, @"media\history.xml"));
            foreach(XmlNode entry in xml.GetElementsByTagName("entry"))
            {
                AddEntry(Wrapper, entry.Attributes["name"].Value, entry.Attributes["type"].Value, entry.Attributes["link"].Value,
                     entry.Attributes["id"].Value, entry.Attributes["date"].Value, entry.Attributes["time"].Value);
            }


             //AddEntry(Wrapper); AddEntry(Wrapper); AddEntry(Wrapper); AddEntry(Wrapper); AddEntry(Wrapper);
        }
        private void AddEntry(TableLayoutPanel Wrapper, string _name, string _type, string _link, string _id, string _date, string _time)
        {
            Wrapper.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            Panel ElementWrapper = new Panel();
            ElementWrapper.Dock = DockStyle.Fill;
            TableLayoutPanel element = new TableLayoutPanel();
            element.Dock = DockStyle.Fill;
            element.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            element.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            element.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            element.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 45F));
            element.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            element.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            element.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            element.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));

            PictureBox preview = new PictureBox();
            preview.Dock = DockStyle.Fill;
            preview.SizeMode = PictureBoxSizeMode.Zoom;
            if(_type == "screenshot")
            {
                preview.ImageLocation = Path.Combine(screenshotsPath, _name);
            }
            if (_type == "video")
            {
                preview.ImageLocation = $@"http://img.youtube.com/vi/{_id}/default.jpg";
            }

            string filepath = string.Empty;
            if (_type == "screenshot")
            {
                filepath = Path.Combine(screenshotsPath, _name);
            }
            if (_type == "video")
            {
                filepath = Path.Combine(videosPath, _name);
            }

            Label name = new Label();
            name.Anchor = AnchorStyles.Left;
            name.AutoSize = true;
            name.Font = new Font(name.Font, FontStyle.Bold);
            name.Text = _name;

            Label datetime = new Label();
            datetime.Anchor = AnchorStyles.Left;
            datetime.AutoSize = true;
            datetime.Text = _date + " " + _time;

            Label copy = new Label();
            copy.Anchor = AnchorStyles.Bottom;
            copy.AutoSize = true;
            copy.Text = "Скопировать";

            Label open = new Label();
            open.Anchor = AnchorStyles.Bottom;
            open.AutoSize = true;
            open.Text = "Открыть";

            LinkLabel copylink = new LinkLabel();
            copylink.Anchor = AnchorStyles.None;
            copylink.AutoSize = true;
            copylink.Text = "ссылку";
            var __copylink = new LinkLabel.Link();
            __copylink.Name = _link;
            copylink.Links.Add(__copylink);
            //MessageBox.Show(copylink.Links[0].Name);
            copylink.Click += CopyLink_click;

            LinkLabel copyfile = new LinkLabel();
            copyfile.Anchor = AnchorStyles.None;
            copyfile.AutoSize = true;
            copyfile.Text = "файл";
            var __copyfile = new LinkLabel.Link();
            __copyfile.Name = filepath;
            copyfile.Links.Add(__copyfile);
            //MessageBox.Show(copyfile.Links[0].Name);
            copyfile.Click += CopyFile_click;

            LinkLabel openlink = new LinkLabel();
            openlink.Anchor = AnchorStyles.None;
            openlink.AutoSize = true;
            openlink.Text = "ссылку";
            var __openlink = new LinkLabel.Link();
            __openlink.Name = _link;
            openlink.Links.Add(__openlink);
            //MessageBox.Show(openlink.Links[0].Name);
            openlink.Click += OpenLink_click;

            LinkLabel openfile = new LinkLabel();
            openfile.Anchor = AnchorStyles.None;
            openfile.AutoSize = true;
            openfile.Text = "файл";
            var __openfile = new LinkLabel.Link();
            __openfile.Name = filepath;
            openfile.Links.Add(__openfile);
            //MessageBox.Show(openfile.Links[0].Name);
            openfile.Click += OpenFile_click;

            element.Controls.Add(preview, 0, 0);
            element.SetRowSpan(preview, 4);
            element.Controls.Add(name, 1, 0);
            element.SetRowSpan(name, 2);
            element.Controls.Add(copy, 2, 0);
            element.SetColumnSpan(copy, 2);
            element.Controls.Add(open, 2, 2);
            element.SetColumnSpan(open, 2);

            element.Controls.Add(datetime, 1, 2);
            element.SetRowSpan(datetime, 2);
            element.Controls.Add(copylink, 2, 1);
            element.Controls.Add(copyfile, 3, 1);
            element.Controls.Add(openlink, 2, 3);
            element.Controls.Add(openfile, 3, 3);
            ElementWrapper.Controls.Add(element);
            Wrapper.Controls.Add(ElementWrapper, 0, Wrapper.RowCount);
        }

        private void CopyLink_click(object sender, EventArgs e)
        {
            string link = (sender as LinkLabel).Links[0].Name;
            Clipboard.SetText(link);
            statusStrip1.Items[0].Text = $"Ссылка {link} скопирована в буфер обмена";
        }
        private void CopyFile_click(object sender, EventArgs e)
        {
            string[] path = new string[1] { (sender as LinkLabel).Links[0].Name };
            DataObject obj = new DataObject();
            obj.SetData(DataFormats.FileDrop, true, path);
            Clipboard.SetDataObject(obj, true);
            statusStrip1.Items[0].Text = $"Файл {Path.GetFileName(path[0])} скопирован в буфер обмена";
        }
        private void OpenLink_click(object sender, EventArgs e)
        {
            string link = (sender as LinkLabel).Links[0].Name;
            statusStrip1.Items[0].Text = $"Открывается ссылка {link}...";
            System.Diagnostics.Process.Start(link);
        }
        private void OpenFile_click(object sender, EventArgs e)
        {
            string path = (sender as LinkLabel).Links[0].Name;
            statusStrip1.Items[0].Text = $"Открывается файл {Path.GetFileName(path)}...";
            System.Diagnostics.Process.Start(path);
        }
    }
}
