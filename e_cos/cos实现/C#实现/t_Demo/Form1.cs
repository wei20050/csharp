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

        private void P(string msg)
        {
            richTextBox1.Text = DateTime.Now.ToString("yyyyMMddHHmmss : ") + msg + Environment.NewLine +
                                @"--------------------------------------------------------" + richTextBox1.Text;
        }

        //创建
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = Cos.KeyXz(textBox2.Text);
            P("新增key成功");
        }

        //验证
        private void button1_Click(object sender, EventArgs e)
        {
            P("验证:" + Cos.KeyYz(textBox1.Text, textBox3.Text));
        }

        //充值
        private void button3_Click(object sender, EventArgs e)
        {
            P("充值:" + Cos.KeyCz(textBox1.Text, textBox2.Text));
        }

        //解绑
        private void button4_Click(object sender, EventArgs e)
        {
            P("解绑:" + Cos.KeyJb(textBox1.Text));
        }

        //删除
        private void button5_Click(object sender, EventArgs e)
        {
            P("删除:" + Cos.KeySc(textBox1.Text));
        }

        //查询
        private void button6_Click(object sender, EventArgs e)
        {
            P("查询:" + Cos.KeyCx(textBox1.Text));
        }

        //上传
        private void button7_Click(object sender, EventArgs e)
        {
            P("上传:" + Cos.KeySet(textBox1.Text, textBox4.Text));
        }

        //下载
        private void button8_Click(object sender, EventArgs e)
        {
            P("下载:" + Cos.KeyGet(textBox1.Text, textBox4.Text));
        }

        //写日志
        private void button9_Click(object sender, EventArgs e)
        {
            Cos.KeyLog("测试错误日志", true);
            Cos.KeyLog("测试信息日志");
            P("测试日志写入成功");
        }

        //加密
        private void button10_Click(object sender, EventArgs e)
        {
            P("加密:" + Cos.KeyEncrypt("123456", "TYYX"));
        }

        //解密
        private void button11_Click(object sender, EventArgs e)
        {
            P("解密:" + Cos.KeyDecrypt("03E00D0A200A0D60A70CA0BC0D206406D0F107701904D0D2", "TYYX"));
        }

        //获取机器码
        private void button12_Click(object sender, EventArgs e)
        {
            textBox3.Text = new SoftReg().GetMNum();
            P("机器码获取完成");
        }

        //选择文件
        private void button13_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox4.Text = openFileDialog1.FileName;
            P("文件已选定");
        }
    }
}
