功能 wlog(txt)
    文件写日志(txt, "d:/log.txt")
结束
功能 add(key, value)
    返回 动态库调用("rc:t.dll", "char *", "add", "char *", key, "char *", value)
结束
功能 del(key)
    返回 动态库调用("rc:t.dll", "char *", "del", "char *", key)
结束
功能 upd(key, newkey)
    返回 动态库调用("rc:t.dll", "char *", "upd", "char *", key, "char *", newkey)
结束
功能 get(key)
    返回 动态库调用("rc:t.dll", "char *", "get", "char *", key)
结束
功能 list(key)
    返回 动态库调用("rc:t.dll", "char *", "list", "char *", key)
结束
功能 delall(keys)
    变量 keyarr
    字符串分割(keys, "~", keyarr)
    遍历(变量 i = 0; i < 数组大小(keyarr); i++)
        变量 ret = del(keyarr[i])
        如果(ret != 204)
            del(keyarr[i])
        结束
    结束
结束
功能 set8User(userinfo)
    变量 userstr = "user/(" & userinfo[0] & "),(" & userinfo[1] & "),(" & userinfo[2] & "),(" & userinfo[3] & "),(" & userinfo[4] & "),(" & userinfo[5] & "),(" & userinfo[6] & "),(" & userinfo[7] & ")"
    变量 retarr
    字符串分割(add(userstr, ""), "_", retarr)
    如果(retarr[0] != 200)
        等待(666)
        字符串分割(add(userstr, ""), "_", retarr)
        如果(retarr[0] != 200)
            wlog(userstr)
            返回 假
        否则
            返回 真
        结束
    否则
        返回 真
    结束
结束
功能 get8User(uid)
    变量 struser = list("user/(" & uid & ")")
    struser = 字符串替换(struser, "(", "")
    struser = 字符串替换(struser, ")", "")
    struser = 字符串替换(struser, "user/", "")
    返回 struser
结束
功能 getUser()
    变量 struser = list("user")
    struser = 字符串替换(struser, "(", "")
    struser = 字符串替换(struser, ")", "")
    struser = 字符串替换(struser, "user/", "")
    返回 struser
结束
功能 set3cami(userinfo)
    变量 userstr = "cami/(" & userinfo[0] & "),(" & userinfo[1] & "),(" & userinfo[2] & ")"
    变量 retarr
    变量 ret = add(userstr, "")
    字符串分割(ret, "_", retarr)
    如果(retarr[0] != 200)
        等待(666)
        字符串分割(add(userstr, ""), "_", retarr)
        如果(retarr[0] != 200)
            wlog(userstr)
            返回 假
        否则
            返回 真
        结束
    否则
        返回 真
    结束
结束
功能 get3cami(ukey)
    变量 struser = list("cami/(" & ukey & ")")
    struser = 字符串替换(struser, "(", "")
    struser = 字符串替换(struser, ")", "")
    struser = 字符串替换(struser, "cami/", "")
    返回 struser
结束
功能 getcami()
    变量 struser = list("cami")
    struser = 字符串替换(struser, "(", "")
    struser = 字符串替换(struser, ")", "")
    struser = 字符串替换(struser, "cami/", "")
    返回 struser
结束
功能 set5Log(userinfo)
    变量 userstr = "log/(" & userinfo[0] & "),(" & userinfo[1] & "),(" & userinfo[2] & "),(" & userinfo[3] & "),(" & userinfo[4] & ")"
    变量 retarr
    字符串分割(add(userstr, ""), "_", retarr)
    如果(retarr[0] != 200)
        等待(666)
        字符串分割(add(userstr, ""), "_", retarr)
        如果(retarr[0] != 200)
            wlog(userstr)
            返回 假
        否则
            返回 真
        结束
    否则
        返回 真
    结束
结束
功能 getLog(uid = "")
    变量 struser
    如果(uid == "")
        struser = list("log/")
    否则
        struser = list("log/(1),("& uid &")")
    结束
    struser = 字符串替换(struser, "(", "")
    struser = 字符串替换(struser, ")", "")
    struser = 字符串替换(struser, "log/", "")
    返回 struser
结束
功能 setConfig(uid, txt)
    变量 retarr
    字符串分割(add("config/(" & uid & ")", txt), "_", retarr)
    如果(retarr[0] != 200)
        等待(666)
        字符串分割(add("config/(" & uid & ")", txt), "_", retarr)
        如果(retarr[0] != 200)
            wlog(uid)
            返回 假
        否则
            返回 真
        结束
    否则
        返回 真
    结束
结束
功能 getConfig(uid)
    返回 get("config/(" & uid & ")")
结束