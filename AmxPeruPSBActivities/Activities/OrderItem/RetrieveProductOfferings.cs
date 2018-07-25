using System.Activities;
using System.Collections.Generic;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System.Linq;
using AmxPeruPSBActivities.Model;
using System;

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class RetrieveProductOfferings : XrmAwareCodeActivity
    {
        public InArgument<List<FamilyModel>> FamilyModel { get; set; }
        public OutArgument<List<ProductOfferingCatalogModel>> ProductOfferingCatalogs { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var familyModel = FamilyModel.Get(context).ToList();
            var productOfferingCatalogs = new List<ProductOfferingCatalogModel>();

            var products = dataContext.ProductSet.Join(dataContext.etel_offeringcatalogue_productSet,
                                                        prod => prod.Id,
                                                        ocp => ocp.productid,
                                                        (prod, ocp) => new { ProductSet = prod, etel_offeringcatalogue_productSet = ocp })
                                                 .ToList();

            foreach (var product in products)
            {
                var result = familyModel.Select(f => f.Id).Contains(product.etel_offeringcatalogue_productSet.etel_offeringcatalogueid.ToString(), StringComparer.OrdinalIgnoreCase);
                if (result)
                {
                    productOfferingCatalogs.Add(new ProductOfferingCatalogModel()
                    {
                        Id = product.ProductSet.Id.ToString(),
                        Name = product.ProductSet.Name
                    });
                }
            }

            ProductOfferingCatalogs.Set(context, productOfferingCatalogs);
        }
    }
}
