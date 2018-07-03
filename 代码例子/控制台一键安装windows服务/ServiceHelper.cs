using System;
using System.Collections;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;

namespace TYExServiceCore
{
    public class ServiceHelper
    {
        /// <summary>
        /// 服务是否存在
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static bool IsServiceExisted(string serviceName)
        {
            var services = ServiceController.GetServices();
            return services.Any(s => s.ServiceName == serviceName);
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="serviceName"></param>
        public static void StartService(string serviceName)
        {
            if (!IsServiceExisted(serviceName)) return;
            var service = new ServiceController(serviceName);
            if (service.Status == ServiceControllerStatus.Running ||
                service.Status == ServiceControllerStatus.StartPending) return;
            service.Start();
            for (var i = 0; i < 60; i++)
            {
                service.Refresh();
                System.Threading.Thread.Sleep(1000);
                if (service.Status == ServiceControllerStatus.Running)
                {
                    break;
                }
                if (i == 59)
                {
                    throw new Exception("打开服务错误：" + serviceName);
                }
            }
        }

        /// <summary>
        /// 获取服务状态
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public static ServiceControllerStatus GetServiceStatus(string serviceName)
        {
            var service = new ServiceController(serviceName);
            return service.Status;
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="install"></param>
        public static void ConfigService(string serviceName, bool install)
        {
            var ti = new TransactedInstaller();
            ti.Installers.Add(new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalSystem
            });
            ti.Installers.Add(new ServiceInstaller
            {
                DisplayName = serviceName,
                ServiceName = serviceName,
                Description = "天域后台服务",
                //ServicesDependedOn = new[] { "MySql" },//前置服务
                StartType = ServiceStartMode.Automatic //运行方式
            });
            ti.Context = new InstallContext();
            ti.Context.Parameters["assemblypath"] = "\"" + Assembly.GetEntryAssembly().Location + "\" /service";
            if (install)
            {
                ti.Install(new Hashtable());
            }
            else
            {
                ti.Uninstall(null);
            }
        }
    }
}