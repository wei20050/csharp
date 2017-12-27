using System.Runtime.InteropServices;
namespace t_Demo
{
    public static class Cos
    {
        /// <summary>
        /// 动态库路径
        /// </summary>
        private const string DllPath = "cos.dll";
        /// <summary>
        /// cos连接秘钥
        /// </summary>
        private const string CosKey = "0C800F07C0F50E404804808902603702F07E0EF0530500290140C60E10050EE04F0170700480AC0520990F40870EB0A30CC0430CC0AF00303902303404D0C00F90EC0FF0C901D0430CE0DC0EC00D0AF01507E05E0A90090B50930EE0170ED08B08403604D07007105803C0F80F90D501503D0720330D60BE0D00020910930F808B0040DC01701307B0D70300EF0380EE07808004309802807F0E20570720890C20B10B501503402007606C0CB0DD0DA0790830D8";
        /// <summary>
        /// 应用名称
        /// </summary>
        private const string AppName = "测试应用";
        /// <summary>
        /// 成功
        /// </summary>
        private const string Success = "1";
        [DllImport(DllPath)]
        private extern static string KeyXZ(string cosKey,string appName,string keyNum);
        /// <summary>
        /// 新增秘钥
        /// </summary>
        /// <param name="keyNum">秘钥天数</param>
        /// <returns>新增的秘钥</returns>
        public static string KeyXz(string keyNum)
        {
            return KeyXZ(CosKey, AppName, keyNum);
        }
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
        private extern static string KeyJB(string cosKey, string appName, string key);
        /// <summary>
        /// 解绑秘钥
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <returns>是否成功</returns>
        public static bool KeyJb(string key)
        {
            return KeyJB(CosKey, AppName, key) == Success;
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
        private extern static string KeySC(string cosKey, string appName, string key);
        /// <summary>
        /// 删除秘钥
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <returns>是否成功</returns>
        public static bool KeySc(string key)
        {
            return KeySC(CosKey, AppName, key) == Success;
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
