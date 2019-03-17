using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NATSimulation
{
    public partial class Form1 : Form
    {
        private List<Computer> computerList;
        private NAT nat;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Computer computer0 = new Computer(Helper.GetInternalIP(), 6666);
            Computer computer1 = new Computer(Helper.GetInternalIP(), 6667);
            Computer computer2 = new Computer(Helper.GetInternalIP(), 6668);
            computerList = new List<Computer>();
            computerList.Add(computer0);
            computerList.Add(computer1);
            computerList.Add(computer2);
            foreach (var computer in computerList)
            {
                computer.MessageReceived += PCReceived;
                computer.MessageSend += PCSend;
            }
            comboBox1.Items.Add("主机0");
            comboBox1.Items.Add("主机1");
            comboBox1.Items.Add("主机2");

            nat = new NAT(Helper.GetInternalIP(), 6669);
            nat.NATReceived += NATReceived;
            nat.MessageSend += NATSend;

            WEB web = new WEB(Helper.GetInternalIP(), 8888);
            web.WEBReceived += WEBReceived;
            web.MessageSend += WEBSend;

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("原地址", 200);
            listView1.Columns.Add("新地址", 80);
            nat.Update+=UpdateList;
        }

     

        private void PCReceived(Message message)
        {
            PCtextBox1.Text +=
                String.Format("[{0}]：{1}收到信息:\r\n{2}\r\n", DateTime.Now, getname(message.getTargetport()), message);
        }

        private void PCSend(Message message)
        {
            PCtextBox1.Text +=
                String.Format("[{0}]：{1}发送信息:\r\n{2}\r\n", DateTime.Now, getname(message.getSourceport()), message);
        }

        private void NATReceived(Message message)
        {
            NATtextBox.Text +=
                String.Format("[{0}]：NAT收到信息:\r\n{1}\r\n正在转换...\r\n", DateTime.Now, message);
        }

        private void NATSend(Message message)
        {
            NATtextBox.Text +=
                String.Format("[{0}]：NAT发送信息:\r\n{1}\r\n", DateTime.Now, message);
        }

        private void WEBReceived(Message message)
        {
            WEBtextBox.Text +=
                String.Format("[{0}]：WEB收到信息:\r\n{1}\r\n正在回应...\r\n", DateTime.Now, message);
        }

        private void WEBSend(Message message)
        {
            WEBtextBox.Text +=
                String.Format("[{0}]：WEB发送信息:\r\n{1}\r\n", DateTime.Now, message);
        }

        private string getname(int port)
        {
            string temp;
            if (port == 6666)

                temp = "主机0";
            else if (port == 6667)
            {
                temp = "主机1";
            }

            else
            {
                temp = "主机2";
            }

            return temp;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Message message = new Message(Helper.GetInternalIP(), 8888, PCtextBox2.Text);
            if (comboBox1.SelectedIndex != -1)
                computerList[comboBox1.SelectedIndex].SendMessage(Helper.GetInternalIP(), 6669, message);
        }

        private void PCtextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void UpdateList()
        {
            listView1.Items.Clear();
            string[] arr = new string[2];
            ListViewItem itm;

            //Add first item
            foreach (var item in nat.NATList)
            {
                arr[0] = item.Value.ToString();
                arr[1] = item.Key.ToString();
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
        }
    }
}
