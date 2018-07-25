using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
   public  class AmxPeruModifyBillingAccountRequest
    {
        
        public string AccountName;

       
        public bool AllowCallItemization;

       
        public int BillMedium;

       
        public System.Guid BillToAddressId;

     
        public string BillingAccountId;

       
        public bool IsPrimaryBillingAccount;

      
        public System.Guid MailToAddressId;

        public int NumberOfCopies;

       
        public bool IsExternal;

      
        public bool IsIndividual;

       
        public string CustomerExternalId;
    }
}
