功能 p(str)
    对话框(str, "2k提示", 0, 真)
结束
功能 打断(dm)
    线程关闭(线程ID)
    线程标识 = 0
    线程ID = 0
    弹(上, dm)
    弹(下, dm)
    弹(左, dm)
    弹(右, dm)
    弹(投, dm)
    弹(板, dm)
    弹(传, dm)
    弹(加, dm)
    弹(掩, dm)
    弹(精, dm)
    弹(五, dm)
    弹(二, dm)
    弹(短, dm)
    弹(双, dm)
    弹(晃, dm)
    弹(一, dm)
    弹(三, dm)
    弹(故, dm)
结束
功能 初始化()
    如果(IsOk)
        p("非法登录!")
        退出()
    结束
    设置托盘("2K")
    变量 不是第一次吗 = 不是第一次()
    用户按键初始化()
    刷新左右()
    如果(不是第一次吗)
        RC()
    结束
    热键开启()
    默认功能名称()
    窗口是否加载 = 真
    如果(复选框获取状态("fx_xfckg"))
        悬浮窗创建()
        悬浮窗写字()
    否则
        悬浮窗关闭()
    结束
结束
功能 不是第一次()
    如果(文件读配置("root", "one", 配置路径) == "")
        文件写配置("root", "one", uid, 配置路径)
        默认时间配置()
        默认热键配置()
        返回 假
    否则
        返回 真
    结束
结束
功能 用户按键初始化()
    上 = 文件读配置("H1", "76", 配置路径)
    下 = 文件读配置("H1", "77", 配置路径)
    左 = 文件读配置("H1", "78", 配置路径)
    右 = 文件读配置("H1", "79", 配置路径)
    投 = 文件读配置("H1", "80", 配置路径)
    板 = 文件读配置("H1", "81", 配置路径)
    传 = 文件读配置("H1", "82", 配置路径)
    加 = 文件读配置("H1", "83", 配置路径)
    掩 = 文件读配置("H1", "84", 配置路径)
    精 = 文件读配置("H1", "85", 配置路径)
    五 = 文件读配置("H1", "86", 配置路径)
    二 = 文件读配置("H1", "87", 配置路径)
    短 = 文件读配置("H1", "88", 配置路径)
    双 = 文件读配置("H1", "89", 配置路径)
    晃 = 文件读配置("H1", "90", 配置路径)
    一 = 文件读配置("H1", "91", 配置路径)
    三 = 文件读配置("H1", "92", 配置路径)
    故 = 文件读配置("H1", "93", 配置路径)
结束
功能 热键开启()
    控件模态窗口("加载界面")
结束
功能 热键关闭()
    遍历(变量 i = 0; i < 75; i++)
        热键销毁("热键" & i)
    结束
结束
功能 高级热键关闭()
    热键销毁("rj_tlrj")
    热键销毁("rj_yczj")
    热键销毁("rj_ycjs")
    热键销毁("rj_tlsjjs")
    热键销毁("rj_tlsjzj")
    热键销毁("rj_dzsjzj")
    热键销毁("rj_dzsjjs")
结束
功能 默认时间配置()
    遍历(变量 i = 0; i < 120; i++)
        文件写配置("textBox", i, "700", 配置路径)
    结束
结束
功能 默认时间设置()
    遍历(变量 i = 0; i < 120; i++)
        编辑框设置文本("编辑框" & i, "700")
    结束
结束
功能 默认热键配置()
    设置配置(76, 101)
    设置配置(77, 98)
    设置配置(78, 97)
    设置配置(79, 99)
    设置配置(80, 68)
    设置配置(81, 65)
    设置配置(82, 83)
    设置配置(83, 16)
    设置配置(84, 69)
    设置配置(85, 70)
    设置配置(86, 90)
    设置配置(87, 88)
    设置配置(88, 79)
    设置配置(89, 81)
    设置配置(90, 87)
    设置配置(91, 67)
    设置配置(92, 86)
    设置配置(93, 80) 
结束
功能 设置配置(name, key, keyre = "0")
    文件写配置("H1", name, 转字符型(key), 配置路径)
    文件写配置("H2", name, 转字符型(keyre), 配置路径)
