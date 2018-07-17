using System;
using System.Configuration;
using System.IO;
using System.ServiceModel;
using TYExPublicCore;

namespace TYExServiceCore
{
    internal class Program
    {
        private static void Main()
        {
            TyCore.DeleteExit();//禁用关闭按钮
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "TYExServiceCore.exe.config"))
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "TYExServiceCore.exe.config", Properties.Resources.TYExServiceCore_exe);
            }
            var host  =  new ServiceHost(typeof(TyService));
            host.Opened += delegate
            {
                Console.WriteLine($@"服务已开启 ... ... {Environment.NewLine}时间:{DateTime.Now}");
            };
            host.Closed += delegate
            {
                Console.WriteLine($@"服务已关闭 ... ...{Environment.NewLine}时间:{DateTime.Now}");
            };
            try
            {
                host.Open();
                if (ConfigurationManager.AppSettings["ServiceDeBug"] == "false")
                {
                    TyCore.ShowConsole(0);
                    TyCore.AutoStart(@"TYExServiceCore");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(@"服务开启异常,请检查服务器配置!");
                TyLog.WriteError(e);
                Console.Read();
                return;
            }
            while (true)Console.Read();
        }
    }
}