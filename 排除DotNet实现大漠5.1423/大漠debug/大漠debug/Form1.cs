using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace 大漠debug
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        [DllImport("dm5.dll")]
        public static extern int RegDebug();
        private void button1_Click(object sender, System.EventArgs e)
        {
            var debug = RegDebug();
            switch (debug)
            {
                case 0:
                    MessageBox.Show(@"RegDebug注册成功");
                    break;
                case 1:
                    MessageBox.Show(@"RegDebug无法释放资源");
                    break;
                default:
                    MessageBox.Show(@"RegDebug无法调用");
                    break;
            }
        }
    }
}
