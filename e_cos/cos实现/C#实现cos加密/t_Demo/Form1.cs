using System;
using System.Windows.Forms;

namespace t_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Cos.KeyEncrypt($@"{textBox1.Text}~!{textBox2.Text}~!{textBox3.Text}", "tyyxuser");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = Cos.KeyDecrypt(richTextBox1.Text, "tyyxuser");
            richTextBox4.Text = Cos.KeyDecrypt(Cos.KeyDecrypt(richTextBox2.Text, "tyyxadmin"),"tyyx");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = Cos.KeyEncrypt(Cos.KeyEncrypt($@"{textBox1.Text}~!{textBox2.Text}~!{textBox3.Text}", "tyyx"), "tyyxadmin");
        }
    }
}
