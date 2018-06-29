﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TYPublicCore
{
    public class TYCore
    {
        [DllImport("user32.dll")]
        private static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);//删除菜单中的按钮
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);//获取系统菜单句柄
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();//获取控制台窗口句柄
        public static void DeleteExit()
        {
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF060, 0);//删除关闭按钮
        }
    }
}
