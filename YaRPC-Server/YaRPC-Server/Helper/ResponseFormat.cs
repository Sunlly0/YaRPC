using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YaRPC_Server.Helper
{
    public class ResponseFormat
    {
        public bool Success;
        public string Info;
        public string Result;

        public static ResponseFormat ProcessNotExist()
        {
            ResponseFormat response = new ResponseFormat
            {
                Success = false,
                Info = "不存在的过程名称",
                Result = null
            };
            return response;
        }

        public static byte[] RunSuccess(string result)
        {
            ResponseFormat response = new ResponseFormat
            {
                Success = true,
                Info = "执行成功",
                Result = result
            };
            return JsonHelper.SerializeJson(response);
        }
    }
}
