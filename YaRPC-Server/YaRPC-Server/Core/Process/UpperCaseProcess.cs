using System;
using System.Collections.Generic;
using System.Text;

namespace YaRPC_Server.Core.Process
{
    class UpperCaseProcess: ProcessBase
    {
        public override string DoWork(decimal[] decimalParam, string[] stringParam)
        {
            string s = stringParam[0];
            return s.ToUpper();
        }

        public UpperCaseProcess()
        {
            this.ProcessName = "UpperCaseProcess";
        }
    }
}
