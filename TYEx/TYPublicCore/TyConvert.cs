using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace TYPublicCore
{
    public class TyConvert
    {  //将JSON数据转化为对应的类型  
        public static T JsonToObj<T>(string jsonStr)
        {
            try
            {
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonStr)))
                {
                    return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(ms);
                }
            }
            catch (Exception ex)
            {
                TyLog.WriteError(ex);
                return default(T);
            }
        }
        //将对应的类型转化为JSON字符串  
        public static string ObjToJson(object jsonObject)
        {
            using (var ms = new MemoryStream())
            {
                new DataContractJsonSerializer(jsonObject.GetType()).WriteObject(ms, jsonObject);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
        //实体集合转DataTable
        public static DataTable ToDataTable<T>(IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());
            var enumerable = collection as IList<T> ?? collection.ToList();
            var count = enumerable.Count;
            if (count <= 0) return dt;
            for (var i = 0; i < enumerable.Count(); i++)
            {
                var tempList = new ArrayList();
                foreach (var pi in props)
                {
                    var obj = pi.GetValue(enumerable.ElementAt(i), null);
                    tempList.Add(obj);
                }
                var array = tempList.ToArray();
                dt.LoadDataRow(array, true);
            }
            return dt;
        }
        //DataTable转实体集合
        public static List<T> DataTableTo<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }
            List<DataRow> rows = new List<DataRow>();
            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }
            return ConvertTo<T>(rows);
        }
        //DataRow集合转实体集合
        private static List<T> ConvertTo<T>(IList<DataRow> rows)
        {
            List<T> list = null;
            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }
            return list;
        }
        //DataRow转实体
        private static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);
            if (row == null) return obj;
            obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in row.Table.Columns)
            {
                var prop = obj.GetType().GetProperty(column.ColumnName);
                try
                {
                    var value = row[column.ColumnName];
                    if (prop != null) prop.SetValue(obj, value, null);
                }
                catch(Exception ex)
                {
                    TyLog.WriteError($"{column.ColumnName}转换失败:{ex}");
                }
            }
            return obj;
        }
    }
}
