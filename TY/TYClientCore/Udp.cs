using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TYClientCore
{
    public class Udp
    {
        #region 基本定义与系统方法
        private static Udp udp = null;//本类对象
        private static readonly object locker = new object();//多线程锁
        UdpClient client;//udp对象
        IPAddress serviceIp = IPAddress.Broadcast;//服务器IP
        //私有构造实现单例模式
        private Udp()
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
        public static Udp Getudp()
        {
            if (udp == null)
            {
                lock (locker)
                {
                    if (udp == null)
                    {
                        udp = new Udp();
                    }
                }
            }
            return udp;
        }
        //获取服务器地址(连接服务器)
        private string DetectServiceAddress()
        {
            if (Send("825C7B29-5B62-4242-AF76-EBDB489A6090", out serviceIp) == string.Empty)
            {
                return "没有获得主机返回,请确认主机是否在同一局域网内!";
            }
            else
            {
                return "连接服务器成功!";
            }
        }
        //发送消息到服务器接收反馈
        private string Send(string message, out IPAddress ip)
        {
            try
            {
                var requestData = Encoding.UTF8.GetBytes(message);
                client.Send(requestData, requestData.Length, new IPEndPoint(serviceIp, 2875));
                var serverEp = new IPEndPoint(IPAddress.Broadcast, 0);
                var serverResponseData = client.Receive(ref serverEp);
                ip = serverEp.Address;
                return Encoding.UTF8.GetString(serverResponseData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ip = IPAddress.Broadcast;
                return string.Empty;
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
        public string Fun(string functionName , string json)
        {
            return Send($"{functionName}|{json}", out _);
        }

        #endregion
    }
}
