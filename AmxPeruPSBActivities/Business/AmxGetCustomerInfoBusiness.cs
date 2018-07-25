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
using AmxPSBActivities.Model;
using AmxPeruPSBActivities.Repository;

namespace AmxPSBActivities.Business
{
    public class AmxGetCustomerInfoBusiness
    {
        private OrganizationServiceProxy _org;

        private IndividualCustomerRepository _individualCustomerRepository = null;
        private IndividualCustomerRepository individualCustomerRepository
        {
            get
            {
                if (this._individualCustomerRepository == null)
                    this._individualCustomerRepository = new IndividualCustomerRepository(this._org);

                return this._individualCustomerRepository;
            }
        }

        public AmxGetCustomerInfoBusiness(OrganizationServiceProxy _org)
        {
            this._org = _org;
        }

        public AmxGetCustomerInfoResponse GetCustomerInfo(AmxGetCustomerInfoRequest request)
        {
            string inputValidationErrorMsg = string.Empty;
            AmxGetCustomerInfoResponse _response = null;

            if (request == null)
            {
                _response = new AmxGetCustomerInfoResponse
                {
                    Error = "Incoming Request in empty",
                    Success = false
                };
                return _response;
            }

            try
            {
                if (!string.IsNullOrEmpty(request.contactid))
                {
                    Guid contactGuid = Guid.Empty;

                    if (!Guid.TryParse(request.contactid, out contactGuid))
                    {
                        _response = new AmxGetCustomerInfoResponse
                        {
                            Error = string.Format("Invalid format for ContactId: {0}", request.contactid),
                            Success = false
                        };
                        return _response;
                    }

                    if (contactGuid != Guid.Empty) {

                        var individual = this.individualCustomerRepository.GetById(contactGuid);
                        _response = new AmxGetCustomerInfoResponse(individual)
                        {
                            Success = true
                        };
                        return _response;
                    }
                }

                if (!string.IsNullOrEmpty(request.documentNumber))
                {
                    if (request.documentType <= 0 || request.documentType > 9)
                    {
                        inputValidationErrorMsg = "Document Type is not valid, Please enter a valid document type. "
                            + "CEDULA_DE_CIUDADANIA = 1,"
                            + "NIT = 2,"
                            + "NIT_DE_EXTRANJERIA = 3,"
                            + "CEDULA_EXTRANJERIA = 4,"
                            + "PASAPORTE = 5,"
                            + "CARNET_DIPLOMATICO = 6"
                            + "TARJETA_DE_IDENTIDAD = 7"
                            + "TARJETA_DE_EXTRANJERIA = 8"
                            + "REGISTRO_DE_NACIMIENTO = 9";

                        _response = new AmxGetCustomerInfoResponse
                        {
                            Error = inputValidationErrorMsg,
                            Success = false
                        };
                        return _response;
                    }

                    var individual = this.individualCustomerRepository.GetByDocumentNumber(request.documentNumber, request.documentType);

                    if (individual.IndividualCustomerId == Guid.Empty)
                    {
                        _response = new AmxGetCustomerInfoResponse
                        {
                            Error = string.Format("Customer not found for documentNumber={0} and documentType={1}", request.documentNumber, request.documentType),
                            Success = false
                        };
                        return _response;
                    }

                    _response = new AmxGetCustomerInfoResponse(individual)
                    {
                        Success = true
                    };
                    return _response;
                }

                if (!string.IsNullOrEmpty(request.accountNumber))
                {
                    var individual = this.individualCustomerRepository.GetByAccountNumber(request.accountNumber);

                    if (individual.IndividualCustomerId == Guid.Empty)
                    {
                        _response = new AmxGetCustomerInfoResponse
                        {
                            Error = string.Format("Customer not found for accountNumber={0}", request.accountNumber),
                            Success = false
                        };
                        return _response;
                    }

                    _response = new AmxGetCustomerInfoResponse(individual)
                    {
                        Success = true
                    };
                    return _response;
                }

                if (!string.IsNullOrEmpty(request.invoiceNumber))
                {
                    _response = new AmxGetCustomerInfoResponse
                    {
                        Error = "Fetch by Invoice not implemented",
                        Success = false
                    };
                    return _response;
                }

                if (!string.IsNullOrEmpty(request.customerName))
                {
                    var individual = this.individualCustomerRepository.GetByCustomerName(request.customerName);

                    if (individual.IndividualCustomerId == Guid.Empty)
                    {
                        _response = new AmxGetCustomerInfoResponse
                        {
                            Error = string.Format("Customer not found for customerName={0}", request.customerName),
                            Success = false
                        };
                        return _response;
                    }

                    _response = new AmxGetCustomerInfoResponse(individual)
                    {
                        Success = true
                    };
                    return _response;
                }

                if (!string.IsNullOrEmpty(request.msisdn))
                {
                    var listIndividual = this.individualCustomerRepository.ListByTelephoneNumber(request.msisdn);

                    if (listIndividual.Count == 0)
                    {
                        _response = new AmxGetCustomerInfoResponse
                        {
                            Error = string.Format("Customer not found for msisdn={0}", request.msisdn),
                            Success = false
                        };
                        return _response;
                    }

                    if (listIndividual.Count > 1)
                    {
                        _response = new AmxGetCustomerInfoResponse
                        {
                            Error = string.Format("Found {0} match customers for telefoneNumber {1}", listIndividual.Count, request.msisdn),
                            Success = false
                        };
                        return _response;
                    }

                    _response = new AmxGetCustomerInfoResponse(listIndividual[0])
                    {
                        Success = true
                    };
                    return _response;
                }

                _response = new AmxGetCustomerInfoResponse
                {
                    Status = "NOK",
                    Error = "Search Criteria is null",
                    Success = false
                };
            }
            catch (Exception ex)
            {
                throw;
            }

            return _response;
        }

