using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TYClient.TYExService;
using TYExPublicCore;
using TYModel;

namespace TYClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(TyEncrypt.TyEnc("123456"));
            //for (int i = 0; i < 100000; i++)
            //{
            //    TyLog.WriteError(i);
            //}
            //for (int j = 0; j < 5555; j++)
            //{
            //    TyLog.WriteInfo(j);
            //}
            //FileDialog fd = new OpenFileDialog();
            //fd.ShowDialog();
            //var fileInfo = new FileInfo(fd.FileName);
            //var c = ts.UpLoadFile(Path.GetFileName(fd.FileName),"756090666", fileInfo.Length, fileInfo.OpenRead(),out var err);
            //MessageBox.Show(c + Environment.NewLine + err);
        }
        private readonly TyServiceClient _ts= new TyServiceClient();

        private void button1_Click(object sender, EventArgs e)
        {
            BindList();
        }
        //新增测试
        private void button3_Click(object sender, EventArgs e)
        {
            var data = _ts.Fun("TestInsert", "true");
            MessageBox.Show(data);
        }
        //修改测试
        private void button4_Click(object sender, EventArgs e)
        {
            var lb = TyConvert.ObjToJson((from object item in dataGridView1.SelectedRows select item as BS_Template).ToList());
            var data = _ts.Fun("TestUpdate", lb);
            MessageBox.Show(data);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var lb = TyConvert.ObjToJson((from object item in dataGridView1.SelectedRows select item as BS_Template).ToList());
            var data = _ts.Fun("TestDelete", lb);
            MessageBox.Show(data);
        }

        private void pagerControl1_PageChanged()
        {
            BindList();
        }

        private void pagerControl1_RefreshData()
        {
            BindList();
        }
        #region 绑定列表
        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindList()
        {
            try
            {
                dataGridView1.DataSource = null;
                var t = new BS_Template
                {
                    name = textBox1.TextLength == 0 ? "" : textBox1.Text
                };
                var res = _ts.Fun("GetTemplateList", $"{TyConvert.ObjToJson(t)}|{pagerControl1.PageSize}|{pagerControl1.Page}");
                if (string.IsNullOrEmpty(res)) return;
                var ress = res.Split('|');
                pagerControl1.TotalRows = int.Parse(ress[0]);
                dataGridView1.ClearSelection();
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = false;
                DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();
                dc.HeaderText = "ID";
                dc.DataPropertyName = "id";
                dataGridView1.Columns.Add(dc);
                dc = new DataGridViewTextBoxColumn();
                dc.HeaderText = "编码";
                dc.DataPropertyName = "code";
                dataGridView1.Columns.Add(dc);
                dc = new DataGridViewTextBoxColumn();
                dc.HeaderText = @"名称";
                dc.DataPropertyName = "name";
                dc.Width = 170;
                dataGridView1.Columns.Add(dc);
                dc = new DataGridViewTextBoxColumn();
                dc.HeaderText = "备注";
                dc.DataPropertyName = "remarks";
                dataGridView1.Columns.Add(dc);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = TyConvert.JsonToObj<List<BS_Template>>(ress[1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
