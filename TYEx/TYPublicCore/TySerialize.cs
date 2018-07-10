using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TYPublicCore
{
    public class TySerialize
    {
        /// <summary>
        /// 序列化
        /// </summary>
        public static byte[] Serialize(object obj)
        {
            var binaryFormatter = new BinaryFormatter();
            var ms = new MemoryStream();
            binaryFormatter.Serialize(ms, obj ?? string.Empty);
            return ms.ToArray();
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        public static object Deserialize(byte[] bArr)
        {
            var binaryFormatter = new BinaryFormatter();
            var ms = new MemoryStream(bArr);
            return binaryFormatter.Deserialize(ms);
        }
    }
}
