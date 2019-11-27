using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo
// ReSharper disable InconsistentNaming

namespace yxz
{


    /// <summary>
    /// 系统操作类
    /// </summary>
    public class Yx
    {
        #region 常量

        #region 设置窗口状态相关的常量

        /// <summary>
        /// 隐藏窗口并激活其他窗口
        /// </summary>
        public const int SwHide = 0;
        /// <summary>
        /// 激活并显示一个窗口。如果窗口被最小化或最大化，系统将其恢复到原来的尺寸和大小。应用程序在第一次显示窗口的时候应该指定此标志
        /// </summary>
        public const int SwNormal = 1;
        /// <summary>
        /// 激活窗口并将其最小化
        /// </summary>
        public const int SwShowminimized = 2;
        /// <summary>
        /// 最大化指定的窗口
        /// </summary>
        public const int SwMaximize = 3;
        /// <summary>
        /// 以窗口最近一次的大小和状态显示窗口。激活窗口仍然维持激活状态
        /// </summary>
        public const int SwShownoactivate = 4;
        /// <summary>
        /// 在窗口原来的位置以原来的尺寸激活和显示窗口
        /// </summary>
        public const int SwShow = 5;
        /// <summary>
        /// 最小化指定的窗口并且激活在Z序中的下一个顶层窗口
        /// </summary>
        public const int SwMinimize = 6;
        /// <summary>
        /// 窗口最小化，激活窗口仍然维持激活状态
        /// </summary>
        public const int SwShowminnoactive = 7;
        /// <summary>
        /// 以窗口原来的状态显示窗口。激活窗口仍然维持激活状态
        /// </summary>
        public const int SwShowna = 8;
        /// <summary>
        /// 激活并显示窗口。如果窗口最小化或最大化，则系统将窗口恢复到原来的尺寸和位置。在恢复最小化窗口时，应用程序应该指定这个标志。
        /// </summary>
        public const int SwRestore = 9;
        /// <summary>
        /// 依据在STARTUPINFO结构中指定的SW_FLAG标志设定显示状态，STARTUPINFO 结构是由启动应用程序的程序传递给CreateProcess函数的
        /// </summary>
        public const int SwShowdefault = 10;

        #endregion

        #endregion

