using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using c;
namespace Demo2
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dm = new Dmsoft();
            dm.MoveTo(100, 100);
        }
        //需要执行的事件
        private void a(object sender, KeyEventArgs e)
        {
            MessageBox.Show(@"您按下了:" + e.KeyData);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //窗体打开的事件中注册钩子 绑事件
            var hook = new c.CHook();
            hook.SetHook();//注册全局钩子
            hook.OnKeyDownEvent += a;//绑定钩子事件
        }
    }
}
