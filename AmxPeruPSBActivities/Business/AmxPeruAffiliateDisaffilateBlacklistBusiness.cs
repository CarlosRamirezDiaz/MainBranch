using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Model.AffiliateDisaffiliate;
using AmxPeruPSBActivities.Model.OrderCaptureSubmit;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AmxPeruPSBActivities.Business
{
    public class AmxPeruAffiliateDisaffilateBlacklistBusiness
    {
        public SubmitOrderRequest getOrderCaptureRequest(AffiliateDisaffilateBlacklistRequest _request, OrganizationServiceProxy _org)
        {
            SubmitOrderRequest _orderRequest = null;
            if (_request != null)
            {
                _orderRequest = new SubmitOrderRequest()
                {
                    createdDate = DateTime.Now.ToString(CultureInfo.CurrentCulture.DateTimeFormat.SortableDateTimePattern),
                    description = "Add CCOI for change Affiliate",
                    run = true,
                    requestedCompletionDate = DateTime.Now.AddDays(5).ToString(CultureInfo.CurrentCulture.DateTimeFormat.SortableDateTimePattern)
                };

                RelatedParty relatedPartyCustomer = new RelatedParty()
                {
                    role = "Customer",
                    reference = _request.CustomerExternalId
                };
                RelatedParty relatedPartyContract = new RelatedParty()
                {
                    role = "contractId",
                    reference = _request.ContractID
                };

                _orderRequest.relatedParties = new List<RelatedParty>();
                _orderRequest.relatedParties.Add(relatedPartyCustomer);
                _orderRequest.relatedParties.Add(relatedPartyContract);

                _orderRequest.orderItems = new List<OrderItem>();
                OrderItem orderItem = new OrderItem();
                orderItem.item = new Model.OrderCaptureSubmit.Item();
                orderItem.item.orderType = "CustomerChangeOrder";
                orderItem.item.action = "omUpdateAffiliatesCCOI";
                orderItem.item.attrs = new List<Attr>();
                if(!string.IsNullOrEmpty(_request.PromotionsBlackList))
                orderItem.item.attrs.Add(new Attr() { name = "PromotionsBlackList", value = _request.PromotionsBlackList });
                if (!string.IsNullOrEmpty(_request.SurveysBlackList))
                orderItem.item.attrs.Add(new Attr() { name = "SurveysBlackList", value = _request.SurveysBlackList });
                if (!string.IsNullOrEmpty(_request.ClaroVASBlackList))
                orderItem.item.attrs.Add(new Attr() { name = "ClaroVASBlackList", value = _request.ClaroVASBlackList });
                if (!string.IsNullOrEmpty(_request.ExternalVASBlackList))
                orderItem.item.attrs.Add(new Attr() { name = "ExternalVASBlackList", value = _request.ExternalVASBlackList });
                _orderRequest.orderItems.Add(orderItem);
            }

            return _orderRequest;
        }
        public SubscriptionBlacklistResponse UpdateSubscriptionBlacklistFields(AffiliateDisaffilateBlacklistRequest _request, OrganizationServiceProxy _org)
        {
            SubscriptionBlacklistResponse _response = null;
            if (_request != null)
            {
                _response = new SubscriptionBlacklistResponse();
                Microsoft.Xrm.Sdk.Entity contract = new Microsoft.Xrm.Sdk.Entity("etel_subscription");
                if (!string.IsNullOrEmpty(_request.ContractID))
                {
                    contract.Id = GetLookupGuidFromField("etel_subscription", "etel_externalid", _request.ContractID,_org);
                    if (!string.IsNullOrEmpty(_request.PromotionsBlackList))
                    {
                        if (_request.PromotionsBlackList == "true")
                        {
                            contract.Attributes["amxperu_promotions"] = new OptionSetValue(250000001);
                        }
                        else if (_request.PromotionsBlackList == "false")
                        {
                            contract.Attributes["amxperu_promotions"] = new OptionSetValue(250000000);
                        }
                    }
                    if (!string.IsNullOrEmpty(_request.SurveysBlackList))
                    {
                        if (_request.SurveysBlackList == "true")
                        {
                            contract.Attributes["amxperu_surveys"] = new OptionSetValue(250000001);
                        }
                        else if (_request.SurveysBlackList == "false")
                        {
                            contract.Attributes["amxperu_surveys"] = new OptionSetValue(250000000);
                        }
                    }
                    if (!string.IsNullOrEmpty(_request.ClaroVASBlackList))
                    {
                        if (_request.ClaroVASBlackList == "true")
                        {
                            contract.Attributes["amxperu_clarovasservices"] = new OptionSetValue(250000001);
                        }
                        else if (_request.ClaroVASBlackList == "false")
                        {
                            contract.Attributes["amxperu_clarovasservices"] = new OptionSetValue(250000000);
                        }
                    }
                    if (!string.IsNullOrEmpty(_request.ExternalVASBlackList))
                    {
                        if (_request.ExternalVASBlackList == "true")
                        {
                            contract.Attributes["amxperu_externalvasservices"] = new OptionSetValue(250000001);
                        }
                        else if (_request.ExternalVASBlackList == "false")
                        {
                            contract.Attributes["amxperu_externalvasservices"] = new OptionSetValue(250000000);
                        }
                    }
                    _org.Update(contract);
                    _response.successflag = 1;
                }
            }
            return _response;
        }
        public Guid GetLookupGuidFromField(string entityName, string columnName, string columnValue, OrganizationServiceProxy OrgService)
        {
            QueryExpression retrieveQuery = new QueryExpression(entityName);
            retrieveQuery.Criteria.AddCondition(columnName, ConditionOperator.Equal, columnValue);
            EntityCollection retrievedCollection = OrgService.RetrieveMultiple(retrieveQuery);

            if (retrievedCollection.Entities.Count == 1)
            {
                return retrievedCollection[0].Id;
            }
            return Guid.Empty;
        }
    }
}
