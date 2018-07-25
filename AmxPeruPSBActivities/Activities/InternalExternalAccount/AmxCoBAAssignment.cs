using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model.InternalExternalAccount;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.InternalExternalAccount
{
    public class AmxCoBAAssignment : XrmAwareCodeActivity
    {
        public InArgument<AmxCoBillingAccountAssignmentRequest> objRequest { get; set; }

        public OutArgument<AmxCoBillingAccountAssignmentResponse> objResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                var objAssignment = new AmxCoBAAssignmentBusiness();
                AmxCoBillingAccountAssignmentResponse objResponse = objAssignment.AssignmentContractInBA(objRequest.Get(context), ContextProvider.OrganizationService);
                this.objResponse.Set(context, objResponse);
            }
            catch (Exception)
            {

            }
        }
    }
}
