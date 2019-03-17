using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace NATSimulation
{
    class NAT:Computer
    {
        public Dictionary<int, IPEndPoint> NATList;
        public Dictionary<int, MessageReceiver>PortlList;
        public event Helper.MessageReceivedEventHandler NATReceived;
        
        public event Helper.NATHandler Update;
        public NAT(IPAddress ip, int port):base(ip,port)
        {
            MessageReceived += Transform;
            NATList=new Dictionary<int, IPEndPoint>();
            PortlList=new Dictionary<int, MessageReceiver>();
            for(int i=6700;i<6710;i++)
                PortlList.Add(i,null);
            
            
        }

        private void Transform(Message message)
        {
            NATReceived(message);
            Thread.Sleep(1000);
            if (message.getTargetport()==8888)
            {
                foreach (var port in PortlList)
                {
                    if (port.Value==null)
                    {
                        IPEndPoint temp =new IPEndPoint(message.getSourceIpAddress(),message.getSourceport());
                        PortlList[port.Key]=new MessageReceiver(port.Key);
                        PortlList[port.Key].MessageReceived += Transform;
                        var tranMessage=new Message(message.getTargetIpAddress(),message.getTargetport(),message.getMessage());
                        tranMessage.setSourceIpAddress(ipAddress);
                        tranMessage.setSourcePort(port.Key);
                        NATList.Add(port.Key,temp);
                        Update();
                        sender.Send(message.getTargetIpAddress(),message.getTargetport(),tranMessage);                       
                        break;
                    }
                }
            }

            else
            {
                IPEndPoint temp = NATList[message.getTargetport()];
                NATList.Remove(message.getTargetport());
                PortlList[message.getTargetport()].StopListen();
                PortlList[message.getTargetport()] = null;
                message.setTargetPort(temp.Port);
                message.setTargetIpAddress(temp.Address);
                sender.Send(temp.Address,temp.Port,message);
                Update();
            }
        }

    }


}
