using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz.Impl;
using Quartz;

namespace Lava.Utility.Command
{
    public class QuartzRemoteClient
    {
        private NameValueCollection properties;
        private IScheduler scheduler;

        public QuartzRemoteClient(NameValueCollection properties)
        {
            this.properties = properties;
            InitRemoteClient();
        }

        private void InitRemoteClient()
        {
            var sf = new StdSchedulerFactory(properties);
            scheduler = sf.GetScheduler();
        }

        public void Create()
        {
            
        }

        public void Run()
        {

        }

        public void Pause(JobKey jobKey)
        {
            scheduler.PauseJob(jobKey);
        }

        public void Delete()
        {

        }
    }
}
