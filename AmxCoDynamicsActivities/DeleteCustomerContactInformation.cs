using AmxDynamicsActivities.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace AmxDynamicsActivities
{
    public class DeleteCustomerContactInformation : CodeActivity
    {
        [Input("Customer contact information")]
        [ReferenceTarget("amx_customercontactinformation")]
        [RequiredArgument]
        public InArgument<EntityReference> Incustomercontactinformation { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            this.Run(service, Incustomercontactinformation.Get(executionContext));
        }

        public void Run(IOrganizationService service, EntityReference customercontactinformation)
        {
            QueryExpression query = new QueryExpression("amx_customercontactinformation");
            query.Criteria.AddCondition("amx_customercontactinformationid", ConditionOperator.Equal, customercontactinformation.Id);

            EntityCollection ress = service.RetrieveMultiple(query);

            if (ress.Entities.Count > 0)
            {
                Entity encontro = ress.Entities.FirstOrDefault();

                service.Delete(encontro.LogicalName, encontro.Id);
            }
            else
            {
                throw new Exception("No Encontro el registro");
            }
        }
    }
}
