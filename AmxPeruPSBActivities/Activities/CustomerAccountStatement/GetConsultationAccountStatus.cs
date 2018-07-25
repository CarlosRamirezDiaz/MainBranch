using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using ExternalApiActivities.Common;
using AmxPeruPSBActivities.Model.CustomerAccountStatement;
using AmxPeruPSBActivities.Service.CustomerAccountStatement;

namespace AmxPeruPSBActivities.Activities.CustomerAccountStatement
{
    public class GetConsultationAccountStatus : XrmAwareCodeActivity
    {
        
        public InArgument<AMXPeruAccountConsultationRequest> request { get; set; }

        public OutArgument<AMXPeruAccountConsultationResponse> response { get; set; }
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                ConsultationAccountStatusService objService = new ConsultationAccountStatusService();
                AMXPeruAccountConsultationResponse objResponse = objService.GetConsultationAccountStatus(request.Get(context), ContextProvider.OrganizationService);
                response.Set(context, objResponse);
            }
            catch(System.Exception ex)
            {

            }
        }
    }
}
