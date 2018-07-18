using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TYExPublicCore;
using TYModel;

namespace TYExService.Dal
{
    /// <summary>
    /// 模板
    /// </summary>
    public class TemplateDal
    {
        #region 分页获取模板集合
        /// <summary>
        /// 分页获取模板集合
        /// </summary>
        public List<BS_Template> GetList(BS_Template b,int size, int page ,out int rows)
        {
            var sql = new StringBuilder(@"
                select *
                from BS_Template t
                where 1=1 ");
            if (!string.IsNullOrWhiteSpace(b.name))
            {
                sql.AppendFormat(" and t.name like '%{0}%'", b.name);
            }
            var orderby = string.Empty;
           var list = GlobalVar.DbHelper.FindPageBySql<BS_Template>(sql.ToString(), orderby, size, page,out rows);
            return list;
        }
        #endregion
        

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        public void Insert(BS_Template obj)
        {
            GlobalVar.DbHelper.Insert(obj);
        }
        #endregion
        public void TestInsert( )
        {
            var k = 0;
            for (var i = 0; i < 100; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        GlobalVar.DbHelper.BeginTransaction();

                        var model = new BS_Template
                        {
                            id = Guid.NewGuid().ToString(),
                            code = k.ToString(),
                            name = "测试" + k,
                            remarks = "测试" + k,
                            type = "1"
                        };
                        Insert(model);

                        GlobalVar.DbHelper.CommitTransaction();

                        k++;
                    }
                    catch (Exception ex)
                    {
                        GlobalVar.DbHelper.RollbackTransaction();
                        TyLog.WriteError(ex.Message);
                    }
                });
            }
        }
        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        public void Update(BS_Template obj)
        {
            GlobalVar.DbHelper.Update(obj,$"id = '{obj.id}'");
        }
        //测试修改
        public void TestUpdate(List<BS_Template> lb)
        {
            var rnd = new Random();

            try
            {
                //GlobalVar.DbHelper.BeginTransaction();
                foreach (var t in lb)
                {
                    t.remarks = "测试" + rnd.Next(1, 9999).ToString("0000");
                    Update(t);
                }
                //GlobalVar.DbHelper.CommitTransaction();
            }
            catch (Exception ex)
            {
                GlobalVar.DbHelper.RollbackTransaction();
                TyLog.WriteError(ex.Message);
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 根据id删除
        /// </summary>
        public void Del(string id)
        {
            GlobalVar.DbHelper.Delete<BS_Template>($"id = '{id}'");
        }
        //测试删除
        public void TestDelete(List<BS_Template> lb)
        {
            try
            {
                GlobalVar.DbHelper.BeginTransaction();
                foreach (var t in lb)
                {
                    Del(t.id);
                }
                GlobalVar.DbHelper.CommitTransaction();
            }
            catch (Exception ex)
            {
                GlobalVar.DbHelper.RollbackTransaction();
                TyLog.WriteError(ex.Message);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public void Delete(string conditions)
        {
            GlobalVar.DbHelper.Delete<BS_Template>(conditions);
        }
        #endregion

    }
}
