using System;
using System.Windows.Forms;
using TYPublicCore;

namespace TYChangePwd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TYDB.TySqLite.Init(out var err); if (err != string.Empty)
                {
                    MessageBox.Show(err);
                }
                else
                {
                    if (!TYDB.TySqLite.ChangePwd()) return;
                    MessageBox.Show(@"密码删除成功!");
                    TyLog.Wlog(@"数据库密码删除成功", false);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                TyLog.Wlog(exception);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show(@"新密码不能为空!");
                return;
            }
            try
            {
                TYDB.TySqLite.Init(out var err);
                if (err != string.Empty)
                {
                    MessageBox.Show(err);
                }
                else
                {
                    if (TYDB.TySqLite.ChangePwd(textBox1.Text))
                    {
                        MessageBox.Show(@"密码修改成功!");
                    }
                    TyLog.Wlog($@"修改数据库密码为:{textBox1.Text}", false);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                TyLog.Wlog(exception);
            }
        }
    }
}
