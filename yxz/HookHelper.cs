using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

// ReSharper disable UnusedMember.Global

namespace yxz
{
    /// <summary>
    /// 键盘钩子帮助类
    /// </summary>
    public class HookHelper
    {
        /// <summary>
        /// 键盘按下事件
        /// </summary>
        public event KeyEventHandler KeyDownEvent;
        /// <summary>
        /// 键盘按键事件
        /// </summary>
        public event KeyPressEventHandler KeyPressEvent;
        /// <summary>
        /// 键盘弹起事件
        /// </summary>
        public event KeyEventHandler KeyUpEvent;

        //键盘钩子标识
        private int _hKeyboardHook;

        private const int SwWmKeydown = 0x100;
        private const int SwWmKeyup = 0x101;
        private const int SwWmSysKeyDown = 0x104;
        private const int SwWmSysKeyUp = 0x105;
        //线程键盘钩子监听鼠标消息设为2，全局键盘监听鼠标消息设为13
        private const int SwWhKeyboardLl = 13;

        /// <summary>
        /// 键盘钩子的封送结构类型
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class KeyboardHookStruct
        {
            /// <summary>
            /// 定一个虚拟键码。该代码必须有一个价值的范围1至254
            /// </summary>
            public int vkCode;
            /// <summary>
            /// 指定的硬件扫描码的关键
            /// </summary>
            public int scanCode;
            /// <summary>
            /// 键标志
            /// </summary>
            public int flags;
            /// <summary>
            /// 指定的时间戳记的这个讯息
            /// </summary>
            public int time;
            /// <summary>
            /// 指定额外信息相关的信息
            /// </summary>
            public int dwExtraInfo; 
        }

        //声明KeyboardHookProcedure作为HookProc类型
        private HookProc _keyboardHookProcedure;
        private readonly List<Keys> _preKeysList = new List<Keys>();//存放被按下的控制键，用来生成具体的键

        /// <summary>
        /// 注册钩子
        /// </summary>
        public void SetHook()
        {
            //************************************
            //关于SetWindowsHookEx (int idHook, HookProc lpn, IntPtr hInstance, int threadId)函数将钩子加入到钩子链表中，说明一下四个参数：
            //idHook 钩子类型，即确定钩子监听何种消息，上面的代码中设为2，即监听键盘消息并且是线程钩子，如果是全局钩子监听键盘消息应设为13，
            //线程钩子监听鼠标消息设为7，全局钩子监听鼠标消息设为14。lpn 钩子子程的地址指针。如果dwThreadId参数为0 或是一个由别的进程创建的
            //线程的标识，lpn必须指向DLL中的钩子子程。 除此以外，lpn可以指向当前进程的一段钩子子程代码。钩子函数的入口地址，当钩子钩到任何
            //消息后便调用这个函数。hInstance应用程序实例的句柄。标识包含lpn所指的子程的DLL。如果threadId 标识当前进程创建的一个线程，而且子
            //程代码位于当前进程，hInstance必须为NULL。可以很简单的设定其为本应用程序的实例句柄。threaded 与安装的钩子子程相关联的线程的标识符
            //如果为0，钩子子程与所有的线程关联，即为全局钩子
            //************************************
            _keyboardHookProcedure = KeyboardHookProc;
            var processModule = System.Diagnostics.Process.GetCurrentProcess().MainModule;
            if (processModule != null)
                _hKeyboardHook = (int)SetWindowsHookEx(SwWhKeyboardLl, _keyboardHookProcedure,
                    GetModuleHandle(processModule.ModuleName),
                    0);
        }

        /// <summary>
        /// 卸载钩子
        /// </summary>
        /// <returns></returns>
        public void UnHook()
        {
            UnhookWindowsHookEx(_hKeyboardHook);
        }

