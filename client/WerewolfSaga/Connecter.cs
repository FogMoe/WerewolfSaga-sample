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
        public int OnLoadConnect()
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 20100);  // 服务器的 IP 地址和端口
                NetworkStream stream = client.GetStream();
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
                MessageBox.Show("连接服务器失败,你检测网络"); return 0;
            }
        }

        public void Connect2ServerRoom1()
        {
            try
            {           
                TcpClient client = new TcpClient("127.0.0.1", 20100);  // 服务器的 IP 地址和端口
                NetworkStream stream = client.GetStream();
                // 发送消息到服务器

                string message = Form1.userName + ":" + Form1.userMail + "的客户端请求连接房间1成功!";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
                // 接收服务器消息
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                MessageBox.Show(receivedMessage);

                

                client.Close();
            }
            catch 
            {
                MessageBox.Show("连接服务器房间1失败");return;
            }
            
        }
    }
}
