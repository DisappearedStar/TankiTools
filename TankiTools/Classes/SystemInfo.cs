using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace TankiTools
{
    static class SystemInfo
    {
        public static Dictionary<string, string> Info { get; set; }

        static SystemInfo()
        {
            Info = BuildSystemInfo();
        }

        private static Dictionary<string, string> BuildSystemInfo()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.Add("CPU", GetCpuInfo()["Name"] + " " + GetCpuInfo()["Freq"]);
            dict.Add("RAM", Util.BytesToString(GetMemoryInfo()));
            dict.Add("OS", GetOsInfo()["Version"] + " " + GetOsInfo()["Bits"]);
            dict.Add("Resolution", GetResolutionInfo()["Width"] + "x" + GetResolutionInfo()["Height"]);

            string gpu = string.Empty;
            string drv = string.Empty;
            var list = GetGpuInfo();
            if (list.Count == 1)
            {
                gpu = list[0]["Model"] + " " + Util.BytesToString(list[0]["Memory"]);
                drv = list[0]["DriverVersion"];
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var t = list[i];
                    gpu += L18n.Get("SystemInfo", "Text_adapter") + i + ": " + t["Model"] + " " + Util.BytesToString(t["Memory"]) + "\n";
                    drv += L18n.Get("SystemInfo", "Text_adapter") + i + ": " + t["DriverVersion"] + "\n";
                }
            }
            dict.Add("GPU", gpu);
            dict.Add("Drivers", drv);
            return dict;
        }



        private static Dictionary<string, string> GetCpuInfo()
        {
            string[] props = { "Name", "MaxClockSpeed" };
            var info = GetObjectProps("Win32_Processor", props).Get().Cast<ManagementObject>().FirstOrDefault();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Name", info.Properties["Name"].Value.ToString());
            dict.Add("Freq", info.Properties["MaxClockSpeed"].Value.ToString());
            return dict;
        }

        private static long GetMemoryInfo()
        {
            string[] props = { "Capacity" };
            var info = GetObjectProps("Win32_PhysicalMemory", props).Get();
            long capacity = 0;
            foreach (ManagementObject obj in info)
            {
                capacity += Convert.ToInt64(obj.Properties["Capacity"].Value);
            }
            return capacity;
        }

        private static List<Dictionary<string, string>> GetGpuInfo()
        {
            List<Dictionary<string, string>> dictWrapper = new List<Dictionary<string, string>>();
            string[] props = { "Caption", "AdapterRAM", "DriverVersion" };
            var info = GetObjectProps("Win32_VideoController", props).Get();
            foreach (ManagementObject obj in info)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("Model", obj["Caption"].ToString());
                dict.Add("Memory", obj["AdapterRAM"].ToString());
                dict.Add("DriverVersion", obj["DriverVersion"].ToString());
                dictWrapper.Add(dict);
            }
            return dictWrapper;
        }

        private static Dictionary<string, string> GetOsInfo()
        {
            string[] props = { "Caption" };
            var info = GetObjectProps("Win32_OperatingSystem", props).Get().Cast<ManagementObject>().FirstOrDefault();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Version", info.Properties["Caption"].Value.ToString());
            dict.Add("Bits", Environment.Is64BitOperatingSystem ? "x64" : "x32");
            return dict;
        }

        private static Dictionary<string, string> GetResolutionInfo()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Width", Screen.PrimaryScreen.Bounds.Width.ToString());
            dict.Add("Height", Screen.PrimaryScreen.Bounds.Height.ToString());
            return dict;
        }


        private static ManagementObjectSearcher GetObjectProps(string obj, string[] props)
        {
            string query = "select ";
            for(int i = 0; i < props.Length; i++)
            {
                query += props[i] + ", ";
            }
            query = query.Remove(query.Length - 2, 2);
            query += " from " + obj;
            return new ManagementObjectSearcher(query);
        }
    }
}
