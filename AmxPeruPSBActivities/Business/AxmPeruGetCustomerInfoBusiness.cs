using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;

namespace AmxPeruPSBActivities.Business
{
    public class AxmPeruGetCustomerInfoBusiness
    {
        string Condition;
        string LinkEntityCondition;
        public AmxPeruGetCustomerInfoResponse RetrieveCustomer(AmxPeruGetCustomerInfoRequest _request, OrganizationServiceProxy _org)
        {
            AmxPeruGetCustomerInfoResponse _response = null;
            if (_request != null)
            {
                string CustomerID = string.Empty;
                string DocNumber = string.Empty;
                string MSISDN = string.Empty;
                int DocType = 0;
                string CustomerName = string.Empty;
                _response = new AmxPeruGetCustomerInfoResponse();
                if (!string.IsNullOrEmpty(_request.CustomerExternalId))
                {
                    CustomerID = _request.CustomerExternalId;
                }
                if (!string.IsNullOrEmpty(_request.msisdn))
                {
                    MSISDN = _request.msisdn;
                }
                if (!string.IsNullOrEmpty(_request.customerName))
                {
                    CustomerName = _request.customerName;
                }
                if (!string.IsNullOrEmpty(_request.documentNumber))
                {
                    DocNumber = _request.documentNumber;
                }
                if (_request.documentType > 0)
                {
                    DocType = _request.documentType;
                }
                if (_request.CustomerType == 1)
                {
                    if (!string.IsNullOrEmpty(CustomerID))
                    {
                        Condition = "<condition attribute='etel_externalid' value='" + CustomerID + "' operator='eq'/>";
                    }
                    if (!string.IsNullOrEmpty(CustomerName))
                    {
                        Condition = "<condition attribute='fullname' value='" + CustomerName + "' operator='eq'/>";
                    }
                    if (!string.IsNullOrEmpty(DocNumber))
                    {
                        Condition += "<condition attribute='etel_passportnumber' value='" + DocNumber + "' operator='eq'/>";
                    }
                    if (!string.IsNullOrEmpty(MSISDN))
                    {
                        LinkEntityCondition = "<link-entity name='etel_subscription' alias='ak' to='contactid' from='etel_individualcustomerid'>"
                            +"<filter type='and'>"
                            + "<condition attribute='etel_msisdnserialno' value='" + MSISDN + "' operator='eq'/>"
                            + "</filter></link-entity>";
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
                        else
                        {
                            _response.successFlag = 0;
                            _response.Error = "Document Type is invalid";
                            return _response;
                        }
                    }
                    _response = GetIndividual(Condition, LinkEntityCondition, _org);
                    if (_response == null)
                    {
                        _response.successFlag = 0;
                        _response.Error = "Customer not found for the given criteria";
                        return _response;
                    }
                }
                else if (_request.CustomerType == 2)
                {
                    _response = GetCorporate(CustomerID, _org);
                    if (_response == null)
                    {
                        _response.successFlag = 0;
                        _response.Error = "Customer not found for the given criteria";
                        return _response;
                    }
                }
                else
                {
                    _response = GetCorporate(CustomerID, _org);
                    if (_response == null)
                    {
                        if (!string.IsNullOrEmpty(CustomerID))
                        {
                            Condition = "<condition attribute='etel_externalid' value='" + CustomerID + "' operator='eq'/>";
                        }
                        if (!string.IsNullOrEmpty(CustomerName))
                        {
                            Condition = "<condition attribute='fullname' value='" + CustomerName + "' operator='eq'/>";
                        }
                        if (!string.IsNullOrEmpty(DocNumber))
                        {
                            Condition += "<condition attribute='etel_passportnumber' value='" + DocNumber + "' operator='eq'/>";
                        }
                        if (!string.IsNullOrEmpty(MSISDN))
                        {
                            LinkEntityCondition = "<link-entity name='etel_subscription' alias='ak' to='contactid' from='etel_individualcustomerid'>"
                                + "<filter type='and'>"
                                + "<condition attribute='etel_msisdnserialno' value='" + MSISDN + "' operator='eq'/>"
                                + "</filter></link-entity>";
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
                            else
                            {
                                _response.successFlag = 0;
                                _response.Error = "Document Type is invalid";
                                return _response;
                            }
                        }
                        _response = GetIndividual(Condition,LinkEntityCondition, _org);
                        if (_response == null)
                        {
                            _response.successFlag = 0;
                            _response.Error = "Customer not found for the given criteria";
                            return _response;
                        }
                    }
                }
            }
            return _response;
        }
        private AmxPeruGetCustomerInfoResponse GetIndividual(string conditionString,string linkEntityCondition, OrganizationServiceProxy _org)
        {
            AmxPeruGetCustomerInfoResponse _individual = new AmxPeruGetCustomerInfoResponse();
            List<SocialNetworks> socialNetworkDetails = new List<SocialNetworks>();
            string FetchQuery = FetchIndividualInfo.Replace("FETCHVALUE", conditionString);
            FetchQuery = FetchQuery.Replace("LINKENTITYMSISDN", linkEntityCondition);
            DataCollection<Entity> _entities = _org.RetrieveMultiple(new FetchExpression(FetchQuery)).Entities;
            foreach (var entity in _entities)
            {
                if (entity.Attributes.Contains("fullname"))
                {
                    _individual.name = entity.Attributes["fullname"].ToString();
                }
                if (entity.Attributes.Contains("firstname"))
                {
                    _individual.firstName = entity.Attributes["firstname"].ToString();
                }
                if (entity.Attributes.Contains("lastname"))
                {
                    _individual.lastName = entity.Attributes["lastname"].ToString();
                }
                if (entity.Attributes.Contains("mobilephone"))
                {
                    _individual.phoneNumber = entity.Attributes["mobilephone"].ToString();
                }
                if (entity.Attributes.Contains("emailaddress1"))
                {
                    _individual.email = entity.Attributes["emailaddress1"].ToString();
                }
                if (entity.Attributes.Contains("company"))
                {
                    _individual.companyName = entity.Attributes["company"].ToString();
                }
                if (entity.Attributes.Contains("etel_passportnumber"))
                {
                    _individual.documentNumber = entity.Attributes["etel_passportnumber"].ToString();
                }
                if (entity.Attributes.Contains("etel_placeofbirth"))
                {
                    _individual.birthPlace = entity.Attributes["etel_placeofbirth"].ToString();
                }
                if (entity.Attributes.Contains("etel_socialmediatwitter"))
                {
                    SocialNetworks _twitter = new SocialNetworks();
                    _twitter.socialNetworkNickname = entity.Attributes["etel_socialmediatwitter"].ToString();
                    _twitter.socialNetworktId = "Twitter";
                    socialNetworkDetails.Add(_twitter);
                }
                if (entity.Attributes.Contains("etel_socialmedialinkedin"))
                {
                    SocialNetworks _linkedin = new SocialNetworks();
                    _linkedin.socialNetworktId = "Linkedin";
                    _linkedin.socialNetworkNickname = entity.Attributes["etel_socialmedialinkedin"].ToString();
                    socialNetworkDetails.Add(_linkedin);
                }
                if (entity.Attributes.Contains("amxperu_socialmediainstagram"))
                {
                    SocialNetworks _instagram = new SocialNetworks();
                    _instagram.socialNetworktId = "Instagram";
                    _instagram.socialNetworkNickname = entity.Attributes["amxperu_socialmediainstagram"].ToString();
                    socialNetworkDetails.Add(_instagram);
                }
                if (entity.Attributes.Contains("etel_socialmediafacebook"))
                {
                    SocialNetworks _facebook = new SocialNetworks();
                    _facebook.socialNetworktId = "Facebook";
                    _facebook.socialNetworkNickname = entity.Attributes["etel_socialmediafacebook"].ToString();
                    socialNetworkDetails.Add(_facebook);
                }
                if (entity.Attributes.Contains("etel_nationalid"))
                {
                    _individual.nationality = entity.Attributes["etel_nationalid"].ToString();
                }
                if (entity.Attributes.Contains("amxperu_blackliststatusreason"))
                {
                    _individual.blackListStatusReason = entity.Attributes["amxperu_blackliststatusreason"].ToString();
                }
                if (entity.Attributes.Contains("etel_externalid"))
                {
                    _individual.customerId = entity.Attributes["etel_externalid"].ToString();
                }
                if (entity.Attributes.Contains("statecode"))
                {
                    int status = ((OptionSetValue)entity["statecode"]).Value;
                    if (status == 1)
                    {
                        _individual.activeFlag = false;
                    }
                    if (status == 0)
                    {
                        _individual.activeFlag = true;
                    }
                }
                if (entity.Attributes.Contains("amxperu_allowmail"))
                {
                    int allowemail = ((OptionSetValue)entity["amxperu_allowmail"]).Value;
                    if (allowemail == 1)
                    {
                        _individual.doNotMail = false;
                    }
                    if (allowemail == 2)
                    {
                        _individual.doNotMail = true;
                    }
                }
                if (entity.Attributes.Contains("amxperu_allowemail"))
                {
                    int allowemail = ((OptionSetValue)entity["amxperu_allowemail"]).Value;
                    if (allowemail == 1)
                    {
                        _individual.doNotEmail = false;
                    }
                    if (allowemail == 2)
                    {
                        _individual.doNotEmail = true;
                    }
                }
                if (entity.Attributes.Contains("amxperu_allowphone"))
                {
                    int allowemail = ((OptionSetValue)entity["amxperu_allowphone"]).Value;
                    if (allowemail == 1)
                    {
                        _individual.doNotPhone = false;
                    }
                    if (allowemail == 2)
                    {
                        _individual.doNotPhone = true;
                    }
                }
                if (entity.Attributes.Contains("preferredappointmentdaycode"))
                {
                    _individual.preferredDay = entity.FormattedValues["preferredappointmentdaycode"].ToString();
                }
                if (entity.Attributes.Contains("preferredappointmenttimecode"))
                {
                    _individual.preferredTime = entity.FormattedValues["preferredappointmenttimecode"].ToString();
                }
                if (entity.Attributes.Contains("amxperu_documenttype"))
                {
                    int docType = ((OptionSetValue)entity["amxperu_documenttype"]).Value;
                    if (docType == 250000000)
                    {
                        _individual.documentType = 1;
                    }
                    if (docType == 250000001)
                    {
                        _individual.documentType = 2;
                    }
                    if (docType == 250000002)
                    {
                        _individual.documentType = 3;
                    }
                    if (docType == 250000003)
                    {
                        _individual.documentType = 4;
                    }
                }
                if (entity.Attributes.Contains("gendercode"))
                {
                    _individual.gender = entity.FormattedValues["gendercode"].ToString();
                }
                if (entity.Attributes.Contains("familystatuscode"))
                {
                    int maritialstatus = ((OptionSetValue)entity["familystatuscode"]).Value;
                    _individual.maritalStatus = maritialstatus;
                }
                if (entity.Attributes.Contains("birthdate"))
                {
                    _individual.birthDate = Convert.ToDateTime(entity.Attributes["birthdate"].ToString());
                }
                if (entity.Attributes.Contains("preferredcontactmethodcode"))
                {
                    string method = entity.FormattedValues["preferredcontactmethodcode"].ToString();
                    if (method == "Mail")
                    {
                        _individual.preferredContactMethod = 2;
                    }
                    else if (method == "Email")
                    {
                        _individual.preferredContactMethod = 3;
                    }
                    else if (method == "Phone")
                    {
                        _individual.preferredContactMethod = 1;
                    }
                }
                if (entity.Attributes.Contains("etel_blackliststatuscode"))
                {
                    _individual.blackListStatusCode = entity.FormattedValues["etel_blackliststatuscode"].ToString();
                }
            }
            if (socialNetworkDetails.Count > 0)
            {
                _individual.socialNetworks = socialNetworkDetails;
            }
            return _individual;
        }
        private AmxPeruGetCustomerInfoResponse GetCorporate(string CustomerExternalID, OrganizationServiceProxy _org)
        {
            AmxPeruGetCustomerInfoResponse _corporate = new AmxPeruGetCustomerInfoResponse();
            List<SocialNetworks> socialNetworkDetails = new List<SocialNetworks>();
            QueryExpression _getContactData = new QueryExpression
            {
                EntityName = "account",
                ColumnSet = new ColumnSet("name", "etel_socialmediatwitter", "etel_socialmedialinkedin", "etel_socialmediafacebook", "etel_shortname"),
                Criteria = new FilterExpression
                {
                    Conditions =
                        {
                            new ConditionExpression
                            {
                                AttributeName = "etel_externalid",
                                Operator = ConditionOperator.Equal,
                                Values = { CustomerExternalID }
                            }
                        }
                }
            };
            DataCollection<Entity> _entities = _org.RetrieveMultiple(_getContactData).Entities;
            foreach (var entity in _entities)
            {
                if (entity.Attributes.Contains("name"))
                {
                    _corporate.name = entity.Attributes["name"].ToString();
                }
                if (entity.Attributes.Contains("etel_shortname"))
                {
                    _corporate.firstName = entity.Attributes["etel_shortname"].ToString();
                }
                if (entity.Attributes.Contains("etel_socialmediatwitter"))
                {
                    SocialNetworks _twitter = new SocialNetworks();
                    _twitter.socialNetworkNickname = entity.Attributes["etel_socialmediatwitter"].ToString();
                    _twitter.socialNetworktId = "Twitter";
                    socialNetworkDetails.Add(_twitter);
                }
                if (entity.Attributes.Contains("etel_socialmedialinkedin"))
                {
                    SocialNetworks _linkedin = new SocialNetworks();
                    _linkedin.socialNetworkNickname = entity.Attributes["etel_socialmedialinkedin"].ToString();
                    _linkedin.socialNetworktId = "Linkedin";
                    socialNetworkDetails.Add(_linkedin);
                }
                if (entity.Attributes.Contains("etel_socialmediafacebook"))
                {
                    SocialNetworks _facebook = new SocialNetworks();
                    _facebook.socialNetworkNickname = entity.Attributes["etel_socialmediafacebook"].ToString();
                    _facebook.socialNetworktId = "Facebook";
                    socialNetworkDetails.Add(_facebook);
                }
            }
            if (socialNetworkDetails.Count > 0)
            {
                _corporate.socialNetworks = socialNetworkDetails;
            }
            return _corporate;
        }
        private static string FetchIndividualInfo = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                                            <entity name='contact'>
                                                                            <attribute name='firstname' />
                                                                            <attribute name='fullname' />
                                                                            <attribute name='lastname' />
                                                                            <attribute name='mobilephone' />
                                                                            <attribute name='emailaddress1' />
                                                                            <attribute name='company' />
                                                                            <attribute name='etel_passportnumber' />
                                                                            <attribute name='etel_placeofbirth' />
                                                                            <attribute name='etel_socialmediatwitter' />
                                                                            <attribute name='etel_socialmedialinkedin' />
                                                                            <attribute name='amxperu_socialmediainstagram' />
                                                                            <attribute name='etel_socialmediafacebook' />
                                                                            <attribute name='amxperu_blackliststatusreason' />
                                                                            <attribute name='etel_nationalid' />
                                                                            <attribute name='etel_externalid' />
                                                                            <attribute name='statecode' />
                                                                            <attribute name='amxperu_allowmail' />
                                                                            <attribute name='amxperu_allowphone' />
                                                                            <attribute name='amxperu_allowemail' />
                                                                            <attribute name='preferredappointmentdaycode' />
                                                                            <attribute name='preferredappointmenttimecode' />
                                                                            <attribute name='amxperu_documenttype' />
                                                                            <attribute name='gendercode' />
                                                                            <attribute name='familystatuscode' />
                                                                            <attribute name='birthdate' />
                                                                            <attribute name='preferredcontactmethodcode' />
                                                                            <attribute name='etel_blackliststatuscode' />
                                                                            <order attribute='fullname' descending='false' />
                                                                              <filter type='and'>
                                                                                FETCHVALUE                                                                               
                                                                               </filter>
                                                                             LINKENTITYMSISDN
                                                                          </entity>
                                                                        </fetch>";
    }
}
