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
    public class AmxPeruGetCustomerSpecialCasesBusiness
    {
        public AmxPeruGetCustomerSpecialCasesResponse GetSpecialCases(AmxPeruGetCustomerSpecialCasesRequest _request, OrganizationServiceProxy _org)
        {
            AmxPeruGetCustomerSpecialCasesResponse _response = null;
            if (_request != null)
            {
                _response = new AmxPeruGetCustomerSpecialCasesResponse();
                if (!string.IsNullOrEmpty(_request.CustomerExternalId))
                {
                    List<MarketingList> _markets = new List<MarketingList>();
                    string CustomerExternalID = _request.CustomerExternalId;
                    if (_request.CustomerType == 1)
                    {
                        _markets = GetIndividualMarketingList(CustomerExternalID, _org);
                        if (_markets.Count > 0)
                        {
                            _response.specialCases = _markets;
                            _response.Status = "OK";                            
                        }
                        else
                        {
                            _response.Status = "NOK";
                            _response.Error= "No Special Cases found for the Customer";
                        }
                    }
                    else if (_request.CustomerType == 2)
                    {
                        _markets = GetCorporateMarketingList(CustomerExternalID, _org);
                        if (_markets.Count > 0)
                        {
                            _response.specialCases = _markets;
                            _response.Status = "OK";
                        }
                        else
                        {
                            _response.Status = "NOK";
                            _response.Error = "No Special Cases found for the Customer";
                        }
                    }
                    else
                    {
                        _markets = GetIndividualMarketingList(CustomerExternalID, _org);
                        if (_markets.Count == 0)
                        {
                            _markets = GetCorporateMarketingList(CustomerExternalID, _org);
                            if (_markets.Count == 0)
                            {                                
                                _response.Error = "No Special Cases found for the Customer";
                                _response.Status = "NOK";
                                return _response;
                            }
                        }

                    }
                }
                else
                {
                    throw new Exception("Customer ExternalId Expected");
                }

            }

            return _response;
        }
        private List<MarketingList> GetIndividualMarketingList(string CustomerExternalID, OrganizationServiceProxy _org)
        {           
            List<MarketingList> _marketingList = new List<MarketingList>();
            string fetchMarketingList = string.Empty;
            fetchMarketingList = string.Format(FetchMarketingListIndividual, CustomerExternalID);
            DataCollection<Entity> _entities = _org.RetrieveMultiple(new FetchExpression(fetchMarketingList)).Entities;
            foreach (var entity in _entities)
            {
                MarketingList _market = new MarketingList();
                if (entity.Attributes.Contains("listname"))
                {
                    _market.name = entity.Attributes["listname"].ToString();
                }
                _marketingList.Add(_market);               
            }
            return _marketingList;
        }
        private List<MarketingList> GetCorporateMarketingList(string CustomerExternalID, OrganizationServiceProxy _org)
        {
            List<MarketingList> _marketingList = new List<MarketingList>();
            string fetchMarketingList = string.Empty;
            fetchMarketingList = string.Format(FetchMarketingListCorporate, CustomerExternalID);
            DataCollection<Entity> _entities = _org.RetrieveMultiple(new FetchExpression(fetchMarketingList)).Entities;
            foreach (var entity in _entities)
            {
                MarketingList _market = new MarketingList();
                if (entity.Attributes.Contains("name"))
                {
                    _market.name = entity.Attributes["name"].ToString();
                }
                _marketingList.Add(_market);
            }
            return _marketingList;
        }
        private static string FetchMarketingListIndividual= @"<fetch distinct='true' mapping='logical' output-format='xml-platform' version='1.0'>
                                                                <entity name='list'>
                                                                <attribute name='listname'/>
                                                                <attribute name='type'/>
                                                                <attribute name='createdfromcode'/>
                                                                <attribute name='listid'/>
                                                                <order descending='true' attribute='listname'/>
                                                                <link-entity name='listmember' intersect='true' visible='false' to='listid' from='listid'>
                                                                <link-entity name='contact' to='entityid' from='contactid' alias='ad'>
                                                                <filter type='and'>
                                                                <condition attribute='etel_externalid' value='{0}' operator='eq'/>
                                                                </filter>
                                                                </link-entity>
                                                                </link-entity>
                                                                </entity>
                                                                </fetch>";
        private static string FetchMarketingListCorporate = @"<fetch distinct='true' mapping='logical' output-format='xml-platform' version='1.0'>
                                                                <entity name='list'>
                                                                <attribute name='listname'/>
                                                                <attribute name='type'/>
                                                                <attribute name='createdfromcode'/>
                                                                <attribute name='listid'/>
                                                                <order descending='true' attribute='listname'/>
                                                                <link-entity name='listmember' intersect='true' visible='false' to='listid' from='listid'>
                                                                <link-entity name='account' to='entityid' from='accountid' alias='ad'>
                                                                <filter type='and'>
                                                                <condition attribute='etel_externalid' value='{0}' operator='eq'/>
                                                                </filter>
                                                                </link-entity>
                                                                </link-entity>
                                                                </entity>
                                                                </fetch>";
    }
}
