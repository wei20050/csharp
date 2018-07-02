using System;
using TYModel;
using TYDB;
using TYPublicCore;
using System.Collections.Generic;

namespace TYService
{
    public class Index
    {
        public static string Test(string json)
        {
            Console.WriteLine(json);
            return "Test";
        }
        public static string GetRen(string json)
        {
            var r = TyConvert.JsonToObj<Ren>(json);
            var values = new Dictionary<string, object>
            {
                { "@id", r.id }
            };
            var sql = "select * from ren where id = @id";
            if (r.id == 0)
            {
                sql = "select * from ren";
            }
            var ds = TySqLite.Query(sql, values);
            var lr = TyConvert.DataTableTo<Ren>(ds.Tables[0]);
            return TyConvert.ObjToJson(lr);
        }
    }
}
