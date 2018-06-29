using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using TYPublicCore;

namespace TYServiceCore
{
    public class TyUdp
    {
        //回调的委托
        public delegate void Callback(string functionName, string jsonData);
        //事件声明
        public static event Callback OnCallback;
        /// <summary>
        /// 服务开启
        /// </summary>
        public static void ServiceOpen()
        {
            //标识UDP信息的加密GUID
            const string broadcastMsg = "825C7B29-5B62-4242-AF76-EBDB489A6090";
            //------这里检查局域网内是否开启了多个服务器 
            var client = new UdpClient
            {
                Client = { ReceiveTimeout = 1000 },
                EnableBroadcast = true
            };
            IPAddress ip;
            var refData = string.Empty;
            try
            {
                var requestData = Encoding.UTF8.GetBytes($"{broadcastMsg}|GetServiceIp");
                client.Send(requestData, requestData.Length, new IPEndPoint(IPAddress.Broadcast, 2875));
                var serverEp = new IPEndPoint(IPAddress.Broadcast, 0);
                var serverResponseData = client.Receive(ref serverEp);
                ip = serverEp.Address;
                refData = Encoding.UTF8.GetString(serverResponseData);
            }
            catch
            {
                ip = IPAddress.Broadcast;
            }
            if (!ip.Equals(IPAddress.Broadcast) && refData.Equals("true"))
            {
                Console.Write($@"当前局域网内已有服务器运行{Environment.NewLine}若要以当前机器为服务器请关闭 {ip} 上的服务器程序 !");
                Console.Read();
                return;
            }
            //------检查完毕

            //服务器默认端口
            var server = new UdpClient(2875);
            Console.Write("服务器运行中 ... ");
            //服务器端死循环监控消息
            while (true)
            {
                try
                {
                    var clientEp = new IPEndPoint(IPAddress.Any, 0);
                    var clientRequestData = server.Receive(ref clientEp);
                    var clientRequest = Encoding.UTF8.GetString(clientRequestData);
                    if (string.IsNullOrWhiteSpace(clientRequest)) continue;
                    var tmp = clientRequest.Split('|');
                    if (tmp[0] != broadcastMsg) continue;
                    if (tmp[1] == "GetServiceIp")
                    {
                        var responseData = Encoding.UTF8.GetBytes("true");
                        server.Send(responseData, responseData.Length, clientEp);
                    }
                    else
                    {
                        OnCallback?.Invoke(tmp[1], tmp[2]);
                        var responseData = Encoding.UTF8.GetBytes(ReflexFunction(tmp[1], tmp[2]));
                        server.Send(responseData, responseData.Length, clientEp);
                    }
                }
                catch (Exception e)
                {
                    Console.Write("服务器异常,详细错误请看日志文件 !");
                    TyLog.Wlog(e);
                    return;
                }
            }
        }

        private static string ReflexFunction(string functionName, string jsonData)
        {
            string responseStr;
            try
            {
                var dll = Environment.CurrentDirectory + @"\TYService.dll";
                const string className = @"TYService.Index";
                var assembly = Assembly.LoadFile(dll);
                var type = assembly.GetType(className);
                responseStr = $@"1|{(string)type.InvokeMember(functionName, BindingFlags.Default | BindingFlags.InvokeMethod, null, null, new object[] { jsonData })}";
            }
            catch (Exception e)
            {
                TyLog.Wlog(e);
                responseStr = $@"0|TYService.Index.{functionName} 未找到 请确认在程序根目录存在TYService.dll 并且其中Index类中存在方法{functionName}";
            }
           return responseStr;
        }
    }
}
