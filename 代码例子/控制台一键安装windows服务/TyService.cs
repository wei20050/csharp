using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TYExServiceCore
{
    public class TyService : ITyService
    {
        public string Fun(string functionName, string jsonData)
        {
            string responseStr;
            try
            {
                var dll = Environment.CurrentDirectory + @"\TYService.dll";
                const string className = @"TYService.Index";
                var assembly = Assembly.LoadFile(dll);
                var type = assembly.GetType(className);
                responseStr = $@"1|{(string)type.InvokeMember(functionName, BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { jsonData })}";
            }
            catch (Exception e)
            {
                responseStr = $@"0|TYService.Index.{functionName} 未找到 请确认在程序根目录存在TYService.dll 并且其中Index类中存在方法{functionName}";
            }
            return responseStr;
        }

        public string Test(string txt)
        {
            return "true " + txt;
        }
    }
}
