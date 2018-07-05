using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TYPublicCore
{

    public class TyEncrypt
    {

        #region 天域不可破解加密

        public static string TyEnc(string strText)
        {
            return GetMD5_16(AesEncryptEcb(strText, "TYYX"));
        }
        #endregion

        #region DES对称加密解密

        /// <summary> 加密字符串
        /// </summary> 
        /// <param name="strText">需被加密的字符串</param> 
        /// <param name="strEncrKey">密钥</param> 
        /// <returns></returns> 
        public static string DesEncrypt(string strText, string strEncrKey)
        {
            try
            {
                byte[] iv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

                var byKey = Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
                var des = new DESCryptoServiceProvider();
                var inputByteArray = Encoding.UTF8.GetBytes(strText);
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, des.CreateEncryptor(byKey, iv), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                return "";
            }
        }

        /// <summary> 解密字符串
        /// </summary> 
        /// <param name="strText">需被解密的字符串</param> 
        /// <param name="sDecrKey">密钥</param> 
        /// <returns></returns> 
        public static string DesDecrypt(string strText, string sDecrKey)
        {
            try
            {
                byte[] iv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                var byKey = Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
                var des = new DESCryptoServiceProvider();
                var inputByteArray = Convert.FromBase64String(strText);
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, des.CreateDecryptor(byKey, iv), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = new UTF8Encoding();
                return encoding.GetString(ms.ToArray());
            }
            catch
            {
                return null;
            }
        }

        /// <summary> 加密文件
        ///
        /// </summary> 
        /// <param name="mInFilePath">原路径</param> 
        /// <param name="mOutFilePath">加密后的文件路径</param> 
        /// <param name="strEncrKey">密钥</param> 
        public static void DesEncryptFile(string mInFilePath, string mOutFilePath, string strEncrKey)
        {
            try
            {
                byte[] iv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

                var byKey = Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
                var fin = new FileStream(mInFilePath, FileMode.Open, FileAccess.Read);
                var fout = new FileStream(mOutFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                fout.SetLength(0);
                //Create variables to help with read and write. 
                var bin = new byte[100]; //This is intermediate storage for the encryption. 
                long rdlen = 0; //This is the total number of bytes written. 
                var totlen = fin.Length; //This is the total length of the input file. 

                DES des = new DESCryptoServiceProvider();
                var encStream = new CryptoStream(fout, des.CreateEncryptor(byKey, iv), CryptoStreamMode.Write);

                //Read from the input file, then encrypt and write to the output file. 
                while (rdlen < totlen)
                {
                    var len = fin.Read(bin, 0, 100); //This is the number of bytes to be written at a time.
                    encStream.Write(bin, 0, len);
                    rdlen = rdlen + len;
                }
                encStream.Close();
                fout.Close();
                fin.Close();
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }

        }

        /// <summary> 解密文件
        /// 
        /// </summary> 
        /// <param name="mInFilePath">被解密路径</param> 
        /// <param name="mOutFilePath">解密后的路径</param> 
        /// <param name="sDecrKey">密钥</param> 
        public static void DesDecryptFile(string mInFilePath, string mOutFilePath, string sDecrKey)
        {
            try
            {
                byte[] iv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

                var byKey = Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
                var fin = new FileStream(mInFilePath, FileMode.Open, FileAccess.Read);
                var fout = new FileStream(mOutFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                fout.SetLength(0);
                //Create variables to help with read and write. 
                var bin = new byte[100]; //This is intermediate storage for the encryption. 
                long rdlen = 0; //This is the total number of bytes written. 
                var totlen = fin.Length; //This is the total length of the input file. 

                DES des = new DESCryptoServiceProvider();
                var encStream = new CryptoStream(fout, des.CreateDecryptor(byKey, iv), CryptoStreamMode.Write);

                //Read from the input file, then encrypt and write to the output file. 
                while (rdlen < totlen)
                {
                    var len = fin.Read(bin, 0, 100); //This is the number of bytes to be written at a time.
                    encStream.Write(bin, 0, len);
                    rdlen = rdlen + len;
                }
                encStream.Close();
                fout.Close();
                fin.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        #endregion

        #region 3DES对称加密解密
        /// <summary>
        ///3DES加密
        /// </summary>
        /// <param name="originalValue">加密数据</param>
        /// <param name="key">24位字符的密钥字符串</param>
        /// <param name="iv">8位字符的初始化向量字符串</param>
        /// <returns></returns>
        public static string DesEncrypt(string originalValue, string key, string iv)
        {
            SymmetricAlgorithm sa = new TripleDESCryptoServiceProvider
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                Key = Encoding.UTF8.GetBytes(key),
                IV = Encoding.UTF8.GetBytes(iv)
            };
            var ct = sa.CreateEncryptor();
            var byt = Encoding.UTF8.GetBytes(originalValue);
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Convert.ToBase64String(ms.ToArray());
        }
        /// <summary>
        /// 3DES解密
        /// </summary>
        /// <param name="data">解密数据</param>
        /// <param name="key">24位字符的密钥字符串(需要和加密时相同)</param>
        /// <param name="iv">8位字符的初始化向量字符串(需要和加密时相同)</param>
        /// <returns></returns>
        public static string DesDecrypst(string data, string key, string iv)
        {
            SymmetricAlgorithm mCsp = new TripleDESCryptoServiceProvider
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                Key = Encoding.UTF8.GetBytes(key),
                IV = Encoding.UTF8.GetBytes(iv)
            };
            var ct = mCsp.CreateDecryptor(mCsp.Key, mCsp.IV);
            var byt = Convert.FromBase64String(data);
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Encoding.UTF8.GetString(ms.ToArray());
        }
        #endregion

        #region AES RijndaelManaged加密解密

        private const string DefaultAesKey = "@#kim123";

        private static readonly byte[] Keys = { 0x41, 0x72, 0x65, 0x79, 0x6F, 0x75, 0x6D, 0x79,
                                             0x53,0x6E, 0x6F, 0x77, 0x6D, 0x61, 0x6E, 0x3F };
        public static string AES_Encrypt(string encryptString)
        {
            return AES_Encrypt(encryptString, DefaultAesKey);
        }

        public static string AES_Decrypt(string decryptString)
        {
            return AES_Decrypt(decryptString, DefaultAesKey);
        }

        #region AES(CBC)有向量（IV）
        /// <summary>对称加密算法AES RijndaelManaged加密(RijndaelManaged（AES）算法是块式加密算法)
        /// 
        /// </summary>
        /// <param name="encryptString">待加密字符串</param>
        /// <param name="encryptKey">加密密钥，须半角字符</param>
        /// <returns>加密结果字符串</returns>
        public static string AES_Encrypt(string encryptString, string encryptKey)
        {
            encryptKey = GetSubString(encryptKey, 32, "");
            encryptKey = encryptKey.PadRight(32, ' ');

            var rijndaelProvider = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32)),
                IV = Keys
            };
            var rijndaelEncrypt = rijndaelProvider.CreateEncryptor();

            var inputData = Encoding.UTF8.GetBytes(encryptString);
            var encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);

            return Convert.ToBase64String(encryptedData);
        }

        /// <summary> 对称加密算法AES RijndaelManaged解密字符串
        ///
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串,失败返回空</returns>
        public static string AES_Decrypt(string decryptString, string decryptKey)
        {
            try
            {
                decryptKey = GetSubString(decryptKey, 32, "");
                decryptKey = decryptKey.PadRight(32, ' ');

                var rijndaelProvider = new RijndaelManaged
                {
                    Key = Encoding.UTF8.GetBytes(decryptKey),
                    IV = Keys
                };
                var rijndaelDecrypt = rijndaelProvider.CreateDecryptor();

                var inputData = Convert.FromBase64String(decryptString);
                var decryptedData = rijndaelDecrypt.TransformFinalBlock(inputData, 0, inputData.Length);

                return Encoding.UTF8.GetString(decryptedData);
            }
            catch
            {
                return string.Empty;
            }
        }
        #endregion

        #region AES(ECB)无向量（IV）
        /// <summary>  
        /// AES加密(无向量)  
        /// </summary>  
        /// <param name="encryptString">被加密的明文</param>  
        /// <param name="encryptKey">密钥 32 </param>  
        /// <returns>密文</returns>  
        public static string AesEncryptEcb(string encryptString, string encryptKey)
        {
            try
            {
                encryptKey = GetSubString(encryptKey, 32, "");
                encryptKey = encryptKey.PadRight(32, ' ');

                var rijndaelProvider = new RijndaelManaged
                {
                    Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 32)),
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                var rijndaelEncrypt = rijndaelProvider.CreateEncryptor();
                var inputData = Encoding.UTF8.GetBytes(encryptString);
                var encryptedData = rijndaelEncrypt.TransformFinalBlock(inputData, 0, inputData.Length);
                return Convert.ToBase64String(encryptedData);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>  
        /// AES解密(无向量)  
        /// </summary>  
        /// <param name="decryptString">被加密的明文</param>  
        /// <param name="decryptKey">密钥</param>  
        /// <returns>明文</returns>  
        public static string AesDecryptEcb(string decryptString, string decryptKey)
        {
            try
            {
                decryptKey = GetSubString(decryptKey, 32, "");
                decryptKey = decryptKey.PadRight(32, ' ');

                var rijndaelProvider = new RijndaelManaged
                {
                    Key = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 32)),
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                var rijndaelDecrypt = rijndaelProvider.CreateDecryptor();
                var inputData = Convert.FromBase64String(decryptString);
                var decryptedData = rijndaelDecrypt.TransformFinalBlock(inputData, 0, inputData.Length);
                return Encoding.UTF8.GetString(decryptedData);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion


        /// <summary>
        /// 按字节长度(按字节,一个汉字为2个字节)取得某字符串的一部分
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="length">所取字符串字节长度</param>
        /// <param name="tailString">附加字符串(当字符串不够长时，尾部所添加的字符串，一般为"...")</param>
        /// <returns>某字符串的一部分</returns>
        private static string GetSubString(string sourceString, int length, string tailString)
        {
            return GetSubString(sourceString, 0, length, tailString);
        }

        /// <summary>
        /// 按字节长度(按字节,一个汉字为2个字节)取得某字符串的一部分
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="startIndex">索引位置，以0开始</param>
        /// <param name="length">所取字符串字节长度</param>
        /// <param name="tailString">附加字符串(当字符串不够长时，尾部所添加的字符串，一般为"...")</param>
        /// <returns>某字符串的一部分</returns>
        private static string GetSubString(string sourceString, int startIndex, int length, string tailString)
        {
            //当是日文或韩文时(注:中文的范围:\u4e00 - \u9fa5, 日文在\u0800 - \u4e00, 韩文为\xAC00-\xD7A3)
            if (System.Text.RegularExpressions.Regex.IsMatch(sourceString, "[\u0800-\u4e00]+") ||
                System.Text.RegularExpressions.Regex.IsMatch(sourceString, "[\xAC00-\xD7A3]+"))
            {
                //当截取的起始位置超出字段串长度时
                if (startIndex >= sourceString.Length)
                {
                    return string.Empty;
                }
                else
                {
                    return sourceString.Substring(startIndex,
                                                   ((length + startIndex) > sourceString.Length) ? (sourceString.Length - startIndex) : length);
                }
            }

            //中文字符，如"中国人民abcd123"
            if (length <= 0)
            {
                return string.Empty;
            }
            var bytesSource = Encoding.Default.GetBytes(sourceString);

            //当字符串长度大于起始位置
            if (bytesSource.Length > startIndex)
            {
                var endIndex = bytesSource.Length;

                //当要截取的长度在字符串的有效长度范围内
                if (bytesSource.Length > (startIndex + length))
                {
                    endIndex = length + startIndex;
                }
                else
                {   //当不在有效范围内时,只取到字符串的结尾
                    length = bytesSource.Length - startIndex;
                    tailString = "";
                }

                var anResultFlag = new int[length];
                var nFlag = 0;
                //字节大于127为双字节字符
                for (var i = startIndex; i < endIndex; i++)
                {
                    if (bytesSource[i] > 127)
                    {
                        nFlag++;
                        if (nFlag == 3)
                        {
                            nFlag = 1;
                        }
                    }
                    else
                    {
                        nFlag = 0;
                    }
                    anResultFlag[i] = nFlag;
                }
                //最后一个字节为双字节字符的一半
                if ((bytesSource[endIndex - 1] > 127) && (anResultFlag[length - 1] == 1))
                {
                    length = length + 1;
                }

                var bsResult = new byte[length];
                Array.Copy(bytesSource, startIndex, bsResult, 0, length);
                var myResult = Encoding.Default.GetString(bsResult);
                myResult = myResult + tailString;

                return myResult;
            }

            return string.Empty;

        }

        /// <summary>
        /// 加密文件流
        /// </summary>
        /// <param name="fs">文件流</param>
        /// <param name="decryptKey">秘钥</param>
        /// <returns></returns>
        public static CryptoStream AES_EncryptStrream(FileStream fs, string decryptKey)
        {
            decryptKey = GetSubString(decryptKey, 32, "");
            decryptKey = decryptKey.PadRight(32, ' ');

            var rijndaelProvider = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(decryptKey),
                IV = Keys
            };

            var encrypto = rijndaelProvider.CreateEncryptor();
            var cytptostreamEncr = new CryptoStream(fs, encrypto, CryptoStreamMode.Write);
            return cytptostreamEncr;
        }

        /// <summary>
        /// 解密文件流
        /// </summary>
        /// <param name="fs">文件流</param>
        /// <param name="decryptKey">秘钥</param>
        /// <returns></returns>
        public static CryptoStream AES_DecryptStream(FileStream fs, string decryptKey)
        {
            decryptKey = GetSubString(decryptKey, 32, "");
            decryptKey = decryptKey.PadRight(32, ' ');

            var rijndaelProvider = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(decryptKey),
                IV = Keys
            };
            var decrypto = rijndaelProvider.CreateDecryptor();
            var cytptostreamDecr = new CryptoStream(fs, decrypto, CryptoStreamMode.Read);
            return cytptostreamDecr;
        }

        /// <summary>
        /// 对指定文件加密
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        /// <returns></returns>
        public static bool AES_EncryptFile(string inputFile, string outputFile)
        {
            try
            {
                var decryptKey = "www.iqidi.com";

                var fr = new FileStream(inputFile, FileMode.Open);
                var fren = new FileStream(outputFile, FileMode.Create);
                var enfr = AES_EncryptStrream(fren, decryptKey);
                var bytearrayinput = new byte[fr.Length];
                fr.Read(bytearrayinput, 0, bytearrayinput.Length);
                enfr.Write(bytearrayinput, 0, bytearrayinput.Length);
                enfr.Close();
                fr.Close();
                fren.Close();
            }
            catch
            {
                //文件异常
                return false;
            }
            return true;
        }

        /// <summary>
        /// 对指定的文件解压缩
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        /// <returns></returns>
        public static bool AES_DecryptFile(string inputFile, string outputFile)
        {
            try
            {
                var decryptKey = "www.iqidi.com";
                var fr = new FileStream(inputFile, FileMode.Open);
                var frde = new FileStream(outputFile, FileMode.Create);
                var defr = AES_DecryptStream(fr, decryptKey);
                var bytearrayoutput = new byte[1024];

                do
                {
                    var mCount = defr.Read(bytearrayoutput, 0, bytearrayoutput.Length);
                    frde.Write(bytearrayoutput, 0, mCount);
                    if (mCount < bytearrayoutput.Length)
                        break;
                } while (true);

                defr.Close();
                fr.Close();
                frde.Close();
            }
            catch
            {
                //文件异常
                return false;
            }
            return true;
        }

        #endregion

        #region RSA加密 解密

        /// <summary>RSA加密
        /// 
        /// </summary>
        /// <param name="plaintext">明文</param>
        /// <param name="publicKey">公钥</param>
        /// <returns>密文字符串</returns>
        public static string EncryptByRsa(string plaintext, string publicKey)
        {
            try
            {
                var byteConverter = new UnicodeEncoding();
                var dataToEncrypt = byteConverter.GetBytes(plaintext);
                using (var rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(publicKey);
                    var encryptedData = rsa.Encrypt(dataToEncrypt, false);
                    return Convert.ToBase64String(encryptedData);
                }
            }
            catch (Exception)
            {
                return null;
            }

        }


        /// <summary> RSA解密
        ///
        /// </summary>
        /// <param name="ciphertext">密文</param>
        /// <param name="privateKey">私钥</param>
        /// <returns>明文字符串</returns>
        public static string DecryptByRsa(string ciphertext, string privateKey)
        {
            try
            {
                var byteConverter = new UnicodeEncoding();
                using (var rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(privateKey);
                    var encryptedData = Convert.FromBase64String(ciphertext);
                    var decryptedData = rsa.Decrypt(encryptedData, false);
                    return byteConverter.GetString(decryptedData);
                }
            }
            catch (Exception)
            {
                return null;
            }

        }


        /// <summary>生成RSA加密 解密的 密钥
        /// 生成的key就是 方法EncryptByRSA与DecryptByRSA用的key了
        /// </summary>
        /// <param name="path">要生成的密钥文件的路径(文件夹)</param>
        public static void GetRsaKey(string path)
        {
            var rsa = new RSACryptoServiceProvider();
            var datetimestr = DateTime.Now.ToString("yyyyMMddHHmmss");
            using (var writer = new StreamWriter("RSA解密_PrivateKey_" + datetimestr + ".xml"))  //这个文件要保密...
            {
                writer.WriteLine(rsa.ToXmlString(true));
            }
            using (var writer = new StreamWriter("RSA加密_PublicKey_" + datetimestr + ".xml"))
            {
                writer.WriteLine(rsa.ToXmlString(false));
            }
        }
        #endregion

        #region Base64加密解密

        /// <summary>
        /// Base64是一種使用64基的位置計數法。它使用2的最大次方來代表僅可列印的ASCII 字元。
        /// 這使它可用來作為電子郵件的傳輸編碼。在Base64中的變數使用字元A-Z、a-z和0-9 ，
        /// 這樣共有62個字元，用來作為開始的64個數字，最後兩個用來作為數字的符號在不同的
        /// 系統中而不同。
        /// Base64加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64Encrypt(string str)
        {
            var encbuff = Encoding.UTF8.GetBytes(str);
            return Convert.ToBase64String(encbuff);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64Decrypt(string str)
        {
            var decbuff = Convert.FromBase64String(str);
            return Encoding.UTF8.GetString(decbuff);
        }
        #endregion

        #region MD5
        /// <summary>

        /// 获得32位的MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMD5_32(string input)
        {
            var md5 = MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(input));
            var sb = new StringBuilder();
            foreach (var t in data)
            {
                sb.AppendFormat("{0:X2}", t);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获得16位的MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMD5_16(string input)
        {
            return GetMD5_32(input).Substring(8, 16);
        }
        /// <summary>
        /// 获得8位的MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMD5_8(string input)
        {
            return GetMD5_32(input).Substring(8, 8);
        }
        /// <summary>
        /// 获得4位的MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMD5_4(string input)
        {
            return GetMD5_32(input).Substring(8, 4);
        }

        public static string Md5EncryptHash(String input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            //the GetBytes method returns byte array equavalent of a string
            var res = md5.ComputeHash(Encoding.Default.GetBytes(input), 0, input.Length);
            var temp = new char[res.Length];
            //copy to a char array which can be passed to a String constructor
            Array.Copy(res, temp, res.Length);
            //return the result as a string
            return new String(temp);
        }
        #endregion

        #region MD5签名验证

        /// <summary>
        /// 对给定文件路径的文件加上标签
        /// </summary>
        /// <param name="path">要加密的文件的路径</param>
        /// <returns>标签的值</returns>
        public static bool AddMd5(string path)
        {
            var isNeed = !CheckMd5(path);
            try
            {
                var fsread = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                var md5File = new byte[fsread.Length];
                fsread.Read(md5File, 0, (int)fsread.Length);                               // 将文件流读取到Buffer中
                fsread.Close();
                if (isNeed)
                {
                    var result = Md5Buffer(md5File, 0, md5File.Length);             // 对Buffer中的字节内容算MD5
                    var md5 = Encoding.ASCII.GetBytes(result);       // 将字符串转换成字节数组以便写人到文件中
                    var fsWrite = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                    fsWrite.Write(md5File, 0, md5File.Length);                               // 将文件，MD5值 重新写入到文件中。
                    fsWrite.Write(md5, 0, md5.Length);
                    fsWrite.Close();
                }
                else
                {
                    var fsWrite = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                    fsWrite.Write(md5File, 0, md5File.Length);
                    fsWrite.Close();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 对给定路径的文件进行验证
        /// </summary>
        /// <param name="path"></param>
        /// <returns>是否加了标签或是否标签值与内容值一致</returns>
        public static bool CheckMd5(string path)
        {
            try
            {
                var getFile = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                var md5File = new byte[getFile.Length];                                      // 读入文件
                getFile.Read(md5File, 0, (int)getFile.Length);
                getFile.Close();

                var result = Md5Buffer(md5File, 0, md5File.Length - 32);             // 对文件除最后32位以外的字节计算MD5，这个32是因为标签位为32位。
                var md5 = Encoding.ASCII.GetString(md5File, md5File.Length - 32, 32);   //读取文件最后32位，其中保存的就是MD5值
                return result == md5;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 计算文件的MD5值
        /// </summary>
        /// <param name="md5File">MD5签名文件字符数组</param>
        /// <param name="index">计算起始位置</param>
        /// <param name="count">计算终止位置</param>
        /// <returns>计算结果</returns>
        private static string Md5Buffer(byte[] md5File, int index, int count)
        {
            var getMd5 = new MD5CryptoServiceProvider();
            var hashByte = getMd5.ComputeHash(md5File, index, count);
            var result = BitConverter.ToString(hashByte);

            result = result.Replace("-", "");
            return result;
        }
        #endregion

        #region  SHA256加密算法


        /// <summary>
        /// SHA256函数
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>SHA256结果(返回长度为44字节的字符串)</returns>
        public static string Sha256(string str)
        {
            var sha256Data = Encoding.UTF8.GetBytes(str);
            var sha256 = new SHA256Managed();
            var result = sha256.ComputeHash(sha256Data);
            return Convert.ToBase64String(result);  //返回长度为44字节的字符串
        }
        #endregion

        #region RC4加密 解密

        /// <summary>RC4加密算法
        /// 返回进过rc4加密过的字符
        /// </summary>
        /// <param name="str">被加密的字符</param>
        /// <param name="ckey">密钥</param>
        public static string EncryptRc4Wq(string str, string ckey)
        {
            var s = new int[256];
            for (var i = 0; i < 256; i++)
            {
                s[i] = i;
            }
            //密钥转数组
            var keys = ckey.ToCharArray();//密钥转字符数组
            var key = new int[keys.Length];
            for (var i = 0; i < keys.Length; i++)
            {
                key[i] = keys[i];
            }
            //明文转数组
            var datas = str.ToCharArray();
            var mingwen = new int[datas.Length];
            for (var i = 0; i < datas.Length; i++)
            {
                mingwen[i] = datas[i];
            }

            //通过循环得到256位的数组(密钥)
            var j = 0;
            var k = 0;
            var length = key.Length;
            for (var i = 0; i < 256; i++)
            {
                var a = s[i];
                j = (j + a + key[k]);
                if (j >= 256)
                {
                    j = j % 256;
                }
                s[i] = s[j];
                s[j] = a;
                if (++k >= length)
                {
                    k = 0;
                }
            }
            //根据上面的256的密钥数组 和 明文得到密文数组
            int x = 0, y = 0;
            var length2 = mingwen.Length;
            var miwen = new int[length2];
            for (var i = 0; i < length2; i++)
            {
                x = x + 1;
                x = x % 256;
                var a2 = s[x];
                y = y + a2;
                y = y % 256;
                int b;
                s[x] = b = s[y];
                s[y] = a2;
                var c = a2 + b;
                c = c % 256;
                miwen[i] = mingwen[i] ^ s[c];
            }
            //密文数组转密文字符
            var mi = new char[miwen.Length];
            for (var i = 0; i < miwen.Length; i++)
            {
                mi[i] = (char)miwen[i];
            }
            var miwenstr = new string(mi);
            return miwenstr;
        }

        /// <summary>RC4解密算法
        /// 返回进过rc4解密过的字符
        /// </summary>
        /// <param name="str">被解密的字符</param>
        /// <param name="ckey">密钥</param>
        public static string DecryptRc4Wq(string str, string ckey)
        {
            var s = new int[256];
            for (var i = 0; i < 256; i++)
            {
                s[i] = i;
            }
            //密钥转数组
            var keys = ckey.ToCharArray();//密钥转字符数组
            var key = new int[keys.Length];
            for (var i = 0; i < keys.Length; i++)
            {
                key[i] = keys[i];
            }
            //密文转数组
            var datas = str.ToCharArray();
            var miwen = new int[datas.Length];
            for (var i = 0; i < datas.Length; i++)
            {
                miwen[i] = datas[i];
            }

            //通过循环得到256位的数组(密钥)
            var j = 0;
            var k = 0;
            var length = key.Length;
            for (var i = 0; i < 256; i++)
            {
                var a = s[i];
                j = j + a + key[k];
                if (j >= 256)
                {
                    j = j % 256;
                }
                s[i] = s[j];
                s[j] = a;
                if (++k >= length)
                {
                    k = 0;
                }
            }
            //根据上面的256的密钥数组 和 密文得到明文数组
            int x = 0, y = 0;
            var length2 = miwen.Length;
            var mingwen = new int[length2];
            for (var i = 0; i < length2; i++)
            {
                x = x + 1;
                x = x % 256;
                var a2 = s[x];
                y = y + a2;
                y = y % 256;
                int b;
                s[x] = b = s[y];
                s[y] = a2;
                var c = a2 + b;
                c = c % 256;
                mingwen[i] = miwen[i] ^ s[c];
            }
            //明文数组转明文字符
            var ming = new char[mingwen.Length];
            for (var i = 0; i < mingwen.Length; i++)
            {
                ming[i] = (char)mingwen[i];
            }
            var mingwenstr = new string(ming);
            return mingwenstr;
        }
        #endregion
    }
}