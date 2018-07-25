using AmxPeruPSBActivities.Business;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model.CustomerEmailBilling;
using AmxPeruPSBActivities.Model;


namespace AmxPeruPSBActivities.Activities
{
    public class AmxCoCustomerEmailBillingActivity : XrmAwareCodeActivity
    {

        public InArgument<AmxCoCustomerEmailBillingRequest> AmxCoCustomerEmailBillingRequest { get; set; }
        public InArgument<string> ParadigmaUpdateMailURL { get; set; }

        public OutArgument<AmxPeruPSBActivities.Model.CustomerEmailBilling.AmxCoCustomerEmailBillingRespose> AmxCoCustomerEmailBillingRespose { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {

            var AmxCoCustomerEmailBillingBusiness = new AmxCoCustomerEmailBillingBusiness();
            AmxCoCustomerEmailBillingRequest request = context.GetValue(this.AmxCoCustomerEmailBillingRequest);
            string ParadigmaUpdateMailURL = context.GetValue(this.ParadigmaUpdateMailURL);

            try
            {
                var response = AmxCoCustomerEmailBillingBusiness.SendNotification(ParadigmaUpdateMailURL, request, ContextProvider.OrganizationService);

                context.SetValue(AmxCoCustomerEmailBillingRespose, response);

            }
            catch (Exception ex)
            {
                context.SetValue(AmxCoCustomerEmailBillingRespose, ex.Message);
            }
        }
    }


}