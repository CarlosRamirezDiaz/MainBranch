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

namespace AmxPeruPSBActivities.Activities.Individual
{
    public class AmxPeruGetCustomerContact : XrmAwareCodeActivity
    {

        public InArgument<AxmPeruCustomerContactRequest> CustomerContactRequest { get; set; }

        public OutArgument<AmxPeruCustomerContactResponse> CustomerContactResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {   
            var request = CustomerContactRequest.Get(context);
            var CustomerExternalID = request.CustomerExternalId;
            AmxPeruCustomerContactResponse ContactResponse = null;
            if(!string.IsNullOrEmpty(CustomerExternalID))
            {
                ContactResponse = new AmxPeruCustomerContactResponse();
                GetCustomerContactBusiness _business = new GetCustomerContactBusiness();                
                ContactResponse = _business.RetrieveContactData(CustomerExternalID,ContextProvider.OrganizationService);
            }

            CustomerContactResponse.Set(context, ContactResponse);
        }
    }
}
