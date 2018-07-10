using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
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
            rKey?.SetValue(appName, $@"""{AppDomain.CurrentDomain.BaseDirectory}{appName}.exe""");
        }
        /// <summary>
        /// 删除注册表实现 解除开机自动启动
        /// </summary>
        /// <param name="appName">日志内容</param>
        public static void UnAutoStart(string appName)
        {
            try
            {
                var rKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                rKey?.DeleteValue(appName, true);
            }
            catch (Exception e)
            {
                TyLog.WriteError(e);
            }
        }
        /// <summary>
        /// 结束进程
        /// </summary>
        public static void KillProcess(string pcTask)
        {
            var pro = Process.GetProcesses();//获取已开启的所有进程
            foreach (var t in pro)
            {
                if (string.Equals(t.ProcessName, pcTask, StringComparison.CurrentCultureIgnoreCase))
                {
                    t.Kill();//结束进程
                }
            }
        }
        /// <summary>
        /// 杀死进程
        /// </summary>
        public static void KillProcess(string startupPath, string killFilePath)
        {
            const string handlePath = @"C:\Windows\system32\handle.exe";
            if (!File.Exists(handlePath))
            {
                var path = Path.Combine(startupPath, "handle.exe");
                File.Copy(path, handlePath);
            }

            var tool = new Process
            {
                StartInfo =
                {
                    FileName = "handle.exe",
                    Arguments = killFilePath + " /accepteula",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            tool.Start();
            tool.WaitForExit();
            var outputTool = tool.StandardOutput.ReadToEnd();
            const string matchPattern = @"(?<=\s+pid:\s+)\b(\d+)\b(?=\s+)";
            foreach (Match match in Regex.Matches(outputTool, matchPattern))
            {
                Process.GetProcessById(int.Parse(match.Value)).Kill();
            }
        }
    }
}
