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
    public class StratumChangeReplicateFromBI : CodeActivity
    {
        [Input("Stratum change")]
        [ReferenceTarget("amx_stratumchange")]
        [RequiredArgument]
        public InArgument<EntityReference> InStratumChange { get; set; }

        [Input("Incident description")]
        [RequiredArgument]
        public InArgument<string> InDescription { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            this.Run(service, InStratumChange.Get(executionContext), InDescription.Get(executionContext));
        }

        public void Run(IOrganizationService service, EntityReference erStratumChange, string description)
        {
            if (description.Contains("Cambio de estrato ") && description.Contains(" a estrato "))
            {
                QueryExpression query = new QueryExpression("amx_stratumchangeitem");
                query.ColumnSet = new ColumnSet("amx_newstratum");
                query.Criteria.AddCondition("amx_stratumchange", ConditionOperator.Equal, erStratumChange.Id);
                query.Criteria.AddCondition("amx_newstratum", ConditionOperator.NotNull);

                LinkEntity leAddress = new LinkEntity("amx_stratumchangeitem", "etel_customeraddress", "amx_customeraddress", "etel_customeraddressid", JoinOperator.Inner);
                leAddress.Columns = new ColumnSet(false);

                LinkEntity leTechnicalDetails = new LinkEntity("etel_customeraddress", "amx_bimgltechnicaldetails", "etel_customeraddressid", "amx_customeraddressid", JoinOperator.Inner);
                leTechnicalDetails.Columns = new ColumnSet("amx_bimgltechnicaldetailsid");
                leTechnicalDetails.EntityAlias = "td";

                leAddress.LinkEntities.Add(leTechnicalDetails);
                query.LinkEntities.Add(leAddress);

                EntityCollection ecItemsStratum = service.RetrieveMultiple(query);

                if (ecItemsStratum.Entities.Count > 0)
                {
                    if (ecItemsStratum.Entities[0].Contains("td.amx_bimgltechnicaldetailsid"))
                    {
                        Entity eTechnicalsDetails = new Entity("amx_bimgltechnicaldetails");
                        eTechnicalsDetails.Id = (Guid)((AliasedValue)ecItemsStratum.Entities[0]["td.amx_bimgltechnicaldetailsid"]).Value;
                        eTechnicalsDetails["amx_stratum"] = ((OptionSetValue)ecItemsStratum.Entities[0]["amx_newstratum"]).Value.ToString();

                        service.Update(eTechnicalsDetails);
                    }                    
                }
            }
        }
    }
}
