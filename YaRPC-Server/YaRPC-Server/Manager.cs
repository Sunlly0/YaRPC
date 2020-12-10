using System;
using System.Collections.Generic;
using System.Text;
using YaRPC_Server.Core;
using YaRPC_Server.Core.Process;

namespace YaRPC_Server
{
    public class Manager: ManagerBase
    {
        public Manager()
        {
            AddProcess addProcess = new AddProcess();
            ProcessRegister.Regist(addProcess);

            MinusProcess minusProcess = new MinusProcess();
            ProcessRegister.Regist(minusProcess);

            UpperCaseProcess upperCaseProcess = new UpperCaseProcess();
            ProcessRegister.Regist(upperCaseProcess);


        }
    }
}
