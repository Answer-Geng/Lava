using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Common.Logging;

namespace Lava.Job
{
    public class JobBase : IJob
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(JobBase));
        public void Execute(IJobExecutionContext context)
        {
            log.Info("--------------------Test Job Executing--------------------------");
        }
    }
}
