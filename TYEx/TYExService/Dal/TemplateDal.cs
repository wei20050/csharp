using System.Collections.Generic;
using System.Text;
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
        public List<BS_Template> GetList(BS_Template b,string size, string page ,out string rows)
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

        #region 获取字段关联模板集合
        /// <summary>
        /// 获取字段关联模板集合
        /// </summary>
        public List<BS_Template> GetList(string fieldId)
        {
            var sql = new StringBuilder($@"
                select *
                from BS_Template t
                left join BS_TplFieldRelation r on r.templateId=t.id
                left join BS_TplField f on f.id=r.fieldId  
                where f.id='{fieldId}'");
            return GlobalVar.DbHelper.FindListBySql<BS_Template>(sql.ToString());
        }
        #endregion

        #region 获取
        public BS_Template Get(string typeCode)
        {
            var sql = new StringBuilder($@"
                select *
                from BS_Template 
                where typeCode='{typeCode}' 
                and type='0'");
            return GlobalVar.DbHelper.FindBySql<BS_Template>(sql.ToString());
        }
        public BS_Template Get2(string templateId)
        {
            var sql = new StringBuilder($@"
                select *
                from BS_Template 
                where id='{templateId}' 
                and type='0'");
            return GlobalVar.DbHelper.FindBySql<BS_Template>(sql.ToString());
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
        public void Update(object obj)
        {
            GlobalVar.DbHelper.Update(obj,$"id = '{((BS_Template)obj).id}'");
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
