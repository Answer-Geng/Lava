using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.Utility.Command
{
    public class QuartzDeleteCommand : ICommand
    {

        private QuartzRemoteClient remoteClient;
        public QuartzDeleteCommand(QuartzRemoteClient remoteClient)
        {
            this.remoteClient = remoteClient;
        }
        public void Execute()
        {
            remoteClient.Delete();
        }
    }
}
