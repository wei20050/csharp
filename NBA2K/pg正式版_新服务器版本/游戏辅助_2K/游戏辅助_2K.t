﻿功能 游戏辅助_2K_初始化()
    设置配置路径()
    热键关闭()
    高级热键关闭()
    验证()
    初始化()
结束
功能 游戏辅助_2K_销毁()
    如果(窗口是否加载)
        WC()
    结束
结束
功能 软件开关_热键()
    软件开关()
结束
功能 设置按钮_点击()
    控件模态窗口("设置界面")
结束
功能 默认按钮_点击()
    如果(对话框("确定要恢复默认配置吗?", "确认后无法后悔", 1, 真) == 5)
        恢复默认()
    结束
结束
功能 an_ckdqsj_点击()
    窗口设置标题(窗口获取自我句柄(), "游戏辅助_2K   您的会员等级是: " & usertype & "  软件到期时间:" & endtime)
结束
功能 an_up_点击()
    WC()
    如果(对话框("从本地上传配置会覆盖服务器配置!", "确认上传吗?", 1, 真) == 5)
        UpCfg()
    结束
结束
功能 an_dp_点击()
    如果(对话框("从服务器下载配置会覆盖本地配置!", "确认下载吗?", 1, 真) == 5)
        DpCfg()
        刷新左右()
    结束
结束
功能 fx_tlkg_点击()
    如果(窗口是否加载) 
        热键销毁("rj_tlrj")
        热键销毁("rj_yczj")
        热键销毁("rj_ycjs")
        如果(复选框获取状态("fx_tlkg"))
            热键注册("rj_tlrj")
            热键注册("rj_yczj")
            热键注册("rj_ycjs")
        结束
    结束
结束
功能 rj_tlrj_热键()
    如果(复选框获取状态("fx_tlkg"))
        如果(线程标识 == 0)
            线程ID = 线程开启("高级投篮", dmz)
        结束
    结束
结束
功能 rj_yczj_热键()
    延迟增加()
结束
功能 rj_ycjs_热键()
    延迟减少()
结束
功能 rj_tlsjjs_热键()
    投篮延迟减少()
结束
功能 rj_tlsjzj_热键()
    投篮延迟增加()
结束
功能 rj_dzsjjs_热键()
    动作延迟减少()
结束
功能 rj_dzsjzj_热键()
    动作延迟增加()
结束
功能 rj_tlrj_失去焦点()
    如果(窗口是否加载) 
        热键销毁("rj_tlrj")
        热键注册("rj_tlrj")
    结束
结束
功能 rj_yczj_失去焦点()
    如果(窗口是否加载) 
        热键销毁("rj_yczj")
        热键注册("rj_yczj")
        悬浮窗写字()
    结束
结束
功能 rj_ycjs_失去焦点()
    如果(窗口是否加载) 
        热键销毁("rj_ycjs")
        热键注册("rj_ycjs")
        悬浮窗写字()
    结束
结束
功能 rj_tlsjjs_失去焦点()
    如果(窗口是否加载) 
        热键销毁("rj_tlsjjs")
        热键注册("rj_tlsjjs")
    结束
    悬浮窗写字()
结束
功能 rj_tlsjzj_失去焦点()
    如果(窗口是否加载) 
        热键销毁("rj_tlsjzj")
        热键注册("rj_tlsjzj")
    结束
    悬浮窗写字()
结束
功能 rj_dzsjjs_失去焦点()
    如果(窗口是否加载) 
        热键销毁("rj_dzsjjs")
        热键注册("rj_dzsjjs")
    结束
    悬浮窗写字()
结束
功能 rj_dzsjzj_失去焦点()
    如果(窗口是否加载) 
        热键销毁("rj_dzsjzj")
        热键注册("rj_dzsjzj")
    结束
    悬浮窗写字()
结束
功能 rj_xggbzy_热键()
    改变鬼步左右()
结束
功能 rj_xggbzy_失去焦点()
    如果(窗口是否加载) 
        热键销毁("rj_xggbzy")
        热键注册("rj_xggbzy")
    结束
    悬浮窗写字()
