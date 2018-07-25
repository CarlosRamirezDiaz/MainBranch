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
    public class UpdateCustomersContactInformation : CodeActivity
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
            Entity contactEnt = service.Retrieve(erIndividual.LogicalName, erIndividual.Id, new ColumnSet("amx_ccinfoupdjsontext"));
            List<Guid> guidsExist = new List<Guid>();

            if (contactEnt!=null)
            {
                if (contactEnt.Contains("amx_ccinfoupdjsontext"))
                {
                    string json = contactEnt.GetAttributeValue<string>("amx_ccinfoupdjsontext");

                    MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<CustomerContactInformation>));

                    List<CustomerContactInformation> customerContactInfo = (List<CustomerContactInformation>)ser.ReadObject(ms);

                    foreach (CustomerContactInformation cusConInfo in customerContactInfo)
                    {
                        Entity customercontactinformation = new Entity("amx_customercontactinformation");

                        if (!string.IsNullOrEmpty(cusConInfo.contacttype))
                        {
                            customercontactinformation["amx_contacttype"] = new OptionSetValue(Convert.ToInt32(cusConInfo.contacttype));
                        }

                        if (cusConInfo.contacttype.Equals("173800000"))
                        {
                            customercontactinformation["amx_email"] = cusConInfo.contactinfo;
                        }
                        else if (cusConInfo.contacttype.Equals("173800001"))
                        {
                            customercontactinformation["amx_phoneno"] = cusConInfo.mobileInfo;
                        }
                        else if (cusConInfo.contacttype.Equals("173800002"))
                        {
                            customercontactinformation["amx_phoneno"] = cusConInfo.fixedlineInfo;
                        }

                        if (!string.IsNullOrEmpty(cusConInfo.fixedOrMobile))
                        {
                            customercontactinformation["amx_mobilefixed"] = cusConInfo.fixedOrMobile.Equals("1") ? true : false;
                        }

                        if (!string.IsNullOrEmpty(cusConInfo.isprimary))
                        {
                            customercontactinformation["amx_primarycontacttype"] = cusConInfo.isprimary.Equals("1") ? true : false;
                        }

                        bool create = false;

                        if (!string.IsNullOrEmpty(cusConInfo.guid))
                        {
                            guidsExist.Add(Guid.Parse(cusConInfo.guid));

                            QueryExpression queryCustomer = new QueryExpression("amx_customercontactinformation");
                            queryCustomer.Criteria.AddCondition("amx_customercontactinformationid", ConditionOperator.Equal, Guid.Parse(cusConInfo.guid));

                            EntityCollection result = service.RetrieveMultiple(queryCustomer);

                            if (result.Entities.Count > 0)
                            {
                                customercontactinformation.Id = Guid.Parse(cusConInfo.guid);
                                service.Update(customercontactinformation);
                            }
                            else
                            {
                                create = true;
                            }
                        }
                        else
                        {
                            create = true;
                        }

                        if (create)
                        {
                            customercontactinformation["amx_individualcustomerid"] = erIndividual;
                            guidsExist.Add(service.Create(customercontactinformation));
                        }
                    }

                    if (guidsExist.Count > 0)
                    {
                        QueryExpression query = new QueryExpression("amx_customercontactinformation");
                        query.Criteria.AddCondition("amx_individualcustomerid", ConditionOperator.Equal, erIndividual.Id);

                        foreach (Guid g in guidsExist)
                        {
                            query.Criteria.AddCondition("amx_customercontactinformationid", ConditionOperator.NotEqual, g);
                        }

                        EntityCollection results = service.RetrieveMultiple(query);

                        if (results.Entities.Count > 0)
                        {
                            foreach (Entity ent in results.Entities)
                            {
                                service.Delete(ent.LogicalName, ent.Id);
                            }
                        }
                    }
                    else
                    {
                        QueryExpression query = new QueryExpression("amx_customercontactinformation");
                        query.Criteria.AddCondition("amx_individualcustomerid", ConditionOperator.Equal, erIndividual.Id);

                        EntityCollection results = service.RetrieveMultiple(query);

                        if (results.Entities.Count > 0)
                        {
                            foreach (Entity ent in results.Entities)
                            {
                                service.Delete(ent.LogicalName, ent.Id);
                            }
                        }
                    }
                }
                else
                {
                    QueryExpression query = new QueryExpression("amx_customercontactinformation");
                    query.Criteria.AddCondition("amx_individualcustomerid", ConditionOperator.Equal, erIndividual.Id);

                    EntityCollection results = service.RetrieveMultiple(query);

                    if (results.Entities.Count > 0)
                    {
                        foreach (Entity ent in results.Entities)
                        {
                            service.Delete(ent.LogicalName, ent.Id);
                        }
                    }
                }
            }
        }
    }
}
