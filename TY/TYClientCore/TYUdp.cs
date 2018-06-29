using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TYPublicCore;

namespace TYClientCore
{
    public class TyUdp
    {
        #region 基本定义与系统方法
        private static TyUdp _udp;//本类对象
        private static readonly object Locker = new object();//多线程锁
        private readonly UdpClient _client;//udp对象
        public IPAddress ServiceIp = IPAddress.Broadcast;//服务器IP
        private const string BroadcastMsg = "825C7B29-5B62-4242-AF76-EBDB489A6090";
        //私有构造实现单例模式
        private TyUdp()
        {
            _client = new UdpClient
            {
                Client = { ReceiveTimeout = 1000 },
                EnableBroadcast = true
            };
        }
        //获取当前对象的公共方法
        public static TyUdp Getudp()
        {
            if (_udp != null) return _udp;
            lock (Locker)
            {
                if (_udp == null)
                {
                    // ReSharper disable once PossibleMultipleWriteAccessInDoubleCheckLocking
                    _udp = new TyUdp();
                }
            }
            return _udp;
        }
        //打开服务器连接 获取地址
        public bool OpenService()
        {
            if (!Send($"{BroadcastMsg}|GetServiceIp", out var refData, out ServiceIp)) return false;
            if (refData != "true") return false;
            _client.Client.ReceiveTimeout = 1000;
            return true;
        }

        //发送消息到服务器接收反馈
        private bool Send(string message,out string refData, out IPAddress ip)
        {
            try
            {
                var requestData = Encoding.UTF8.GetBytes(message);
                _client.Send(requestData, requestData.Length, new IPEndPoint(ServiceIp, 2875));
                var serverEp = new IPEndPoint(IPAddress.Broadcast, 0);
                var serverResponseData = _client.Receive(ref serverEp);
                ip = serverEp.Address;
                refData = Encoding.UTF8.GetString(serverResponseData);
                return true;
            }
            catch (Exception ex)
            {
                TyLog.Wlog(ex);
                ip = IPAddress.Broadcast;
                refData = ex.ToString();
                return false;
            }
        }
        //关闭客户端
        public void CloseClient()
        {
            _client?.Close();
        }
        #endregion

        #region 接口

        /// <summary>
        /// 主要与服务器端沟通的函数
        /// </summary>
        /// <param name="functionName">方法名</param>
        /// <param name="json">数据json</param>
        /// <param name="refData">返回的数据</param>
        /// <returns>服务器返回的json</returns>
        public bool Fun(string functionName, string json, out string refData)
        {
            refData = "服务器连接失败!";
            if (!Send($"{BroadcastMsg}|{functionName}|{json}", out var refDatas, out var serverEp)) return false;
            if (!serverEp.Equals(IPAddress.Broadcast) && ServiceIp.Equals(IPAddress.Broadcast))ServiceIp = serverEp;
            var tmp = refDatas.Split('|');
            if (tmp.Length != 2) return false;
            refData = tmp[1];
            return !tmp[0].Equals("0");
        }
        #endregion

    }
}
