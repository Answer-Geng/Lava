using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lava.ViewModel.Job
{
    public class CreateJobInput
    {
        public int JobID { get; set; }
        public string JobName { get; set; }
        public string JobGroup { get; set; }
        public string TriggerName { get; set; }
        public string TriggerGroup { get; set; }
        public string Cron { get; set; }
        public string Description { get; set; }
    }
}
