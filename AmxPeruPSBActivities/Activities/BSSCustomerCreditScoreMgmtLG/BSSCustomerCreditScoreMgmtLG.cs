using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model.BSSCustomerCreditScoreMgmtLG;
using AmxPeruPSBActivities.Service.BSSCustomerCreditScoreMgmtLG;

namespace AmxPeruPSBActivities.Activities.BSSCustomerCreditScoreMgmtLG
{
    public class BSSCustomerCreditScoreMgmtLG : XrmAwareCodeActivity
    {
        public InArgument<AMXPeruBSSCustomerCreditScoreMgmtLGRequest> creditScorerequest { get; set; }

        public OutArgument<AMXPeruBSSCustomerCreditScoreMgmtLGResponse> creditScoreresponse { get; set; }
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            //BSSCustomerCreditScoreMgmtLGStatusService objService = new BSSCustomerCreditScoreMgmtLGStatusService();
            //AMXPeruBSSCustomerCreditScoreMgmtLGResponse objResponse = objService.GetBSSCustomerCreditScoreMgmtLGStatus(creditScorerequest.Get(context), ContextProvider.OrganizationService);
            //creditScoreresponse.Set(context, objResponse);
                       
            try
            {
                AMXPeruBSSCustomerCreditScoreMgmtLGResponse _AMXPeruBSSCustomerCreditScoreMgmtLGResponse = new AMXPeruBSSCustomerCreditScoreMgmtLGResponse();
                //AMXPeruBSSCustomerCreditScoreMgmtLGResponse _AMXPeruBSSCustomerCreditScoreMgmtLGResponse = null;
                BSSCustomerCreditScoreMgmtLGStatusService _BSSCustomerCreditScoreMgmtLGStatusService = new BSSCustomerCreditScoreMgmtLGStatusService();
                _AMXPeruBSSCustomerCreditScoreMgmtLGResponse = _BSSCustomerCreditScoreMgmtLGStatusService.GetBSSCustomerCreditScoreMgmtLGStatus(creditScorerequest.Get(context), ContextProvider.OrganizationService);
                creditScoreresponse.Set(context, _AMXPeruBSSCustomerCreditScoreMgmtLGResponse);

            }

            catch (Exception ex)
            {
                throw;

            }
        }
    }
}
