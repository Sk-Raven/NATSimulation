using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace NATSimulation
{
    class MessageSender
    {
        private Socket client;
        private IPEndPoint ip;
        public delegate void MessageSendEventHandler(Message message);
        public event MessageSendEventHandler MessageSend;


        public bool Send(IPAddress ip, int port, Message message)
        {
            try
            {
                this.ip = new IPEndPoint(ip, port);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(this.ip);
               
            }
            catch(Exception e)
            {
                e.ToString();
                return false;
            }
            try
            {                          
                BinaryFormatter b = new BinaryFormatter();
                var ms = new MemoryStream();
                b.Serialize(ms, message);
                byte[] datasize = new byte[4];
                datasize = BitConverter.GetBytes(ms.GetBuffer().Length);
                client.Send(datasize);
                client.Send(ms.GetBuffer());
                MessageSend(message);
                return true;                
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public void SignOut()
        {
            if(client!=null)
                client.Dispose();
        }
    }
}
