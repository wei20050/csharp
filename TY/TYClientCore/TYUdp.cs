using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TYClientCore
{
    public class TYUdp
    {
        #region 基本定义与系统方法
        private static TYUdp udp = null;//本类对象
        private static readonly object locker = new object();//多线程锁
        private UdpClient client;//udp对象
        public IPAddress serviceIp = IPAddress.Broadcast;//服务器IP
        const string ServerAddressBroadcastMsg = "825C7B29-5B62-4242-AF76-EBDB489A6090";
        //私有构造实现单例模式
        private TYUdp()
        {
            client = new UdpClient
            {
                Client = { ReceiveTimeout = 1000 },
                EnableBroadcast = true
            };
            if (serviceIp == IPAddress.Broadcast)
            {
                DetectServiceAddress();
            }
        }
        //获取当前对象的公共方法
        public static TYUdp Getudp()
        {
            if (udp == null)
            {
                lock (locker)
                {
                    if (udp == null)
                    {
                        udp = new TYUdp();
                    }
                }
            }
            return udp;
        }
        //获取服务器地址(连接服务器)
        private string DetectServiceAddress()
        {
            if (Send($"{ServerAddressBroadcastMsg}|GetServiceIp", out string refData, out serviceIp))
            {
                if (refData == "true")
                {
                    client.Client.ReceiveTimeout = 60000;
                    return "连接服务器成功!";
                }
            }
            return "没有获得主机返回,请确认主机是否在同一局域网内!";
        }
        //发送消息到服务器接收反馈
        private bool Send(string message,out string RefData, out IPAddress ip)
        {
            try
            {
                var requestData = Encoding.UTF8.GetBytes(message);
                client.Send(requestData, requestData.Length, new IPEndPoint(serviceIp, 2875));
                var serverEp = new IPEndPoint(IPAddress.Broadcast, 0);
                var serverResponseData = client.Receive(ref serverEp);
                ip = serverEp.Address;
                RefData = Encoding.UTF8.GetString(serverResponseData);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ip = IPAddress.Broadcast;
                RefData = ex.ToString();
                return false;
            }
        }
        //关闭客户端
        public void CloseClient()
        {
            client?.Close();
        }
        #endregion

        #region 接口
        /// <summary>
        /// 主要与服务器端沟通的函数
        /// </summary>
        /// <param name="functionName">方法名</param>
        /// <param name="json">数据json</param>
        /// <returns>服务器返回的json</returns>
        public bool Fun(string functionName , string json,out string refData)
        {
            return Send($"{ServerAddressBroadcastMsg}|{functionName}|{json}", out refData, out _);
        }

        #endregion
    }
}
