using Quartz;

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
