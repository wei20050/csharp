using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace t_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string CosKey = "0E605407A0F60F00AA07E00C0AE0BE0C907706C00500104E09A0B40D00F00DB07102900F0260A208C09D0C502F07208900605300709601703D0540B405B08406D0C20B501D0F10C406403B0DF00A0F40110F10FC0190660950C106F03703406A0210CC08703D0A60CA02E0F40B308D06705409F0A60510380E50260BB0D202E08B05A09B0F004608709B0F009103505B0D40030D30000B30F10B50AA0B00ED0600640A80930730420710270BB0650170EE0270F1";
        string AppName = "测试应用";
        //创建
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = T_Help.KeyXZ(CosKey, AppName, textBox2.Text);
        }
        //验证
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = $"{DateTime.Now.ToString("yyyyMMddHHmmss : ")}{T_Help.KeyYZ(CosKey, AppName, textBox1.Text,"YX")}\r\n" + richTextBox1.Text;
        }
        //充值
        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = $"{DateTime.Now.ToString("yyyyMMddHHmmss : ")}{T_Help.KeyYZ(CosKey, AppName, textBox1.Text, "YX")}\r\n" + richTextBox1.Text;
        }
        //解绑
        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = $"{DateTime.Now.ToString("yyyyMMddHHmmss : ")}{T_Help.KeyJB(CosKey, AppName, textBox1.Text)}\r\n" + richTextBox1.Text;
        }
        //删除
        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = $"{DateTime.Now.ToString("yyyyMMddHHmmss : ")}{T_Help.KeySC(CosKey, AppName, textBox1.Text)}\r\n" + richTextBox1.Text;
        }
        //查询
        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = $"{DateTime.Now.ToString("yyyyMMddHHmmss : ")}{T_Help.KeyCX(CosKey, AppName, textBox1.Text)}\r\n" + richTextBox1.Text;
        }
        //上传
        private void button7_Click(object sender, EventArgs e)
        {

        }
        //下载
        private void button8_Click(object sender, EventArgs e)
        {

        }
        //写日志
        private void button9_Click(object sender, EventArgs e)
        {

        }
        //加密
        private void button10_Click(object sender, EventArgs e)
        {

        }
        //解密
        private void button11_Click(object sender, EventArgs e)
        {

        }
        //获取机器码
        private void button12_Click(object sender, EventArgs e)
        {

        }
    }
}
