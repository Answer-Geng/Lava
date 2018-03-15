using Quartz;

namespace Lava.Utility.Command
{
    public class QuartzPauseJobCommand : ICommand
    {
        private IScheduler scheduler;
        private JobKey jobKey;

        public QuartzPauseJobCommand(IScheduler scheduler, JobKey jobKey)
        {
            this.scheduler = scheduler;
            this.jobKey = jobKey;
        }

        public void Execute()
        {
            scheduler.PauseJob(jobKey);
        }
    }
}
