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
            Console.WriteLine(json);
            return $"Test:{json}";
        }

        public static string GetTemplateList(string json)
        {
            var jsons = json.Split('|');
            var bsTemplate = TyConvert.JsonToObj<BS_Template>(jsons[0]);
            var td = new TemplateDal();
            var bsTemplateList = td.GetList(bsTemplate, Convert.ToInt32(jsons[1]), Convert.ToInt32(jsons[2]), out var rows);
            return rows + "|" + TyConvert.ObjToJson(bsTemplateList);
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
            var lb = TyConvert.JsonToObj<List<BS_Template>>(json);
            var td = new TemplateDal();
            td.TestDelete(lb);
            return "true";
        }
    }
}
