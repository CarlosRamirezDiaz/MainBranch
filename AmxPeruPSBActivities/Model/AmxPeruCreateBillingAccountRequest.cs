using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxPeruCreateBillingAccountRequest : BaseRequest
    {
        public bool IsExternal { get; set; }
        public string LoggedInUserGuid { get; set; }
        public bool IsIndividual { get; set; }
        public string CustomerGuid { get; set; }
        public string BiCreateBARecordGuid { get; set; }
        public string AccountType { get; set; }
        public int AccountStatus { get; set; }
        public string BillingAccountGuid { get; set; }
        public string CustomerExternalId { get; set; }
        public string BillingAccountName { get; set; }
        public string BillCycleCode { get; set; }
        public bool AllowCallItemization { get; set; }
        public int BillFormatId { get; set; }
        public int BillFormatNumberOfCopies { get; set; }
        public List<BillingAddress> Addresses { get; set; }
    }
    public class BillingAddress
    {    
        public string ExternalId { get; set; }
        public string AddressGuid { get; set; }
        public string AddressTypeCode { get; set; }
    }
}
