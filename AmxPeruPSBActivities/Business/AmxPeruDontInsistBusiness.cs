using AmxPeruPSBActivities.Model;
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
    public class AmxPeruDontInsistBusiness
    {
        public AmxPeruDontInsistResponse SetDontInsist(AmxPeruDontInsistRequest request,OrganizationServiceProxy OrgService)
        {
            AmxPeruDontInsistResponse _AmxPeruDontInsistResponse = null;

         

            try
            {
                _AmxPeruDontInsistResponse = new AmxPeruDontInsistResponse();

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
                         Guid custGuid = GetLookupGuidFromField(entityName, "etel_externalid", request.CustomerExternalId,OrgService);

                        if (custGuid != Guid.Empty)
                        {

                            Entity relatedContact = new Entity(entityName, custGuid);
                            relatedContact["amxperu_donotinsist"] = request.DontInsistFlag;
                            if (request.DontInsistDate != DateTime.MinValue)
                            {
                                relatedContact["amxperu_donotinsistdate"] = request.DontInsistDate;
                            }
                            OrgService.Update(relatedContact);
                            //CreateBILogRequest BIRequest = new CreateBILogRequest();
                            //BIRequest.Channel = request.Channel;
                            //BIRequest.CustomerExternalID = request.CustomerExternalID;
                            //BIRequest.CustomerType = request.CustomerType;
                            //BIRequest.subject = Constants.BILogDontInsistSubject;
                            //BIRequest.description = Constants.BILogDontInsistDescription;
                            //BIRequest.RegardingRecordEntityName = relatedContact.LogicalName;
                            //BIRequest.RegardingRecordID = relatedContact.Id;

                            //CreateBILogBusiness BIBusiness = new CreateBILogBusiness();
                            //BIBusiness.CreateBILogValues(BIRequest);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return _AmxPeruDontInsistResponse;





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


    }
}
