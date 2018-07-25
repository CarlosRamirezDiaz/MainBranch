using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using ExternalApiActivities.Helpers;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Business
{
    class EligibilityBusiness
    {
        //todo: assing it.
        XrmDataContext _xrmDataContext;
        XrmDataContextProvider _xrmDataContextProvider { get; set; }

        private static readonly string[] QueryColumns =
            {
                "productid", "name", "description", "productnumber",
                "etel_bundle", "etel_creatingcontract", "etel_offertypecode",
                "etel_promotioncategorycode", "transactioncurrencyid", "etel_rateplanid", "etel_externalid"
            };

        /// <summary>
        /// Applies the eligibility rule.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>List of Products</returns>
        public List<Product> ExecuteApplyEligibilityRule(EligibilityViewModel model)
        {
            var ruleHandler = new EligibilityHandler();
            var queryContext = new OfferingQueryContext(new ColumnSet(QueryColumns)) { Query = { Distinct = true } };
            queryContext = GetRatePlanId(queryContext, model);

            if (queryContext == null)
            {
                return null;
            }
            
            queryContext = this.GetMarketSegments(queryContext, model);
            queryContext = this.GetCustomerGroups(queryContext, model);
            queryContext = this.GetSalesChannels(queryContext, model);
            queryContext = this.GetCatalogues(queryContext, model);
            queryContext = this.IsContractCreated(queryContext);
            return ruleHandler.HandleEligibilityRules(_xrmDataContextProvider.OrganizationService, queryContext);
        }

        /// <summary>
        /// Gets the rate plan identifier.
        /// </summary>
        /// <param name="queryContext">The query context.</param>
        /// <param name="model">The model.</param>
        /// <returns>Offering Query Context</returns>
        private OfferingQueryContext GetRatePlanId(OfferingQueryContext queryContext, EligibilityViewModel model)
        {
            Guid? ratePlanId = null;

            bool isAvailableToAddRule = false;

            var orderId = model.OrderId;
            var orderEntity = model.OrderEntity;

            // business 
            var ratePlanBusiness = new RatePlanBusiness();
            var orderCaptureBusiness = new OrderCaptureBusiness();
            var orderItemBusiness = new OrderItemBusiness();

            if (model.CreatingContractProductId.HasValue)
            {
                //// add rate plan to filtering rule
                var ratePlan = ratePlanBusiness.GetRatePlanByOfferingId(model.CreatingContractProductId.Value);
                ratePlanId = ratePlan.Id;
                isAvailableToAddRule = true;
            }

            if (orderId != null || orderEntity != null)
            {
                if (orderEntity == null)
                {
                    //// get order entity
                    orderEntity = (etel_ordercapture)orderCaptureBusiness.RetrieveById(orderId.Value);
                }

                if (orderId == null)
                {
                    orderId = orderEntity.Id;
                }

                //// order type code check
                if (orderEntity != null && orderEntity.etel_ordertypecode.Value != (int)etel_ordertypecode.RatePlanChange && orderEntity.etel_subscriptionid != null)
                {
                    //// add rate plan to filtering rule
                    var ratePlan = ratePlanBusiness.GetRatePlanByContractId(orderEntity.etel_subscriptionid.Id).FirstOrDefault();
                    if (ratePlan != null)
                    {
                        ratePlanId = ratePlan.etel_rateplanId;
                        isAvailableToAddRule = true;
                    }
                }
                else if (orderEntity != null && orderEntity.etel_ordertypecode.Value == (int)etel_ordertypecode.RatePlanChange && orderEntity.etel_newofferid != null)
                {
                    //// add rate plan to filtering rule
                    var ratePlan = ratePlanBusiness.GetRatePlanByOfferingId(orderEntity.etel_newofferid.Id);
                    ratePlanId = ratePlan.Id;
                    isAvailableToAddRule = true;
                }
                else
                {
                    //// get order items from basket
                    var orderItems = orderItemBusiness.RetrieveOrderItems(orderId.Value);
                    if (orderItems.Any())
                    {
                        //// select subscription offering from basket items
                        var orderItem =
                            orderItems.FirstOrDefault(
                                etelOrderitem =>
                                etelOrderitem.etel_orderitemtypecode.Value == (int)etel_orderitemtypecode.Subscription);

                        if (orderItem != null)
                        {
                            //// add rate plan to filtering rule
                            var ratePlan = ratePlanBusiness.GetRatePlanByOfferingId(orderItem.etel_offeringid.Id);
                            ratePlanId = ratePlan.Id;
                            isAvailableToAddRule = true;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            queryContext.RatePlanId = ratePlanId;
            if (isAvailableToAddRule)
            {
                queryContext.Rules.Add(new FilteringRatePlanRule());
            }

            return queryContext;
        }

        /// <summary>
        /// Gets the market segments.
        /// </summary>
        /// <param name="queryContext">The query context.</param>
        /// <param name="model">The model.</param>
        /// <returns>Offering Query Context</returns>
        private OfferingQueryContext GetMarketSegments(OfferingQueryContext queryContext, EligibilityViewModel model)
        {
            if (model.CustomerId.HasValue)
            {
                var customerBusiness = new CustomerBusiness();
                var marketSegment = customerBusiness.GetMarketSegmentsId(model.CustomerType.Value, model.CustomerId.Value);

                if (marketSegment != null)
                {
                    var marketSegments = new List<Guid> { marketSegment.Id };

                    queryContext.MarketSegments = marketSegments;
                    queryContext.Rules.Add(new FilteringMarketSegmentRule());
                }
            }

            return queryContext;
        }

        /// <summary>
        /// Gets the customer groups.
        /// </summary>
        /// <param name="queryContext">The query context.</param>
        /// <param name="model">The model.</param>
        /// <returns>Offering Query Context</returns>
        private OfferingQueryContext GetCustomerGroups(OfferingQueryContext queryContext, EligibilityViewModel model)
        {
            var business = new CustomerGroupBusiness();

            var guid = model.CustomerId;
            var customerType = model.CustomerType;

            if (guid != null && customerType != null)
            {
                List<etel_customergroup> groups = business.GetCustomerGroups(guid.Value, customerType.Value);

                if (groups != null)
                {
                    queryContext.CustomerGroups = groups.Select(g => g.etel_customergroupId ?? new Guid()).ToList();
                    queryContext.Rules.Add(new FilteringCustomerGroupRule());
                }
            }

            return queryContext;
        }

        /// <summary>
        /// Gets the sales channels.
        /// </summary>
        /// <param name="queryContext">The query context.</param>
        /// <param name="model">The model.</param>
        /// <returns>Offering Query Context</returns>
        private OfferingQueryContext GetSalesChannels(OfferingQueryContext queryContext, EligibilityViewModel model)
        {
            if (!model.UserId.HasValue)
            {
                return queryContext;
            }

            var salesChannelBusiness = new SalesChannelBusiness();

            var salesChannelId = salesChannelBusiness.RetrieveSalesChannelIdByUser(model.UserId.Value);
            if (salesChannelId != Guid.Empty)
            {
                queryContext.SalesChannels = new List<Guid> { salesChannelId };
                queryContext.Rules.Add(new FilteringSalesChannelRule());
            }

            return queryContext;
        }

        /// <summary>
        /// Gets the catalogues.
        /// </summary>
        /// <param name="queryContext">The query context.</param> 
        /// <param name="model">The model.</param>
        /// <returns>Offering Query Context</returns>
        private OfferingQueryContext GetCatalogues(OfferingQueryContext queryContext, EligibilityViewModel model)
        {
            if (!model.CatalogueId.HasValue)
            {
                return queryContext;
            }

            queryContext.Catalogues = new List<Guid> { model.CatalogueId.Value };
            queryContext.Rules.Add(new FilteringCatalogueRule());

            return queryContext;
        }

        /// <summary>
        /// Determines whether [is contract created] [the specified query context].
        /// </summary>
        /// <param name="queryContext">The query context.</param>
        /// <returns>Offering Query Context</returns>
        private OfferingQueryContext IsContractCreated(OfferingQueryContext queryContext)
        {
            queryContext.IsContractCreated = false;
            queryContext.Rules.Add(new FilteringContractCreatedRule());

            return queryContext;
        }
    }
}
