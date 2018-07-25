using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.Eligibility
{
   public class AmxPeruCreateBILOGResponse : BaseResponse
    {
       
        public string subject { get; set; }
        public string description { get; set; }
        public Guid RegardingRecordID { get; set; }
        public string RegardingRecordEntityName { get; set; }
    }
}
