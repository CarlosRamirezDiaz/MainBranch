using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using AmxPeruCommonLibrary;
using AmxSoapServicesActivities.ContractsSearchService;
using Ericsson.PSB.Workflow.Client.Core;
using AmxSoapServicesActivities.Model;


namespace AmxSoapServicesActivities.Activities
{

    public sealed class ContractsSearchByIdActivity : XrmAwareCodeActivity
    {
        public InArgument<string> individualCustomerId { get; set; }
        public InArgument<string> bURL { get; set; }
        public OutArgument<List<AmxSoapServicesActivities.Model.ContractsSearchResponse>> contractresponse { get; set; }


        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var customerID = individualCustomerId.Get(context);
            Guid individualId = new Guid(customerID);

            var bscsURL = bURL.Get(context);
            //var bscsURL = "http://localhost:9090/wsi/services";
            var identityExtension = context.GetExtension<UserIdentityExtension>();
            var contractsSearchBusiness = new AmxSoapServicesActivities.Business.ContractsSearchBusiness();

            try
            {
                var response = contractsSearchBusiness.contractsSearchById(bscsURL, individualId, identityExtension, ContextProvider.OrganizationService);

                context.SetValue(contractresponse, response);

            }
            catch (Exception ex)
            {
                context.SetValue(contractresponse, ex.Message);
            }
        }
    }
}
