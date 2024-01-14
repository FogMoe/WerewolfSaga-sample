using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WerewolfSaga
{
    public partial class Form1 : Form
    {
        public static string userName;
        public static string userMail;
        Connecter connecter = new Connecter();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            userName = textBox1.Text;
            userMail = textBox2.Text;
            if(userName =="" || userMail =="")
            {
                MessageBox.Show("昵称与邮箱不能为空");
            }
            
            connecter.Connect2ServerRoom1();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e) { 

           
            string onlineRoom1Players = connecter.OnLoadConnect().ToString();
            listBox1.Items[0] = "房间1[标准]（" + onlineRoom1Players+"/6）";


        }
    }
}
