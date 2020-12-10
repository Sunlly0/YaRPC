using System;
using YaRPC_Server.Core;

namespace YaRPC_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            while (true)
            {
                manager.Listen();
            }
        }
    }
}
