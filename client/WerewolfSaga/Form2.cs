using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WerewolfSaga
{
    public partial class Form2 : Form
    {
        Form1 form1 = new Form1();
        Connecter connecter = new Connecter();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
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
        }
    }
}
