using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxDynamicsActivities
{
    public class AddressCustomerValidatePrimary : CodeActivity
    {
        [Input("Individual customer")]
        [ReferenceTarget("contact")]
        [RequiredArgument]
        public InArgument<EntityReference> InIndividual { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            this.Run(service, InIndividual.Get(executionContext));
        }

        public void Run(IOrganizationService service, EntityReference erIndividual)
        {
            QueryExpression query = new QueryExpression("etel_customeraddress");
            query.ColumnSet = new ColumnSet(false);
            query.Criteria.AddCondition("etel_isprimaryaddress", ConditionOperator.Equal, true);
            query.Criteria.AddCondition("etel_individualcustomerid", ConditionOperator.Equal, erIndividual.Id);

            EntityCollection ecAddress = service.RetrieveMultiple(query);

            if (ecAddress.Entities.Count > 1)
            {
                throw new InvalidPluginExecutionException("El usuario no debe tener mas de una dirección primaria.");
            }
        }
    }
}
