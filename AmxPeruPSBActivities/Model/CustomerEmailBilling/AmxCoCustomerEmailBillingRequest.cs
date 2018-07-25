using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model.CustomerEmailBilling;
using Newtonsoft.Json;

namespace AmxPeruPSBActivities.Model
{
    public class AmxCoCustomerEmailBillingRequest
    {
        public string numeroCuenta { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
        public string email3 { get; set; }

        public static AmxCoCustomerEmailBillingRequest CustomerEmailBillingRequestFactory()
        {
            var returnValue = new AmxCoCustomerEmailBillingRequest();
            return returnValue;

        }

    }

 
}
