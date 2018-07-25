using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxSoapServicesActivities.Model
{
    public class GenericDirectoryNumberServiceRequest
    {
        public string npcode { get; set; }
        public string plcode { get; set; }
        public string submId { get; set; }
        public string hlcode { get; set; }
        public string dnCode { get; set; }
        public string dnStatus { get; set; }
        public string searchCount { get; set; }
        public bool reservation { get; set; }
    }
}
