using Lava.Utility.Command;
using Lava.Utility.Provider;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.Business
{
    public class JobLogic
    {
        private IScheduler scheduler = new RemoteSchedulerProvider().Scheduler;

        public void AddJob()
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
