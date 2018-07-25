using System;
using System.Activities;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using ExternalApiActivities.Common;
using System.Collections.Generic;
using AmxPeruPSBActivities.Model.OrderCapture;
using System.Linq;
using AmxPeruCommonLibrary.OptionSets;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.Offering
{
    public class RetrieveOptionalOfferings : XrmAwareCodeActivity
    {
        public InArgument<string> ParentOfferingId { get; set; }
        public InArgument<List<Guid>> CharValues { get; set; }
        public InArgument<List<Entity>> OfferingList { get; set; }
        public InArgument<List<Entity>> PopConfigList { get; set; }
        public OutArgument<List<ProductOfferingItem>> OptionalOfferingList { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var charValues = CharValues.Get(context);
            var offeringList = OfferingList.Get(context);
            var popConfigList = PopConfigList.Get(context);

            if (charValues?.Count > 0 && popConfigList?.Count > 0)
            {
                var pricingBusiness = new PricingBusiness(ContextProvider);
                var optionalOfferingList = pricingBusiness.RetrieveOfferingsWithPrices(offeringList, popConfigList, charValues, ParentOfferingId.Get(context));
                OptionalOfferingList.Set(context, optionalOfferingList);
            }
        }
    }
}