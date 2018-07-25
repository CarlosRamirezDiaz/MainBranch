using AmxCoPSBActivities.Model;
using AmxPeruPSBActivities.AMXCOLOMBIA.Business.Individual;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.Individual;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Newtonsoft.Json;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Activities.Individual
{
    public class AmxGetMobileCustomerInfo : XrmAwareCodeActivity
    {
        public InArgument<string> mobileNumber { get; set; }
        public OutArgument<BaseResponse<AmxGetMobileCustomerInfoResponse>> AmxGetCustomerInfoResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var getCustomerMobileInfoBusiness = new AmxGetMobileCustomerInfoBusiness(ContextProvider.OrganizationService);

            var response = getCustomerMobileInfoBusiness.GetMobileCustomerInfo(this.mobileNumber.Get(context));

            this.AmxGetCustomerInfoResponse.Set(context, response);
        }
    }
}
