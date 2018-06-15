using System;
using TYPublicCore;
using TYServiceCore;
namespace TYService
{
    class Program
    {
        static void Main(string[] args)
        {
            TYCore.DeleteExit();
            if (!TYSQLite.Init(out string err)) Console.WriteLine(err);
            TYUdp._main += Index._main;
            TYUdp.ServiceOpen();
        }
    }
}
