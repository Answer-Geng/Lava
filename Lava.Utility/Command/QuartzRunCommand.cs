using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.Utility.Command
{
    public class QuartzRunCommand : ICommand
    {
        private QuartzRemoteClient remoteClient;
        public QuartzRunCommand(QuartzRemoteClient remoteClient)
        {
            this.remoteClient = remoteClient;
        }
        public void Execute()
        {
            remoteClient.Run();
        }
    }
}
