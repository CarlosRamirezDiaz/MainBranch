using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
   public class AmxPeruCreateBILOGRequest: BaseRequest
    {
        public string subject { get; set; }
        public string description { get; set; }
        public Guid CreatedTaskID { get; set; }
        public string regardingRecordEntityName { get; set; }
     
    }
}
