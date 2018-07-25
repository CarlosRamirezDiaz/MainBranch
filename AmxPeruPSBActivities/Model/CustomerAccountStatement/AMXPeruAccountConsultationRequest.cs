using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.CustomerAccountStatement
{
    public class AMXPeruAccountConsultationRequest :BaseRequest
    {
        public string TransactionId { get; set; }
        public string ApplicationCode { get; set; }
        public string UserApplication { get; set; }
        public string QueryType { get; set; }
        public string ServiceType { get; set; }
        public string CLIAccountNo { get; set; }
        public string TelephoneNo { get; set; }
        public string BalanceEnquryFlag { get; set; }
        public string PaymentDisputeFlag { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int  PageSize { get; set; }
        public string PageNo { get; set; }
    }
}
