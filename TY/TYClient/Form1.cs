using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TYClientCore;
using TYModel;
using TYPublicCore;
namespace TYClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var r = new Ren
            {
                id = textBox1.TextLength == 0 ? 0 : Convert.ToInt32(textBox1.Text)
            };
            if (TyUdp.Getudp().Fun("GetRen", TyConvert.ObjToJson(r), out var json))
            {
                dataGridView1.DataSource = TyConvert.JsonToObj<List<Ren>>(json);
            }
            else
            {
                MessageBox.Show(json);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TyUdp.Getudp().OpenService() ? @"服务器连接成功!" : @"服务器连接失败!");
        }
    }
}
