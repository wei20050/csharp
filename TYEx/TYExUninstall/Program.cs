using System;
using TYExPublicCore;

namespace TYEXUninstall
{
    class Program
    {
        static void Main(string[] args)
        {
            TyCore.UnAutoStart("TYExServiceCore");
            TyCore.KillProcess("TYExServiceCore");
            Console.WriteLine("已成功卸载TYExServiceCore服务");
            Console.Read();
        }
    }
}
