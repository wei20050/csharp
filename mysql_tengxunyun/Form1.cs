using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace mysql_tengxunyun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //写入
        //string msgn;
        //for (int i = 0; i < 10; i++)
        //{
        //    Cos.Put(i.ToString(),i.ToString(),out msgn);
        //}
        private void button1_Click(object sender, System.EventArgs e)
        {
            //List<string> msg;
            //var a = Cos.Get_B("", out msg);
            //foreach (var item in msg)
            //{
            //    Console.WriteLine(item);
            //    Cos.Del(item);
            //}
            // string a;
            //int ret = Cos.Get("aaa",out a);
            nba2k.GetUser("新建");
        }
    }
}
