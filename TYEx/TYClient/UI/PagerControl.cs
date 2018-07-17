using System;
using System.Drawing;
using System.Windows.Forms;

namespace TYClient.UI
{
    public partial class PagerControl : UserControl
    {
        #region PageSize
        private int _pageSize = 20;
        /// <summary>
        /// 当前页数
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// 记录数
        /// </summary>
        public int TotalRows { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                if (Rows != 0)
                {
                    return (TotalRows - 1) / Rows + 1;
                }
                return 0;
            }
        }
        /// <summary>
        /// 上一页
        /// </summary>
        public int PrePage
        {
            get
            {
                if (Page - 1 > 0)
                {
                    return Page - 1;
                }
                return 1;
            }
        }
        /// <summary>
        /// 下一页
        /// </summary>
        public int NextPage
        {
            get
            {
                if (Page + 1 < PageCount)
                {
                    return Page + 1;
                }
                return PageCount;
            }
        }
        /// <summary>
        /// 每页数据条数
        /// </summary>
        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value == 0)
                {
                    _pageSize = 1;
                    Rows = 1;
                }
                else
                {
                    _pageSize = value;
                    Rows = value;
                }
            }
        }
        #endregion

        #region 事件
        public event PageChangedHandler PageChanged;
        public event RefreshDataHandler RefreshData;
        #endregion

        #region Pager
        //private PagerModel _pager = new PagerModel(1, 20);
        //public PagerModel Pager
        //{
        //    get => _pager;
        //    set
        //    {
        //        _pager = value;
        //        txtCurrentPage.Text = _pager.page.ToString();
        //        lblTotalPage.Text = @" / " + _pager.pageCount;
        //    }
        //}
        #endregion

        #region PagerControl 构造函数
        public PagerControl()
        {
            InitializeComponent();
        }
        #endregion

        #region PagerControl_Load
        private void PagerControl_Load(object sender, EventArgs e)
        {
            tools.BackColor = SystemColors.Control;
        }
        #endregion

        private void btnFirst_Click(object sender, EventArgs e)
        {
            Page = 1;
            PageChanged?.Invoke();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            Page = PrePage;
            PageChanged?.Invoke();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Page = NextPage;
            PageChanged?.Invoke();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            Page = PageCount;
            PageChanged?.Invoke();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData?.Invoke();
        }

        private void btnCurrentPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCurrentPage_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(txtCurrentPage.Text) < 1)
            {
                txtCurrentPage.Text = @"1";
            }
            if (Convert.ToInt32(txtCurrentPage.Text) > PageCount)
            {
                txtCurrentPage.Text = PageCount.ToString();
            }
            Page = Convert.ToInt32(txtCurrentPage.Text);
            PageChanged?.Invoke();
        }
    }
    /// <summary>
    /// 翻页
    /// </summary>
    public delegate void PageChangedHandler();
    /// <summary>
    /// 刷新数据
    /// </summary>
    public delegate void RefreshDataHandler();
}
