using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Model
{
   public class AmxCoTechnicianAppGetResourceRequest
    {
       public GetResourceRequest getResourceRequest { get; set; }
    }
    public class HeaderRequest
    {
        public string transactionId { get; set; }
        public string system { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string requestDate { get; set; }
        public string ipApplication { get; set; }
        public string traceabilityId { get; set; }
    }
    public class GetResourceRequest
    {
        public HeaderRequest headerRequest { get; set; }
        public string company { get; set; }
        public string id { get; set; }
        public string date { get; set; }
    }
}
