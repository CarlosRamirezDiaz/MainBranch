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
    public class AmxCoBureauBusiness
    {
        public string GetBureau(string bureauURL, Guid individualCustomerId, OrganizationServiceProxy _org)
        {
            int externalBureauExpiration = 30;

            var individualRepository = new IndividualCustomerRepository(_org);

            var individual = individualRepository.GetById(individualCustomerId);

            if (individual.IndividualCustomerId == Guid.Empty)
                throw new Exception("Individual Customer not found for Id: " + individualCustomerId);

            if (string.IsNullOrEmpty(individual.LastName))
                throw new Exception("Individual Customer lastname empty for Id: " + individualCustomerId);

            // Get the last Credit Profile
            var creditProfileRepository = new CreditProfileRepository(_org);
            var existCreditProfile = creditProfileRepository.GetLastBy(individualCustomerId, DateTime.Now.Date.AddHours(-24));
            //if (existCreditProfile.Id != Guid.Empty)
            //{
            //    return "Credit Profile already exists.";
            //}

            var creditdate = existCreditProfile.BureauDate;
            var numberOfDays = DateTime.Now.Subtract(creditdate);

            if (numberOfDays.Days > externalBureauExpiration || existCreditProfile.BureauSource == "Interno")
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
                    //return error;
                    return "Error";
                }

                var getBureauResponse = JsonConvert.DeserializeObject<ModelClaroESB.Bureau.GetBureauResponse>(jsonResponse);

                var creditProfile = new CreditProfileModel();
                creditProfile.BureauClassification = getBureauResponse.customerCreditProfile.classification;
                creditProfile.BureauCreditScore = getBureauResponse.customerCreditProfile.creditScore.ToString();
                creditProfile.BureauDate = DateTime.Now;
                creditProfile.BureauType = getBureauResponse.customerCreditProfile.type;
                creditProfile.BureauFamilyNames = getBureauResponse.customerName.familyNames;
                creditProfile.BureauGivenNames = getBureauResponse.customerName.givenNames;
                creditProfile.BureauScore = getBureauResponse.customerCreditProfile.score;
                creditProfile.BureauSource = "Externo";
                creditProfile.IndividualCustomerId = individualCustomerId;

                //QueryExpression ConfigData = new QueryExpression { EntityName = "etel_crmconfiguration", ColumnSet = new ColumnSet(true) };
                //ConfigData.Criteria = new FilterExpression();
                //ConfigData.Criteria.AddCondition("etel_name", ConditionOperator.Equal, "ClaroESB_Header_ipApplication");
                //EntityCollection templateCollection = _org.RetrieveMultiple(ConfigData);
                //if (templateCollection != null && templateCollection.Entities.Count > 0)
                //{
                //    creditProfile.BureauType = templateCollection.Entities[0].Attributes["etel_value"].ToString();
                //}
                
                creditProfileRepository.Create(creditProfile);

                //2018-07-02 eheldma: Save first and last name

                if (getBureauResponse.customerName.givenNames != "") {
                    Entity Customer = new Entity("contact", individual.IndividualCustomerId);
                    Customer.Attributes.Add("firstname", getBureauResponse.customerName.givenNames);
                    _org.Update(Customer);
                }
                
                return "Credit Profile created.";
            }

            return "Credit Profile still valid.";
        }
    }
}
