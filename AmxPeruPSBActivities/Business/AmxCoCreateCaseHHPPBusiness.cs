using AmxPeruPSBActivities.Model.Case;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Business
{
    public class AmxCoCreateCaseHHPPBusiness
    {
        public AmxCoCreateCaseHHPPResponse CreateCaseHHPP(AmxCoCreateCaseHHPPRequest request, OrganizationServiceProxy service)
        {
            AmxCoCreateCaseHHPPResponse response = new AmxCoCreateCaseHHPPResponse();

            try {
                Entity eIncidentCreate = new Entity("incident");
                if (!string.IsNullOrEmpty(request.description)) eIncidentCreate["description"] = request.description;

                if (!string.IsNullOrEmpty(request.caseType))
                {

                    QueryExpression paramCaseType = new QueryExpression("etel_crmconfiguration");
                    paramCaseType.ColumnSet = new ColumnSet("etel_value");
                    paramCaseType.Criteria.AddCondition("etel_name", ConditionOperator.Equal, request.caseType);

                    EntityCollection ecParamCaseType = service.RetrieveMultiple(paramCaseType);

                    if (ecParamCaseType.Entities.Count > 0)
                    {
                        QueryExpression queryCaseType = new QueryExpression("amxperu_casetype");
                        queryCaseType.ColumnSet = new ColumnSet(false);
                        queryCaseType.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, ecParamCaseType.Entities[0]["etel_value"].ToString());

                        EntityCollection ecCaseType = service.RetrieveMultiple(queryCaseType);

                        if (ecCaseType.Entities.Count > 0)
                        {
                            eIncidentCreate["amxperu_casetype"] = ecCaseType.Entities[0].ToEntityReference();
                        }
                    }                    
                }

                if (!string.IsNullOrEmpty(request.individualId))
                {
                    eIncidentCreate["customerid"] = new EntityReference("contact", Guid.Parse(request.individualId));

                    QueryExpression queryOrderCapture = new QueryExpression("etel_ordercapture");
                    queryOrderCapture.ColumnSet = new ColumnSet("ownerid");
                    queryOrderCapture.Criteria.AddCondition("etel_individualcustomerid", ConditionOperator.Equal, Guid.Parse(request.individualId));
                    queryOrderCapture.Orders.Add(new OrderExpression("createdon", OrderType.Descending));

                    EntityCollection ecOrderCap = service.RetrieveMultiple(queryOrderCapture);

                    if (ecOrderCap.Entities.Count > 0)
                    {
                        eIncidentCreate["amx_bimanagerwithcustomer"] = (EntityReference)ecOrderCap.Entities[0]["ownerid"];
                    }
                }                

                Guid idCase = service.Create(eIncidentCreate);
                response.caseId = idCase.ToString();

                Entity eIncident = service.Retrieve("incident", idCase, new ColumnSet("ticketnumber"));

                if (eIncident.Contains("ticketnumber"))
                {
                    response.numberId = eIncident["ticketnumber"].ToString();
                }
            }
            catch (Exception ex)
            {
                response.error = true;
                response.messageError = ex.Message;
            }

            return response;
        }
    }
}
