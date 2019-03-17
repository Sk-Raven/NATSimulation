using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace NATSimulation
{
    [Serializable]
    class Message
    {
        private IPAddress SourceIpAddress;
        private IPAddress TargetIpAddress;
        private int Sourceport;
        private int Targetport;
        private string message;

        public Message(IPAddress IpAddress, int port, string message)
        {
            TargetIpAddress = IpAddress;
            Targetport = port;
            this.message = message;
        }

        //public Message(IPAddress SIpAddress, int Sport, IPAddress TIpAddress, int Tport, string message)
        //{
        //    TargetIpAddress = TIpAddress;
        //    Targetport = Tport;
        //    SourceIpAddress = SIpAddress;
        //    Sourceport = Sport;
        //    this.message = message;
        //}

        public IPAddress getTargetIpAddress()
        {
            return TargetIpAddress;
        }

        public int getTargetport()
        {
            return Targetport;
        }

        public void setTargetPort(int port)
        {
            Targetport = port;
        }

        public void setTargetIpAddress(IPAddress ip)
        {
            TargetIpAddress = ip;
        }

     

        public void setSourceIpAddress(IPAddress ip)
        {
            SourceIpAddress = ip;
        }

        public void setSourcePort(int port)
        {
            Sourceport = port;
        }

        public IPAddress getSourceIpAddress()
        {
            return SourceIpAddress;
        }

        public int getSourceport()
        {
            return Sourceport;
        }

        override 
        public string ToString()
        {
            return String.Format("{{\r\n Source {0}:{1}\r\n Target {2}:{3}\r\n Message:{4}\r\n}}\r\n", SourceIpAddress,Sourceport,TargetIpAddress,Targetport,message);
        }

        public string getMessage()
        {
            return message;
        }

    }
}