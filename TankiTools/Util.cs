using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankiTools
{
    //public enum MemoryUnit { Bit, Byte, Kbyte, Mbyte, Gbyte }

    static class Util
    {
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
    }
}
/*
string[] units = { " B", " KB", " MB", " GB" };
const ulong x = 1024;
ulong divider = 1024;
if(number < divider)
{
    return number + units[0];
}
else
{
    while(number > x)
    {
        ulong rest = number % x;
        number /= divider;
    }
}
*/
