using ExternalApiActivities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    class AMXPeruCreditProfileRequestModel : CustomerCreditProfileRequestModel
    {
        public int CurrentBureauCreditLimit { get; set; }

        public int CurrentCRMCreditLimit { get; set; }

        public int CurrentWalletsCreditLimits { get; set; }

        public int RequestedCRMCreditLimit { get; set; }

        public int ConfirmedCRMCreditLimit { get; set; }

        public String ChangeReason { get; set; }
    }
}
