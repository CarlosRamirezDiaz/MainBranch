using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.SeeCreditAssessment
{
    public class AMXPeruSeeCreditAssessmentResponse : BaseResponse
    {
        public string DecisionID { get; set; }
        public AMXPeruOfferingType Offering { get; set; }
    }
}
