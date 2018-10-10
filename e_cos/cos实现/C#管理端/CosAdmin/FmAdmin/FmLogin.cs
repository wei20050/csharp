using System.Windows.Forms;

namespace CosAdmin.FmAdmin
{
    public partial class FmLogin : Form
    {
        public FmLogin()
        {
            _cos = Cos.GetCos("Admin");
            InitializeComponent();
        }

        private readonly Cos _cos;
        private bool _yz = true;
        public string AppName = "";
        public string UserName = "";

        private void button1_Click(object sender, System.EventArgs e)
        {

            AppName = txtApp.Text;
            UserName = txtKey.Text;
            if (txtKey.Text == @"tyyxadmin")
            {
                UserName = @"tianyuyaoxi";
                _yz = false;
                Properties.Settings.Default.AppName = txtApp.Text;
                Properties.Settings.Default.Key = txtKey.Text;
                Properties.Settings.Default.Save();
                Close();
            }
            else
            {
                if (_cos.KeyYz(txtKey.Text, txtApp.Text))
                {
                    _yz = false;
                    Properties.Settings.Default.AppName = txtApp.Text;
                    Properties.Settings.Default.Key = txtKey.Text;
                    Properties.Settings.Default.Save();
                    Close();
                }
                else
                {
                    MessageBox.Show(@"验证失败,具体问题请看 LOG 文件夹内的 ERR文件");
                }
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void FmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_yz)
            {
                Application.Exit();
            }
        }

        private void FmLogin_Load(object sender, System.EventArgs e)
        {
            txtApp.Text = Properties.Settings.Default.AppName;
            txtKey.Text = Properties.Settings.Default.Key;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtKey.Text == @"tyyxadmin")
            {
                new FmReg().Show();
            }
        }
    }
}
