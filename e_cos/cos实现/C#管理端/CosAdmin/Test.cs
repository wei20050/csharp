using System;
using System.Windows.Forms;

namespace CosAdmin
{
    public partial class Test : Form
    {
        public Test(string appName)
        {
            _cos = new Cos(appName);
            InitializeComponent();
        }

        private readonly Cos _cos;
        private void P(string msg)
        {
            richTextBox1.Text = DateTime.Now.ToString("yyyyMMddHHmmss : ") + msg + Environment.NewLine +
                                @"---------------------------------------------------------------" +
                                Environment.NewLine + richTextBox1.Text;
        }

        //创建
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = _cos.KeyXz(textBox2.Text);
            P(textBox1.Text == string.Empty ? "新增key失败" : "新增key成功");
        }

        //验证
        private void button1_Click(object sender, EventArgs e)
        {
            P("验证:" + _cos.KeyYz(textBox1.Text, textBox3.Text));
        }

        //充值
        private void button3_Click(object sender, EventArgs e)
        {
            P("充值:" + _cos.KeyCz(textBox1.Text, textBox2.Text));
        }

        //解绑
        private void button4_Click(object sender, EventArgs e)
        {
            P("解绑:" + _cos.KeyJb(textBox1.Text));
        }

        //删除
        private void button5_Click(object sender, EventArgs e)
        {
            P("删除:" + _cos.KeySc(textBox1.Text));
        }

        //查询
        private void button6_Click(object sender, EventArgs e)
        {
            P("查询:" + _cos.KeyCx(textBox1.Text));
        }

        //上传
        private void button7_Click(object sender, EventArgs e)
        {
            P("上传:" + _cos.KeySet(textBox1.Text, textBox4.Text));
        }

        //下载
        private void button8_Click(object sender, EventArgs e)
        {
            P("下载:" + _cos.KeyGet(textBox1.Text, textBox4.Text));
        }

        //写日志
        private void button9_Click(object sender, EventArgs e)
        {
            _cos.KeyLog("测试错误日志");
            _cos.KeyLog("测试信息日志","0");
            P("测试日志写入成功");
        }

        //加密
        private void button10_Click(object sender, EventArgs e)
        {
            P("加密:" + _cos.KeyEncrypt("123456", "TYYX"));
        }

        //解密
        private void button11_Click(object sender, EventArgs e)
        {
            P("解密:" + _cos.KeyDecrypt("03E00D0A200A0D60A70CA0BC0D206406D0F107701904D0D2", "TYYX"));
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

        //直接写入
        private void button14_Click(object sender, EventArgs e)
        {
            P("直接写入:" + _cos.Insert(textBox5.Text, string.Empty));
        }

        //直接删除
        private void button15_Click(object sender, EventArgs e)
        {
            P("直接删除:" + _cos.Delete(textBox5.Text));
        }
    }
}
