using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NATSimulation
{
    
    class MessageReceiver
    {
        
        public event Helper.MessageReceivedEventHandler MessageReceived;
        public Socket listener;
        private Thread workerThread;
        private Thread receiveThread;


        public MessageReceiver(int port)
        {
           
            workerThread = new Thread(()=>ListenThreadMethod(port))
            {
                IsBackground = true
            };
            workerThread.Start();
            
        }

        private void ListenThreadMethod(int port)
        {
            IPAddress localIp = IPAddress.Parse(Helper.GetInternalIP().ToString());
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(localIp, port));  //绑定IP地址：端口
            listener.Listen(10);    //设定最多10个排队连接请求

                 
            while (true)
            {
                if (listener != null)
                {
                    try
                    {
                        Socket clientSocket = listener.Accept();
                        receiveThread = new Thread(()=>MessageListener(clientSocket));
                        receiveThread.Start();
                    }
                    catch 
                    {
                     
                        break;
                    }
                }
            }
        }

        private void MessageListener(Socket clientSocket)
        {
            byte[] size=new byte[4];
            clientSocket.Receive(size,0,4,SocketFlags.None);
            int baglength = BitConverter.ToInt32(size,0);
            byte[] buffer = new byte[8192];
            var ms = new MemoryStream();
            int numberOfBytesRead=0;
            int bytesRead;
            do
            {
                bytesRead = clientSocket.Receive(buffer, 0, 8192, SocketFlags.None);
                ms.Write(buffer, 0, bytesRead);
                numberOfBytesRead += bytesRead;
            } while (numberOfBytesRead<baglength);
            ms.Seek(0, SeekOrigin.Begin);
            if (MessageReceived != null)
            {
                BinaryFormatter b = new BinaryFormatter();
                Message temp = b.Deserialize(ms) as Message;             
                ms.Close();
                MessageReceived(temp);       // 已经收到消息
            }
        }

      

        public void StopListen()
        {
            try
            {
                listener.Close();
                listener = null;
                workerThread.Abort();
               
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }



    }
}
