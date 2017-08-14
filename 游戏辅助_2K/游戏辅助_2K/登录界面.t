功能 an_login_点击()
    wuser()
    变量 username = 编辑框获取文本("bj_uid", "登录界面")
    变量 password = 编辑框获取文本("bj_pwd", "登录界面")
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
    变量 页码 = 登录(username, password, code)
    如果(页码 != "")
        变量 infos
        变量 count = 字符串分割(页码, "|", infos)
        如果(count == 3)
            如果(infos[1] == 6)
                IsOk = 假
                endtime = infos[0]
                usertype = infos[2]
                uid = username
                pwd = password
                控件关闭子窗口("登录界面", 6)
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
功能 an_change_点击()
    wuser()
    变量 username = 编辑框获取文本("bj_uid", "登录界面")
    变量 password = 编辑框获取文本("bj_pwd", "登录界面")
    变量 ukey = 编辑框获取文本("bj_ukey", "登录界面")
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
    如果(ukey == "请输入充值卡密(充值/注册时才需要)")
        p("请输入充值卡密")
        返回
    结束
    变量 页码 = 注册_充值(username, password, code, ukey)
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
功能 an_jiebang_点击()
    wuser()
    如果(对话框("申请解绑可以解除当前电脑对软件的绑定,解绑会扣除到期时间,是否解绑?(注:普通会员当天解绑两次后不扣时)", "2K提示", 2, 真) == 4)
        返回
    结束
    变量 username = 编辑框获取文本("bj_uid", "登录界面")
    变量 password = 编辑框获取文本("bj_pwd", "登录界面")
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
    变量 页码 = 解绑(username, password, code)
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
功能 wuser()
    文件写配置("root", "uid", 编辑框获取文本("bj_uid", "登录界面"), 配置路径)
    变量 password = ""
    如果(复选框获取状态("fx_bcpwd", "登录界面"))
        password = 编辑框获取文本("bj_pwd", "登录界面")
        文件写配置("root", "bcpwd", 1, 配置路径)
    否则
        文件写配置("root", "bcpwd", 0, 配置路径)
    结束
    文件写配置("root", "pwd", password, 配置路径)
结束
功能 登录界面_初始化()
    变量 ret1 = 注册表获取键值("HKEY_CURRENT_USER\\Software\\SysCode", "mcode")
    如果(ret1 == null)
        code = md5(md5(随机数(1000, 9999)) & 当前时间())
        变量 ret2 = 注册表创建项("HKEY_CURRENT_USER\\Software", "SysCode")
        变量 ret3 = 注册表创建键值("HKEY_CURRENT_USER\\Software\\SysCode", "mcode", code, 0)
        如果(!ret2 || !ret3)
            对话框("机器码获取失败,请尝试右键管理员身份运行软件!", "错误提示", 0, 真)
            退出()
        结束
    否则
        code = ret1
    结束
    变量 username = 文件读配置("root", "uid", 配置路径)
    变量 password = 文件读配置("root", "pwd", 配置路径)
    如果(username == "")
        username = "请输入会员帐号"
    结束
    如果(password == "")
        password = "请输入会员密码"
    结束
    编辑框设置文本("bj_uid", username, "登录界面")
    编辑框设置文本("bj_pwd", password, "登录界面")
    复选框设置状态("fx_bcpwd", 文件读配置("root", "bcpwd", 配置路径), "登录界面")  
结束 
功能 登录界面_销毁()
    如果(IsOk)
        退出()
    结束
结束
功能 bj_uid_获得焦点()
    如果("请输入会员帐号" == 编辑框获取文本("bj_uid", "登录界面"))
        编辑框设置文本("bj_uid", "", "登录界面")
    结束
结束
功能 bj_pwd_获得焦点()
    如果("请输入会员密码" == 编辑框获取文本("bj_pwd", "登录界面"))
        编辑框设置文本("bj_pwd", "", "登录界面")
    结束
结束
功能 bj_ukey_获得焦点()
    如果("请输入充值卡密(充值/注册时才需要)" == 编辑框获取文本("bj_ukey", "登录界面"))
        编辑框设置文本("bj_ukey", "", "登录界面")
    结束
结束
功能 bj_uid_失去焦点()
    如果("" == 编辑框获取文本("bj_uid", "登录界面"))
        编辑框设置文本("bj_uid", "请输入会员帐号", "登录界面")
    结束
结束
功能 bj_pwd_失去焦点()
    如果("" == 编辑框获取文本("bj_pwd", "登录界面"))
        编辑框设置文本("bj_pwd", "请输入会员密码", "登录界面")
    结束
结束
功能 bj_ukey_失去焦点()
    如果("" == 编辑框获取文本("bj_ukey", "登录界面"))
        编辑框设置文本("bj_ukey", "请输入充值卡密(充值/注册时才需要)", "登录界面")
    结束
结束