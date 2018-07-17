using System;
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
            var bsTemplateList = td.GetList(bsTemplate, jsons[1], jsons[2], out var rows);
            return rows + "|" + TyConvert.ObjToJson(bsTemplateList);
        }
    }
}
