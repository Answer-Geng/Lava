using Lava.Utility.Command;
using Lava.Utility.Provider;
using Lava.ViewModel.Job;
using Quartz;
using System;

namespace Lava.Business
{
    public class JobLogic
    {
        private IScheduler scheduler = new RemoteSchedulerProvider().Scheduler;

        public void AddJob(CreateJobInput job)
        {
           
        }
        public void DeleteJob(string name,string group)
        {
            var delete = new QuartzDeleteJobCommand(scheduler, new JobKey(name, group));
            delete.Execute();
        }
        public void PauseJob(string name, string group)
        {
            var pause = new QuartzPauseJobCommand(scheduler, new JobKey(name, group));
            pause.Execute();
        }
        public void ResumeJob(string name, string group)
        {
            var resume = new QuartzResumeJobCommand(scheduler, new JobKey(name, group));
            resume.Execute();
        }
        
    }
}
