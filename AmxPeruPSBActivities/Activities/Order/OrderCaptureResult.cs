using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using AmxPeruPSBActivities.Model.OrderCaptureSubmit;
using AmxPeruCommonLibrary;
using Ericsson.PSB.Workflow.Client.Core;
using AmxPeruCommonLibrary.ServiceContracts.Model;
using AmxPeruCommonLibrary.ServiceContracts.Services;
using AmxPeruPSBActivities.Model.DirectoryNumberRead;
using AmxPeruCommonLibrary.BssServiceConfigMgmt;

namespace AmxPeruPSBActivities.Activities.Order
{


    public class OrderCaptureResult : XrmAwareCodeActivity
    {
        public InArgument<SubmitOrderRequest> OmResponse { get; set; }

        public InArgument<Exception> OMException { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var omResponse = OmResponse.Get(context);
            var oMException = OMException.Get(context);


        }
    }
}
