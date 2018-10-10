using System;
using System.Windows.Forms;
using System.Configuration;
namespace CosAdmin.FmAdmin
{
    public partial class FmAdmin : Form
    {
        public FmAdmin()
        {
            InitializeComponent();
        }

        private Cos _cos;
        public string AppName = "";
        public string UserName = "";

        private void FmAdmin_Load(object sender, EventArgs e)
        {
            Cos.CosKey = Cos.GetCos().KeyDecrypt(ConfigurationManager.AppSettings["CosKey"],"tyyxadmin");
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 2;
            var login = new FmLogin();
            login.ShowDialog();
            AppName = login.AppName;
            UserName = login.UserName;
            Text = $@"当前应用为:{AppName}";
            _cos = Cos.GetCos(AppName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserName != "tianyuyaoxi") return;
            new Test(AppName).ShowDialog();
        }
        /// <summary>
        /// 建卡按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJK_Click(object sender, EventArgs e)
        {
            var strsum = string.Empty;
            for (var i = 0; i < Convert.ToInt32(comboBox1.Text); i++)
            {
                var strTmp = _cos.KeyXz(Common.GetKeyStatus(comboBox2.SelectedIndex));
                strsum += strTmp + Environment.NewLine;
                _cos.JlXz(strTmp,UserName,"新建");
            }
            rtxtInfo.Text = $@"当前{Common.GetKeyStatus(comboBox2.SelectedIndex)}天卡 {comboBox1.Text} 张如下:{Environment.NewLine}{strsum}";
        }
        /// <summary>
        /// 卡查询=>查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var data=_cos.KeyCx(txtKey1.Text);
            var datainfo = _cos.Str2KeyList(data);
            dataGridView1.DataSource = datainfo;
        }
        /// <summary>
        /// 记录查询=>查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            var data = _cos.JlCx(txtKey2.Text);
            var datainfo = _cos.Str2JlList(data);
            dataGridView2.DataSource = datainfo;
        }
    }
}
