﻿using Quartz;

namespace Lava.Job
{
    public class HelloJob : BaseJob
    {
        public override void Execute(IJobExecutionContext context)
        {
            log.Info("-------------------HelloJob-------------------");
        }
    }
}
