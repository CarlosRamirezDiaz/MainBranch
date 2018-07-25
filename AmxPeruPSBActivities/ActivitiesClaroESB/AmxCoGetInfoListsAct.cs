using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using ExternalApiActivities.Common;
using AmxPeruPSBActivities.Repository;
using AmxPeruPSBActivities.Model.Listas;


namespace AmxPeruPSBActivities.ActivitiesClaroESB
{

    public sealed class AmxCoGetInfoListsAct : XrmAwareCodeActivity
    {
        public InArgument<string> individualCustomerId { get; set; }
        public InArgument<string> listasURL { get; set; }
        
        public OutArgument<AmxCoGetListsResponse> ListasResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var customerID = individualCustomerId.Get(context);

            var listasBusiness = new AmxCoPSBActivities.BusinessClaroESB.AmxCoListasBusiness();

            string bURL = listasURL.Get(context);

            try
            {
                var response = listasBusiness.GetListas(bURL, new Guid(customerID), ContextProvider.OrganizationService);

                context.SetValue(ListasResponse, response);

            }
            catch (Exception ex)
            {
                context.SetValue(ListasResponse, ex.Message);
            }
        }
    }
}
