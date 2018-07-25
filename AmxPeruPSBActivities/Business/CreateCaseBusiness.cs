using AmxPeruPSBActivities.Model.Case;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Query;

namespace AmxPeruPSBActivities.Business
{
    public class CreateCaseBusiness
    {

        public CaseResponse CreateCaseOnCRM(CaseRequest request, OrganizationServiceProxy organizationService)
        {
            try
            {
                CaseResponse response = null;


                //serviceIdentifier
                //productName
                //"complaintPhase

                //caseTypeCategory1
                //caseTypeCategory2
                //caseTypeCategory3
                //caseTypeCategory4

                //serialNumber

                //identifier
                //referentialPhoneNumber
                //referentialEMail
                //referentialAddress
                //notificationMethod
                //paymentDispute
                //callRecordId
                //resolutionNumber
                //resolutionDate
                //indecopi
                //osiptel
                //resolutionNotificationDate
                //AddressOfServiceFailure
                //documents

                #region "Properti assignment"
                Entity caseEntity = new Entity("incident");

                if (!string.IsNullOrEmpty(request.CustomerId.Trim()))
                {
                    if (request.CustomerType==1||request.CustomerType==2) {
                        if (request.CustomerType == 1)
                        {
                            caseEntity.Attributes.Add("customerid", new EntityReference("contact", new Guid(request.CustomerId)));
                        }
                        else if (request.CustomerType == 2)
                        {
                            caseEntity.Attributes.Add("customerid", new EntityReference("account", new Guid(request.CustomerId)));
                        }
                    }

                }


                if (!string.IsNullOrEmpty(request.CaseType))
                {

                    Guid retrievedRecordGuid = GetLookupGuidFromField("amxperu_casetype", "amxperu_name", request.CaseType, organizationService);
                    caseEntity.Attributes.Add("amxperu_casetype", new EntityReference("amxperu_casetype", retrievedRecordGuid));

                }
                if (!string.IsNullOrEmpty(request.caseTypeCategory1))
                {

                    Guid retrievedRecordGuid = GetLookupGuidFromField("amxperu_casecategory", "amxperu_name", request.caseTypeCategory1, organizationService);
                    caseEntity.Attributes.Add("amxperu_casecategory", new EntityReference("amxperu_casecategory", retrievedRecordGuid));

                }
                if (!string.IsNullOrEmpty(request.caseTypeCategory2))
                {

                    Guid retrievedRecordGuid = GetLookupGuidFromField("amxperu_casesubcategory", "amxperu_name", request.caseTypeCategory2, organizationService);
                    caseEntity.Attributes.Add("amxperu_casesubcategory", new EntityReference("amxperu_casesubcategory", retrievedRecordGuid));

                }
                if (!string.IsNullOrEmpty(request.caseTypeCategory3))
                {

                    Guid retrievedRecordGuid = GetLookupGuidFromField("amxperu_casesubsubcategory", "amxperu_name", request.caseTypeCategory3, organizationService);
                    caseEntity.Attributes.Add("amxperu_casesubsubcategory", new EntityReference("amxperu_casesubsubcategory", retrievedRecordGuid));

                }
                if (!string.IsNullOrEmpty(request.caseTypeCategory4))
                {

                    Guid retrievedRecordGuid = GetLookupGuidFromField("amxperu_caseothercategory", "amxperu_name", request.caseTypeCategory4, organizationService);
                    caseEntity.Attributes.Add("amxperu_caseothercategory", new EntityReference("amxperu_caseothercategory", retrievedRecordGuid));

                }
                //   caseEntity.Attributes.Add("parentcaseid", request.CaseParentId);


                if (!string.IsNullOrEmpty(request.CaseTitle.Trim()))
                    caseEntity.Attributes.Add("title", request.CaseTitle);

                if (!string.IsNullOrEmpty(request.Description))
                {
                    caseEntity.Attributes.Add("description", request.Description);
                }

                //caseEntity.Attributes.Add("etel_complaintreason", request.ComplaintPhase);
                //if (request.Origin > 0)
                //    caseEntity.Attributes.Add("caseorigincode", request.Origin);
                //if (request.Priority > 0)
                //    caseEntity.Attributes.Add("prioritycode", request.Priority);

                //if (request.Severity > 0)
                //    caseEntity.Attributes.Add("severitycode", request.Severity);
                //if (request.Status > 0)
                //    caseEntity.Attributes.Add("statuscode", request.Status);



                //
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
                        bool dtFlag = int.TryParse(eachDocument.DocumentId, out doctype);
                        if (dtFlag)
                            document.Attributes.Add("amxperu_documenttype", new OptionSetValue(doctype));
                    }
                    if (request.CustomerType == 1)
                    {
                        EntityReference customer = new EntityReference("contact", new Guid(request.CustomerId));
                        document.Attributes.Add("amxperu_relatedindividual", customer);
                    }
                    else if (request.CustomerType == 2)
                    {
                        EntityReference customer = new EntityReference("account", new Guid(request.CustomerId));
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
                throw;
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
