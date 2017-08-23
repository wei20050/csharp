功能 user_bind(uid)
    变量 userstr = getUser()
    变量 retarr
    变量 userarr = 数组()
    字符串分割(userstr, "_", retarr)
    如果(retarr[0] == 200)
        字符串分割(retarr[1], "~", retarr)
    否则
        返回 null
    结束
    变量 x = 0
    遍历(变量 i = 0; i < 数组大小(retarr); i++)
        变量 userarrn
        字符串分割(retarr[i], ",", userarrn)
        如果(字符串查找(userarrn[0], uid) != -1 || uid == "")
            如果(userarrn[2] == "admin")
                userarrn[2] = "软件完工第一天"
            结束
            如果(userarrn[3] == "admin")
                userarrn[3] = "永不过期"
            结束
            变量 arrn = 数组("会员ID" = userarrn[0], "注册时间" = userarrn[2], "到期时间" = userarrn[3], "最后解锁时间" = userarrn[4], "总计解锁次数" = userarrn[5], "当天解锁次数" = userarrn[6])
            userarr[x] = arrn
            x = x + 1
        结束
    结束
    表格填充数据集("表格_会员", userarr)
结束
功能 log_bind(uid, ukey, time0, time1)
    变量 logstr = getLog()
    变量 retarr
    变量 logarr = 数组()
    字符串分割(logstr, "_", retarr)
    如果(retarr[0] == 200)
        字符串分割(retarr[1], "~", retarr)
    否则
        返回 null
    结束
    变量 x = 0
    变量 banyue = 0, yue = 0, bannian = 0, nian = 0, yongjiu = 0
    遍历(变量 i = 0; i < 数组大小(retarr); i++)
        变量 logarrn
        字符串分割(retarr[i], ",", logarrn)
        变量 msgarr
        字符串分割(logarrn[4], "-", msgarr)
        变量 isshow = -1
        如果(单选框获取状态("单选框2"))
            isshow = 2
        结束
        如果(单选框获取状态("单选框1") && logarrn[3] != 15 && logarrn[3] != 30 && logarrn[3] != 180 && logarrn[3] != 366 && logarrn[3] != 3000)
            isshow = 1
        结束
        如果(单选框获取状态("单选框0") && (logarrn[3] == 15 || logarrn[3] == 30 || logarrn[3] == 180 || logarrn[3] == 366 || logarrn[3] == 3000))
            isshow = 0
        结束
        如果(isshow > -1)
            如果((字符串查找(logarrn[1], uid) != -1 || uid == "") && (字符串查找(msgarr[0], ukey) != -1 || ukey == "") && 时间间隔("h", time0 & " 00:00:00", logarrn[2]) > 0 && 时间间隔("h", time1 & " 23:59:59", logarrn[2]) < 0)
                变量 arrn = 数组("序号" = x + 1, "会员ID" = logarrn[1], "充值时间" = logarrn[2], "卡密天数" = logarrn[3], "卡密" = msgarr[0], "发卡人ID" = msgarr[1])
                logarr[x] = arrn
                x = x + 1
                如果(isshow == 0)
                    选择(logarrn[3])
                        条件 15
                        banyue = banyue + 1
                        条件 30
                        yue = yue + 1
                        条件 180
                        bannian = bannian + 1
                        条件 366
                        nian = nian + 1
                        条件 3000
                        yongjiu = yongjiu + 1
                    结束
                结束
            结束
        结束
    结束
     printBB(banyue, yue, bannian, nian, yongjiu)
    表格填充数据集("表格_记录", logarr)
结束
功能 printBB(banyue, yue, bannian, nian, yongjiu)
    变量 strs = "充值数量=> 半月卡: " & banyue & " 张  月卡: " & yue & " 张  半年卡: " & bannian & " 张  年卡: " & nian & " 张  永久卡: " & yongjiu & " 张"
    变量 strq = "充值金额=> 半月卡: " & banyue * 12 & " 元  月卡: " & yue * 20 & " 元  半年卡: " & bannian * 90 & " 元  年卡: " & nian * 180 & " 元  永久卡: " & yongjiu * 500 & " 元"
    标签设置文本("标签_财务报表数", strs)
    标签设置文本("标签_财务报表钱", strq)
结束
功能 cami_bind(ukey)
    变量 camistr = getcami()
    变量 retarr
    变量 camiarr = 数组()
    字符串分割(camistr, "_", retarr)
    如果(retarr[0] == 200)
        字符串分割(retarr[1], "~", retarr)
    否则
        返回 null
    结束
    变量 x = 0
    遍历(变量 i = 0; i < 数组大小(retarr); i++)
        变量 camiarrn
        字符串分割(retarr[i], ",", camiarrn)
        如果(字符串查找(camiarrn[0], ukey) != -1 || ukey == "")
            变量 arrn = 数组("卡密" = camiarrn[0], "发卡人ID" = camiarrn[1], "卡密天数" = camiarrn[2])
            camiarr[x] = arrn
            x = x + 1
        结束
    结束
    表格填充数据集("表格_卡密", camiarr)
结束
功能 savepwd(uid, pwd)
    变量 retarr
    变量 okey
    字符串分割(list("user/(" & uid & ")"), "_", retarr)
    如果(retarr[0] != 200)
        字符串分割(list("user/(" & uid & ")"), "_", retarr)
        如果(retarr[0] != 200)
            消息框("修改失败,查询原密码失败!")
            返回
        结束
    结束
    okey = retarr[1]
    变量 user = okey
    user = 字符串替换(user, "(", "")
    user = 字符串替换(user, ")", "")
    user = 字符串替换(user, "user/", "")
    变量 userinfo
    字符串分割(user, ",", userinfo)
    userinfo[1] = md5(pwd)
    变量 nkey = "user/(" & userinfo[0] & "),(" & userinfo[1] & "),(" & userinfo[2] & "),(" & userinfo[3] & "),(" & userinfo[4] & "),(" & userinfo[5] & "),(" & userinfo[6] & "),(" & userinfo[7] & ")"
    如果(okey == nkey)
        消息框("修改失败,新密码与初始密码相同!")
        返回
    结束
    如果(upd(okey, nkey) == 204)
        消息框("修改成功,请使用新密码登录!")
        控件关闭子窗口("修改密码", 6)
        返回
    否则
        如果(upd(okey, nkey) == 204)
            消息框("修改成功,请使用新密码登录!")
            控件关闭子窗口("修改密码", 6)
            返回
        否则
            消息框("网络错误,修改失败请重试!")
            返回
        结束
    结束
结束