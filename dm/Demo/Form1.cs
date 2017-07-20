using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //解析程序集失败的时候调用加载资源文件中的dll, 这句必须写在构造里面 InitializeComponent之前.
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            InitializeComponent();
        }
        /// <summary>
        /// 读取资源中的dll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return System.Reflection.Assembly.Load(bytes);
        }
        //需要执行的事件
        private void a(object sender, KeyEventArgs e)
        {
            MessageBox.Show("您按下了:" + e.KeyData.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //窗体打开的事件中注册钩子 绑事件
            c.CHook hook = new c.CHook();
            hook.SetHook();//注册全局钩子
            hook.OnKeyDownEvent += a;//绑定钩子事件
        }
        //测试大漠功能的按钮
        private void button1_Click(object sender, EventArgs e)
        {
            var dm = new c.Dmsoft();
            dm.MoveTo(20, 20);
            dm.LeftDoubleClick();
            dm.Delay(1000);
            dm.MoveTo(300, 600);
        }
    }
}
