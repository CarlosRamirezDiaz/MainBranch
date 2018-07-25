using Ericsson.ETELCRM.Entities.Crm;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Business;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk.Query;
using ExternalApiActivities.Common;
using System;
using System.Activities;


namespace AmxPeruPSBActivities.Activities.Task
{
    public class AmxPeruCreateBILOG : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruCreateTaskUpdatedResponse> createBILOGRequest { get; set; }
        public OutArgument<AmxPeruCreateBILOGResponse> createBILOGResponse { get; set; }
       
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
                Model.Eligibility.AmxPeruCreateBILOGResponse _CreateBILogResponse = null;
                string customerTypeName = string.Empty;
                Guid customerGuid = Guid.Empty;
            string CustomerTypeField = null;

                try
                {
                var request = createBILOGRequest.Get(context);
                _CreateBILogResponse = new Model.Eligibility.AmxPeruCreateBILOGResponse();
                    Entity biLogActivityEnt = new Entity("etel_bi_log");
                    if (request != null)
                    {
                        //if (!string.IsNullOrEmpty(request.subject))
                        //{
                            biLogActivityEnt["subject"] = "Task Record Created.";
                       // }

                       // if (!string.IsNullOrEmpty(request.description))
                       // {
                            biLogActivityEnt["etel_description"] = "New task record is Created in CRM. ";
                  //  }

                        if (!string.IsNullOrEmpty(request.Channel))
                        {
                            biLogActivityEnt["etel_customerchannel"] = request.Channel;
                        }

                        if ((!string.IsNullOrEmpty(request.CustomerExternalId)))
                        {
                            if (request.CustomerType == 0)
                            {
                                customerTypeName = "contact";
                                CustomerTypeField = "etel_individualcustomerid";

                            }
                            else
                            {
                                customerTypeName = "account";
                                CustomerTypeField = "etel_corporatecustomerid";
                            }
                            QueryExpression searchQuery = new QueryExpression(customerTypeName);
                            searchQuery.Criteria.AddCondition("etel_externalid", ConditionOperator.Equal, request.CustomerExternalId);
                            EntityCollection contactRecords = ContextProvider.OrganizationService.RetrieveMultiple(searchQuery);
                            if (contactRecords.Entities.Count > 0)
                            {
                                biLogActivityEnt[CustomerTypeField] = new EntityReference(contactRecords[0].LogicalName, contactRecords[0].Id);
                                Entity party1 = new Entity("activityparty");
                                party1["partyid"] = new EntityReference(contactRecords[0].LogicalName, contactRecords[0].Id);
                                EntityCollection entCollection = new EntityCollection();
                                entCollection.Entities.Add(party1);
                                biLogActivityEnt["customers"] = entCollection;
                            }
                        }

                        biLogActivityEnt["scheduledend"] = DateTime.UtcNow;

                        if (!(string.IsNullOrEmpty(request.regardingRecordEntityName)))
                        {
                            biLogActivityEnt["regardingobjectid"] = new EntityReference(request.regardingRecordEntityName,new Guid(request.CreatedTaskID));
                        }

                        Guid CreatedBiLogGuid = ContextProvider.OrganizationService.Create(biLogActivityEnt);

                        if (CreatedBiLogGuid != null && request.regardingRecordEntityName != "amxbase_biordercapture")
                        {
                            EntityReference moniker = new EntityReference();
                            moniker.LogicalName = "etel_bi_log";
                            moniker.Id = CreatedBiLogGuid;
                            OrganizationRequest orgrequest = new OrganizationRequest() { RequestName = "SetState" };
                            orgrequest["EntityMoniker"] = moniker;
                            OptionSetValue state = new OptionSetValue(1);
                            OptionSetValue status = new OptionSetValue(2);
                            orgrequest["State"] = state;
                            orgrequest["Status"] = status;
                            ContextProvider.OrganizationService.Execute(orgrequest);
                            _CreateBILogResponse.Status = "OK";
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

               
            createBILOGResponse.Set(context, _CreateBILogResponse);
        }

    }
    
}
