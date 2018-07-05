using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TYClient.TYService;
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
        TyServiceClient ts= new TyServiceClient();

        private void button1_Click(object sender, EventArgs e)
        {
            var r = new Ren
            {
                id = textBox1.TextLength == 0 ? 0 : Convert.ToInt32(textBox1.Text)
            };
            var data = ts.Fun("GetRen", TyConvert.ObjToJson(r));
            dataGridView1.DataSource = TyConvert.JsonToObj<List<Ren>>(data);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TyEncrypt.TyEnc("123456"));
            //FileDialog fd = new OpenFileDialog();
            //fd.ShowDialog();
            //var fileInfo = new FileInfo(fd.FileName);
            //var c = ts.UpLoadFile(Path.GetFileName(fd.FileName),"756090666", fileInfo.Length, fileInfo.OpenRead(),out var err);
            //MessageBox.Show(c + Environment.NewLine + err);
        }
    }
}
