using System;
using System.ServiceModel;
using System.Threading;
using TYDB;
using TYPublicCore;

namespace TYExServiceCore
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine($@"正在连接数据库 ... ... {Environment.NewLine}时间:{DateTime.Now}");
                if (!TySqLite.Init(out var err))
                {
                    Console.WriteLine(err);
                    Console.Read();
                    return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(@"数据库初始化异常,请检查数据库配置!");
                TyLog.WriteError(e);
                Console.Read();
                return;
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
                TyCore.DeleteExit();
                TyCore.ShowConsole(0);
                TyCore.AutoStart(@"TYExServiceCore");
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