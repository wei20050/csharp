功能 验证()
    变量 ret = 是否注册("dm.dmsoft")
    如果(!ret)
        变量 retdm = 注册插件("rc:dm.dll", 真)
        如果(retdm == 假)
            p("对不起您的系统权限不足,无法使用本软件,请尝试右键管理员身份运行!")
            退出()
        结束
    结束
    dmz = 插件("dm.dmsoft")
    控件模态窗口("登录界面")
结束
功能 按(key, dm)
    dm.KeyDown(key)
结束
功能 弹(key, dm)
    dm.KeyUp(key)
结束
功能 键(key, dm)
    dm.KeyPress(key)
结束
功能 等(ms)
    等待(ms)
结束
功能 悬浮窗创建()
    悬浮窗ID = dmz.CreateFoobarRect(0, 200, 200, 230, 100)
    dmz.SetWindowTransparent(悬浮窗ID, 200)
    dmz.FoobarSetFont(悬浮窗ID, "微软雅黑", 11, 1)
    dmz.FoobarTextRect(悬浮窗ID, 5, 5, 300, 100)
结束
功能 悬浮窗写字()
    变量 左右 = "左"
    如果(是否左右)
        左右 = "右"
    结束
    变量 h1, h2, h3, h4, h5, h6, h7, h
    热键获取键码("rj_ycjs", h1, h)
    热键获取键码("rj_yczj", h2, h)
    热键获取键码("rj_tlsjjs", h3, h)
    热键获取键码("rj_tlsjzj", h4, h)
    热键获取键码("rj_dzsjjs", h5, h)
    热键获取键码("rj_dzsjzj", h6, h)
    热键获取键码("rj_xggbzy", h7, h)
    dmz.FoobarPrintText(悬浮窗ID, "高级投篮:" & 编辑框获取文本("bj_dqyc") & "毫秒" & GetKeyName(h1) & "" & GetKeyName(h2) & "\r\n鬼步投篮:" & 编辑框获取文本("编辑框14") & "毫秒" & GetKeyName(h3) & "" & GetKeyName(h4) & "\r\n鬼步动作:" & 编辑框获取文本("编辑框29") & "毫秒" & GetKeyName(h5) & "" & GetKeyName(h6) & "\r\n当前动作方向:" & 左右 & "" & GetKeyName(h7), "ff0000")
结束
功能 悬浮窗关闭()
    dmz.FoobarClose(悬浮窗ID)
结束
//服务器相关---------------------------------------------------------------------------------------------
功能 getUrl(urlStr)
    变量 内容 = http获取页面源码(urlStr, "utf-8")
    返回 内容
结束
功能 登录(musername, mpwd, mcode)
    变量 username = 字符串修剪(musername)
    变量 password = 字符串修剪(mpwd)
    如果(username == "")
        返回 "会员号不能为空!|8|8"
    结束
    如果(password == "") 
        返回 "密码不能为空!|8|8"
    否则
        password = md5(password)
    结束
    变量 retarr
    userEdit(username)
    字符串分割(get8User(username), "_", retarr)
    如果(retarr[0] == 403)
        字符串分割(get8User(username), "_", retarr)
    结束
    如果(retarr[0] == 403)
        返回 "网络连接错误,请重新登录!|8|8"
    否则
        如果(retarr[0] == 200)
            如果(retarr[1] == "")
                返回 "账号不存在!|8|8"
            否则
                变量 user
                字符串分割(retarr[1], ",", user)
                变量 upwd = user[1]
                变量 uregtime = user[2]
                变量 uendtime = user[3]
                变量 uunum = user[6]
                变量 ucode = user[7]
                如果(upwd != password)
                    返回 "密码错误,请重新登录!|8|8"
                结束
                如果(mcode != ucode)
                    如果(ucode == "")
                        变量 okey = "user/(" & user[0] & "),(" & user[1] & "),(" & user[2] & "),(" & user[3] & "),(" & user[4] & "),(" & user[5] & "),(" & user[6] & "),(" & user[7] & ")"
                        user[7] = mcode
                        变量 nkey = "user/(" & user[0] & "),(" & user[1] & "),(" & user[2] & "),(" & user[3] & "),(" & user[4] & "),(" & user[5] & "),(" & user[6] & "),(" & user[7] & ")"
                        如果(okey == nkey)
                            返回 "登陆失败,获取机器码失败!|8|8"
                        结束
                        如果(upd(okey, nkey) != 204)
                            如果(upd(okey, nkey) != 204)
                                返回 "登陆失败,网络连接中断!|8|8"
                            结束
                        结束
                        如果(uendtime == "admin")
                            如果(uregtime == "admin")
                                返回 " 管理员永不过期! 当天解锁次数:" & uunum & "次|6|NBA2K顶级管理"
                            否则
                                返回 " 永不过期! 当天解锁次数:" & uunum & "次|6|NBA2K永久会员"
                            结束
                        结束
                        如果(时间间隔("s", 当前时间(), uendtime) < 0)
                            返回 "您的会员期限已到期,请充值!|8|8"
                        结束	
                        返回 " " & uendtime & " 当天解锁次数:" & uunum & "次|6|普通会员"
                    结束
                    返回 "您的机器码与常用机器码不符,请点击解绑!|8|8"
                结束	
                如果(uendtime == "admin")
                    如果(uregtime == "admin")
                        返回 " 管理员永不过期! 当天解锁次数:" & uunum & "次|6|NBA2K顶级管理"
                    否则
                        返回 " 永不过期! 当天解锁次数:" & uunum & "次|6|NBA2K永久会员"
                    结束
                结束
                如果(时间间隔("s", 当前时间(), uendtime) < 0)
                    返回 "您的会员期限已到期,请充值!|8|8"
                结束	
                返回 " " & uendtime & " 当天解锁次数:" & uunum & "次|6|普通会员"
            结束
        否则
            返回 "服务器异常,请重新登录!|8|8"
        结束
    结束
