using System.IO;
using System.ServiceModel;

namespace TYExServiceCore
{
    [ServiceContract]
    public interface ITyService
    {
        //执行服务器方法
        [OperationContract]
        string Fun(string functionName, string json);
        //上传文件
        [OperationContract]
        UpFileResult UpLoadFile(UpFile filestream);

        //下载文件
        [OperationContract]
        DownFileResult DownLoadFile(DownFile downfile);
    }
    [MessageContract]
    public class DownFile
    {
        [MessageHeader]
        public string FileName { get; set; }
        [MessageHeader]
        public string FilePath { get; set; }
    }

    [MessageContract]
    public class UpFileResult
    {
        [MessageHeader]
        public bool IsSuccess { get; set; }
        [MessageHeader]
        public string Message { get; set; }
    }

    [MessageContract]
    public class UpFile
    {
        [MessageHeader]
        public long FileSize { get; set; }
        [MessageHeader]
        public string FileName { get; set; }
        [MessageHeader]
        public string FilePath { get; set; }
        [MessageBodyMember]
        public Stream FileStream { get; set; }
    }

    [MessageContract]
    public class DownFileResult
    {
        [MessageHeader]
        public long FileSize { get; set; }
        [MessageHeader]
        public bool IsSuccess { get; set; }
        [MessageHeader]
        public string Message { get; set; }
        [MessageBodyMember]
        public Stream FileStream { get; set; }
    }
}
