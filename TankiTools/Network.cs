using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Microsoft.Win32;
using NetFwTypeLib;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace TankiTools
{

    public static class Network
    {
        public class TankiServer
        {
            public int nodeNumber { get; private set; }
            public string nodeName { get; private set; }
            public int online { get; private set; }
            public int inbattles { get; private set; }
            public int inlobby { get; private set; }

            public TankiServer(int _nodeNumber, int _online, int _inbattles)
            {
                online = _online;
                inbattles = _inbattles;
                inlobby = _online - _inbattles;
                nodeNumber = _nodeNumber;
                if (_nodeNumber > 0 && _nodeNumber < 57)
                {
                    nodeName = "RU " + _nodeNumber.ToString();
                }
                if (nodeNumber >= 57 && nodeNumber < 77)
                {
                    nodeName = "EN " + (_nodeNumber - 56).ToString();
                }
                if (nodeNumber >= 77 && nodeNumber < 81)
                {
                    nodeName = "DE " + (_nodeNumber - 76).ToString();
                }
                if (nodeNumber >= 81)
                {
                    nodeName = "PL " + (_nodeNumber - 80).ToString();
                }
            }
            public override string ToString()
            {
                return $"c{nodeNumber} | {nodeNumber} online: {online} (in battles: {inbattles}, in lobby: {inlobby})";
            }
        }

        public class TankiPort
        {
            public TankiPort(int p)
            {
                port = p;
                isOpen = false;
            }
            public int port { get; private set; }
            public bool isOpen { get; set; }

        }
        public enum HostLocation
        {
            /// <summary>
            /// локальная сеть
            /// </summary>
            Local,
            /// <summary>
            /// серверы ТО
            /// </summary>
            Destination,
            /// <summary>
            /// промежуточные узлы маршрута
            /// </summary>
            Intermediate,
            /// <summary>
            /// IP не определен (отвал по таймауту)
            /// </summary>
            Unknown
        }
        public enum TraceStatus
        {
            /// <summary>
            /// потеря пакетов
            /// </summary>
            PacketsLoss,
            /// <summary>
            /// слишком большая разница между макс. и мин. пингом
            /// </summary>
            TooBigPingFluctuactions,
            /// <summary>
            /// пинг меньше 50
            /// </summary>
            LowPing,
            /// <summary>
            /// пинг между 50 и 100
            /// </summary>
            NormalPing,
            /// <summary>
            /// пинг между 100 и 150
            /// </summary>
            HighPing,
            /// <summary>
            /// пинг больше 150, но меньше лимита на таймаут
            /// </summary>
            BadPing
        }

        public class TracertEntry
        {
            int hop;
            string ip;
            string hostname;
            string country;
            string city;
            long time1;
            long time2;
            long time3;
            HostLocation location;
            TraceStatus status;

            public TracertEntry(int _hop, string _ip, long _time1, long _time2, long _time3)
            {
                hop = _hop;
                ip = _ip;
                try
                {
                    hostname = Dns.GetHostEntry(_ip).HostName;
                }
                catch (Exception) { hostname = string.Empty; }

                time1 = _time1;
                time2 = _time2;
                time3 = _time3;
                if (_time1 == -1 || _time2 == -1 || _time3 == -1)
                {
                    status = TraceStatus.PacketsLoss;
                }
                else
                {
                    long avg = (_time1 + _time2 + _time3) / 3;
                    if (avg <= 50)
                    {
                        status = TraceStatus.LowPing;
                    }
                    if (avg > 50 && avg <= 100)
                    {
                        status = TraceStatus.NormalPing;
                    }
                    if (avg > 100 && avg <= 150)
                    {
                        status = TraceStatus.HighPing;
                    }
                    if (avg > 150)
                    {
                        status = TraceStatus.BadPing;
                    }
                }
                if (_ip != string.Empty)
                {
                    string[] parts = _ip.Split('.');
                    if (parts[0] == "37" && parts[1] == "48")
                    {
                        location = HostLocation.Destination;
                    }
                    else if (parts[0] == "10" || (parts[0] == "192" && parts[1] == "168") ||
                        (parts[0] == "172" && Convert.ToInt32(parts[1]) >= 16 && Convert.ToInt32(parts[1]) <= 31))
                    {
                        location = HostLocation.Local;
                    }
                    else
                    {
                        location = HostLocation.Intermediate;
                    }
                }
                else
                {
                    location = HostLocation.Unknown;
                }
                if (_ip != string.Empty || location == HostLocation.Local)
                {
                    using (WebClient client = new WebClient())
                    {
                        string apikey = "412b882f5f367fc2edfad0a39a1cb3329040f480";
                        string json = client.DownloadString(new Uri(string.Format(@"http://api.db-ip.com/v2/{0}/{1}", apikey, _ip)));
                        JToken token = JObject.Parse(json);
                        country = (string)token.SelectToken("countryName");
                        city = (string)token.SelectToken("city");
                    }
                }
                else
                {
                    country = string.Empty;
                    city = string.Empty;
                }
            }

            override public string ToString()
            {
                return string.Format("{0} | {1} [{2}] ({3}) in {4} | {5} {6} {7} ({8})",
                    hop, hostname, ip, location.ToString(), country, time1, time2, time3, status.ToString());
            }
        }

        public static IEnumerable<TankiServer> GetTankiServers()
        {
            string json;
            using (WebClient webClient = new WebClient())
            {
                json = webClient.DownloadString(@"http://tankionline.com/s/status.js");
            }
            JObject nodes = (JObject)JObject.Parse(json).GetValue("nodes");
            for (int i = 1; i < 100; i++)
            {
                JObject nodeInfo = (JObject)nodes.GetValue("main.c" + i.ToString());
                if (nodeInfo != null)
                {
                    yield return new TankiServer(i, (int)nodeInfo.GetValue("online"), (int)nodeInfo.GetValue("inbattles"));
                }
            }
        }

        public static string GetMyIpAddress()
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    return webClient.DownloadString(@"https://api.ipify.org");
                }
                catch(WebException)
                {
                    return "Невозможно получить IP-адрес. Возможно, отсутствует подключение к Интернету";
                }
            }
        }

        public static List<TankiPort> GetPortsStatus(int[] portsArray)
        {
            const string host = "c1.eu.tankionline.com";
            string ip = HostToIpString(host);

            var ports = new List<TankiPort>();
            foreach(int port in portsArray)
            {
                ports.Add(new TankiPort(port));
            }

            foreach(TankiPort p in ports)
            {
                try
                {
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        tcpClient.Connect(ip, p.port);
                        p.isOpen = true;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            return ports;
        }

        public static void OpenPorts(int[] portsArray)
        {
            try
            {
                INetFwMgr mgr = (INetFwMgr)Activator.CreateInstance(
                    Type.GetTypeFromProgID("HNetCfg.FwMgr", false));
                if (!mgr.LocalPolicy.CurrentProfile.FirewallEnabled) return;
                
                INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.
                    CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2", false));

                List<INetFwRule> _rules = new List<INetFwRule>();
                foreach (INetFwRule rule in fwPolicy2.Rules) _rules.Add(rule);

                var Rules = _rules.Where(x =>
                    x.Action == NET_FW_ACTION_.NET_FW_ACTION_BLOCK &&
                    x.Direction == NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT &&
                    x.Enabled == true).ToList();
                if (Rules.Count == 0) return;
                List<string> ports = portsArray.ToList().ConvertAll(x => x.ToString());

                foreach (INetFwRule rule in Rules)
                {
                    var tList = rule.RemotePorts.Split(',').ToList();
                    var remotePorts = new List<string>();

                    foreach(var item in tList)
                    {
                        if (item.Contains('-'))
                        {
                            var t = item.Split('-').ToList().ConvertAll(x => Convert.ToInt32(x));
                            for(int i = t.First(); i <= t.Last(); i++)
                            {
                                remotePorts.Add(i.ToString());
                            }
                        }
                        else
                        {
                            remotePorts.Add(item);
                        }
                    }

                    var intersection = remotePorts.Intersect(ports).ToList();
                    if (intersection.Count == 0) continue;
                    if (intersection.Count == remotePorts.Count)
                    {
                        rule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                    }
                    else
                    {
                        rule.RemotePorts = String.Join(",", remotePorts.Except(intersection));
                        string query = "netsh advfirewall firewall add rule name=\"OpenTankiPorts\"" +
                            " dir=out action=allow protocol=TCP remoteport=" + string.Join(",", intersection);
                        CmdHelper.ExecuteInHidedMode(query);
                    }
                }     
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        public static void SetTcpAck(bool state)
        {
            const string path = @"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces\";
            string[] ifs = Registry.LocalMachine.OpenSubKey(path).GetSubKeyNames();
            for(int i = 0; i < ifs.Length; i++)
            {
                if (state) Registry.LocalMachine.OpenSubKey(path + ifs[i], true).SetValue("TcpAckFrequency", 1);
                else       Registry.LocalMachine.OpenSubKey(path + ifs[i], true).DeleteValue("TcpAckFrequency");
            }
        }

        public static void SetNetworkThrottling(bool state)
        {
            const string path = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile";
            try
            {
                Registry.LocalMachine.OpenSubKey(path, true).SetValue("NetworkThrottlingIndex",
                    ((state) ? unchecked((int) 0xFFFFFFFF) : 0xA), RegistryValueKind.DWord);
            }
            catch(Exception e) { MessageBox.Show(e.Message); }
        }

        


        public static string HostToIpString(string host)
        {
            return Dns.GetHostEntry(host).AddressList[0].ToString();
        }
        public static byte[] HostToIpBytes(string host)
        {
            return Dns.GetHostEntry(host).AddressList[0].GetAddressBytes();
        }
        public static IPAddress HostToIPAddress(string host)
        {
            return Dns.GetHostEntry(host).AddressList[0];
        }
        public static string IpToHost(string ip)
        {
            return Dns.GetHostEntry(ip).HostName;
        }
        public static string IpToHost(byte[] ip)
        {
            return Dns.GetHostEntry(string.Join(".", ip)).HostName;
        }
        public static string IpToHost(IPAddress ip)
        {
            return Dns.GetHostEntry(ip.ToString()).HostName;
        }
    }
}
