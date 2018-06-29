using System;
using TYDB;
using TYPublicCore;

namespace TYServiceCore
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!TySqLite.Init(out var err))
            {
                Console.WriteLine(err);
                return;
            }
            TyCore.DeleteExit();
            TyUdp.ServiceOpen();
        }
    }
}
