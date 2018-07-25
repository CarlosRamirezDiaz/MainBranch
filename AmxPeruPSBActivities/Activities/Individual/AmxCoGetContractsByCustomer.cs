using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model.Individual;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.Individual
{
    public class AmxCoGetContractsByCustomer: XrmAwareCodeActivity
    {
        public InArgument<AmxCoGetContractsByCustomerRequest> objAmxCoGetContractsByCustomerRequest { get; set; }

        public OutArgument<AmxCoGetContractsByCustomerResponse> objAmxCoGetContractsByCustomerResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                AmxCoGetContractsByCustomerBusiness business = new AmxCoGetContractsByCustomerBusiness();
                AmxCoGetContractsByCustomerResponse objResponse = business.AmxCoGetContractsByCustomer(ContextProvider.OrganizationService, objAmxCoGetContractsByCustomerRequest.Get(context));
                objAmxCoGetContractsByCustomerResponse.Set(context, objResponse);
            }
            catch (Exception)
            {

            }
        }
    }
}
