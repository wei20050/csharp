using System;
using System.Collections.Generic;
using TYExPublicCore;
using TYExService.Dal;
using TYModel;

namespace TYExService
{
    public class Index
    {
        public static string Test(string json)
        {
            var objs = TyConvert.JsonToObj<object[]>(json);
            Console.WriteLine(objs[0] + objs[1].ToString());
            return $"Test:{objs[0]}:{objs[1]}";
        }

        public static string GetTemplateList(string json)
        {
            var objs = TyConvert.JsonToObj<object[]>(json);
            var t = TyConvert.JsonToObj<BS_Template>(objs[0].ToString());
            var td = new TemplateDal();
            var bsTemplateList = td.GetList(t, (int) objs[1], (int) objs[2], out var rows);
            return TyConvert.ObjToJson(new[] {rows.ToString(), TyConvert.ObjToJson(bsTemplateList)});
        }
        public static string TestInsert(string json)
        {
            var td = new TemplateDal();
            td.TestInsert();
            return json;
        }
        public static string TestUpdate(string json)
        {
            var lb = TyConvert.JsonToObj<List<BS_Template>>(json);
            var td = new TemplateDal();
            td.TestUpdate(lb);
            return "true";
        }
        public static string TestDelete(string json)
        {
            var lb = TyConvert.JsonToObj<string[]>(json);
            var td = new TemplateDal();
            td.TestDelete(lb);
            return "true";
        }
    }
}
