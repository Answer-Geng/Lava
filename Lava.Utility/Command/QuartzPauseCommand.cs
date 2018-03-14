using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.Utility.Command
{
    public class QuartzPauseCommand : ICommand
    {
        private QuartzRemoteClient remoteClient;
        private JobKey jobKey;

        public QuartzPauseCommand(QuartzRemoteClient remoteClient, JobKey jobKey)
        {
            this.remoteClient = remoteClient;
            this.jobKey = jobKey;
        }

        public void Execute()
        {
            remoteClient.Pause(jobKey);
        }
    }
}
