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

namespace AmxPeruPSBActivities.Activities.BillingAccount
{
    public sealed class GetAvgBillActualDebt : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruGetAvgBillDebtLimitRequest> inputObject { get; set; }
        public OutArgument<AmxPeruGetAvgBillDebtLimitResponse> outputObject { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AmxPeruGetAvgBillDebtLimitRequest _request = new AmxPeruGetAvgBillDebtLimitRequest();
            AmxPeruGetAvgBillDebtLimitResponse _response = new AmxPeruGetAvgBillDebtLimitResponse();
            _request = inputObject.Get(context);
            AmxPeruGetAvgBillActualDebtBusiness _fetchDataFromOAC = new AmxPeruGetAvgBillActualDebtBusiness();
            _response = _fetchDataFromOAC.FetchDataFromOACBSCS(_request, ContextProvider.OrganizationService);
        }
    }
}