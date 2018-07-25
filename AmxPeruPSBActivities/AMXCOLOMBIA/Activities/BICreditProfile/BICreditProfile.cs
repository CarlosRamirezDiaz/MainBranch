using AmxPeruPSBActivities.AMXCOLOMBIA.Business.BICreditProfile;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.BICreditProfile;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System.Activities;


namespace AmxPeruPSBActivities.AMXCOLOMBIA.Activities.BICreditProfile
{
    public class BICreditProfile : XrmAwareCodeActivity
    {
        #region Input/Output Arguments
        public InArgument<BICreditProfileRequest> BICreditProfileRequest { get; set; }
        public OutArgument<BICreditProfileResponse> BICreditProfileResponse { get; set; }
        #endregion

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var jsonResponseStr = new BICreditProfileResponse();
            if (BICreditProfileRequest.Get(context) != null)
            {
                jsonResponseStr = new BICreditProfileBusiness().GetBICreditProfileInfo(BICreditProfileRequest.Get(context), ContextProvider.OrganizationService);
            }
            BICreditProfileResponse.Set(context, jsonResponseStr);
        }
    }
}
