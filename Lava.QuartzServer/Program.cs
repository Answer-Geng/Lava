using Quartz.Impl;
using System.Collections.Specialized;
using Quartz;
using Common.Logging;

namespace Lava.QuartzServer
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            NameValueCollection properties = new NameValueCollection
            {
                ["quartz.scheduler.instanceName"] = "Lava",
                ["quartz.scheduler.instanceId"] = "AUTO",
                ["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz",
                ["quartz.threadPool.threadCount"] = "5",
                ["quartz.threadPool.threadPriority"] = "Normal",
                ["quartz.scheduler.exporter.type"] = "Quartz.Simpl.RemotingSchedulerExporter, Quartz",
                ["quartz.scheduler.exporter.port"] = "555",
                ["quartz.scheduler.exporter.bindName"] = "QuartzScheduler",
                ["quartz.scheduler.exporter.channelType"] = "tcp",
                ["quartz.scheduler.exporter.channelName"] = "httpQuartz",
                ["quartz.scheduler.exporter.rejectRemoteRequests"] = "true",
                ["quartz.jobStore.misfireThreshold"] = "60000",
                ["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz",
                ["quartz.jobStore.dataSource"] = "default",
                ["quartz.jobStore.tablePrefix"] = "LAVA_",
                ["quartz.jobStore.clustered"] = "true",
                ["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz",
                ["quartz.dataSource.default.connectionString"] = @"Data Source=.;Initial Catalog=Lava;User ID=sa;Password=123",
                ["quartz.dataSource.default.provider"] = "SqlServer-20"
            };

            ISchedulerFactory sf = new StdSchedulerFactory(properties);
            IScheduler sched = sf.GetScheduler();
            log.Info("------- Initialization Complete -----------");
            log.Info("------- Starting Scheduler ---------------");
            sched.Start();
        }
    }
}
