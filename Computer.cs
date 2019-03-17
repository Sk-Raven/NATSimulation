using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NATSimulation
{
    class Computer
    {
        public MessageSender sender;
        public MessageReceiver receiver;
        public IPAddress ipAddress;
        private int port;

        public Computer()
        {
            
        }

        public Computer(IPAddress ip,int port)
        {
            ipAddress = ip;
            this.port = port;
            sender =new MessageSender();
            receiver=new MessageReceiver(port);
            
        }

        public void SendMessage(IPAddress targetip, int targetport, Message message)
        {
            message.setSourcePort(port);
            message.setSourceIpAddress(ipAddress);
            sender.Send(targetip,targetport,message);
        }

     

        public void Close()
        {
            sender.SignOut();
            receiver.StopListen();
        }

        public int getport()
        {
            return port;
        }

        public event Helper.MessageReceivedEventHandler MessageReceived
        {
            add
            {
                receiver.MessageReceived += value;              
            }
            remove
            {
                receiver.MessageReceived -= value;              
            }
        }

        public event MessageSender.MessageSendEventHandler MessageSend
        {
            add
            {
                sender.MessageSend += value;
            }
            remove
            {
                sender.MessageSend -= value;
            }
        }


    }
}
