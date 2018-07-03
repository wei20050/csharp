using System;
using System.ServiceModel;
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
                TyLog.Wlog(e);
                Console.Read();
                return;
            }
           
            var host  =  new ServiceHost(typeof(TyService));
            host.Opened += delegate
            {
                Console.WriteLine(@"服务已开启 ... ... 时间:{0}", DateTime.Now);
            };
            host.Closed += delegate
            {
                Console.WriteLine(@"服务已关闭 ... ... 时间:{0}", DateTime.Now);
            };
            try
            {
                host.Open();
                TyCore.DeleteExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(@"服务开启异常,请检查服务器配置!");
                TyLog.Wlog(e);
                Console.Read();
                return;
            }
            while (true)Console.Read();
        }
    }
}