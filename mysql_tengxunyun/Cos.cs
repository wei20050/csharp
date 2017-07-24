using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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
        /// <summary>
        /// 获取接口数据
        /// </summary>
        /// <returns></returns>
        private static int GetValue(string value,out string msg)
        {
            var v = value.Split('_');
            msg = v[1];
            return Convert.ToInt32(v[0]);
        }

        public static int Put(string key,string text, out string msg)
        {
            return GetValue(Put_Object(key,text),out msg);
        }
        public static int Get(string key, out string msg)
        {
            return GetValue(Get_Object(key), out msg);
        }
        public static int Del(string key)
        {
            int ret;
            int.TryParse(Delete_Object(key),out ret);
            return ret;
        }
        public static int Get_B(string key, out List<string> msg)
        {
            string msgTmp;
            var ret = GetValue(Get_Bucket(key), out msgTmp);
            msg = msgTmp.Split(',').ToList();
            return ret;
        }
    }
}
