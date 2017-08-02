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
        private void button1_Click(object sender, System.EventArgs e)
        {
           
        }
        public void p(object o)
        {
            MessageBox.Show(o.ToString());
        }
        public void test()
        {
            user u = new user();
            u.uid = "756090666";
            u.pwd = "111111111";
            u.regtime = "201708021111";
            u.endtime = "201709021111";
            p(nba2k.SetUser(u));
        }
        public void test1()
        {
            user u = nba2k.GetUser("756090666");
        }
        public void test3()
        {
            var a = Cos.findall("user");
            foreach (var item in a)
            {
                Cos.Del(item);
            }
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            sjzy s = new sjzy();
            s.ShowDialog();
        }
    }
}
