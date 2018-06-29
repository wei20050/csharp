using System;
using System.Collections.Generic;
using TYModel;
using TYPublicCore;
using TYServiceCore;

namespace TYService
{
    public class Index
    {
        public static void _main(string FunctionName, string JsonData, out string responseStr)
        {
            responseStr = string.Empty;
            switch (FunctionName)
            {
                case nameof(Test):
                    responseStr = Test(JsonData);
                    break;
                case nameof(GetRen):
                    responseStr = GetRen(JsonData);
                    break;
                default:
                    break;
            }
        }
        //测试方法
        public static string Test(string json)
        {
            Console.WriteLine(json);
            return "Test";
        }
        public static string GetRen(string json)
        {
            Ren r = TYConvert.JsonToObj<Ren>(json);
            string where = r.id == 0 ? "" : " and id = " + r.id;
            var ds = TYSQLite.Query("select * from ren where 1 = 1 " + where);
            List<Ren> lr = TYConvert.DataTableTo<Ren>(ds.Tables[0]);
            return TYConvert.ObjToJson(lr);
        }
    }
}
