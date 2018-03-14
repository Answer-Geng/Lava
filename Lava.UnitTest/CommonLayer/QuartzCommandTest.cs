using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Specialized;
using Lava.Utility.Command;
using Quartz;

namespace Lava.UnitTest.CommonLayer
{
    [TestClass]
    public class QuartzCommandTest
    {
        [TestMethod]
        public void QuartzPauseCommand()
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

            Invoker invoker = new Invoker();
            JobKey jobKey = new JobKey("myjob", "group");
            QuartzRemoteClient client = new QuartzRemoteClient(properties);
            QuartzPauseCommand pauseCommand = new QuartzPauseCommand(client, jobKey);
            invoker.SetCommand(pauseCommand);
            invoker.ExecuteCommand();

        }
    }
}
