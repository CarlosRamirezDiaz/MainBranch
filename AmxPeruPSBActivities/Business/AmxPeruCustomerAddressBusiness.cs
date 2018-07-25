using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AmxPeruPSBActivities.Business
{
    public class AmxPeruCustomerAddressBusiness
    {
        string Condition;
        public AmxPeruCustomerAddressResponse CreateAddress(AmxPeruCustomerAddressRequest _request, OrganizationServiceProxy _org)
        {
            AmxPeruCustomerAddressResponse _response = null;
            if (_request != null)
            {
                _response = new AmxPeruCustomerAddressResponse();
                Entity CreateAddress = new Entity("etel_customeraddressbusinessinteraction");
                string alert = ValidateRequiredFields(_request.AddressType, _request);
                if (alert != "")
                {
                    _response.Error = alert;
                    _response.CustomerAddressID = "";
                    return _response;
                }
                string postalcodeValidate = ValidatePostalCode(_request.ZIPPostalCode);
                if (postalcodeValidate != "")
                {
                    _response.Error = postalcodeValidate;
                    _response.CustomerAddressID = "";
                    return _response;
                }
                CreateAddress.Attributes["etel_customeraddresstypecode"] = new OptionSetValue(_request.AddressType);
                CreateAddress.Attributes["amxperu_zonetype"] = new OptionSetValue(_request.ZoneType);
                CreateAddress.Attributes["amxperu_blockedifice"] = new OptionSetValue(_request.BlockEdifice);
                CreateAddress.Attributes["amxperu_apartmenttypeinterior"] = new OptionSetValue(_request.ApartmentTypeInterior);
                CreateAddress.Attributes["amxperu_urbanizationtype"] = new OptionSetValue(_request.UrbanizationType);
                CreateAddress.Attributes["amxperu_populationzone"] = new OptionSetValue(_request.PopulationZone);
                CreateAddress.Attributes["etel_postalcode"] = _request.ZIPPostalCode.ToString();
                CreateAddress.Attributes["amxperu_longitude"] = _request.Longitude.ToString();
                CreateAddress.Attributes["amxperu_latitude"] = _request.Latitude.ToString();
                CreateAddress.Attributes["amxperu_referencedescription"] = _request.ReferenceDescription.ToString();
                CreateAddress.Attributes["etel_street2"] = _request.Street2.ToString();
                CreateAddress.Attributes["etel_street3"] = _request.Street3.ToString();
                CreateAddress.Attributes["amxperu_street1"] = new OptionSetValue(_request.Street1);
                //CreateAddress.Attributes["amxperu_building"] = new OptionSetValue(_request.Building);
                CreateAddress.Attributes["amxperu_buildtype"] = new OptionSetValue(_request.BuildType);
                CreateAddress.Attributes["amxperu_square"] = _request.Square.ToString();
                CreateAddress.Attributes["amxperu_allotment"] = _request.Allotment.ToString();
                CreateAddress.Attributes["amxperu_number"] = _request.Number.ToString();
                CreateAddress.Attributes["amxperu_grouping"] = _request.Grouping.ToString();
                //CreateAddress.Attributes["amxperu_billingemail"] = _request.BillingEmail.ToString();
                CreateAddress.Attributes["amxperu_normalized"] = _request.Normalized;
                Guid countryGuid = GetLookupGuidFromField("etel_country", "etel_code", _request.Country,_org);
                string EntityName = "";
                string AttributeName = "";
                string ColumnName = "";

                if (_request.CustomerType == 1)
                {
                    EntityName = "contact";
                    AttributeName = "etel_individualcustomer";
                    ColumnName = "fullname";
                }
                if (_request.CustomerType == 2)
                {
                    EntityName = "account";
                    AttributeName = "etel_corporatecustomer";
                    ColumnName = "name";
                }

                if (EntityName != "" && AttributeName != "")
                {
                    Entity customerRecord = GetCustomerValues(EntityName, "etel_externalid", _request.CustomerExternalId, ColumnName,_org);
                    if (customerRecord != null)
                    {
                        CreateAddress.Attributes[AttributeName] = new EntityReference(customerRecord.LogicalName, customerRecord.Id);
                        CreateAddress.Attributes["etel_name"] = customerRecord.Attributes[ColumnName].ToString() + " - Customer Address Business Interaction";
                    }
                }


                if (countryGuid != Guid.Empty)
                    CreateAddress.Attributes["etel_countryid"] = new EntityReference("etel_country", countryGuid);

                Guid departmentLookup = GetLookupGuidFromField("amxperu_department", "amxperu_departmentcode", _request.Department, _org);
                if (departmentLookup != Guid.Empty)
                {
                    CreateAddress.Attributes["amxperu_department"] = new EntityReference("amxperu_department", departmentLookup);
                    Guid provinceLookup = GetProvinceFromDepartment(_request.Province, departmentLookup,_org);
                    if (provinceLookup != Guid.Empty)
                    {
                        CreateAddress.Attributes["amxperu_province"] = new EntityReference("amxperu_province", provinceLookup);
                        Guid districtLookup = GetDistrictFromProvince(_request.District, provinceLookup,_org);
                        if (districtLookup != Guid.Empty)
                        {
                            CreateAddress.Attributes["amxperu_district"] = new EntityReference("amxperu_district", districtLookup);
                            string UbigeoValue = GetUbigeoValue(countryGuid, departmentLookup, provinceLookup, districtLookup,_org);
                            if (UbigeoValue != "")
                                CreateAddress.Attributes["amxperu_ubigeo"] = UbigeoValue;
                        }
                    }
                }

                Guid createdAddressRecordId = _org.Create(CreateAddress);
                Entity submitRecord = new Entity(CreateAddress.LogicalName, createdAddressRecordId);
                submitRecord.Attributes["etel_submit"] = true;
                submitRecord.Attributes["amxperu_isexternal"] = true;
                _org.Update(submitRecord);
                Entity RetrievedCustomerAddressBI = _org.Retrieve(CreateAddress.LogicalName, createdAddressRecordId, new ColumnSet("etel_customeraddress"));
                if (RetrievedCustomerAddressBI.Contains("etel_customeraddress"))
                {
                    _response.CustomerAddressID = ((EntityReference)RetrievedCustomerAddressBI.Attributes["etel_customeraddress"]).Id.ToString();
                }
            }
            return _response;
        }
        public AmxPeruCustomerAddressResponse ModifyAddress(AmxPeruCustomerAddressRequest _request, OrganizationServiceProxy _org)
        {
            AmxPeruCustomerAddressResponse _response = null;
            if (_request != null)
            {
                _response = new AmxPeruCustomerAddressResponse();
                Entity ModifyAddress = new Entity("etel_bi_customeraddressmodification");
                string alert = ValidateRequiredFields(_request.AddressType, _request);
                if (alert != "")
                {
                    _response.Error = alert;
                    _response.CustomerAddressID = "";
                    return _response;
                }
                string postalcodeValidate = ValidatePostalCode(_request.ZIPPostalCode);
                if (postalcodeValidate != "")
                {
                    _response.Error = postalcodeValidate;
                    _response.CustomerAddressID = "";
                    return _response;
                }
                ModifyAddress.Attributes["etel_customeraddresstypecode"] = new OptionSetValue(_request.AddressType);
                ModifyAddress.Attributes["amxperu_zonetype"] = new OptionSetValue(_request.ZoneType);
                ModifyAddress.Attributes["amxperu_blockedifice"] = new OptionSetValue(_request.BlockEdifice);
                ModifyAddress.Attributes["amxperu_apartmenttypeinterior"] = new OptionSetValue(_request.ApartmentTypeInterior);
                ModifyAddress.Attributes["amxperu_urbanizationtype"] = new OptionSetValue(_request.UrbanizationType);
                ModifyAddress.Attributes["amxperu_populationzone"] = new OptionSetValue(_request.PopulationZone);
                ModifyAddress.Attributes["etel_postalcode"] = _request.ZIPPostalCode.ToString();
                ModifyAddress.Attributes["amxperu_longitude"] = _request.Longitude.ToString();
                ModifyAddress.Attributes["amxperu_latitude"] = _request.Latitude.ToString();
                ModifyAddress.Attributes["amxperu_referencedescription"] = _request.ReferenceDescription.ToString();
                ModifyAddress.Attributes["etel_street2"] = _request.Street2.ToString();
                ModifyAddress.Attributes["etel_street3"] = _request.Street3.ToString();
                ModifyAddress.Attributes["amxperu_street1"] = new OptionSetValue(_request.Street1);
                //ModifyAddress.Attributes["amxperu_building"] = new OptionSetValue(_request.Building);
                ModifyAddress.Attributes["amxperu_buildtype"] = new OptionSetValue(_request.BuildType);
                ModifyAddress.Attributes["amxperu_square"] = _request.Square.ToString();
                ModifyAddress.Attributes["amxperu_allotment"] = _request.Allotment.ToString();
                ModifyAddress.Attributes["amxperu_number"] = _request.Number.ToString();
                ModifyAddress.Attributes["amxperu_grouping"] = _request.Grouping.ToString();
                //ModifyAddress.Attributes["amxperu_billingemail"] = _request.BillingEmail.ToString();
                ModifyAddress.Attributes["amxperu_normalized"] = _request.Normalized;
                Guid countryGuid = GetLookupGuidFromField("etel_country", "etel_code", _request.Country, _org);
                string EntityName = "";
                string AttributeName = "";
                string ColumnName = "";

                if (_request.CustomerType == 1)
                {
                    EntityName = "contact";
                    AttributeName = "etel_individualcustomer";
                    ColumnName = "fullname";
                }
                if (_request.CustomerType == 2)
                {
                    EntityName = "account";
                    AttributeName = "etel_corporatecustomer";
                    ColumnName = "name";
                }

                if (EntityName != "" && AttributeName != "")
                {
                    Entity customerRecord = GetCustomerValues(EntityName, "etel_externalid", _request.CustomerExternalId, ColumnName, _org);
                    if (customerRecord != null)
                    {
                        ModifyAddress.Attributes[AttributeName] = new EntityReference(customerRecord.LogicalName, customerRecord.Id);
                        ModifyAddress.Attributes["etel_name"] = customerRecord.Attributes[ColumnName].ToString() + " - Customer Address Business Interaction";
                    }
                }

                if (!string.IsNullOrEmpty(_request.CustomerAddressID))
                {
                    ModifyAddress.Attributes["etel_customeraddress"] = new EntityReference("etel_customeraddress", new Guid(_request.CustomerAddressID));

                }
                if (countryGuid != Guid.Empty)
                    ModifyAddress.Attributes["etel_countryid"] = new EntityReference("etel_country", countryGuid);

                Guid departmentLookup = GetLookupGuidFromField("amxperu_department", "amxperu_departmentcode", _request.Department, _org);
                if (departmentLookup != Guid.Empty)
                {
                    ModifyAddress.Attributes["amxperu_department"] = new EntityReference("amxperu_department", departmentLookup);
                    Guid provinceLookup = GetProvinceFromDepartment(_request.Province, departmentLookup, _org);
                    if (provinceLookup != Guid.Empty)
                    {
                        ModifyAddress.Attributes["amxperu_province"] = new EntityReference("amxperu_province", provinceLookup);
                        Guid districtLookup = GetDistrictFromProvince(_request.District, provinceLookup, _org);
                        if (districtLookup != Guid.Empty)
                        {
                            ModifyAddress.Attributes["amxperu_district"] = new EntityReference("amxperu_district", districtLookup);
                            string UbigeoValue = GetUbigeoValue(countryGuid, departmentLookup, provinceLookup, districtLookup, _org);
                            if (UbigeoValue != "")
                                ModifyAddress.Attributes["amxperu_ubigeo"] = UbigeoValue;
                        }
                    }
                }

                Guid modifiedAddressRecordId = _org.Create(ModifyAddress);
                Entity submitRecord = new Entity(ModifyAddress.LogicalName, modifiedAddressRecordId);
                submitRecord.Attributes["etel_submit"] = true;
                submitRecord.Attributes["amxperu_isexternal"] = true;
                _org.Update(submitRecord);
                _response.CustomerAddressID = _request.CustomerAddressID;
            }
            return _response;
        }
        public AmxPeruGetCustomerAddressResponse getCustomerAddresses(AmxPeruGetCustomerAddressRequest _request, OrganizationServiceProxy _org)
        {
            AmxPeruGetCustomerAddressResponse _response = null;
            if (_request != null)
            {
                _response = new AmxPeruGetCustomerAddressResponse();
                string CustomerID = string.Empty;
                string DocNumber = string.Empty;
                int DocType = 0;
                if (!string.IsNullOrEmpty(_request.CustomerExternalId)) {
                    CustomerID = _request.CustomerExternalId;
                }
                if (!string.IsNullOrEmpty(_request.documentNumber))
                {
                    DocNumber= _request.documentNumber;
                }
                if (_request.documentType > 0)
                {
                    DocType = _request.documentType;
                }
                if (string.IsNullOrEmpty(CustomerID) && string.IsNullOrEmpty(DocNumber))
                {
                    _response.successFlag = 0;
                    _response.Status = "NOK";
                    _response.Error = "You should enter either Customer ExternalID or Document Number";
                }
                else
                {                    
                    List<Address> _addresses = new List<Address>();
                    if (_request.CustomerType == 1)
                    {
                        if (CustomerID != string.Empty)
                        {
                            Condition = "<condition attribute='etel_externalid' value='" + CustomerID + "' operator='eq'/>";
                        }
                        if(DocNumber != string.Empty)
                        {
                            Condition += "<condition attribute='etel_passportnumber' value='" + DocNumber + "' operator='eq'/>";
                        }
                        if(DocType != 0)
                        {
                            if (_request.documentType == 2)
                            {
                                Condition += "<condition attribute='amxperu_documenttype' value='250000001' operator='eq'/>";
                            }
                            else if(_request.documentType == 1)
                            {
                                Condition += "<condition attribute='amxperu_documenttype' value='250000000' operator='eq'/>";
                            }
                            else if(_request.documentType == 4)
                            {
                                Condition += "<condition attribute='amxperu_documenttype' value='250000003' operator='eq'/>";
                            }
                            else if(_request.documentType == 3)
                            {
                                Condition += "<condition attribute='amxperu_documenttype' value='250000002' operator='eq'/>";
                            }
                        }
                        _addresses = FetchIndividualAddress(Condition, _org);


                    }
                    else if (_request.CustomerType == 2)
                    {
                        if (CustomerID != string.Empty)
                        {
                            Condition = "<condition attribute='etel_externalid' value='" + CustomerID + "' operator='eq'/>";
                        }
                        _addresses = FetchCorporateAddress(Condition, _org);
                    }
                    else
                    {
                        if (CustomerID != string.Empty)
                        {
                            Condition = "<condition attribute='etel_externalid' value='" + CustomerID + "' operator='eq'/>";
                        }
                        _addresses = FetchCorporateAddress(Condition, _org);
                        if (_addresses.Count == 0) { 
                           if (DocNumber != string.Empty)
                            {
                                Condition += "<condition attribute='etel_passportnumber' value='" + DocNumber + "' operator='eq'/>";
                            }
                            if (DocType != 0)
                            {
                                if (_request.documentType == 2)
                                {
                                    Condition += "<condition attribute='amxperu_documenttype' value='250000001' operator='eq'/>";
                                }
                                else if (_request.documentType == 1)
                                {
                                    Condition += "<condition attribute='amxperu_documenttype' value='250000000' operator='eq'/>";
                                }
                                else if (_request.documentType == 4)
                                {
                                    Condition += "<condition attribute='amxperu_documenttype' value='250000003' operator='eq'/>";
                                }
                                else if (_request.documentType == 3)
                                {
                                    Condition += "<condition attribute='amxperu_documenttype' value='250000002' operator='eq'/>";
                                }
                            }
                            _addresses = FetchIndividualAddress(Condition, _org);
                        }
                    }
                    if (_addresses.Count > 0)
                    {
                        _response.successFlag = 1;
                        _response.listOfAddresses = _addresses;
                        _response.Status = "OK";
                    }
                    else
                    {
                        _response.successFlag = 0;
                        _response.Status = "NOK";
                        _response.Error = "No result found";
                    }
                }
            }
            return _response;
        }
        private List<Address> FetchIndividualAddress(string conditionString, OrganizationServiceProxy _org)
        {
            List<Address> _addresses = new List<Address>();
            string FetchQuery = FetchAddressIndividual.Replace("FETCHVALUE", conditionString);
            DataCollection<Entity> _entities = _org.RetrieveMultiple(new FetchExpression(FetchQuery)).Entities;
            foreach (var entity in _entities)
            {
                Address _address = new Address();
                if (entity.Attributes.Contains("amxperu_latitude"))
                {
                    _address.Latitude = entity.Attributes["amxperu_latitude"].ToString();
                }
                if (entity.Attributes.Contains("amxperu_longitude"))
                {
                    _address.Longitude = entity.Attributes["amxperu_longitude"].ToString();
                }
                if (entity.Attributes.Contains("amxperu_ubigeo"))
                {
                    _address.Ubigeo = entity.Attributes["amxperu_ubigeo"].ToString();
                }
                if (entity.Attributes.Contains("etel_name"))
                {
                    _address.AddressName = entity.Attributes["etel_name"].ToString();
                }
                if (entity.Attributes.Contains("etel_customeraddressid"))
                {
                    _address.CustomerAddressID = entity.Attributes["etel_customeraddressid"].ToString();
                }
                if (entity.Attributes.Contains("etel_customeraddresstypecode"))
                {
                    _address.AddressType = ((OptionSetValue)entity["etel_customeraddresstypecode"]).Value;
                }
                _addresses.Add(_address);
            }
            return _addresses;
        }
        private List<Address> FetchCorporateAddress(string conditionString, OrganizationServiceProxy _org)
        {
            List<Address> _addresses = new List<Address>();
            string FetchQuery = FetchAddressCorporate.Replace("FETCHVALUE", conditionString);
            DataCollection<Entity> _entities = _org.RetrieveMultiple(new FetchExpression(FetchQuery)).Entities;
            foreach (var entity in _entities)
            {
                Address _address = new Address();
                if (entity.Attributes.Contains("amxperu_latitude"))
                {
                    _address.Latitude = entity.Attributes["amxperu_latitude"].ToString();
                }
                if (entity.Attributes.Contains("amxperu_longitude"))
                {
                    _address.Longitude = entity.Attributes["amxperu_longitude"].ToString();
                }
                if (entity.Attributes.Contains("amxperu_ubigeo"))
                {
                    _address.Ubigeo = entity.Attributes["amxperu_ubigeo"].ToString();
                }
                if (entity.Attributes.Contains("etel_name"))
                {
                    _address.AddressName = entity.Attributes["etel_name"].ToString();
                }
                if (entity.Attributes.Contains("etel_customeraddressid"))
                {
                    _address.CustomerAddressID = entity.Attributes["etel_customeraddressid"].ToString();
                }
                if (entity.Attributes.Contains("etel_customeraddresstypecode"))
                {
                    _address.AddressType = ((OptionSetValue)entity["etel_customeraddresstypecode"]).Value;
                }
                _addresses.Add(_address);
            }
            return _addresses;
        }
        private string ValidateRequiredFields(int Addresstype, AmxPeruCustomerAddressRequest request)
        {
            string alertMessage = "";

            if (Addresstype == 1)
            {
                if (request.Street1 == 0)
                {
                    alertMessage = alertMessage + "Regular Address must have Street 1 Value ";
                }
                if (request.Street2 == null)
                {
                    alertMessage = alertMessage + "Regular Address must have Street 2 Value ";
                }
                if (request.Street3 == null)
                {
                    alertMessage = alertMessage + "Regular Address must have Street 3 Value ";
                }
                if (request.Country == null)
                {
                    alertMessage = alertMessage + "Regular Address must have Country Value ";
                }
                if (request.Department == null)
                {
                    alertMessage = alertMessage + "Regular Address must have Department Value ";
                }
                if (request.Province == null)
                {
                    alertMessage = alertMessage + "Regular Address must have Province Value ";
                }
                if (request.District == null)
                {
                    alertMessage = alertMessage + "Regular Address must have District Value ";
                }

            }
            else if (Addresstype == 2)
            {
                if (request.PopulationZone == 0)
                {
                    alertMessage = alertMessage + "Population Zone Address Type must have Population Zone Value";
                }
            }

            return alertMessage;
        }
        private string ValidatePostalCode(string PostalCode)
        {
            string alert = "";
            int result;
            if (int.TryParse(PostalCode, out result))
            {
                //Postal Code is numeric value
            }
            else
            {
                alert = "Postal Code must be numeric value";
            }
            return alert;
        }
        private Guid GetLookupGuidFromField(string entityName, string columnName, string columnValue, OrganizationServiceProxy _org)
        {
            QueryExpression retrieveQuery = new QueryExpression(entityName);
            retrieveQuery.Criteria.AddCondition(columnName, ConditionOperator.Equal, columnValue);
            EntityCollection retrievedCollection = _org.RetrieveMultiple(retrieveQuery);

            if (retrievedCollection.Entities.Count == 1)
            {
                return retrievedCollection[0].Id;
            }
            return Guid.Empty;
        }
        private Entity GetCustomerValues(string entityName, string columnName, string columnValue, string columnSet, OrganizationServiceProxy _org)
        {
            QueryExpression retrieveQuery = new QueryExpression(entityName);
            retrieveQuery.Criteria.AddCondition(columnName, ConditionOperator.Equal, columnValue);
            retrieveQuery.ColumnSet = new ColumnSet(columnSet);
            EntityCollection retrievedCollection = _org.RetrieveMultiple(retrieveQuery);

            if (retrievedCollection.Entities.Count == 1)
            {
                return retrievedCollection[0];
            }
            return null;
        }
        private Guid GetProvinceFromDepartment(string provinceCode, Guid departmentLookup, OrganizationServiceProxy _org)
        {
            QueryExpression retrieveQuery = new QueryExpression("amxperu_province");
            retrieveQuery.Criteria.AddCondition("amxperu_provincecode", ConditionOperator.Equal, provinceCode);
            retrieveQuery.Criteria.AddCondition("amxperu_department", ConditionOperator.Equal, departmentLookup);
            retrieveQuery.ColumnSet = new ColumnSet(false);
            EntityCollection retrievedCollection = _org.RetrieveMultiple(retrieveQuery);

            if (retrievedCollection.Entities.Count == 1)
            {
                return retrievedCollection[0].Id;
            }
            return Guid.Empty;
        }
        private Guid GetDistrictFromProvince(string districtCode, Guid provinceLookup, OrganizationServiceProxy _org)
        {
            QueryExpression retrieveQuery = new QueryExpression("amxperu_district");
            retrieveQuery.Criteria.AddCondition("amxperu_districtcode", ConditionOperator.Equal, districtCode);
            retrieveQuery.Criteria.AddCondition("amxperu_province", ConditionOperator.Equal, provinceLookup);
            retrieveQuery.ColumnSet = new ColumnSet(false);
            EntityCollection retrievedCollection = _org.RetrieveMultiple(retrieveQuery);

            if (retrievedCollection.Entities.Count == 1)
            {
                return retrievedCollection[0].Id;
            }
            return Guid.Empty;
        }
        private string GetUbigeoValue(Guid CountryId, Guid DepartmentId, Guid ProvinceId, Guid DistrictID , OrganizationServiceProxy _org)
        {
            string Ubigeo = string.Empty;
            string[] columns = { "amxperu_name", "amxperu_addressconfigurationid" };
            QueryExpression retrieveQuery = new QueryExpression("amxperu_addressconfiguration");
            retrieveQuery.ColumnSet = new ColumnSet(columns);
            retrieveQuery.Criteria = new FilterExpression();
            retrieveQuery.Criteria.AddCondition("amxperu_country", ConditionOperator.Equal, CountryId);
            retrieveQuery.Criteria.AddCondition("amxperu_department", ConditionOperator.Equal, DepartmentId);
            retrieveQuery.Criteria.AddCondition("amxperu_province", ConditionOperator.Equal, ProvinceId);
            retrieveQuery.Criteria.AddCondition("amxperu_district", ConditionOperator.Equal, DistrictID);
            EntityCollection retrievedCollection = _org.RetrieveMultiple(retrieveQuery);

            if (retrievedCollection.Entities.Count == 1)
            {
                Ubigeo = retrievedCollection[0].GetAttributeValue<string>("amxperu_name");
            }

            return Ubigeo;
        }
        private static string FetchAddressIndividual= @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                                            <entity name='etel_customeraddress'>
                                                                            <attribute name='amxperu_latitude' />
                                                                            <attribute name='amxperu_longitude' />
                                                                            <attribute name='amxperu_ubigeo' />
                                                                            <attribute name='etel_customeraddresstypecode' />
                                                                            <attribute name='etel_customeraddressid' />
                                                                            <attribute name='etel_name' />
                                                                            <order attribute='etel_name' descending='false' />
                                                                            <link-entity name='contact' alias='af' to='etel_individualcustomerid' from='contactid'>
                                                                                <filter type='and'>
                                                                                FETCHVALUE                                                                               
                                                                               </filter>
                                                                             </link-entity>
                                                                            </entity>
                                                                        </fetch>";

        private static string FetchAddressCorporate = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                                            <entity name='etel_customeraddress'>
                                                                            <attribute name='amxperu_latitude' />
                                                                            <attribute name='amxperu_longitude' />
                                                                            <attribute name='amxperu_ubigeo' />
                                                                            <attribute name='etel_customeraddresstypecode' />
                                                                            <attribute name='etel_customeraddressid' />
                                                                            <attribute name='etel_name' />
                                                                            <order attribute='etel_name' descending='false' />
                                                                            <link-entity name='account' alias='af' to='etel_corporatecustomerid' from='accountid'>
                                                                                <filter type='and'>
                                                                                FETCHVALUE                                                                               
                                                                               </filter>
                                                                             </link-entity>
                                                                            </entity>
                                                                        </fetch>";
    }
}