结束
功能 bj_dqyc_内容改变()
    如果(窗口是否加载) 
        变量 内容 = 编辑框获取文本("bj_dqyc")
        如果(字符串长度(内容) > 4)
            内容 = 字符串截取左侧(内容, 4)
        结束
        文件写配置("gjtl", "dqyc", 内容, 配置路径)
        悬浮窗写字()
    结束
结束
功能 fx_xfckg_点击()
    如果(窗口是否加载)
        如果(复选框获取状态("fx_xfckg"))
            悬浮窗创建()
            悬浮窗写字()
        否则
            悬浮窗关闭()
        结束
    结束
结束
功能 热键0_热键()
    如果(复选框获取状态("复选框0"))
        线程ID = 线程开启("功能0", dmz)
    结束
结束
功能 热键1_热键()
    如果(复选框获取状态("复选框1"))
        打断(dmz)
        线程ID = 线程开启("功能1", dmz)
    结束
结束
功能 热键2_热键()
    如果(复选框获取状态("复选框2"))
        打断(dmz)
        线程ID = 线程开启("功能2", dmz)
    结束
结束
功能 热键3_热键()
    如果(复选框获取状态("复选框3"))
        打断(dmz)
        线程ID = 线程开启("功能3", dmz)
    结束
结束
功能 热键4_热键()
    如果(复选框获取状态("复选框4"))
        打断(dmz)
        线程ID = 线程开启("功能4", dmz)
    结束
结束
功能 热键5_热键()
    如果(复选框获取状态("复选框5"))
        打断(dmz)
        线程ID = 线程开启("功能5", dmz)
    结束
结束
功能 热键6_热键()
    如果(复选框获取状态("复选框6"))
        打断(dmz)
        线程ID = 线程开启("功能6", dmz)
    结束
结束
功能 热键7_热键()
    如果(复选框获取状态("复选框7"))
        打断(dmz)
        线程ID = 线程开启("功能7", dmz)
    结束
结束
功能 热键8_热键()
    如果(复选框获取状态("复选框8"))
        打断(dmz)
        线程ID = 线程开启("功能8", dmz)
    结束
结束
功能 热键9_热键()
    如果(复选框获取状态("复选框9"))
        打断(dmz)
        线程ID = 线程开启("功能9", dmz)
    结束
结束
功能 热键10_热键()
    如果(复选框获取状态("复选框10"))
        打断(dmz)
        线程ID = 线程开启("功能10", dmz)
    结束
结束
功能 热键11_热键()
    如果(复选框获取状态("复选框11"))
        打断(dmz)
        线程ID = 线程开启("功能11", dmz)
    结束
结束
功能 热键12_热键()
    如果(复选框获取状态("复选框12"))
        打断(dmz)
        线程ID = 线程开启("功能12", dmz)
    结束
结束
功能 热键13_热键()
    如果(复选框获取状态("复选框13"))
        打断(dmz)
        线程ID = 线程开启("功能13", dmz)
    结束
结束
功能 热键14_热键()
    如果(复选框获取状态("复选框14"))
        打断(dmz)
        线程ID = 线程开启("功能14", dmz)
    结束
结束
功能 热键15_热键()
    如果(复选框获取状态("复选框15"))
        打断(dmz)
        线程ID = 线程开启("功能15", dmz)
    结束
结束
功能 热键16_热键()
    如果(复选框获取状态("复选框16"))
        打断(dmz)
        线程ID = 线程开启("功能16", dmz)
    结束
结束
功能 热键17_热键()
    如果(复选框获取状态("复选框17"))
        打断(dmz)
        线程ID = 线程开启("功能17", dmz)
    结束
结束
功能 热键18_热键()
    如果(复选框获取状态("复选框18"))
        打断(dmz)
        线程ID = 线程开启("功能18", dmz)
    结束
结束
功能 热键19_热键()
    如果(复选框获取状态("复选框19"))
        打断(dmz)
        线程ID = 线程开启("功能19", dmz)
    结束
结束
功能 热键20_热键()
    如果(复选框获取状态("复选框20"))
        打断(dmz)
        线程ID = 线程开启("功能20", dmz)
    结束
