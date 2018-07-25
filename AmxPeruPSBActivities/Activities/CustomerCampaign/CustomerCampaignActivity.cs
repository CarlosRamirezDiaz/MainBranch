using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model.CustomerCampaign;
using AmxPeruPSBActivities.Service.CustomerCampaign;

namespace AmxPeruPSBActivities.Activities.CustomerCampaign
{
    public class CustomerCampaignActivity : XrmAwareCodeActivity
    {
        public InArgument<CustomerCampaignRequest> custCampaignRequest { get; set; }

        public OutArgument<CustomerCampaignResponse> custCampaignResponse { get; set; }
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {

            
            CustomerCampaignService objCustomerCampaignService = new CustomerCampaignService();
            CustomerCampaignResponse objResponse= objCustomerCampaignService.GetCustomerCampaignList(custCampaignRequest.Get(context), ContextProvider.OrganizationService);
            custCampaignResponse.Set(context, objResponse);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
