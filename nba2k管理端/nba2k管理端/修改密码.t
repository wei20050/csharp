//开始按钮_点击操作
功能 修改密码_开始_点击()
    变量 retarr
    变量 okey
    字符串分割(list("user/(" & q_uid & ")"), "_", retarr)
    如果(retarr[0] != 200)
        字符串分割(list("user/(" & q_uid & ")"), "_", retarr)
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
    userinfo[1] = md5(编辑框获取文本("编辑框3", "修改密码"))
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
//退出按钮_点击操作
功能 修改密码_退出_点击()
    控件关闭子窗口("修改密码", 6)
结束