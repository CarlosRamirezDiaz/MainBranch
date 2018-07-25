using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

namespace AmxPeruPlugins
{
    public class CustomerAddressUpdate : IPlugin
    {
        //Variables : Scope Plugin
        IOrganizationServiceFactory OrganizationServiceFactory = null;
        IOrganizationService OrganizationService = null;
        IPluginExecutionContext PluginExecutiongContext = null;
        Entity PluginScopeEntity = null;
        Entity PostEntityImage = null;
        Guid AssociatedCustomerAddressRecordGuid = Guid.Empty;
        //Variables : Scope Plugin

        public void Execute(IServiceProvider serviceProvider)
        { 
            try
            {
                PluginExecutiongContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                if (PluginExecutiongContext.InputParameters.Contains("Target") &&
                    PluginExecutiongContext.InputParameters["Target"] is Entity &&
                    PluginExecutiongContext.PostEntityImages.Contains("POSTIMG"))
                {
                    PluginScopeEntity = (Entity)PluginExecutiongContext.InputParameters["Target"];
                    PostEntityImage = (Entity)PluginExecutiongContext.PostEntityImages["POSTIMG"];
                    OrganizationServiceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                    OrganizationService = OrganizationServiceFactory.CreateOrganizationService(PluginExecutiongContext.UserId);

                    //Associated Customer Address REcord Guid
                    AssociatedCustomerAddressRecordGuid = (PostEntityImage.Attributes.Contains("etel_customeraddress")) ? (PostEntityImage.Attributes["etel_customeraddress"] as EntityReference).Id : Guid.Empty;

                    if (AssociatedCustomerAddressRecordGuid != Guid.Empty)
                    {
                        UpdateAddressInCRM();
                        BILogSchema _BILogSchema = new BILogSchema()
                        {
                            Channel = "Internal",
                            Description = "Customer Address Updated",
                            Subject = "Update Customer Address",
                            LoggedInUserId = PluginExecutiongContext.UserId
                        };
                        CreateBILogValues(PostEntityImage, OrganizationService, _BILogSchema);

                        //if (UpdateAddressInBscs())
                        //{
                        //    throw new InvalidPluginExecutionException("BSCS Updated");
                        //    //if (UpdateAddressInCRM())
                        //    //{
                        //    //    //BILogSchema _BILogSchema = new BILogSchema()
                        //    //    //{
                        //    //    //    Channel = "Internal",
                        //    //    //    Description = "Customer Address Updated",
                        //    //    //    Subject = "Update Customer Address",
                        //    //    //    LoggedInUserId = PluginExecutiongContext.UserId
                        //    //    //};
                        //    //    //CreateBILogValues(PostEntityImage, OrganizationService, _BILogSchema);
                        //    //}
                        //}
                    }
                    else
                    {
                        throw new InvalidPluginExecutionException("TCRM Plugin : Associated Customer Address NOT found");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException("TCRM Plugin : " + ex.Message);
            }
        }

        private bool UpdateAddressInBscs()
        {
            bool successFlag = false;
            string BscsApiUriConfigKey = "BscsApiUriCustomerAddressUpdate";
            string SoapXmlText = @"<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:add='http://ericsson.com/services/ws_CIL_7/addresswrite' xmlns:ses='http://ericsson.com/services/ws_CIL_7/sessionchange'>
                                       <soapenv:Header>
                                          <wsse:Security soapenv:mustUnderstand='1' xmlns:wsse='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd' xmlns:wsu='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd'>
                                             <wsse:UsernameToken wsu:Id='UsernameToken-5F82EB5633F990A9A215039160482071'>
                                                <wsse:Username>ADMX</wsse:Username>
                                                <wsse:Password Type='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText'>ADMX</wsse:Password>
                                                <wsse:Nonce EncodingType='http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary'>3VsUusVk4p6ucgzCYWwuqg==</wsse:Nonce>
                                                <wsu:Created>2017-08-28T10:27:28.205Z</wsu:Created>
                                             </wsse:UsernameToken>
                                          </wsse:Security>
                                       </soapenv:Header>
                                       <soapenv:Body>
                                          <add:addressWriteRequest>  
                                             <add:inputAttributes> 
                                                <add:adrStreet>?amxperu_street1?</add:adrStreet>                                                
                                                <add:adrStreetno>?etel_street2?</add:adrStreetno>                                                
                                                <add:adrState>?amxperu_provincecode?</add:adrState>                                                
                                                <add:adrPhn1Area>?street3?</add:adrPhn1Area>                                                
                                                <add:adrPhn1>?street4?</add:adrPhn1>                                                
                                                <add:adrZip>?etel_postalcode?</add:adrZip>                
                                                <add:countryId>?etel_countryid?</add:countryId>                                                
                                                <add:adrCity>?amxperu_provincecode?</add:adrCity>             
                                                <add:csIdPub>?etel_externalid?</add:csIdPub>                                                
                                                <add:adrSeq>?sequenceNumber?</add:adrSeq>
                                             </add:inputAttributes>         
                                             <add:sessionChangeRequest>            
                                                <ses:values>
                                                   <ses:item>
                                                      <ses:key>BU_ID</ses:key>
                                                      <ses:value>2</ses:value>
                                                   </ses:item>
                                                </ses:values>
                                             </add:sessionChangeRequest>
                                          </add:addressWriteRequest>
                                       </soapenv:Body>
                                    </soapenv:Envelope>";
            string BscsApiUri = string.Empty;
            try
            {
                //Get the bascs api uri from crm config
                BscsApiUri = RetrieveAmxConfigValue(OrganizationService, BscsApiUriConfigKey);

                SoapXmlText = SoapXmlText.Replace("?amxperu_street1?", (PostEntityImage.Attributes.Contains("amxperu_street1")) ? PostEntityImage.FormattedValues["amxperu_street1"].ToString() : "Val_Not_Present_SampleVal");
                SoapXmlText = SoapXmlText.Replace("?etel_street2?", (PostEntityImage.Attributes.Contains("etel_street2")) ? PostEntityImage.Attributes["etel_street2"].ToString() : "Val_Not_Present_SampleVal");
                SoapXmlText = SoapXmlText.Replace("?amxperu_provincecode?", FetchProvince());
                SoapXmlText = SoapXmlText.Replace("?street3?", "Sample_Val");
                SoapXmlText = SoapXmlText.Replace("?street4?", "Sample_Val");
                SoapXmlText = SoapXmlText.Replace("?etel_postalcode?", (PostEntityImage.Attributes.Contains("etel_postalcode")) ? PostEntityImage.Attributes["etel_postalcode"].ToString() : "Val_Not_Present_SampleVal");
                SoapXmlText = SoapXmlText.Replace("?etel_countryid?", FetchCountryCode());
                SoapXmlText = SoapXmlText.Replace("?etel_externalid?", FetchCustomerExternalIdViaGuid());
                SoapXmlText = SoapXmlText.Replace("?sequenceNumber?", FetchSequenceNumber());

                HttpWebRequest request = CreateWebRequest(BscsApiUri);
                XmlDocument soapEnvelopeXml = new XmlDocument();
                using (Stream stream = request.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }

                using (WebResponse response = request.GetResponse())
                {
                    throw new InvalidPluginExecutionException("BSCS Updated");
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        string soapResult = rd.ReadToEnd();
                        successFlag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return successFlag;
        }

        public HttpWebRequest CreateWebRequest(string BscsApiUri)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(BscsApiUri);
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private string RetrieveAmxConfigValue(IOrganizationService OrgService, string keyName)
        {
            string configValue = string.Empty;
            string fetchXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                  <entity name='amxperu_amxconfigurations'>
                                    <attribute name='amxperu_amxconfigurationsid' />
                                    <attribute name='amxperu_value' />
                                    <filter type='and'>
                                      <condition attribute='amxperu_name' operator='eq' value='{0}' />
                                    </filter>
                                  </entity>
                                </fetch>";

            try
            {
                fetchXml = string.Format(fetchXml, keyName);
                EntityCollection _EntityCollection = OrgService.RetrieveMultiple(new FetchExpression(fetchXml));
                if (_EntityCollection != null && _EntityCollection.Entities.Count > 0)
                {
                    if (_EntityCollection.Entities.Count == 1)
                    {
                        configValue = _EntityCollection[0].GetAttributeValue<string>("amxperu_value");
                    }
                    else
                    {
                        //throw new InvalidPluginExecutionException(Constants.MultipleValuesFound + keyName);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return configValue;
        }

        private string FetchCustomerExternalIdViaGuid()
        {
            string csIdPub = string.Empty;
            string customerType = string.Empty;
            Guid customerGuid = Guid.Empty;

            try
            {
                if (PostEntityImage.Attributes.Contains("etel_individualcustomer"))
                {
                    customerType = "contact";
                    customerGuid = (PostEntityImage.Attributes["etel_individualcustomer"] as EntityReference).Id;
                    csIdPub = (OrganizationService.Retrieve(customerType, customerGuid, new ColumnSet("etel_externalid"))).Attributes["etel_externalid"].ToString();

                }
                else if (PostEntityImage.Attributes.Contains("etel_corporatecustomer"))
                {
                    customerType = "account";
                    customerGuid = (PostEntityImage.Attributes["etel_corporatecustomer"] as EntityReference).Id;
                    csIdPub = (OrganizationService.Retrieve(customerType, customerGuid, new ColumnSet("etel_externalid"))).Attributes["etel_externalid"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return csIdPub;
        }

        private string FetchCountryCode()
        {
            string CountryCode = string.Empty;

            try
            {
                Guid countryId = (PostEntityImage.Attributes.Contains("etel_countryid")) ? (PostEntityImage.Attributes["etel_countryid"] as EntityReference).Id : Guid.Empty;
                if (countryId != Guid.Empty)
                {
                    CountryCode = (OrganizationService.Retrieve("etel_country", countryId, new ColumnSet("etel_value"))).Attributes["etel_value"].ToString();
                }
                else
                {
                    throw new InvalidPluginExecutionException("TCRM Plugin : No Country Code Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CountryCode;
        }

        private string FetchProvince()
        {
            string ProvinceCode = string.Empty;

            try
            {
                Guid ProvinceId = (PostEntityImage.Attributes.Contains("amxperu_province")) ? (PostEntityImage.Attributes["amxperu_province"] as EntityReference).Id : Guid.Empty;
                if (ProvinceId != Guid.Empty)
                {
                    ProvinceCode = (OrganizationService.Retrieve("amxperu_province", ProvinceId, new ColumnSet("amxperu_name"))).Attributes["amxperu_name"].ToString();
                }
                else
                {
                    throw new InvalidPluginExecutionException("TCRM Plugin : No Province Code Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ProvinceCode;
        }

        private string FetchSequenceNumber()
        {
            string SequenceNumber = string.Empty;

            try
            {
                if (AssociatedCustomerAddressRecordGuid != Guid.Empty)
                {
                    SequenceNumber = (OrganizationService.Retrieve("etel_customeraddress", AssociatedCustomerAddressRecordGuid, new ColumnSet("etel_addressnumber"))).Attributes["etel_addressnumber"].ToString();
                }
                else
                {
                    throw new InvalidPluginExecutionException("TCRM Plugin : No Sequence Code Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return SequenceNumber;
        }

        public static void CreateBILogValues(Entity postImage, IOrganizationService OrgService, BILogSchema biLogSchema)
        {
            string customerTypeName = string.Empty;
            string CustomerTypeField = string.Empty;
            string customerFilterField = string.Empty;
            Guid customerGuid = Guid.Empty;
            string fetchXmlBiHeader = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                      <entity name='etel_bi_header'>
                                        <attribute name='activityid' />
                                        <attribute name='createdon' />
                                        <order attribute='subject' descending='false' />
                                        <filter type='and'>
                                          <condition attribute='createdby' operator='eq' value='{0}' />
                                          <condition attribute='etel_headerstatus' operator='eq' value='1' />
                                        </filter>
                                      </entity>
                                    </fetch>";
            Guid loggedinUserId = Guid.Empty;
            Guid BIHeaderRecordGuid = Guid.Empty;

            try
            {
                if (biLogSchema != null)
                {
                    if (biLogSchema.LoggedInUserId != Guid.Empty)
                    {
                        loggedinUserId = biLogSchema.LoggedInUserId;
                    }
                }

                Entity biLogActivityEnt = new Entity("etel_bi_log");
                if (postImage.Attributes.Contains("amxbase_isexternal"))
                {
                    if (!(bool)postImage.Attributes["amxbase_isexternal"])
                    {
                        fetchXmlBiHeader = string.Format(fetchXmlBiHeader, loggedinUserId);
                        EntityCollection _EntityCollection = OrgService.RetrieveMultiple(new FetchExpression(fetchXmlBiHeader));

                        if (_EntityCollection != null)
                        {
                            if (_EntityCollection.Entities.Count > 0)
                            {
                                //Get the BI Header for this BI Activity
                                BIHeaderRecordGuid = new Guid(_EntityCollection.Entities[0].Attributes["activityid"].ToString());
                            }
                        }

                        if (BIHeaderRecordGuid != Guid.Empty)
                        {
                            //Update the Subject of the Bi Header with the BI Activity
                            Entity tempEnt = new Entity("etel_bi_header");
                            ColumnSet columnSet = new ColumnSet(new string[] { "activityid", "createdon" });
                            tempEnt = OrgService.Retrieve(tempEnt.LogicalName, BIHeaderRecordGuid, columnSet);
                            tempEnt.Attributes.Add("subject", "Customer Address Update");
                            OrgService.Update(tempEnt);
                            biLogActivityEnt.Attributes.Add("etel_bi_headerid", new EntityReference("etel_bi_header", BIHeaderRecordGuid));
                        }
                    }
                }

                biLogActivityEnt.Attributes.Add("scheduledend", DateTime.Now);
                biLogActivityEnt.Attributes.Add("subject", biLogSchema.Subject);
                biLogActivityEnt.Attributes.Add("etel_description", biLogSchema.Description);
                biLogActivityEnt.Attributes.Add("etel_customerchannel", biLogSchema.Channel);
                if (postImage.Attributes.Contains("etel_individualcustomer"))
                {
                    customerTypeName = "contact";
                    customerFilterField = "contactid";
                    CustomerTypeField = "etel_individualcustomerid";
                    customerGuid = (postImage.Attributes["etel_individualcustomer"] as EntityReference).Id;
                }
                else if (postImage.Attributes.Contains("etel_corporatecustomer"))
                {
                    customerTypeName = "account";
                    customerFilterField = "accountid";
                    CustomerTypeField = "etel_corporatecustomerid";
                    customerGuid = (postImage.Attributes["etel_corporatecustomer"] as EntityReference).Id;
                }
                QueryExpression searchQuery = new QueryExpression(customerTypeName);
                searchQuery.Criteria.AddCondition(customerFilterField, ConditionOperator.Equal, customerGuid);
                EntityCollection contactRecords = OrgService.RetrieveMultiple(searchQuery);
                if (contactRecords.Entities.Count > 0)
                {
                    biLogActivityEnt[CustomerTypeField] = new EntityReference(contactRecords[0].LogicalName, contactRecords[0].Id);
                    Entity party1 = new Entity("activityparty");
                    party1["partyid"] = new EntityReference(contactRecords[0].LogicalName, contactRecords[0].Id);
                    EntityCollection entCollection = new EntityCollection();
                    entCollection.Entities.Add(party1);
                    biLogActivityEnt["customers"] = entCollection;
                }
                biLogActivityEnt.Attributes.Add("regardingobjectid", new EntityReference(postImage.LogicalName, postImage.Id));
                Guid CreatedBiLogGuid = OrgService.Create(biLogActivityEnt);
                if (postImage.LogicalName == "etel_ordercapture")
                {
                    if (CreatedBiLogGuid != null)
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
                        OrgService.Execute(orgrequest);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool UpdateAddressInCRM()
        {
            bool updateFlag = false;

            try
            {
                Entity CustomerAdddressEntity = new Entity("etel_customeraddress", AssociatedCustomerAddressRecordGuid);

                if (PostEntityImage.Attributes.Contains("amxperu_longitude"))
                {
                    if (PostEntityImage.Attributes["amxperu_longitude"] != null)
                    {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("amxperu_longitude", PostEntityImage.Attributes["amxperu_longitude"]));
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_latitude"))
                {
                    if (PostEntityImage.Attributes["amxperu_latitude"] != null)
                    {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("amxperu_latitude", PostEntityImage.Attributes["amxperu_latitude"]));
                    }
                }
                //updated with new attribute list START
                if (PostEntityImage.Attributes.Contains("amxperu_square"))
                {
                    if (PostEntityImage.Attributes["amxperu_square"] != null)
                    {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("amxperu_square", PostEntityImage.Attributes["amxperu_square"]));
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_allotment"))
                {
                    if (PostEntityImage.Attributes["amxperu_allotment"] != null)
                    {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("amxperu_allotment", PostEntityImage.Attributes["amxperu_allotment"]));
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_number"))
                {
                    if (PostEntityImage.Attributes["amxperu_number"] != null)
                    {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("amxperu_number", PostEntityImage.Attributes["amxperu_number"]));
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_grouping"))
                {
                    if (PostEntityImage.Attributes["amxperu_grouping"] != null)
                    {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("amxperu_grouping", PostEntityImage.Attributes["amxperu_grouping"]));
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_street1"))
                {
                    if ((OptionSetValue)PostEntityImage.Attributes["amxperu_street1"] != null)
                    {
                        int avenueStreet = (PostEntityImage.Attributes["amxperu_street1"] as OptionSetValue).Value;
                        CustomerAdddressEntity.Attributes.Add("amxperu_street1", new OptionSetValue(avenueStreet));
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_building"))
                {
                    if ((OptionSetValue)PostEntityImage.Attributes["amxperu_building"] != null)
                    {
                        int building = (PostEntityImage.Attributes["amxperu_building"] as OptionSetValue).Value;
                        CustomerAdddressEntity.Attributes.Add("amxperu_building", new OptionSetValue(building));
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_buildtype"))
                {
                    if ((OptionSetValue)PostEntityImage.Attributes["amxperu_buildtype"] != null)
                    {
                        int buildtype = (PostEntityImage.Attributes["amxperu_buildtype"] as OptionSetValue).Value;
                        CustomerAdddressEntity.Attributes.Add("amxperu_buildtype", new OptionSetValue(buildtype));
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_billingemail"))
                {
                    if (PostEntityImage.Attributes["amxperu_billingemail"] != null)
                    {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("amxperu_billingemail", PostEntityImage.Attributes["amxperu_billingemail"]));
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_normalized"))
                {
                    if ((bool)PostEntityImage.Attributes["amxperu_normalized"])
                    {
                        CustomerAdddressEntity.Attributes.Add("amxperu_normalized", true);
                    }
                    else
                    {
                        CustomerAdddressEntity.Attributes.Add("amxperu_normalized", false);
                    }
                }
                if (PostEntityImage.Attributes.Contains("etel_street3"))
                {
                    if (PostEntityImage.Attributes["etel_street3"] != null)
                    {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("etel_addressline3", PostEntityImage.Attributes["etel_street3"]));
                    }
                }
                //updated with new attribute list END
                if (PostEntityImage.Attributes.Contains("amxperu_ubigeo"))
                {
                    if (PostEntityImage.Attributes["amxperu_ubigeo"] != null)
                    {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("amxperu_ubigeo", PostEntityImage.Attributes["amxperu_ubigeo"]));
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_referencedescription"))
                {
                    if (PostEntityImage.Attributes["amxperu_referencedescription"] != null)
                    {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("amxperu_referencedescription", PostEntityImage.Attributes["amxperu_referencedescription"]));
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_department"))
                {
                    if ((EntityReference)PostEntityImage.Attributes["amxperu_department"] != null)
                    {
                        EntityReference department = new EntityReference("amxperu_department", (PostEntityImage.Attributes["amxperu_department"] as EntityReference).Id);
                        CustomerAdddressEntity.Attributes.Add("amxperu_department", department);
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_province"))
                {
                    if ((EntityReference)PostEntityImage.Attributes["amxperu_province"] != null)
                    {
                        EntityReference province = new EntityReference("amxperu_province", (PostEntityImage.Attributes["amxperu_province"] as EntityReference).Id);
                        CustomerAdddressEntity.Attributes.Add("amxperu_province", province);
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_district"))
                {
                    if ((EntityReference)PostEntityImage.Attributes["amxperu_district"] != null)
                    {
                        EntityReference district = new EntityReference("amxperu_district", (PostEntityImage.Attributes["amxperu_district"] as EntityReference).Id);
                        CustomerAdddressEntity.Attributes.Add("amxperu_district", district);
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_apartmenttypeinterior"))
                {
                    if ((OptionSetValue)PostEntityImage.Attributes["amxperu_apartmenttypeinterior"] != null)
                    {
                        int apartmentInterior = (PostEntityImage.Attributes["amxperu_apartmenttypeinterior"] as OptionSetValue).Value;
                        CustomerAdddressEntity.Attributes.Add("amxperu_apartmenttypeinterior", new OptionSetValue(apartmentInterior));
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_blockedifice"))
                {
                    if ((OptionSetValue)PostEntityImage.Attributes["amxperu_blockedifice"] != null)
                    {
                        int blockEdifice = (PostEntityImage.Attributes["amxperu_blockedifice"] as OptionSetValue).Value;
                        CustomerAdddressEntity.Attributes.Add("amxperu_blockedifice", new OptionSetValue(blockEdifice));
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_populationzone"))
                {
                    if ((OptionSetValue)PostEntityImage.Attributes["amxperu_populationzone"] != null)
                    {
                        int populationZone = (PostEntityImage.Attributes["amxperu_populationzone"] as OptionSetValue).Value;
                        CustomerAdddressEntity.Attributes.Add("amxperu_populationzone", new OptionSetValue(populationZone));
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_zonetype"))
                {
                    if ((OptionSetValue)PostEntityImage.Attributes["amxperu_zonetype"] != null)
                    {
                        int zoneType = (PostEntityImage.Attributes["amxperu_zonetype"] as OptionSetValue).Value;
                        CustomerAdddressEntity.Attributes.Add("amxperu_zonetype", new OptionSetValue(zoneType));
                    }
                }
                if (PostEntityImage.Attributes.Contains("amxperu_urbanizationtype"))
                {
                    if ((OptionSetValue)PostEntityImage.Attributes["amxperu_urbanizationtype"] != null)
                    {
                        int urbanType = (PostEntityImage.Attributes["amxperu_urbanizationtype"] as OptionSetValue).Value;
                        CustomerAdddressEntity.Attributes.Add("amxperu_urbanizationtype", new OptionSetValue(urbanType));
                    }
                }
                if (PostEntityImage.Attributes.Contains("etel_customeraddresstypecode"))
                {
                    if ((OptionSetValue)PostEntityImage.Attributes["etel_customeraddresstypecode"] != null)
                    {
                        int addressType = (PostEntityImage.Attributes["etel_customeraddresstypecode"] as OptionSetValue).Value;
                        CustomerAdddressEntity.Attributes.Add("etel_customeraddresstypecode", new OptionSetValue(addressType));
                    }
                }
                if (PostEntityImage.Attributes.Contains("etel_street1"))
                {
                    if (PostEntityImage.Attributes["etel_street1"] != null)
                    {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("etel_addressline1", PostEntityImage.Attributes["etel_street1"]));
                    }
                }
                if (PostEntityImage.Attributes.Contains("etel_street2"))
                {
                    if (PostEntityImage.Attributes["etel_street2"] != null)
                    {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("etel_addressline2", PostEntityImage.Attributes["etel_street2"]));
                    }
                }
                if (PostEntityImage.Attributes.Contains("etel_postalcode"))
                {
                    if (PostEntityImage.Attributes["etel_postalcode"] != null)
                    {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("etel_postalcode", PostEntityImage.Attributes["etel_postalcode"]));
                    }
                }
                if (PostEntityImage.Attributes.Contains("etel_telephone1"))
                {
                    if (PostEntityImage.Attributes["etel_telephone1"] != null)
                    {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("etel_telephone1", PostEntityImage.Attributes["etel_telephone1"]));
                    }
                }
                if (PostEntityImage.Attributes.Contains("etel_telephone2"))
                {
                    if (PostEntityImage.Attributes["etel_telephone2"] != null)
                    {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("etel_telephone2", PostEntityImage.Attributes["etel_telephone2"]));
                    }
                }
                if (PostEntityImage.Attributes.Contains("etel_emailaddress"))
                {
                    if (PostEntityImage.Attributes["etel_emailaddress"] != null)
                    {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("etel_emailaddress", PostEntityImage.Attributes["etel_emailaddress"]));
                    }
                }
                if (PostEntityImage.Attributes.Contains("etel_fax"))
                {
                    if (PostEntityImage.Attributes["etel_fax"] != null)
                    {
                        CustomerAdddressEntity.Attributes.Add(new KeyValuePair<string, object>("etel_fax", PostEntityImage.Attributes["etel_fax"]));
                    }
                }
                if (PostEntityImage.Attributes.Contains("etel_countryid"))
                {
                    if ((EntityReference)PostEntityImage.Attributes["etel_countryid"] != null)
                    {
                        EntityReference country = new EntityReference("etel_country", (PostEntityImage.Attributes["etel_countryid"] as EntityReference).Id);
                        CustomerAdddressEntity.Attributes.Add("etel_countryid", country);
                    }
                }
                if (PostEntityImage.Attributes.Contains("etel_cityid"))
                {
                    if ((EntityReference)PostEntityImage.Attributes["etel_cityid"] != null)
                    {
                        EntityReference city = new EntityReference("etel_city", (PostEntityImage.Attributes["etel_cityid"] as EntityReference).Id);
                        CustomerAdddressEntity.Attributes.Add("etel_cityid", city);
                    }
                }

                OrganizationService.Update(CustomerAdddressEntity);
                updateFlag = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return updateFlag;
        }
    }

    //public class BILogSchema
    //{
    //    public Guid BiHeaderRecordGuid { get; set; }
    //    public Guid LoggedInUserId { get; set; }
    //    public string Subject { get; set; }
    //    public string Description { get; set; }
    //    public string Channel { get; set; }
    //}

    //public class BILogRequest
    //{
    //    public Guid BiHeaderRecordGuid { get; set; }
    //    public Guid LoggedInUserId { get; set; }
    //    public string Subject { get; set; }
    //    public string Description { get; set; }
    //    public string Channel { get; set; }

    //    public int CustomerType { get; set; }
    //    public Guid CustomerGuid { get; set; }

    //    public string RegargingEntityLogicialName { get; set; }
    //    public Guid RegargingEntityRecordGuid { get; set; }
    //}
}