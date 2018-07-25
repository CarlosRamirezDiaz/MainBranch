using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AmxWorkflowPlugin
{
    public sealed partial class AppointmentLogCWA : CodeActivity
    {
        [Input("Contact List Name")]
        public InArgument<string> ContactListName { get; set; }
        [Input("Is One Day Before?")]
        public InArgument<bool> IsOneDay { get; set; }
        [Output("Response")]
        public OutArgument<string> Response { get; set; }
        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
            try 
            {
                var conListName = ContactListName.Get(executionContext);
                var isOneDay = IsOneDay.Get(executionContext);
                var response = new AMXCommon.Business.AppointmentLog.AMXSaveContactToListBusiness().GetAppointmentLogDetails(service, context.PrimaryEntityId, conListName, isOneDay);
                Response.Set(executionContext, response.responseStatus.description);

            }
            catch(Exception ex){
                throw new InvalidPluginExecutionException(ex.Message);
            }
        }
    }
}
