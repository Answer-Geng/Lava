using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace Lava.Job
{
    class JobBase : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
