using System;
using System.Collections.Generic;
using System.Linq;
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

        //服务器接口类
        private readonly TyServiceClient _ts = new TyServiceClient();
        private void button2_Click(object sender, EventArgs e)
        {
            object[] objs = {123456,"成功" };
           var str = _ts.Fun("Test", TyConvert.ObjToJson(objs));
            MessageBox.Show(str);
        }

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
            var lb = (from DataGridViewRow item in dataGridView1.SelectedRows select item.DataBoundItem as BS_Template).ToList();
            var data = _ts.Fun("TestUpdate", TyConvert.ObjToJson(lb));
            MessageBox.Show(data);
        }
        //删除测试
        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"没有选中任何行!");
                return;
            }
            var lb = (from DataGridViewRow item in dataGridView1.SelectedRows select item.DataBoundItem as BS_Template).ToList();
            var strs = new string[lb.Count];
            for (var i=0; i < lb.Count;i++)
            {
                strs[i] = lb[i].id;
            }
            var data = _ts.Fun("TestDelete", TyConvert.ObjToJson(strs));
            MessageBox.Show(data);
        }
        //换页
        private void pagerControl1_PageChanged()
        {
            BindList();
        }
        //刷新
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
                object[] objs = {TyConvert.ObjToJson(t), pagerControl1.PageSize, pagerControl1.Page};
                var res = _ts.Fun("GetTemplateList", TyConvert.ObjToJson(objs));
                if (string.IsNullOrEmpty(res)) return;
                var ress = TyConvert.JsonToObj<string[]>(res);
                pagerControl1.TotalRows = int.Parse(ress[0]);
                dataGridView1.ClearSelection();
                dataGridView1.Columns.Clear();
                dataGridView1.AutoGenerateColumns = false;
                var dc = new DataGridViewTextBoxColumn
                {
                    HeaderText = @"ID",
                    Width = 240,
                    DataPropertyName = "id"
                };
                dataGridView1.Columns.Add(dc);
                dc = new DataGridViewTextBoxColumn
                {
                    HeaderText = @"编码",
                    DataPropertyName = "code"
                };
                dataGridView1.Columns.Add(dc);
                dc = new DataGridViewTextBoxColumn
                {
                    HeaderText = @"名称",
                    DataPropertyName = "name",
                    Width = 240
                };
                dataGridView1.Columns.Add(dc);
                dc = new DataGridViewTextBoxColumn
                {
                    HeaderText = @"备注",
                    DataPropertyName = "remarks"
                };
                dataGridView1.Columns.Add(dc);
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.DataSource = TyConvert.JsonToObj<List<BS_Template>>(ress[1]) ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();
        }
    }
}
