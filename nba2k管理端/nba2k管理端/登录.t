﻿//开始按钮_点击操作
功能 登录_开始_点击()
    q_uid = 编辑框获取文本("编辑框0", "登录")
    变量 pwd = 编辑框获取文本("编辑框1", "登录")
    如果(q_uid == "")
        消息框("账号不能为空!")
        返回
    结束
    如果(q_uid == "888888")
        控件模态窗口("顶级管理界面")
        控件关闭子窗口("登录", 6)
        返回
    结束
    如果(pwd == "")
        消息框("密码不能为空!")
        返回
    结束
    如果(验证(pwd))
        控件关闭子窗口("登录", 6)
    结束
结束
功能 验证(pwd)
    返回 登录接口(pwd)
结束
//退出按钮_点击操作
功能 登录_退出_点击()
    退出()
结束
//点击关闭_执行操作
功能 登录_关闭()
    退出()
结束
功能 登录接口(password)
    变量 pwd = md5(password)
    变量 retarr
    字符串分割(get8User(q_uid), "_", retarr)
    如果(retarr[0] == 403)
        字符串分割(get8User(q_uid), "_", retarr)
        如果(retarr[0] == 403)
            消息框("网络连接失败!")
            返回 假
        结束
    结束
    如果(retarr[0] == 200)
        如果(retarr[1] == "")
            消息框(q_uid & " 不存在!")
            返回 假
        否则
            字符串分割(retarr[1], ",", retarr)
            如果(retarr[1] != pwd)
                消息框("密码不正确!")
                返回 假
            结束
            如果(retarr[2] != "admin" || retarr[3] != "admin")
                消息框("你没有权限登录此系统!")
                返回 假
            结束
            如果(password == 1)
                消息框("检测到你使用的是默认密码,将调到密码修改界面!")
                控件模态窗口("修改密码")
                返回 假
            结束
            返回 真
        结束
    结束
    返回 假
结束