using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model.StratumChange;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.StratumChange
{
    public class StratumChangeCreateItemAddress : XrmAwareCodeActivity
    {
        public InArgument<StratumChangeCreateItemRequest> obRequest { get; set; }

        public OutArgument<StratumChangeCreateItemResponse> objResponse { get; set; }
        
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                var objStratumChangeCreateitem = new AmxCoStratumChangeCreateItemBusiness();
                StratumChangeCreateItemResponse objResponseExec = objStratumChangeCreateitem.CreateItemsItemAddress(obRequest.Get(context), ContextProvider.OrganizationService);
                objResponse.Set(context, objResponseExec);
            }
            catch (Exception)
            {

            }
        }
    }
}
