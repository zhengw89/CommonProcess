using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonProcess.Demo.Core
{
    internal abstract class OperateProcess : CoreOperateProcess
    {
        protected OperateProcess(IDataProcessConfig config)
            : base(config)
        {
        }

        public bool ExecuteProcess()
        {
            return base.ExecuteCoreProcess();
        }
    }
}
