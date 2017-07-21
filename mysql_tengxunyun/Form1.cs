using System.Collections.Generic;
using System.Runtime.InteropServices;
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
            var ld = new List<Dictionary<string, string>>();
            var d = new Dictionary<string, string> {{"11", "22"}};
            ld.Add(d);
            foreach (var item in ld)
            {
               // Put_Object(item.);
            }
        }
        [DllImport("COS.dll")]
        private static extern string Put_Object(string key, string text);
        [DllImport("COS.dll")]
        private static extern string Get_Object(string key, string text);
        [DllImport("COS.dll")]
        private static extern string Delete_Object(string key);
        [DllImport("COS.dll")]
        private static extern string Get_Bucket(string key);

    }
}
