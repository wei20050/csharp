using System.Collections.Generic;
using System.Text;
using TYModel;

namespace TYExService.Dal
{
    public class TestDal
    {
        #region 分页获取
        /// <summary>
        /// 分页获取
        /// </summary>
        //public List<BS_Test> GetList(out int rows, string name)
        //{
        //    StringBuilder sql = new StringBuilder(@"
        //        select *
        //        from BS_Test t
        //        where 1=1 ");

        //    if (!string.IsNullOrWhiteSpace(name))
        //    {
        //        sql.AppendFormat(" and t.name like '%{0}%'", name);
        //    }

        //    string orderby = string.Empty;
        //    pager = GlobalVar.DbHelper.FindPageBySql<BS_Test>(sql.ToString(), orderby, pager.Rows, pager.Page);
        //    return pager.Result as List<BS_Test>;
        //}
        /// <summary>
        /// 查询列表
        /// </summary>
        public List<BS_Test> GetList(string name)
        {
            StringBuilder sql = new StringBuilder(@"
                select *
                from BS_Test t
                where 1=1 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                sql.AppendFormat(" and t.name like '%{0}%'", name);
            }

            return GlobalVar.DbHelper.FindListBySql<BS_Test>(sql.ToString());
        }
        #endregion

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        public void Insert(object obj)
        {
            GlobalVar.DbHelper.Insert(obj);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        public void Update(BS_Test obj)
        {
            GlobalVar.DbHelper.Update(obj,"id="+obj.id);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        public void Del(string id)
        {
            GlobalVar.DbHelper.Delete<BS_Test>("id="+id);
        }
        #endregion
    }
}
