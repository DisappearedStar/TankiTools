using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

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

    class Network
    {


        private string GetIpAddress()
        {
            using (WebClient webClient = new WebClient())
            {
                return webClient.DownloadString("https://api.ipify.org");
            }
        }

        private List<TankiPort> GetPortsStatus(int[] portsArray)
        {
            var ports = new List<TankiPort>();
            for(int i = 0; i < portsArray.Length; i++)
            {
                ports.Add(new TankiPort(portsArray[i]));
            }
            string ip = ResolveHostToIp("http://c1.eu.tankionline.com/");

            using (TcpClient tcpClient = new TcpClient())
            {
                for(int i = 0; i < ports.Count; i++)
                {
                    try
                    {
                        tcpClient.Connect(ip, ports[i].port);
                        ports[i].isOpen = true;
                    }
                    catch (Exception) { }
                }
            }
            return ports;
        }


        private string ResolveHostToIp(string host)
        {
            return Dns.GetHostEntry(host).AddressList[0].ToString();
        }
    }
}
