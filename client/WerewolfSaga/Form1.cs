using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WerewolfSaga
{
    public partial class Form1 : Form
    {
        public static string userName;
        public static string userMail;
        public static bool customServer=false;
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
            if(customServer==false)
            {
                Connecter.ipAddress = "127.0.0.1";
                Connecter.port = 20100;
            }
            else
            {
                Connecter.ipAddress = textBox3.Text;
                Connecter.port = int.Parse(textBox4.Text);
            }
            
            if (userName =="" || userMail =="")
            {
                MessageBox.Show("昵称与邮箱不能为空");
            }
            else
            {
                if (connecter.Connect2ServerRoom1())
                {
                    Form2 form2 = new Form2();
                    
                    form2.Show();
                    this.Hide();
                    
                }
                
            }
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e) 
        { 

           
            string onlineRoom1Players = connecter.OnLoadConnect().ToString();
            
            listBox1.SelectedIndex = 0;


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(customServer==false)
            {
                listBox1.Visible = false;
                textBox3.Visible = true;
                textBox4.Visible = true;
                customServer = true;
            }
            else
            {
                listBox1.Visible = true;
                textBox3.Visible = false;
                textBox4.Visible = false;
                customServer = false;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // 使用默认的浏览器打开网站
                Process.Start("https://github.com/scarletkc/Werewolf-Saga");
            }
            catch (Exception)
            {
                MessageBox.Show("https://github.com/scarletkc/Werewolf-Saga");
            }
        }
    }
}
