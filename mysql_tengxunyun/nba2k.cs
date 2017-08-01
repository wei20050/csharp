using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mysql_tengxunyun
{
    public class nba2k
    {
        public static user GetUser(string uid)
        {
            user u = new user();
            List<string> ls = new List<string>();
            int ret = Cos.Get_B("<" + uid + ">", out ls);
            if (ret == 200)
            {
                string ostr = "";
                ret = Cos.Get(ls[0], out ostr);
                if (ret == 200)
                {
                    string[] key = ls[0].Replace(@"user/", "").Replace("<", "").Replace(">", "").Split(',');
                    string[] value = ostr.Split(',');
                    u.uid = uid;
                    u.regtime = key[1];
                    u.pwd = value[0];
                    u.endtime = value[1];
                    u.utime = value[2];
                    u.sunum = value[3];
                    u.unum = value[4];
                    u.mcode = value[5];
                }
            }
            return u;
        }
    }
}
