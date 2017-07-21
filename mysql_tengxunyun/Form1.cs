using System;
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
            var a = Cos.Get("223");
                Console.WriteLine( a);
        }
    }
}
