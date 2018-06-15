using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TYClientCore;
using TYModel;
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
                id = 2,
                name = "weiyaoxi",
                age = 12,
                sfzhm = "1122"
            };
            var json = Udp.Getudp().Fun("GetRen",TYPublicCore.Json.ObjToJson(r));
            dataGridView1.DataSource = TYPublicCore.Json.JsonToObj<List<Ren>>(json);
        }
    }
}
