using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxCoPSBActivities.ModelClaroESB.Bureau;
using Newtonsoft.Json;
using AmxPeruPSBActivities.Repository;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Model.CreditProfile;
using AmxPeruPSBActivities.Service.SendNotification;
using Microsoft.Xrm.Sdk;

namespace AmxCoPSBActivities.BusinessClaroESB
{
    public class CustomerBiographicBusiness
    {
        public string GetCustomerBiographicBusiness(string bureauURL, Guid individualCustomerId, OrganizationServiceProxy _org)
        {
            int biographicValidationExpiration = 30;

            var individualRepository = new IndividualCustomerRepository(_org);

            var individual = individualRepository.GetById(individualCustomerId);

            if (individual.IndividualCustomerId == Guid.Empty)
                throw new Exception("Individual Customer not found for Id: " + individualCustomerId);

            if (string.IsNullOrEmpty(individual.LastName))
                throw new Exception("Individual Customer lastname empty for Id: " + individualCustomerId);

            var lastValidationDate = individual.BiographicValidationDate;
            var x = (DateTime.Today - lastValidationDate).Days;

            if (x > biographicValidationExpiration)
            {
                var lastNames = individual.LastName.Trim().Split(' ');
                var lastName = lastNames[lastNames.Length - 1];

                var common = new AmxCoPSBActivities.BusinessClaroESB.AmxCoClaroESBCommon(_org);

                var request = GetBureauRequest.GetBureauRequestFactory(individual.DocumentType, individual.DocumentNumber, individual.DocumentIssueDate, lastName);

                string jsonRequest;
                string jsonResponse;
                string error;

                if (!common.RestCall<GetBureauRequest>(bureauURL, request, out jsonRequest, out jsonResponse, out error))
                {
                    return "Error";
                }

                var getBureauResponse = JsonConvert.DeserializeObject<ModelClaroESB.Bureau.GetBureauResponse>(jsonResponse);

                // Save First name

                if (getBureauResponse.customerName.givenNames != "")
                {
                    Entity Customer = new Entity("contact", individual.IndividualCustomerId);
                    Customer.Attributes.Add("firstname", getBureauResponse.customerName.givenNames);
                    Customer.Attributes.Add("amx_biographicvalidationdate", DateTime.Today);
                    _org.Update(Customer);
                }
            }

            return "OK";
        }
    }
}
