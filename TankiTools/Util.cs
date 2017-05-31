using System;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace TankiTools
{
    static class Util
    {
        public static string AppData = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
        public static string AppDataRoaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string AppDataLocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string StartupPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static MainWindow Main;
        public const string MaxCacheSize = "1048576";

        public static string BytesToString(long number)
        {
            string[] suf = { " B", " KB", " MB", " GB" };
            if (number == 0)
            {
                return "0" + suf[0];
            }
            long bytes = Math.Abs(number);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(number) * num).ToString() + suf[place];
        }

        public static string BytesToString(string number)
        {
            long x = Convert.ToInt64(number);
            string[] suf = { " B", " KB", " MB", " GB" };
            if (x == 0)
            {
                return "0" + suf[0];
            }
            long bytes = Math.Abs(x);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(x) * num).ToString() + suf[place];
        }

        /// <summary>
        /// Deletes all files and directories by a given path.
        /// </summary>
        /// <param name="path">Full path to target directory.</param>
        public static void EmptyDirectory(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch (Exception) { }
                
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                try
                {
                    dir.Delete(true);
                }
                catch(Exception) { }
            }
        }

        public static bool IsDirectoryEmpty(string path)
        {
            return Directory.EnumerateFileSystemEntries(path).Count() == 0 ? true : false;
        }

        public static bool CheckNullOrEmpty<T>(T value)
        {
            if (typeof(T) == typeof(string))
                return string.IsNullOrEmpty(value as string) || string.IsNullOrWhiteSpace(value as string);
            return value == null || value.Equals(default(T));
        }
        public static void ExecuteInHidedMode(string command)
        {
            using (Process process = new Process())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C " + command;
                process.StartInfo = startInfo;
                process.Start();
            }
        }
    }
}
