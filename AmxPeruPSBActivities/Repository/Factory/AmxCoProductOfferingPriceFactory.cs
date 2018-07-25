using AmxCoPSBActivities.Model.ProductOfferingPrice;
using Ericsson.ETELCRM.CrmFoundationLibrary.ServiceClient.Entities;
using Ericsson.ETELCRM.Entities.Crm.CustomEntities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.Repository.Factory
{
    internal static class AmxCoProductOfferingPriceFactory
    {
        internal static Entity CreateEntityFrom(AmxCoProductOfferingPriceModel productOfferingPrice)
        {
            Entity entity = new Entity("amxperu_productofferingprice");

            entity.Id = productOfferingPrice.amxperu_productofferingpriceid;
            entity.Attributes.Add("amxperu_externalid", productOfferingPrice.amxperu_externalid);
            entity.Attributes.Add("amxperu_name", productOfferingPrice.amxperu_name);
            entity.Attributes.Add("amxperu_periodcode", productOfferingPrice.amxperu_periodcode);
            entity.Attributes.Add("amxperu_price", productOfferingPrice.amxperu_price);
            entity.Attributes.Add("amxperu_price_base", productOfferingPrice.amxperu_price_base);
            entity.Attributes.Add("amxperu_pricetypecode", productOfferingPrice.amxperu_pricetypecode);
            entity.Attributes.Add("amxperu_productofferingid", new EntityReference("amxperu_productofferingid", productOfferingPrice.amxperu_productofferingid));
            entity.Attributes.Add("transactioncurrencyid", new EntityReference("transactioncurrencyid", productOfferingPrice.transactioncurrencyid));

            return entity;
        }

        internal static AmxCoProductOfferingPriceModel CreateProductOfferingPriceFrom(Entity entity)
        {
            var productOfferingPrice = new AmxCoProductOfferingPriceModel();

            productOfferingPrice.amxperu_productofferingpriceid = entity.Id;

            if (entity.Contains("amxperu_externalid"))
                productOfferingPrice.amxperu_externalid = (String)entity.Attributes["amxperu_externalid"];
            if (entity.Contains("amxperu_name"))
                productOfferingPrice.amxperu_name = (String)entity.Attributes["amxperu_name"];
            if (entity.Contains("amxperu_periodcode"))
                productOfferingPrice.amxperu_periodcode = (OptionSetValue)entity.Attributes["amxperu_periodcode"];
            if (entity.Contains("amxperu_price"))
                productOfferingPrice.amxperu_price = (Microsoft.Xrm.Sdk.Money)entity.Attributes["amxperu_price"];
            if (entity.Contains("amxperu_price_base"))
                productOfferingPrice.amxperu_price_base = (Microsoft.Xrm.Sdk.Money)entity.Attributes["amxperu_price_base"];
            if (entity.Contains("amxperu_pricetypecode"))
                productOfferingPrice.amxperu_pricetypecode = (OptionSetValue)entity.Attributes["amxperu_pricetypecode"];
            if (entity.Contains("amxperu_productofferingid"))
                productOfferingPrice.amxperu_productofferingid = ((EntityReference)entity.Attributes["amxperu_productofferingid"]).Id;
            if (entity.Contains("transactioncurrencyid"))
                productOfferingPrice.amxperu_productofferingid = ((EntityReference)entity.Attributes["transactioncurrencyid"]).Id;

            return productOfferingPrice;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] { "amxperu_productofferingpriceid"
                                                    ,"amxperu_externalid"
                                                    ,"amxperu_name"
                                                    ,"amxperu_periodcode"
                                                    ,"amxperu_price"
                                                    ,"amxperu_price_base"
                                                    ,"amxperu_pricetypecode"
                                                    ,"amxperu_productofferingid"
                                                    ,"transactioncurrencyid"});
            }
        }
    }
}
