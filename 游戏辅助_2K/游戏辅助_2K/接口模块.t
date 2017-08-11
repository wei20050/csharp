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
//功能 getUrl(urlStr)
//    变量 内容 = http获取页面源码(urlStr, "utf-8")
//    返回 内容
//结束
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
            变量 txt = 字符串替换(infos[1], "!", "\r\n")
            if(文件覆盖内容(配置路径, txt))
                RC()
                p(infos[0])
            else
                p("服务器配置写入本地失败,请尝试右键管理员方式打开软件!")
            end	
        否则
            p("服务器连接失败,请检查网络!")
        结束
    否则
        p("服务器连接失败,请检查网络!")
    结束
结束
功能 上传(txt)
    变量 ret = setConfig()
    变量 mode = "post"
    变量 senddata = "username=" & uid & "&txt=" & txt
    变量 head = array()
    变量 post_response = ""
    变量 post_ret = ""
    post_ret = httpsubmit(mode, post_url, senddata, "", head, post_response)
    //messagebox(post_response) //响应头
    返回 url解码(post_ret, "utf-8")
结束
功能 下载()
    变量 post_url = "http://tianyu.vicp.io/yz/index.php/Vu/Index/dp"
    变量 mode = "post"
    变量 senddata = "username=" & uid
    变量 head = array()
    变量 post_response = ""
    变量 post_ret = ""
    post_ret = httpsubmit(mode, post_url, senddata, "", head, post_response)
    //messagebox(post_response) //响应头
    返回 url解码(post_ret, "utf-8")
结束
//服务器相关---------------------------------------------------------------------------------------------