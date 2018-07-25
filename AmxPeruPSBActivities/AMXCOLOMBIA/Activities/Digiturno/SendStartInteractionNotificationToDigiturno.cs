using AmxCoPSBActivities.Model;
using AmxCoPSBActivities.Model.Digiturno;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Activities.Digiturno
{
    public sealed class SendStartInteractionNotificationToDigiturno : XrmAwareCodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> biSpecificationName { get; set; }
        public InArgument<string> userId { get; set; }
        public InArgument<string> digiturnoUrl { get; set; }
        public OutArgument<BaseResponse<DigiturnoNotifyEventTurnResponse>> response { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var response = new BaseResponse<DigiturnoNotifyEventTurnResponse>();

            try
            {
                // Obtain the digiturno IdBusinessInteraction
                var digiturnoBusiness = new AmxCoPSBActivities.BusinessClaroESB.AmxCoDigiturnoBusiness();

                var notifyResponse = digiturnoBusiness.SendStartNotificationToDigiturno(context.GetValue(this.biSpecificationName), new Guid(context.GetValue(this.userId)), context.GetValue(this.digiturnoUrl), ContextProvider.OrganizationService);

                response.Success = true;
                response.Value = notifyResponse;
                context.SetValue(this.response, response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                context.SetValue(this.response, response);
            }
        }
    }
}
