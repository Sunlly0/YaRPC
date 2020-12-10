using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace YaRPC_Server.Core
{
    public class NetWork
    {
        private IPEndPoint IPEndPoint;
        public Socket Socket;
        
        public NetWork(int port)
        {
            IPAddress iP = IPAddress.Any;
            IPEndPoint = new IPEndPoint(iP, port);
            Socket = new Socket(IPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Socket.Bind(IPEndPoint);
            Socket.Listen(10);
        }


    }
}
