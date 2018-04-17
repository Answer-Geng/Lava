using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Specialized;
using Lava.Utility.Command;
using Quartz;
using Quartz.Impl;
using Lava.Job;
using Lava.Utility.Provider;
using Quartz.Impl.AdoJobStore;
using System.Data.SqlClient;
using Common.Logging;
using Quartz.Impl.AdoJobStore.Common;
using Quartz.Simpl;
using System.Data.Common;

namespace Lava.UnitTest.CommonLayer
{
    [TestClass]
    public class QuartzCommandUnitTest
    {
        private JobKey jobKey;
        private IScheduler scheduler;
        public QuartzCommandUnitTest()
        {
            RemoteSchedulerProvider rs = new RemoteSchedulerProvider();
            scheduler = rs.Scheduler;
            jobKey = new JobKey("lava_job_001", "lava_job_group");
        }

        [TestMethod]
        public void QuartzPauseJobCommand()
        { 
            QuartzPauseJobCommand pauseCommand = new QuartzPauseJobCommand(scheduler, jobKey);
            pauseCommand.Execute();
        }

        [TestMethod]
        public void QuartzResumeJobCommand()
        {
            QuartzResumeJobCommand resumeCommand = new QuartzResumeJobCommand(scheduler, jobKey);
            resumeCommand.Execute();
        }

        [TestMethod]
        public void QuartzDeleteJobCommand()
        {
            QuartzDeleteJobCommand deleteCommand = new QuartzDeleteJobCommand(scheduler, jobKey);
            deleteCommand.Execute();
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
            addCommand.Execute();
           
        }

        [TestMethod]
        public void QuartzSelectCommand()
        {
            var args = new DelegateInitializationArgs();
            args.Logger = LogManager.GetLogger(GetType());
            args.TablePrefix = "LAVA_";
            args.InstanceName = "Lava";
            args.InstanceId = "AUTO";
            args.DbProvider = new DbProvider("SqlServer-20", "Data Source=.;Initial Catalog=Lava;User ID=sa;Password=123");
            args.TypeLoadHelper = new SimpleTypeLoadHelper();
            args.ObjectSerializer = new DefaultObjectSerializer();

            StdAdoDelegate adoDelegate = new StdAdoDelegate();
            adoDelegate.Initialize(args);
            using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Lava;User ID=sa;Password=123"))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    ConnectionAndTransactionHolder holder = new ConnectionAndTransactionHolder(conn, tran);
                    var num = adoDelegate.SelectNumJobs(holder);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                }
               
            }
        }
    }
}

