using System.Runtime.InteropServices;
namespace t_Demo
{
    public static class Cos
    {
        /// <summary>
        /// 动态库路径
        /// </summary>
        private const string DllPath = "cosuser.dll";
        /// <summary>
        /// cos连接秘钥
        /// </summary>
        private const string CosKey = "0C00770CC0740CF0900DD04F0FC0C407A0130370630B60AD0540C30A70EC05C02C0940F405D00E0310930DD0830EF0760DE0170060950F101B0960730330C40F30C007A0E50870B708301F0A60630E00E60DE01600208C0C80880140FD05F0D600B07F07005F0D10E70B405B0B200B0AC04A07206808904E0000080A700E0CC03E0660220F203E0AF0210BB0ED06F0880840C006B02505C0DC0080280630F20930F90F90CA0A708604E0170FE0840DE0BC016025";
        /// <summary>
        /// 应用名称
        /// </summary>
        private const string AppName = "测试应用";
        /// <summary>
        /// 成功
        /// </summary>
        private const string Success = "1";
        [DllImport(DllPath)]
        private extern static string KeyYZ(string cosKey, string appName, string key,string dn);
        /// <summary>
        /// 验证秘钥
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="dn">电脑机器码</param>
        /// <returns>是否成功</returns>
        public static bool KeyYz(string key,string dn)
        {
            return KeyYZ(CosKey, AppName, key,dn) == Success;
        }
        [DllImport(DllPath)]
        private extern static string KeyCZ(string cosKey, string appName, string key, string keyNum);
        /// <summary>
        /// 给秘钥充值
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="keyNum">充值天数</param>
        /// <returns>是否成功</returns>
        public static bool KeyCz(string key, string keyNum)
        {
            return KeyCZ(CosKey, AppName, key, keyNum) == Success;
        }
        [DllImport(DllPath)]
        private extern static string KeySet(string cosKey, string appName, string key, string path);
        /// <summary>
        /// 根据秘钥写文本文件到服务器
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="path">文本文件路径</param>
        /// <returns>是否成功</returns>
        public static bool KeySet(string key, string path)
        {
            return KeySet(CosKey, AppName, key, path) == Success;
        }
        [DllImport(DllPath)]
        private extern static string KeyGet(string cosKey, string appName, string key, string path);
        /// <summary>
        /// 根据秘钥读文本文件到本地
        /// </summary>
        /// <param name="key">取文件的秘钥</param>
        /// <param name="path">存到的文件路径</param>
        /// <returns>是否成功</returns>
        public static bool KeyGet(string key, string path)
        {
            return KeyGet(CosKey, AppName, key, path) == Success;
        }
        [DllImport(DllPath)]
        private extern static string KeyCX(string cosKey, string appName, string key);
        /// <summary>
        /// 查询key
        /// </summary>
        /// <param name="key">为空则查询所有 否则查询单条</param>
        /// <returns>查询到的数据 没有匹配数据返回空字符串</returns>
        public static string KeyCx(string key)
        {
            return KeyCX(CosKey, AppName, key);
        }
        [DllImport(DllPath)]
        private extern static void KeyLOG(string content, string isErr);
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="content">日志类容</param>
        /// <param name="isErr">是否是错误日志默认不是错误日志</param>
        public static void KeyLog(string content, string isErr = Success)
        {
            KeyLOG( content,  isErr);
        }
        [DllImport(DllPath)]
        private extern static string Encrypt(string content, string key);
        /// <summary>
        /// 加密文本
        /// </summary>
        /// <param name="content">待加密的文本</param>
        /// <param name="key">秘钥</param>
        /// <returns>加密后的文本</returns>
        public static string KeyEncrypt(string content, string key)
        {
            return Encrypt( content, key);
        }
        [DllImport(DllPath)]
        private extern static string Decrypt(string content, string key);
        /// <summary>
        /// 解密文本
        /// </summary>
        /// <param name="content">密文</param>
        /// <param name="key">秘钥</param>
        /// <returns>解密后的文本</returns>
        public static string KeyDecrypt(string content, string key)
        {
            return Decrypt(content, key);
        }

    }
}