        public AmxGetCustomerInfoResponse SearchCustomerUri(AmxGetCustomerInfoRequest request, string CTIUrl, string CustomerSearch, string prospectUrl, OrganizationServiceProxy _org)
        {
            string inputValidationErrorMsg = string.Empty;
            string searchedCustomerUri = string.Empty;
            string fetchXml = string.Empty;
            AmxGetCustomerInfoResponse _response = null;
            if (request != null)
            {
                try
                {
                    if (request.documentType <= 0 || request.documentType > 9)
                    {
                        inputValidationErrorMsg = "Document Type is not valid, Please enter a valid document type. "
                            + "CEDULA_DE_CIUDADANIA = 1,"
                            + "NIT = 2,"
                            + "NIT_DE_EXTRANJERIA = 3,"
                            + "CEDULA_EXTRANJERIA = 4,"
                            + "PASAPORTE = 5,"
                            + "CARNET_DIPLOMATICO = 6"
                            + "TARJETA_DE_IDENTIDAD = 7"
                            + "TARJETA_DE_EXTRANJERIA = 8"
                            + "REGISTRO_DE_NACIMIENTO = 9";

                    }
                    //Fetch Xml Logic
                    if (string.IsNullOrEmpty(request.msisdn))
                    {
                        if (!string.IsNullOrEmpty(request.documentNumber))
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
                        if (!string.IsNullOrEmpty(request.documentNumber))
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

                        var customerId = Guid.Empty;
                        if (_EntityCollection != null && _EntityCollection.Entities.Count > 0)
                        {
                            customerId = _EntityCollection.Entities[0].Id;
                            searchedCustomerUri = string.Format(CTIUrl, customerId.ToString());
                        }

                        if (customerId == Guid.Empty)
                        {
                            //                            customerId = this.CreateProspect(request, _org);
                            searchedCustomerUri = string.Format(prospectUrl, customerId.ToString());
                        }

                        if (string.IsNullOrEmpty(searchedCustomerUri))
                        {
                            searchedCustomerUri = CustomerSearch;
                        }

                        if (!string.IsNullOrEmpty(searchedCustomerUri))
                        {
                            _response = new AmxGetCustomerInfoResponse
                            {
                                //CustomerUri = searchedCustomerUri,
                                Status = "OK"
                            };
                        }
                        else
                        {
                            _response = new AmxGetCustomerInfoResponse
                            {
                                Status = "NOK",
                                Error = "Search Criteria is null",
                            };
                        }
                    }
                    else
                    {
                        _response = new AmxGetCustomerInfoResponse
                        {
                            Status = "NOK",
                            Error = "Search Criteria is null",
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
                _response = new AmxGetCustomerInfoResponse
                {
                    Status = "NOK",
                    Error = "Incoming Request in empty",
                };
            }
            return _response;
        }

        private string SetFetchXmlDoc(int customerType, AmxGetCustomerInfoRequest request)
        {
            string fetchXml = string.Empty;

            try
            {
                if (customerType == 1)
                {
                    fetchXml = string.Format(CtiSearchDocTypeDocNumber, request.documentType, request.documentNumber);
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

        private string SetFetchXmlDocMSISDN(int customerType, AmxGetCustomerInfoRequest request)
        {
            string fetchXml = string.Empty;

            try
            {
                if (customerType == 1)
                {
                    fetchXml = string.Format(CtiSearchDocTypeDocNumberMSISDN, request.documentType, request.documentNumber, request.msisdn);
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

        private string SetFetchXmlMobilephone(int customerType, AmxGetCustomerInfoRequest request)
        {
            string fetchXml = string.Empty;

            try
            {
                if (customerType == 1)
                {
                    fetchXml = string.Format(CtiSearchContactMobilephone, request.msisdn);
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

        private string SetFetchXmlMSISDN(int customerType, AmxGetCustomerInfoRequest request)
        {
            string fetchXml = string.Empty;

            try
            {
                if (customerType == 1)
                {
                    fetchXml = string.Format(CtiSearchMSISDN, request.msisdn);
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

        private static string CtiSearchContactMobilephone = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='true'>
                                                                  <entity name='contact'>
                                                                    <attribute name='fullname' />
                                                                    <attribute name='contactid' />
                                                                      <filter type='and'>
                                                                        <condition attribute='mobilephone' operator='eq' value='{0}' />
                                                                      </filter>
                                                                  </entity>
                                                                </fetch>";

        private Guid CreateProspect(AmxCoCTIGetCustomerRequest request, OrganizationServiceProxy _org)
        {
            var createProspectBusiness = new AmxPeruPSBActivities.Business.AmxCoCreateProspectBusiness();

            var prospectRequest = new AxmPeruCreateProspectRequest()
            {
                documentType = request.DocumentType,
                documentNumber = request.DocumentNumber,
                phone = request.ANI,
                firstName = string.Empty,
                lastName = string.Empty
            };

            var prospectResponse = createProspectBusiness.CreateProspectCustomer(prospectRequest, _org);

            Guid prospectId = Guid.Empty;
            Guid.TryParse(prospectResponse.prospectId, out prospectId);

            return prospectId;
        }
    }
}