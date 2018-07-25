using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model.Case;
using AmxPeruPSBActivities.Model.InternalExternalAccount;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.InternalExternalAccount
{
    public class AmxCoCreateItemsAccountWithDataBSCS : XrmAwareCodeActivity
    {
        public InArgument<string> idIndividual { get; set; }

        public OutArgument<AmxCoCreateItemsAccountWithDataBSCSResponse> objCreateCaseHHPPResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                IWorkflowContext workflowContext = context.GetExtension<IWorkflowContext>();
                var objOpenNewCaseMLG = new AmxCoCreateItemsBABusiness();
                AmxCoCreateItemsAccountWithDataBSCSResponse objResponse = new AmxCoCreateItemsAccountWithDataBSCSResponse();
                objResponse = objOpenNewCaseMLG.CreateItemsAccountWithDataBSCS(idIndividual.Get(context), ContextProvider.OrganizationService, workflowContext.UserId);
                objCreateCaseHHPPResponse.Set(context, objResponse);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message.ToString();
                AmxCoCreateItemsAccountWithDataBSCSResponse objResponse = new AmxCoCreateItemsAccountWithDataBSCSResponse();
                objResponse.error = true;
                objResponse.message = "Error";
                objCreateCaseHHPPResponse.Set(context, objResponse);
            }
        }
    }
}
