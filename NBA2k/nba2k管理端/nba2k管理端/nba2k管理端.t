﻿变量 q_uid
功能 nba2k管理端_初始化()
    控件模态窗口("登录")
    变量 retarr 
    字符串分割(list("log"),"_",retarr)
    字符串分割(retarr[1],"~",retarr)
    变量 userarr = 数组()
    for(var i = 0; i <数组大小(retarr); i++)
        变量 userinfo = retarr[i]
        userinfo = 字符串替换(userinfo,"user/","")
        userinfo = 字符串替换(userinfo,"(","")
        userinfo = 字符串替换(userinfo,")","")
        变量 retarrn
        字符串分割(userinfo,",",retarrn)
        userarr[i]=retarrn
    end
    表格填充数据集("表格0",userarr)
结束
//发卡按钮
功能 按钮0_点击()
    变量 ukeys = ""
    变量 unum = getnum(下拉框获取选项("下拉框1"))
    遍历(变量 i = 0; i <= 下拉框获取选项("下拉框0"); i++)
        变量 ukey = sc10str()
        变量 userinfo = 数组(ukey, q_uid, unum)
        如果(set3cami(userinfo))
            ukeys = ukeys & ukey & "\r\n"
        否则
            ukeys = ukeys & "生成失败!\r\n"
        结束		
    结束
    编辑框设置文本("编辑框2", "生成:" & unum & "天 卡密 ↓\r\n" & ukeys)
    设置剪切板(ukeys)
    消息框("生成的卡密已经复制到剪切板, 请粘贴保存!")
结束
功能 sc10str()
    返回 字符串截取(字符串转大写(aes加密(md5(指定时间("s", 随机数(-666666, 666666), 当前时间())), 指定时间("s", 随机数(-666666, 666666), 当前时间()))), 6, 16)
结束
功能 getnum(index)
    选择(index)
        条件 0
        返回 30
        条件 1
        返回 15
        条件 2
        返回 366
        条件 3
        返回 180
        条件 4
        返回 1
        条件 5
        返回 7
        条件 6
        返回 3000
        默认
        返回 0
    结束
结束
