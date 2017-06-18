using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace TankiTools
{
    static class MediaHistoryManager
    {
        public static readonly string HistoryFile = Path.Combine(Util.StartupPath, "history.xml");

        static MediaHistoryManager()
        {
            if (!File.Exists(HistoryFile))
            {
                File.Create(HistoryFile).Close();
            }
            if (!Directory.Exists(SettingsManager.screenshots_path))
            {
                Directory.CreateDirectory(SettingsManager.screenshots_path);
            }
            if (!Directory.Exists(SettingsManager.videos_path))
            {
                Directory.CreateDirectory(SettingsManager.videos_path);
            }
        }

        public static List<HistoryEntry> GetHistoryFromFile()
        {
            List<HistoryEntry> entries = new List<HistoryEntry>();
            XDocument history;
            try
            {
                using (FileStream stream = new FileStream(HistoryFile, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    history = XDocument.Load(stream);
                }
            }
            catch (Exception)
            {
                return entries;
            }
            XElement root = history.Root;
            foreach (XElement entry in root.Elements())
            {
                string _name, _type, _link, _id, _date, _time;
                try
                {
                    _name = entry.Attribute("name").Value;
                }
                catch (Exception)
                {
                    _name = string.Empty;
                }
                try
                {
                    _type = entry.Attribute("type").Value;
                }
                catch (Exception)
                {
                    _type = string.Empty;
                }
                try
                {
                    _link = entry.Attribute("link").Value;
                }
                catch (Exception)
                {
                    _link = string.Empty;
                }
                try
                {
                    _id = entry.Attribute("id").Value;
                }
                catch (Exception)
                {
                    _id = string.Empty;
                }
                try
                {
                    _date = entry.Attribute("date").Value;
                }
                catch (Exception)
                {
                    _date = string.Empty;
                }
                try
                {
                    _time = entry.Attribute("time").Value;
                }
                catch (Exception)
                {
                    _time = string.Empty;
                }
                entries.Add(new HistoryEntry(_name, _type, _link, _id, _date, _time));
            }
            return entries;
        }

        public static void SaveEntryToHistory(HistoryEntry entry)
        {
            XElement _entry = new XElement("entry",
                 new XAttribute("name", entry.name),
                 new XAttribute("type", entry.type),
                 new XAttribute("link", entry.link),
                 new XAttribute("id", entry.id),
                 new XAttribute("date", entry.date),
                 new XAttribute("time", entry.time)
            );
            
            try
            {
                using (FileStream s = File.Open(HistoryFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                {
                    XDocument doc = XDocument.Load(s);
                    doc.Root.Add(_entry);
                    s.Seek(0, SeekOrigin.Begin);
                    doc.Save(s);
                }
            }
            catch(Exception)
            {
                XDocument _history = new XDocument(new XElement("mediahistory", _entry));
                using (StreamWriter w = new StreamWriter(HistoryFile, false))
                {
                    _history.Save(w);
                }
            }
        }

        public static void AddLinkToEntry(string _name, string _link, MediaType _type)
        {
            string _id = GetIdFromLink(_link, _type);
            try
            {
                using (FileStream s = File.Open(HistoryFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(s);
                    doc.SelectSingleNode($@"/mediahistory/entry[@name='{_name}']").Attributes["link"].Value = _link;
                    doc.SelectSingleNode($@"/mediahistory/entry[@name='{_name}']").Attributes["id"].Value = _id;
                    s.Seek(0, SeekOrigin.Begin);
                    doc.Save(s);
                }
            }
            catch (Exception) { }
        }

        private static string GetIdFromLink(string _link, MediaType _type)
        {
            if (_type == MediaType.Screenshot)
            {
                return _link.Split('/').Last().Split('.').First();
            }
            else
            {
                if (_link.Contains("youtu.be"))
                {
                    return _link.Split('/').Last();
                }
                else
                {
                    return _link.Substring(_link.IndexOf("?v=") + 3, 11);
                }
            }
        }

        public enum MediaType { Screenshot, Video }
        public class HistoryEntry
        {
            public string name { get; private set; }
            public string type { get; private set; }
            public string link { get; private set; }
            public string id { get; private set; }
            public string date { get; private set; }
            public string time { get; private set; }

            public HistoryEntry(MediaType _type, string _link, string _name, DateTime now)
            {
                name = _name;
                type = _type.ToString().ToLower();
                date = now.Date.ToString().Split(' ')[0];
                time = now.TimeOfDay.ToString().Split('.')[0];
                if (!Util.CheckNullOrEmpty(_link))
                {
                    link = _link;
                    if (_type == MediaType.Screenshot)
                    {
                        id = _link.Split('/').Last().Split('.').First();
                    }
                    if (_type == MediaType.Video)
                    {
                        if (_link.Contains("youtu.be"))
                        {
                            id = _link.Split('/').Last();
                        }
                        else
                        {
                            id = _link.Substring(_link.IndexOf("?v=") + 3, 11);
                        }
                    }
                }
                else
                {
                    link = string.Empty;
                    id = string.Empty;
                }
            }

            public HistoryEntry(string _name, string _type, string _link, string _id, string _date, string _time)
            {
                name = _name;
                type = _type;
                link = _link;
                id = _id;
                date = _date;
                time = _time;
            }
        }
    }
}
