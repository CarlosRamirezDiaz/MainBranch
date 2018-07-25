using AmxCoPSBActivities.Model;
using AmxPeruPSBActivities.AMXCOLOMBIA.Business.BI_Log;
using AmxPeruPSBActivities.AMXCOLOMBIA.Business.Individual;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.BI_Log;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Activities.BI_Log
{
    public class AmxBiLogAdd : XrmAwareCodeActivity
    {
        public InArgument<AmxBiLogAddRequest> request { get; set; }
        public OutArgument<BaseResponse<AmxBiLogAddResponse>> response { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var amxBiLogBusiness = new AmxBiLogBusiness(ContextProvider.OrganizationService);

            var response = amxBiLogBusiness.AddBiLog(this.request.Get(context));

            this.response.Set(context, response);
        }
    }
}
