using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AxmPeruCreateProspectRequest :BaseRequest
    {
        public int documentType { get; set; }
        public string documentNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string companyName { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

    }
}
