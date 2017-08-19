变量 线程ID
功能 setmsg(name, index, length, cg, sb)
    标签设置文本("标签_提示", " 正在上传:" & name & "总数据量:" & length & "条 已上传:" & index & "条 成功:" & cg & "条 失败:" & sb & "条")
结束
功能 sjcl(uxtime)
    返回 字符串替换(指定时间("s", uxtime, "1970-01-01 08:00:00"), "/", "-")
结束
功能 数据_转移()
    选择(编辑框获取文本("编辑框0"))
    结束
    变量 user_arr, config_arr, log_arr, cami_arr
    变量 ret = sqlitesqlarray("d:\\yxdb.db", "select * from kam_user where endtime2 = 0", user_arr)
    如果(!ret)
        消息框("查询数据:" & 获取错误信息(1))
        返回 ""
    结束
    ret = sqlitesqlarray("d:\\yxdb.db", "select * from kam_config where txt2 is null", config_arr)
    如果(!ret)
        消息框("查询数据:" & 获取错误信息(1))
        返回 ""
    结束
    变量 大小 = 数组大小(user_arr) + 数组大小(config_arr) 
    变量 cg = 0
    变量 sb = 0
    变量 index = 0
    变量 tmp
    遍历(变量 i = 0; i < 数组大小(user_arr); i++)
        
        变量 value
        数组获取元素(user_arr, i, value)
        变量 userinfo = 数组(value["uid"], value["pwd"], sjcl(value["regtime"]), sjcl(value["endtime"]), value["utime"], value["sunum"], value["unum"], value["mcode"])
        如果(set8User(userinfo))
            cg = cg + 1
            ret = sqlitesqlarray("d:\\yxdb.db", "update kam_user set endtime2 = 1 where uid = "&value["uid"], tmp)
        否则
            sb = sb + 1
        结束
        index = index + 1
        setmsg("user", index, 大小, cg, sb)
    结束
    等待(666)
    遍历(变量 i = 0; i < 数组大小(config_arr); i++)
        变量 value
        数组获取元素(config_arr, i, value)
        如果(setConfig(value["uid"], value["txt"]))
            cg = cg + 1
            
            ret = sqlitesqlarray("d:\\yxdb.db", "update kam_config set txt2 = '1' where uid =  "&value["uid"], tmp)
        否则
            sb = sb + 1
        结束
        index = index + 1
        setmsg("config", index, 大小, cg, sb)
    结束
    消息框("数据转移完成!")
结束
//从这里开始执行
功能 执行()
    数据_转移()
结束
//启动_热键操作
功能 启动_热键()
    线程ID = 线程开启("执行", "")
结束
//终止热键操作
功能 终止_热键()
    线程关闭(线程ID)
结束
功能 按钮0_点击()
    var retarr
    var liststr = list(编辑框获取文本("编辑框0"))
    delall(字符串截取右侧(liststr, 字符串长度(liststr) - 4))
    消息框("清空完成!")
结束