结束
功能 默认热键设置()
    设置热键(76, 101)
    设置热键(77, 98)
    设置热键(78, 97)
    设置热键(79, 99)
    设置热键(80, 68)
    设置热键(81, 65)
    设置热键(82, 83)
    设置热键(83, 16)
    设置热键(84, 69)
    设置热键(85, 70)
    设置热键(86, 90)
    设置热键(87, 88)
    设置热键(88, 79)
    设置热键(89, 81)
    设置热键(90, 87)
    设置热键(91, 67)
    设置热键(92, 86)
    设置热键(93, 80)  
结束
功能 设置热键(name, key, keyre = "")
    热键设置键码("热键" & name, key, keyre, "设置界面")
结束
功能 恢复默认()
    热键关闭()
    默认时间配置()
    默认时间设置()
    for(var i = 0; i < 75; i++)
        热键设置键码("热键" & i, "", 0)
        复选框设置状态("复选框" & i, 假)
    end
结束
功能 软件开关()
    如果(是否关闭)
        热键关闭()
        高级热键关闭()
        设置托盘气泡("软件热键已经全部关闭!", "2K提醒")
        是否关闭 = 假
    否则
        热键开启()
        设置托盘气泡("软件热键已经全部开启!", "2K提醒")
        是否关闭 = 真
    结束  
结束
功能 改变鬼步左右()
    如果(是否左右)
        是否左右 = 假
    否则
        是否左右 = 真
    结束  
    悬浮窗写字()
    刷新左右()
结束
功能 刷新左右()
    如果(是否左右)
        左s = 左
        右s = 右
    否则
        左s = 右
        右s = 左
    结束
结束
功能 延迟增加()
    如果(复选框获取状态("fx_tlkg"))
        编辑框设置文本("bj_dqyc", (编辑框获取文本("bj_dqyc") + 1))
    结束
结束
功能 延迟减少()
    如果(复选框获取状态("fx_tlkg"))
        编辑框设置文本("bj_dqyc", (编辑框获取文本("bj_dqyc") - 1))
    结束
结束
功能 投篮延迟增加()
    遍历(变量 i = 0; i < 数组大小(投篮时间组); i++)
        变量 nx = 编辑框获取文本("编辑框" & bjqh(投篮时间组[i]))
        编辑框设置文本("编辑框" & bjqh(投篮时间组[i]), nx + 1)
    结束
结束
功能 投篮延迟减少()
    遍历(变量 i = 0; i < 数组大小(投篮时间组); i++)
        变量 nx = 编辑框获取文本("编辑框" & bjqh(投篮时间组[i]))
        编辑框设置文本("编辑框" & bjqh(投篮时间组[i]), nx - 1)
    结束
结束
功能 动作延迟增加()
    遍历(变量 i = 0; i < 数组大小(动作时间组); i++)
        变量 nx = 编辑框获取文本("编辑框" & bjqh(动作时间组[i], 假))
        编辑框设置文本("编辑框" & bjqh(动作时间组[i], 假), nx + 5)
    结束
结束
功能 动作延迟减少()
    遍历(变量 i = 0; i < 数组大小(动作时间组); i++)
        变量 nx = 编辑框获取文本("编辑框" & bjqh(动作时间组[i], 假))
        编辑框设置文本("编辑框" & bjqh(动作时间组[i], 假), nx - 5)
    结束
结束
//改变延迟框修改延迟
功能 改变延迟(index)
    变量 bjktxt = 编辑框获取文本("编辑框" & index)
    设置延迟时间(index, bjktxt)
结束
功能 设置延迟时间(index, yc)
    文件写配置("textBox", index, yc, 配置路径)
结束
功能 bjqh(index, istl = 真)
    变量 n = 15
    if(istl)
        n = 0
    end
    变量 nx = 转整型(index / 15)
    return nx * 15 + index + n
结束
功能 取随机(n)
    返回 转整型(随机数(1, n))
结束
功能 左()
    返回 是否左右 == 假
结束
功能 右()
    返回 是否左右 == 真
结束
功能 动作(dzdelay, index, bs = 1)
    变量 delays = 文件读配置("textBox", bjqh(index, 假), 配置路径)
    变量 delay = (delays - 700) * bs + dzdelay
    等(delay)
