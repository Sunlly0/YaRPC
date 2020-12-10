using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace YaRPC_Server.Helper
{
    public class ByteHelper
    {
        public static string DecimalToString(decimal number)
        {
            return Convert.ToString(number);
        }
    }
}
