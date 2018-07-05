using System;
using System.IO;

namespace TYPublicCore
{
    public class TyLog
    {
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="info">日志内容</param>
        /// <param name="iserr">是否为错误日志(默认是)</param>
        public static void Wlog(object info, bool iserr = true)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "logs")) //若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "logs"); //新建文件夹   
            }
            var file = new StreamWriter($@"{AppDomain.CurrentDomain.BaseDirectory}logs\{DateTime.Now:yyyy-MM-dd}.log",
                true);
            file.Write($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} {(iserr ? "错误" : "信息")} {info}{Environment.NewLine}");
            file.Flush();
            file.Close();
        }
    }
}