using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Crm.Sdk.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPlugins
{
    public class SendEmailCommon : IPlugin
    {
        #region [Execute Method]
        public void Execute(IServiceProvider serviceProvider)
        {
            ITracingService tracing = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            try
            {
                if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
                {
                    IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                    IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
                    Entity entity = (Entity)context.InputParameters["Target"];
                    Entity postEntityImage = (Entity)context.PostEntityImages["PostImage"];
                    //Entity preEntityImage = (Entity)context.PostEntityImages["PreImage"];
                    EntityReference contactID = null;
                    Guid fromAddress = Guid.Empty;
                    Guid toAddress = Guid.Empty;
                    string emaillTemplate = string.Empty;

                    if (context.MessageName == "Update")
                    {
                        fromAddress = getConfigValues(service, "Mail Notification From Address");
                        if (entity.Contains("etel_submit"))
                        {
                            if ((bool)entity.Attributes["etel_submit"] == true)
                            {
                                //Modify Bill Cycle  
                                if (entity.LogicalName == "etel_billcyclechangebusinessinteraction")
                                {
                                    tracing.Trace("bill cycle change" + entity.LogicalName);

                                    if (postEntityImage.Attributes.Contains("etel_individualcustomer") && postEntityImage.Attributes["etel_individualcustomer"] != null)
                                    {
                                        contactID = (EntityReference)postEntityImage.Attributes["etel_individualcustomer"];
                                    }
                                    if (postEntityImage.Attributes.Contains("etel_corporatecustomerid") && postEntityImage.Attributes["etel_corporatecustomerid"] != null)
                                    {
                                        contactID = (EntityReference)postEntityImage.Attributes["etel_corporatecustomerid"];
                                    }

                                    SendEmail(service, entity, fromAddress, contactID, "Bill Cycle Change");
                                }
                                if (entity.LogicalName == "etel_bi_billingaccountcreate")
                                {

                                    if (postEntityImage.Attributes.Contains("etel_accountid") && postEntityImage.Attributes["etel_accountid"] != null)
                                    {
                                        contactID = (EntityReference)postEntityImage.Attributes["etel_accountid"];
                                    }
                                    if (postEntityImage.Attributes.Contains("etel_customerindividualid") && postEntityImage.Attributes["etel_customerindividualid"] != null)
                                    {
                                        contactID = (EntityReference)postEntityImage.Attributes["etel_customerindividualid"];
                                    }
                                    tracing.Trace("conatct" + contactID);
                                    //throw new Exception("test");

                                    SendEmail(service, entity, fromAddress, contactID, "Assign Bill Cycle");
                                }
                                if (entity.LogicalName == "etel_billingaccountupdatebi")
                                {
                                    tracing.Trace("step3");
                                    if (postEntityImage.Attributes.Contains("etel_accountid") && postEntityImage.Attributes["etel_accountid"] != null)
                                    {
                                        tracing.Trace("account");
                                        contactID = (EntityReference)postEntityImage.Attributes["etel_accountid"];
                                    }
                                    if (postEntityImage.Attributes.Contains("etel_customerindividualid") && postEntityImage.Attributes["etel_customerindividualid"] != null)
                                    {
                                        tracing.Trace("contact");
                                        contactID = (EntityReference)postEntityImage.Attributes["etel_customerindividualid"];
                                    }
                                    tracing.Trace("entityreference" + (EntityReference)postEntityImage.Attributes["etel_customerindividualid"]);
                                    tracing.Trace("step4" + contactID + "Modify Bill Account ");
                                    SendEmail(service, entity, fromAddress, contactID, "Modify Bill Account");
                                }
                                if (entity.LogicalName == "etel_bi_modifysubscriptionba")
                                {
                                    if (postEntityImage.Attributes.Contains("etel_corporateid") && postEntityImage.Attributes["etel_corporateid"] != null)
                                    {
                                        contactID = (EntityReference)postEntityImage.Attributes["etel_corporateid"];
                                    }
                                    if (postEntityImage.Attributes.Contains("etel_individualid") && postEntityImage.Attributes["etel_individualid"] != null)
                                    {
                                        contactID = (EntityReference)postEntityImage.Attributes["etel_individualid"];
                                    }

                                    SendEmail(service, entity, fromAddress, contactID, "Billing Account Subscription Change");
                                }
                                if (entity.LogicalName == "etel_customeraddressbusinessinteraction")
                                {
                                    if (postEntityImage.Attributes.Contains("etel_individualcustomer") && postEntityImage.Attributes["etel_individualcustomer"] != null)
                                    {
                                        contactID = (EntityReference)postEntityImage.Attributes["etel_individualcustomer"];
                                    }
                                    if (postEntityImage.Attributes.Contains("etel_corporatecustomer") && postEntityImage.Attributes["etel_corporatecustomer"] != null)
                                    {
                                        contactID = (EntityReference)postEntityImage.Attributes["etel_corporatecustomer"];
                                    }

                                    SendEmail(service, entity, fromAddress, contactID, "Create Address BI");
                                }
                                if (entity.LogicalName == "etel_bi_customeraddressmodification")
                                {
                                    if (postEntityImage.Attributes.Contains("etel_individualcustomer") && postEntityImage.Attributes["etel_individualcustomer"] != null)
                                    {
                                        contactID = (EntityReference)postEntityImage.Attributes["etel_individualcustomer"];
                                    }
                                    if (postEntityImage.Attributes.Contains("etel_corporatecustomer") && postEntityImage.Attributes["etel_corporatecustomer"] != null)
                                    {
                                        contactID = (EntityReference)postEntityImage.Attributes["etel_corporatecustomer"];
                                    }

                                    SendEmail(service, entity, fromAddress, contactID, "Modify Address BI");
                                }
                            }
                        }

                        else if (entity.Contains("amxperu_submit"))
                        {
                            if ((bool)entity.Attributes["amxperu_submit"])
                            {
                                if (entity.LogicalName == "amxperu_biaffiliateordisaffiliatetodataprotecti")
                                {
                                    if (postEntityImage.Attributes.Contains("amxperu_customerindividual") && postEntityImage.Attributes["amxperu_customerindividual"] != null)
                                    {
                                        contactID = (EntityReference)postEntityImage.Attributes["amxperu_customerindividual"];
                                    }
                                    if (postEntityImage.Attributes.Contains("amxperu_customercorporate") && postEntityImage.Attributes["amxperu_customercorporate"] != null)
                                    {
                                        contactID = (EntityReference)postEntityImage.Attributes["amxperu_customercorporate"];
                                    }

                                    SendEmail(service, entity, fromAddress, contactID, "Data Protection BI");
                                }
                                if (entity.LogicalName == "amxperu_biaffiliatedisaffiliateblacklist")
                                {
                                    if (postEntityImage.Attributes.Contains("amxperu_customerindividual") && postEntityImage.Attributes["amxperu_customerindividual"] != null)
                                    {
                                        contactID = (EntityReference)postEntityImage.Attributes["amxperu_customerindividual"];
                                    }
                                    if (postEntityImage.Attributes.Contains("amxperu_customercorporate") && postEntityImage.Attributes["amxperu_customercorporate"] != null)
                                    {
                                        contactID = (EntityReference)postEntityImage.Attributes["amxperu_customercorporate"];
                                    }

                                    SendEmail(service, entity, fromAddress, contactID, "Service Blacklist BI");
                                }
                            }
                        }
                    }
                }

                //etel_accountid  etel_customerindividualid
                #endregion
            }
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException(ex.Message);
            }
        }


        public Guid getConfigValues(IOrganizationService service, string key)
        {

            string value = string.Empty;

            QueryExpression ConfigData = new QueryExpression { EntityName = "amxperu_amxconfigurations", ColumnSet = new ColumnSet(true) };
            ConfigData.Criteria = new FilterExpression();
            ConfigData.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, key);
            EntityCollection templateCollection = service.RetrieveMultiple(ConfigData);
            if (templateCollection != null && templateCollection.Entities.Count > 0)
            {

                value = templateCollection.Entities[0].Attributes["amxperu_value"].ToString();
            }
            return new Guid(value);
        }
        private void SendEmail(IOrganizationService service, Entity entity, Guid fromAddress, EntityReference contactID, string emaillTemplate)
        {
            Guid templateId = Guid.Empty;

            templateId = getTemplateID(service, emaillTemplate);
            Entity email = new Entity();
            email.LogicalName = "email";
            Entity fromParty = new Entity("activityparty");
            Entity toParty = new Entity("activityparty");
            fromParty["partyid"] = new EntityReference("systemuser", fromAddress);
            // to = owner;
            toParty["partyid"] = new EntityReference(contactID.LogicalName, contactID.Id);
            //fromParty.Attributes.Add("partyid", from.Id);
            EntityCollection collFromParty = new EntityCollection();
            collFromParty.EntityName = "systemuser";
            collFromParty.Entities.Add(fromParty);
            EntityCollection collToParty = new EntityCollection();
            collToParty.EntityName = contactID.LogicalName;
            collToParty.Entities.Add(toParty);
            email.Attributes.Add("from", collFromParty);

            email.Attributes.Add("to", collToParty);
            SendEmailFromTemplateRequest emailUsingTemplateReq = new SendEmailFromTemplateRequest
            {
                Target = email,
                TemplateId = templateId,
                RegardingId = entity.Id,
                RegardingType = entity.LogicalName
            };
            
            //throw new InvalidPluginExecutionException("email template"+emaillTemplate+ " from " + fromAddress +"  ");
            SendEmailFromTemplateResponse emailUsingTemplateResp = (SendEmailFromTemplateResponse)service.Execute(emailUsingTemplateReq);
        }


        private Guid getTemplateID(IOrganizationService service, string emaillTemplate)
        {
            Guid templateId = Guid.Empty;
            QueryExpression templateQuery = new QueryExpression { EntityName = "template", ColumnSet = new ColumnSet("templateid") };
            templateQuery.Criteria = new FilterExpression();
            templateQuery.Criteria.AddCondition("title", ConditionOperator.Equal, emaillTemplate);
            EntityCollection templateCollection = service.RetrieveMultiple(templateQuery);
            if (templateCollection != null && templateCollection.Entities.Count > 0)
            {
                 templateId = templateCollection.Entities[0].Id;
            }
            return templateId;
        }
      
    }

}
