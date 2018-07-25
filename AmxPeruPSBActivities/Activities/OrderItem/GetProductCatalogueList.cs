using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using AmxPeruPSBActivities.Model;
using Ericsson.PSB.Workflow.Client.Core;
using AmxPeruCommonLibrary.Caching;
using ExternalApiActivities.Helpers;

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class GetProductCatalogueList : XrmAwareCodeActivity
    {
        public OutArgument<List<ProductCatalogueModel>> ProductCatalogueList { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {

            
            //ExternalApiActivities.Helpers.

            string EntityProductCatalogue = "etel_offeringcatalogue";
            var cachingExtension = context.GetExtension<CachingExtension>();

            var productCatalogues = cachingExtension.GetOrAdd("cache.etel_offeringcatalogue",
                () => {
                    var productCatalogueSet = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
                    {
                        EntityName = EntityProductCatalogue,
                        ColumnSet = new ColumnSet(true),
                    });
                    return productCatalogueSet;
                }
            );

            var resultProductCataloguesList = new List<ProductCatalogueModel>();
            foreach (var item in productCatalogues.Entities)
            {
                var resultProductCatalogues = new ProductCatalogueModel();
                resultProductCatalogues.CatalogueId = Convert.ToString(item.Id);
                resultProductCatalogues.CatalogueName = Convert.ToString(item.Attributes["etel_name"]);
                resultProductCatalogues.CatalogueType = Convert.ToString(((OptionSetValue)item.Attributes["amxperu_catalogtype"]).Value);
                if (item.Attributes.Contains("etel_parentofferingcatalogueid"))
                {
                    resultProductCatalogues.ParentCatalogueId = Convert.ToString(((EntityReference)item.Attributes["etel_parentofferingcatalogueid"]).Id);
                    resultProductCatalogues.ParentCatalogueName = Convert.ToString(((EntityReference)item.Attributes["etel_parentofferingcatalogueid"]).Name);
                }
                resultProductCataloguesList.Add(resultProductCatalogues);
            }
            ProductCatalogueList.Set(context, resultProductCataloguesList);
        }
    }
}