结束
功能 注册_充值(musername, mpwd, mcode, mukey)
    变量 username = 字符串修剪(musername)
    变量 password = 字符串修剪(mpwd)
    mukey = 字符串修剪(mukey)
    变量 day
    如果(username == "")
        返回 "会员号不能为空!|8|8"
    结束
    如果(password == "") 
        返回 "密码不能为空!|8|8"
    否则
        password = md5(password)
    结束
    如果(mukey == "")
        返回 "卡密不能为空!|8|8"
    结束
    变量 retarr
    字符串分割(get3cami(mukey), "_", retarr)
    如果(retarr[0] == 403)
        字符串分割(get3cami(mukey), "_", retarr)
    结束
    如果(retarr[0] == 403)
        返回 "网络连接错误,请重试!|8|8"
    结束
    如果(retarr[0] == 200 && retarr[1] == "")
        返回 "对不起卡密不正确,请检查是否输入有误或卡密已经被使用!|8|8"
    结束
    如果(retarr[0] != 200)
        返回 "服务器异常,请联系管理!|8|8"
    结束
     userEdit(username)
    变量 ucami
    字符串分割(retarr[1], ",", ucami)
    day = ucami[2]
    字符串分割(get8User(username), "_", retarr)
    如果(retarr[0] == 403)
        字符串分割(get8User(username), "_", retarr)
    结束
    如果(retarr[0] == 403)
        返回 "网络连接错误,请重试!|8|8"
    否则
        uid = username
        如果(retarr[0] == 200)
            如果(retarr[1] == "")
                变量 userinfo = 数组(username, password, 字符串替换(当前时间(), "/", "-"), 字符串替换(指定时间("d", day, 当前时间()), "/", "-"), "", "0", "0", "")
                如果(day == 3000)
                    userinfo = 数组(username, password, 字符串替换(当前时间(), "/", "-"), "admin", "", "0", "0", "")
                结束
                如果(set8User(userinfo))
                    cuser(1, ucami)
                    返回 "已自动为您创建会员:" & username & ",并且充值成功!|6|8"
                结束
                如果(set8User(userinfo))
                    cuser(1, ucami)
                    返回 "已自动为您创建会员:" & username & ",并且充值成功!|6|8"
                结束
                返回 "网络连接失败,请重试!|8|8"
            否则
                变量 userarr
                字符串分割(retarr[1], ",", userarr)
                如果(userarr[1] != password)
                    返回  "密码错误,请不要误充值给别人哦!|8|8"
                结束
                如果(userarr[3] == "admin")
                    返回 "您过期时间是永久,无需充值!|6|8"
                结束
                变量 okey = "user/(" & userarr[0] & "),(" & userarr[1] & "),(" & userarr[2] & "),(" & userarr[3] & "),(" & userarr[4] & "),(" & userarr[5] & "),(" & userarr[6] & "),(" & userarr[7] & ")"
                如果(时间间隔("n", 当前时间(), userarr[3]) < 0)
                    userarr[3] = 字符串替换(指定时间("d", day, 当前时间()), "/", "-") 
                否则
                    userarr[3] = 字符串替换(指定时间("d", day, userarr[3]), "/", "-")
                结束
                如果(day == 3000)
                    userarr[3] = "admin"
                结束
                变量 nkey = "user/(" & userarr[0] & "),(" & userarr[1] & "),(" & userarr[2] & "),(" & userarr[3] & "),(" & userarr[4] & "),(" & userarr[5] & "),(" & userarr[6] & "),(" & userarr[7] & ")"
                如果(upd(okey, nkey) == 204)
                    cuser(1, ucami)
                    返回 "恭喜您充值成功!|6|8"
                否则
                    如果(upd(okey, nkey) == 204)
                        cuser(1, ucami)
                        返回 "恭喜您充值成功!|6|8"
                    否则
                        返回 "网络错误,充值失败!"
                    结束
                结束
            结束
        否则
            返回 "网络连接错误,服务器错误!|8|8"
        结束
    结束
