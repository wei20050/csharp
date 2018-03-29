using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace yx
{
    public class DmSoft : IDisposable
    {
        #region 路径全局常量
        private const string DmPath = @"C:\Windows\Temp\dm.dll";
        private const string DmcPath = @"C:\Windows\Temp\dmc.dll";
        #endregion

        #region import DLL 函数

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr CreateDM(string dmpath);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FreeDM();

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string Ver(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetPath(IntPtr dm, string path);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string Ocr(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindStr(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim, out object x, out object y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetResultCount(IntPtr dm, string str);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetResultPos(IntPtr dm, string str, int index, out object x, out object y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int StrStr(IntPtr dm, string s, string str);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SendCommand(IntPtr dm, string cmd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int UseDict(IntPtr dm, int index);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetBasePath(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetDictPwd(IntPtr dm, string pwd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string OcrInFile(IntPtr dm, int x1, int y1, int x2, int y2, string picName, string color, double sim);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Capture(IntPtr dm, int x1, int y1, int x2, int y2, string file);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int KeyPress(IntPtr dm, int vk);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int KeyDown(IntPtr dm, int vk);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int KeyUp(IntPtr dm, int vk);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int LeftClick(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int RightClick(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int MiddleClick(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int LeftDoubleClick(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int LeftDown(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int LeftUp(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int RightDown(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int RightUp(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int MoveTo(IntPtr dm, int x, int y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int MoveR(IntPtr dm, int rx, int ry);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetColor(IntPtr dm, int x, int y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetColorBGR(IntPtr dm, int x, int y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string RGB2BGR(IntPtr dm, string rgbColor);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string BGR2RGB(IntPtr dm, string bgrColor);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int UnBindWindow(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int CmpColor(IntPtr dm, int x, int y, string color, double sim);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ClientToScreen(IntPtr dm, int hwnd, ref object x, ref object y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ScreenToClient(IntPtr dm, int hwnd, ref object x, ref object y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ShowScrMsg(IntPtr dm, int x1, int y1, int x2, int y2, string msg, string color);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetMinRowGap(IntPtr dm, int rowGap);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetMinColGap(IntPtr dm, int colGap);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindColor(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim, int dir, out object x, out object y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindColorEx(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim, int dir);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWordLineHeight(IntPtr dm, int lineHeight);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWordGap(IntPtr dm, int wordGap);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetRowGapNoDict(IntPtr dm, int rowGap);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetColGapNoDict(IntPtr dm, int colGap);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWordLineHeightNoDict(IntPtr dm, int lineHeight);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWordGapNoDict(IntPtr dm, int wordGap);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetWordResultCount(IntPtr dm, string str);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetWordResultPos(IntPtr dm, string str, int index, out object x, out object y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetWordResultStr(IntPtr dm, string str, int index);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetWords(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetWordsNoDict(IntPtr dm, int x1, int y1, int x2, int y2, string color);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetShowErrorMsg(IntPtr dm, int show);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetClientSize(IntPtr dm, int hwnd, out object width, out object height);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int MoveWindow(IntPtr dm, int hwnd, int x, int y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetColorHSV(IntPtr dm, int x, int y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetAveRGB(IntPtr dm, int x1, int y1, int x2, int y2);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetAveHSV(IntPtr dm, int x1, int y1, int x2, int y2);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetForegroundWindow(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetForegroundFocus(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetMousePointWindow(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPointWindow(IntPtr dm, int x, int y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string EnumWindow(IntPtr dm, int parent, string title, string className, int filter);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetWindowState(IntPtr dm, int hwnd, int flag);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetWindow(IntPtr dm, int hwnd, int flag);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetSpecialWindow(IntPtr dm, int flag);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowText(IntPtr dm, int hwnd, string text);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowSize(IntPtr dm, int hwnd, int width, int height);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetWindowRect(IntPtr dm, int hwnd, out object x1, out object y1, out object x2, out object y2);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetWindowTitle(IntPtr dm, int hwnd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetWindowClass(IntPtr dm, int hwnd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowState(IntPtr dm, int hwnd, int flag);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int CreateFoobarRect(IntPtr dm, int hwnd, int x, int y, int w, int h);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int CreateFoobarRoundRect(IntPtr dm, int hwnd, int x, int y, int w, int h, int rw, int rh);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int CreateFoobarEllipse(IntPtr dm, int hwnd, int x, int y, int w, int h);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int CreateFoobarCustom(IntPtr dm, int hwnd, int x, int y, string pic, string transColor, double sim);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FoobarFillRect(IntPtr dm, int hwnd, int x1, int y1, int x2, int y2, string color);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FoobarDrawText(IntPtr dm, int hwnd, int x, int y, int w, int h, string text, string color, int align);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FoobarDrawPic(IntPtr dm, int hwnd, int x, int y, string pic, string transColor);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FoobarUpdate(IntPtr dm, int hwnd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FoobarLock(IntPtr dm, int hwnd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FoobarUnlock(IntPtr dm, int hwnd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FoobarSetFont(IntPtr dm, int hwnd, string fontName, int size, int flag);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FoobarTextRect(IntPtr dm, int hwnd, int x, int y, int w, int h);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FoobarPrintText(IntPtr dm, int hwnd, string text, string color);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FoobarClearText(IntPtr dm, int hwnd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FoobarTextLineGap(IntPtr dm, int hwnd, int gap);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Play(IntPtr dm, string file);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FaqCapture(IntPtr dm, int x1, int y1, int x2, int y2, int quality, int delay, int time);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FaqRelease(IntPtr dm, int handle);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FaqSend(IntPtr dm, string server, int handle, int requestType, int timeOut);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Beep(IntPtr dm, int fre, int delay);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FoobarClose(IntPtr dm, int hwnd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int MoveDD(IntPtr dm, int dx, int dy);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FaqGetSize(IntPtr dm, int handle);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int LoadPic(IntPtr dm, string picName);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FreePic(IntPtr dm, string picName);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetScreenData(IntPtr dm, int x1, int y1, int x2, int y2);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FreeScreenData(IntPtr dm, int handle);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int WheelUp(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int WheelDown(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetMouseDelay(IntPtr dm, string type, int delay);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetKeypadDelay(IntPtr dm, string type, int delay);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetEnv(IntPtr dm, int index, string name);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetEnv(IntPtr dm, int index, string name, string value);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SendString(IntPtr dm, int hwnd, string str);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int DelEnv(IntPtr dm, int index, string name);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetPath(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetDict(IntPtr dm, int index, string dictName);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindPic(IntPtr dm, int x1, int y1, int x2, int y2, string picName, string deltaColor, double sim, int dir, out object x, out object y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindPicEx(IntPtr dm, int x1, int y1, int x2, int y2, string picName, string deltaColor, double sim, int dir);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetClientSize(IntPtr dm, int hwnd, int width, int height);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ReadInt(IntPtr dm, int hwnd, string addr, int type);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ReadFloat(IntPtr dm, int hwnd, string addr);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ReadDouble(IntPtr dm, int hwnd, string addr);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindInt(IntPtr dm, int hwnd, string addrRange, int intValueMin, int intValueMax, int type);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindFloat(IntPtr dm, int hwnd, string addrRange, Single floatValueMin, Single floatValueMax);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindDouble(IntPtr dm, int hwnd, string addrRange, double doubleValueMin, double doubleValueMax);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindString(IntPtr dm, int hwnd, string addrRange, string stringValue, int type);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetModuleBaseAddr(IntPtr dm, int hwnd, string moduleName);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string MoveToEx(IntPtr dm, int x, int y, int w, int h);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string MatchPicName(IntPtr dm, string picName);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int AddDict(IntPtr dm, int index, string dictInfo);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int EnterCri(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int LeaveCri(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int WriteInt(IntPtr dm, int hwnd, string addr, int type, int v);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int WriteFloat(IntPtr dm, int hwnd, string addr, Single v);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int WriteDouble(IntPtr dm, int hwnd, string addr, double v);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int WriteString(IntPtr dm, int hwnd, string addr, int type, string v);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int AsmAdd(IntPtr dm, string asmIns);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int AsmClear(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int AsmCall(IntPtr dm, int hwnd, int mode);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindMultiColor(IntPtr dm, int x1, int y1, int x2, int y2, string firstColor, string offsetColor, double sim, int dir, out object x, out object y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindMultiColorEx(IntPtr dm, int x1, int y1, int x2, int y2, string firstColor, string offsetColor, double sim, int dir);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string AsmCode(IntPtr dm, int baseAddr);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string Assemble(IntPtr dm, string asmCode, int baseAddr, int isUpper);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowTransparent(IntPtr dm, int hwnd, int v);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string ReadData(IntPtr dm, int hwnd, string addr, int len);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int WriteData(IntPtr dm, int hwnd, string addr, string data);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindData(IntPtr dm, int hwnd, string addrRange, string data);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetPicPwd(IntPtr dm, string pwd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Log(IntPtr dm, string info);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindStrE(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindColorE(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim, int dir);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindPicE(IntPtr dm, int x1, int y1, int x2, int y2, string picName, string deltaColor, double sim, int dir);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindMultiColorE(IntPtr dm, int x1, int y1, int x2, int y2, string firstColor, string offsetColor, double sim, int dir);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetExactOcr(IntPtr dm, int exactOcr);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string ReadString(IntPtr dm, int hwnd, string addr, int type, int len);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FoobarTextPrintDir(IntPtr dm, int hwnd, int dir);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string OcrEx(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetDisplayInput(IntPtr dm, string mode);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetTime(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetScreenWidth(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetScreenHeight(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int BindWindowEx(IntPtr dm, int hwnd, string display, string mouse, string keypad, string publicDesc, int mode);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetDiskSerial(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string Md5(IntPtr dm, string str);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetMac(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ActiveInputMethod(IntPtr dm, int hwnd, string id);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int CheckInputMethod(IntPtr dm, int hwnd, string id);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindInputMethod(IntPtr dm, string id);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetCursorPos(IntPtr dm, out object x, out object y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int BindWindow(IntPtr dm, int hwnd, string display, string mouse, string keypad, int mode);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindWindow(IntPtr dm, string className, string titleName);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetScreenDepth(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetScreen(IntPtr dm, int width, int height, int depth);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ExitOs(IntPtr dm, int type);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetDir(IntPtr dm, int type);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetOsType(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindWindowEx(IntPtr dm, int parent, string className, string titleName);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetExportDict(IntPtr dm, int index, string dictName);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetCursorShape(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int DownCpu(IntPtr dm, int rate);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetCursorSpot(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SendString2(IntPtr dm, int hwnd, string str);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FaqPost(IntPtr dm, string server, int handle, int requestType, int timeOut);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FaqFetch(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FetchWord(IntPtr dm, int x1, int y1, int x2, int y2, string color, string word);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int CaptureJpg(IntPtr dm, int x1, int y1, int x2, int y2, string file, int quality);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindStrWithFont(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim, string fontName, int fontSize, int flag, out object x, out object y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindStrWithFontE(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim, string fontName, int fontSize, int flag);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindStrWithFontEx(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim, string fontName, int fontSize, int flag);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetDictInfo(IntPtr dm, string str, string fontName, int fontSize, int flag);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SaveDict(IntPtr dm, int index, string file);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetWindowProcessId(IntPtr dm, int hwnd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetWindowProcessPath(IntPtr dm, int hwnd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int LockInput(IntPtr dm, int lock1);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetPicSize(IntPtr dm, string picName);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetID(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int CapturePng(IntPtr dm, int x1, int y1, int x2, int y2, string file);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int CaptureGif(IntPtr dm, int x1, int y1, int x2, int y2, string file, int delay, int time);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ImageToBmp(IntPtr dm, string picName, string bmpName);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindStrFast(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim, out object x, out object y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindStrFastEx(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindStrFastE(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int EnableDisplayDebug(IntPtr dm, int enableDebug);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int CapturePre(IntPtr dm, string file);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int RegEx(IntPtr dm, string code, string ver, string ip);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetMachineCode(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetClipboard(IntPtr dm, string data);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetClipboard(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetNowDict(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Is64Bit(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetColorNum(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string EnumWindowByProcess(IntPtr dm, string processName, string title, string className, int filter);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetDictCount(IntPtr dm, int index);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetLastError(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetNetTime(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int EnableGetColorByCapture(IntPtr dm, int en);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int CheckUAC(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetUAC(IntPtr dm, int uac);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int DisableFontSmooth(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int CheckFontSmooth(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetDisplayAcceler(IntPtr dm, int level);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindWindowByProcess(IntPtr dm, string processName, string className, string titleName);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindWindowByProcessId(IntPtr dm, int processId, string className, string titleName);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string ReadIni(IntPtr dm, string section, string key, string file);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int WriteIni(IntPtr dm, string section, string key, string v, string file);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int RunApp(IntPtr dm, string path, int mode);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int delay(IntPtr dm, int mis);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindWindowSuper(IntPtr dm, string spec1, int flag1, int type1, string spec2, int flag2, int type2);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string ExcludePos(IntPtr dm, string allPos, int type, int x1, int y1, int x2, int y2);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindNearestPos(IntPtr dm, string allPos, int type, int x, int y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string SortPosDistance(IntPtr dm, string allPos, int type, int x, int y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindPicMem(IntPtr dm, int x1, int y1, int x2, int y2, string picInfo, string deltaColor, double sim, int dir, out object x, out object y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindPicMemEx(IntPtr dm, int x1, int y1, int x2, int y2, string picInfo, string deltaColor, double sim, int dir);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindPicMemE(IntPtr dm, int x1, int y1, int x2, int y2, string picInfo, string deltaColor, double sim, int dir);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string AppendPicAddr(IntPtr dm, string picInfo, int addr, int size);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int WriteFile(IntPtr dm, string file, string content);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Stop(IntPtr dm, int id);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetDictMem(IntPtr dm, int index, int addr, int size);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetNetTimeSafe(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ForceUnBindWindow(IntPtr dm, int hwnd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string ReadIniPwd(IntPtr dm, string section, string key, string file, string pwd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int WriteIniPwd(IntPtr dm, string section, string key, string v, string file, string pwd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int DecodeFile(IntPtr dm, string file, string pwd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int KeyDownChar(IntPtr dm, string keyStr);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int KeyUpChar(IntPtr dm, string keyStr);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int KeyPressChar(IntPtr dm, string keyStr);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int KeyPressStr(IntPtr dm, string keyStr, int delay);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int EnableKeypadPatch(IntPtr dm, int en);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int EnableKeypadSync(IntPtr dm, int en, int timeOut);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int EnableMouseSync(IntPtr dm, int en, int timeOut);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int DmGuard(IntPtr dm, int en, string type);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FaqCaptureFromFile(IntPtr dm, int x1, int y1, int x2, int y2, string file, int quality);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindIntEx(IntPtr dm, int hwnd, string addrRange, int intValueMin, int intValueMax, int type, int step, int multiThread, int mode);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindFloatEx(IntPtr dm, int hwnd, string addrRange, Single floatValueMin, Single floatValueMax, int step, int multiThread, int mode);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindDoubleEx(IntPtr dm, int hwnd, string addrRange, double doubleValueMin, double doubleValueMax, int step, int multiThread, int mode);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindStringEx(IntPtr dm, int hwnd, string addrRange, string stringValue, int type, int step, int multiThread, int mode);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindDataEx(IntPtr dm, int hwnd, string addrRange, string data, int step, int multiThread, int mode);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int EnableRealMouse(IntPtr dm, int en, int mousedelay, int mousestep);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int EnableRealKeypad(IntPtr dm, int en);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SendStringIme(IntPtr dm, string str);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FoobarDrawLine(IntPtr dm, int hwnd, int x1, int y1, int x2, int y2, string color, int style, int width);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindStrEx(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int IsBind(IntPtr dm, int hwnd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetDisplayDelay(IntPtr dm, int t);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetDmCount(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int DisableScreenSave(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int DisablePowerSave(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetMemoryHwndAsProcessId(IntPtr dm, int en);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindShape(IntPtr dm, int x1, int y1, int x2, int y2, string offsetColor, double sim, int dir, out object x, out object y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindShapeE(IntPtr dm, int x1, int y1, int x2, int y2, string offsetColor, double sim, int dir);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindShapeEx(IntPtr dm, int x1, int y1, int x2, int y2, string offsetColor, double sim, int dir);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindStrS(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim, out object x, out object y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindStrExS(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindStrFastS(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim, out object x, out object y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindStrFastExS(IntPtr dm, int x1, int y1, int x2, int y2, string str, string color, double sim);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindPicS(IntPtr dm, int x1, int y1, int x2, int y2, string picName, string deltaColor, double sim, int dir, out object x, out object y);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FindPicExS(IntPtr dm, int x1, int y1, int x2, int y2, string picName, string deltaColor, double sim, int dir);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ClearDict(IntPtr dm, int index);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetMachineCodeNoMac(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetClientRect(IntPtr dm, int hwnd, out object x1, out object y1, out object x2, out object y2);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int EnableFakeActive(IntPtr dm, int en);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetScreenDataBmp(IntPtr dm, int x1, int y1, int x2, int y2, out object data, out object size);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int EncodeFile(IntPtr dm, string file, string pwd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetCursorShapeEx(IntPtr dm, int type);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FaqCancel(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string IntToData(IntPtr dm, int intValue, int type);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string FloatToData(IntPtr dm, Single floatValue);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string DoubleToData(IntPtr dm, double doubleValue);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string StringToData(IntPtr dm, string stringValue, int type);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetMemoryFindResultToFile(IntPtr dm, string file);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int EnableBind(IntPtr dm, int en);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetSimMode(IntPtr dm, int mode);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int LockMouseRect(IntPtr dm, int x1, int y1, int x2, int y2);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SendPaste(IntPtr dm, int hwnd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int IsDisplayDead(IntPtr dm, int x1, int y1, int x2, int y2, int t);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetKeyState(IntPtr dm, int vk);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int CopyFile(IntPtr dm, string srcFile, string dstFile, int over);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int IsFileExist(IntPtr dm, string file);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int DeleteFile(IntPtr dm, string file);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int MoveFile(IntPtr dm, string srcFile, string dstFile);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int CreateFolder(IntPtr dm, string folderName);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int DeleteFolder(IntPtr dm, string folderName);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetFileLength(IntPtr dm, string file);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string ReadFile(IntPtr dm, string file);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int WaitKey(IntPtr dm, int keyCode, int timeOut);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int DeleteIni(IntPtr dm, string section, string key, string file);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int DeleteIniPwd(IntPtr dm, string section, string key, string file, string pwd);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int EnableSpeedDx(IntPtr dm, int en);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int EnableIme(IntPtr dm, int en);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Reg(IntPtr dm, string code, string ver);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string SelectFile(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string SelectDirectory(IntPtr dm);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int LockDisplay(IntPtr dm, int lock1);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FoobarSetSave(IntPtr dm, int hwnd, string file, int en, string header);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string EnumWindowSuper(IntPtr dm, string spec1, int flag1, int type1, string spec2, int flag2, int type2, int sort);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int DownloadFile(IntPtr dm, string url, string saveFile, int timeout);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int EnableKeypadMsg(IntPtr dm, int en);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int EnableMouseMsg(IntPtr dm, int en);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int RegNoMac(IntPtr dm, string code, string ver);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int RegExNoMac(IntPtr dm, string code, string ver, string ip);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetEnumWindowDelay(IntPtr dm, int delay);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int FindMulColor(IntPtr dm, int x1, int y1, int x2, int y2, string color, double sim);

        [DllImport(DmcPath, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern string GetDict(IntPtr dm, int index, int fontIndex);

        #endregion

        #region 大漠函数封装

        private IntPtr _dm;

        private bool _disposed;

        public DmSoft()
        {
            if (!File.Exists(DmPath))
            {
                File.WriteAllBytes(DmPath, Properties.Resources.dm);
            }
            if (!File.Exists(DmcPath))
            {
                File.WriteAllBytes(DmcPath, Properties.Resources.dmc);
            }
            _dm = CreateDM(DmPath);
        }

        public int SetPath(string path)
        {
            return SetPath(_dm, path);
        }

        public string Ocr(int x1, int y1, int x2, int y2, string color, double sim)
        {
            return Ocr(_dm, x1, y1, x2, y2, color, sim);
        }

        public int FindStr(int x1, int y1, int x2, int y2, string str, string color, double sim, out object x, out object y)
        {
            return FindStr(_dm, x1, y1, x2, y2, str, color, sim, out x, out y);
        }

        public int GetResultCount(string str)
        {
            return GetResultCount(_dm, str);
        }

        public int GetResultPos(string str, int index, out object x, out object y)
        {
            return GetResultPos(_dm, str, index, out x, out y);
        }

        public int StrStr(string s, string str)
        {
            return StrStr(_dm, s, str);
        }

        public int SendCommand(string cmd)
        {
            return SendCommand(_dm, cmd);
        }

        public int UseDict(int index)
        {
            return UseDict(_dm, index);
        }

        public string GetBasePath()
        {
            return GetBasePath(_dm);
        }

        public int SetDictPwd(string pwd)
        {
            return SetDictPwd(_dm, pwd);
        }

        public string OcrInFile(int x1, int y1, int x2, int y2, string picName, string color, double sim)
        {
            return OcrInFile(_dm, x1, y1, x2, y2, picName, color, sim);
        }

        public int Capture(int x1, int y1, int x2, int y2, string file)
        {
            return Capture(_dm, x1, y1, x2, y2, file);
        }

        public int KeyPress(int vk)
        {
            return KeyPress(_dm, vk);
        }

        public int KeyDown(int vk)
        {
            return KeyDown(_dm, vk);
        }

        public int KeyUp(int vk)
        {
            return KeyUp(_dm, vk);
        }

        public int LeftClick()
        {
            return LeftClick(_dm);
        }

        public int RightClick()
        {
            return RightClick(_dm);
        }

        public int MiddleClick()
        {
            return MiddleClick(_dm);
        }

        public int LeftDoubleClick()
        {
            return LeftDoubleClick(_dm);
        }

        public int LeftDown()
        {
            return LeftDown(_dm);
        }

        public int LeftUp()
        {
            return LeftUp(_dm);
        }

        public int RightDown()
        {
            return RightDown(_dm);
        }

        public int RightUp()
        {
            return RightUp(_dm);
        }

        public int MoveTo(int x, int y)
        {
            return MoveTo(_dm, x, y);
        }

        public int MoveR(int rx, int ry)
        {
            return MoveR(_dm, rx, ry);
        }

        public string GetColor(int x, int y)
        {
            return GetColor(_dm, x, y);
        }

        public string GetColorBgr(int x, int y)
        {
            return GetColorBGR(_dm, x, y);
        }

        public string Rgb2Bgr(string rgbColor)
        {
            return RGB2BGR(_dm, rgbColor);
        }

        public string Bgr2Rgb(string bgrColor)
        {
            return BGR2RGB(_dm, bgrColor);
        }

        public int UnBindWindow()
        {
            return UnBindWindow(_dm);
        }

        public int CmpColor(int x, int y, string color, double sim)
        {
            return CmpColor(_dm, x, y, color, sim);
        }

        public int ClientToScreen(int hwnd, ref object x, ref object y)
        {
            return ClientToScreen(_dm, hwnd, ref x, ref y);
        }

        public int ScreenToClient(int hwnd, ref object x, ref object y)
        {
            return ScreenToClient(_dm, hwnd, ref x, ref y);
        }

        public int ShowScrMsg(int x1, int y1, int x2, int y2, string msg, string color)
        {
            return ShowScrMsg(_dm, x1, y1, x2, y2, msg, color);
        }

        public int SetMinRowGap(int rowGap)
        {
            return SetMinRowGap(_dm, rowGap);
        }

        public int SetMinColGap(int colGap)
        {
            return SetMinColGap(_dm, colGap);
        }

        public int FindColor(int x1, int y1, int x2, int y2, string color, double sim, int dir, out object x, out object y)
        {
            return FindColor(_dm, x1, y1, x2, y2, color, sim, dir, out x, out y);
        }

        public string FindColorEx(int x1, int y1, int x2, int y2, string color, double sim, int dir)
        {
            return FindColorEx(_dm, x1, y1, x2, y2, color, sim, dir);
        }

        public int SetWordLineHeight(int lineHeight)
        {
            return SetWordLineHeight(_dm, lineHeight);
        }

        public int SetWordGap(int wordGap)
        {
            return SetWordGap(_dm, wordGap);
        }

        public int SetRowGapNoDict(int rowGap)
        {
            return SetRowGapNoDict(_dm, rowGap);
        }

        public int SetColGapNoDict(int colGap)
        {
            return SetColGapNoDict(_dm, colGap);
        }

        public int SetWordLineHeightNoDict(int lineHeight)
        {
            return SetWordLineHeightNoDict(_dm, lineHeight);
        }

        public int SetWordGapNoDict(int wordGap)
        {
            return SetWordGapNoDict(_dm, wordGap);
        }

        public int GetWordResultCount(string str)
        {
            return GetWordResultCount(_dm, str);
        }

        public int GetWordResultPos(string str, int index, out object x, out object y)
        {
            return GetWordResultPos(_dm, str, index, out x, out y);
        }

        public string GetWordResultStr(string str, int index)
        {
            return GetWordResultStr(_dm, str, index);
        }

        public string GetWords(int x1, int y1, int x2, int y2, string color, double sim)
        {
            return GetWords(_dm, x1, y1, x2, y2, color, sim);
        }

        public string GetWordsNoDict(int x1, int y1, int x2, int y2, string color)
        {
            return GetWordsNoDict(_dm, x1, y1, x2, y2, color);
        }

        public int SetShowErrorMsg(int show)
        {
            return SetShowErrorMsg(_dm, show);
        }

        public int GetClientSize(int hwnd, out object width, out object height)
        {
            return GetClientSize(_dm, hwnd, out width, out height);
        }

        public int MoveWindow(int hwnd, int x, int y)
        {
            return MoveWindow(_dm, hwnd, x, y);
        }

        public string GetColorHsv(int x, int y)
        {
            return GetColorHSV(_dm, x, y);
        }

        public string GetAveRgb(int x1, int y1, int x2, int y2)
        {
            return GetAveRGB(_dm, x1, y1, x2, y2);
        }

        public string GetAveHsv(int x1, int y1, int x2, int y2)
        {
            return GetAveHSV(_dm, x1, y1, x2, y2);
        }

        public int GetForegroundWindow()
        {
            return GetForegroundWindow(_dm);
        }

        public int GetForegroundFocus()
        {
            return GetForegroundFocus(_dm);
        }

        public int GetMousePointWindow()
        {
            return GetMousePointWindow(_dm);
        }

        public int GetPointWindow(int x, int y)
        {
            return GetPointWindow(_dm, x, y);
        }

        public string EnumWindow(int parent, string title, string className, int filter)
        {
            return EnumWindow(_dm, parent, title, className, filter);
        }

        public int GetWindowState(int hwnd, int flag)
        {
            return GetWindowState(_dm, hwnd, flag);
        }

        public int GetWindow(int hwnd, int flag)
        {
            return GetWindow(_dm, hwnd, flag);
        }

        public int GetSpecialWindow(int flag)
        {
            return GetSpecialWindow(_dm, flag);
        }

        public int SetWindowText(int hwnd, string text)
        {
            return SetWindowText(_dm, hwnd, text);
        }

        public int SetWindowSize(int hwnd, int width, int height)
        {
            return SetWindowSize(_dm, hwnd, width, height);
        }

        public int GetWindowRect(int hwnd, out object x1, out object y1, out object x2, out object y2)
        {
            return GetWindowRect(_dm, hwnd, out x1, out y1, out x2, out y2);
        }

        public string GetWindowTitle(int hwnd)
        {
            return GetWindowTitle(_dm, hwnd);
        }

        public string GetWindowClass(int hwnd)
        {
            return GetWindowClass(_dm, hwnd);
        }

        public int SetWindowState(int hwnd, int flag)
        {
            return SetWindowState(_dm, hwnd, flag);
        }

        public int CreateFoobarRect(int hwnd, int x, int y, int w, int h)
        {
            return CreateFoobarRect(_dm, hwnd, x, y, w, h);
        }

        public int CreateFoobarRoundRect(int hwnd, int x, int y, int w, int h, int rw, int rh)
        {
            return CreateFoobarRoundRect(_dm, hwnd, x, y, w, h, rw, rh);
        }

        public int CreateFoobarEllipse(int hwnd, int x, int y, int w, int h)
        {
            return CreateFoobarEllipse(_dm, hwnd, x, y, w, h);
        }

        public int CreateFoobarCustom(int hwnd, int x, int y, string pic, string transColor, double sim)
        {
            return CreateFoobarCustom(_dm, hwnd, x, y, pic, transColor, sim);
        }

        public int FoobarFillRect(int hwnd, int x1, int y1, int x2, int y2, string color)
        {
            return FoobarFillRect(_dm, hwnd, x1, y1, x2, y2, color);
        }

        public int FoobarDrawText(int hwnd, int x, int y, int w, int h, string text, string color, int align)
        {
            return FoobarDrawText(_dm, hwnd, x, y, w, h, text, color, align);
        }

        public int FoobarDrawPic(int hwnd, int x, int y, string pic, string transColor)
        {
            return FoobarDrawPic(_dm, hwnd, x, y, pic, transColor);
        }

        public int FoobarUpdate(int hwnd)
        {
            return FoobarUpdate(_dm, hwnd);
        }

        public int FoobarLock(int hwnd)
        {
            return FoobarLock(_dm, hwnd);
        }

        public int FoobarUnlock(int hwnd)
        {
            return FoobarUnlock(_dm, hwnd);
        }

        public int FoobarSetFont(int hwnd, string fontName, int size, int flag)
        {
            return FoobarSetFont(_dm, hwnd, fontName, size, flag);
        }

        public int FoobarTextRect(int hwnd, int x, int y, int w, int h)
        {
            return FoobarTextRect(_dm, hwnd, x, y, w, h);
        }

        public int FoobarPrintText(int hwnd, string text, string color)
        {
            return FoobarPrintText(_dm, hwnd, text, color);
        }

        public int FoobarClearText(int hwnd)
        {
            return FoobarClearText(_dm, hwnd);
        }

        public int FoobarTextLineGap(int hwnd, int gap)
        {
            return FoobarTextLineGap(_dm, hwnd, gap);
        }

        public int Play(string file)
        {
            return Play(_dm, file);
        }

        public int FaqCapture(int x1, int y1, int x2, int y2, int quality, int delay, int time)
        {
            return FaqCapture(_dm, x1, y1, x2, y2, quality, delay, time);
        }

        public int FaqRelease(int handle)
        {
            return FaqRelease(_dm, handle);
        }

        public string FaqSend(string server, int handle, int requestType, int timeOut)
        {
            return FaqSend(_dm, server, handle, requestType, timeOut);
        }

        public int Beep(int fre, int delay)
        {
            return Beep(_dm, fre, delay);
        }

        public int FoobarClose(int hwnd)
        {
            return FoobarClose(_dm, hwnd);
        }

        public int MoveDd(int dx, int dy)
        {
            return MoveDD(_dm, dx, dy);
        }

        public int FaqGetSize(int handle)
        {
            return FaqGetSize(_dm, handle);
        }

        public int LoadPic(string picName)
        {
            return LoadPic(_dm, picName);
        }

        public int FreePic(string picName)
        {
            return FreePic(_dm, picName);
        }

        public int GetScreenData(int x1, int y1, int x2, int y2)
        {
            return GetScreenData(_dm, x1, y1, x2, y2);
        }

        public int FreeScreenData(int handle)
        {
            return FreeScreenData(_dm, handle);
        }

        public int WheelUp()
        {
            return WheelUp(_dm);
        }

        public int WheelDown()
        {
            return WheelDown(_dm);
        }

        public int SetMouseDelay(string type, int delay)
        {
            return SetMouseDelay(_dm, type, delay);
        }

        public int SetKeypadDelay(string type, int delay)
        {
            return SetKeypadDelay(_dm, type, delay);
        }

        public string GetEnv(int index, string name)
        {
            return GetEnv(_dm, index, name);
        }

        public int SetEnv(int index, string name, string value)
        {
            return SetEnv(_dm, index, name, value);
        }

        public int SendString(int hwnd, string str)
        {
            return SendString(_dm, hwnd, str);
        }

        public int DelEnv(int index, string name)
        {
            return DelEnv(_dm, index, name);
        }

        public string GetPath()
        {
            return GetPath(_dm);
        }

        public int SetDict(int index, string dictName)
        {
            return SetDict(_dm, index, dictName);
        }

        public int FindPic(int x1, int y1, int x2, int y2, string picName, string deltaColor, double sim, int dir, out object x, out object y)
        {
            return FindPic(_dm, x1, y1, x2, y2, picName, deltaColor, sim, dir, out x, out y);
        }

        public string FindPicEx(int x1, int y1, int x2, int y2, string picName, string deltaColor, double sim, int dir)
        {
            return FindPicEx(_dm, x1, y1, x2, y2, picName, deltaColor, sim, dir);
        }

        public int SetClientSize(int hwnd, int width, int height)
        {
            return SetClientSize(_dm, hwnd, width, height);
        }

        public int ReadInt(int hwnd, string addr, int type)
        {
            return ReadInt(_dm, hwnd, addr, type);
        }

        public int ReadFloat(int hwnd, string addr)
        {
            return ReadFloat(_dm, hwnd, addr);
        }

        public int ReadDouble(int hwnd, string addr)
        {
            return ReadDouble(_dm, hwnd, addr);
        }

        public string FindInt(int hwnd, string addrRange, int intValueMin, int intValueMax, int type)
        {
            return FindInt(_dm, hwnd, addrRange, intValueMin, intValueMax, type);
        }

        public string FindFloat(int hwnd, string addrRange, Single floatValueMin, Single floatValueMax)
        {
            return FindFloat(_dm, hwnd, addrRange, floatValueMin, floatValueMax);
        }

        public string FindDouble(int hwnd, string addrRange, double doubleValueMin, double doubleValueMax)
        {
            return FindDouble(_dm, hwnd, addrRange, doubleValueMin, doubleValueMax);
        }

        public string FindString(int hwnd, string addrRange, string stringValue, int type)
        {
            return FindString(_dm, hwnd, addrRange, stringValue, type);
        }

        public int GetModuleBaseAddr(int hwnd, string moduleName)
        {
            return GetModuleBaseAddr(_dm, hwnd, moduleName);
        }

        public string MoveToEx(int x, int y, int w, int h)
        {
            return MoveToEx(_dm, x, y, w, h);
        }

        public string MatchPicName(string picName)
        {
            return MatchPicName(_dm, picName);
        }

        public int AddDict(int index, string dictInfo)
        {
            return AddDict(_dm, index, dictInfo);
        }

        public int EnterCri()
        {
            return EnterCri(_dm);
        }

        public int LeaveCri()
        {
            return LeaveCri(_dm);
        }

        public int WriteInt(int hwnd, string addr, int type, int v)
        {
            return WriteInt(_dm, hwnd, addr, type, v);
        }

        public int WriteFloat(int hwnd, string addr, Single v)
        {
            return WriteFloat(_dm, hwnd, addr, v);
        }

        public int WriteDouble(int hwnd, string addr, double v)
        {
            return WriteDouble(_dm, hwnd, addr, v);
        }

        public int WriteString(int hwnd, string addr, int type, string v)
        {
            return WriteString(_dm, hwnd, addr, type, v);
        }

        public int AsmAdd(string asmIns)
        {
            return AsmAdd(_dm, asmIns);
        }

        public int AsmClear()
        {
            return AsmClear(_dm);
        }

        public int AsmCall(int hwnd, int mode)
        {
            return AsmCall(_dm, hwnd, mode);
        }

        public int FindMultiColor(int x1, int y1, int x2, int y2, string firstColor, string offsetColor, double sim, int dir, out object x, out object y)
        {
            return FindMultiColor(_dm, x1, y1, x2, y2, firstColor, offsetColor, sim, dir, out x, out y);
        }

        public string FindMultiColorEx(int x1, int y1, int x2, int y2, string firstColor, string offsetColor, double sim, int dir)
        {
            return FindMultiColorEx(_dm, x1, y1, x2, y2, firstColor, offsetColor, sim, dir);
        }

        public string AsmCode(int baseAddr)
        {
            return AsmCode(_dm, baseAddr);
        }

        public string Assemble(string asmCode, int baseAddr, int isUpper)
        {
            return Assemble(_dm, asmCode, baseAddr, isUpper);
        }

        public int SetWindowTransparent(int hwnd, int v)
        {
            return SetWindowTransparent(_dm, hwnd, v);
        }

        public string ReadData(int hwnd, string addr, int len)
        {
            return ReadData(_dm, hwnd, addr, len);
        }

        public int WriteData(int hwnd, string addr, string data)
        {
            return WriteData(_dm, hwnd, addr, data);
        }

        public string FindData(int hwnd, string addrRange, string data)
        {
            return FindData(_dm, hwnd, addrRange, data);
        }

        public int SetPicPwd(string pwd)
        {
            return SetPicPwd(_dm, pwd);
        }

        public int Log(string info)
        {
            return Log(_dm, info);
        }

        public string FindStrE(int x1, int y1, int x2, int y2, string str, string color, double sim)
        {
            return FindStrE(_dm, x1, y1, x2, y2, str, color, sim);
        }

        public string FindColorE(int x1, int y1, int x2, int y2, string color, double sim, int dir)
        {
            return FindColorE(_dm, x1, y1, x2, y2, color, sim, dir);
        }

        public string FindPicE(int x1, int y1, int x2, int y2, string picName, string deltaColor, double sim, int dir)
        {
            return FindPicE(_dm, x1, y1, x2, y2, picName, deltaColor, sim, dir);
        }

        public string FindMultiColorE(int x1, int y1, int x2, int y2, string firstColor, string offsetColor, double sim, int dir)
        {
            return FindMultiColorE(_dm, x1, y1, x2, y2, firstColor, offsetColor, sim, dir);
        }

        public int SetExactOcr(int exactOcr)
        {
            return SetExactOcr(_dm, exactOcr);
        }

        public string ReadString(int hwnd, string addr, int type, int len)
        {
            return ReadString(_dm, hwnd, addr, type, len);
        }

        public int FoobarTextPrintDir(int hwnd, int dir)
        {
            return FoobarTextPrintDir(_dm, hwnd, dir);
        }

        public string OcrEx(int x1, int y1, int x2, int y2, string color, double sim)
        {
            return OcrEx(_dm, x1, y1, x2, y2, color, sim);
        }

        public int SetDisplayInput(string mode)
        {
            return SetDisplayInput(_dm, mode);
        }

        public int GetTime()
        {
            return GetTime(_dm);
        }

        public int GetScreenWidth()
        {
            return GetScreenWidth(_dm);
        }

        public int GetScreenHeight()
        {
            return GetScreenHeight(_dm);
        }

        public int BindWindowEx(int hwnd, string display, string mouse, string keypad, string publicDesc, int mode)
        {
            return BindWindowEx(_dm, hwnd, display, mouse, keypad, publicDesc, mode);
        }

        public string GetDiskSerial()
        {
            return GetDiskSerial(_dm);
        }

        public string Md5(string str)
        {
            return Md5(_dm, str);
        }

        public string GetMac()
        {
            return GetMac(_dm);
        }

        public int ActiveInputMethod(int hwnd, string id)
        {
            return ActiveInputMethod(_dm, hwnd, id);
        }

        public int CheckInputMethod(int hwnd, string id)
        {
            return CheckInputMethod(_dm, hwnd, id);
        }

        public int FindInputMethod(string id)
        {
            return FindInputMethod(_dm, id);
        }

        public int GetCursorPos(out object x, out object y)
        {
            return GetCursorPos(_dm, out x, out y);
        }

        public int BindWindow(int hwnd, string display, string mouse, string keypad, int mode)
        {
            return BindWindow(_dm, hwnd, display, mouse, keypad, mode);
        }

        public int FindWindow(string className, string titleName)
        {
            return FindWindow(_dm, className, titleName);
        }

        public int GetScreenDepth()
        {
            return GetScreenDepth(_dm);
        }

        public int SetScreen(int width, int height, int depth)
        {
            return SetScreen(_dm, width, height, depth);
        }

        public int ExitOs(int type)
        {
            return ExitOs(_dm, type);
        }

        public string GetDir(int type)
        {
            return GetDir(_dm, type);
        }

        public int GetOsType()
        {
            return GetOsType(_dm);
        }

        public int FindWindowEx(int parent, string className, string titleName)
        {
            return FindWindowEx(_dm, parent, className, titleName);
        }

        public int SetExportDict(int index, string dictName)
        {
            return SetExportDict(_dm, index, dictName);
        }

        public string GetCursorShape()
        {
            return GetCursorShape(_dm);
        }

        public int DownCpu(int rate)
        {
            return DownCpu(_dm, rate);
        }

        public string GetCursorSpot()
        {
            return GetCursorSpot(_dm);
        }

        public int SendString2(int hwnd, string str)
        {
            return SendString2(_dm, hwnd, str);
        }

        public int FaqPost(string server, int handle, int requestType, int timeOut)
        {
            return FaqPost(_dm, server, handle, requestType, timeOut);
        }

        public string FaqFetch()
        {
            return FaqFetch(_dm);
        }

        public string FetchWord(int x1, int y1, int x2, int y2, string color, string word)
        {
            return FetchWord(_dm, x1, y1, x2, y2, color, word);
        }

        public int CaptureJpg(int x1, int y1, int x2, int y2, string file, int quality)
        {
            return CaptureJpg(_dm, x1, y1, x2, y2, file, quality);
        }

        public int FindStrWithFont(int x1, int y1, int x2, int y2, string str, string color, double sim, string fontName, int fontSize, int flag, out object x, out object y)
        {
            return FindStrWithFont(_dm, x1, y1, x2, y2, str, color, sim, fontName, fontSize, flag, out x, out y);
        }

        public string FindStrWithFontE(int x1, int y1, int x2, int y2, string str, string color, double sim, string fontName, int fontSize, int flag)
        {
            return FindStrWithFontE(_dm, x1, y1, x2, y2, str, color, sim, fontName, fontSize, flag);
        }

        public string FindStrWithFontEx(int x1, int y1, int x2, int y2, string str, string color, double sim, string fontName, int fontSize, int flag)
        {
            return FindStrWithFontEx(_dm, x1, y1, x2, y2, str, color, sim, fontName, fontSize, flag);
        }

        public string GetDictInfo(string str, string fontName, int fontSize, int flag)
        {
            return GetDictInfo(_dm, str, fontName, fontSize, flag);
        }

        public int SaveDict(int index, string file)
        {
            return SaveDict(_dm, index, file);
        }

        public int GetWindowProcessId(int hwnd)
        {
            return GetWindowProcessId(_dm, hwnd);
        }

        public string GetWindowProcessPath(int hwnd)
        {
            return GetWindowProcessPath(_dm, hwnd);
        }

        public int LockInput(int lock1)
        {
            return LockInput(_dm, lock1);
        }

        public string GetPicSize(string picName)
        {
            return GetPicSize(_dm, picName);
        }

        public int GetId()
        {
            return GetID(_dm);
        }

        public int CapturePng(int x1, int y1, int x2, int y2, string file)
        {
            return CapturePng(_dm, x1, y1, x2, y2, file);
        }

        public int CaptureGif(int x1, int y1, int x2, int y2, string file, int delay, int time)
        {
            return CaptureGif(_dm, x1, y1, x2, y2, file, delay, time);
        }

        public int ImageToBmp(string picName, string bmpName)
        {
            return ImageToBmp(_dm, picName, bmpName);
        }

        public int FindStrFast(int x1, int y1, int x2, int y2, string str, string color, double sim, out object x, out object y)
        {
            return FindStrFast(_dm, x1, y1, x2, y2, str, color, sim, out x, out y);
        }

        public string FindStrFastEx(int x1, int y1, int x2, int y2, string str, string color, double sim)
        {
            return FindStrFastEx(_dm, x1, y1, x2, y2, str, color, sim);
        }

        public string FindStrFastE(int x1, int y1, int x2, int y2, string str, string color, double sim)
        {
            return FindStrFastE(_dm, x1, y1, x2, y2, str, color, sim);
        }

        public int EnableDisplayDebug(int enableDebug)
        {
            return EnableDisplayDebug(_dm, enableDebug);
        }

        public int CapturePre(string file)
        {
            return CapturePre(_dm, file);
        }

        public int RegEx(string code, string ver, string ip)
        {
            return RegEx(_dm, code, ver, ip);
        }

        public string GetMachineCode()
        {
            return GetMachineCode(_dm);
        }

        public int SetClipboard(string data)
        {
            return SetClipboard(_dm, data);
        }

        public string GetClipboard()
        {
            return GetClipboard(_dm);
        }

        public int GetNowDict()
        {
            return GetNowDict(_dm);
        }

        public int Is64Bit()
        {
            return Is64Bit(_dm);
        }

        public int GetColorNum(int x1, int y1, int x2, int y2, string color, double sim)
        {
            return GetColorNum(_dm, x1, y1, x2, y2, color, sim);
        }

        public string EnumWindowByProcess(string processName, string title, string className, int filter)
        {
            return EnumWindowByProcess(_dm, processName, title, className, filter);
        }

        public int GetDictCount(int index)
        {
            return GetDictCount(_dm, index);
        }

        public int GetLastError()
        {
            return GetLastError(_dm);
        }

        public string GetNetTime()
        {
            return GetNetTime(_dm);
        }

        public int EnableGetColorByCapture(int en)
        {
            return EnableGetColorByCapture(_dm, en);
        }

        public int CheckUac()
        {
            return CheckUAC(_dm);
        }

        public int SetUac(int uac)
        {
            return SetUAC(_dm, uac);
        }

        public int DisableFontSmooth()
        {
            return DisableFontSmooth(_dm);
        }

        public int CheckFontSmooth()
        {
            return CheckFontSmooth(_dm);
        }

        public int SetDisplayAcceler(int level)
        {
            return SetDisplayAcceler(_dm, level);
        }

        public int FindWindowByProcess(string processName, string className, string titleName)
        {
            return FindWindowByProcess(_dm, processName, className, titleName);
        }

        public int FindWindowByProcessId(int processId, string className, string titleName)
        {
            return FindWindowByProcessId(_dm, processId, className, titleName);
        }

        public string ReadIni(string section, string key, string file)
        {
            return ReadIni(_dm, section, key, file);
        }

        public int WriteIni(string section, string key, string v, string file)
        {
            return WriteIni(_dm, section, key, v, file);
        }
        public int RunApp(string path)
        {
            System.Diagnostics.Process.Start(path);
            return 1;
            //return RunApp(_dm, path, mode);
        }
        public void Delay(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

        public int FindWindowSuper(string spec1, int flag1, int type1, string spec2, int flag2, int type2)
        {
            return FindWindowSuper(_dm, spec1, flag1, type1, spec2, flag2, type2);
        }

        public string ExcludePos(string allPos, int type, int x1, int y1, int x2, int y2)
        {
            return ExcludePos(_dm, allPos, type, x1, y1, x2, y2);
        }

        public string FindNearestPos(string allPos, int type, int x, int y)
        {
            return FindNearestPos(_dm, allPos, type, x, y);
        }

        public string SortPosDistance(string allPos, int type, int x, int y)
        {
            return SortPosDistance(_dm, allPos, type, x, y);
        }

        public int FindPicMem(int x1, int y1, int x2, int y2, string picInfo, string deltaColor, double sim, int dir, out object x, out object y)
        {
            return FindPicMem(_dm, x1, y1, x2, y2, picInfo, deltaColor, sim, dir, out x, out y);
        }

        public string FindPicMemEx(int x1, int y1, int x2, int y2, string picInfo, string deltaColor, double sim, int dir)
        {
            return FindPicMemEx(_dm, x1, y1, x2, y2, picInfo, deltaColor, sim, dir);
        }

        public string FindPicMemE(int x1, int y1, int x2, int y2, string picInfo, string deltaColor, double sim, int dir)
        {
            return FindPicMemE(_dm, x1, y1, x2, y2, picInfo, deltaColor, sim, dir);
        }

        public string AppendPicAddr(string picInfo, int addr, int size)
        {
            return AppendPicAddr(_dm, picInfo, addr, size);
        }

        public int WriteFile(string file, string content)
        {
            return WriteFile(_dm, file, content);
        }

        public int Stop(int id)
        {
            return Stop(_dm, id);
        }

        public int SetDictMem(int index, int addr, int size)
        {
            return SetDictMem(_dm, index, addr, size);
        }

        public string GetNetTimeSafe()
        {
            return GetNetTimeSafe(_dm);
        }

        public int ForceUnBindWindow(int hwnd)
        {
            return ForceUnBindWindow(_dm, hwnd);
        }
        /// <summary>
        /// 读取加密的ini文件
        /// </summary>
        /// <param name="section">小节名</param>
        /// <param name="key">变量名</param>
        /// <param name="file">文件路径(当前路径用./开头)</param>
        /// <param name="pwd">加密密码</param>
        /// <returns>变量值</returns>
        public string ReadIniPwd(string section, string key, string file, string pwd)
        {
            return AesDecrypt(AesDecrypt(ReadIni(AesEncrypt(AesEncrypt(section,pwd), "TYYXPWD"), AesEncrypt(AesEncrypt(key,pwd), "TYYXPWD").Replace("=",string.Empty), file), "TYYXPWD"),pwd);
        }

        /// <summary>
        /// 写入加密的ini文件
        /// </summary>
        /// <param name="section">小节名</param>
        /// <param name="key">变量名</param>
        /// <param name="v">变量值</param>
        /// <param name="file">文件路径(当前路径用./开头)</param>
        /// <param name="pwd">加密密码</param>
        /// <returns>1 or 0</returns>
        public int WriteIniPwd(string section, string key, string v, string file, string pwd)
        {
            return WriteIni(AesEncrypt(AesEncrypt(section, pwd), "TYYXPWD"), AesEncrypt(AesEncrypt(key, pwd), "TYYXPWD").Replace("=", string.Empty), AesEncrypt(AesEncrypt(v, pwd), "TYYXPWD"), file);
        }

        public int DecodeFile(string file, string pwd)
        {
            return DecodeFile(_dm, file, pwd);
        }

        public int KeyDownChar(string keyStr)
        {
            return KeyDownChar(_dm, keyStr);
        }

        public int KeyUpChar(string keyStr)
        {
            return KeyUpChar(_dm, keyStr);
        }

        public int KeyPressChar(string keyStr)
        {
            return KeyPressChar(_dm, keyStr);
        }

        #region 收费改不收费 实现大小写按键
        private const int KeyeventfExtendedkey = 0x1;
        private const int KeyeventfKeyup = 0x2;
        private const int VkCapital = 0x14;
        /// <summary>
        /// 改变键状态
        /// </summary>
        /// <param name="bVk"></param>
        /// <param name="bScan"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, EntryPoint = "keybd_event", CallingConvention = CallingConvention.Winapi)]
        private static extern void Keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        #endregion

        /// <summary>
        /// 模拟按键输入字符串值(只支持大小写字母.特殊符号 和数字)
        /// </summary>
        /// <param name="keyStr">模拟输入的字符串</param>
        /// <param name="delay">每个字之间的延迟</param>
        /// <param name="iszs">是否模拟真实输入</param>
        /// <returns>返回1 or 0</returns>
        public int KeyPressStr(string keyStr, int delay,int iszs = 0)
        {
            try
            {
                foreach (var chr in keyStr)
                {
                    if (char.IsUpper(chr))
                    {
                        Keybd_event(VkCapital, 0x45, KeyeventfExtendedkey, (UIntPtr) 0);
                        Keybd_event(VkCapital, 0x45, KeyeventfExtendedkey | KeyeventfKeyup, (UIntPtr) 0);
                        KeyPressChar(chr.ToString());
                        Keybd_event(VkCapital, 0x45, KeyeventfExtendedkey, (UIntPtr) 0);
                        Keybd_event(VkCapital, 0x45, KeyeventfExtendedkey | KeyeventfKeyup, (UIntPtr) 0);
                    }
                    else
                    {
                        KeyPressChar(chr.ToString());
                    }
                    Delay(iszs == 0 ? delay : new Random().Next(1, 100));
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return 1;
        }

        public int EnableKeypadPatch(int en)
        {
            return EnableKeypadPatch(_dm, en);
        }

        public int EnableKeypadSync(int en, int timeOut)
        {
            return EnableKeypadSync(_dm, en, timeOut);
        }

        public int EnableMouseSync(int en, int timeOut)
        {
            return EnableMouseSync(_dm, en, timeOut);
        }

        public int DmGuard(int en, string type)
        {
            return DmGuard(_dm, en, type);
        }

        public int FaqCaptureFromFile(int x1, int y1, int x2, int y2, string file, int quality)
        {
            return FaqCaptureFromFile(_dm, x1, y1, x2, y2, file, quality);
        }

        public string FindIntEx(int hwnd, string addrRange, int intValueMin, int intValueMax, int type, int step, int multiThread, int mode)
        {
            return FindIntEx(_dm, hwnd, addrRange, intValueMin, intValueMax, type, step, multiThread, mode);
        }

        public string FindFloatEx(int hwnd, string addrRange, Single floatValueMin, Single floatValueMax, int step, int multiThread, int mode)
        {
            return FindFloatEx(_dm, hwnd, addrRange, floatValueMin, floatValueMax, step, multiThread, mode);
        }

        public string FindDoubleEx(int hwnd, string addrRange, double doubleValueMin, double doubleValueMax, int step, int multiThread, int mode)
        {
            return FindDoubleEx(_dm, hwnd, addrRange, doubleValueMin, doubleValueMax, step, multiThread, mode);
        }

        public string FindStringEx(int hwnd, string addrRange, string stringValue, int type, int step, int multiThread, int mode)
        {
            return FindStringEx(_dm, hwnd, addrRange, stringValue, type, step, multiThread, mode);
        }

        public string FindDataEx(int hwnd, string addrRange, string data, int step, int multiThread, int mode)
        {
            return FindDataEx(_dm, hwnd, addrRange, data, step, multiThread, mode);
        }

        public int EnableRealMouse(int en, int mousedelay, int mousestep)
        {
            return EnableRealMouse(_dm, en, mousedelay, mousestep);
        }

        public int EnableRealKeypad(int en)
        {
            return EnableRealKeypad(_dm, en);
        }

        public int SendStringIme(string str)
        {
            return SendStringIme(_dm, str);
        }

        public int FoobarDrawLine(int hwnd, int x1, int y1, int x2, int y2, string color, int style, int width)
        {
            return FoobarDrawLine(_dm, hwnd, x1, y1, x2, y2, color, style, width);
        }

        public string FindStrEx(int x1, int y1, int x2, int y2, string str, string color, double sim)
        {
            return FindStrEx(_dm, x1, y1, x2, y2, str, color, sim);
        }

        public int IsBind(int hwnd)
        {
            return IsBind(_dm, hwnd);
        }

        public int SetDisplayDelay(int t)
        {
            return SetDisplayDelay(_dm, t);
        }

        public int GetDmCount()
        {
            return GetDmCount(_dm);
        }

        public int DisableScreenSave()
        {
            return DisableScreenSave(_dm);
        }

        public int DisablePowerSave()
        {
            return DisablePowerSave(_dm);
        }

        public int SetMemoryHwndAsProcessId(int en)
        {
            return SetMemoryHwndAsProcessId(_dm, en);
        }

        public int FindShape(int x1, int y1, int x2, int y2, string offsetColor, double sim, int dir, out object x, out object y)
        {
            return FindShape(_dm, x1, y1, x2, y2, offsetColor, sim, dir, out x, out y);
        }

        public string FindShapeE(int x1, int y1, int x2, int y2, string offsetColor, double sim, int dir)
        {
            return FindShapeE(_dm, x1, y1, x2, y2, offsetColor, sim, dir);
        }

        public string FindShapeEx(int x1, int y1, int x2, int y2, string offsetColor, double sim, int dir)
        {
            return FindShapeEx(_dm, x1, y1, x2, y2, offsetColor, sim, dir);
        }

        public string FindStrS(int x1, int y1, int x2, int y2, string str, string color, double sim, out object x, out object y)
        {
            return FindStrS(_dm, x1, y1, x2, y2, str, color, sim, out x, out y);
        }

        public string FindStrExS(int x1, int y1, int x2, int y2, string str, string color, double sim)
        {
            return FindStrExS(_dm, x1, y1, x2, y2, str, color, sim);
        }

        public string FindStrFastS(int x1, int y1, int x2, int y2, string str, string color, double sim, out object x, out object y)
        {
            return FindStrFastS(_dm, x1, y1, x2, y2, str, color, sim, out x, out y);
        }

        public string FindStrFastExS(int x1, int y1, int x2, int y2, string str, string color, double sim)
        {
            return FindStrFastExS(_dm, x1, y1, x2, y2, str, color, sim);
        }

        public string FindPicS(int x1, int y1, int x2, int y2, string picName, string deltaColor, double sim, int dir, out object x, out object y)
        {
            return FindPicS(_dm, x1, y1, x2, y2, picName, deltaColor, sim, dir, out x, out y);
        }

        public string FindPicExS(int x1, int y1, int x2, int y2, string picName, string deltaColor, double sim, int dir)
        {
            return FindPicExS(_dm, x1, y1, x2, y2, picName, deltaColor, sim, dir);
        }

        public int ClearDict(int index)
        {
            return ClearDict(_dm, index);
        }

        public string GetMachineCodeNoMac()
        {
            return GetMachineCodeNoMac(_dm);
        }

        public int GetClientRect(int hwnd, out object x1, out object y1, out object x2, out object y2)
        {
            return GetClientRect(_dm, hwnd, out x1, out y1, out x2, out y2);
        }

        public int EnableFakeActive(int en)
        {
            return EnableFakeActive(_dm, en);
        }

        public int GetScreenDataBmp(int x1, int y1, int x2, int y2, out object data, out object size)
        {
            return GetScreenDataBmp(_dm, x1, y1, x2, y2, out data, out size);
        }

        public int EncodeFile(string file, string pwd)
        {
            return EncodeFile(_dm, file, pwd);
        }

        public string GetCursorShapeEx(int type)
        {
            return GetCursorShapeEx(_dm, type);
        }

        public int FaqCancel()
        {
            return FaqCancel(_dm);
        }

        public string IntToData(int intValue, int type)
        {
            return IntToData(_dm, intValue, type);
        }

        public string FloatToData(Single floatValue)
        {
            return FloatToData(_dm, floatValue);
        }

        public string DoubleToData(double doubleValue)
        {
            return DoubleToData(_dm, doubleValue);
        }

        public string StringToData(string stringValue, int type)
        {
            return StringToData(_dm, stringValue, type);
        }

        public int SetMemoryFindResultToFile(string file)
        {
            return SetMemoryFindResultToFile(_dm, file);
        }

        public int EnableBind(int en)
        {
            return EnableBind(_dm, en);
        }

        public int SetSimMode(int mode)
        {
            return SetSimMode(_dm, mode);
        }

        public int LockMouseRect(int x1, int y1, int x2, int y2)
        {
            return LockMouseRect(_dm, x1, y1, x2, y2);
        }

        public int SendPaste(int hwnd)
        {
            return SendPaste(_dm, hwnd);
        }

        public int IsDisplayDead(int x1, int y1, int x2, int y2, int t)
        {
            return IsDisplayDead(_dm, x1, y1, x2, y2, t);
        }

        public int GetKeyState(int vk)
        {
            return GetKeyState(_dm, vk);
        }

        public int CopyFile(string srcFile, string dstFile, int over)
        {
            return CopyFile(_dm, srcFile, dstFile, over);
        }

        public int IsFileExist(string file)
        {
            return IsFileExist(_dm, file);
        }

        public int DeleteFile(string file)
        {
            return DeleteFile(_dm, file);
        }

        public int MoveFile(string srcFile, string dstFile)
        {
            return MoveFile(_dm, srcFile, dstFile);
        }

        public int CreateFolder(string folderName)
        {
            return CreateFolder(_dm, folderName);
        }

        public int DeleteFolder(string folderName)
        {
            return DeleteFolder(_dm, folderName);
        }

        public int GetFileLength(string file)
        {
            return GetFileLength(_dm, file);
        }

        public string ReadFile(string file)
        {
            return ReadFile(_dm, file);
        }

        public int WaitKey(int keyCode, int timeOut)
        {
            return WaitKey(_dm, keyCode, timeOut);
        }

        public int DeleteIni(string section, string key, string file)
        {
            return DeleteIni(_dm, section, key, file);
        }
        /// <summary>
        /// 删除加密的ini文件小节
        /// </summary>
        /// <param name="section">小节名</param>
        /// <param name="key">变量名(如果变量名为空删除整个小节)</param>
        /// <param name="file">文件路径(当前路径用./开头)</param>
        /// <param name="pwd">加密密码</param>
        /// <returns>1 or 0</returns>
        public int DeleteIniPwd(string section, string key, string file, string pwd)
        {
            return DeleteIni(AesEncrypt(AesEncrypt(section, pwd), "TYYXPWD"), AesEncrypt(AesEncrypt(key, pwd), "TYYXPWD").Replace("=", string.Empty), file);
        }

        public int EnableSpeedDx(int en)
        {
            return EnableSpeedDx(_dm, en);
        }

        public int EnableIme(int en)
        {
            return EnableIme(_dm, en);
        }

        public int Reg(string code, string ver)
        {
            return Reg(_dm, code, ver);
        }

        public string SelectFile()
        {
            return SelectFile(_dm);
        }

        public string SelectDirectory()
        {
            return SelectDirectory(_dm);
        }

        public int LockDisplay(int lock1)
        {
            return LockDisplay(_dm, lock1);
        }

        public int FoobarSetSave(int hwnd, string file, int en, string header)
        {
            return FoobarSetSave(_dm, hwnd, file, en, header);
        }

        public string EnumWindowSuper(string spec1, int flag1, int type1, string spec2, int flag2, int type2, int sort)
        {
            return EnumWindowSuper(_dm, spec1, flag1, type1, spec2, flag2, type2, sort);
        }

        public int DownloadFile(string url, string saveFile, int timeout)
        {
            return DownloadFile(_dm, url, saveFile, timeout);
        }

        public int EnableKeypadMsg(int en)
        {
            return EnableKeypadMsg(_dm, en);
        }

        public int EnableMouseMsg(int en)
        {
            return EnableMouseMsg(_dm, en);
        }

        public int RegNoMac(string code, string ver)
        {
            return RegNoMac(_dm, code, ver);
        }

        public int RegExNoMac(string code, string ver, string ip)
        {
            return RegExNoMac(_dm, code, ver, ip);
        }

        public int SetEnumWindowDelay(int delay)
        {
            return SetEnumWindowDelay(_dm, delay);
        }

        public int FindMulColor(int x1, int y1, int x2, int y2, string color, double sim)
        {
            return FindMulColor(_dm, x1, y1, x2, y2, color, sim);
        }

        public string GetDict(int index, int fontIndex)
        {
            return GetDict(_dm, index, fontIndex);
        }

        #endregion

        #region 继承释放接口方法

        public void Close()
        {
            Dispose();
        }

        ~DmSoft()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            if (_dm != IntPtr.Zero)
            {
                UnBindWindow();
                _dm = IntPtr.Zero;
                FreeDM();
            }
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        #endregion

        #region 扩展功能

        /// <summary>  
        /// AES加密
        /// </summary>  
        /// <param name="data">要加密的明文</param>  
        /// <param name="key">密钥</param>  
        /// <returns>密文</returns>
        public string AesEncrypt(string data, string key)
        {
            if (string.IsNullOrEmpty(data)) return string.Empty;
            MemoryStream mStream = new MemoryStream();
            RijndaelManaged aes = new RijndaelManaged();

            var plainBytes = Encoding.UTF8.GetBytes(data);
            var bKey = new byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(key.PadRight(bKey.Length)), bKey, bKey.Length);

            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;
            aes.Key = bKey;
            CryptoStream cryptoStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
            try
            {
                cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            finally
            {
                cryptoStream.Close();
                mStream.Close();
                aes.Clear();
            }
        }


        /// <summary>  
        /// AES解密
        /// </summary>  
        /// <param name="data">被加密的明文</param>  
        /// <param name="key">密钥</param>  
        /// <returns>明文</returns>  
        public string AesDecrypt(string data, string key)
        {
            if (string.IsNullOrEmpty(data)) return string.Empty;
            var encryptedBytes = Convert.FromBase64String(data);
            var bKey = new byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(key.PadRight(bKey.Length)), bKey, bKey.Length);

            MemoryStream mStream = new MemoryStream(encryptedBytes);
            RijndaelManaged aes = new RijndaelManaged
            {
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                Key = bKey
            };
            CryptoStream cryptoStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Read);
            try
            {
                var tmp = new byte[encryptedBytes.Length + 32];
                var len = cryptoStream.Read(tmp, 0, encryptedBytes.Length + 32);
                var ret = new byte[len];
                Array.Copy(tmp, 0, ret, 0, len);
                return Encoding.UTF8.GetString(ret);
            }
            finally
            {
                cryptoStream.Close();
                mStream.Close();
                aes.Clear();
            }
        }

        #endregion

    }
}
