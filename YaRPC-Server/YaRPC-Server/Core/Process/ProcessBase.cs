using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace YaRPC_Server.Core.Process
{
    public class ProcessBase
    {
        public string ProcessName { get; set; }
        public virtual string DoWork(decimal[] decimalParam, string[] stringParam)
        {
            return null;
        }
    }
}
