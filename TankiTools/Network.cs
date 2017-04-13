﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Microsoft.Win32;
using NetFwTypeLib;

using System.Windows.Forms;

namespace TankiTools
{
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

    public static class Network
    {


        public static string GetIpAddress()
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
            string ip = ResolveHostToIp(host);

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
                else Registry.LocalMachine.OpenSubKey(path + ifs[i], true).DeleteValue("TcpAckFrequency");
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

        //private 


        private static string ResolveHostToIp(string host)
        {
            return Dns.GetHostEntry(host).AddressList[0].ToString();
        }
    }
}
