using System.Runtime.InteropServices;

namespace 大漠debug
{
    public class DmHelper
    {
        [DllImport("dm5.dll")]
        public static extern int RegDebug();
    }
}