结束
功能 投篮(index, dm)
    变量 delay = 文件读配置("textBox", bjqh(index), 配置路径)
    如果(delay != "0" && delay != "")
        按(投, dm)
        等(delay)
        弹(投, dm)
    结束
结束
功能 特殊投篮等(index)
    变量 delay = 文件读配置("textBox", bjqh(index), 配置路径)
    如果(delay != "0" && delay != "")
        等(delay)
    结束
结束
功能 高级投篮(dm)
    等(40)
    按(投, dm)
    等(文件读配置("gjtl", "dqyc", 配置路径))
    弹(投, dm)
    线程ID = 0
    线程标识 = 0
结束
//service stat
功能 add(key, value)
    返回 动态库调用("rc:t.dll", "char *", "add", "char *", key, "char *", value)
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
功能 getLog()
    变量 struser = list("log")
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
//service end
功能 GetKeyName(KeyValue)
    选择(KeyValue) 
        条件 37
        return "上"
        条件 38
        return "下"
        条件 39
        return "左"
        条件 40
        return "右"
        条件 8
        return "BackSpace"
        条件 9
        return "Tab"
        条件 13
        return "Enter"
        条件 16
        return "Shift"
        条件 17
        return "Ctrl"
        条件 19
        return "PauseBreak"
        条件 20
        return "CapsLock"
        条件 27
        return "Esc"
        条件 32
        return "Space"
        条件 33
        return "PageUp"
        条件 34
        return "PageDown"
        条件 35
        return "End"
        条件 36
        return "Home"
        条件 45
        return "Insert"
        条件 46
        return "Delete"
        条件 91
        return "Windows"
        条件 144
        return "NumLock"
        条件 145
        return "ScrollLock"
        条件 164
        return "左Alt"
        条件 165
        return "右Alt"
        条件 106
        return "Num*"
        条件 107
        return "Num+"
        条件 109
        return "Num-"
        条件 110
        return "Num."
        条件 111
        return "Num/"
        条件 187
        return "="
        条件 188
        return ","
        条件 189
        return "-"
        条件 190
        return "."
        条件 191
        return "/"
        条件 192
        return "`"
        条件 219
        return "["
        条件 220
        return "\\"
        条件 221
        return "]"
        条件 112
        return "F1"
        条件 113
        return "F2"
        条件 114
        return "F3"
        条件 115
        return "F4"
        条件 116
        return "F5"
        条件 117
        return "F6"
        条件 118
        return "F7"
        条件 119
        return "F8"
        条件 120
        return "F9"
        条件 121
        return "F10"
        条件 122
        return "F11"
        条件 123
        return "F12"
        条件 65
        return "A"
        条件 66
        return "B"
        条件 67
        return "C"
        条件 68
        return "D"
        条件 69
        return "E"
        条件 70
        return "F"
        条件 71
        return "G"
        条件 72
        return "H"
        条件 73
        return "I"
        条件 74
        return "J"
        条件 75
        return "K"
        条件 76
        return "L"
        条件 77
        return "M"
        条件 78
        return "N"
        条件 79
        return "O"
        条件 80
        return "P"
        条件 81
        return "Q"
        条件 82
        return "R"
        条件 83
        return "S"
        条件 84
        return "T"
        条件 85
        return "U"
        条件 86
        return "V"
        条件 87
        return "W"
        条件 88
        return "X"
        条件 89
        return "Y"
        条件 90
        return "Z"
        条件 48
        return "0"
        条件 49
        return "1"
        条件 50
        return "2"
        条件 51
        return "3"
        条件 52
        return "4"
        条件 53
        return "5"
        条件 54
        return "6"
        条件 55
        return "7"
        条件 56
        return "8"
        条件 57
        return "9"
        条件 96
        return "Num0"
        条件 97
        return "Num1"
        条件 98
        return "Num2"
        条件 99
        return "Num3"
        条件 100
        return "Num4"
        条件 101
        return "Num5"
        条件 102
        return "Num6"
        条件 103
        return "Num7"
        条件 104
        return "Num8"
        条件 105
        return "Num9"
        默认 
        return ""
    结束 
结束