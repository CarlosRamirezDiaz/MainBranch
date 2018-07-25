using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxPeruGetCustomerInfoRequest : BaseRequest
    {
        public string msisdn { get; set; }
        public int documentType { get; set; }
        public string documentNumber { get; set; }
        public string customerName { get; set; }
        public string invoiceNumber { get; set; }
    }
}
