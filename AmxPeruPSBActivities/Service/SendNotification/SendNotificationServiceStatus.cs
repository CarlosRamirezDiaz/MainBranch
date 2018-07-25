using AmxPeruPSBActivities.SendNotification;
using AmxPeruPSBActivities.Model.SendNotification;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Crm.Sdk.Messages;

namespace AmxPeruPSBActivities.Service.SendNotification
{
   public class SendNotificationServiceStatus
    {
        EntityCollection entitycollection = null;
        public AmxperuSendNotificationResponse SendnotificationStatus(AmxperuSendNotificationRequest request, OrganizationServiceProxy organizationService, Microsoft.Xrm.Sdk.Entity entity)
        {
            AmxperuSendNotificationResponse objsendnotificationresponse = null;
            //BusinessInteraction _business = new BusinessInteraction();
            //_business.description = request.Description;
            sendNotificationRequestType reqtype = new sendNotificationRequestType()
            {
                MarketingCampaignExtension = new MarketingCampaignExtension()
                {
                    _dispatchID = request.DispatchID,
                    _mailRecipient = request.MailRecipient,
                    _bodyMail = request.BodyMail,
                    _mailSender = request.MailSender,
                    _subjectMail = request.SubjectMail
                },
                
                UtilityFields = new UtilityFields()
                {
                    text01 = request.Text01,
                    text02 = request.Text02,
                    text03 = request.Text03
                },
                //Notification,
                //ProductOffering = new ProductOffering()
                //{
                                                        
                //}
               // Notification = request.Description;,
               ProductOffering = new ProductOffering()
               {
                   _product = new AmxPeruPSBActivities.SendNotification.Product[] 
                   {
                       new AmxPeruPSBActivities.SendNotification.Product(){ externalIDs = request.ExternalIDs }
                   } 
               },
               listaRequestOpcional = new AttributeValuePair[] 
               {
                   new AttributeValuePair(){
                       name = request.AttributeValuePair.FirstOrDefault().nameField,
                       value = request.AttributeValuePair.FirstOrDefault().valueField
                   }
               }
            };


            sendNotificationResponseType restype = new sendNotificationResponseType()
            {
                listaResponseOpcional = new AttributeValuePair[]
                {
                    new AttributeValuePair()
                    {
                        name="Response Name",
                        value="Response Value"

                    }
                }

            };

            CreateEmailActitvity(organizationService, entity, request);
            //return restype;

            AmxperuSendNotificationResponse resobj = new AmxperuSendNotificationResponse()
            {
                Status = "OK",
                Error = "404 error",
               
                AttributeValuePairResponse = new List<KeyValuePairResponse>()
                {
                    new KeyValuePairResponse()
                    {
                        ResponsenameField="KeyvalupairResponseNamefield",
                        ResponsevalueField="KeyvalupairResponseValuefield"
                    }
                }


            };

            return resobj;
        }
        public Guid getConfigValues(IOrganizationService service, string key)
        {

            string value = string.Empty;

            QueryExpression ConfigData = new QueryExpression { EntityName = "etel_crmconfiguration", ColumnSet = new ColumnSet(true) };
            ConfigData.Criteria = new FilterExpression();
            ConfigData.Criteria.AddCondition("etel_name", ConditionOperator.Equal, key);
            EntityCollection templateCollection = service.RetrieveMultiple(ConfigData);
            if (templateCollection != null && templateCollection.Entities.Count > 0)
            {
                value = templateCollection.Entities[0].Attributes["etel_value"].ToString();
            }
            return new Guid(value);
        }
        private void CreateEmailActitvity(IOrganizationService service, Microsoft.Xrm.Sdk.Entity entity, AmxperuSendNotificationRequest request)
        {
            Guid templateId = Guid.Empty;
            Guid FromadminuserID = Guid.Empty;
            Guid ToContactID = Guid.Empty;
            entitycollection = getTemplateID(service,request.TemplateID);
            if (entitycollection != null && entitycollection.Entities.Count > 0)
            {
                templateId = entitycollection.Entities[0].Id;
            }
            Microsoft.Xrm.Sdk.Entity email = new Microsoft.Xrm.Sdk.Entity();
            email.LogicalName = "email";
            QueryExpression ConfigData = new QueryExpression { EntityName = "contact", ColumnSet = new ColumnSet(true) };
            ConfigData.Criteria = new FilterExpression();
            ConfigData.Criteria.AddCondition("etel_externalid", ConditionOperator.Equal, request.ExternalIDs);
            EntityCollection contactCollection = service.RetrieveMultiple(ConfigData);
            if (contactCollection != null && contactCollection.Entities.Count > 0)
            {
                ToContactID = contactCollection.Entities[0].Id;
            }
            FromadminuserID = getConfigValues(service, "Mail Notification From Address");
            Microsoft.Xrm.Sdk.Entity fromParty = new Microsoft.Xrm.Sdk.Entity("activityparty");
            Microsoft.Xrm.Sdk.Entity toParty = new Microsoft.Xrm.Sdk.Entity("activityparty");
            fromParty["partyid"] = new EntityReference("systemuser", FromadminuserID);
            // to = owner;
            toParty["partyid"] = new EntityReference("contact", ToContactID);
            //fromParty.Attributes.Add("partyid", from.Id);
            EntityCollection collFromParty = new EntityCollection();
            collFromParty.EntityName = "systemuser";
            collFromParty.Entities.Add(fromParty);
            EntityCollection collToParty = new EntityCollection();
            collToParty.EntityName = "contact";
            collToParty.Entities.Add(toParty);
            email.Attributes.Add("from", collFromParty);
            email.Attributes.Add("to", collToParty);
            if (templateId != null)
            {
                email.Attributes.Add("subject", request.SubjectMail);
                email.Attributes.Add("regardingobjectid", new EntityReference(request.regardingentityname, new Guid(request.regardingentityId)));
                email.Attributes.Add("description", " Description : " + request.Description + " Text01 : " + request.Text01 + " Text02 : " + request.Text02 + " Text03 : " + request.Text03 + " Interation Date" + request.InteractionDate);
                Guid emailid=service.Create(email);
                service.Execute(new SetStateRequest
                {
                    EntityMoniker = new EntityReference("email", emailid),
                    State = new OptionSetValue(1),
                    Status = new OptionSetValue(2)
                });
            }
            else
            {
                email.Attributes.Add("subject", request.SubjectMail);
                email.Attributes.Add("regardingobjectid", new EntityReference(request.regardingentityname, new Guid(request.regardingentityId)));
                email.Attributes.Add("description", " Description : " + request.Description + ",  Text01 : " + request.Text01 + ",  Text02 : " + request.Text02 + ",  Text03 : " + request.Text03 + ",  Interation Date" + request.InteractionDate);
                Guid emailid = service.Create(email);
                service.Execute(new SetStateRequest
                {
                    EntityMoniker = new EntityReference("email", emailid),
                    State = new OptionSetValue(1),
                    Status = new OptionSetValue(2)
                });
            }         
        }
        private EntityCollection getTemplateID(IOrganizationService service, string emaillTemplate)
        {
            Guid templateId = Guid.Empty;
            QueryExpression templateQuery = new QueryExpression { EntityName = "template", ColumnSet = new ColumnSet(true) };
            templateQuery.Criteria = new FilterExpression();
            templateQuery.Criteria.AddCondition("title", ConditionOperator.Equal, emaillTemplate);
            EntityCollection templateCollection = service.RetrieveMultiple(templateQuery);
           // entitycollection = templateCollection;
            //if (templateCollection != null && templateCollection.Entities.Count > 0)
            //{
            //    templateId = templateCollection.Entities[0].Id;
            //}
            return templateCollection;
        }
    }
}
