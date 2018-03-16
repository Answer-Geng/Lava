using Common.Logging;
using Quartz;

namespace Lava.Job
{
    public abstract class AbstractJob : IJob
    {
        protected readonly static ILog log = LogManager.GetLogger(typeof(AbstractJob));
        public abstract void Execute(IJobExecutionContext context);
        
    }
}
