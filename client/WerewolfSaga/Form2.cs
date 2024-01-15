using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WerewolfSaga
{
    public partial class Form2 : Form
    {
        Form1 form1 = new Form1();
        Connecter connecter = new Connecter();
        public static string seatedName;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }

        private void Form2_FormClosing(object sender, FormClosedEventArgs e)
        {
            
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (connecter.GetInSeat(1))
            {
                this.button1.Text = Form1.userName + "（" +Form1.userMail+ "）";
                this.button1.Enabled = false; this.button2.Enabled = false; this.button3.Enabled = false; this.button4.Enabled = false; this.button5.Enabled = false; this.button6.Enabled = false;

            }
            else
            {
                this.button1.Text = seatedName;
                this.button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (connecter.GetInSeat(2))
            {
                this.button2.Text = Form1.userName + "（" + Form1.userMail + "）";
                this.button1.Enabled = false; this.button2.Enabled = false; this.button3.Enabled = false; this.button4.Enabled = false; this.button5.Enabled = false; this.button6.Enabled = false;

            }
            else
            {
                this.button2.Text = seatedName;
                this.button2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (connecter.GetInSeat(3))
            {
                this.button3.Text = Form1.userName + "（" + Form1.userMail + "）";
                this.button1.Enabled = false; this.button2.Enabled = false; this.button3.Enabled = false; this.button4.Enabled = false; this.button5.Enabled = false; this.button6.Enabled = false;

            }
            else
            {
                this.button3.Text = seatedName;
                this.button3.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (connecter.GetInSeat(4))
            {
                this.button4.Text = Form1.userName + "（" + Form1.userMail + "）";
                this.button1.Enabled = false; this.button2.Enabled = false; this.button3.Enabled = false; this.button4.Enabled = false; this.button5.Enabled = false; this.button6.Enabled = false;

            }
            else
            {
                this.button4.Text = seatedName;
                this.button4.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (connecter.GetInSeat(5))
            {
                this.button5.Text = Form1.userName + "（" + Form1.userMail + "）";
                this.button1.Enabled = false; this.button2.Enabled = false; this.button3.Enabled = false; this.button4.Enabled = false; this.button5.Enabled = false; this.button6.Enabled = false;

            }
            else
            {
                this.button5.Text = seatedName;
                this.button5.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (connecter.GetInSeat(6))
            {
                this.button6.Text = Form1.userName + "（" + Form1.userMail + "）";
                this.button1.Enabled = false; this.button2.Enabled = false; this.button3.Enabled = false; this.button4.Enabled = false; this.button5.Enabled = false; this.button6.Enabled = false;

            }
            else
            {
                this.button6.Text = seatedName;
                this.button6.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Dictionary<int, string> result = connecter.GetSeatedStatus();
            Button[] buttons = new Button[7];
            buttons[1]= this.button1;
            buttons[2]= this.button2;
            buttons[3]= this.button3;
            buttons[4]= this.button4;
            buttons[5]= this.button5;
            buttons[6]= this.button6;
            // 输出结果
            foreach (var kvp in result)
            {
                if (buttons[kvp.Key].InvokeRequired)
                {
                    buttons[kvp.Key].Invoke(new MethodInvoker(() => buttons[kvp.Key].Text = kvp.Value));
                    buttons[kvp.Key].Invoke(new MethodInvoker(() => buttons[kvp.Key].Enabled = false));
                }
                else
                {
                    buttons[kvp.Key].Text = kvp.Value;
                    buttons[kvp.Key].Enabled = false;
                }
            }
        }
    }
}
