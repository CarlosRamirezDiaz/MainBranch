using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.ServiceModel;
using AmxPeruPlugins.BILCustomerService;

namespace AmxPeruPlugins
{
    public class AmxPeruModifyIndividualDemographic : IPlugin
    {
        public static string FetchContactFields = @"<fetch distinct='false' mapping='logical' output-format='xml-platform' version='1.0'>
                                                    <entity name='contact'>
                                                    <attribute name='fullname'/>
                                                    <attribute name='contactid'/>
                                                    <attribute name='etel_externalid'/>
                                                    <order descending='false' attribute='fullname'/>
                                                    <filter type='and'>
                                                    <condition attribute='contactid' value='{0}' operator='eq'/>
                                                    </filter>
                                                    </entity>
                                                    </fetch>";


        public void Execute(IServiceProvider serviceProvider)
        {
            IPluginExecutionContext context = null;
            IOrganizationService OrganizationService = null;
            Entity postEntityImage = null;
            Entity entity = null;
            try
            {
                context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                if (context.Depth == 1)
                {
                    if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity && context.PostEntityImages.Contains("POSTIMG"))
                    {
                        // Get the target entity from the input parameters.
                        entity = (Entity)context.InputParameters["Target"];
                        postEntityImage = (Entity)context.PostEntityImages["POSTIMG"];
                        IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                        OrganizationService = serviceFactory.CreateOrganizationService(context.UserId);

                        if (postEntityImage.Attributes.Contains("etel_submit"))
                        {
                            if ((bool)postEntityImage.Attributes["etel_submit"])
                            {
                                UpdateCustomerDemographic(postEntityImage, OrganizationService);
                            }
                        }
                    }
                }
                BILogSchema _BILogSchema = new BILogSchema
                {
                    LoggedInUserId = context.UserId,
                    Subject = "Modify Customer Demographic",
                    Description = "Customer Demographic Modified Successfully",
                    Channel = "External Channel"
                };
                //common.CreateBILogValues(postEntityImage, OrganizationService, _BILogSchema);
            }
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException(ex.Message);
            }
        }
        private string GetCustomerExternalID(string CustomerGuidId, IOrganizationService service)
        {
            string CustomerExternalID = string.Empty;
            string fetchXml = string.Empty;

            try
            {
                if (!string.IsNullOrEmpty(CustomerGuidId))
                {
                    fetchXml = string.Format(FetchContactFields, CustomerGuidId);
                    EntityCollection _EntityCollection = service.RetrieveMultiple(new FetchExpression(fetchXml));
                    if (_EntityCollection != null && _EntityCollection.Entities.Count > 0)
                    {
                        if (_EntityCollection.Entities[0].Attributes.Contains("etel_externalid"))
                        {
                            CustomerExternalID = _EntityCollection.Entities[0].Attributes["etel_externalid"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CustomerExternalID;
        }

        public void UpdateCustomerDemographic(Entity postEntityImage, IOrganizationService service)
        {
            string docType = string.Empty;
            string docId = string.Empty;
            string IndividualCustomerGuid = string.Empty;
            bool successFlag;
            try
            {
                if (postEntityImage.Attributes.Contains("amxperu_documenttype"))
                {
                    if ((OptionSetValue)postEntityImage.Attributes["amxperu_documenttype"] != null)
                    {
                        int doctype = (postEntityImage.Attributes["amxperu_documenttype"] as OptionSetValue).Value;
                        docType = doctype.ToString();
                    }
                }
                if (postEntityImage.Attributes.Contains("etel_passportnumber"))
                {
                    if (!string.IsNullOrEmpty(postEntityImage.Attributes["etel_passportnumber"].ToString()))
                    {
                        docId = postEntityImage.Attributes["etel_passportnumber"].ToString();
                    }
                }
                if (postEntityImage.Attributes.Contains("etel_customerid"))
                {
                    if ((EntityReference)postEntityImage.Attributes["etel_customerid"] != null)
                    {
                        Guid Individual = (postEntityImage.Attributes["etel_customerid"] as EntityReference).Id;
                        IndividualCustomerGuid = Individual.ToString();
                    }
                }

                if ((!string.IsNullOrEmpty(docType)) && (!string.IsNullOrEmpty(docId)) && (!string.IsNullOrEmpty(IndividualCustomerGuid)))
                {
                    successFlag = PassDocTypeDocIdToBSCS(postEntityImage, service);
                    if (successFlag == true)
                    {
                        UpdateCustomerData(postEntityImage, service);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void UpdateCustomerData(Entity postImage, IOrganizationService service)
        {
            Guid IndividualGuidID = Guid.Empty;
            string fullname = "";
            if (postImage.Attributes.Contains("etel_customerid"))
            {
                if ((EntityReference)postImage.Attributes["etel_customerid"] != null)
                {
                    IndividualGuidID = (postImage.Attributes["etel_customerid"] as EntityReference).Id;
                    Entity Customer = new Entity("contact", IndividualGuidID);

                    if (postImage.Attributes.Contains("etel_firstname"))
                    {
                        if (postImage.Attributes["etel_firstname"] != null)
                        {
                            Customer.Attributes.Add("firstname", postImage.Attributes["etel_firstname"].ToString());
                            fullname += postImage.Attributes["etel_firstname"].ToString();
                        }
                    }
                    if (postImage.Attributes.Contains("etel_lastname"))
                    {
                        if (postImage.Attributes["etel_lastname"] != null)
                        {
                            Customer.Attributes.Add("lastname", postImage.Attributes["etel_lastname"].ToString());
                            fullname += postImage.Attributes["etel_lastname"].ToString();
                        }
                    }
                    if (fullname != "")
                    {
                        Customer.Attributes.Add("fullname", fullname);
                    }
                    if (postImage.Attributes.Contains("amxperu_socialprofilefacebook"))
                    {
                        if (postImage.Attributes["amxperu_socialprofilefacebook"] != null)
                        {
                            Customer.Attributes.Add("etel_socialmediafacebook", postImage.Attributes["amxperu_socialprofilefacebook"].ToString());
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_socialprofileinstagram"))
                    {
                        if (postImage.Attributes["amxperu_socialprofileinstagram"] != null)
                        {
                            Customer.Attributes.Add("amxperu_socialmediainstagram", postImage.Attributes["amxperu_socialprofileinstagram"].ToString());
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_socialprofilelinkedin"))
                    {
                        if (postImage.Attributes["amxperu_socialprofilelinkedin"] != null)
                        {
                            Customer.Attributes.Add("etel_socialmedialinkedin", postImage.Attributes["amxperu_socialprofilelinkedin"].ToString());
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_socialprofiletwitter"))
                    {
                        if (postImage.Attributes["amxperu_socialprofiletwitter"] != null)
                        {
                            Customer.Attributes.Add("etel_socialmediatwitter", postImage.Attributes["amxperu_socialprofiletwitter"].ToString());
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_workplace"))
                    {
                        if (postImage.Attributes["amxperu_workplace"] != null)
                        {
                            Customer.Attributes.Add("amxperu_workplace", postImage.Attributes["amxperu_workplace"].ToString());
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_prefferedgivenname"))
                    {
                        if (postImage.Attributes["amxperu_prefferedgivenname"] != null)
                        {
                            Customer.Attributes.Add("etel_prefferedgivenname", postImage.Attributes["amxperu_prefferedgivenname"].ToString());
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_placeofbirth"))
                    {
                        if (postImage.Attributes["amxperu_placeofbirth"] != null)
                        {
                            Customer.Attributes.Add("etel_placeofbirth", postImage.Attributes["amxperu_placeofbirth"].ToString());
                        }
                    }
                    if (postImage.Attributes.Contains("etel_passportnumber"))
                    {
                        if (postImage.Attributes["etel_passportnumber"] != null)
                        {
                            Customer.Attributes.Add("etel_passportnumber", postImage.Attributes["etel_passportnumber"].ToString());
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_otherphonehome"))
                    {
                        if (postImage.Attributes["amxperu_otherphonehome"] != null)
                        {
                            Customer.Attributes.Add("amxperu_otherphonehome", postImage.Attributes["amxperu_otherphonehome"].ToString());
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_otherphonebusiness"))
                    {
                        if (postImage.Attributes["amxperu_otherphonebusiness"] != null)
                        {
                            Customer.Attributes.Add("amxperu_otherphonebusiness", postImage.Attributes["amxperu_otherphonebusiness"].ToString());
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_motherslastname"))
                    {
                        if (postImage.Attributes["amxperu_motherslastname"] != null)
                        {
                            Customer.Attributes.Add("amxperu_motherslastname", postImage.Attributes["amxperu_motherslastname"].ToString());
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_mainphone"))
                    {
                        if (postImage.Attributes["amxperu_mainphone"] != null)
                        {
                            Customer.Attributes.Add("mobilephone", postImage.Attributes["amxperu_mainphone"].ToString());
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_jobtitle"))
                    {
                        if (postImage.Attributes["amxperu_jobtitle"] != null)
                        {
                            Customer.Attributes.Add("jobtitle", postImage.Attributes["amxperu_jobtitle"].ToString());
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_email"))
                    {
                        if (postImage.Attributes["amxperu_email"] != null)
                        {
                            Customer.Attributes.Add("emailaddress1", postImage.Attributes["amxperu_email"].ToString());
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_companyname"))
                    {
                        if (postImage.Attributes["amxperu_companyname"] != null)
                        {
                            Customer.Attributes.Add("amxperu_businessname", postImage.Attributes["amxperu_companyname"].ToString());
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_clarocommunityuser"))
                    {
                        if (postImage.Attributes["amxperu_clarocommunityuser"] != null)
                        {
                            Customer.Attributes.Add("amxperu_clarocommunityuser", postImage.Attributes["amxperu_clarocommunityuser"].ToString());
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_claroaccountuser"))
                    {
                        if (postImage.Attributes["amxperu_claroaccountuser"] != null)
                        {
                            Customer.Attributes.Add("amxperu_claroaccountuser", postImage.Attributes["amxperu_claroaccountuser"].ToString());
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_allowsocialnetwork"))
                    {
                        if ((OptionSetValue)postImage.Attributes["amxperu_allowsocialnetwork"] != null)
                        {
                            int socialNetwork = (postImage.Attributes["amxperu_allowsocialnetwork"] as OptionSetValue).Value;
                            Customer.Attributes.Add("amxperu_allowsocialnetworks", new OptionSetValue(socialNetwork));
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_allowphonecall"))
                    {
                        if ((OptionSetValue)postImage.Attributes["amxperu_allowphonecall"] != null)
                        {
                            int phone = (postImage.Attributes["amxperu_allowphonecall"] as OptionSetValue).Value;
                            Customer.Attributes.Add("amxperu_allowphone", new OptionSetValue(phone));
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_allowsms"))
                    {
                        if ((OptionSetValue)postImage.Attributes["amxperu_allowsms"] != null)
                        {
                            int sms = (postImage.Attributes["amxperu_allowsms"] as OptionSetValue).Value;
                            Customer.Attributes.Add("amxperu_allowsmsinstantmessaging", new OptionSetValue(sms));
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_allowmail"))
                    {
                        if ((OptionSetValue)postImage.Attributes["amxperu_allowmail"] != null)
                        {
                            int mail = (postImage.Attributes["amxperu_allowmail"] as OptionSetValue).Value;
                            Customer.Attributes.Add("amxperu_allowmail", new OptionSetValue(mail));
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_allowvisit"))
                    {
                        if ((OptionSetValue)postImage.Attributes["amxperu_allowvisit"] != null)
                        {
                            int visit = (postImage.Attributes["amxperu_allowvisit"] as OptionSetValue).Value;
                            Customer.Attributes.Add("amxperu_allowvisit", new OptionSetValue(visit));
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_allowemail"))
                    {
                        if ((OptionSetValue)postImage.Attributes["amxperu_allowemail"] != null)
                        {
                            int email = (postImage.Attributes["amxperu_allowemail"] as OptionSetValue).Value;
                            Customer.Attributes.Add("amxperu_allowemail", new OptionSetValue(email));
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_allowbulkemail"))
                    {
                        if ((OptionSetValue)postImage.Attributes["amxperu_allowbulkemail"] != null)
                        {
                            int bulkemail = (postImage.Attributes["amxperu_allowbulkemail"] as OptionSetValue).Value;
                            Customer.Attributes.Add("amxperu_allowbulkemail", new OptionSetValue(bulkemail));
                        }
                    }                   
                    if (postImage.Attributes.Contains("amxperu_documenttype"))
                    {
                        if ((OptionSetValue)postImage.Attributes["amxperu_documenttype"] != null)
                        {
                            int documentType = (postImage.Attributes["amxperu_documenttype"] as OptionSetValue).Value;
                            Customer.Attributes.Add("amxperu_documenttype", new OptionSetValue(documentType));
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_language"))
                    {
                        if ((OptionSetValue)postImage.Attributes["amxperu_language"] != null)
                        {
                            int language = (postImage.Attributes["amxperu_language"] as OptionSetValue).Value;
                            Customer.Attributes.Add("etel_languagecode", new OptionSetValue(language));
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_gender"))
                    {
                        if ((OptionSetValue)postImage.Attributes["amxperu_gender"] != null)
                        {
                            int gender = (postImage.Attributes["amxperu_gender"] as OptionSetValue).Value;
                            Customer.Attributes.Add("gendercode", new OptionSetValue(gender));

                        }
                    }
                    if (postImage.Attributes.Contains("etel_salutation"))
                    {
                        if ((OptionSetValue)postImage.Attributes["etel_salutation"] != null)
                        {
                            int salutationcode = (postImage.Attributes["etel_salutation"] as OptionSetValue).Value;
                            Customer.Attributes.Add("etel_salutationcode", new OptionSetValue(salutationcode));
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_maritalstatus"))
                    {
                        if ((OptionSetValue)postImage.Attributes["amxperu_maritalstatus"] != null)
                        {
                            int maritalStatus = (postImage.Attributes["amxperu_maritalstatus"] as OptionSetValue).Value;
                            Customer.Attributes.Add("familystatuscode", new OptionSetValue(maritalStatus));
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_role"))
                    {
                        if ((OptionSetValue)postImage.Attributes["amxperu_role"] != null)
                        {
                            int accountRole = (postImage.Attributes["amxperu_role"] as OptionSetValue).Value;
                            Customer.Attributes.Add("accountrolecode", new OptionSetValue(accountRole));
                        }
                    }
                    if (postImage.Attributes.Contains("amxperu_contactmethod"))
                    {
                        if ((OptionSetValue)postImage.Attributes["amxperu_contactmethod"] != null)
                        {
                            int contactMethod = (postImage.Attributes["amxperu_contactmethod"] as OptionSetValue).Value;
                            Customer.Attributes.Add("preferredcontactmethodcode", new OptionSetValue(contactMethod));
                        }
                    }
                    if (postImage.Attributes.Contains("etel_dateofbirth"))
                    {
                        if (postImage.Attributes["etel_dateofbirth"] != null)
                        {
                            DateTime DOB = (DateTime)postImage.Attributes["etel_dateofbirth"];
                            Customer.Attributes.Add("birthdate", DOB.Date);
                        }
                    }
                    service.Update(Customer);
                }
            }
        }
        private bool PassDocTypeDocIdToBSCS(Entity postEntityImage, IOrganizationService service)
        {
            bool flag = false;
            string docType = string.Empty;
            string docId = string.Empty;
            string IndividualCustomerGuid = string.Empty;
            string language = string.Empty;
            string salutation = string.Empty;
            string maritalStatus = string.Empty;
            string gender = string.Empty;
            string firstName = string.Empty;
            string lastName = string.Empty;
            string Mobile = string.Empty;
            string DateOfBirth = string.Empty;
            Guid Individual = Guid.Empty;
            try
            {
                if (postEntityImage.Attributes.Contains("amxperu_documenttype"))
                {
                    if ((OptionSetValue)postEntityImage.Attributes["amxperu_documenttype"] != null)
                    {
                        int doctype = (postEntityImage.Attributes["amxperu_documenttype"] as OptionSetValue).Value;
                        docType = doctype.ToString();
                    }
                }
                if (postEntityImage.Attributes.Contains("etel_passportnumber"))
                {
                    if (!string.IsNullOrEmpty(postEntityImage.Attributes["etel_passportnumber"].ToString()))
                    {
                        docId = postEntityImage.Attributes["etel_passportnumber"].ToString();
                    }
                }
                if (postEntityImage.Attributes.Contains("etel_customerid"))
                {
                    if ((EntityReference)postEntityImage.Attributes["etel_customerid"] != null)
                    {
                        Individual = (postEntityImage.Attributes["etel_customerid"] as EntityReference).Id;
                        IndividualCustomerGuid = Individual.ToString();
                    }
                }
                if (postEntityImage.Attributes.Contains("etel_firstname"))
                {
                    if (postEntityImage.Attributes["etel_firstname"] != null)
                    {
                        firstName = postEntityImage.Attributes["etel_firstname"].ToString();
                    }
                }
                if (postEntityImage.Attributes.Contains("etel_lastname"))
                {
                    if (postEntityImage.Attributes["etel_lastname"] != null)
                    {
                        lastName = postEntityImage.Attributes["etel_lastname"].ToString();
                    }
                }
                if (postEntityImage.Attributes.Contains("amxperu_mainphone"))
                {
                    if (postEntityImage.Attributes["amxperu_mainphone"] != null)
                    {
                        Mobile = postEntityImage.Attributes["amxperu_mainphone"].ToString();
                    }
                }
                if (postEntityImage.Attributes.Contains("amxperu_gender"))
                {
                    if ((OptionSetValue)postEntityImage.Attributes["amxperu_gender"] != null)
                    {
                        int gendercode = (postEntityImage.Attributes["amxperu_gender"] as OptionSetValue).Value;
                        gender = gendercode.ToString();
                    }
                }
                if (postEntityImage.Attributes.Contains("amxperu_language"))
                {
                    if ((OptionSetValue)postEntityImage.Attributes["amxperu_language"] != null)
                    {
                        int languagecode = (postEntityImage.Attributes["amxperu_language"] as OptionSetValue).Value;
                        language = languagecode.ToString();
                    }
                }
                if (postEntityImage.Attributes.Contains("etel_salutation"))
                {
                    if ((OptionSetValue)postEntityImage.Attributes["etel_salutation"] != null)
                    {
                        int salutationcode = (postEntityImage.Attributes["etel_salutation"] as OptionSetValue).Value;
                        salutation = salutationcode.ToString();
                    }
                }
                if (postEntityImage.Attributes.Contains("amxperu_maritalstatus"))
                {
                    if ((OptionSetValue)postEntityImage.Attributes["amxperu_maritalstatus"] != null)
                    {
                        int maritalstatus = (postEntityImage.Attributes["amxperu_maritalstatus"] as OptionSetValue).Value;
                        maritalStatus = maritalstatus.ToString();
                    }
                }
                if (postEntityImage.Attributes.Contains("etel_dateofbirth"))
                {
                    if (postEntityImage.Attributes["etel_dateofbirth"] != null)
                    {
                        DateTime DOB = (DateTime)postEntityImage.Attributes["etel_dateofbirth"];
                        DateOfBirth = DOB.ToString();
                    }
                }

                BasicHttpBinding binding = new BasicHttpBinding
                {
                    Name = "JavaBilServiceBinding",
                    OpenTimeout = new TimeSpan(0, 15, 0),
                    CloseTimeout = new TimeSpan(0, 15, 0),
                    ReceiveTimeout = new TimeSpan(0, 15, 0),
                    SendTimeout = new TimeSpan(0, 15, 0),
                };

                string BILUrl = common.RetrieveAmxConfigValue(service, "BILCustomerServiceUrl");
                EndpointAddress endPointAddress = new EndpointAddress(BILUrl);
                CustomerServicesClient _client = new CustomerServicesClient(binding, endPointAddress);
                Customer arg0 = new Customer();
                arg0.partyRoleId = IndividualCustomerGuid;
                arg0.externalId = GetCustomerExternalID(IndividualCustomerGuid, service);
                PartyRoleType _PartyRoleType = new PartyRoleType();
                _PartyRoleType.name = "Customer";
                arg0.partyRoleType = _PartyRoleType;
                arg0.customerStatus = "1";
                arg0.type = "2";
                arg0.isPaymentResponsible = true;
                arg0.isPaymentResponsibleSpecified = true;
                Individual _Individual = new Individual();
                _Individual.name = firstName;
                _Individual.surname = lastName;
                _Individual.language = language;
                _Individual.maritalStatus = maritalStatus;
                _Individual.gender = gender;
                _Individual.formOfAddress = salutation;
                arg0.party = _Individual;

                CustomerAccountContact[] _CustomerAccountContactArray = new CustomerAccountContact[1];
                CustomerAccountContact _CustomerAccountContact = new CustomerAccountContact();
                ContactMedium[] _ContactMediumArray = new ContactMedium[1];
                PostalContact _postalContact = new PostalContact();
                _postalContact.externalId = "1";
                _postalContact.id = "1fa50c7d-06f9-e611-810b-00505601173a";
                _ContactMediumArray[0] = _postalContact;
                _CustomerAccountContact.contactMedium = _ContactMediumArray;
                _CustomerAccountContactArray[0] = _CustomerAccountContact;

                arg0.customerAccountContact = _CustomerAccountContactArray;

                //Pass DocType & DocId
                CommonCharacteristicValue[] _CommonCharacteristicValueArray = new CommonCharacteristicValue[2];
                CommonCharacteristicValue _CommonCharacteristicValueDocType = new CommonCharacteristicValue();
                CommonCharacteristicValue _CommonCharacteristicValueDocId = new CommonCharacteristicValue();

                SpecCharacteristic _SpecCharacteristicDocType = new SpecCharacteristic();
                _SpecCharacteristicDocType.name = "DocumentId";
                _SpecCharacteristicDocType.description = docType;

                SpecCharacteristic _SpecCharacteristicDocId = new SpecCharacteristic();
                _SpecCharacteristicDocId.name = "DocumentIdNo";
                _SpecCharacteristicDocId.description = docId;

                _CommonCharacteristicValueDocType.CommonSpecCharacteristic = _SpecCharacteristicDocType;
                _CommonCharacteristicValueDocId.CommonSpecCharacteristic = _SpecCharacteristicDocId;

                _CommonCharacteristicValueArray[0] = _CommonCharacteristicValueDocType;
                _CommonCharacteristicValueArray[1] = _CommonCharacteristicValueDocId;

                arg0.commonCharacteristicValue = _CommonCharacteristicValueArray;

                Customer _customerResponse = new Customer();

                _customerResponse = _client.updateCustomer(arg0);

                if (_customerResponse != null && !string.IsNullOrEmpty(_customerResponse.externalId))
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return flag;
        }
    }
}
