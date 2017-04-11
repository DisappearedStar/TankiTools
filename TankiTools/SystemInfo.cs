using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Windows.Forms;

namespace TankiTools
{


    static class SystemInfo
    {
        public static Dictionary<string, string> GetCpuInfo()
        {
            //List<Dictionary<string, string>> infoWrapper = new List<Dictionary<string, string>>();
            var info = GetObject("Win32_Processor").Get().Cast<ManagementObject>().FirstOrDefault();
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.Add("MaxClockSpeed", info["MaxClockSpeed"].ToString());
            dict.Add("Name", info["Name"].ToString());
            dict.Add("Manufacturer", info["Manufacturer"].ToString());
            dict.Add("Version", info["Version"].ToString());
            return dict;
        }

        public static ulong GetMemoryInfo()
        {
            var info = GetObject("Win32_PhysicalMemory").Get();
            ulong capacity = 0;
            foreach (ManagementObject obj in info)
            {
                capacity += Convert.ToUInt64(obj.Properties["Capacity"].Value);
            }
            return capacity;
        }

        public static List<Dictionary<string, string>> GetGpuInfo()
        {
            List<Dictionary<string, string>> dictWrapper = new List<Dictionary<string, string>>();
            var info = GetObject("Win32_VideoController").Get();
            foreach (ManagementObject obj in info)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("Name", obj["Name"].ToString());
                dict.Add("Caption", obj["Caption"].ToString());
                dict.Add("Memory", obj["AdapterRAM"].ToString());
                dict.Add("DriverVersion", obj["DriverVersion"].ToString());
                dict.Add("InstalledDisplayDrivers", obj["InstalledDisplayDrivers"].ToString());
                dictWrapper.Add(dict);
            }
            return dictWrapper;
        }

        public static Dictionary<string, string> GetOsInfo()
        {
            var info = GetObject("Win32_OperatingSystem").Get().Cast<ManagementObject>().FirstOrDefault();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Version", info.Properties["Caption"].Value.ToString());
            dict.Add("Bits", Environment.Is64BitOperatingSystem ? "x64" : "x32");
            return dict;
        }

        public static Dictionary<string, string> GetScreenResolution()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Width", Screen.PrimaryScreen.Bounds.Width.ToString());
            dict.Add("Height", Screen.PrimaryScreen.Bounds.Height.ToString());
            return dict;
        }



        private static ManagementObjectSearcher GetObject(string key)
        {
            return new ManagementObjectSearcher("select * from " + key);
        }
    }
}
