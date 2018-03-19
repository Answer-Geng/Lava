using Quartz;

namespace Lava.Utility.Command
{
    public class QuartzAddJobCommand : ICommand
    {
        private IScheduler scheduler;
        private IJobDetail jobDetail;
        private ITrigger trigger;
        public QuartzAddJobCommand(IScheduler scheduler, IJobDetail jobDetail, ITrigger trigger)
        {
            this.scheduler = scheduler;
            this.jobDetail = jobDetail;
            this.trigger = trigger;
        }
        public void Execute()
        {
            scheduler.ScheduleJob(jobDetail, trigger);
        }
    }
}
