using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.CustomerEmailBilling
{
    public class AmxCoCustomerEmailBillingRespose : BaseResponse
    {

        public List<ErrorEmailBillingRespose> error { get; set; }

        public Boolean registrado { get; set; }

    }

    public class ErrorEmailBillingRespose
    {

        public Boolean isError { get; set; }
        public string msg { get; set; }

    }
}
