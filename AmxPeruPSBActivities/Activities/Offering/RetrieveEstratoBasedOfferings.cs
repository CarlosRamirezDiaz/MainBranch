using ExternalApiActivities.Common;
using System;
using Microsoft.Xrm.Sdk;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using System.Collections.Generic;
using System.Linq;

namespace AmxPeruPSBActivities.Activities.Offering
{
    public class RetrieveEstratoBasedOfferings : XrmAwareCodeActivity
    {
        public InArgument<List<Guid>> EstratoPopConfigIds { get; set; }
        public InArgument<List<Guid>> AllEstratoPopConfigIds { get; set; }
        public InArgument<List<Entity>> PopConfigCharValueList { get; set; }
        public InOutArgument<List<Entity>> ConfigOfferingPopList { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var estratoPopConfigIds = EstratoPopConfigIds.Get(context);
            var allEstratoPopConfigIds = AllEstratoPopConfigIds.Get(context);
            var configOfferingPopList = ConfigOfferingPopList.Get(context);

            #region Get selected estrato offerings
            //Get products by selected estrato.
            var offeringList = configOfferingPopList?.Where(p => estratoPopConfigIds.Contains((Guid)p.Attributes["amxperu_productofferingpriceconfigurationid"]) &&
                                                                 estratoPopConfigIds.Contains(((EntityReference)p.GetAttributeValue<AliasedValue>("amxperu_productofferingprice.amxperu_popconfiguration")?.Value).Id))?
                                                              .ToList();
            #endregion

            #region Get offerings which have estrato value "All"
            //Get product id list.
            var offeringIds = offeringList?.Select(p => p.GetAttributeValue<AliasedValue>("product.productid")?.Value?.ToString())
                                           .Distinct()
                                           .ToList();
            //Get offerings which have estrato value "All".
            var allEstratoBasedOfferings = configOfferingPopList?.Where(p => allEstratoPopConfigIds.Contains((Guid)p.Attributes["amxperu_productofferingpriceconfigurationid"]) &&
                                                                             allEstratoPopConfigIds.Contains(((EntityReference)p.GetAttributeValue<AliasedValue>("amxperu_productofferingprice.amxperu_popconfiguration")?.Value).Id))?
                                                                 .ToList();
            //Remove offerings which are already in product list.
            allEstratoBasedOfferings = allEstratoBasedOfferings.Where(p => !offeringIds.Contains(p.GetAttributeValue<AliasedValue>("product.productid")?.Value))?
                                                               .ToList();
            //Add non-existing offerings to the product list.
            offeringList.AddRange(allEstratoBasedOfferings);
            #endregion

            #region Get offerings with default values
            //Get pop config ids from characteristic value-pop config relation table.
            var popConfigCharValueList = PopConfigCharValueList.Get(context).Select(p => (Guid)p.Attributes["amxperu_productofferingpriceconfigurationid"])
                                                                            .Distinct()
                                                                            .ToList();
            //Get product id list.
            offeringIds = offeringList?.Select(p => p.GetAttributeValue<AliasedValue>("product.productid")?.Value?.ToString())
                                                                .Distinct()
                                                                .ToList();
            //Get offerings which are not in characteristic value-pop config relation table.
            var offeringsWithDefaultPrice = configOfferingPopList.Where(n => !popConfigCharValueList.Contains((Guid)n.Attributes["amxperu_productofferingpriceconfigurationid"])).ToList();
            //Remove offerings which are already in product list.
            offeringsWithDefaultPrice = offeringsWithDefaultPrice.Where(p => !offeringIds.Contains(p.GetAttributeValue<AliasedValue>("product.productid")?.Value))?
                                                                 .ToList();
            //Add non-existing offerings to the product list.
            offeringList.AddRange(offeringsWithDefaultPrice);

            #endregion

            ConfigOfferingPopList.Set(context, offeringList);
        }
    }
}
