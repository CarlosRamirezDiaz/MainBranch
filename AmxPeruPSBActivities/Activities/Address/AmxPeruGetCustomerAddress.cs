using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.Address
{
    public class AmxPeruGetCustomerAddress : XrmAwareCodeActivity
    {

        public InArgument<AmxPeruGetCustomerAddressRequest> CustomerAddressRequest { get; set; }

        public OutArgument<AmxPeruGetCustomerAddressResponse> CustomerAddressResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {   
            var request = CustomerAddressRequest.Get(context);
            AmxPeruGetCustomerAddressResponse AddressResponse = null;
            if(request != null)
            {
                AddressResponse = new AmxPeruGetCustomerAddressResponse();
                AmxPeruCustomerAddressBusiness _business = new AmxPeruCustomerAddressBusiness();
                AddressResponse = _business.getCustomerAddresses(request, ContextProvider.OrganizationService);
            }
            CustomerAddressResponse.Set(context, AddressResponse);
        }
    }
}
