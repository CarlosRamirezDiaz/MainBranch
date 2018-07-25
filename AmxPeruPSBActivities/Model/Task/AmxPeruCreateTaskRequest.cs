using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.Task
{
    public class AmxPeruCreateTaskRequest : BaseRequest
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int TaskType { get; set; }
        public bool BIRequired { get; set; }
        public string ServiceId { get; set; }
        public DateTime ScheduledEnd { get; set; }
        public string OwnerType { get; set; }
        public string OwnerName { get; set; }
        public string RegardingType { get; set; }
        public string RegardingColumnName { get; set; }
        public string RegardingColumnValue { get; set; }
    }
 }
