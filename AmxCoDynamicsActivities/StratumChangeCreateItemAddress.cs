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
    public class StratumChangeCreateItemAddress : CodeActivity
    {
        [Input("Cambio de estrato")]
        [ReferenceTarget("amx_stratumchange")]
        [RequiredArgument]
        public InArgument<EntityReference> InStratumChange { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            this.Run(service, InStratumChange.Get(executionContext));
        }

        public void Run(IOrganizationService service, EntityReference erStratumChange)
        {
            Entity eStratumChange = service.Retrieve(erStratumChange.LogicalName, erStratumChange.Id, new ColumnSet("amx_individualcustomer"));

            if (eStratumChange != null)
            {
                if (eStratumChange.Contains("amx_individualcustomer"))
                {
                    QueryExpression query = new QueryExpression("etel_customeraddress");
                    query.ColumnSet = new ColumnSet("etel_customeraddressid");
                    query.Criteria.AddCondition("etel_individualcustomerid", ConditionOperator.Equal, ((EntityReference)eStratumChange["amx_individualcustomer"]).Id);

                    LinkEntity leDetailsTechnicals = new LinkEntity("etel_customeraddress", "amx_bimgltechnicaldetails", "etel_customeraddressid", "amx_customeraddressid", JoinOperator.Inner);
                    leDetailsTechnicals.Columns = new ColumnSet("amx_stratum");
                    leDetailsTechnicals.EntityAlias = "mgltd";

                    query.LinkEntities.Add(leDetailsTechnicals);

                    EntityCollection ecAddress = service.RetrieveMultiple(query);

                    foreach (Entity eAddress in ecAddress.Entities)
                    {
                        Entity createItemSC = new Entity("amx_stratumchangeitem");
                        createItemSC["amx_stratumchange"] = erStratumChange;
                        createItemSC["amx_customeraddress"] = new EntityReference("etel_customeraddress", (Guid)eAddress["etel_customeraddressid"]);
                        if (eAddress.Contains("mgltd.amx_stratum")) createItemSC["amx_mglcrmstratum"] = ((AliasedValue)eAddress["mgltd.amx_stratum"]).Value.ToString();
                        createItemSC["amx_billingstratum"] = "";

                        service.Create(createItemSC);
                    }
                }
            }
        }
    }
}
