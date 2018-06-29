using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TYServiceCore
{
    public class TYUdp
    {
        public delegate void Main(string FunctionName, string JsonData, out string responseData);
        public static event Main _main;
        public static void ServiceOpen()
        {
            Console.Write("服务器运行中 ... ");
            var Server = new UdpClient(2875);
            const string ServerAddressBroadcastMsg = "825C7B29-5B62-4242-AF76-EBDB489A6090";
            while (true)
            {
                var clientEp = new IPEndPoint(IPAddress.Any, 0);
                var clientRequestData = Server.Receive(ref clientEp);
                var clientRequest = Encoding.UTF8.GetString(clientRequestData);
                if (string.IsNullOrWhiteSpace(clientRequest)) continue;
                var tmp = clientRequest.Split('|');
                if (tmp[0] == ServerAddressBroadcastMsg)
                {
                    if (tmp[1] == "GetServiceIp")
                    {
                        var responseData = Encoding.UTF8.GetBytes("true");
                        Server.Send(responseData, responseData.Length, clientEp);
                    }
                    else
                    {
                        _main(tmp[1], tmp[2], out string responseStr);
                        var responseData = Encoding.UTF8.GetBytes(responseStr);
                        Server.Send(responseData, responseData.Length, clientEp);
                    }
                }
            }
        }
    }
}
