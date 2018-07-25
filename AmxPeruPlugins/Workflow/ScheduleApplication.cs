using Ericsson.ETELCRM.Business;
using Ericsson.ETELCRM.CrmFoundationLibrary.Integration;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPlugins.Workflow
{
    public class ScheduleApplication : CodeActivity
    {
        protected override void Execute(CodeActivityContext executionContext)
        {
            var actionContext = BusinessInitializer.BuildWorkflowContext(executionContext);
            var context = executionContext.GetExtension<IWorkflowContext>();

            try
            {
                if (context.PrimaryEntityName == "amx_scheduledapplication")
                {
                    var scheduledapplication = actionContext.OrganizationService.Retrieve("amx_scheduledapplication", context.PrimaryEntityId, new Microsoft.Xrm.Sdk.Query.ColumnSet(true));

                    if (scheduledapplication != null)
                    {
                        if (scheduledapplication.Attributes["amx_name"].ToString() == "Order")
                        {
                            DateTime t = DateTime.Now;
                            var result = actionContext.OrganizationService.RetrieveMultiple(new QueryExpression
                            {
                                EntityName = etel_ordercapture.EntityLogicalName,
                                ColumnSet = new ColumnSet(true),
                                Criteria = new FilterExpression() { Conditions =
                                    {
                                        new ConditionExpression("statuscode", ConditionOperator.Equal, etel_ordercapture_statuscode.Draft),
                                        new ConditionExpression("createdon", ConditionOperator.OnOrBefore, t.AddDays(-30))
                                    }

                                }
                            });

                            if (result.Entities.Count >0)
                            {
                                foreach (var order in result.Entities)
                                {
                                    SetStatus(etel_ordercapture.EntityLogicalName, order.Id, (int)etel_ordercaptureState.Inactive, (int)etel_ordercapture_statuscode.Expired, actionContext);
                                }
                            }

                            Entity scheduledapplicationEntity = new Entity("amx_scheduledapplication");
                            //scheduledapplicationEntity.Id = scheduledapplication.Id;

                            var date = scheduledapplicationEntity.Contains("amx_nextexecutedate") ? Convert.ToDateTime(scheduledapplicationEntity.Attributes["amx_nextexecutedate"].ToString()) : DateTime.Now;

                            scheduledapplicationEntity.Attributes["amx_name"] = "Order";
                            scheduledapplicationEntity.Attributes["amx_nextexecutedate"] = date.AddDays(1);
                            scheduledapplicationEntity.Attributes["amx_lastexecutedate"] = DateTime.Now;
                            actionContext.OrganizationService.Create(scheduledapplicationEntity);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                var log = actionContext.Resolve<IExceptionLogBL>().HandleProcessError(ex);
                throw new Exception(ex.Message);
            }
        }

        private void SetStatus(string entityName, Guid entityId, int stateCode, int statusCode, IActionContext actionContext)
        {
            SetStateRequest req = new SetStateRequest();
            req.EntityMoniker = new EntityReference(entityName, entityId);

            req.State = new OptionSetValue(stateCode);
            req.Status = new OptionSetValue(statusCode);
            actionContext.OrganizationService.Execute(req);
        }

    }
}