结束
功能 热键21_热键()
    如果(复选框获取状态("复选框21"))
        打断(dmz)
        线程ID = 线程开启("功能21", dmz)
    结束
结束
功能 热键22_热键()
    如果(复选框获取状态("复选框22"))
        线程ID = 线程开启("功能22", dmz)
    结束
结束
功能 热键23_热键()
    如果(复选框获取状态("复选框23"))
        线程ID = 线程开启("功能23", dmz)
    结束
结束
功能 热键24_热键()
    如果(复选框获取状态("复选框24"))
        线程ID = 线程开启("功能24", dmz)
    结束
结束
功能 热键25_热键()
    如果(复选框获取状态("复选框25"))
        线程ID = 线程开启("功能25", dmz)
    结束
结束
功能 热键26_热键()
    如果(复选框获取状态("复选框26"))
        打断(dmz)
        线程ID = 线程开启("功能26", dmz)
    结束
结束
功能 热键27_热键()
    如果(复选框获取状态("复选框27"))
        打断(dmz)
        线程ID = 线程开启("功能27", dmz)
    结束
结束
功能 热键28_热键()
    如果(复选框获取状态("复选框28"))
        打断(dmz)
        线程ID = 线程开启("功能28", dmz)
    结束
结束
功能 热键29_热键()
    如果(复选框获取状态("复选框29"))
        打断(dmz)
        线程ID = 线程开启("功能29", dmz)
    结束
结束
功能 热键30_热键()
    如果(复选框获取状态("复选框30"))
        线程ID = 线程开启("功能30", dmz)
    结束
结束
功能 热键31_热键()
    如果(复选框获取状态("复选框31"))
        打断(dmz)
        线程ID = 线程开启("功能31", dmz)
    结束
结束
功能 热键32_热键()
    如果(复选框获取状态("复选框32"))
        打断(dmz)
        线程ID = 线程开启("功能32", dmz)
    结束
结束
功能 热键33_热键()
    如果(复选框获取状态("复选框33"))
        打断(dmz)
        线程ID = 线程开启("功能33", dmz)
    结束
结束
功能 热键34_热键()
    如果(复选框获取状态("复选框34"))
        打断(dmz)
        线程ID = 线程开启("功能34", dmz)
    结束
结束
功能 热键35_热键()
    如果(复选框获取状态("复选框35"))
        打断(dmz)
        线程ID = 线程开启("功能35", dmz)
    结束
结束
功能 热键36_热键()
    如果(复选框获取状态("复选框36"))
        打断(dmz)
        线程ID = 线程开启("功能36", dmz)
    结束
结束
功能 热键37_热键()
    如果(复选框获取状态("复选框37"))
        打断(dmz)
        线程ID = 线程开启("功能37", dmz)
    结束
结束
功能 热键38_热键()
    如果(复选框获取状态("复选框38"))
        打断(dmz)
        线程ID = 线程开启("功能38", dmz)
    结束
结束
功能 热键39_热键()
    如果(复选框获取状态("复选框39"))
        打断(dmz)
        线程ID = 线程开启("功能39", dmz)
    结束
结束
功能 热键40_热键()
    如果(复选框获取状态("复选框40"))
        打断(dmz)
        线程ID = 线程开启("功能40", dmz)
    结束
结束
功能 热键41_热键()
    如果(复选框获取状态("复选框41"))
        打断(dmz)
        线程ID = 线程开启("功能41", dmz)
    结束
结束
功能 热键42_热键()
    如果(复选框获取状态("复选框42"))
        打断(dmz)
        线程ID = 线程开启("功能42", dmz)
    结束
结束
功能 热键43_热键()
    如果(复选框获取状态("复选框43"))
        打断(dmz)
        线程ID = 线程开启("功能43", dmz)
    结束
结束
功能 热键44_热键()
    如果(复选框获取状态("复选框44"))
        打断(dmz)
        线程ID = 线程开启("功能44", dmz)
    结束
结束
功能 热键45_热键()
    如果(复选框获取状态("复选框45"))
        打断(dmz)
        线程ID = 线程开启("功能45", dmz)
    结束
结束
功能 热键46_热键()
    如果(复选框获取状态("复选框46"))
        打断(dmz)
        线程ID = 线程开启("功能46", dmz)
    结束
