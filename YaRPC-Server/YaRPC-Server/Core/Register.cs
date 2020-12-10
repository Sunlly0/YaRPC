using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YaRPC_Server.Core.Process;

namespace YaRPC_Server.Core
{
    public class Register
    {
        private Dictionary<string, ProcessBase> RegistedProcess = 
            new Dictionary<string, ProcessBase>();

        public void Regist(ProcessBase process)
        {
            RegistedProcess.Add(process.ProcessName, process);
        }

        public ProcessBase GetProcess(string processName)
        {
            var item = RegistedProcess.Where(r => r.Key == processName).FirstOrDefault();
            if (item.Value == null)
                return null;
            else
                return item.Value;
        }
    }
}
