using Quartz;

namespace Lava.Job
{
    public class HelloJob2 : BaseJob
    {
        public override void Execute(IJobExecutionContext context)
        {
            log.Info("-------------------HelloJob2-------------------");
        }
    }
}
