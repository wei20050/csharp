using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.SqlServer.Server;

namespace CosAdmin
{
    public class Cos
    {

        #region 基本配置

        /// <summary>
        /// 动态库路径
        /// </summary>
        private const string DllPath = "cos.dll";

        /// <summary>
        /// cos连接秘钥
        /// </summary>
        private const string CosKey = "0C800F07C0F50E404804808902603702F07E0EF0530500290140C60E10050EE04F0170700480AC0520990F40870EB0A30CC0430CC0AF00303902303404D0C00F90EC0FF0C901D0430CE0DC0EC00D0AF01507E05E0A90090B50930EE0170ED08B08403604D07007105803C0F80F90D501503D0720330D60BE0D00020910930F808B0040DC01701307B0D70300EF0380EE07808004309802807F0E20570720890C20B10B501503402007606C0CB0DD0DA0790830D8";

        /// <summary>
        /// 成功
        /// </summary>
        private const string Success = "1";

        #endregion

        #region 构造不同的应用

        /// <summary>
        /// 应用名称
        /// </summary>
        private readonly string _appName;

        public Cos()
        {
            _appName = "默认应用";
        }

        public Cos(string appName)
        {
            _appName = appName;
        }

        #endregion

        #region dll引入
        [DllImport(DllPath)]
        private static extern string Insert(string cosKey, string key, string value);
        [DllImport(DllPath)]
        private static extern string Delete(string cosKey, string key);
        [DllImport(DllPath)]
        private static extern string Find(string cosKey, string key);
        [DllImport(DllPath)]
        private static extern string KeyXZ(string cosKey, string appName, string keyNum);
        [DllImport(DllPath)]
        private static extern string KeyYZ(string cosKey, string appName, string key, string dn);
        [DllImport(DllPath)]
        private static extern string KeyJB(string cosKey, string appName, string key);
        [DllImport(DllPath)]
        private static extern string KeyCZ(string cosKey, string appName, string key, string keyNum);
        [DllImport(DllPath)]
        private static extern string KeySC(string cosKey, string appName, string key);
        [DllImport(DllPath)]
        private static extern string KeySet(string cosKey, string appName, string key, string path);
        [DllImport(DllPath)]
        private static extern string KeyGet(string cosKey, string appName, string key, string path);
        [DllImport(DllPath)]
        private static extern string KeyCX(string cosKey, string appName, string key);
        [DllImport(DllPath)]
        private static extern string JlXZ(string cosKey, string appName, string key, string skey, string type);
        [DllImport(DllPath)]
        private static extern string JlCX(string cosKey, string appName, string key);
        [DllImport(DllPath)]
        private static extern void KeyLOG(string content, string isErr);
        [DllImport(DllPath)]
        private static extern string Encrypt(string content, string key);
        [DllImport(DllPath)]
        private static extern string Decrypt(string content, string key);
        [DllImport(DllPath)]
        private static extern string KeyFB(string key);
        [DllImport(DllPath)]
        private static extern string KeyKB(string key);

        #endregion

