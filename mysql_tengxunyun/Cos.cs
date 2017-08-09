using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace mysql_tengxunyun
{
    public class Cos
    {
        [DllImport("COS.dll")]
        private static extern string Put_Object(string key, string text);
        [DllImport("COS.dll")]
        private static extern string Get_Object(string key);
        [DllImport("COS.dll")]
        private static extern string Delete_Object(string key);
        [DllImport("COS.dll")]
        private static extern string Get_Bucket(string key);
        private static int GetValue(string value,out string msg)
        {
            var v = value.Split('_');
            if (v.Length != 2)
            {
                Common.WLog("GetValue : " + value);
            }
            msg = v[1];
            return Convert.ToInt32(v[0]);
        }
        private static int Get_B(string key, out List<string> msg)
        {
            string msgTmp;
            msg = new List<string>();
            var ret = GetValue(Get_Bucket(key), out msgTmp);
            if (ret != 200)
            {
                Common.WLog("Get_B : " + ret + "_" + msgTmp);
                msg = null;
            }
            else
            {
                foreach (var item in msgTmp.Split('~'))
                {
                    msg.Add(item);
                }
            }
            return ret;
        }
        /// <summary>
        /// 添加一条数据/修改一条数据
        /// </summary>
        /// <param name="key">数据名</param>
        /// <param name="text">数据内容</param>
        /// <param name="msg">返回信息</param>
        /// <returns></returns>
        public static int Add(string key,string text, out string msg)
        {
            return GetValue(Put_Object(key,text),out msg);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="key">数据名</param>
        /// <returns>真假</returns>
        public static bool Save(string key,string name)
        {
            string ret = find(key);
            if (ret.Equals(""))
            {
                return false;
            }
            else
            {
                string msg;
                Add(name, "", out msg);
                Del(ret);
                return true;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="key">数据名称</param>
        /// <returns>返回信息</returns>
        public static int Del(string key)
        {
            int ret;
            int.TryParse(Delete_Object(key),out ret);
            if (ret != 204)Common.WLog("Del : " + "key:"+ key + "返回值：" + ret);
            return ret;
        }
        /// <summary>
        /// 获取数据内容
        /// </summary>
        /// <param name="key">数据名</param>
        /// <param name="msg">返回数据内容</param>
        /// <returns></returns>
        public static int Get(string key, out string msg)
        {
            return GetValue(Get_Object(key), out msg);
        }
        /// <summary>
        /// 查询一条数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string find(string key)
        {
            var ls = findall(key);
            if (ls == null)
            {
                return "";
            }
            return ls[0];
        }
        /// <summary>
        /// 查询所有符合条件的数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<string> findall(string key)
        {
            List<string> ls = new List<string>();
            int ret = Get_B(key,out ls);
            return ls;
        }
    }
}
