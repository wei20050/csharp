功能 按钮1_点击()
结束
功能 按钮2_点击()
    变量 retarr
    变量 ret = 字符串分割(list("user/(" & 编辑框获取文本("编辑_管理号", "顶级管理界面") & ")"), "_", retarr)
    变量 userarr
    字符串分割(retarr[1], "~", userarr)
    如果(del(userarr[0]) == 204)
        消息框("删除成功!")
    否则
        消息框("删除失败")
    结束
结束
功能 按钮4_点击()
    //这里添加你要执行的代码
    变量 ret 
    变量 user
    字符串分割(get8User(编辑框获取文本("编辑框4", "顶级管理界面")), "_", ret)
    字符串分割(ret[1], ",", user)
    变量 okey = "user/(" & user[0] & "),(" & user[1] & "),(" & user[2] & "),(" & user[3] & "),(" & user[4] & "),(" & user[5] & "),(" & user[6] & "),(" & user[7] & ")"
    变量 nkey = "user/(" & user[0] & "),(" & user[1] & "),(" & user[2] & "),(" & 字符串替换(指定时间("d", 40, user[3]), "/", "-") & "),(" & user[4] & "),(" & user[5] & "),(" & user[6] & "),(" & user[7] & ")"
    如果(upd(okey, nkey))
        消息框("创建成功!")
    否则
        消息框("创建失败")
    结束
结束
功能 按钮_addadmin_点击()
    变量 userinfo = 数组(编辑框获取文本("编辑_uid", "顶级管理界面"), md5("1"), "admin", "admin", "", "0", "0", "")
    如果(set8User(userinfo))
        消息框("创建成功!")
    否则
        消息框("创建失败")
    结束
结束
功能 按钮_deluser_点击()
    变量 retarr
    变量 ret = 字符串分割(list("user/(" & 编辑框获取文本("编辑_uid", "顶级管理界面") & ")"), "_", retarr)
    变量 userarr
    字符串分割(retarr[1], "~", userarr)
    如果(del(userarr[0]) == 204)
        消息框("删除成功!")
    否则
        消息框("删除失败")
    结束
结束
功能 按钮_delall_点击()
    变量 mkey = 字符串修剪(编辑框获取文本("编辑框_key","顶级管理界面"))
    if(mkey =="")
        消息框("对不起请指定key")
        return
    end
    变量 liststr = list(mkey)
    delall(字符串截取右侧(liststr, 字符串长度(liststr) - 4))
    消息框("清空完成!")
结束
功能 按钮_saveuser_点击()
    变量 saveuid = 字符串修剪(编辑框获取文本("编辑框_saveuid","顶级管理界面"))
    变量 where = 字符串修剪(编辑框获取文本("编辑框_where","顶级管理界面"))
    var retarr
    字符串分割(saveuser(saveuid, where), "_", retarr)
    消息框(retarr[1])
结束