结束
功能 热键47_热键()
    如果(复选框获取状态("复选框47"))
        打断(dmz)
        线程ID = 线程开启("功能47", dmz)
    结束
结束
功能 热键48_热键()
    如果(复选框获取状态("复选框48"))
        打断(dmz)
        线程ID = 线程开启("功能48", dmz)
    结束
结束
功能 热键49_热键()
    如果(复选框获取状态("复选框49"))
        打断(dmz)
        线程ID = 线程开启("功能49", dmz)
    结束
结束
功能 热键50_热键()
    如果(复选框获取状态("复选框50"))
        打断(dmz)
        线程ID = 线程开启("功能50", dmz)
    结束
结束
功能 热键51_热键()
    如果(复选框获取状态("复选框51"))
        打断(dmz)
        线程ID = 线程开启("功能51", dmz)
    结束
结束
功能 热键52_热键()
    如果(复选框获取状态("复选框52"))
        线程ID = 线程开启("功能52", dmz)
    结束
结束
功能 热键53_热键()
    如果(复选框获取状态("复选框53"))
        线程ID = 线程开启("功能53", dmz)
    结束
结束
功能 热键54_热键()
    如果(复选框获取状态("复选框54"))
        打断(dmz)
        线程ID = 线程开启("功能54", dmz)
    结束
结束
功能 热键55_热键()
    如果(复选框获取状态("复选框55"))
        打断(dmz)
        线程ID = 线程开启("功能55", dmz)
    结束
结束
功能 热键56_热键()
    如果(复选框获取状态("复选框56"))
        打断(dmz)
        线程ID = 线程开启("功能56", dmz)
    结束
结束
功能 热键57_热键()
    如果(复选框获取状态("复选框57"))
        打断(dmz)
        线程ID = 线程开启("功能57", dmz)
    结束
结束
功能 热键58_热键()
    如果(复选框获取状态("复选框58"))
        打断(dmz)
        线程ID = 线程开启("功能58", dmz)
    结束
结束
功能 热键59_热键()
    如果(复选框获取状态("复选框59"))
        打断(dmz)
        线程ID = 线程开启("功能59", dmz)
    结束
结束
功能 热键60_热键()
    如果(复选框获取状态("复选框60"))
        打断(dmz)
    结束
结束
功能 热键61_热键()
    如果(复选框获取状态("复选框61"))
        打断(dmz)
        线程ID = 线程开启("功能61", dmz)
    结束
结束
功能 热键62_热键()
    如果(复选框获取状态("复选框62"))
        打断(dmz)
        线程ID = 线程开启("功能62", dmz)
    结束
结束
功能 热键63_热键()
    如果(复选框获取状态("复选框63"))
        打断(dmz)
        线程ID = 线程开启("功能63", dmz)
    结束
结束
功能 热键64_热键()
    如果(复选框获取状态("复选框64"))
        打断(dmz)
        线程ID = 线程开启("功能64", dmz)
    结束
结束
功能 热键65_热键()
    如果(复选框获取状态("复选框65"))
        打断(dmz)
        线程ID = 线程开启("功能65", dmz)
    结束
结束
功能 热键66_热键()
    如果(复选框获取状态("复选框66"))
        线程ID = 线程开启("功能66", dmz)
    结束
结束
功能 热键67_热键()
    如果(复选框获取状态("复选框67"))
        线程ID = 线程开启("功能67", dmz)
    结束
结束
功能 热键68_热键()
    如果(复选框获取状态("复选框68"))
        打断(dmz)
        线程ID = 线程开启("功能68", dmz)
    结束
结束
功能 热键69_热键()
    如果(复选框获取状态("复选框69"))
        打断(dmz)
        线程ID = 线程开启("功能69", dmz)
    结束
结束
功能 热键70_热键()
    如果(复选框获取状态("复选框70"))
        打断(dmz)
        线程ID = 线程开启("功能70", dmz)
    结束
结束
功能 热键71_热键()
    如果(复选框获取状态("复选框71"))
        打断(dmz)
        线程ID = 线程开启("功能71", dmz)
    结束
