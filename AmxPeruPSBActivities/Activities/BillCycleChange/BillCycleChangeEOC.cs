using AmxPeruPSBActivities.AMXCOLOMBIA.Business.BillCycleChange;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.BI_Log;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Activities.BillCycleChange
{
    public class BillCycleChangeEOC : XrmAwareCodeActivity
    {
        #region Input/Output Arguments
        public InArgument<BillCycleChangeEOCRequest> BillCycleChangeEOCRequest { get; set; }

        public InArgument<BILogSchema> BILogSchemaRequest { get; set; }
        public OutArgument<bool> BillCycleChangeEOCResponse { get; set; }
        #endregion

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            bool jsonResponseStr = false;
            if (BillCycleChangeEOCRequest.Get(context) != null)
            {
                jsonResponseStr = new BillCycleChangeSubmitToEOC().SubmitEOCForBillCycleChange(BillCycleChangeEOCRequest.Get(context), ContextProvider.OrganizationService, BILogSchemaRequest.Get(context));
            }
            BillCycleChangeEOCResponse.Set(context, jsonResponseStr);
        }
    }
}
