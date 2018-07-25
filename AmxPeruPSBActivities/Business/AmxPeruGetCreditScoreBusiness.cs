using AmxPeruPSBActivities.Model.CreditScore;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Business
{
    public class AmxPeruGetCreditScoreBusiness
    {
        public AmxPeruGetCreditScoreResponse GetCreditScore(AmxPeruGetCreditScoreRequest request, OrganizationServiceProxy OrgService)
        {
            AmxPeruGetCreditScoreResponse _AmxPeruGetCreditScoreResponse = null;



            try
            {
                _AmxPeruGetCreditScoreResponse = new AmxPeruGetCreditScoreResponse();

                if (request != null)
                {
                    if (request.CustomerType == 1 || request.CustomerType == 2)
                    {
                        string entityName = "";
                        if (request.CustomerType == 1)
                        {
                            entityName = "contact";

                        }
                        else if (request.CustomerType == 2)
                        {
                            entityName = "account";
                        }

                        Guid custGuid = Guid.Empty;
                        if (!string.IsNullOrEmpty(request.CustomerExternalId))
                        {
                            custGuid = GetLookupGuidFromField(entityName, "etel_externalid", request.CustomerExternalId, OrgService);
                        }
                        else if (!string.IsNullOrEmpty(request.DocumentID))
                        {
                            custGuid =GetCustomerGuidFroDocumentTypeAndNumber(entityName,request.DocumentType, request.DocumentID, OrgService);

                        }
                        if (custGuid != Guid.Empty)
                        {
                            Entity customerData = new Entity();

                            QueryExpression creditProfileListQuery = new QueryExpression("etel_creditprofile");
                            if (request.CustomerType == 1)
                            {
                                customerData = OrgService.Retrieve("contact", custGuid, new ColumnSet(true));

                                if (customerData.LogicalName == "contact")
                                {
                                    _AmxPeruGetCreditScoreResponse.Individual = new Individual();
                                    _AmxPeruGetCreditScoreResponse.Individual.CustomerType = "Individual";
                                    if (customerData.Contains("firstname"))
                                    {
                                        _AmxPeruGetCreditScoreResponse.Individual.Names = customerData.Attributes["firstname"].ToString();
                                    }
                                    if (customerData.Contains("lastname"))
                                    {
                                        _AmxPeruGetCreditScoreResponse.Individual.LastName = customerData.Attributes["lastname"].ToString();
                                    }
                                    if (customerData.Contains("birthdate"))
                                    {
                                        _AmxPeruGetCreditScoreResponse.Individual.BirthDate = (DateTime)(customerData.Attributes["birthdate"]);
                                    }
                                    if (customerData.Contains("amxperu_motherslastname"))
                                    {
                                        _AmxPeruGetCreditScoreResponse.Individual.MotherLastName = customerData.Attributes["amxperu_motherslastname"].ToString();
                                    }




                                }


                                creditProfileListQuery.Criteria.AddCondition("etel_individualid", ConditionOperator.Equal, custGuid);
                                creditProfileListQuery.ColumnSet = new ColumnSet(true);
                                EntityCollection creditProfileList = OrgService.RetrieveMultiple(creditProfileListQuery);

                                if (creditProfileList.Entities.Count > 0)
                                {
                                    Entity creditprofileRecord = creditProfileList.Entities.First();
                                    if (creditprofileRecord.Contains("etel_creditscore"))
                                    {
                                        _AmxPeruGetCreditScoreResponse.Individual.CreditScore = creditprofileRecord.Attributes["etel_creditscore"].ToString();
                                    }

                                }
                            }
                            else if (request.CustomerType == 2)
                            {
                                customerData = OrgService.Retrieve("account", custGuid, new ColumnSet(true));

                                if (customerData.LogicalName == "account")
                                {
                                    _AmxPeruGetCreditScoreResponse.Corporate = new Corporate();
                                    if (customerData.Contains("name"))
                                    {
                                        _AmxPeruGetCreditScoreResponse.Corporate.CompanyName = customerData.Attributes["name"].ToString();
                                    }

                                }
                                creditProfileListQuery.Criteria.AddCondition("etel_corporateid", ConditionOperator.Equal, custGuid);
                                creditProfileListQuery.ColumnSet = new ColumnSet(true);
                                EntityCollection creditProfileList = OrgService.RetrieveMultiple(creditProfileListQuery);

                                if (creditProfileList.Entities.Count > 0)
                                {
                                    Entity creditprofileRecord = creditProfileList.Entities.First();
                                    if (creditprofileRecord.Contains("etel_creditscore"))
                                    {
                                        //   _AmxPeruGetCreditScoreResponse.Corporate.Score = creditprofileRecord.Attributes["etel_creditscore"].ToString();
                                    }

                                }
                            }

                            _AmxPeruGetCreditScoreResponse.SucessFlag = 1;
                        }
                        else {
                            _AmxPeruGetCreditScoreResponse.SucessFlag = 0;
                            _AmxPeruGetCreditScoreResponse.Error = "Customer not found for the given criteria";
                            return _AmxPeruGetCreditScoreResponse;
                            throw new Exception("No Customer found with given information.");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return _AmxPeruGetCreditScoreResponse;





        }
        public Guid GetLookupGuidFromField(string entityName, string columnName, string columnValue, OrganizationServiceProxy OrgService)
        {
            QueryExpression retrieveQuery = new QueryExpression(entityName);
            retrieveQuery.Criteria.AddCondition(columnName, ConditionOperator.Equal, columnValue);
            EntityCollection retrievedCollection = OrgService.RetrieveMultiple(retrieveQuery);

            if (retrievedCollection.Entities.Count >= 1)
            {
                return retrievedCollection.Entities.First().Id;
            }

            return Guid.Empty;
        }

        public Guid GetCustomerGuidFroDocumentTypeAndNumber(string entityName, int documentType, string documentNumber, OrganizationServiceProxy OrgService)
        {
            int documentTypeValue = 0;
            //switch (documentType) {
            //    case "DNI":
            //        documentTypeValue = 250000000;
            //        break;
            //    case "CE":
            //        documentTypeValue = 250000001;

            //        break;
            //    case "RUC":
            //        documentTypeValue = 250000002;

            //        break;
            //    case "Passport":
            //        documentTypeValue = 250000003;

            //        break;
            //    default:
            //        throw new Exception ("Document ID not provided or given value for document ID is wrong.");
                 
            //}
            QueryExpression retrieveQuery = new QueryExpression(entityName);
            retrieveQuery.Criteria.AddCondition("amxperu_documenttype", ConditionOperator.Equal, documentTypeValue);
            retrieveQuery.Criteria.AddCondition("etel_passportnumber", ConditionOperator.Equal, documentNumber);
            EntityCollection retrievedCollection = OrgService.RetrieveMultiple(retrieveQuery);

            if (retrievedCollection.Entities.Count >= 1)
            {
                return retrievedCollection.Entities.First().Id;
            }

            return Guid.Empty;
        }


    }
}
