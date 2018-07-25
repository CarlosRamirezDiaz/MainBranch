using AmxCoPSBActivities.Model;
using AmxPeruPSBActivities.AMXCOLOMBIA.Business;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.Paradigma;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Activities.Paradigma
{
    public class ParadigmaGetIFrameUrl : XrmAwareCodeActivity
    {
        public InArgument<string> individualId { get; set; }
        public InArgument<string> userId { get; set; }
        public InArgument<string> iFrameBaseUrl { get; set; }
        public OutArgument<BaseResponse<string>> response { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var returnValue = new BaseResponse<string>();

            try
            {
                var individualId = context.GetValue(this.individualId);
                var userId = context.GetValue(this.userId);
                var iFrameBaseUrl = context.GetValue(this.iFrameBaseUrl);

                var paradigmaBusiness = new ParadigmaBusiness(ContextProvider.OrganizationService);

                var iFrameUrl = paradigmaBusiness.GetIFrameUrl(new Guid(individualId), new Guid(userId), iFrameBaseUrl);

                returnValue.Value = iFrameUrl;

                returnValue.Success = true;
            }
            catch (Exception ex)
            {
                returnValue.ErrorMessage = ex.Message;
                returnValue.Success = false;
            }

            response.Set(context, returnValue);
        }
    }
}