        #region 基本功能
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="key">数据名称</param>
        /// <param name="value">数据值</param>
        /// <returns>新增的秘钥</returns>
        public bool Insert(string key,string value)
        {
            return Insert(CosKey, key, value) == Success;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="key">数据名称</param>
        /// <returns>新增的秘钥</returns>
        public bool Delete(string key)
        {
            return Delete(CosKey, key) == Success;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="key">数据名称</param>
        /// <returns>新增的秘钥</returns>
        public string Find(string key)
        {
            return Find(CosKey, key);
        }

        #endregion

        #region 验证相关

        /// <summary>
        /// 新增秘钥
        /// </summary>
        /// <param name="keyNum">秘钥天数</param>
        /// <returns>新增的秘钥</returns>
        public string KeyXz(string keyNum)
        {
            return KeyXZ(CosKey, _appName, keyNum);
        }

        /// <summary>
        /// 验证秘钥
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="dn">电脑机器码</param>
        /// <returns>是否成功</returns>
        public bool KeyYz(string key, string dn)
        {
            return KeyYZ(CosKey, _appName, key, dn) == Success;
        }

        /// <summary>
        /// 解绑秘钥
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <returns>是否成功</returns>
        public bool KeyJb(string key)
        {
            return KeyJB(CosKey, _appName, key) == Success;
        }

        /// <summary>
        /// 给秘钥充值
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="keyNum">充值天数</param>
        /// <returns>是否成功</returns>
        public bool KeyCz(string key, string keyNum)
        {
            return KeyCZ(CosKey, _appName, key, keyNum) == Success;
        }


        /// <summary>
        /// 删除秘钥
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <returns>是否成功</returns>
        public bool KeySc(string key)
        {
            return KeySC(CosKey, _appName, key) == Success;
        }


        /// <summary>
        /// 根据秘钥写文本文件到服务器
        /// </summary>
        /// <param name="key">秘钥</param>
        /// <param name="path">文本文件路径</param>
        /// <returns>是否成功</returns>
        public bool KeySet(string key, string path)
        {
            return KeySet(CosKey, _appName, key, path) == Success;
        }


        /// <summary>
        /// 根据秘钥读文本文件到本地
        /// </summary>
        /// <param name="key">取文件的秘钥</param>
        /// <param name="path">存到的文件路径</param>
        /// <returns>是否成功</returns>
        public bool KeyGet(string key, string path)
        {
            return KeyGet(CosKey, _appName, key, path) == Success;
        }


        /// <summary>
        /// 查询key
        /// </summary>
        /// <param name="key">为空则查询所有 否则查询单条</param>
        /// <returns>查询到的数据 没有匹配数据返回空字符串</returns>
        public string KeyCx(string key)
        {
            return KeyCX(CosKey, _appName, key);
        }

        /// <summary>
        /// 记录新增
        /// </summary>
        /// <param name="key">当前记录key</param>
        /// <param name="skey">操作人的key</param>
        /// <param name="type">操作类型</param>
        /// <returns>查询到的数据 没有匹配数据返回空字符串</returns>
        public string JlXz(string key,string skey,string type)
        {
            return JlXZ(CosKey, _appName, key, skey,type);
        }

        /// <summary>
        /// 记录查询
        /// </summary>
        /// <param name="key">为空则查询所有 否则查询单条</param>
        /// <returns>查询到的数据 没有匹配数据返回空字符串</returns>
        public string JlCx(string key)
        {
            return JlCX(CosKey, _appName, key);
        }

        #endregion

        #region 杂项

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="content">日志类容</param>
        /// <param name="isErr">是否是错误日志默认不是错误日志</param>
        public void KeyLog(string content, string isErr = Success)
        {
            KeyLOG(content, isErr);
        }

        /// <summary>
        /// 加密文本
        /// </summary>
        /// <param name="content">待加密的文本</param>
        /// <param name="key">秘钥</param>
        /// <returns>加密后的文本</returns>
        public string KeyEncrypt(string content, string key)
        {
            return Encrypt(content, key);
        }

        /// <summary>
        /// 解密文本
        /// </summary>
        /// <param name="content">密文</param>
        /// <param name="key">秘钥</param>
        /// <returns>解密后的文本</returns>
        public string KeyDecrypt(string content, string key)
        {
            return Decrypt(content, key);
        }
        /// <summary>
        /// 把key 封装成 (YX)key(YX)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string KeyFb(string key)
        {
            return KeyFB(key);
        }
        /// <summary>
        /// 把(YX)key(YX) 打开成 key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string KeyKb(string key)
        {
            return KeyKB(key);
        }
        /// <summary>
        /// 字符串数据转密钥对象
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public CKey Str2Key(string str)
        {
            var tmpStr = str.Replace($@"{_appName}/", "");
            if (str == string.Empty || tmpStr == string.Empty)
            {
                return null;
            }
            var arrStr = tmpStr.Split(new[]{"|,|"},StringSplitOptions.None);
            CKey key = new CKey
            {
                Key = KeyKB(arrStr[0]),
                Num = KeyKB(arrStr[1]),
                EndTime = KeyKB(arrStr[2]),
                RegTime = KeyKB(arrStr[3]),
                UpdTime = KeyKB(arrStr[4]),
                Dn = KeyKB(arrStr[5])
            };
            return key;
        }
        /// <summary>
        /// 字符串数据转密钥对象List
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<CKey> Str2KeyList(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            var arrStr = str.Split(new[] { "|_|" }, StringSplitOptions.None);
            var keyList = arrStr.Select(Str2Key).ToList();
            keyList.Sort();
            return keyList;
        }
        /// <summary>
        /// 字符串数据转记录对象
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public CJl Str2Jl(string str)
        {
            var tmpStr = str.Replace($@"记录/{_appName}/", "");
            if (str == string.Empty || tmpStr == string.Empty)
            {
                return null;
            }
            var arrStr = tmpStr.Split(new[] { "|,|" }, StringSplitOptions.None);
            CJl jl = new CJl
            {
                Key = KeyKB(arrStr[0]),
                SKey = KeyKB(arrStr[1]),
                Time = KeyKB(arrStr[2]),
                Type = KeyKB(arrStr[3])
            };
            return jl;
        }
        /// <summary>
        /// 字符串数据转密钥对象List
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<CJl> Str2JlList(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            var arrStr = str.Split(new[] { "|_|" }, StringSplitOptions.None);
            var jlList = arrStr.Select(Str2Jl).ToList();
            jlList.Sort();
            return jlList;
        }
        #endregion
    }

    public class CKey : IComparable<CKey>
    {
        public string Key { get; set; }
        public string Num { get; set; }
        public string EndTime { get; set; }
        public string RegTime { get; set; }
        public string UpdTime { get; set; }
        public string Dn { get; set; }
        public int CompareTo(CKey other)
        {
            return null == other ? 1 : string.Compare(other.UpdTime, UpdTime, StringComparison.Ordinal);
        }
    }

    public class CJl : IComparable<CJl>
    {
        public string Key { get; set; }
        public string SKey { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public int CompareTo(CJl other)
        {
            return null == other ? 1 : string.Compare(other.Time, Time, StringComparison.Ordinal);
        }
    }
}
