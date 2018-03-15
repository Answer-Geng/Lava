using Quartz;

namespace Lava.Utility.Command
{
    public class QuartzDeleteJobCommand : ICommand
    {
        private IScheduler scheduler;
        private JobKey jobKey;
        public QuartzDeleteJobCommand(IScheduler scheduler, JobKey jobKey)
        {
            this.scheduler = scheduler;
            this.jobKey = jobKey;
        }
        public void Execute()
        {
            scheduler.DeleteJob(jobKey);
        }
    }
}
