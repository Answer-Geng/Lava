using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz.Impl;
using System.Collections.Specialized;
using Quartz;
using Common.Logging;
using Lava.Job;

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
                //["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz",
                //["quartz.threadPool.threadCount"] = "5",
                //["quartz.threadPool.threadPriority"] = "Normal",
                //["quartz.scheduler.exporter.type"] = "Quartz.Simpl.RemotingSchedulerExporter, Quartz",
                //["quartz.scheduler.exporter.port"] = "555",
                //["quartz.scheduler.exporter.bindName"] = "QuartzScheduler",
                //["quartz.scheduler.exporter.channelType"] = "tcp",
                //["quartz.scheduler.exporter.channelName"] = "httpQuartz",
                //["quartz.scheduler.exporter.rejectRemoteRequests"] = "true",
                //["quartz.jobStore.misfireThreshold"] = "60000",
                ["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz",
                ["quartz.jobStore.dataSource"] = "default",
                ["quartz.jobStore.tablePrefix"] = "LAVA_",
                ["quartz.jobStore.clustered"] = "true",
                ["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz",
                ["quartz.dataSource.default.connectionString"] = @"Data Source=.;Initial Catalog=Lava;User ID=sa;Password=123",
                ["quartz.dataSource.default.provider"] = "SqlServer-20"
            };

            ////1.首先创建一个作业调度池
            //var properties = new NameValueCollection();
            ////存储类型
            //properties["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz";

            ////驱动类型
            //properties["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz";   
            //properties["quartz.jobStore.dataSource"] = "myDS";
            //properties["quartz.jobStore.tablePrefix"] = "LAVA_";
            ////连接字符串
            //properties["quartz.dataSource.myDS.connectionString"] = @"Data Source=.;Initial Catalog=Lava;User ID=sa;Password=123";
            ////sqlserver版本
            //properties["quartz.dataSource.myDS.provider"] = "SqlServer-20";

            ////是否集群
            //properties["quartz.jobStore.clustered"] = "true";
            //properties["quartz.scheduler.instanceId"] = "AUTO";

            ISchedulerFactory sf = new StdSchedulerFactory(properties);
            IScheduler sched = sf.GetScheduler();
            log.Info("------- Initialization Complete -----------");
            log.Info("------- Starting Scheduler ---------------");
            sched.Start();
            log.Info("------- Started Scheduler ----------------");

            //var jobKey = JobKey.Create("myjob", "group");

            //if (sched.CheckExists(jobKey))
            //{
            //    Console.WriteLine("当前job已经存在，无需调度:{0}", jobKey.ToString());
            //}
            //else
            //{
            //    IJobDetail job = JobBuilder.Create<JobBase>()
            //           .WithDescription("使用quartz进行持久化存储")
            //           .StoreDurably()
            //           .RequestRecovery()
            //           .WithIdentity(jobKey)
            //           .UsingJobData("count", 1)
            //           .Build();

            //    ITrigger trigger = TriggerBuilder.Create().WithSimpleSchedule(x => x.WithIntervalInSeconds(2).RepeatForever())
            //                                              .Build();

            //    sched.ScheduleJob(job, trigger);

            //    Console.WriteLine("调度进行中！！！");
            //}

            var jobKey = JobKey.Create("myjob", "group");
            if (sched.CheckExists(jobKey))
            {
                log.Info("The current job already exsits");
            }
            else
            {
                log.Info("------------------Start to Create job-----------------------");

                IJobDetail job = JobBuilder.Create<JobBase>()
                    .WithDescription("使用quartz进行持久化存储")
                    .StoreDurably()
                    .RequestRecovery()
                    .WithIdentity(jobKey)
                    .UsingJobData("count", 1)
                    .Build();

                ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
                                                              .WithSimpleSchedule(x => x.WithIntervalInSeconds(2).RepeatForever())
                                                              .Build();

                log.InfoFormat("{0} will run at: {1} and repeat: {2} times, every {3} seconds", job.Key, trigger.GetNextFireTimeUtc(), trigger.RepeatCount, trigger.RepeatInterval.TotalSeconds);
                sched.ScheduleJob(job, trigger);
            }

        }

    }
}
