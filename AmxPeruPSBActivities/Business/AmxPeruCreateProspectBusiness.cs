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
    public class AmxPeruCreateProspectBusiness
    {
        public AxmPeruCreateProspectResponse CreateProspectCustomer (AxmPeruCreateProspectRequest _request, OrganizationServiceProxy _org)
        {
            AxmPeruCreateProspectResponse _response = null;
            if (_request != null)
            {
                _response = new AxmPeruCreateProspectResponse();
                Entity individual = new Entity("contact");
                string alert = ValidateInputs(_request);
                if(alert != "")
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
                individual.Attributes["firstname"] = _request.firstName.ToString();
                individual.Attributes["lastname"] = _request.lastName.ToString();                
                if (_request.companyName != null)
                {
                    individual.Attributes["company"] = _request.companyName.ToString();
                }
                if (_request.email != null)
                {
                    individual.Attributes["emailaddress1"] = _request.email.ToString();
                }
                individual.Attributes["mobilephone"] = _request.phone.ToString();
                individual.Attributes["etel_passportnumber"] = _request.documentNumber.ToString();
                int docType = _request.documentType;
                if (docType == 1)
                {
                    individual.Attributes["amxperu_documenttype"] = new OptionSetValue(250000000);
                }
                else if (docType == 2)
                {
                    individual.Attributes["amxperu_documenttype"] = new OptionSetValue(250000001);
                }
                else if (docType == 3)
                {
                    individual.Attributes["amxperu_documenttype"] = new OptionSetValue(250000002);
                }
                else if (docType == 4)
                {
                    individual.Attributes["amxperu_documenttype"] = new OptionSetValue(250000003);
                }
                Guid createdCustomerId = _org.Create(individual);
                if (createdCustomerId != null)
                {
                    _response.prospectId = createdCustomerId.ToString();
                    _response.successFlag = 1;
                    _response.Status = "OK";
                }
            }
          return _response;
        }

        private string ValidateDocumentTypeID( int docType, string docNumber)
        {
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
               if(docNumber.Length == 0)
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
