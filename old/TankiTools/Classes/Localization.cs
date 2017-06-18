using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace TankiTools
{
    static class L18n
    {
        private static XDocument Localization;
        private static string lang;
        static L18n()
        {
            Localization = XDocument.Parse(Properties.Resources.L18n);
            lang = SettingsManager.lang;
        }
        public static string Get(string parentName, string nodeName)
        {
            return Localization.Root.Element(parentName).Element(nodeName).Attribute(lang).Value;
        }
    }
}
