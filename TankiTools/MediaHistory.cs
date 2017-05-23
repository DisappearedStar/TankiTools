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
using System.Web;
using System.Net;
using System.Threading.Tasks;
using AForge.Video.FFMPEG;

namespace TankiTools
{
    public partial class MediaHistory : Form
    {
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
            PanelWrapper.Controls.Add(Wrapper);
            AddEntries(Wrapper, MediaHistoryManager.GetHistoryFromFile());
        }
        private void AddEntries(TableLayoutPanel Wrapper, List<MediaHistoryManager.HistoryEntry> entries)
        {
            if(entries.Count == 0)
            {
                Wrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                Label txt = new Label();
                txt.Anchor = AnchorStyles.None;
                txt.AutoSize = true;
                txt.Font = new Font(txt.Font, FontStyle.Bold);
                txt.Text = "Здесь пока пусто";
                Wrapper.Controls.Add(txt);
                return;
            }
            entries.Reverse();
            foreach(var entry in entries)
            {
                string filepath = "";
                if(entry.type == "screenshot")
                {
                    filepath = File.Exists(Path.Combine(SettingsManager.screenshots_path, entry.name)) ?
                        Path.Combine(SettingsManager.screenshots_path, entry.name) : null;
                }
                if (entry.type == "video")
                {
                    filepath = File.Exists(Path.Combine(SettingsManager.videos_path, entry.name)) ?
                        Path.Combine(SettingsManager.videos_path, entry.name) : null;
                }
                
                PictureBox preview = new PictureBox();
                preview.Dock = DockStyle.Fill;
                preview.SizeMode = PictureBoxSizeMode.Zoom;

                if (entry.type == "screenshot")
                {
                    if(!Util.CheckNullOrEmpty(filepath))
                    {
                        preview.ImageLocation = filepath;
                    }
                    else
                    {
                        try
                        {
                            using (WebClient client = new WebClient())
                            using (var s = new MemoryStream(client.DownloadData(entry.link)))
                            {
                                preview.Image = Image.FromStream(s);
                            }
                        }
                        catch (Exception) { }
                    }
                }
                if (entry.type == "video")
                {
                    if (!Util.CheckNullOrEmpty(filepath))
                    {
                        using (var video = new VideoFileReader())
                        {
                            video.Open(Path.Combine(SettingsManager.videos_path, entry.name));
                            preview.Image = (video.ReadVideoFrame()) as Image;
                            video.Close();
                        }
                    }
                    else
                    {
                        try
                        {
                            using (WebClient client = new WebClient())
                            using (var s = new MemoryStream(client.DownloadData(
                                $@"http://img.youtube.com/vi/{entry.id}/default.jpg")))
                            {
                                preview.Image = Image.FromStream(s);
                            }
                        }
                        catch (Exception) { }
                    }
                }

                Label name = new Label();
                name.Anchor = AnchorStyles.Left;
                name.AutoSize = true;
                name.Font = new Font(name.Font, FontStyle.Bold);
                name.Text = entry.name;

                Label datetime = new Label();
                datetime.Anchor = AnchorStyles.Left;
                datetime.AutoSize = true;
                datetime.Text = $"{entry.date} {entry.time}";

                Label copy = new Label();
                copy.Anchor = AnchorStyles.Bottom;
                copy.AutoSize = true;
                copy.Text = "Скопировать";
                Label open = new Label();
                open.Anchor = AnchorStyles.Bottom;
                open.AutoSize = true;
                open.Text = "Открыть";

                LinkLabel copyfile = new LinkLabel();
                copyfile.Anchor = AnchorStyles.None;
                copyfile.AutoSize = true;
                copyfile.Text = "файл";
                var __copyfile = new LinkLabel.Link();
                __copyfile.Name = filepath;
                copyfile.Links.Add(__copyfile);
                copyfile.Click += CopyFile_click;

                LinkLabel openfile = new LinkLabel();
                openfile.Anchor = AnchorStyles.None;
                openfile.AutoSize = true;
                openfile.Text = "файл";
                var __openfile = new LinkLabel.Link();
                __openfile.Name = filepath;
                openfile.Links.Add(__openfile);
                openfile.Click += OpenFile_click;

                if (Util.CheckNullOrEmpty(filepath))
                {
                    copyfile.Enabled = false;
                    copyfile.ActiveLinkColor = Color.Red;
                    copyfile.LinkColor = Color.Red;
                    copyfile.LinkBehavior = LinkBehavior.NeverUnderline;
                    copyfile.Click -= CopyFile_click;
                    openfile.Enabled = false;
                    openfile.ActiveLinkColor = Color.Red;
                    openfile.LinkColor = Color.Red;
                    openfile.LinkBehavior = LinkBehavior.NeverUnderline;
                    openfile.Click -= OpenFile_click;
                }


                LinkLabel copylink = new LinkLabel();
                copylink.Anchor = AnchorStyles.None;
                copylink.AutoSize = true;
                var __copylink = new LinkLabel.Link();
                __copylink.Name = entry.link;
                copylink.Links.Add(__copylink);
                copylink.Text = "ссылку";
                copylink.Click += CopyLink_click;

                LinkLabel openlink = new LinkLabel();
                openlink.Anchor = AnchorStyles.None;
                openlink.AutoSize = true;
                var __openlink = new LinkLabel.Link();
                __openlink.Name = entry.link;
                openlink.Links.Add(__openlink);
                openlink.Text = "ссылку";
                openlink.Click += OpenLink_click;

                if (Util.CheckNullOrEmpty(entry.link))
                {
                    copylink.Enabled = false;
                    copylink.ActiveLinkColor = Color.Red;
                    copylink.LinkColor = Color.Red;
                    copylink.LinkBehavior = LinkBehavior.NeverUnderline;
                    copylink.Click -= CopyLink_click;
                    openlink.Enabled = false;
                    openlink.ActiveLinkColor = Color.Red;
                    openlink.LinkColor = Color.Red;
                    openlink.LinkBehavior = LinkBehavior.NeverUnderline;
                    openlink.Click -= OpenLink_click;
                }

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

                Panel ElementWrapper = new Panel();
                ElementWrapper.Dock = DockStyle.Fill;
                ElementWrapper.Controls.Add(element);
                Wrapper.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
                Wrapper.Controls.Add(ElementWrapper, 0, Wrapper.RowStyles.Count - 1);
            }
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
