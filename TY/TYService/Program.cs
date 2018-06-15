using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TYModel;
using TYPublicCore;
using TYServiceCore;
namespace TYService
{
    class Program
    {
       
        static void Main(string[] args)
        {
            SQLite.dataBasePath = @"D:\000zGit\csharp\TY\mydb.db";
            Program p = new Program();
            Core.DeleteExit();
            Udp udp = new Udp();
            udp._main += p.Index;
            udp.ServiceOpen();
        }
        public void Index(string clientRequest, out string responseStr)
        {
            responseStr = string.Empty;
            var tmp = clientRequest.Split('|');
            if (tmp.Length != 2)
            {
                return;
            }
            else
            {
                switch (tmp[0])
                {
                    case nameof(Test):
                        responseStr = Test(tmp[1]);
                        break;
                    case nameof(GetRen):
                        responseStr = GetRen(tmp[1]);
                        break;
                    default:
                        break;
                }
            }
        }
        //测试方法
        public string Test(string json)
        {
            Console.WriteLine(json);
            return "Test";
        }
        public string GetRen(string json)
        {
            //Ren r = Json.JsonToObj<Ren>(json);
            //string where = r.id == 0 ? " and id = " + r.id : "";
            var ds = SQLite.Query("select * from ren");
            List<Ren> lr = new List<Ren>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Ren ren = new Ren
                {
                    id = Convert.ToInt32(item["id"]),
                    name = item["name"].ToString(),
                    age = Convert.ToInt32(item["age"]),
                    sfzhm = item["sfzhm"].ToString()
                };
                lr.Add(ren);
            }
            return Json.ObjToJson(lr);
        }
    }
}
