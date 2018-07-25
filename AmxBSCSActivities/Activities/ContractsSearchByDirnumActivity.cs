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

    public sealed class ContractsSearchByDirnumActivity : XrmAwareCodeActivity
    {
        public InArgument<string> dirNum { get; set; }
        public InArgument<string> bscsURL { get; set; }
        public OutArgument<List<AmxSoapServicesActivities.Model.ContractsSearchResponse>> contractresponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            var Dirnum = dirNum.Get(context);
            var bURL = bscsURL.Get(context);
            var identityExtension = context.GetExtension<UserIdentityExtension>();
            var contractsSearchBusiness = new AmxSoapServicesActivities.Business.ContractsSearchBusiness();

            try
            {
                var response = contractsSearchBusiness.contractsSearchByDirnum(bURL, Dirnum, identityExtension, ContextProvider.OrganizationService);

                context.SetValue(contractresponse, response);

            }
            catch (Exception ex)
            {
                context.SetValue(contractresponse, ex.Message);
            }
        }
    }
}
