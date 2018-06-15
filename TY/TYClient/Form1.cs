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
            Ren r = new Ren
            {
                id = 2
            };
            TYUdp.Getudp().serviceIp = System.Net.IPAddress.Parse(textBox1.Text);
            if (TYUdp.Getudp().Fun("GetRen", TYConvert.ObjToJson(r), out string json))
            {
                dataGridView1.DataSource = TYConvert.JsonToObj<List<Ren>>(json);
            }
            else
            {
                MessageBox.Show("服务器连接错误");
            }
        }
    }
}
