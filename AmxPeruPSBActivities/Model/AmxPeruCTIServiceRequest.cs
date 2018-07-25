using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxPeruCTIServiceRequest : BaseRequest
    {
        public int DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string MSISDN { get; set; }
    }
}
