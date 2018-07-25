using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPSBActivities.Model
{
    public class AmxGetCustomerInfoRequest : AmxPeruPSBActivities.Model.BaseRequest
    {
        public string contactid { get; set; }
        public string msisdn { get; set; }
        public int documentType { get; set; }
        public string documentNumber { get; set; }
        public string customerName { get; set; }
        public string invoiceNumber { get; set; }
        public string accountNumber { get; set; }
    }
}