        /// <summary>
        /// 键盘输入（扫码枪扫描）钩子
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private int KeyboardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            //如果该消息被丢弃（nCode<0）或者没有事件绑定处理程序则不会触发事件
            if (nCode >= 0 && (KeyDownEvent != null || KeyUpEvent != null || KeyPressEvent != null))
            {
                var keyDataFromHook = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
                var keyData = (Keys)keyDataFromHook.vkCode;
                //按下控制键
                if ((KeyDownEvent != null || KeyPressEvent != null) && (wParam == SwWmKeydown || wParam == SwWmSysKeyDown))
                {
                    if (IsCtrlAltShiftKeys(keyData) && _preKeysList.IndexOf(keyData) == -1)
                    {
                        _preKeysList.Add(keyData);
                    }
                }
                //WM_KEYDOWN和WM_SYS KEYDOWN消息，将会引发KeyDownEvent事件
                if (KeyDownEvent != null && (wParam == SwWmKeydown || wParam == SwWmSysKeyDown))
                {
                    var e = new KeyEventArgs(GetDownKeys(keyData));

                    KeyDownEvent?.Invoke(this, e);
                }
                //WM_KEYDOWN消息将引发KeyPressEvent 
                if (KeyPressEvent != null && wParam == SwWmKeydown)
                {
                    var keyState = new byte[256];
                    GetKeyboardState(keyState);
                    var inBuffer = new byte[2];
                    if (ToAscii(keyDataFromHook.vkCode, keyDataFromHook.scanCode, keyState,inBuffer, keyDataFromHook.flags) == 1)
                    {
                        var e = new KeyPressEventArgs((char)inBuffer[0]);
                        KeyPressEvent(this, e);
                    }
                }
                //松开控制键
                if ((KeyDownEvent != null || KeyPressEvent != null) && (wParam == SwWmKeyup || wParam == SwWmSysKeyUp))
                {
                    if (IsCtrlAltShiftKeys(keyData))
                    {
                        for (var i = _preKeysList.Count - 1; i >= 0; i--)
                        {
                            if (_preKeysList[i] == keyData) { _preKeysList.RemoveAt(i); }
                        }
                    }
                }
                //WM_KEYUP和WM_SYS KEYUP消息，将引发KeyUpEvent事件 
                if (KeyUpEvent != null && (wParam == SwWmKeyup || wParam == SwWmSysKeyUp))
                {
                    var e = new KeyEventArgs(GetDownKeys(keyData));
                    KeyUpEvent?.Invoke(this, e);
                }
            }
            return (int)CallNextHookEx(new IntPtr(_hKeyboardHook), nCode, new IntPtr(wParam), lParam);
            //返回1吃掉按键 不往下传递
            //return 1;
        }

        /// <summary>
        /// 检查是否是控制键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static bool IsCtrlAltShiftKeys(Keys key)
        {
            return key == Keys.LControlKey || key == Keys.RControlKey || key == Keys.LMenu || key == Keys.RMenu || key == Keys.LShiftKey || key == Keys.RShiftKey;
        }

        /// <summary>
        /// 根据已经按下的控制键生成key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private Keys GetDownKeys(Keys key)
        {
            var rtnKey = Keys.None;
            foreach (var i in _preKeysList)
            {
                switch (i)
                {
                    case Keys.LControlKey:
                    case Keys.RControlKey:
                        rtnKey |= Keys.Control;
                        break;
                    case Keys.LMenu:
                    case Keys.RMenu:
                        rtnKey |= Keys.Alt;
                        break;
                    case Keys.LShiftKey:
                    case Keys.RShiftKey:
                        rtnKey |= Keys.Shift;
                        break;
                }
            }
            return rtnKey | key;
        }


        #region Win32

        /// <summary>
        /// 钩子过程
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);

        /// <summary>
        /// 安装钩子
        /// </summary>
        /// <param name="idHook"></param>
        /// <param name="lpn"></param>
        /// <param name="hInstance"></param>
        /// <param name="threadId"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpn, IntPtr hInstance, int threadId);

        /// <summary>
        /// //卸载钩子
        /// </summary>
        /// <param name="idHook"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool UnhookWindowsHookEx(int idHook);

        /// <summary>
        /// 通过信息钩子继续下一个钩子
        /// </summary>
        /// <param name="idHook"></param>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 取得当前线程编号（线程钩子需要用到）
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        internal static extern int GetCurrentThreadId();

        /// <summary>
        /// 使用WINDOWS API函数代替获取当前实例的函数,防止钩子失效
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);

        /// <summary>
        /// 获取按键的状态
        /// </summary>
        /// <param name="pbKeyState"></param>
        /// <returns></returns>
        [DllImport("user32", EntryPoint = "GetKeyboardState")]
        internal static extern int GetKeyboardState(byte[] pbKeyState);

        /// <summary>
        /// 转换指定的虚拟键码和键盘状态的相应字符
        /// </summary>
        /// <param name="uVirtualKey">[in] 指定虚拟关键代码进行翻译</param>
        /// <param name="uScanCode">[in] 指定的硬件扫描码的关键须翻译成英文。高阶位的这个值设定的关键，如果是（不压）</param>
        /// <param name="lpbKeyState">[in] 指针，以256字节数组，包含当前键盘的状态。每个元素（字节）的数组包含状态的一个关键。如果高阶位的字节是一套，关键是下跌（按下）。在低比特，如果设置表明，关键是对切换。在此功能，只有肘位的CAPS LOCK键是相关的。在切换状态的NUM个锁和滚动锁定键被忽略。</param>
        /// <param name="lpwTransKey">[out] 指针的缓冲区收到翻译字符。</param>
        /// <param name="fuState">[in] Specifies whether a menu is active. This parameter must be 1 if a menu is active, or 0 otherwise.</param>
        /// <returns></returns>
        [DllImport("user32", EntryPoint = "ToAscii")]
        internal static extern int ToAscii(int uVirtualKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

        [DllImport("user32", EntryPoint = "GetKeyNameText", BestFitMapping = false)]
        internal static extern int GetKeyNameText(int param, StringBuilder lpBuffer, int nSize);

        #endregion

    }
}
