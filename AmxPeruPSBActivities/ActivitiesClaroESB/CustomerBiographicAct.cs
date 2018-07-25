using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk.Client;
using AmxPeruPSBActivities.Repository;


namespace AmxPeruPSBActivities.ActivitiesClaroESB
{

    public sealed class CustomerBiographicAct : XrmAwareCodeActivity
    {

        public InArgument<string> individualCustomerId { get; set; }
        public InArgument<string> bureauURL { get; set; }

        public OutArgument<string> custBiographicResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {

            var customerID = individualCustomerId.Get(context);

            string response = "";

            var bureauBusiness = new AmxCoPSBActivities.BusinessClaroESB.CustomerBiographicBusiness();

            string bURL = bureauURL.Get(context);
            //string bURL = "http://localhost:58002/Bureau/V1.0/Rest/GetBureau";

            try
            {
                response = bureauBusiness.GetCustomerBiographicBusiness(bURL, new Guid(customerID), ContextProvider.OrganizationService);

                context.SetValue(custBiographicResponse, response);
            }
            catch (Exception ex)
            {
                context.SetValue(custBiographicResponse, ex.Message);
            }
        }
    }
}
