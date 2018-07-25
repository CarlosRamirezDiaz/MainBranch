using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk.Query;

namespace AmxPeruPSBActivities.Business
{
    public class AmxPeruCTIServiceBusiness
    {
        public AmxPeruCTIServiceResponse SearchCustomerUri(AmxPeruCTIServiceRequest request, string CTIUrl, string CustomerSearch,  OrganizationServiceProxy _org)
        {
            string inputValidationErrorMsg = string.Empty;
            string searchedCustomerUri = string.Empty;
            string fetchXml = string.Empty;
            AmxPeruCTIServiceResponse _ctiResponse = null;
            if (request != null)
            {
                try
                {
                    if(request.DocumentType != 0)
                    {
                        if(request.DocumentType == 1)
                        {
                            request.DocumentType = 250000000;
                        }
                       else if (request.DocumentType == 2)
                        {
                            request.DocumentType = 250000001;
                        }
                        else if (request.DocumentType == 3)
                        {
                            request.DocumentType = 250000002;
                        }
                        else if (request.DocumentType == 4)
                        {
                            request.DocumentType = 250000003;
                        }
                        else
                        {
                            inputValidationErrorMsg = "Document Type is not valid, Please enter a valid document type.";
                        }
                    }
                    //Fetch Xml Logic
                    if (string.IsNullOrEmpty(request.MSISDN))
                    {
                        if (!string.IsNullOrEmpty(request.DocumentNumber))
                        {
                            fetchXml = SetFetchXmlDoc(request.CustomerType, request);
                        }
                        else
                        {
                            inputValidationErrorMsg = "Please Provide Doc Type & Doc Number or MSISDN";
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(request.DocumentNumber))
                        {
                            fetchXml = SetFetchXmlDocMSISDN(request.CustomerType, request);
                        }
                        else
                        {
                            fetchXml = SetFetchXmlMSISDN(request.CustomerType, request);
                        }
                    }
                    //Fetch Xml Logic

                    if (!string.IsNullOrEmpty(fetchXml))
                    {
                        EntityCollection _EntityCollection = _org.RetrieveMultiple(new FetchExpression(fetchXml));

                        if (_EntityCollection != null && _EntityCollection.Entities.Count > 0)
                        {
                            searchedCustomerUri = string.Format(CTIUrl, _EntityCollection.Entities[0].Id.ToString());
                        }

                        if (string.IsNullOrEmpty(searchedCustomerUri))
                        {
                            searchedCustomerUri = CustomerSearch;
                        }
                        if (!string.IsNullOrEmpty(searchedCustomerUri))
                        {
                            _ctiResponse = new AmxPeruCTIServiceResponse
                            {
                                CustomerUri = searchedCustomerUri,
                                successFlag = 1,
                                Status = "OK"
                            };
                        }
                        else
                        {
                            _ctiResponse = new AmxPeruCTIServiceResponse
                            {
                                Status = "NOK",
                                Error = "Search Criteria is null",
                                successFlag = 0
                            };
                        }
                    }
                    else
                    {
                        _ctiResponse = new AmxPeruCTIServiceResponse
                        {
                            Status = "NOK",
                            Error = "Search Criteria is null",
                            successFlag = 0
                        };
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                _ctiResponse = new AmxPeruCTIServiceResponse
                {
                    Status = "NOK",
                    Error = "Incoming Request in empty",
                    successFlag=0
                 };
            }
            return _ctiResponse;
        }
        private string SetFetchXmlDoc(int customerType, AmxPeruCTIServiceRequest request)
        {
            string fetchXml = string.Empty;

            try
            {
                if (customerType == 1)
                {
                    fetchXml = string.Format(CtiSearchDocTypeDocNumber, request.DocumentType, request.DocumentNumber);
                }
                else if (customerType == 2)
                {
                    throw new Exception("Corp Customer Search Not Implemented");
                }
                else if (customerType != 1 && customerType != 2)
                {
                    throw new Exception("Invalid Customer Type");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return fetchXml;
        }

        private string SetFetchXmlDocMSISDN(int customerType, AmxPeruCTIServiceRequest request)
        {
            string fetchXml = string.Empty;

            try
            {
                if (customerType == 1)
                {
                    fetchXml = string.Format(CtiSearchDocTypeDocNumberMSISDN, request.DocumentType, request.DocumentNumber, request.MSISDN);
                }
                else if (customerType == 2)
                {
                    throw new Exception("Corp Customer Search Not Implemented");
                }
                else if (customerType != 1 && customerType != 2)
                {
                    throw new Exception("Invalid Customer Type");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return fetchXml;
        }

        private string SetFetchXmlMSISDN(int customerType, AmxPeruCTIServiceRequest request)
        {
            string fetchXml = string.Empty;

            try
            {
                if (customerType == 1)
                {
                    fetchXml = string.Format(CtiSearchMSISDN, request.MSISDN);
                }
                else if (customerType == 2)
                {
                    throw new Exception("Corp Customer Search Not Implemented");
                }
                else if (customerType != 1 && customerType != 2)
                {
                    throw new Exception("Invalid Customer Type");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return fetchXml;
        }
           
        private static string CtiSearchDocTypeDocNumber = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>
                                                                  <entity name='contact'>
                                                                    <attribute name='fullname' />
                                                                    <attribute name='contactid' />
                                                                    <filter type='and'>
                                                                    <condition attribute='amxperu_documenttype' operator='eq' value='{0}' />
                                                                    <condition attribute='etel_passportnumber' operator='eq' value='{1}' />
                                                                    </filter>
                                                                  </entity>
                                                                </fetch>";
        private static string CtiSearchDocTypeDocNumberMSISDN = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>
                                                                  <entity name='contact'>
                                                                    <attribute name='fullname' />
                                                                    <attribute name='contactid' />
                                                                    <filter type='and'>
                                                                    <condition attribute='amxperu_documenttype' operator='eq' value='{0}' />
                                                                    <condition attribute='etel_passportnumber' operator='eq' value='{1}' />
                                                                    </filter>
                                                                    <link-entity name='etel_subscription' from='etel_individualcustomerid' to='contactid' alias='ad'>
                                                                      <filter type='and'>
                                                                        <condition attribute='etel_msisdnserialno' operator='eq' value='{2}' />
                                                                      </filter>
                                                                    </link-entity>
                                                                  </entity>
                                                                </fetch>";
        private static string CtiSearchMSISDN = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>
                                                                  <entity name='contact'>
                                                                    <attribute name='fullname' />
                                                                    <attribute name='contactid' />
                                                                    <link-entity name='etel_subscription' from='etel_individualcustomerid' to='contactid' alias='ad'>
                                                                      <filter type='and'>
                                                                        <condition attribute='etel_msisdnserialno' operator='eq' value='{0}' />
                                                                      </filter>
                                                                    </link-entity>
                                                                  </entity>
                                                                </fetch>";
    }
}
