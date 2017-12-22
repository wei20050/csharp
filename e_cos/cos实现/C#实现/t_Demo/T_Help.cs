using System.Runtime.InteropServices;
namespace t_Demo
{
    public static class T_Help
    {
        [DllImport("t.dll")]
        public extern static string KeyXZ(string CosKey,string AppName,string KeyNum);
        [DllImport("t.dll")]
        public extern static string KeyYZ(string CosKey, string AppName, string Key,string DN);
        [DllImport("t.dll")]
        public extern static string KeyJB(string CosKey, string AppName, string Key);
        [DllImport("t.dll")]
        public extern static string KeyCZ(string CosKey, string AppName, string Key,string keyNum);
        [DllImport("t.dll")]
        public extern static string KeySC(string CosKey, string AppName, string Key);
        [DllImport("t.dll")]
        public extern static string KeySetConfig(string CosKey, string AppName, string Key, string path);
        [DllImport("t.dll")]
        public extern static string KeyGetConfig(string CosKey, string AppName, string Key, string path);
        [DllImport("t.dll")]
        public extern static string KeyCX(string CosKey, string AppName, string Key);
        [DllImport("t.dll")]
        public extern static string KeyLOG(string Content, bool IsErr);
        [DllImport("t.dll")]
        public extern static string Encrypt(string Content, bool Key);
        [DllImport("t.dll")]
        public extern static string Decrypt(string Content, bool Key);
        
    }
}
