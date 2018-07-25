using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;

namespace AmxPeruPSBActivities.Activities.EOC
{

    public sealed class GetCustomerProductsFromSRActivity : XrmAwareCodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> CustomerExternalId { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            string customerExternalId = context.GetValue(this.CustomerExternalId);
        }
    }
}
