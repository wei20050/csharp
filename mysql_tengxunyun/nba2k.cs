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
            string ret = Cos.find("<" + uid + ">");
            if (ret != "")
            {
                string[] usern = ret.Replace(@"user/", "").Replace("(", "").Replace(")", "").Split(',');
                u.uid = uid;
                u.regtime = usern[1];
                u.pwd = usern[2];
                u.endtime = usern[3];
                u.utime = usern[4];
                u.sunum = usern[5];
                u.unum = usern[6];
                u.mcode = usern[7];
            }
            return u;
        }
    }
}
