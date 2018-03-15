using Common.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.Job
{
    public abstract class AbstractJob : IJob
    {
        protected readonly static ILog log = LogManager.GetLogger(typeof(AbstractJob));
        public abstract void Execute(IJobExecutionContext context);
        
    }
}