        #region 系统API

        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        private static extern void Keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int x, int y);
        [DllImport("user32.dll", EntryPoint = "mouse_event", SetLastError = true)]
        private static extern int Mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(
            string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(
            string section, string key, string def,
            StringBuilder retVal, int size, string filePath);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr processId);
        [DllImport("user32.dll")]
        private static extern bool GetGUIThreadInfo(uint idThread, ref Guithreadinfo lpgui);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        private static extern IntPtr FWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);
        private delegate bool CallBack(IntPtr hwnd, int lParam);
        [DllImport("user32.dll", EntryPoint = "EnumWindows")]
        private static extern int EWindows(CallBack lpEnumFunc, int lParam);
        [DllImport("user32.dll")]
        private static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        private static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out Rect lpRect);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRePaint);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("User32")]
        private static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("User32")]
        private static extern bool CloseClipboard();

        [DllImport("User32")]
        private static extern bool EmptyClipboard();

        [DllImport("User32")]
        private static extern bool IsClipboardFormatAvailable(int format);

        [DllImport("User32")]
        private static extern IntPtr GetClipboardData(int uFormat);

        [DllImport("User32", CharSet = CharSet.Unicode)]
        private static extern IntPtr SetClipboardData(int uFormat, IntPtr hMem);

        #endregion

        #region 全局变量

        /// <summary>
        /// 最后一次错误信息
        /// </summary>
        private static string _lastError = string.Empty;

        #endregion

        #region 结构

        [StructLayout(LayoutKind.Sequential)]
        private struct Guithreadinfo
        {
            public int cbSize;
            private readonly int flags;
            private readonly IntPtr hwndActive;
            public readonly IntPtr hwndFocus;
            private readonly IntPtr hwndCapture;
            private readonly IntPtr hwndMenuOwner;
            private readonly IntPtr hwndMoveSize;
            private readonly IntPtr hwndCaret;
            private readonly Rect rectCaret;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public readonly int left;
            public readonly int top;
            public readonly int right;
            public readonly int bottom;
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 获取焦点句柄
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        /// <returns></returns>
        private static Guithreadinfo? GetGuiThreadInfo(IntPtr hwnd)
        {
            if (hwnd == IntPtr.Zero) return null;
            var threadId = GetWindowThreadProcessId(hwnd, IntPtr.Zero);
            var guiThreadInfo = new Guithreadinfo();
            guiThreadInfo.cbSize = Marshal.SizeOf(guiThreadInfo);
            if (GetGUIThreadInfo(threadId, ref guiThreadInfo) == false)
                return null;
            return guiThreadInfo;
        }

        /// <summary>
        /// 获得GetBitmap
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        private static Bitmap GetBitmap(string imagePath)
        {
            var bitmap = new Bitmap(imagePath);
            var retBitmap = (Bitmap)bitmap.Clone();
            bitmap.Dispose();
            return retBitmap;
        }

        #endregion

        #region 系统

        /// <summary>
        /// 获取最后一次错误信息
        /// </summary>
        /// <returns></returns>
        public static string GetLastError()
        {
            return _lastError;
        }

        /// <summary>
        /// 延迟
        /// </summary>
        /// <param name="ms">毫秒</param>
        public static void Delay(int ms)
        {
            try
            {
                System.Threading.Thread.Sleep(ms);
            }
            catch (Exception e)
            {
                _lastError = $"延迟: {e}";
            }
        }

        /// <summary>
        /// 打开应用文件或网站
        /// </summary>
        /// <param name="path">文件或应用路径</param>
        /// <returns></returns>
        public static void RunApp(string path)
        {
            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch (Exception e)
            {
                _lastError = $"打开应用文件或网站: {e}";
            }
        }

        /// <summary>
        /// 获取剪切板内容
        /// </summary>
        /// <returns>剪切板内容</returns>
        public static object GetClipboard()
        {
            try
            {
                var value = string.Empty;
                OpenClipboard(IntPtr.Zero);
                if (IsClipboardFormatAvailable(13))
                {
                    var ptr = GetClipboardData(13);
                    if (ptr != IntPtr.Zero)
                    {
                        value = Marshal.PtrToStringUni(ptr);
                    }
                }
                CloseClipboard();
                return value;
            }
            catch (Exception e)
            {
                _lastError = $"获取剪切板内容: {e}";
                return string.Empty;
            }

        }

        /// <summary>
        /// 设置剪切板内容
        /// </summary>
        /// <returns>内容</returns>
        public static void SetClipboard(string content)
        {
            try
            {
                while (true)
                {
                    if (!OpenClipboard(IntPtr.Zero))
                    {
                        continue;
                    }
                    EmptyClipboard();
                    SetClipboardData(13, Marshal.StringToHGlobalUni(content));
                    CloseClipboard();
                    break;
                }
            }
            catch (Exception e)
            {
                _lastError = $"设置剪切板内容: {e}";
            }
        }

        /// <summary>
        /// 输入字符串
        /// </summary>
        /// <param name="text">字符串文本</param>
        public static void SayString(string text)
        {
            var hwnd = GetForegroundWindow();
            if (string.IsNullOrEmpty(text))
                return;
            var guiInfo = GetGuiThreadInfo(hwnd);
            if (guiInfo == null) return;
            foreach (var t in text)
            {
                SendMessage(guiInfo.Value.hwndFocus, 0x0102, (IntPtr)t, IntPtr.Zero);
            }
        }

        #endregion

        #region 键盘操作

        /// <summary>
        /// 获得键码
        /// </summary>
        /// <param name="c"></param>
        /// <param name="isUpper"></param>
        /// <returns></returns>
        public static byte GetKey(string c, out bool isUpper)
        {
            isUpper = false;
            for (var i = 1; i < 13; i++)
            {
                if (c == $"F{i}")
                {
                    return (byte)(111 + i);
                }
            }
            switch (c)
            {
                case "!":
                    isUpper = true;
                    return 49;
                case "@":
                    isUpper = true;
                    return 50;
                case "#":
                    isUpper = true;
                    return 51;
                case "$":
                    isUpper = true;
                    return 52;
                case "%":
                    isUpper = true;
                    return 53;
                case "^":
                    isUpper = true;
                    return 54;
                case "&":
                    isUpper = true;
                    return 55;
                case "*":
                    isUpper = true;
                    return 56;
                case "(":
                    isUpper = true;
                    return 57;
                case ")":
                    isUpper = true;
                    return 48;
                case "-":
                    return 189;
                case "_":
                    isUpper = true;
                    return 189;
                case "=":
                    return 187;
                case "+":
                    isUpper = true;
                    return 187;
                case ";":
                    return 186;
                case ":":
                    isUpper = true;
                    return 186;
                case "/":
                    return 191;
                case "?":
                    isUpper = true;
                    return 191;
                case "`":
                    return 192;
                case "~":
                    isUpper = true;
                    return 192;
                case "[":
                    return 219;
                case "{":
                    isUpper = true;
                    return 219;
                case "]":
                    return 221;
                case "}":
                    isUpper = true;
                    return 221;
                case "\\":
                    return 220;
                case "|":
                    isUpper = true;
                    return 220;
                case "'":
                    return 222;
                case "\"":
                    isUpper = true;
                    return 222;
                case ",":
                    return 188;
                case "<":
                    isUpper = true;
                    return 188;
                case ".":
                    return 190;
                case ">":
                    isUpper = true;
                    return 190;
                case "Back":
                    return 8;
                case "Tab":
                    return 9;
                case "Enter":
                    return 13;
                case "Shift":
                    return 16;
                case "Ctrl":
                    return 17;
                case "Alt":
                    return 18;
                case "Esc":
                    return 27;
                case "Insert":
                    return 45;
                case "Delete":
                    return 46;
                case "PageUp":
                    return 33;
                case "PageDown":
                    return 34;
                case "End":
                    return 35;
                case "Home":
                    return 36;
                case " ":
                case "Space":
                    return 32;
                default:
                    return c.Length != 1 ? (byte)0 : Convert.ToByte(c.ToUpper()[0]);
            }
        }

        /// <summary>
        /// 键盘按下
        /// </summary>
        /// <param name="bVk">键代码</param>
        public static void KeyDown(byte bVk)
        {
            Keybd_event(bVk, 0, 0, 0);
        }

        /// <summary>
        /// 键盘弹起
        /// </summary>
        /// <param name="bVk">键代码</param>
        public static void KeyUp(byte bVk)
        {
            Keybd_event(bVk, 0, 2, 0);
        }

        /// <summary>
        /// 键盘按键
        /// </summary>
        /// <param name="bVk">键代码</param>
        public static void KeyPress(byte bVk)
        {
            Keybd_event(bVk, 0, 0, 0);
            Keybd_event(bVk, 0, 2, 0);
        }

        /// <summary>
        /// <para>键盘按键</para>
        /// <para>"!"</para>
        /// <para>"@"</para>
        /// <para>"#"</para>
        /// <para>"$"</para>
        /// <para>"%"</para>
        /// <para>"^"</para>
        /// <para>"&"</para>
        /// <para>"*"</para>
        /// <para>"("</para>
        /// <para>")"</para>
        /// <para>"-"</para>
        /// <para>"_"</para>
        /// <para>"="</para>
        /// <para>"+"</para>
        /// <para>";"</para>
        /// <para>"" </para>
        /// <para>"/"</para>
        /// <para>"?"</para>
        /// <para>"`"</para>
        /// <para>"~"</para>
        /// <para>"["</para>
        /// <para>"{"</para>
        /// <para>"]"</para>
        /// <para>"}"</para>
        /// <para>"\\"</para>
        /// <para>"|"</para>
        /// <para>"'"</para>
        /// <para>"\""</para>
        /// <para>","</para>
        /// <para>"＜"</para>
        /// <para>"."</para>
        /// <para>">"</para>
        /// <para>"Back"</para>
        /// <para>"Tab"</para>
        /// <para>"Enter"</para>
        /// <para>"Shift"</para>
        /// <para>"Ctrl"</para>
        /// <para>"Alt"</para>
        /// <para>"Esc"</para>
        /// <para>"Insert"</para>
        /// <para>"Delete"</para>
        /// <para>"PageUp"</para>
        /// <para>"PageDown"</para>
        /// <para>"End"</para>
        /// <para>"Home"</para>
        /// <para>" "</para>
        /// <para>"Space"</para>
        /// </summary>
        /// <param name="s">键字符</param>
        public static void KeyPressChar(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return;
            }
            var key = GetKey(s, out var isUpper);
            if (isUpper)
            {
                KeyDown(16);
                KeyPress(key);
                KeyUp(16);
            }
            else
            {
                KeyPress(key);
            }
        }

        /// <summary>
        /// 键盘根据文本按键
        /// </summary>
        /// <param name="keyStr">键文本(只支持标准ASCII可见字符)</param>
        /// <param name="delay">每个字之间的延迟</param>
        /// <param name="iszs">是否模拟真实输入</param>
        public static void KeyPressStr(string keyStr, int delay = 6, bool iszs = false)
        {
            foreach (var chr in keyStr)
            {
                KeyPressChar(chr.ToString());
                Delay(iszs ? new Random().Next(1, 100) : delay);
            }
        }

        /// <summary>
        /// ctrl+c 复制
        /// </summary>
        public static void KeyCtrlC()
        {
            KeyDown(17);
            Delay(66);
            KeyPress(67);
            Delay(66);
            KeyUp(17);
        }

        /// <summary>
        /// ctrl+x 剪切
        /// </summary>
        public static void KeyCtrlX()
        {
            KeyDown(17);
            Delay(66);
            KeyPress(88);
            Delay(66);
            KeyUp(17);
        }

        /// <summary>
        /// ctrl+v 粘贴
        /// </summary>
        public static void KeyCtrlV()
        {
            KeyDown(17);
            Delay(66);
            KeyPress(86);
            Delay(66);
            KeyUp(17);
        }

        /// <summary>
        /// ctrl+a 全选
        /// </summary>
        public static void KeyCtrlA()
        {
            KeyDown(17);
            Delay(66);
            KeyPress(65);
            Delay(66);
            KeyUp(17);
        }

        #endregion

        #region 鼠标操作

        /// <summary>
        /// 鼠标左键按下
        /// </summary>
        public static void LeftDown()
        {
            Mouse_event(0x0002, 1, 0, 0, 0);
        }

        /// <summary>
        /// 鼠标左键弹起
        /// </summary>
        public static void LeftUp()
        {
            Mouse_event(0x0004, 1, 0, 0, 0);
        }

        /// <summary>
        /// 鼠标左键点击
        /// </summary>
        public static void LeftClick()
        {
            Mouse_event(0x0002, 1, 0, 0, 0);
            Mouse_event(0x0004, 1, 0, 0, 0);
        }

        /// <summary>
        /// 鼠标右键按下
        /// </summary>
        public static void RightDown()
        {
            Mouse_event(0x0008, 1, 0, 0, 0);
        }

        /// <summary>
        /// 鼠标右键弹起
        /// </summary>
        public static void RightUp()
        {
            Mouse_event(0x0010, 1, 0, 0, 0);
        }

        /// <summary>
        /// 鼠标右键点击
        /// </summary>
        public static void RightClick()
        {
            Mouse_event(0x0008, 1, 0, 0, 0);
            Mouse_event(0x0010, 1, 0, 0, 0);
        }

        /// <summary>
        /// 鼠标中键按下
        /// </summary>
        public static void MiddleDown()
        {
            Mouse_event(0x0020, 1, 0, 0, 0);
        }

        /// <summary>
        /// 鼠标中键弹起
        /// </summary>
        public static void MiddleUp()
        {
            Mouse_event(0x0040, 1, 0, 0, 0);
        }

        /// <summary>
        /// 鼠标中键点击
        /// </summary>
        public static void MiddleClick()
        {
            Mouse_event(0x0020, 1, 0, 0, 0);
            Mouse_event(0x0040, 1, 0, 0, 0);
        }

        /// <summary>
        /// 鼠标滚轮向下滚动
        /// </summary>
        public static void WheelDown(int d)
        {
            Mouse_event(0x800, 0, 0, d * -1, 0);
        }

        /// <summary>
        /// 鼠标滚轮向上滚动
        /// </summary>
        public static void WheelUp(int d)
        {
            Mouse_event(0x800, 0, 0, d, 0);
        }

        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="x">屏幕x坐标</param>
        /// <param name="y">屏幕y坐标</param>
        public static void MoveTo(int x, int y)
        {
            SetCursorPos(x, y);
        }

        /// <summary>
        /// 获取当前鼠标坐标
        /// </summary>
        /// <param name="x">鼠标x</param>
        /// <param name="y">鼠标y</param>
        public static void GetCursorPos(out int x, out int y)
        {
            var screenPoint = Control.MousePosition;
            x = screenPoint.X;
            y = screenPoint.Y;
        }

        #endregion

        #region 键鼠综合操作

        /// <summary>
        /// 移动并点击(左键)
        /// </summary>
        /// <param name="x">鼠标x</param>
        /// <param name="y">鼠标y</param>
        public static void MoveClickL(int x, int y)
        {
            MoveTo(x, y);
            Delay(66);
            LeftClick();
        }

        /// <summary>
        /// 移动并点击(右键)
        /// </summary>
        /// <param name="x">鼠标x</param>
        /// <param name="y">鼠标y</param>
        public static void MoveClickR(int x, int y)
        {
            MoveTo(x, y);
            Delay(66);
            RightClick();
        }

        /// <summary>
        /// 移动并点击且输入
        /// </summary>
        /// <param name="x">鼠标x</param>
        /// <param name="y">鼠标y</param>
        /// <param name="s">输入的文本</param>
        public static void MoveClickSend(int x, int y, string s)
        {
            MoveClickL(x, y);
            Delay(66);
            SetClipboard(s);
            Delay(66);
            KeyCtrlV();
        }

        /// <summary>
        /// 移动并点击且键入
        /// </summary>
        /// <param name="x">鼠标x</param>
        /// <param name="y">鼠标y</param>
        /// <param name="s">键入的按键字符串</param>
        public static void MoveClickKsy(int x, int y, string s)
        {
            MoveClickL(x, y);
            KeyPressStr(s);
        }

        #endregion

        #region 文件操作

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="srcFile">源文件路径</param>
        /// <param name="dstFile">目标文件路径</param>
        /// <param name="over">是否覆盖</param>
        /// <returns>0:失败 1:成功</returns>
        public static int CopyFile(string srcFile, string dstFile, bool over)
        {
            try
            {
                File.Copy(srcFile, dstFile, over);
            }
            catch (Exception e)
            {
                _lastError = $"复制文件: {e}";
                return 0;
            }
            return 1;
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="folder">目录路径</param>
        /// <returns>0:失败 1:成功</returns>
        public static int CreateFolder(string folder)
        {
            try
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
            }
            catch (Exception e)
            {
                _lastError = $"创建目录: {e}";
                return 0;
            }
            return 1;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="file">文件路径</param>
        /// <returns>0:失败 1:成功</returns>
        public static int DeleteFile(string file)
        {
            try
            {
                File.Delete(file);
            }
            catch (Exception e)
            {
                _lastError = $"删除文件: {e}";
                return 0;
            }
            return 1;
        }

        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="folder">目录路径</param>
        /// <returns>0:失败 1:成功</returns>
        public static int DeleteFolder(string folder)
        {
            try
            {
                Directory.Delete(folder);
            }
            catch (Exception e)
            {
                _lastError = $"删除目录: {e}";
                return 0;
            }
            return 1;
        }

        /// <summary>
        /// 确定文件是否存在
        /// </summary>
        /// <param name="file">文件路径</param>
        /// <returns>0:不存在 1:存在</returns>
        public static int IsFileExist(string file)
        {
            try
            {
                return File.Exists(file) ? 1 : 0;
            }
            catch (Exception e)
            {
                _lastError = $"确定文件是否存在: {e}";
                return 0;
            }
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="srcFile">源文件路径</param>
        /// <param name="dstFile">目标文件路径</param>
        /// <returns>0:失败 1:成功</returns>
        public static int MoveFile(string srcFile, string dstFile)
        {
            try
            {
                File.Move(srcFile, dstFile);
            }
            catch (Exception e)
            {
                _lastError = $"移动文件: {e}";
                return 0;
            }
            return 1;
        }

        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="file">文件路径</param>
        /// <returns>内容</returns>
        public static string ReadFile(string file)
        {
            try
            {
                return File.ReadAllText(file);
            }
            catch (Exception e)
            {
                _lastError = $"读取文件内容: {e}";
                return string.Empty;
            }
        }

        /// <summary>
        /// 读取INI文件内容
        /// </summary>
        /// <param name="section">小节名</param>
        /// <param name="key">变量名</param>
        /// <param name="file">文件路径</param>
        /// <returns>内容</returns>
        public static string ReadIni(string section, string key, string file)
        {
            try
            {
                var sb = new StringBuilder(255);
                GetPrivateProfileString(section, key, "", sb, 255, file);
                return sb.ToString().Trim();
            }
            catch (Exception e)
            {
                _lastError = $"读取INI文件内容: {e}";
                return string.Empty;
            }
        }

        /// <summary>
        /// 弹出选择文件夹对话框，并返回选择的文件夹路径.
        /// </summary>
        /// <returns>文件夹路径</returns>
        public static string SelectDirectory()
        {
            try
            {
                var fdlg = new FolderBrowserDialog();
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    return fdlg.SelectedPath;
                }
            }
            catch (Exception e)
            {
                _lastError = $"选择文件夹: {e}";
                return string.Empty;
            }
            return string.Empty;
        }

        /// <summary>
        /// 弹出选择文件对话框，并返回选择的文件路径.
        /// </summary>
        /// <returns>文件路径</returns>
        public static string SelectFile()
        {
            try
            {
                var fdlg = new OpenFileDialog();
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    return fdlg.FileName;
                }
            }
            catch (Exception e)
            {
                _lastError = $"选择文件: {e}";
                return string.Empty;
            }
            return string.Empty;
        }

        /// <summary>
        /// 向指定文件追加字符串
        /// </summary>
        /// <param name="file">文件路径</param>
        /// <param name="content">内容</param>
        /// <returns>0:失败 1:成功</returns>
        public static int WriteFile(string file, string content)
        {
            try
            {
                var sw = new StreamWriter(file, true);
                sw.WriteLine(content);
                sw.Close();
            }
            catch (Exception e)
            {
                _lastError = $"向指定文件追加字符串: {e}";
                return 0;
            }
            return 1;
        }

        /// <summary>
        /// 向指定的Ini写入信息
        /// </summary>
        /// <param name="section">节点</param>
        /// <param name="key">变量名</param>
        /// <param name="value">变量值</param>
        /// <param name="file">文件路径</param>
        /// <returns>0:失败 1:成功</returns>
        public static int WriteIni(string section, string key, string value, string file)
        {
            try
            {
                WritePrivateProfileString(section, key, value, file);
            }
            catch (Exception e)
            {
                _lastError = $"向指定的Ini写入信息: {e}";
                return 0;
            }
            return 1;
        }

        #endregion

        #region 窗口操作

        /// <summary>
        /// 获取窗体的句柄函数
        /// </summary>
        /// <param name="lpClassName">窗口类名</param>
        /// <param name="lpWindowName">窗口标题名</param>
        /// <returns>返回第一个找到的句柄</returns>
        public static int FindWindow(string lpClassName, string lpWindowName)
        {
            if (lpClassName == string.Empty) lpClassName = null;
            if (lpWindowName == string.Empty) lpWindowName = null;
            return (int)FWindow(lpClassName, lpWindowName);
        }

        /// <summary>
        /// 获取窗体的句柄函数(高级)
        /// </summary>
        /// <param name="hwndParent">父窗体句柄(若父窗体值为0此方法同FindWindow)</param>
        /// <param name="lpClassName">窗口类名</param>
        /// <param name="lpWindowName">窗口标题名</param>
        /// <returns>返回第一个找到的句柄</returns>
        public static int FindWindowEx(int hwndParent, string lpClassName, string lpWindowName)
        {
            if (lpClassName == string.Empty) lpClassName = null;
            if (lpWindowName == string.Empty) lpWindowName = null;
            return (int)FWindowEx((IntPtr)hwndParent, IntPtr.Zero, lpClassName, lpWindowName);
        }

        /// <summary>
        /// 获取窗体的句柄函数(模糊匹配)
        /// </summary>
        /// <param name="lpClassName">窗口类名</param>
        /// <param name="lpWindowName">窗口标题名</param>
        /// <returns>返回句柄集合</returns>
        public static List<int> EnumWindows(string lpClassName, string lpWindowName)
        {
            var wndList = new List<int>();
            EWindows(delegate (IntPtr hWnd, int y)
            {
                var sb = new StringBuilder(256);
                GetClassNameW(hWnd, sb, sb.Capacity);
                var windowClass = sb.ToString();
                GetWindowTextW(hWnd, sb, sb.Capacity);
                var windowText = sb.ToString();
                if (lpClassName == string.Empty && lpWindowName == string.Empty)
                {
                    if (windowText.Contains(lpWindowName) && windowClass.Contains(lpClassName))
                    {
                        wndList.Add((int)hWnd);
                    }
                }
                else if (lpClassName == string.Empty)
                {
                    if (windowText.Contains(lpWindowName))
                    {
                        wndList.Add((int)hWnd);
                    }
                }
                else if (lpWindowName == string.Empty)
                {

                    if (windowClass.Contains(lpClassName))
                    {
                        wndList.Add((int)hWnd);
                    }
                }
                return true;
            }, 0);
            return wndList;
        }

        /// <summary>
        /// 获取窗口位置
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="zx">返回窗口左x坐标</param>
        /// <param name="zy">返回窗口左y坐标</param>
        /// <param name="yx">返回窗口右x坐标</param>
        /// <param name="yy">返回窗口右y坐标</param>
        /// <returns>0:失败 1:成功</returns>
        public static int GetWindowRect(int hwnd, out int zx, out int zy, out int yx, out int yy)
        {
            zx = zy = yx = yy = -1;
            try
            {
                GetWindowRect((IntPtr)hwnd, out var ipRect);
                zx = ipRect.left;
                zy = ipRect.top;
                yx = ipRect.right;
                yy = ipRect.bottom;
            }
            catch (Exception e)
            {
                _lastError = $"获取窗口位置: {e}";
                return 0;
            }
            return 1;
        }

        /// <summary>
        /// 设置窗口大小
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="w">宽</param>
        /// <param name="h">高</param>
        /// <returns>0:失败 1:成功</returns>
        public static int SetWindowSize(int hwnd, int w, int h)
        {
            try
            {
                GetWindowRect(hwnd, out var zx, out var zy, out _, out _);
                return MoveWindow((IntPtr)hwnd, zx, zy, w, h, true);
            }
            catch (Exception e)
            {
                _lastError = $"设置窗口大小: {e}";
                return 0;
            }
        }

        /// <summary>
        /// 移动窗口
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        /// <returns>0:失败 1:成功</returns>
        public static int MoveWindow(int hwnd, int x, int y)
        {
            try
            {
                GetWindowRect(hwnd, out var zx, out var zy, out var yx, out var yy);
                return MoveWindow((IntPtr)hwnd, x - 6, y, yx - zx, yy - zy, true);
            }
            catch (Exception e)
            {
                _lastError = $"移动窗口: {e}";
                return 0;
            }
        }

        /// <summary>
        /// 设置窗口的状态
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="type">状态类型</param>
        /// <returns>0:失败 1:成功</returns>
        public static int SetWindowState(int hwnd, int type)
        {
            try
            {

                return ShowWindow((IntPtr)hwnd, type);
            }
            catch (Exception e)
            {
                _lastError = $"设置窗口的状态: {e}";
                return 0;
            }
        }

        #endregion

        #region 图色操作

        /// <summary> 
        /// 屏幕截图 
        /// </summary> 
        /// <param name="x"></param> 
        /// <param name="y"></param> 
        /// <param name="width"></param> 
        /// <param name="height"></param> 
        /// <returns></returns> 
        public static Bitmap CopyScreen(int x, int y, int width, int height)
        {
            var bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(x, y, 0, 0, new Size(width, height));
            }
            return bitmap;
        }

        /// <summary>
        /// 在大图里找小图
        /// </summary>
        /// <param name="S_bmp">大图</param>
        /// <param name="P_bmp">小图</param>
        /// <param name="rect">指定只在大图指定区域内查找，全图查找请设为 Rectangle.Empty</param>
        /// <returns></returns>
        public static unsafe List<Point> FindPic(Bitmap S_bmp, Bitmap P_bmp, Rectangle rect)
        {
            if (S_bmp.PixelFormat != PixelFormat.Format24bppRgb) { throw new Exception("颜色格式只支持24位bmp"); }
            if (P_bmp.PixelFormat != PixelFormat.Format24bppRgb) { throw new Exception("颜色格式只支持24位bmp"); }
            var S_Width = S_bmp.Width;
            var S_Height = S_bmp.Height;
            var P_Width = P_bmp.Width;
            var P_Height = P_bmp.Height;
            if (rect == Rectangle.Empty) { rect = new Rectangle(0, 0, S_Width, S_Height); }
            var S_Data = S_bmp.LockBits(new Rectangle(0, 0, S_Width, S_Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            var P_Data = P_bmp.LockBits(new Rectangle(0, 0, P_Width, P_Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            var List = new List<Point>();
            var S_stride = S_Data.Stride;
            var P_stride = P_Data.Stride;
            var P_offset = P_stride - P_Data.Width * 3;
            var S_Iptr = S_Data.Scan0;
            var P_Iptr = P_Data.Scan0;
            var IsOk = false;
            var _BreakW = S_Width - P_Width + 1;
            var _BreakH = S_Height - P_Height + 1;
            for (var h = rect.Y; h < _BreakH; h++)
            {
                for (var w = rect.X; w < _BreakW; w++)
                {
                    var P_ptr = (byte*)P_Iptr;
                    for (var y = 0; y < P_Height; y++)
                    {
                        for (var x = 0; x < P_Width; x++)
                        {
                            var S_ptr = (byte*)(S_Iptr + S_stride * (h + y) + (w + x) * 3);
                            if (P_ptr != null && S_ptr != null && S_ptr[0] == P_ptr[0] && S_ptr[1] == P_ptr[1] && S_ptr[2] == P_ptr[2])
                            {
                                IsOk = true;
                            }
                            else
                            {
                                IsOk = false; break;
                            }
                            P_ptr += 3;
                        }
                        if (IsOk == false) { break; }
                        P_ptr += P_offset;
                    }
                    if (IsOk) { List.Add(new Point(w, h)); }
                    IsOk = false;
                }
            }
            S_bmp.UnlockBits(S_Data);
            P_bmp.UnlockBits(P_Data);
            return List;
        }


        /// <summary>
        /// 取坐标点颜色
        /// </summary>
        /// <param name="x">坐标x</param>
        /// <param name="y">坐标y</param>
        /// <returns>颜色字符串</returns>
        public static string GetColor(int x, int y)
        {
            try
            {
                var sWidth = Screen.AllScreens[0].Bounds.Width;
                var sHeight = Screen.AllScreens[0].Bounds.Height;
                var parBitmap = new Bitmap(sWidth, sHeight, PixelFormat.Format24bppRgb);
                using (var g = Graphics.FromImage(parBitmap))
                {
                    g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(sWidth, sHeight));
                }
                var color = parBitmap.GetPixel(x, y);
                return color.Name.Substring(2);
            }
            catch (Exception e)
            {
                _lastError = $"取色: {e}";
            }
            return string.Empty;
        }

        /// <summary>
        /// 找图
        /// </summary>
        /// <param name="zx">左上角x</param>
        /// <param name="zy">左上角y</param>
        /// <param name="yx">右下角x</param>
        /// <param name="yy">右下角y</param>
        /// <param name="pic">要查找的图片路径</param>
        /// <param name="intX">返回的x坐标</param>
        /// <param name="intY">返回的y坐标</param>
        public static void FindPic(int zx, int zy, int yx, int yy, string pic, out int intX, out int intY)
        {
            intX = intY = -1;
            var sBmp = CopyScreen(zx, zy, yx - zx, yy - zy);
            var pBmp = GetBitmap(pic);
            var picArr = FindPic(sBmp, pBmp, Rectangle.Empty);
            if (picArr == null || picArr.Count <= 0) return;
            intX = picArr[0].X;
            intY = picArr[0].Y;
        }

        #endregion

        #region 后台操作

        /// <summary>
        /// 根据句柄发送一个字符串
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="input">字符串</param>
        public static void SendStr(int hwnd, string input)
        {
            if (string.IsNullOrEmpty(input)) return;
            foreach (var t in input)
            {
                SendMessage((IntPtr)hwnd, 0x0102, (IntPtr)t, IntPtr.Zero);
            }
        }

        /// <summary>
        /// 根据句柄按下鼠标左键
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        public static void SendLeftDown(int hwnd, int x, int y)
        {
            PostMessage((IntPtr)hwnd, 0x201, (IntPtr)1, (IntPtr)(x + (y << 16)));
        }

        /// <summary>
        /// 根据句柄弹起鼠标左键
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        public static void SendLeftUp(int hwnd, int x, int y)
        {
            PostMessage((IntPtr)hwnd, 0x202, (IntPtr)1, (IntPtr)(x + (y << 16)));
        }

        /// <summary>
        /// 根据句柄点击鼠标左键
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        public static void SendLeftClick(int hwnd, int x, int y)
        {
            PostMessage((IntPtr)hwnd, 0x201, (IntPtr)1, (IntPtr)(x + (y << 16)));
            PostMessage((IntPtr)hwnd, 0x202, (IntPtr)1, (IntPtr)(x + (y << 16)));
        }

        /// <summary>
        /// 根据句柄按下鼠标右键
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        public static void SendRightDown(int hwnd, int x, int y)
        {
            PostMessage((IntPtr)hwnd, 0x204, (IntPtr)1, (IntPtr)(x + (y << 16)));
        }

        /// <summary>
        /// 根据句柄弹起鼠标右键
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        public static void SendRightUp(int hwnd, int x, int y)
        {
            PostMessage((IntPtr)hwnd, 0x205, (IntPtr)1, (IntPtr)(x + (y << 16)));
        }

        /// <summary>
        /// 根据句柄点击鼠标右键
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        public static void SendRightClick(int hwnd, int x, int y)
        {
            PostMessage((IntPtr)hwnd, 0x204, (IntPtr)1, (IntPtr)(x + (y << 16)));
            PostMessage((IntPtr)hwnd, 0x205, (IntPtr)1, (IntPtr)(x + (y << 16)));
        }

        /// <summary>
        /// 根据句柄键盘按下
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="bVk">键代码</param>
        public static void SendKeyDown(int hwnd, Keys bVk)
        {
            SendMessage((IntPtr)hwnd, 0X104, (IntPtr)bVk, IntPtr.Zero);
        }

        /// <summary>
        /// 根据句柄键盘弹起
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="bVk">键代码</param>
        public static void SendKeyUp(int hwnd, Keys bVk)
        {
            SendMessage((IntPtr)hwnd, 0X101, (IntPtr)bVk, IntPtr.Zero);
        }

        /// <summary>
        /// 根据句柄键盘按键
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="bVk">键代码</param>
        public static void SendKeyPress(int hwnd, Keys bVk)
        {
            SendMessage((IntPtr)hwnd, 0X106, (IntPtr)bVk, IntPtr.Zero);
        }

        #endregion
    }
}
