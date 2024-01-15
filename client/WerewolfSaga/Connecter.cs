using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WerewolfSaga
{
    public class Connecter
    {
        public static string ipAddress;
        public static int port;
        public TcpClient client;
        public NetworkStream stream;
        public int OnLoadConnect()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 20100);  // 服务器的 IP 地址和端口
                stream = client.GetStream();
                // 发送消息到服务器

                string message = "OnLoad";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
                // 接收服务器消息
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                client.Close();

                return int.Parse(receivedMessage);
            }
            catch
            {
                MessageBox.Show("连接官方服务器失败"); return 0;
            }
        }

        public bool Connect2ServerRoom1()
        {
            try
            {
                client = new TcpClient(ipAddress, port);  // 服务器的 IP 地址和端口
                stream = client.GetStream();
                // 发送消息到服务器

                string message = Form1.userName + ":" + Form1.userMail + "的客户端请求连接房间成功!";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
                // 接收服务器消息
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                MessageBox.Show(receivedMessage);
                client.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("连接服务器房间失败"); return false;
            }

        }

        public bool GetInSeat(int seatNum)
        {
            client = new TcpClient(ipAddress, port);  // 服务器的 IP 地址和端口
            stream = client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(Form1.userName + "（" + Form1.userMail + "）坐" + seatNum.ToString() + "Seated");
            stream.Write(data, 0, data.Length);

            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            client.Close();
            if (receivedMessage.Contains("成功"))
            {
                MessageBox.Show(receivedMessage);
                return true;
            }
            else
            {
                MessageBox.Show(receivedMessage + "已经坐了");
                Form2.seatedName = receivedMessage;
                return false;
            }
        }
        private string GetSendMessage()
        {
            client = new TcpClient(ipAddress, port);  // 服务器的 IP 地址和端口
            stream = client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes("检测连接状态");
            stream.Write(data, 0, data.Length);

            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            client.Close();
            return receivedMessage;
        }
        public Dictionary<int, string> GetSeatedStatus()
        {
            // 获取 sendMessage
            string sendMessage = GetSendMessage();

            // 处理 sendMessage
            string[] seatAndUserIds = sendMessage.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<int, string> seatedUid = new Dictionary<int, string>();

            foreach (var seatAndUserId in seatAndUserIds)
            {
                string[] parts = seatAndUserId.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    int seatNumber;
                    if (int.TryParse(parts[0].Replace("Seat ", ""), out seatNumber))
                    {
                        seatedUid[seatNumber] = parts[1];
                    }
                }
            }

            // 返回结果
            return seatedUid;
        }
    }
}
