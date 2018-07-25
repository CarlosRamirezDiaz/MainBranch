using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.SeeCreditAssessment
{
    public class AMXPeruSeeCreditAssessmentRequest : BaseRequest
    {
        public string DecisionID { get; set; }
        public AMXPeruTyperequest Request { get; set; }
    }
}