结束
功能 热键72_热键()
    如果(复选框获取状态("复选框72"))
        打断(dmz)
        线程ID = 线程开启("功能72", dmz)
    结束
结束
功能 热键73_热键()
    如果(复选框获取状态("复选框73"))
        打断(dmz)
        线程ID = 线程开启("功能73", dmz)
    结束
结束
功能 热键74_热键()
    如果(复选框获取状态("复选框74"))
        打断(dmz)
        线程ID = 线程开启("功能74", dmz)
    结束
结束
功能 热键0_失去焦点()
    热键销毁("热键0")
    热键注册("热键0")
结束
功能 热键1_失去焦点()
    热键销毁("热键1")
    热键注册("热键1")
结束
功能 热键2_失去焦点()
    热键销毁("热键2")
    热键注册("热键2")
结束
功能 热键3_失去焦点()
    热键销毁("热键3")
    热键注册("热键3")
结束
功能 热键4_失去焦点()
    热键销毁("热键4")
    热键注册("热键4")
结束
功能 热键5_失去焦点()
    热键销毁("热键5")
    热键注册("热键5")
结束
功能 热键6_失去焦点()
    热键销毁("热键6")
    热键注册("热键6")
结束
功能 热键7_失去焦点()
    热键销毁("热键7")
    热键注册("热键7")
结束
功能 热键8_失去焦点()
    热键销毁("热键8")
    热键注册("热键8")
结束
功能 热键9_失去焦点()
    热键销毁("热键9")
    热键注册("热键9")
结束
功能 热键10_失去焦点()
    热键销毁("热键10")
    热键注册("热键10")
结束
功能 热键11_失去焦点()
    热键销毁("热键11")
    热键注册("热键11")
结束
功能 热键12_失去焦点()
    热键销毁("热键12")
    热键注册("热键12")
结束
功能 热键13_失去焦点()
    热键销毁("热键13")
    热键注册("热键13")
结束
功能 热键14_失去焦点()
    热键销毁("热键14")
    热键注册("热键14")
结束
功能 热键15_失去焦点()
    热键销毁("热键15")
    热键注册("热键15")
结束
功能 热键16_失去焦点()
    热键销毁("热键16")
    热键注册("热键16")
结束
功能 热键17_失去焦点()
    热键销毁("热键17")
    热键注册("热键17")
结束
功能 热键18_失去焦点()
    热键销毁("热键18")
    热键注册("热键18")
结束
功能 热键19_失去焦点()
    热键销毁("热键19")
    热键注册("热键19")
结束
功能 热键20_失去焦点()
    热键销毁("热键20")
    热键注册("热键20")
结束
功能 热键21_失去焦点()
    热键销毁("热键21")
    热键注册("热键21")
结束
功能 热键22_失去焦点()
    热键销毁("热键22")
    热键注册("热键22")
结束
功能 热键23_失去焦点()
    热键销毁("热键23")
    热键注册("热键23")
结束
功能 热键24_失去焦点()
    热键销毁("热键24")
    热键注册("热键24")
结束
功能 热键25_失去焦点()
    热键销毁("热键25")
    热键注册("热键25")
结束
功能 热键26_失去焦点()
    热键销毁("热键26")
    热键注册("热键26")
结束
功能 热键27_失去焦点()
    热键销毁("热键27")
    热键注册("热键27")
结束
功能 热键28_失去焦点()
    热键销毁("热键28")
    热键注册("热键28")
结束
功能 热键29_失去焦点()
    热键销毁("热键29")
    热键注册("热键29")
结束
功能 热键30_失去焦点()
    热键销毁("热键30")
    热键注册("热键30")
结束
功能 热键31_失去焦点()
    热键销毁("热键31")
    热键注册("热键31")
结束
功能 热键32_失去焦点()
    热键销毁("热键32")
    热键注册("热键32")
结束
功能 热键33_失去焦点()
    热键销毁("热键33")
    热键注册("热键33")
结束
功能 热键34_失去焦点()
    热键销毁("热键34")
    热键注册("热键34")
结束
功能 热键35_失去焦点()
    热键销毁("热键35")
    热键注册("热键35")
