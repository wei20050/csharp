using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace yxz
{
    public class KeyHook
    {
        #region 常数和结构

        public const int WmKeydown = 0x100;
        public const int WmKeyup = 0x101;
        public const int WmSyskeydown = 0x104;
        public const int WmSyskeyup = 0x105;
        public const int WhKeyboardLl = 13;

        [StructLayout(LayoutKind.Sequential)] //声明键盘钩子的封送结构类型 
        public class KeyboardHookStruct
        {
            public int vkCode; //表示一个在1到254间的虚似键盘码 
            public int scanCode; //表示硬件扫描码 
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        #endregion

        #region 钩子Api

        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);
        //安装钩子的函数 
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        //卸下钩子的函数 
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);
        //下一个钩挂的函数 
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);
        [DllImport("user32")]
        public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);
        [DllImport("user32")]
        public static extern int GetKeyboardState(byte[] pbKeyState);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        #endregion

        #region 钩子方法定义

        int _hHook;

        HookProc _keyboardHookDelegate;

        //按下按键触发
        public event KeyEventHandler OnKeyDownEvent;

        //弹起按键触发
        public event KeyEventHandler OnKeyUpEvent;

        //按下并弹起按键触发
        public event KeyPressEventHandler OnKeyPressEvent;

        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private List<Keys> _preKeysList = new List<Keys>();//存放被按下的控制键，用来生成具体的键

        private int KeyboardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            //如果该消息被丢弃（nCode<0）或者没有事件绑定处理程序则不会触发事件
            if ((nCode >= 0) && (OnKeyDownEvent != null || OnKeyUpEvent != null || OnKeyPressEvent != null))
            {
                var keyDataFromHook = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
                var keyData = (Keys)keyDataFromHook.vkCode;
                //按下控制键
                if ((OnKeyDownEvent != null || OnKeyPressEvent != null) && (wParam == WmKeydown || wParam == WmSyskeydown))
                {
                    if (IsCtrlAltShiftKeys(keyData) && _preKeysList.IndexOf(keyData) == -1)
                    {
                        _preKeysList.Add(keyData);
                    }
                }
                //WM_KEYDOWN和WM_SYSKEYDOWN消息，将会引发OnKeyDownEvent事件
                if (OnKeyDownEvent != null && (wParam == WmKeydown || wParam == WmSyskeydown))
                {
                    var e = new KeyEventArgs(GetDownKeys(keyData));

                    OnKeyDownEvent?.Invoke(this, e);
                }
                //WM_KEYDOWN消息将引发OnKeyPressEvent 
                if (OnKeyPressEvent != null && wParam == WmKeydown)
                {
                    var keyState = new byte[256];
                    GetKeyboardState(keyState);
                    var inBuffer = new byte[2];
                    if (ToAscii(keyDataFromHook.vkCode, keyDataFromHook.scanCode, keyState, inBuffer, keyDataFromHook.flags) == 1)
                    {
                        var e = new KeyPressEventArgs((char)inBuffer[0]);
                        OnKeyPressEvent(this, e);
                    }
                }
                //松开控制键
                if ((OnKeyDownEvent != null || OnKeyPressEvent != null) && (wParam == WmKeyup || wParam == WmSyskeyup))
                {
                    if (IsCtrlAltShiftKeys(keyData))
                    {
                        for (var i = _preKeysList.Count - 1; i >= 0; i--)
                        {
                            if (_preKeysList[i] == keyData) { _preKeysList.RemoveAt(i); }
                        }
                    }
                }
                //WM_KEYUP和WM_SYSKEYUP消息，将引发OnKeyUpEvent事件 
                if (OnKeyUpEvent != null && (wParam == WmKeyup || wParam == WmSyskeyup))
                {
                    var e = new KeyEventArgs(GetDownKeys(keyData));
                    OnKeyUpEvent?.Invoke(this, e);
                }
            }
            return CallNextHookEx(_hHook, nCode, wParam, lParam);
        }

        //根据已经按下的控制键生成key
        private Keys GetDownKeys(Keys key)
        {
            var rtnKey = Keys.None;
            foreach (var i in _preKeysList)
            {
                if (i == Keys.LControlKey || i == Keys.RControlKey) { rtnKey = rtnKey | Keys.Control; }
                if (i == Keys.LMenu || i == Keys.RMenu) { rtnKey = rtnKey | Keys.Alt; }
                if (i == Keys.LShiftKey || i == Keys.RShiftKey) { rtnKey = rtnKey | Keys.Shift; }
            }
            return rtnKey | key;
        }

        private bool IsCtrlAltShiftKeys(Keys key)
        {
            if (key == Keys.LControlKey || key == Keys.RControlKey || key == Keys.LMenu || key == Keys.RMenu || key == Keys.LShiftKey || key == Keys.RShiftKey) { return true; }
            return false;
        }

        /// <summary>
        /// 注册钩子
        /// </summary>
        public void SetHook()
        {
            _keyboardHookDelegate = KeyboardHookProc;
            var cProcess = Process.GetCurrentProcess();
            var cModule = cProcess.MainModule;
            var mh = GetModuleHandle(cModule.ModuleName);
            _hHook = SetWindowsHookEx(WhKeyboardLl, _keyboardHookDelegate, mh, 0);
        }

        /// <summary>
        /// 注销钩子
        /// </summary>
        public void UnHook()
        {
            UnhookWindowsHookEx(_hHook);
        }

        #endregion
    }
}
