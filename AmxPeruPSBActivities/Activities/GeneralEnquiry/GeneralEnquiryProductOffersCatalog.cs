using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Model.GeneralEnquiry;

namespace AmxPeruPSBActivities.Activities.GeneralEnquiry
{
    public class GeneralEnquiryProductOffersCatalog : XrmAwareCodeActivity
    {
        public InArgument<ProductCatalogSearchRequest> searchRequest { get; set; }
        public OutArgument<List<ProductOfferingCatalogModel>> ProductOfferingCatalogs { get; set; }
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var request = searchRequest.Get(context);

            if (request.LookForInputText == "Offer Name")
            {
                var productOfferingCatalogs = new List<ProductOfferingCatalogModel>();

                var products = dataContext.ProductSet.Join(dataContext.etel_offeringcatalogue_productSet,
                                                            prod => prod.Id,
                                                            ocp => ocp.productid,
                                                            (prod, ocp) => new { ProductSet = prod, etel_offeringcatalogue_productSet = ocp })
                                                     .ToList();



                foreach (var product in products)
                {
                    if (product.ProductSet.Name.Contains(request.OfferName))
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
}
