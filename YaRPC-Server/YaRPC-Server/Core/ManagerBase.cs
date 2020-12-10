using Newtonsoft.Json;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using YaRPC_Server.Core.Process;
using YaRPC_Server.Helper;

namespace YaRPC_Server.Core
{
    public class ManagerBase
    {
        protected Register ProcessRegister = new Register();
        protected NetWork ServerSocket = new NetWork(Settings.Port);


        public void Listen()
        {
            Socket tmpSocket;
            while (true)
            {
                tmpSocket = ServerSocket.Socket.Accept();
                Thread newThread = new Thread(new ParameterizedThreadStart(ReceiveCall));
                newThread.Start(tmpSocket);
            }
        }

        private void ReceiveCall(Object _socket)
        {
            Socket socket = (Socket)_socket;
            try
            {
                //int hasTried = 1;
                //int trySum = 6;
                while (true)
                {
                    byte[] buffer = new byte[Settings.bufferSize];

                    int recvLength = socket.Receive(buffer, buffer.Length, SocketFlags.None);
                    //if (hasTried < trySum)
                    //{
                    //    hasTried++; 
                    //    continue;   //前两次请求故意丢弃，模拟请求失败，待到第三次请求的时候返回
                    //}
                    //continue;
                    if (recvLength == 0)
                        //客户端已断开
                        return;
                    byte[] callResult = RunCall(buffer);
                    socket.Send(callResult, callResult.Length, SocketFlags.None);
                }
            }
            catch (System.Net.Sockets.SocketException)
            {
                return;
            }
            
                   
        }

        private byte[] RunCall(byte[] buffer)
        {
            string jsonString = Encoding.UTF8.GetString(buffer);
            jsonString = jsonString.Replace("\0", "");
            JsonFormat requestJson =JsonConvert.DeserializeObject<JsonFormat>(jsonString);

            string processName = requestJson.ProcessName;
            ProcessBase process = ProcessRegister.GetProcess(processName);
            if (process == null)
                return JsonHelper.SerializeJson(ResponseFormat.ProcessNotExist());
            string result = process.DoWork(requestJson.DecimalParams.ToArray(), 
                requestJson.StringParams.ToArray());

            return ResponseFormat.RunSuccess(result);
        }
    }
}
