using System;
using System.ServiceProcess;

namespace TYExServiceCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //带参启动运行服务
            if (args.Length > 0)
            {
                try
                {
                    ServiceBase[] serviceToRun = { new WindowsService() };
                    ServiceBase.Run(serviceToRun);
                }
                catch (Exception ex)
                {
                    System.IO.File.AppendAllText(@"D:\Log.txt", "\nService Start Error：" + DateTime.Now + "\n" + ex.Message);
                }
            }
            //不带参启动配置程序
            else
            {
                StartLable:
                Console.WriteLine("请选择你要执行的操作——1：部署服务，2：卸载服务，3：验证服务，回车或Esc:退出");
                Console.WriteLine("——————————————————————————————————");
                var key = Console.ReadKey().Key;

                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        if (ServiceHelper.IsServiceExisted("TYExService"))
                        {
                            ServiceHelper.ConfigService("TYExService", false);
                        }
                        if (!ServiceHelper.IsServiceExisted("TYExService"))
                        {
                            ServiceHelper.ConfigService("TYExService", true);
                        }
                        ServiceHelper.StartService("TYExService");
                        goto StartLable;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        if (ServiceHelper.IsServiceExisted("TYExService"))
                        {
                            ServiceHelper.ConfigService("TYExService", false);
                        }
                        else
                        {
                            Console.WriteLine("\n服务不存在 ... ...");
                        }
                        goto StartLable;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        if (!ServiceHelper.IsServiceExisted("TYExService"))
                        {
                            Console.WriteLine("\n服务不存在 ... ...");
                        }
                        else
                        {
                            Console.WriteLine("\n服务状态：" + ServiceHelper.GetServiceStatus("TYExService"));
                        }
                        goto StartLable;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Escape:
                        break;
                    default:
                        Console.WriteLine("\n请输入一个有效键！");
                        Console.WriteLine("——————————————————————————————————");
                        goto StartLable;
                }
            }
        }
    }
}