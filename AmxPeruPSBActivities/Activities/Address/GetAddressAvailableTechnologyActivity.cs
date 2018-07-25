using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.Address
{

    public sealed class GetAddressAvailableTechnologyActivity : XrmAwareCodeActivity
    {
        public InArgument<string> AddressId { get; set; }
        public OutArgument<string> Technology { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            string addressId = context.GetValue(AddressId);
            var addressBusiness = new CustomerAddressBusiness(ContextProvider);
            context.SetValue(Technology, addressBusiness.GetAddressTechnology(addressId));
        }
    }
}
