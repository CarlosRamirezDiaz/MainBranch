using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model.CheckDebtAccount;
using AmxPeruPSBActivities.Service.CheckDebtAccount;

namespace AmxPeruPSBActivities.Activities.CheckDebtAccount
{
    public class GetDebtAccountStatus : XrmAwareCodeActivity
    {
        public InArgument<CheckDebtAccountRequest> request { get; set; }

        public OutArgument<CheckDebtAccountResponse> response { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                CheckDebtAccountStatusService objCheckDebtAccountStatusService = new CheckDebtAccountStatusService();
                var objResponse= objCheckDebtAccountStatusService.GetDebtAccountStatus(request.Get(context), ContextProvider.OrganizationService);
                response.Set(context, objResponse);
            }
            catch(System.Exception ex)
            {
            }
        }
    }
}
