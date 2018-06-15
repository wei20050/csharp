using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TYServiceCore
{
    public class Udp
    {
        public delegate void Main(string clientRequest, out string responseData);
        public event Main _main;
        public void ServiceOpen()
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
                if (clientRequest == ServerAddressBroadcastMsg)
                {
                    var responseData = Encoding.UTF8.GetBytes("true");
                    Server.Send(responseData, responseData.Length, clientEp);
                }
                else
                {
                    _main(clientRequest, out string responseStr);
                    var responseData = Encoding.UTF8.GetBytes(responseStr);
                    Server.Send(responseData, responseData.Length, clientEp);
                }
            }
        }
    }
}
