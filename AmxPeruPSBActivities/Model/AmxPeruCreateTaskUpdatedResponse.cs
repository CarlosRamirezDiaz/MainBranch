using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
   public class AmxPeruCreateTaskUpdatedResponse : BaseRequest
    {
        public string CreatedTaskID { get; set; }
        public string regardingRecordEntityName { get; set; }
    }
}
