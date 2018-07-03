using System;
using System.ServiceModel;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace TYExServiceCore
{
    internal partial class WindowsService : ServiceBase
    {
        private readonly ServiceHost _host;
        public WindowsService()
        {
            InitializeComponent();
            _host = new ServiceHost(typeof(TyService));
        }

        protected override void OnStart(string[] args)
        {

            System.IO.File.AppendAllText(@"D:\Log.txt", " Service Start :" + DateTime.Now);
            //使用Task 就可以解决原来作者那个启动服务后需要循环60秒判断任务是否开始等一系列问题
            new Task(() =>
            {
                _host.Opened += delegate
                {
                    Console.WriteLine(@"wcf windows service is start at @{0}", DateTime.Now);
                };
                _host.Closed += delegate
                {
                    Console.WriteLine(@"wcf windows service is stop at @{0}", DateTime.Now);
                };
                try
                {
                    _host.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }).Start();
        }

        protected override void OnStop()
        {
            System.IO.File.AppendAllText(@"D:\Log.txt", " Service Stop :" + DateTime.Now);
        }
    }
}