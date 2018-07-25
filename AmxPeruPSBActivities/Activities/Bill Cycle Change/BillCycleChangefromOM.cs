using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;

using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.Bill_Cycle_Change
{
  public sealed class BillCycleChangefromOM : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruBillCycleChangefromOMRequest> inputObject { get; set; }
        public OutArgument<AmxPeruBillCycleChangefromOMResponse> outputObject { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AmxPeruBillCycleChangefromOMResponse _AmxPeruBillCycleChangefromOMResponse = null;
            try
            {
                AmxPeruBillCycleChangefromOMBusiness _AmxPeruBillCycleChangefromOMBusiness = new AmxPeruBillCycleChangefromOMBusiness();

                _AmxPeruBillCycleChangefromOMResponse = _AmxPeruBillCycleChangefromOMBusiness.AmxPeruBillCycleChangefromOMValues(inputObject.Get(context), ContextProvider.OrganizationService);

                //call business layer method for processing

                _AmxPeruBillCycleChangefromOMResponse.Status = "SUCCESS";

                //Set Values for the Out Parameter/Argument
                context.SetValue(outputObject, _AmxPeruBillCycleChangefromOMResponse);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
