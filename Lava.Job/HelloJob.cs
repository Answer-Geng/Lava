using Common.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.Job
{
    public class HelloJob : AbstractJob
    {
        public override void Execute(IJobExecutionContext context)
        {
            log.Info("---------------Hello,Job-----------------");
        }
    }
}
