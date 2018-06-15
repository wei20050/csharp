using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace TYPublicCore
{

    public class Json
    {
        //将JSON数据转化为对应的类型  
        public static T JsonToObj<T>(string JSONStr)
        {
            try
            {
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(JSONStr)))
                {
                    return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(ms);
                }
            }
            catch (System.Exception ex)
            {
                Log.Wlog(ex);
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
    }
}