结束
功能 热键36_失去焦点()
    热键销毁("热键36")
    热键注册("热键36")
结束
功能 热键37_失去焦点()
    热键销毁("热键37")
    热键注册("热键37")
结束
功能 热键38_失去焦点()
    热键销毁("热键38")
    热键注册("热键38")
结束
功能 热键39_失去焦点()
    热键销毁("热键39")
    热键注册("热键39")
结束
功能 热键40_失去焦点()
    热键销毁("热键40")
    热键注册("热键40")
结束
功能 热键41_失去焦点()
    热键销毁("热键41")
    热键注册("热键41")
结束
功能 热键42_失去焦点()
    热键销毁("热键42")
    热键注册("热键42")
结束
功能 热键43_失去焦点()
    热键销毁("热键43")
    热键注册("热键43")
结束
功能 热键44_失去焦点()
    热键销毁("热键44")
    热键注册("热键44")
结束
功能 热键45_失去焦点()
    热键销毁("热键45")
    热键注册("热键45")
结束
功能 热键46_失去焦点()
    热键销毁("热键46")
    热键注册("热键46")
结束
功能 热键47_失去焦点()
    热键销毁("热键47")
    热键注册("热键47")
结束
功能 热键48_失去焦点()
    热键销毁("热键48")
    热键注册("热键48")
结束
功能 热键49_失去焦点()
    热键销毁("热键49")
    热键注册("热键49")
结束
功能 热键50_失去焦点()
    热键销毁("热键50")
    热键注册("热键50")
结束
功能 热键51_失去焦点()
    热键销毁("热键51")
    热键注册("热键51")
结束
功能 热键52_失去焦点()
    热键销毁("热键52")
    热键注册("热键52")
结束
功能 热键53_失去焦点()
    热键销毁("热键53")
    热键注册("热键53")
结束
功能 热键54_失去焦点()
    热键销毁("热键54")
    热键注册("热键54")
结束
功能 热键55_失去焦点()
    热键销毁("热键55")
    热键注册("热键55")
结束
功能 热键56_失去焦点()
    热键销毁("热键56")
    热键注册("热键56")
结束
功能 热键57_失去焦点()
    热键销毁("热键57")
    热键注册("热键57")
结束
功能 热键58_失去焦点()
    热键销毁("热键58")
    热键注册("热键58")
结束
功能 热键59_失去焦点()
    热键销毁("热键59")
    热键注册("热键59")
结束
功能 热键60_失去焦点()
    热键销毁("热键60")
    热键注册("热键60")
结束
功能 热键61_失去焦点()
    热键销毁("热键61")
    热键注册("热键61")
结束
功能 热键62_失去焦点()
    热键销毁("热键62")
    热键注册("热键62")
结束
功能 热键63_失去焦点()
    热键销毁("热键63")
    热键注册("热键63")
结束
功能 热键64_失去焦点()
    热键销毁("热键64")
    热键注册("热键64")
结束
功能 热键65_失去焦点()
    热键销毁("热键65")
    热键注册("热键65")
结束
功能 热键66_失去焦点()
    热键销毁("热键66")
    热键注册("热键66")
结束
功能 热键67_失去焦点()
    热键销毁("热键67")
    热键注册("热键67")
结束
功能 热键68_失去焦点()
    热键销毁("热键68")
    热键注册("热键68")
结束
功能 热键69_失去焦点()
    热键销毁("热键69")
    热键注册("热键69")
结束
功能 热键70_失去焦点()
    热键销毁("热键70")
    热键注册("热键70")
结束
功能 热键71_失去焦点()
    热键销毁("热键71")
    热键注册("热键71")
结束
功能 热键72_失去焦点()
    热键销毁("热键72")
    热键注册("热键72")
结束
功能 热键73_失去焦点()
    热键销毁("热键73")
    热键注册("热键73")
结束
功能 热键74_失去焦点()
    热键销毁("热键74")
    热键注册("热键74")
结束
功能 编辑框0_内容改变()
    改变延迟(0)
结束
功能 编辑框1_内容改变()
    改变延迟(1)
结束
功能 编辑框2_内容改变()
    改变延迟(2)
