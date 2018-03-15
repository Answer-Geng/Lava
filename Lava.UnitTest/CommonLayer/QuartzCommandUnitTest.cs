using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Specialized;
using Lava.Utility.Command;
using Quartz;
using Quartz.Impl;
using Lava.Job;

namespace Lava.UnitTest.CommonLayer
{
    [TestClass]
    public class QuartzCommandUnitTest
    {
        private Invoker invoker;
        private JobKey jobKey;
        private IScheduler scheduler;
        public QuartzCommandUnitTest()
        {
            NameValueCollection properties = new NameValueCollection()
            {
                ["quartz.scheduler.instanceName"] = "RemoteClient",

                // set thread pool info
                ["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz",
                ["quartz.threadPool.threadCount"] = "5",
                ["quartz.threadPool.threadPriority"] = "Normal",

                // set remoting exporter
                ["quartz.scheduler.proxy"] = "true",
                ["quartz.scheduler.proxy.address"] = "tcp://127.0.0.1:555/QuartzScheduler"
            };

            var schedulerFactory = new StdSchedulerFactory(properties);
            scheduler = schedulerFactory.GetScheduler();
            invoker = new Invoker();
            jobKey = new JobKey("lava_job_001", "lava_job_group");
        }

        [TestMethod]
        public void QuartzPauseJobCommand()
        { 
            QuartzPauseJobCommand pauseCommand = new QuartzPauseJobCommand(scheduler, jobKey);
            invoker.SetCommand(pauseCommand);
            invoker.ExecuteCommand();
        }

        [TestMethod]
        public void QuartzResumeJobCommand()
        {
            QuartzResumeJobCommand resumeCommand = new QuartzResumeJobCommand(scheduler, jobKey);
            invoker.SetCommand(resumeCommand);
            invoker.ExecuteCommand();
        }

        [TestMethod]
        public void QuartzDeleteJobCommand()
        {
            QuartzDeleteJobCommand deleteCommand = new QuartzDeleteJobCommand(scheduler, jobKey);
            invoker.SetCommand(deleteCommand);
            invoker.ExecuteCommand();
        }

        [TestMethod]
        public void QuartzAddJobCommand()
        {
            var job = JobBuilder.Create<HelloJob>()
                .WithIdentity("lava_job_001", "lava_job_group")
                .RequestRecovery()
                .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity("lava_trigger_001", "lava_trigger_group")
                .ForJob(job)
                .StartNow()
                .WithSimpleSchedule(x => x.RepeatForever().WithInterval(TimeSpan.FromSeconds(2)))
                .Build();

            QuartzAddJobCommand addCommand = new QuartzAddJobCommand(scheduler, job, trigger);
            invoker.SetCommand(addCommand);
            invoker.ExecuteCommand();
        }
    }
}
