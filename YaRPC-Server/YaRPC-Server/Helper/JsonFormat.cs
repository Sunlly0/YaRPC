using System;
using System.Collections.Generic;
using System.Text;

namespace YaRPC_Server.Helper
{
    public class JsonFormat
    {
        public string ProcessName { get; set; }
        public List<string> StringParams { get; set; }
        public List<decimal> DecimalParams { get; set; }
    }
}