结束
功能 编辑框3_内容改变()
    改变延迟(3)
结束
功能 编辑框4_内容改变()
    改变延迟(4)
结束
功能 编辑框5_内容改变()
    改变延迟(5)
结束
功能 编辑框6_内容改变()
    改变延迟(6)
结束
功能 编辑框7_内容改变()
    改变延迟(7)
结束
功能 编辑框8_内容改变()
    改变延迟(8)
结束
功能 编辑框9_内容改变()
    改变延迟(9)
结束
功能 编辑框10_内容改变()
    改变延迟(10)
结束
功能 编辑框11_内容改变()
    改变延迟(11)
结束
功能 编辑框12_内容改变()
    改变延迟(12)
结束
功能 编辑框13_内容改变()
    改变延迟(13)
结束
功能 编辑框14_内容改变()
    改变延迟(14)
    悬浮窗写字()
结束
功能 编辑框15_内容改变()
    改变延迟(15)
结束
功能 编辑框16_内容改变()
    改变延迟(16)
结束
功能 编辑框17_内容改变()
    改变延迟(17)
结束
功能 编辑框18_内容改变()
    改变延迟(18)
结束
功能 编辑框19_内容改变()
    改变延迟(19)
结束
功能 编辑框20_内容改变()
    改变延迟(20)
结束
功能 编辑框21_内容改变()
    改变延迟(21)
结束
功能 编辑框22_内容改变()
    改变延迟(22)
结束
功能 编辑框23_内容改变()
    改变延迟(23)
结束
功能 编辑框24_内容改变()
    改变延迟(24)
结束
功能 编辑框25_内容改变()
    改变延迟(25)
结束
功能 编辑框26_内容改变()
    改变延迟(26)
结束
功能 编辑框27_内容改变()
    改变延迟(27)
结束
功能 编辑框28_内容改变()
    改变延迟(28)
结束
功能 编辑框29_内容改变()
    改变延迟(29)
    悬浮窗写字()
结束
功能 编辑框30_内容改变()
    改变延迟(30)
结束
功能 编辑框31_内容改变()
    改变延迟(31)
结束
功能 编辑框32_内容改变()
    改变延迟(32)
结束
功能 编辑框33_内容改变()
    改变延迟(33)
结束
功能 编辑框34_内容改变()
    改变延迟(34)
结束
功能 编辑框35_内容改变()
    改变延迟(35)
结束
功能 编辑框36_内容改变()
    改变延迟(36)
结束
功能 编辑框37_内容改变()
    改变延迟(37)
结束
功能 编辑框38_内容改变()
    改变延迟(38)
结束
功能 编辑框39_内容改变()
    改变延迟(39)
结束
功能 编辑框40_内容改变()
    改变延迟(40)
结束
功能 编辑框41_内容改变()
    改变延迟(41)
结束
功能 编辑框42_内容改变()
    改变延迟(42)
结束
功能 编辑框43_内容改变()
    改变延迟(43)
结束
功能 编辑框44_内容改变()
    改变延迟(44)
结束
功能 编辑框45_内容改变()
    改变延迟(45)
结束
功能 编辑框46_内容改变()
    改变延迟(46)
结束
功能 编辑框47_内容改变()
    改变延迟(47)
结束
功能 编辑框48_内容改变()
    改变延迟(48)
结束
功能 编辑框49_内容改变()
    改变延迟(49)
结束
功能 编辑框50_内容改变()
    改变延迟(50)
结束
功能 编辑框51_内容改变()
    改变延迟(51)
结束
功能 编辑框52_内容改变()
    改变延迟(52)
结束
功能 编辑框53_内容改变()
    改变延迟(53)
结束
功能 编辑框54_内容改变()
    改变延迟(54)
结束
功能 编辑框55_内容改变()
    改变延迟(55)
结束
功能 编辑框56_内容改变()
    改变延迟(56)
结束
功能 编辑框57_内容改变()
    改变延迟(57)
结束
功能 编辑框58_内容改变()
    改变延迟(58)
结束
功能 编辑框59_内容改变()
    改变延迟(59)
结束
功能 编辑框60_内容改变()
    改变延迟(60)
