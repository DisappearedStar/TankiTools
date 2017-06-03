using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Microsoft.Win32;
using NetFwTypeLib;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TankiTools
{

    public static class Network
    {
        private static int[] DefaultPorts = { 4444, 5222, 5223, 14444, 15222, 15223 };

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
            /// сервер недоступен
            /// </summary>
            ServerUnavailable,
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
            public int hop { get; private set; }
            public string ip { get; private set; }
            public string hostname { get; private set; }
            public string country { get; private set; }
            public string city { get; private set; }
            public long time1 { get; private set; }
            public long time2 { get; private set; }
            public long time3 { get; private set; }
            public HostLocation location { get; private set; }
            public TraceStatus status { get; private set; }

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
                        string json = client.DownloadString(new Uri($@"http://api.db-ip.com/v2/{apikey}/{_ip}")); 
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
                return $"{hostname} [{ip}] ({location.ToString()}) | {country}";
            }
            public string ToStringWithPing()
            {
                return $"{hostname} [{ip}] ({location.ToString()}) | {country} | {(float)(time1 + time2 + time3) / 3}ms";
            }
        }

        public static string GetMyIpAddress()
        {
            using (WebClient webClient = new WebClient())
            {
                return webClient.DownloadString(@"https://api.ipify.org");
            }
        }

        public static List<TankiPort> GetPortsStatus()
        {
            const string host = "c1.eu.tankionline.com";
            string ip = HostToIpString(host);

            var ports = new List<TankiPort>();
            foreach(int port in DefaultPorts)
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
                catch (Exception) { }
            }
            return ports;
        }

        public static async Task<TraceStatus> Ping()
        {
            const string host = "c1.eu.tankionline.com";
            string ip = HostToIpString(host);
            Ping ping = new Ping();
            PingOptions pingOptions = new PingOptions(128, true);
            Stopwatch pingReplyTime = new Stopwatch();
            PingReply reply;
            long avg = 0;
            long min = 1000;
            long max = 0;
            int counter = 21;
            int received = 0;
            int timeout = 1000;

            for(int i = 0; i < counter; i++)
            {
                pingReplyTime.Reset();
                pingReplyTime.Start();
                reply = await ping.SendTaskAsync(ip, timeout, new byte[] { 32 }, pingOptions);
                pingReplyTime.Stop();
                if (reply.Status == IPStatus.Success && i > 0)
                {
                    received++;
                    avg += pingReplyTime.ElapsedMilliseconds;
                    if (pingReplyTime.ElapsedMilliseconds < min) { min = pingReplyTime.ElapsedMilliseconds; }
                    if (pingReplyTime.ElapsedMilliseconds > max) { max = pingReplyTime.ElapsedMilliseconds; }
                } 
            }
            
            avg /= received;
            if (received + 1 < counter)
            {
                return TraceStatus.PacketsLoss;
            }
            else if(((float)max / (float)min) > 1.25)
            {
                return TraceStatus.TooBigPingFluctuactions;
            }
            else
            {
                if(avg <= 50)
                {
                    return TraceStatus.LowPing;
                }
                if (avg > 50 && avg <= 100)
                {
                    return TraceStatus.NormalPing;
                }
                if (avg > 100 && avg <= 150)
                {
                    return TraceStatus.HighPing;
                }
                else
                {
                    return TraceStatus.BadPing;
                }
            }
        }

        public static async Task<List<TracertEntry>> Trace()
        {
            const string host = "c1.eu.tankionline.com";
            string ip = HostToIpString(host);
            Ping ping = new Ping();
            PingOptions pingOptions = new PingOptions(1, true);
            Stopwatch pingReplyTime = new Stopwatch();
            PingReply reply;
            List<TracertEntry> trace = new List<TracertEntry>();
            IPStatus status = IPStatus.TimeExceeded;

            do
            {
                List<long> times = new List<long>(3);
                string _ip = string.Empty;
                for (int i = 0; i < 3; i++)
                {
                    pingReplyTime.Reset();
                    pingReplyTime.Start();
                    reply = await ping.SendTaskAsync(ip, 1000, new byte[] { 32 }, pingOptions);
                    pingReplyTime.Stop();

                    if (reply.Status != IPStatus.TimedOut) times.Add(pingReplyTime.ElapsedMilliseconds);
                    else times.Add(-1);

                    try
                    {
                        _ip = reply.Address.ToString();
                    }
                    catch (Exception) { }
                    status = reply.Status;
                }
                trace.Add(new TracertEntry(pingOptions.Ttl, _ip, times[0], times[1], times[2]));
                pingOptions.Ttl++;
            }
            while (status != IPStatus.Success);
            return trace;
        }

        public static bool OpenPorts(List<TankiPort> portsList)
        {
            List<string> ports = portsList.Where(x => x.isOpen == false).Select(x => x.port.ToString()).ToList();
            if(ports.Count == 0)
            {
                return false;
            }
            else
            {
                INetFwMgr mgr = (INetFwMgr)Activator.CreateInstance(
                                    Type.GetTypeFromProgID("HNetCfg.FwMgr", false));
                if (!mgr.LocalPolicy.CurrentProfile.FirewallEnabled) return false;

                INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.
                    CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2", false));

                List<INetFwRule> _rules = new List<INetFwRule>();
                foreach (INetFwRule rule in fwPolicy2.Rules) _rules.Add(rule);

                var Rules = _rules.Where(x =>
                    x.Action == NET_FW_ACTION_.NET_FW_ACTION_BLOCK &&
                    x.Direction == NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT &&
                    x.Enabled == true).ToList();
                if (Rules.Count == 0) return false;


                foreach (INetFwRule rule in Rules)
                {
                    var tList = rule.RemotePorts.Split(',').ToList();
                    var remotePorts = new List<string>();

                    foreach (var item in tList)
                    {
                        if (item.Contains('-'))
                        {
                            var t = item.Split('-').ToList().ConvertAll(x => Convert.ToInt32(x));
                            for (int i = t.First(); i <= t.Last(); i++)
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
                        Util.ExecuteInHidedMode(query);
                    }
                }
                return true;
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
            var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
            if (hklm.OpenSubKey(path, true) == null)
            {
                hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            }
            hklm.OpenSubKey(path, true).SetValue("NetworkThrottlingIndex",
                    ((state) ? unchecked((int)0xFFFFFFFF) : 0xA), RegistryValueKind.DWord);
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
