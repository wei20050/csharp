using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace TY
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                //设置应用程序处理异常方式：ThreadException处理
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException += Application_ThreadException;
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                #region 应用程序的主入口点
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
                #endregion
            }
            catch (Exception ex)
            {
                var str = GetExceptionMsg(ex, string.Empty);
                MessageBox.Show(str, @"系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            var str = GetExceptionMsg(e.Exception, e.ToString());
            MessageBox.Show(str, @"系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            MessageBox.Show(str, @"系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 生成自定义异常消息
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="backStr">备用异常消息：当ex为null时有效</param>
        /// <returns>异常字符串文本</returns>
        private static string GetExceptionMsg(Exception ex, string backStr)
        {
            var sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendFormat("【出现时间】：{0}{1}", DateTime.Now.ToString(CultureInfo.CurrentCulture),Environment.NewLine);
            if (ex != null)
            {
                sb.AppendFormat("【异常类型】：{0}{1}" , ex.GetType().Name, Environment.NewLine);
                sb.AppendFormat("【异常信息】：{0}{1}", ex.Message, Environment.NewLine);
                if (Debugger.IsAttached)
                {
                    sb.AppendFormat("【堆栈调用】：{0}{1}", ex.StackTrace, Environment.NewLine);
                }
            }
            else
            {
                sb.AppendFormat("【未处理异常】：" + backStr);
            }
            sb.AppendLine("*****************************************************************");
            return sb.ToString();
        }
    }
}