结束
功能 cuser(type, camiarr)
    变量 key = "cami/(" & camiarr[0] & "),(" & camiarr[1] & "),(" & camiarr[2] & ")"
    del(key)
    del(key)
    del(key)
    del(key)
    del(key)
    set5Log(数组(type, uid, 字符串替换(当前时间(), "/", "-"), camiarr[2], camiarr[0] & "-" & camiarr[1]))
结束
功能 解绑(musername, mpwd, mcode)
    变量 username = 字符串修剪(musername)
    变量 password = 字符串修剪(mpwd)
    如果(username == "")
        返回 "会员号不能为空!|8|8"
    结束
    如果(password == "") 
        返回 "密码不能为空!|8|8"
    否则
        password = md5(password)
    结束
    变量 retarr
    变量 okey
    字符串分割(list("user/(" & username & ")"), "_", retarr)
    如果(retarr[0] != 200)
        字符串分割(list("user/(" & username & ")"), "_", retarr)
        如果(retarr[0] != 200)
            返回 "解绑失败,账户查询失败!|8|8"
        否则
            如果(retarr[1] == "")
                返回 "解绑失败,账号不存在!|8|8"
            结束
        结束
    结束
    userEdit(username)
    okey = retarr[1]
    变量 user = okey
    user = 字符串替换(user, "(", "")
    user = 字符串替换(user, ")", "")
    user = 字符串替换(user, "user/", "")
    变量 userinfo
    字符串分割(user, ",", userinfo)
    如果(userinfo[1] != password)
        返回 "密码错误,请重新输入密码!|8|8"
    结束
    如果(userinfo[7] == mcode)
        返回 "当前电脑机器码完全符合,为防止误操作扣时,此次解绑无效!|8|8"
    结束
    如果(userinfo[2] == "admin" && userinfo[3] == "admin")
        返回 解绑n(okey, userinfo, mcode)
    结束
    如果(时间间隔("s", 当前时间(), userinfo[3]) < 0)
        返回 "您的会员期限已到期,请充值!|8|8"
    结束		
    返回 解绑n(okey, userinfo, mcode)
结束
功能 解绑n(mokey, muser, mcode)
    变量 at = 当前时间()
    变量 ntime = 时间年(at) & get1to2(时间月(at)) & get1to2(时间日(at))
    如果(ntime == muser[4])
        如果(muser[6] > 2)
            如果(muser[3] == "admin") 
                返回 "永久会员今日解绑次数超过两次，请联系管理员强制解锁!|8|8"
            结束
        否则
            muser[3] = 字符串替换(指定时间("h", -4, muser[3]), "/", "-")
        结束
        muser[5] = muser[5] + 1
        muser[6] = muser[6] + 1
        muser[7] = mcode
    否则
        如果(muser[3] != "admin") 
            muser[3] = 字符串替换(指定时间("h", -4, muser[3]), "/", "-")
        结束
        muser[4] = ntime
        muser[5] = muser[5] + 1
        muser[6] = 1
        muser[7] = mcode
    结束
    变量 nkey = "user/(" & muser[0] & "),(" & muser[1] & "),(" & muser[2] & "),(" & muser[3] & "),(" & muser[4] & "),(" & muser[5] & "),(" & muser[6] & "),(" & muser[7] & ")"
    变量 ret = upd(mokey, nkey)
    如果(ret == 204)
        返回 "解除绑定成功!|6|8"
    否则
        如果(upd(mokey, nkey) == 204)
            返回 "解除绑定成功!|6|8"
        否则
            返回 "网络错误,解绑失败请重试!"
        结束
    结束
