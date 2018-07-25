using AmxPeruPSBActivities.Common;
using AmxPeruPSBActivities.Model.Individual;
using AmxPeruPSBActivities.Repository;
using Microsoft.Xrm.Sdk.Client;
using System;

namespace AmxCoPSBActivities.ModelClaroESB.Sarglaft
{
    public class ConsultListsRequest
    {
        // Sample Request
        //"name" : "chapo guzman",
        //"punctuation" : "95",
        //"lists" : "ONU|OFAC|FBI"
        public string typeIdentification { get; set; }
        public string identification { get; set; }
        public string name { get; set; }
        public string punctuation { get; set; }
        public string lists { get; set; }
       
        public static ConsultListsRequest ConsultListsRequestFactory(string fullName, string customerId, int punctuation, OrganizationServiceProxy _org)
        {
            var returnValue = new ConsultListsRequest();

            returnValue.name = fullName;
            returnValue.punctuation = punctuation.ToString();
            returnValue.lists = "ONU|OFAC|FBI";

            // Get customer information to include the id and id type
            IndividualCustomerRepository individualCustomerRepository = new IndividualCustomerRepository(_org);
            IndividualCustomerModel individualCustomer = individualCustomerRepository.GetById(new System.Guid(customerId));

            // Getting value of document type and parsing to retrieve code
            string[] stringSplit = OptionSet.RetrieveDocumentTypeByValue(individualCustomer.DocumentType).Split(new string[] { "-" }, StringSplitOptions.None);

            returnValue.typeIdentification = stringSplit[0];

            returnValue.identification = individualCustomer.DocumentNumber;

            return returnValue;
        }
    }
}
