using Quartz;

namespace Lava.Utility.Command
{
    public class QuartzResumeJobCommand : ICommand
    {   
        private IScheduler scheduler;
        private JobKey jobKey;
        public QuartzResumeJobCommand(IScheduler scheduler, JobKey jobKey)
        {
            this.scheduler = scheduler;
            this.jobKey = jobKey;
        }
        public void Execute()
        {
            scheduler.ResumeJob(jobKey);
        }
    }
}
