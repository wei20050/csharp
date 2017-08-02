namespace mysql_tengxunyun
{
    public class nba2k
    {
       
        public static bool AddUser(user u)
        {
            string msg;
            int ret = Cos.Add(string.Format(@"user/({0}),({1}),({2}),({3}),({4}),({5}),({6}),({7})", u.uid,u.regtime,u.pwd,u.endtime,u.utime,u.sunum,u.unum,u.mcode), "", out msg);
            if (ret == 200)
            {
                return true;
            }
            else
            {
                Common.WLog("AddUser ：" + ret + " : " + msg);
                return false;
            }
        }
        public static bool DelUser(string uid)
        {
            return 204 == Cos.Del(Cos.find(@"user/(" + uid + ")"));
        }
        public static bool SetUser(user u)
        {
            string ret = Cos.find(@"user/(" + u.uid + ")");
            if (ret != "")
            {
                string[] usern = ret.Replace(@"user/", "").Replace("(", "").Replace(")", "").Split(',');
                u.regtime = Common.EmptyToStr(u.regtime, usern[1]);
                u.pwd = Common.EmptyToStr(u.pwd, usern[2]);
                u.endtime = Common.EmptyToStr(u.endtime, usern[3]);
                u.utime = Common.EmptyToStr(u.utime, usern[4]);
                u.sunum = Common.EmptyToStr(u.sunum, usern[5]);
                u.unum = Common.EmptyToStr(u.unum, usern[6]);
                u.mcode = Common.EmptyToStr(u.mcode, usern[7]);
                if (AddUser(u))
                {
                    if (Cos.Del(ret) == 204)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static user GetUser(string uid)
        {
            user u = new user();
            string ret = Cos.find(@"user/(" + uid + ")");
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
