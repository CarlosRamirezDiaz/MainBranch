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
    public class AmxCoCreateProspectBusiness
    {
        public AxmPeruCreateProspectResponse CreateProspectCustomer(AxmPeruCreateProspectRequest _request, OrganizationServiceProxy _org)
        {
            AxmPeruCreateProspectResponse _response = null;
            if (_request != null)
            {
                _response = new AxmPeruCreateProspectResponse();
                Entity individual = new Entity("contact");
                string alert = ValidateInputs(_request);
                if (alert != "")
                {
                    _response.Error = alert;
                    _response.successFlag = 0;
                    return _response;
                }
                string alertMsg = ValidateDocumentTypeID(_request.documentType, _request.documentNumber);
                if (alertMsg != "")
                {
                    _response.Error = alertMsg;
                    _response.successFlag = 0;
                    return _response;
                }
                if (!string.IsNullOrEmpty(_request.firstName))
                {
                    individual.Attributes["firstname"] = _request.firstName.ToString();
                }
                if (!string.IsNullOrEmpty(_request.lastName))
                {
                    individual.Attributes["lastname"] = _request.lastName.ToString();
                }
                if (!string.IsNullOrEmpty(_request.companyName))
                {
                    individual.Attributes["company"] = _request.companyName.ToString();
                }
                if (!string.IsNullOrEmpty(_request.email))
                {
                    individual.Attributes["emailaddress1"] = _request.email.ToString();
                }
                if (!string.IsNullOrEmpty(_request.phone))
                {
                    individual.Attributes["mobilephone"] = _request.phone.ToString();
                }
                if (!string.IsNullOrEmpty(_request.documentNumber))
                {
                    individual.Attributes["etel_iddocumentnumber"] = _request.documentNumber.ToString();
                }
                if (_request.documentType > 0 && _request.documentType <= 6)
                {
                    individual.Attributes["amxperu_documenttype"] = new OptionSetValue(_request.documentType);
                }
                individual.Attributes["statuscode"] = new OptionSetValue(831260000);  // Prospect StatusCode
        
                Guid createdCustomerId = _org.Create(individual);
                if (createdCustomerId != Guid.Empty)
                {
                    _response.prospectId = createdCustomerId.ToString();
                    _response.successFlag = 1;
                    _response.Status = "OK";
                }
            }
            return _response;
        }

        private string ValidateDocumentTypeID(int docType, string docNumber)
        {
            return string.Empty;

            string alertMessage = "";
            if (docType == 1)
            {
                if (docNumber.Length != 8)
                {
                    alertMessage = alertMessage + "Document Number should be of 8 characters";
                }
            }
            else if (docType == 2)
            {
                if (docNumber.Length != 9)
                {
                    alertMessage = alertMessage + "Document Number should be of 9 characters";
                }
            }
            else if (docType == 3)
            {
                if (docNumber.Length != 11)
                {
                    alertMessage = alertMessage + "Document Number should be of 11 characters";
                }
            }
            else if (docType == 4)
            {
                if (docNumber.Length == 0)
                {
                    alertMessage = alertMessage + "Document Number should not be empty";
                }
            }
            else
            {
                alertMessage = alertMessage + "Document Type is not valid";
            }
            return alertMessage;
        }
        private string ValidateInputs(AxmPeruCreateProspectRequest request)
        {
            string alert = "";
            if (request.firstName == null)
            {
                alert = alert + "First Name should not be empty";
            }
            if (request.lastName == null)
            {
                alert = alert + "Last Name should not be empty";
            }
            if (request.phone == null)
            {
                alert = alert + "Phone Number should not be empty";
            }
            if (request.documentNumber == null)
            {
                alert = alert + "Document Number should not be empty";
            }
            if (request.documentType == 0)
            {
                alert = alert + "Document Type should not be 0";
            }
            return alert;
        }
    }
}
