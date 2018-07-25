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
    public class AmxPeruCreateCustomerAddress : XrmAwareCodeActivity
    {

        public InArgument<AmxPeruCustomerAddressRequest> CustomerAddressRequest { get; set; }

        public OutArgument<AmxPeruCustomerAddressResponse> CustomerAddressResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {   
            var request = CustomerAddressRequest.Get(context);
            AmxPeruCustomerAddressResponse AddressResponse = null;
            if(request != null)
            {
                AddressResponse = new AmxPeruCustomerAddressResponse();
                AmxPeruCustomerAddressBusiness _business = new AmxPeruCustomerAddressBusiness();
                AddressResponse = _business.CreateAddress(request, ContextProvider.OrganizationService);
            }

            CustomerAddressResponse.Set(context, AddressResponse);
        }
    }
}
