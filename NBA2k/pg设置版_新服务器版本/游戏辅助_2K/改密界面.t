功能 改密界面_修改_点击()
    变量 username = 编辑框获取文本("bj_uid", "改密界面")
    变量 password = 编辑框获取文本("bj_pwd", "改密界面")
    变量 newpassword = 编辑框获取文本("bj_newpwd", "")
    如果(username == "请输入会员帐号")
        p("请输入会员帐号")
        返回
    结束
    如果(!是否整型(username) || 字符串长度(username) > 16)
        p("会员号必须是整数并且不大于15位")
        返回
    结束
    如果(password == "请输入会员密码")
        p("请输入会员密码")
        返回
    结束
    如果(newpassword == "请输入新会员密码")
        p("请输入新会员密码")
        返回
    结束
    变量 页码 = getUrl("http://tianyu.vicp.io/yz/index.php/Vu/Index/editpwd?username=" & username & "&password=" & password & "&newpassword=" & newpassword)
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
功能 改密界面_退出_点击()
    控件关闭子窗口("改密界面", 1)
结束