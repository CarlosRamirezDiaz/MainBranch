using AmxPeruPSBActivities.Model.Case;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Business
{
    public class AmxPeruCreateCaseBusiness
    {
        public CaseResponse CreateCaseOnCRM(CaseRequest request, OrganizationServiceProxy organizationService)
        {
            try
            {
                CaseResponse response = new CaseResponse();
                #region "Properti assignment"
                Entity caseEntity = new Entity("incident");
                Guid CustomerGuid = Guid.Empty;

                if (!string.IsNullOrEmpty(request.CustomerId.Trim()))
                {
                    if (request.CustomerType == 1 || request.CustomerType == 2)
                    {
                        if (request.CustomerType == 1)
                        {
                            CustomerGuid = GetLookupGuidFromField("contact", "etel_externalid", request.CustomerId, organizationService);
                            caseEntity.Attributes.Add("customerid", new EntityReference("contact", CustomerGuid));
                        }
                        else if (request.CustomerType == 2)
                        {
                            CustomerGuid = GetLookupGuidFromField("account", "etel_externalid", request.CustomerId, organizationService);
                            caseEntity.Attributes.Add("customerid", new EntityReference("account", CustomerGuid));
                        }
                    }
                }
                
                if (!string.IsNullOrEmpty(request.CaseTitle.Trim()))
                    caseEntity.Attributes.Add("title", request.CaseTitle);

                if (!string.IsNullOrEmpty(request.CaseType))
                {
                    Guid caseTypeGuid = GetLookupGuidFromField("amxperu_casetype", "amxperu_name", request.CaseType, organizationService);
                    if (caseTypeGuid != Guid.Empty)
                    {
                        caseEntity.Attributes.Add("amxperu_casetype", new EntityReference("amxperu_casetype", caseTypeGuid));
                    }
                }

                if (!string.IsNullOrEmpty(request.caseTypeCategory1))
                {
                    Guid caseTypeGuid = GetLookupGuidFromField("amxperu_casecategory", "amxperu_name", request.caseTypeCategory1, organizationService);
                    if (caseTypeGuid != Guid.Empty)
                    {
                        caseEntity.Attributes.Add("amxperu_casecategory", new EntityReference("amxperu_casecategory", caseTypeGuid));
                    }
                }

                if (!string.IsNullOrEmpty(request.caseTypeCategory2))
                {
                    Guid caseTypeGuid = GetLookupGuidFromField("amxperu_casesubcategory", "amxperu_name", request.caseTypeCategory2, organizationService);
                    if (caseTypeGuid != Guid.Empty)
                    {
                        caseEntity.Attributes.Add("amxperu_casesubcategory", new EntityReference("amxperu_casesubcategory", caseTypeGuid));
                    }
                }
                if (!string.IsNullOrEmpty(request.caseTypeCategory3))
                {
                    Guid caseTypeGuid = GetLookupGuidFromField("amxperu_casesubsubcategory", "amxperu_name", request.caseTypeCategory3, organizationService);
                    if (caseTypeGuid != Guid.Empty)
                    {
                        caseEntity.Attributes.Add("amxperu_casesubsubcategory", new EntityReference("amxperu_casesubsubcategory", caseTypeGuid));
                    }
                }

                if (!string.IsNullOrEmpty(request.caseTypeCategory4))
                {
                    Guid caseTypeGuid = GetLookupGuidFromField("amxperu_caseothercategory", "amxperu_name", request.caseTypeCategory4, organizationService);
                    if (caseTypeGuid != Guid.Empty)
                    {
                        caseEntity.Attributes.Add("amxperu_caseothercategory", new EntityReference("amxperu_caseothercategory", caseTypeGuid));
                    }
                }

                if (!string.IsNullOrEmpty(request.CaseParentId))
                {
                    Guid retreiveParentCaseGuid = GetLookupGuidFromField("incident", "ticketnumber", request.CaseParentId, organizationService);
                    caseEntity.Attributes.Add("parentcaseid", new EntityReference("incident", retreiveParentCaseGuid));
                }
                
                if (!string.IsNullOrEmpty(request.Description))
                    caseEntity.Attributes.Add("description", request.Description);

                if (request.Origin > 0)
                {
                    caseEntity.Attributes.Add("amxperu_originchannel", new OptionSetValue(request.Origin));
                }
                if (request.Priority > 0)
                {
                    caseEntity.Attributes.Add("prioritycode", new OptionSetValue((int)request.Priority));
                }

                if (request.Severity > 0)
                {
                    caseEntity.Attributes.Add("severitycode", new OptionSetValue((int)request.Severity));
                }

                if (request.Status > 0)
                {
                    caseEntity.Attributes.Add("statecode", request.Status);
                }

                //if (!string.IsNullOrEmpty(request.Subject))
                //    caseEntity.Attributes.Add("subjectid", request.Subject);

                #endregion
                Guid createdCaseGuid = organizationService.Create(caseEntity);
                response.CaseId = createdCaseGuid.ToString();

                foreach (Documents eachDocument in request.Documents)
                {
                    Entity document = new Entity("amxperu_customerdocument");
                    document.Attributes.Add("amxperu_name", eachDocument.DocumentName);
                    if (!string.IsNullOrEmpty(eachDocument.DocumentIdOnbase))
                    {
                        document.Attributes.Add("amxperu_documentidonbase", eachDocument.DocumentIdOnbase);
                    }

                    if (!string.IsNullOrEmpty(eachDocument.DocumentId))
                    {
                        int doctype;
                       bool dtFlag= int.TryParse(eachDocument.DocumentId,out doctype);
                        if(dtFlag)
                        document.Attributes.Add("amxperu_documenttype", new OptionSetValue(doctype));
                    }
                    if (request.CustomerType == 1)
                    {
                        EntityReference customer = new EntityReference("contact", CustomerGuid);
                        document.Attributes.Add("amxperu_relatedindividual", customer);
                    }
                    else if (request.CustomerType == 2)
                    {
                        EntityReference customer = new EntityReference("account", CustomerGuid);
                        document.Attributes.Add("amxperu_relatedcorporate", customer);
                    }
                    document.Attributes.Add("amxperu_relatedentityname", "incident");
                    document.Attributes.Add("amxperu_relatedentityguid", createdCaseGuid.ToString());
                    organizationService.Create(document);
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Guid GetLookupGuidFromField(string entityName, string columnName, string columnValue, OrganizationServiceProxy OrgService)
        {
            QueryExpression retrieveQuery = new QueryExpression(entityName);
            retrieveQuery.Criteria.AddCondition(columnName, ConditionOperator.Equal, columnValue);
            EntityCollection retrievedCollection = OrgService.RetrieveMultiple(retrieveQuery);

            if (retrievedCollection.Entities.Count == 1)
            {
                return retrievedCollection[0].Id;
            }
            return Guid.Empty;
        }


    }
}
