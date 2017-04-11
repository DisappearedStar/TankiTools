using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankiTools
{
    class Diagnostics
    {
        private string BuildCpuInfo()
        {
            var dict = SystemInfo.GetCpuInfo();
            string s =
                dict["Manufacturer"] + " " + 
                dict["Name"] + " " + 
                dict["Version"] + " " + 
                dict["MaxClockSpeed"];
            return s;
        }

        private string BuildMemoryInfo()
        {
            var capacity = Convert.ToUInt64(SystemInfo.GetMemoryInfo()) / (1024 * 1024);
            if(capacity > 1024)
            {
                return capacity / 1024 + " Gb";
            }
            else
            {
                return capacity + " Mb";
            }
        }

        private string BuildGpuInfo()
        {
            string s = string.Empty;
            var list = SystemInfo.GetGpuInfo();
            if(list.Count == 1)
            {
                s = list[0]["Caption"] + " " + list[0]["Memory"];
            }
            else
            {
                for(int i = 0; i < list.Count; i++)
                {
                    Dictionary<string, string> dict in list
                    s += "Видеокарта : " + dict["Caption"] + " " + dict["Memory"] + "\n";
                }
            }
        }
    }
}
