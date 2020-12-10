using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YaRPC_Server.Helper
{
    public class JsonHelper
    {
        public static byte[] SerializeJson(Object obj)
        {
            string jsonString = JsonConvert.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(jsonString);
        }
    }
}
