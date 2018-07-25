using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.Case
{
    public class AmxCoUpdateCaseStatusRequest
    {
        public string caseId { get; set; }
        public string caseReason { get; set; }
        public string caseIdMGL { get; set; }
        public string caseStatus { get; set; }
        public string caseCompleted { get; set; }
    }
}
