﻿功能 按钮1_点击()
    变量 userinfo = 数组(编辑框获取文本("编辑_管理号", "顶级管理界面"), md5("1"), "admin", "admin", "0", "0", "0", "0")
    如果(set8User(userinfo))
        消息框("创建成功!")
    否则
        消息框("创建失败")
    结束
结束
功能 按钮2_点击()
    变量 retarr
    变量 ret = 字符串分割(list("user/(" & 编辑框获取文本("编辑_管理号", "顶级管理界面") & ")"), "_", retarr)
    如果(del(retarr[1]) == 204)
        消息框("删除成功!")
    否则
        消息框("删除失败")
    结束
结束