using AmxCoPSBActivities.Repository.Factory;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model;
using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model.OrderCapture;
using AmxPeruPSBActivities.Model.OrderCaptureSubmit;
using AmxPeruPSBActivities.Repository;
using Ericsson.ETELCRM.Entities.Crm;
using Ericsson.ETELCRM.Entities.Crm.CustomEntities;
using ExternalApiActivities.Common;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AmxCoPSBActivities.AMXCOLOMBIA.Activities.Order
{
    public class GenerateEOCRequestActivity : XrmAwareCodeActivity
    {
        public InArgument<Guid> OrderCaptureId { get; set; }

        public OutArgument<SubmitOrderRequest> SubmitRequest { get; set; }
        
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            SubmitOrderRequest request = new SubmitOrderRequest();

            request = (new OrderCaptureBusiness(ContextProvider.OrganizationService).retrieveEOCBiRequest(OrderCaptureId.Get(context), ContextProvider.OrganizationService, dataContext, context));

            SubmitRequest.Set(context, request);
        }
    }
}