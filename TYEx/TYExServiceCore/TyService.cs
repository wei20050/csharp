using System;
using System.IO;
using System.Reflection;
using TYExPublicCore;

namespace TYExServiceCore
{
    public class TyService : ITyService
    {
        //执行方法 json形式
        public string Fun(string functionName, string jsonData)
        {
            string responseStr;
            var serviceName = System.Configuration.ConfigurationManager.AppSettings["ServiceName"];
            try
            {
                var dll = AppDomain.CurrentDomain.BaseDirectory + $@"{serviceName}.dll";
                var className = $@"{serviceName}.Index";
                var assembly = Assembly.LoadFile(dll);
                var type = assembly.GetType(className);
                responseStr = $@"{(string)type.InvokeMember(functionName, BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { jsonData })}";
            }
            catch (Exception e)
            {
                TyLog.WriteError(e);
                responseStr = string.Empty;
            }
            return responseStr;
        }
       
        //上传文件
        public UpFileResult UpLoadFile(UpFile filedata)
        {
            var result = new UpFileResult();
            var path = $@"{AppDomain.CurrentDomain.BaseDirectory}Files\{filedata.FilePath}\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var buffer = new byte[filedata.FileSize];
            var fs = new FileStream(path + filedata.FileName, FileMode.Create, FileAccess.Write);
            int count;
            while ((count = filedata.FileStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fs.Write(buffer, 0, count);
            }
            //清空缓冲区
            fs.Flush();
            //关闭流
            fs.Close();
            result.IsSuccess = true;
            return result;
        }

        //下载文件
        public DownFileResult DownLoadFile(DownFile filedata)
        {
            var result = new DownFileResult();
            var path = $@"{AppDomain.CurrentDomain.BaseDirectory}Files\{filedata.FilePath}\{filedata.FileName}";
            if (!File.Exists(path))
            {
                result.IsSuccess = false;
                result.FileSize = 0;
                result.Message = "服务器不存在此文件";
                result.FileStream = new MemoryStream();
                return result;
            }
            Stream ms = new MemoryStream();
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            fs.CopyTo(ms);
            ms.Position = 0;  //重要，不为0的话，客户端读取有问题
            result.IsSuccess = true;
            result.FileSize = ms.Length;
            result.FileStream = ms;
            fs.Flush();
            fs.Close();
            return result;
        }
    }
}
