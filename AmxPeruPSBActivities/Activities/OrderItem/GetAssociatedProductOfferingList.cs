using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using Microsoft.Xrm.Sdk;
using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk.Query;

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class GetAssociatedProductOfferingList : XrmAwareCodeActivity
    {
        public OutArgument<List<ProductOffering>> ProductOfferingAddonList { get; set; }
        public OutArgument<List<ProductOffering>> ProductOfferingDeviceList { get; set; }

        public InArgument<string> ParentOfferingId { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var parentOfferingId = ParentOfferingId.Get(context);
            var modelOfferingList = new List<ProductOffering>();
            var modelDeviceList = new List<ProductOffering>();

            string Entityofferingassociation = "etel_offeringassociation";
            var resultofferingassociation = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = Entityofferingassociation,
                ColumnSet = new ColumnSet(true),
            });

            var associatedproductOfferingIds = resultofferingassociation.Entities
                .Where(a => ((EntityReference)(a.Attributes["etel_primaryofferingid"])).Id == Guid.Parse(parentOfferingId) )
                .Select(a => ((EntityReference)(a.Attributes["etel_secondaryofferingid"])).Id).Distinct();

            string entityOffering = "product";
            var resultEntityOffering = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = entityOffering,
                ColumnSet = new ColumnSet(true),
            });

            // var configurations = resultEntityOffering.Entities.Where(a => associatedproductOfferingIds.Contains(((EntityReference)(a.Attributes["amxperu_productoffering"])).Id));
            var offertypecode = "amxperu_offertypecode";
            var offerings = resultEntityOffering.Entities.Where(a => associatedproductOfferingIds.Contains(a.Id));
            var fieldEtelOfferTypeCode = "etel_offertypecode";
            int optionSetDevice = 831260007;

            foreach (var item in offerings)
            {
                var model = new ProductOffering();
                model.ProductOfferingId = item.Id.ToString();
                model.ParentOfferingId = parentOfferingId;
                model.OfferingName = Convert.ToString(item.Attributes["name"]);
                model.OfferTypeCode = ((OptionSetValue)(item.Attributes[offertypecode])).Value;
                
                if (((OptionSetValue)(item.Attributes[fieldEtelOfferTypeCode])).Value == optionSetDevice)
                {
                    modelDeviceList.Add(model);
                }
                else
                {
                    modelOfferingList.Add(model);
                }
            }

            ProductOfferingAddonList.Set(context, modelOfferingList);
            ProductOfferingDeviceList.Set(context, modelDeviceList);

        }
    }
}
