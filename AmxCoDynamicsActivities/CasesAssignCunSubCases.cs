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
    public class CasesAssignCunSubCases : CodeActivity
    {
        [Input("Case")]
        [ReferenceTarget("incident")]
        [RequiredArgument]
        public InArgument<EntityReference> InIncident { get; set; }

        [Input("CUN")]
        [RequiredArgument]
        public InArgument<string> InCun { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            this.Run(service, InIncident.Get(executionContext), InCun.Get(executionContext));
        }

        public void Run(IOrganizationService service, EntityReference erIncident, string cun)
        {
            ValidateOtherMatrixCase(service, erIncident);

            QueryExpression query = new QueryExpression("incident");
            query.ColumnSet = new ColumnSet("amx_productfamily");
            query.Criteria.AddCondition("parentcaseid", ConditionOperator.Equal, erIncident.Id);
            query.Criteria.AddCondition("amx_cun", ConditionOperator.Null);
            query.Orders.Add(new OrderExpression("amx_productfamily", OrderType.Ascending));

            EntityCollection ecSubCases = service.RetrieveMultiple(query);

            string[] arrSeparator = { "," };
            string[] arrSepCun = { ":" };
            string[] arrCunFamilies = cun.Split(arrSeparator, StringSplitOptions.None);
            string firsCun = string.Empty;
            string cunsInChilds = string.Empty;

            foreach (Entity eSubcase in ecSubCases.Entities)
            {
                if (eSubcase.Contains("amx_productfamily"))
                {
                    foreach (string cunFamily in arrCunFamilies)
                    {
                        if (cunFamily.ToUpper().Contains(eSubcase["amx_productfamily"].ToString().ToUpper()))
                        {
                            string[] arrCun = cunFamily.Split(arrSepCun, StringSplitOptions.None);

                            if (string.IsNullOrEmpty(firsCun))
                            {
                                firsCun = arrCun[1];
                                cunsInChilds = arrCun[1];
                            }
                            else
                            {
                                cunsInChilds = cunsInChilds + "," + arrCun[1];
                            }                            

                            Entity eSubCaseUpdate = new Entity(eSubcase.LogicalName);
                            eSubCaseUpdate.Id = eSubcase.Id;
                            eSubCaseUpdate["amx_cun"] = arrCun[1];

                            service.Update(eSubCaseUpdate);

                            break;
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(firsCun))
            {
                Entity eSubCaseUpdate = new Entity(erIncident.LogicalName);
                eSubCaseUpdate.Id = erIncident.Id;
                eSubCaseUpdate["amx_cun"] = firsCun;
                eSubCaseUpdate["amx_cuninchilds"] = cunsInChilds;

                service.Update(eSubCaseUpdate);
            }

        }

        private void ValidateOtherMatrixCase(IOrganizationService service, EntityReference erIncident)
        {
            Entity eIncident = service.Retrieve(erIncident.LogicalName, erIncident.Id, new ColumnSet("amx_productfamily", 
                "customerid", "amx_caseid", "amx_cun"));

            if (eIncident.Contains("amx_productfamily") && eIncident.Contains("customerid") && eIncident.Contains("amx_caseid"))
            {
                QueryExpression query = new QueryExpression(erIncident.LogicalName);
                query.ColumnSet = new ColumnSet(false);
                query.Criteria.AddCondition("incidentid", ConditionOperator.Equal, erIncident.Id);
                query.Criteria.AddCondition("amx_cun", ConditionOperator.Null);
                query.Criteria.AddCondition("parentcaseid", ConditionOperator.Null);
                query.Criteria.AddCondition("amx_productfamily", ConditionOperator.Equal, eIncident["amx_productfamily"].ToString());
                query.Criteria.AddCondition("customerid", ConditionOperator.Equal, ((EntityReference)eIncident["customerid"]).Id);
                query.Criteria.AddCondition("amx_caseid", ConditionOperator.Equal, ((EntityReference)eIncident["amx_caseid"]).Id);

                EntityCollection ecCases = service.RetrieveMultiple(query);

                foreach (Entity eCase in ecCases.Entities )
                {
                    Entity eCaseUpdate = new Entity(eCase.LogicalName);
                    eCaseUpdate.Id = eCase.Id;
                    eCaseUpdate["amx_cun"] = eIncident["amx_cun"].ToString();

                    service.Update(eCaseUpdate);
                }
            }
        }
    }
}
