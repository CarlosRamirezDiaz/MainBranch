using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using Microsoft.Xrm.Sdk;
using AmxPeruPSBActivities.Model.Task;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.Task
{

    public sealed class CreateTaskInCrm : XrmAwareCodeActivity
    {

        public InArgument<AmxPeruCreateTaskRequest> CreateTaskRequest { get; set; }
        public OutArgument<AmxPeruCreateTaskResponse> CreateTaskResponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var request = CreateTaskRequest.Get(context);
            AmxPeruCreateTaskResponse response = null;
            if (request != null)
            {
                response = new AmxPeruCreateTaskResponse();

                AmxPeruCreateTaskBusiness _business = new AmxPeruCreateTaskBusiness();
                response = _business.CreateTask(request, ContextProvider.OrganizationService);
            }
            CreateTaskResponse.Set(context, response);
        }
    }
}