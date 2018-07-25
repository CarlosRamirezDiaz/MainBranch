using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ExternalApiActivities.Common;
using AmxPeruPSBActivities.Model.OrderMilestone;
using Ericsson.ETELCRM.Entities.Crm;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.OrderMilestone
{

    public  class AmxPeruSetOrderMilestoneActivity : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruSetOrderMilestoneRequest> inputObject { get; set; }
        public OutArgument<AmxPeruSetOrderMilestoneResponse> outputObject { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {

            AmxPeruSetOrderMilestoneResponse _AmxPeruSetOrderMilestoneResponse = null;
            try
            {
                AmxPeruSetOrderMilestoneBusiness _AmxPeruSetOrderMilestoneBusiness = new AmxPeruSetOrderMilestoneBusiness();

                _AmxPeruSetOrderMilestoneResponse = _AmxPeruSetOrderMilestoneBusiness.SetOrderStatus(inputObject.Get(context), ContextProvider.OrganizationService);

                //call business layer method for processing

                _AmxPeruSetOrderMilestoneResponse.Status = "SUCCESS";

                //Set Values for the Out Parameter/Argument
                context.SetValue(outputObject, _AmxPeruSetOrderMilestoneResponse);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
