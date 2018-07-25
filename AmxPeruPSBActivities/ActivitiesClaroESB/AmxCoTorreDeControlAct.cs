using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using AmxCoPSBActivities.BusinessClaroESB;
using AmxCoPSBActivities.Model.TorreDeControl;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using AmxPeruPSBActivities.Repository;


namespace AmxPeruPSBActivities.ActivitiesClaroESB
{

    public sealed class AmxCoTorreDeControlAct : XrmAwareCodeActivity
    {
        public InArgument<AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlRequest> AmxCoTorreDeControlRequest { get; set; }
        public InArgument<string> torreDeControlURL { get; set; }

        public OutArgument<AmxCoPSBActivities.Model.TorreDeControl.AmxCoTorreDeControlResponse> AmxCoTorreDeControlResponse { get; set; }
        
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            
            var torreDeControlBusiness = new AmxCoPSBActivities.BusinessClaroESB.AmxCoTorreDeControlBusiness();
            AmxCoTorreDeControlRequest request = context.GetValue(this.AmxCoTorreDeControlRequest);
            string torreURL = context.GetValue(this.torreDeControlURL);

            try
            {
                var response = torreDeControlBusiness.SendNotification(torreURL, request, ContextProvider.OrganizationService);

                context.SetValue(AmxCoTorreDeControlResponse, response);

            }
            catch (Exception ex)
            {
                context.SetValue(AmxCoTorreDeControlResponse, ex.Message);
            }
        }
    }
}
