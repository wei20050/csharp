using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace yxz
{
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
        private static extern void Keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
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
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr processId);
        [DllImport("user32.dll")]
        private static extern bool GetGUIThreadInfo(uint idThread, ref Guithreadinfo lpgui);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FWindow(string lpClassName, string lpWindowName);
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
        public static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRePaint);
        [DllImport("user32.dll")]
        public static extern int ShowWindow(int hwnd, int nCmdShow);

        #endregion

        #region 全局变量

        /// <summary>
        /// 最后一次错误信息
        /// </summary>
        private static string _lastError = string.Empty;

        #endregion

        #region 结构

        [StructLayout(LayoutKind.Sequential)]
        public struct Guithreadinfo
        {
            public int cbSize;
            public int flags;
            public IntPtr hwndActive;
            public IntPtr hwndFocus;
            public IntPtr hwndCapture;
            public IntPtr hwndMenuOwner;
            public IntPtr hwndMoveSize;
            public IntPtr hwndCaret;
            public Rect rectCaret;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
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
        /// 找透明图
        /// </summary>
        /// <param name="zx">左上角x</param>
        /// <param name="zy">左上角y</param>
        /// <param name="yx">右下角x</param>
        /// <param name="yy">右下角y</param>
        /// <param name="pic">要查找的图片</param>
        /// <param name="simc">颜色相似度</param>
        /// <param name="sim">匹配相似度</param>
        /// <param name="intX">返回的x坐标</param>
        /// <param name="intY">返回的y坐标</param>
        private static void FindPicE(int zx, int zy, int yx, int yy, string pic, double simc, double sim, out int intX, out int intY)
        {
            intX = intY = -1;
            var errorRange = Convert.ToByte(255 - 255 * simc);
            var parWidth = Screen.AllScreens[0].Bounds.Width;
            var parHeight = Screen.AllScreens[0].Bounds.Height;
            var parBitmap = new Bitmap(parWidth, parHeight, PixelFormat.Format24bppRgb);
            using (var g = Graphics.FromImage(parBitmap))
            {
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(parWidth, parHeight));
            }
            var searchRect = new Rectangle(zx, zy, yx - zx, yy - zy);
            if (searchRect.IsEmpty)
            {
                searchRect = new Rectangle(0, 0, parWidth, parHeight);
            }
            var subBitmap = new Bitmap(pic);
            var subWidth = subBitmap.Width;
            var subHeight = subBitmap.Height;
            var bgColor = subBitmap.GetPixel(0, 0); //背景色
            var searchLeftTop = searchRect.Location;
            var searchSize = searchRect.Size;
            var subData = subBitmap.LockBits(new Rectangle(0, 0, subBitmap.Width, subBitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var parData = parBitmap.LockBits(new Rectangle(0, 0, parBitmap.Width, parBitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var byteArrarySub = new byte[subData.Stride * subData.Height];
            var byteArraryPar = new byte[parData.Stride * parData.Height];
            Marshal.Copy(subData.Scan0, byteArrarySub, 0, subData.Stride * subData.Height);
            Marshal.Copy(parData.Scan0, byteArraryPar, 0, parData.Stride * parData.Height);
            var iMax = searchLeftTop.Y + searchSize.Height - subData.Height; //行
            var jMax = searchLeftTop.X + searchSize.Width - subData.Width; //列
            var startPixelColor = Color.FromArgb(0, 0, 0);
            int smallOffsetX = 0, smallOffsetY = 0;


            for (var m = 0; m < subHeight; m++)
            {
                for (var n = 0; n < subWidth; n++)
                {
                    smallOffsetX = n;
                    smallOffsetY = m;
                    var subIndex = m * subWidth * 4 + n * 4;
                    var color = Color.FromArgb(byteArrarySub[subIndex + 3], byteArrarySub[subIndex + 2],
                        byteArrarySub[subIndex + 1], byteArrarySub[subIndex]);
                    if (ColorAEqualColorB(color, bgColor, errorRange)) continue;
                    startPixelColor = color;
                    goto END;
                }
            }

            END:
            for (var i = searchLeftTop.Y; i < iMax; i++)
            {
                for (var j = searchLeftTop.X; j < jMax; j++)
                {
                    //大图x，y坐标处的颜色值
                    int x = j, y = i;
                    var parIndex = i * parWidth * 4 + j * 4;
                    var colorBig = Color.FromArgb(byteArraryPar[parIndex + 3],
                        byteArraryPar[parIndex + 2], byteArraryPar[parIndex + 1], byteArraryPar[parIndex]);
                    if (!ColorAEqualColorB(colorBig, startPixelColor, errorRange)) continue;
                    var smallStartX = x - smallOffsetX;
                    var smallStartY = y - smallOffsetY;
                    var sum = 0; //所有需要比对的有效点
                    var matchNum = 0; //成功匹配的点
                    for (var m = 0; m < subHeight; m++)
                    {
                        for (var n = 0; n < subWidth; n++)
                        {
                            int x1 = n, y1 = m;
                            var subIndex = m * subWidth * 4 + n * 4;
                            var color = Color.FromArgb(byteArrarySub[subIndex + 3],
                                byteArrarySub[subIndex + 2], byteArrarySub[subIndex + 1], byteArrarySub[subIndex]);
                            if (color == bgColor) continue;
                            sum++;
                            int x2 = smallStartX + x1, y2 = smallStartY + y1;
                            var parReleativeIndex = y2 * parWidth * 4 + x2 * 4; //比对大图对应的像素点的颜色
                            var colorPixel = Color.FromArgb(byteArraryPar[parReleativeIndex + 3],
                                byteArraryPar[parReleativeIndex + 2], byteArraryPar[parReleativeIndex + 1],
                                byteArraryPar[parReleativeIndex]);
                            if (ColorAEqualColorB(colorPixel, color, errorRange))
                            {
                                matchNum++;
                            }
                        }
                    }
                    var rate = (double)matchNum / sum;
                    if (!(rate >= sim)) continue;
                    intX = smallStartX + (int)(subWidth / 2.0);
                    intY = smallStartY + (int)(subHeight / 2.0);
                    goto FIND_END;
                }
            }
            FIND_END:
            subBitmap.UnlockBits(subData);
            parBitmap.UnlockBits(parData);
            subBitmap.Dispose();
            parBitmap.Dispose();
            GC.Collect();
        }
        /// <summary>
        /// 对比两个颜色的误差
        /// </summary>
        /// <param name="colorA">颜色a</param>
        /// <param name="colorB">颜色b</param>
        /// <param name="errorRange">误差值</param>
        /// <returns></returns>
        private static bool ColorAEqualColorB(Color colorA, Color colorB, byte errorRange = 10)
        {
            return colorA.A <= colorB.A + errorRange && colorA.A >= colorB.A - errorRange &&
                   colorA.R <= colorB.R + errorRange && colorA.R >= colorB.R - errorRange &&
                   colorA.G <= colorB.G + errorRange && colorA.G >= colorB.G - errorRange &&
                   colorA.B <= colorB.B + errorRange && colorA.B >= colorB.B - errorRange;
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
        /// <param name="format">数据类型</param>
        /**参数以类DataFormats 指定 说明如下
        DataFormats      名称	                说明
        公共字段静态成员 Bitmap                 指定 Windows 位图格式。 此 static 字段是只读的。
        公共字段静态成员 CommaSeparatedValue    指定以逗号分隔值(CSV) 的格式，这是电子表格常用的交换格式。 Windows 窗体不直接使用此格式。 此 static 字段是只读的。
        公共字段静态成员 Dib                    指定 Windows     与设备无关的位图(DIB) 格式。 此 static 字段是只读的。
        公共字段静态成员 Dif                    指定 Windows 数据交换格式(DIF)，Windows 窗体不直接使用此格式。 此 static 字段是只读的。
        公共字段静态成员 EnhancedMetafile       指定 Windows 增强型图元文件格式。 此 static 字段是只读的。
        公共字段静态成员 FileDrop               指定 Windows 文件放置格式，Windows 窗体不直接使用此格式。 此 static 字段是只读的。
        公共字段静态成员 Html                   指定 HTML 剪贴板格式中的文本。 此 static 字段是只读的。
        公共字段静态成员 Locale                 指定 Windows 区域性格式，Windows 窗体不直接使用此格式。 此 static 字段是只读的。
        公共字段静态成员 MetafilePict           指定 Windows 图元文件格式，Windows 窗体不直接使用此格式。 此 static 字段是只读的。
        公共字段静态成员 OemText                指定标准 Windows 原始设备制造商(OEM) 文本格式。 此 static 字段是只读的。
        公共字段静态成员 Palette                指定 Windows 调色板格式。 此 static 字段是只读的。
        公共字段静态成员 PenData                指定 Windows 钢笔数据格式，它由书写软件所使用的笔画组成，Windows 窗体不使用此格式。 此 static 字段是只读的。
        公共字段静态成员 Riff                   指定资源交换文件格式(RIFF) 音频格式，Windows 窗体不直接使用此格式。 此 static 字段是只读的。
        公共字段静态成员 Rtf                    指定由 RTF 数据组成的文本。 此 static 字段是只读的。
        公共字段静态成员 Serializable           指定封装任何类型的 Windows 窗体对象的格式。 此 static 字段是只读的。
        公共字段静态成员 StringFormat           指定 Windows 窗体字符串类格式，Windows 窗体使用此格式存储字符串对象。 此 static 字段是只读的。
        公共字段静态成员 SymbolicLink           指定 Windows 符号链接格式，Windows 窗体不直接使用此格式。 此 static 字段是只读的。
        公共字段静态成员 Text                   指定标准 ANSI 文本格式。 此 static 字段是只读的。
        公共字段静态成员 Tiff                   指定标记图像文件格式(TIFF)，Windows 窗体不直接使用此格式。 此 static 字段是只读的。
        公共字段静态成员 UnicodeText            指定标准 Windows Unicode 文本格式。 此 static 字段是只读的。
        公共字段静态成员 WaveAudio              指定 wave 音频格式，Windows 窗体不直接使用此格式。 此 static 字段是只读的。
        */
        /// <returns>剪切板内容</returns>
        public static object GetClipboard(string format)
        {
            try
            {
                 return  Clipboard.GetData(format);
            }
            catch (Exception e)
            {
                _lastError = $"获取剪切板内容: {e}";
            }
            return null;
        }
        /// <summary>
        /// 设置剪切板内容
        /// </summary>
        /// <returns></returns>
        public static void SetClipboard(object content)
        {
            try
            {
                Clipboard.SetDataObject(content, true);
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

        #region 图色操作

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
        /// 找色
        /// </summary>
        /// <param name="zx">左上角x</param>
        /// <param name="zy">左上角y</param>
        /// <param name="yx">右下角x</param>
        /// <param name="yy">右下角y</param>
        /// <param name="searchColor"></param>
        /// <param name="sim"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void FindColor(int zx,int zy,int yx,int yy,string searchColor, double sim ,out int x,out int y)
        {
            x = y = -1;
            try
            {
                var sWidth = Screen.AllScreens[0].Bounds.Width;
                var sHeight = Screen.AllScreens[0].Bounds.Height;
                var parBitmap = new Bitmap(sWidth, sHeight, PixelFormat.Format24bppRgb);
                using (var g = Graphics.FromImage(parBitmap))
                {
                    g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(sWidth, sHeight));
                }
                var errorRange = (byte)(255 - 255 * sim);
                var colorX = ColorTranslator.FromHtml($"#{searchColor}");
                var parData = parBitmap.LockBits(new Rectangle(0, 0, parBitmap.Width, parBitmap.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                var byteArraryPar = new byte[parData.Stride * parData.Height];
                Marshal.Copy(parData.Scan0, byteArraryPar, 0, parData.Stride * parData.Height);
                var searchRect = new Rectangle(zx, zy, yx - zx, yy - zy);
                if (searchRect.IsEmpty)
                {
                    searchRect = new Rectangle(0, 0, parBitmap.Width, parBitmap.Height);
                }
                var searchLeftTop = searchRect.Location;
                var searchSize = searchRect.Size;
                var iMax = searchLeftTop.Y + searchSize.Height;
                var jMax = searchLeftTop.X + searchSize.Width;
                var pointX = -1;
                var pointY = -1;
                for (var m = searchRect.Y; m < iMax; m++)
                {
                    for (var n = searchRect.X; n < jMax; n++)
                    {
                        var index = m * parBitmap.Width * 4 + n * 4;
                        var color = Color.FromArgb(byteArraryPar[index + 3], byteArraryPar[index + 2],
                            byteArraryPar[index + 1], byteArraryPar[index]);
                        if (!ColorAEqualColorB(color, colorX, errorRange)) continue;
                        pointX = n;
                        pointY = m;
                        goto END;
                    }
                }
                END:
                parBitmap.UnlockBits(parData);
                x = pointX;
                y = pointY;
            }
            catch (Exception e)
            {
                _lastError = $"找色: {e}";
            }
        }

        /// <summary>
        /// 找图
        /// </summary>
        /// <param name="zx">左上角x</param>
        /// <param name="zy">左上角y</param>
        /// <param name="yx">右下角x</param>
        /// <param name="yy">右下角y</param>
        /// <param name="pic">要查找的图片</param>
        /// <param name="sim">相似度</param>
        /// <param name="intX">返回的x坐标</param>
        /// <param name="intY">返回的y坐标</param>
        public static unsafe void FindPic(int zx, int zy, int yx, int yy, string pic, double sim, out int intX, out int intY)
        {
            intX = intY = -1;
            try
            {
                var errorRange = Convert.ToByte(255 - 255 * sim);
                var sWidth = Screen.AllScreens[0].Bounds.Width;
                var sHeight = Screen.AllScreens[0].Bounds.Height;
                var sBmp = new Bitmap(sWidth, sHeight, PixelFormat.Format24bppRgb);
                using (var g = Graphics.FromImage(sBmp))
                {
                    g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(sWidth, sHeight));
                }
                var pBmp = new Bitmap(pic);
                if (pBmp.PixelFormat != PixelFormat.Format24bppRgb) { throw new Exception("图片格式只支持24位bmp,请检查图片!"); }
                var pWidth = pBmp.Width;
                var pHeight = pBmp.Height;
                //四个角的颜色相同做透明图处理
                var colorn = pBmp.GetPixel(0, 0);
                if (colorn == pBmp.GetPixel(0, pHeight - 1) &&
                    colorn == pBmp.GetPixel(pWidth - 1, 0) &&
                    colorn == pBmp.GetPixel(pWidth - 1, pHeight - 1))
                {
                    FindPicE(zx, zy, yx, yy, pic, sim, sim, out intX, out intY);
                }
                var rect = new Rectangle(zx, zy, yx - zx, yy - zy);
                if (rect.IsEmpty)
                {
                    rect = new Rectangle(0, 0, sWidth, sHeight);
                }
                var sData = sBmp.LockBits(new Rectangle(0, 0, sWidth, sHeight), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                var pData = pBmp.LockBits(new Rectangle(0, 0, pWidth, pHeight), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                var sStride = sData.Stride;
                var pStride = pData.Stride;
                var pOffset = pStride - pData.Width * 3;
                var sIptr = sData.Scan0;
                var pIptr = pData.Scan0;
                var isOk = false;
                var breakW = sWidth - pWidth + 1;
                var breakH = sHeight - pHeight + 1;
                for (var h = rect.Y; h < breakH; h++)
                {
                    for (var w = rect.X; w < breakW; w++)
                    {
                        var pPtr = (byte*)pIptr;
                        for (var y = 0; y < pHeight; y++)
                        {
                            for (var x = 0; x < pWidth; x++)
                            {
                                var sPtr = (byte*)(sIptr + sStride * (h + y) + (w + x) * 3);
                                if (pPtr != null
                                    && sPtr != null
                                    && sPtr[0] <= pPtr[0] + errorRange
                                    && sPtr[0] >= pPtr[0] - errorRange
                                    && sPtr[1] <= pPtr[1] + errorRange
                                    && sPtr[1] >= pPtr[1] - errorRange
                                    && sPtr[2] <= pPtr[2] + errorRange
                                    && sPtr[2] >= pPtr[2] - errorRange)
                                {
                                    isOk = true;
                                }
                                else
                                {
                                    isOk = false;
                                    break;
                                }
                                pPtr += 3;
                            }
                            if (isOk == false)
                            {
                                break;
                            }
                            pPtr += pOffset;
                        }
                        if (!isOk) continue;
                        intX = w + (int)(pWidth / 2.0);
                        intY = h + (int)(pHeight / 2.0);
                        goto end;
                    }
                }
                end:
                sBmp.UnlockBits(sData);
                pBmp.UnlockBits(pData);
            }
            catch (Exception e)
            {
                _lastError = $"找图: {e}";
            }
        }

        #endregion

        #region 键盘操作

        /// <summary>
        /// 键盘按下
        /// </summary>
        /// <param name="bVk">键代码</param>
        public static void KeyDown(Keys bVk)
        {
            Keybd_event(bVk, 0, 0, 0);
        }

        /// <summary>
        /// 键盘弹起
        /// </summary>
        /// <param name="bVk">键代码</param>
        public static void KeyUp(Keys bVk)
        {
            Keybd_event(bVk, 0, 2, 0);
        }

        /// <summary>
        /// 键盘按键
        /// </summary>
        /// <param name="bVk">键代码</param>
        public static void KeyPress(Keys bVk)
        {
            Keybd_event(bVk, 0, 0, 0);
            Keybd_event(bVk, 0, 2, 0);
        }

        /// <summary>
        /// ctrl+c 复制
        /// </summary>
        public static void KeyCtrlC()
        {
            KeyDown(Keys.LControlKey);
            Delay(66);
            KeyPress(Keys.C);
            Delay(66);
            KeyUp(Keys.LControlKey);
        }
        /// <summary>
        /// ctrl+x 剪切
        /// </summary>
        public static void KeyCtrlX()
        {
            KeyDown(Keys.LControlKey);
            Delay(66);
            KeyPress(Keys.X);
            Delay(66);
            KeyUp(Keys.LControlKey);
        }
        /// <summary>
        /// ctrl+v 粘贴
        /// </summary>
        public static void KeyCtrlV()
        {
            KeyDown(Keys.LControlKey);
            Delay(66);
            KeyPress(Keys.V);
            Delay(66);
            KeyUp(Keys.LControlKey);
        }
        /// <summary>
        /// ctrl+a 全选
        /// </summary>
        public static void KeyCtrlA()
        {
            KeyDown(Keys.LControlKey);
            Delay(66);
            KeyPress(Keys.A);
            Delay(66);
            KeyUp(Keys.LControlKey);
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
        public static string ReadIni(string section,string key, string file)
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
        public static int WriteFile(string file,string content)
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
        public static int WriteIni(string section,string  key,string  value,string  file)
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
            return (int) FWindow(lpClassName, lpWindowName);
        }
        /// <summary>
        /// 获取窗体的句柄函数(模糊匹配)
        /// </summary>
        /// <param name="lpClassName">窗口类名</param>
        /// <param name="lpWindowName">窗口标题名</param>
        /// <returns>返回句柄集合</returns>
        public static List<int> FindWindowEx(string lpClassName, string lpWindowName)
        {
            var wndList = new List<int>();
            EWindows(delegate(IntPtr hWnd, int y)
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
                        wndList.Add((int) hWnd);
                    }
                }
                else if (lpClassName == string.Empty)
                {
                    if (windowText.Contains(lpWindowName))
                    {
                        wndList.Add((int) hWnd);
                    }
                }
                else if (lpWindowName == string.Empty)
                {

                    if (windowClass.Contains(lpClassName))
                    {
                        wndList.Add((int) hWnd);
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
        public static int GetWindowRect(int hwnd, out int zx,out int zy,out int yx,out int yy)
        {
            zx = zy = yx = yy = - 1;
            try
            {
                GetWindowRect((IntPtr)hwnd,out var ipRect);
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
                GetWindowRect(hwnd,out var zx,out var zy,out _,out _);
                return MoveWindow((IntPtr) hwnd, zx, zy, w, h, true);
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
                return MoveWindow((IntPtr) hwnd, x-6, y, yx - zx, yy - zy, true);
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

                return ShowWindow(hwnd, type);
            }
            catch (Exception e)
            {
                _lastError = $"设置窗口的状态: {e}";
                return 0;
            }
        }
        #endregion

        #region 后台操作

        #endregion
    }
}
