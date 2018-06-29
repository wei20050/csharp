using System;
using TYModel;
using TYDB;
using TYPublicCore;

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
            var where = r.id == 0 ? "" : " and id = " + r.id;
            var ds = TySqLite.Query("select * from ren where 1 = 1 " + where);
            var a = ds.Tables[0];
            var b = a.Rows[0][1];

            var lr = TyConvert.DataTableTo<Ren>(ds.Tables[0]);
            return TyConvert.ObjToJson(lr);
        }
    }
}
