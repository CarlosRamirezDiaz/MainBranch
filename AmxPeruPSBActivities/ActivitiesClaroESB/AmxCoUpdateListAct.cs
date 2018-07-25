using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using ExternalApiActivities.Common;
using AmxPeruPSBActivities.Repository;

namespace AmxPeruPSBActivities.ActivitiesClaroESB
{

    public sealed class AmxCoUpdateListAct : XrmAwareCodeActivity
    {
        public InArgument<string> individualCustomerId { get; set; }
        public InArgument<string> idReason { get; set; }
        public InArgument<string> orderId { get; set; }
        public InArgument<string> updateListURL { get; set; }

        public OutArgument<string> updateListResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var customerID = individualCustomerId.Get(context);
            var OrderId = orderId.Get(context);

            var listasBusiness = new AmxCoPSBActivities.BusinessClaroESB.AmxCoListasBusiness();

            string bURL = updateListURL.Get(context);
            string IdReason = idReason.Get(context);

            try
            {
                var response = listasBusiness.UpdateList(bURL, new Guid(customerID), ContextProvider.OrganizationService, new Guid(OrderId), IdReason);

                context.SetValue(updateListResponse, response);

            }
            catch (Exception ex)
            {
                context.SetValue(updateListResponse, ex.Message);
            }
        }
    }
}
