using System;

namespace TYUninstall
{
    class Program
    {
        static void Main(string[] args)
        {
            TYPublicCore.TyCore.UnAutoStart("TYExServiceCore");
            TYPublicCore.TyCore.KillProcess("TYExServiceCore");
            Console.WriteLine("已成功卸载TYExServiceCore服务");
            Console.Read();
        }
    }
}
