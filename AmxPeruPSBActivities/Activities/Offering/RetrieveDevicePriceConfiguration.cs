using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;

namespace AmxPeruPSBActivities.Activities.Offering
{
    public class RetrieveDevicePriceConfiguration : XrmAwareCodeActivity
    {
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            //select all configurations.

            //filter with input device Id

            //map to model for output
            // device name (offer Name)
        }
    }
}
