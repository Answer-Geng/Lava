using Common.Logging;
using Quartz;

namespace Lava.Job
{
    public abstract class BaseJob : IJob
    {
        protected readonly static ILog log = LogManager.GetLogger(typeof(BaseJob));
        public abstract void Execute(IJobExecutionContext context);
    }
}
