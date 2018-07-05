using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace TYPublicCore
{
    public class TyCore
    {
        [DllImport("user32.dll")]
        private static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);//删除菜单中的按钮
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);//获取系统菜单句柄
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();//获取控制台窗口句柄
        [DllImport("User32.dll", EntryPoint = "ShowWindow")]
        private static extern bool ShowWindow(IntPtr hWnd, int type);
        /// <summary>
        /// 删除控制台应用程序的关闭按钮
        /// </summary>
        public static void DeleteExit()
        {
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF060, 0);//删除关闭按钮
        }
        /// <summary>
        /// 显示控制台应用程序
        /// </summary>
        /// <param name="i">显示模式</param>
        public static void ShowConsole(int i)
        {
            ShowWindow(GetConsoleWindow(), i);
        }
        /// <summary>
        /// 设置注册表实现 开机自动启动
        /// </summary>
        /// <param name="appName">日志内容</param>
        public static void AutoStart(string appName)
        {
            var rKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            rKey?.SetValue(appName, $@"""{Environment.CurrentDirectory}\{appName}.exe""");
        }
    }
}
