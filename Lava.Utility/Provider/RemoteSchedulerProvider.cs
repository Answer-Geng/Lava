using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.Utility.Provider
{
    public class RemoteSchedulerProvider
    {
        private IScheduler scheduler;
        public IScheduler Scheduler
        {
            get
            {
                if (scheduler == null)
                {
                    Init();
                }
                return scheduler;
            }
        }

        public string ProxyAddress { get; set; }

        private void Init()
        {
            var properties = GetRemoteSchedulerProperties();
            var schedulerFactory = new StdSchedulerFactory(properties);
            scheduler = schedulerFactory.GetScheduler();
        }

        private NameValueCollection GetRemoteSchedulerProperties()
        {
            var properties = new NameValueCollection()
            {
                ["quartz.scheduler.instanceName"] = "RemoteClient",
                ["quartz.scheduler.proxy"] = "true",
                ["quartz.scheduler.proxy.address"] = ProxyAddress == "" ? "tcp://127.0.0.1:555/QuartzScheduler" : ProxyAddress
            };
            return properties;
        }
    }
}
