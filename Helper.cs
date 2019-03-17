using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NATSimulation
{
    class Helper
    {
        public delegate void NATHandler();
        public delegate void MessageReceivedEventHandler(Message message);
        public static IPAddress GetInternalIP()
        {
            IPHostEntry host;
            IPAddress localip = IPAddress.Parse("192.168.1.1");
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localip = ip;
                    break;
                }
            }
            return localip;
        }
    }
}
