using AmxPeruPSBActivities.Model.OrderCapture;
using AmxPeruPSBActivities.Model.OrderCaptureSubmit;
using Ericsson.ETELCRM.Entities.Crm;
using Ericsson.ETELCRM.Entities.Crm.CustomEntities;
using ExternalApiActivities.Common;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.Order
{
    public class GetOfferingActivity : XrmAwareCodeActivity
    {
        public InArgument<OfferingRequestModel> OfferingModelInput { get; set; }
        public OutArgument<OfferingModel> OfferingModelOutPut { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            OfferingRequestModel _OfferingRequestModel = new OfferingRequestModel();
            OfferingModel _OfferingModel = new OfferingModel();

            try
            {
                _OfferingRequestModel = OfferingModelInput.Get(context);
                bool IsSearchAllOffer = false;

                if (_OfferingRequestModel != null)
                {
                    if (string.IsNullOrEmpty(_OfferingRequestModel.Location) &&
                        string.IsNullOrEmpty(_OfferingRequestModel.OfferName) &&
                        string.IsNullOrEmpty(_OfferingRequestModel.OfferId) &&
                        string.IsNullOrEmpty(_OfferingRequestModel.Family) &&
                        string.IsNullOrEmpty(_OfferingRequestModel.SpecialCase) &&
                        string.IsNullOrEmpty(_OfferingRequestModel.Campaign))
                    {
                        IsSearchAllOffer = true;
                    }

                    if (_OfferingRequestModel.OfferingTypeCode == "Basic")
                    {
                        int OfferTypeCode = 831260006;
                        List<ProductOfferingItem> listOfProductOffering = new List<ProductOfferingItem>();

                        if (IsSearchAllOffer)
                        {
                            QueryExpression offeringQuery = new QueryExpression("product");
                            offeringQuery.ColumnSet = new ColumnSet(true);
                            offeringQuery.Criteria.AddCondition("etel_offertypecode", ConditionOperator.Equal, OfferTypeCode);
                            offeringQuery.Criteria.AddCondition("statecode", ConditionOperator.Equal, new OptionSetValue(1));
                            EntityCollection offeringListCollection = ContextProvider.OrganizationService.RetrieveMultiple(offeringQuery);
                            if (offeringListCollection != null)
                            {
                                if (offeringListCollection.Entities.Count > 0)
                                {
                                    foreach (Microsoft.Xrm.Sdk.Entity offeringEntity in offeringListCollection.Entities)
                                    {
                                        listOfProductOffering.Add(
                                       new ProductOfferingItem()
                                       {
                                           OfferingId = (offeringEntity.Contains("productid")) ? offeringEntity.Attributes["productid"].ToString() : string.Empty,
                                           OfferingName = (offeringEntity.Contains("name")) ? offeringEntity.Attributes["name"].ToString() : string.Empty,
                                           OfferingTypeCode = (offeringEntity.Contains("etel_offertypecode")) ? offeringEntity.Attributes["etel_offertypecode"].ToString() : string.Empty,
                                           OfferingTypeText = (offeringEntity.Contains("etel_offertypecode")) ? offeringEntity.FormattedValues["etel_offertypecode"].ToString() : string.Empty
                                       });
                                    }
                                }
                            }
                        }
                        else
                        {
                            string fetchXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                  <entity name='product'>
                                                    <attribute name='name' />
                                                    <order attribute='productnumber' descending='false' />
                                                    <filter type='and'>
                                                      <condition attribute='etel_offertypecode' operator='eq' value='831260006' />
                                                      <filter type='and'>
                                                        <condition attribute='statecode' operator='eq' value='0' />
                                                        {0}
                                                      </filter>
                                                    </filter>
                                                  </entity>
                                                </fetch>";
                            string conditionExpression = @"<condition attribute='{0}' operator='like' value='%{1}%' />";
                            string condition = string.Empty;
                            if (!string.IsNullOrEmpty(_OfferingRequestModel.OfferName))
                            {
                                condition = condition + string.Format(conditionExpression, "name", _OfferingRequestModel.OfferName);
                            }
                            if (!string.IsNullOrEmpty(_OfferingRequestModel.OfferId))
                            {
                                condition = condition + string.Format(conditionExpression, "etel_externalid", _OfferingRequestModel.OfferId);
                            }

                            fetchXml = string.Format(fetchXml, condition);
                            EntityCollection OfferCollection = ContextProvider.OrganizationService.RetrieveMultiple(new FetchExpression(fetchXml));
                            if (OfferCollection != null)
                            {
                                if (OfferCollection.Entities.Count > 0)
                                {
                                    foreach (Microsoft.Xrm.Sdk.Entity offeringEntity in OfferCollection.Entities)
                                    {
                                        listOfProductOffering.Add(
                                       new ProductOfferingItem()
                                       {
                                           OfferingId = (offeringEntity.Contains("productid")) ? offeringEntity.Attributes["productid"].ToString() : string.Empty,
                                           OfferingName = (offeringEntity.Contains("name")) ? offeringEntity.Attributes["name"].ToString() : string.Empty,
                                           OfferingTypeCode = (offeringEntity.Contains("etel_offertypecode")) ? offeringEntity.Attributes["etel_offertypecode"].ToString() : string.Empty,
                                           OfferingTypeText = (offeringEntity.Contains("etel_offertypecode")) ? offeringEntity.FormattedValues["etel_offertypecode"].ToString() : string.Empty
                                       });
                                    }
                                }
                            }
                        }

                        _OfferingModel.ListOfOfferings = listOfProductOffering;
                        _OfferingModel.Status = "Success";
                        _OfferingModel.Count = listOfProductOffering.Count.ToString();
                    }
                }
                else
                {
                    _OfferingModel.Status = "TCRM PSB : Input Mode in NULL";
                    _OfferingModel.Status = "Failure";
                    _OfferingModel.Count = "0";
                }

                OfferingModelOutPut.Set(context, _OfferingModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}