using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.Case
{
    public class CaseGetCunRequest
    {
        public string documentType { get; set; }
        public string documentId { get; set; }
        public string business { get; set; }
        public string incidentId { get; set; }
    }
}
