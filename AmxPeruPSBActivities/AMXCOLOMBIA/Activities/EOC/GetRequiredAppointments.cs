using AmxCoPSBActivities.Model;
using AmxPeruPSBActivities.AMXCOLOMBIA.Business.EOC;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.EOC;
using AmxPeruPSBActivities.Model.OrderCaptureSubmit;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.AMXCOLOMBIA.Activities.Configuration
{
    public class GetRequiredAppointments : XrmAwareCodeActivity
    {
        public InArgument<Guid> orderCaptureId { get; set; }
        public InArgument<SubmitOrderRequest> submitOrderRequest { get; set; }
        public OutArgument<BaseResponse<List<RequiredAppointment>>> requiredAppointments { get; set; }

        public OutArgument<string> hasBiOut { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var returnValue = new BaseResponse<List<RequiredAppointment>>();
            string hasBi = null;

            try
            {
                var submitOrderRequest = context.GetValue(this.submitOrderRequest);

                var eocBusiness = new EocBiBusiness(ContextProvider.OrganizationService);

                

                var appointments = eocBusiness.GetRequiredAppointments(submitOrderRequest, context.GetValue(this.orderCaptureId), ref hasBi);
                
                returnValue.Value = appointments;

                returnValue.Success = true;
            }
            catch (Exception ex)
            {
                returnValue.ErrorMessage = ex.Message;
                returnValue.Success = false;
            }

            requiredAppointments.Set(context, returnValue);
            hasBiOut.Set(context, hasBi);
        }
    }
}
