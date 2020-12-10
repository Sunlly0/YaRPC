using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using YaRPC_Server.Helper;

namespace YaRPC_Server.Core.Process
{
    public class AddProcess: ProcessBase
    {
        public override string DoWork(decimal[] decimalParam, string[] stringParam)
        {
            decimal result = decimalParam[0] + decimalParam[1];
            return ByteHelper.DecimalToString(result);
        }
        
        public AddProcess()
        {
            ProcessName = "AddProcess";
        }
        
    }
}
