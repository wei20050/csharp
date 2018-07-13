﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAL
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
        public List<BS_Template> GetList(ref PagerModel pager, string noticeType, string coreType, string name, Enums.TemplateType templateType)
        {
            StringBuilder sql = new StringBuilder(@"
                select *
                from BS_Template t
                where 1=1 ");

            if (!string.IsNullOrWhiteSpace(noticeType))
            {
                sql.AppendFormat(" and nt.name like '%{0}%'", noticeType);
            }

            if (!string.IsNullOrWhiteSpace(coreType))
            {
                sql.AppendFormat(" and ct.name like '%{0}%'", coreType);
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                sql.AppendFormat(" and t.name like '%{0}%'", name);
            }

            sql.AppendFormat(" and t.type = '{0}'", (int)templateType);

            string orderby = string.Empty;
            pager = GlobalVar.SqliteHelp.FindPageBySql<BS_Template>(sql.ToString(), orderby, pager.rows, pager.page);
            return pager.result as List<BS_Template>;
        }
        #endregion

        #region 获取字段关联模板集合
        /// <summary>
        /// 获取字段关联模板集合
        /// </summary>
        public List<BS_Template> GetList(string fieldId)
        {
            StringBuilder sql = new StringBuilder(string.Format(@"
                select *
                from BS_Template t
                left join BS_TplFieldRelation r on r.templateId=t.id
                left join BS_TplField f on f.id=r.fieldId  
                where f.id='{0}'", fieldId));
            return GlobalVar.SqliteHelp.FindListBySql<BS_Template>(sql.ToString());
        }
        #endregion

        #region 获取
        public BS_Template Get(string typeCode, Enums.TemplateType templateType)
        {
            StringBuilder sql = new StringBuilder(string.Format(@"
                select *
                from BS_Template 
                where typeCode='{0}' 
                and type='{1}'", typeCode, (int)templateType));
            return GlobalVar.SqliteHelp.FindBySql<BS_Template>(sql.ToString());
        }
        public BS_Template Get2(string templateId, Enums.TemplateType templateType)
        {
            StringBuilder sql = new StringBuilder(string.Format(@"
                select *
                from BS_Template 
                where id='{0}' 
                and type='{1}'", templateId, (int)templateType));
            return GlobalVar.SqliteHelp.FindBySql<BS_Template>(sql.ToString());
        }
        #endregion

        #region GetMaxId
        /// <summary>
        /// GetMaxId
        /// </summary>
        public int GetMaxId()
        {
            return GlobalVar.SqliteHelp.GetMaxId<BS_Template>("id");
        }
        #endregion

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        public void Insert(object obj)
        {
            GlobalVar.SqliteHelp.Insert(obj);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        public void Update(object obj)
        {
            GlobalVar.SqliteHelp.Update(obj);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        public void Del(string id)
        {
            GlobalVar.SqliteHelp.IdDelete<BS_Template>(id);
        }
        /// <summary>
        /// 删除
        /// </summary>
        public void BatchDelete(string ids)
        {
            GlobalVar.SqliteHelp.IdBatchDelete<BS_Template>(ids);
        }
        /// <summary>
        /// 删除
        /// </summary>
        public void Delete(string conditions)
        {
            GlobalVar.SqliteHelp.Delete<BS_Template>(conditions);
        }
        #endregion

    }
}