结束
功能 编辑框61_内容改变()
    改变延迟(61)
结束
功能 编辑框62_内容改变()
    改变延迟(62)
结束
功能 编辑框63_内容改变()
    改变延迟(63)
结束
功能 编辑框64_内容改变()
    改变延迟(64)
结束
功能 编辑框65_内容改变()
    改变延迟(65)
结束
功能 编辑框66_内容改变()
    改变延迟(66)
结束
功能 编辑框67_内容改变()
    改变延迟(67)
结束
功能 编辑框68_内容改变()
    改变延迟(68)
结束
功能 编辑框69_内容改变()
    改变延迟(69)
结束
功能 编辑框70_内容改变()
    改变延迟(70)
结束
功能 编辑框71_内容改变()
    改变延迟(71)
结束
功能 编辑框72_内容改变()
    改变延迟(72)
结束
功能 编辑框73_内容改变()
    改变延迟(73)
结束
功能 编辑框74_内容改变()
    改变延迟(74)
结束
功能 编辑框75_内容改变()
    改变延迟(75)
结束
功能 编辑框76_内容改变()
    改变延迟(76)
结束
功能 编辑框77_内容改变()
    改变延迟(77)
结束
功能 编辑框78_内容改变()
    改变延迟(78)
结束
功能 编辑框79_内容改变()
    改变延迟(79)
结束
功能 编辑框80_内容改变()
    改变延迟(80)
结束
功能 编辑框81_内容改变()
    改变延迟(81)
结束
功能 编辑框82_内容改变()
    改变延迟(82)
结束
功能 编辑框83_内容改变()
    改变延迟(83)
结束
功能 编辑框84_内容改变()
    改变延迟(84)
结束
功能 编辑框85_内容改变()
    改变延迟(85)
结束
功能 编辑框86_内容改变()
    改变延迟(86)
结束
功能 编辑框87_内容改变()
    改变延迟(87)
结束
功能 编辑框88_内容改变()
    改变延迟(88)
结束
功能 编辑框89_内容改变()
    改变延迟(89)
结束
功能 编辑框90_内容改变()
    改变延迟(90)
结束
功能 编辑框91_内容改变()
    改变延迟(91)
结束
功能 编辑框92_内容改变()
    改变延迟(92)
结束
功能 编辑框93_内容改变()
    改变延迟(93)
结束
功能 编辑框94_内容改变()
    改变延迟(94)
结束
功能 编辑框95_内容改变()
    改变延迟(95)
结束
功能 编辑框96_内容改变()
    改变延迟(96)
结束
功能 编辑框97_内容改变()
    改变延迟(97)
结束
功能 编辑框98_内容改变()
    改变延迟(98)
结束
功能 编辑框99_内容改变()
    改变延迟(99)
结束
功能 编辑框100_内容改变()
    改变延迟(100)
结束
功能 编辑框101_内容改变()
    改变延迟(101)
结束
功能 编辑框102_内容改变()
    改变延迟(102)
结束
功能 编辑框103_内容改变()
    改变延迟(103)
结束
功能 编辑框104_内容改变()
    改变延迟(104)
结束
功能 编辑框105_内容改变()
    改变延迟(105)
结束
功能 编辑框106_内容改变()
    改变延迟(106)
结束
功能 编辑框107_内容改变()
    改变延迟(107)
结束
功能 编辑框108_内容改变()
    改变延迟(108)
结束
功能 编辑框109_内容改变()
    改变延迟(109)
结束
功能 编辑框110_内容改变()
    改变延迟(110)
结束
功能 编辑框111_内容改变()
    改变延迟(111)
结束
功能 编辑框112_内容改变()
    改变延迟(112)
结束
功能 编辑框113_内容改变()
    改变延迟(113)
结束
功能 编辑框114_内容改变()
    改变延迟(114)
结束
功能 编辑框115_内容改变()
    改变延迟(115)
结束
功能 编辑框116_内容改变()
    改变延迟(116)
结束
功能 编辑框117_内容改变()
    改变延迟(117)
结束
功能 编辑框118_内容改变()
    改变延迟(118)
结束
功能 编辑框119_内容改变()
    改变延迟(119)
结束