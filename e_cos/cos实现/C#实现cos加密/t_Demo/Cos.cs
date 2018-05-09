using System.Runtime.InteropServices;
namespace t_Demo
{
    public static class Cos
    {
        /// <summary>
        /// 动态库路径
        /// </summary>
        private const string DllPath = "cosuser.dll";
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
