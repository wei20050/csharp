using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace yx
{
    public class DmSoftEx
    {
        #region 大漠收费方法实现

        #region RunApp

        internal static int RunApp(string path)
        {
            try
            {
                System.Diagnostics.Process.Start(path);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        #endregion

        #region Delay

        internal static void Delay(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

        #endregion

        #region KeyPressStr

        [DllImport("user32.dll", CharSet = CharSet.Auto,ExactSpelling = true,CallingConvention = CallingConvention.Winapi)]
        private static extern short GetKeyState(int keyCode);

        internal static int KeyPressStr(string keyStr, int iszs = 0, int delay = 6)
        {
            try
            {
                var dm = new DmSoft();
                var isCapsLock = (((ushort)GetKeyState(0x14)) & 0xffff) != 0;
                if (isCapsLock)
                {
                    dm.KeyPress(20);
                }
                foreach (var chr in keyStr)
                {
                    if (char.IsUpper(chr))
                    {
                        dm.KeyPress(20);
                        dm.Delay(6);
                        dm.KeyPressChar(chr.ToString());
                        dm.Delay(6);
                        dm.KeyPress(20);
                    }
                    else
                    {
                        dm.KeyPressChar(chr.ToString());
                    }
                    dm.Delay(iszs == 0 ? delay : new Random().Next(1 + delay, 100 + delay));
                }
                if (isCapsLock)
                {
                    dm.KeyPress(20);
                }
            }
            catch
            {
                return 0;
            }
            return 1;
        }

        #endregion

        #region ReadIniPwd

        internal static string ReadIniPwd(string section, string key, string file, string pwd)
        {
            var dm = new DmSoft();
            return AesDecrypt(AesDecrypt(dm.ReadIni(AesEncrypt(AesEncrypt(section, pwd), "TYYXPWD"), AesEncrypt(AesEncrypt(key, pwd), "TYYXPWD").Replace("=", string.Empty), file), "TYYXPWD"), pwd);
        }

        #endregion

        #region WriteIniPwd

        internal static int WriteIniPwd(string section, string key, string v, string file, string pwd)
        {
            var dm = new DmSoft();
            return dm.WriteIni(AesEncrypt(AesEncrypt(section, pwd), "TYYXPWD"), AesEncrypt(AesEncrypt(key, pwd), "TYYXPWD").Replace("=", string.Empty), AesEncrypt(AesEncrypt(v, pwd), "TYYXPWD"), file);
        }

        #endregion

        #region DeleteIniPwd

        internal static int DeleteIniPwd(string section, string key, string file, string pwd)
        {
            var dm = new DmSoft();
            return dm.DeleteIni(AesEncrypt(AesEncrypt(section, pwd), "TYYXPWD"), AesEncrypt(AesEncrypt(key, pwd), "TYYXPWD").Replace("=", string.Empty), file);
        }

        #endregion

        #endregion 大漠收费方法实现


        #region 扩展功能

        /// <summary>  
        /// AES加密
        /// </summary>  
        /// <param name="data">要加密的明文</param>  
        /// <param name="key">密钥</param>  
        /// <returns>密文</returns>
        public static string AesEncrypt(string data, string key)
        {
            if (string.IsNullOrEmpty(data)) return string.Empty;
            MemoryStream mStream = new MemoryStream();
            RijndaelManaged aes = new RijndaelManaged();

            var plainBytes = Encoding.UTF8.GetBytes(data);
            var bKey = new byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(key.PadRight(bKey.Length)), bKey, bKey.Length);

            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;
            aes.Key = bKey;
            CryptoStream cryptoStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
            try
            {
                cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            finally
            {
                cryptoStream.Close();
                mStream.Close();
                aes.Clear();
            }
        }


        /// <summary>  
        /// AES解密
        /// </summary>  
        /// <param name="data">被加密的明文</param>  
        /// <param name="key">密钥</param>  
        /// <returns>明文</returns>  
        public static string AesDecrypt(string data, string key)
        {
            if (string.IsNullOrEmpty(data)) return string.Empty;
            var encryptedBytes = Convert.FromBase64String(data);
            var bKey = new byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(key.PadRight(bKey.Length)), bKey, bKey.Length);

            MemoryStream mStream = new MemoryStream(encryptedBytes);
            RijndaelManaged aes = new RijndaelManaged
            {
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                Key = bKey
            };
            CryptoStream cryptoStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Read);
            try
            {
                var tmp = new byte[encryptedBytes.Length + 32];
                var len = cryptoStream.Read(tmp, 0, encryptedBytes.Length + 32);
                var ret = new byte[len];
                Array.Copy(tmp, 0, ret, 0, len);
                return Encoding.UTF8.GetString(ret);
            }
            finally
            {
                cryptoStream.Close();
                mStream.Close();
                aes.Clear();
            }
        }

        #endregion 扩展功能
    }
}
