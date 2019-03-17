using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NATSimulation
{
    class WEB:Computer
    {
        public event Helper.MessageReceivedEventHandler WEBReceived;
        public WEB(IPAddress ip, int port) : base(ip, port)
        {
            MessageReceived += Response;
        }

        private void Response(Message message)
        {
            WEBReceived(message);
            Thread.Sleep(1000);
            string temp;
            if (message.getMessage()=="hello")
            {
                temp = "hi";
                
            }
            else if(message.getMessage().Equals("how are you"))
            {
                temp = "I'm fine";
            }

            else
            {
                temp = "what?";
            }
            Thread.Sleep(1000);
            var response = new Message(message.getSourceIpAddress(), message.getSourceport(),temp);
            SendMessage(response.getTargetIpAddress(), response.getTargetport(),response);
        }
    }
}
