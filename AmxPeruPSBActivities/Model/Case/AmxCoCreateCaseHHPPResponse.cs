using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.Case
{
    public class AmxCoCreateCaseHHPPResponse
    {
        public bool error { get; set; }
        public string messageError { get; set; }
        public string caseId { get; set; }
        public string numberId { get; set; }
    }
}
