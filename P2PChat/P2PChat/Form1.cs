using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2PChat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Thread td;
        private TcpListener tcpListener;
        private static string message = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            td = new Thread(StartListen);
            td.Start(); // 启动监听线程
            timer1.Start();
        }
        private void StartListen()
        {
            message = "";
            tcpListener = new TcpListener(888);
            tcpListener.Start(); // 启动监听
            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient(); // 接受连接请求
                NetworkStream nStream = tcpClient.GetStream(); // 获取数据流
                byte[] buffer = new byte[1024]; // 建立缓存
                int i = nStream.Read(buffer, 0, buffer.Length); // 将数据流写入缓存
                message = Encoding.Default.GetString(buffer,0,i); // 将字节解码为string字符串
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.tcpListener != null)
            {
                tcpListener.Stop(); // 停止监听
            }
            if (td != null)
            {
                if (td.ThreadState == ThreadState.Running)
                {
                    td.Abort(); // 停止线程
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbReceive.Clear(); // 清除聊天文本框
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress[] ip = Dns.GetHostAddresses(Dns.GetHostName()); // 获取本机IP地址
                // 发送的消息
                string strMsg = $"{txtNickName.Text}({ip[0].ToString()}) {DateTime.Now.ToString("T")}\n {rtbSend.Text}\n";
                TcpClient tcpClient = new TcpClient(txtIPAddress.Text, 888); // 建立TCP连接
                NetworkStream networkStream = tcpClient.GetStream(); // 获取数据流
                StreamWriter writer = new StreamWriter(networkStream,Encoding.Default); // 数据流写入实例
                writer.Write(strMsg);
                writer.Flush(); // 清理缓冲区
                writer.Close(); // 关闭
                rtbReceive.AppendText(strMsg);
                rtbReceive.ScrollToCaret();
                rtbSend.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rtbSend_KeyPress(object sender, KeyPressEventArgs e) // 键盘事件
        {
            if (e.KeyChar == '\r') // 按下回车键
            {
                btnSend.PerformClick(); // 触发发送事件
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (message != "")
            {
                rtbReceive.AppendText(message);
                rtbReceive.ScrollToCaret();
                message = ""; // 初始化message
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); // 退出程序
        }
    }
}