结束
功能 userEdit(euid)
    变量 retarr
    字符串分割(list("user/(" & euid & ")"), "_", retarr)
    如果(retarr[0] == 200)
        返回 userEdit2(retarr[1])
    结束
    字符串分割(list(euid), "_", retarr)
    如果(retarr[0] == 200)
        返回 userEdit2(retarr[1])
    结束
    字符串分割(list(euid), "_", retarr)
    如果(retarr[0] == 200)
        返回 userEdit2(retarr[1])
    结束
    返回 -1
结束
功能 userEdit2(users)
    如果(users == "")
        返回 0
    结束
    变量 userarr
    字符串分割(users, "~", userarr)
    变量 arrl = 数组大小(userarr)
    如果(arrl > 1)
        遍历(变量 i = 0; i < arrl - 1; i++)
            del(userarr[i])
            等待(100)
            del(userarr[i])	
        结束
    结束
结束
功能 get1to2(num)
    如果(字符串长度(num) == 1)
        返回 "0" & num
    结束
    返回 num
结束
功能 UpCfg()
    变量 txt = 字符串替换(文件读取内容(配置路径), "\r\n", "!")
    变量 页码 = 上传(txt)
    如果(页码 != "")
        变量 infos
        变量 count = 字符串分割(页码, "|", infos)
        如果(count == 3)
            p(infos[0])
        否则
            p("服务器连接失败,请检查网络!")
        结束
    否则
        p("服务器连接失败,请检查网络!")
    结束
结束
功能 DpCfg()
    变量 页码 = 下载()
    如果(页码 != "")
        变量 infos
        变量 count = 字符串分割(页码, "|", infos)
        如果(count == 3)
            如果(infos[1] != 0)
                变量 txt = 字符串替换(infos[1], "!", "\r\n")
                如果(文件覆盖内容(配置路径, txt))
                    RC()
                    p(infos[0])
                否则
                    p("服务器配置写入本地失败,请尝试右键管理员方式打开软件!")
                结束	
            否则
                p(infos[0])
            结束
        否则
            p("服务器连接失败,请检查网络!")
        结束
    否则
        p("服务器连接失败,请检查网络!")
    结束
结束
功能 上传(txt)
    //    变量 post_url = "http://tianyu.vicp.io/yz/index.php/Vu/Index/up"
    //    变量 ret = setConfig(uid, txt)
    //    变量 mode = "post"
    //    变量 senddata = "username=" & uid & "&txt=" & txt
    //    变量 head = array()
    //    变量 post_response = ""
    //    变量 post_ret = ""
    //    post_ret = httpsubmit(mode, post_url, senddata, "", head, post_response)
    //    //messagebox(post_response) //响应头
    //    返回 url解码(post_ret, "utf-8")
    如果(setConfig(uid, txt))
        返回 "上传成功！|0|0"
    否则
        返回 "403"
    结束
结束
功能 下载()
    //    变量 post_url = "http://tianyu.vicp.io/yz/index.php/Vu/Index/dp"
    //    变量 mode = "post"
    //    变量 senddata = "username=" & uid
    //    变量 head = array()
    //    变量 post_response = ""
    //    变量 post_ret = ""
    //    post_ret = httpsubmit(mode, post_url, senddata, "", head, post_response)
    //    //messagebox(post_response) //响应头
    //    返回 url解码(post_ret, "utf-8")
    变量 retarr
    字符串分割(getConfig(uid), "_", retarr)
    如果(retarr[0] == 404)
        返回  "下载失败,当前用户没有上传过配置！|0|0"
    结束
    如果(retarr[0] == 200)
        返回  "下载成功!|" & retarr[1] & "|0"
    结束
    如果(retarr[0] == 200)
        返回  "下载成功!|" & retarr[1] & "|0"
    结束
    返回  "下载失败,网络连接错误|0|0"
结束
//服务器相关---------------------------------------------------------------------------------------------