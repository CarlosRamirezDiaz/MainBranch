using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Model.OrderCapture;

namespace AmxPeruPSBActivities.Repository.Factory
{
    internal static class OfferingFactory
    {
        // Product characteristic etel_productcharacteristic
        internal static Entity CreateProductCharacteristicEntityFrom(OrganizationServiceProxy org, ProductCharacteristicModel productCharacteristic)
        {
            Entity entity = new Entity("etel_productcharacteristic");

            entity.Id = productCharacteristic.etel_productcharacteristicid;
            entity.Attributes.Add("etel_externalid", productCharacteristic.etel_externalid);

            return entity;
        }

        internal static ProductCharacteristicModel CreateProductCharacteristicFrom(Entity entity)
        {
            var productCharacteristic = new ProductCharacteristicModel();

            productCharacteristic.etel_productcharacteristicid = entity.Id;

            if (entity.Contains("etel_externalid"))
                productCharacteristic.etel_externalid = entity.Attributes["etel_externalid"].ToString();

            return productCharacteristic;
        }

        internal static ColumnSet ProudctCharacteristicFields
        {
            get
            {
                return new ColumnSet(new string[] { "etel_productcharacteristicid"
                    ,"etel_externalid"
                });
            }
        }


        // Product Characteristic Use etel_productcharacteristicuse
        internal static Entity CreateProductCharUseEntityFrom(OrganizationServiceProxy org, ProductCharacteristicUseModel productCharUse)
        {
            Entity entity = new Entity("etel_productcharacteristicuseid");

            entity.Id = productCharUse.etel_productcharacteristicuseid;
            entity.Attributes.Add("etel_name", productCharUse.etel_name);
            entity.Attributes.Add("etel_productcharacteristicid", productCharUse.etel_productcharacteristicid);

            return entity;
        }

        internal static ProductCharacteristicUseModel CreateProductCharUseFrom(Entity entity)
        {
            var productCharUse = new ProductCharacteristicUseModel();

            productCharUse.etel_productcharacteristicuseid = entity.Id;

            if (entity.Contains("etel_name"))
                productCharUse.etel_name = entity.Attributes["etel_name"].ToString();

            if (entity.Contains("etel_productcharacteristicid"))
                productCharUse.etel_productcharacteristicid = (EntityReference)entity.Attributes["etel_productcharacteristicid"];

            return productCharUse;
        }

        internal static ColumnSet ProductCharUseFields
        {
            get
            {
                return new ColumnSet(new string[] { "etel_productcharacteristicuseid"
                    ,"etel_name"
                    ,"etel_productcharacteristicid"
                });
            }
        }

        // Product Characteristic Value etel_productcharacteristicvalue
        internal static Entity CreateProductCharValueEntityFrom(OrganizationServiceProxy org, ProductCharacteristicValueModel productCharValue)
        {
            Entity entity = new Entity("etel_productcharacteristicvalue");

            entity.Id = productCharValue.etel_productcharacteristicvalueid;
            entity.Attributes.Add("etel_name", productCharValue.etel_name);
            entity.Attributes.Add("etel_productcharacteristicid", productCharValue.etel_productcharacteristicid);

            return entity;
        }

        internal static ProductCharacteristicValueModel CreateProductCharValueFrom(Entity entity)
        {
            var productCharValue = new ProductCharacteristicValueModel();

            productCharValue.etel_productcharacteristicvalueid = entity.Id;

            if (entity.Contains("etel_name"))
                productCharValue.etel_name = entity.Attributes["etel_name"].ToString();

            if (entity.Contains("etel_productcharacteristicid"))
                productCharValue.etel_productcharacteristicid = (EntityReference)entity.Attributes["etel_productcharacteristicid"];

            return productCharValue;
        }

        internal static ColumnSet ProductCharValueFields
        {
            get
            {
                return new ColumnSet(new string[] { "etel_productcharacteristicvalueid"
                    ,"etel_name"
                    ,"etel_productcharacteristicid"
                });
            }
        }

        // Product Characteristic Value Use etel_productcharacteristicvalueuse
        internal static Entity CreateProductCharValueUseEntityFrom(OrganizationServiceProxy org, ProductCharacteristicValueUseModel productCharValueUse)
        {
            Entity entity = new Entity("etel_productcharacteristicvalueuse");

            entity.Id = productCharValueUse.etel_productcharacteristicvalueuseid;
            entity.Attributes.Add("etel_name", productCharValueUse.etel_name);
            entity.Attributes.Add("etel_productcharacteristicuseid", productCharValueUse.etel_productcharacteristicuseid);

            return entity;
        }

        internal static ProductCharacteristicValueUseModel CreateProductCharValueUseFrom(Entity entity)
        {
            var productCharValue = new ProductCharacteristicValueUseModel();

            productCharValue.etel_productcharacteristicvalueuseid = entity.Id;

            if (entity.Contains("etel_name"))
                productCharValue.etel_name = entity.Attributes["etel_name"].ToString();

            if (entity.Contains("etel_productcharacteristicuseid"))
                productCharValue.etel_productcharacteristicuseid = (EntityReference)entity.Attributes["etel_productcharacteristicuseid"];

            return productCharValue;
        }

        internal static ColumnSet ProductCharValueUseFields
        {
            get
            {
                return new ColumnSet(new string[] { "etel_productcharacteristicvalueuseid"
                    ,"etel_name"
                    ,"etel_productcharacteristicuseid"
                });
            }
        }

        // Product Offering Char Use amxperu_productofferingcharuse
        internal static Entity CreateOfferingCharUseEntityFrom(OrganizationServiceProxy org, ProductOfferingCharUseModel productOfferCharUse)
        {
            Entity entity = new Entity("amxperu_productofferingcharuse");

            entity.Id = productOfferCharUse.amxperu_productofferingcharuseid;
            entity.Attributes.Add("amxperu_name", productOfferCharUse.amxperu_name);
            entity.Attributes.Add("amxperu_productoffering", productOfferCharUse.amxperu_productoffering);

            return entity;
        }

        internal static ProductOfferingCharUseModel CreateOfferingCharUseFrom(Entity entity)
        {
            var productOfferingCharUseValue = new ProductOfferingCharUseModel();

            productOfferingCharUseValue.amxperu_productofferingcharuseid = entity.Id;

            if (entity.Contains("amxperu_name"))
                productOfferingCharUseValue.amxperu_name = entity.Attributes["amxperu_name"].ToString();

            if (entity.Contains("amxperu_productoffering"))
                productOfferingCharUseValue.amxperu_productoffering = (EntityReference)entity.Attributes["amxperu_productoffering"];

            return productOfferingCharUseValue;
        }

        internal static ColumnSet ProudctOfferingCharUseFields
        {
            get
            {
                return new ColumnSet(new string[] { "amxperu_productofferingcharuseid"
                    ,"amxperu_name"
                    ,"amxperu_productoffering"
                });
            }
        }

        // Product Offering Char Value Use amxperu_productofferingcharvalueuse
        internal static Entity CreateOfferingCharValueUseEntityFrom(OrganizationServiceProxy org, ProductOfferingCharValueUseModel productOfferCharValueUse)
        {
            Entity entity = new Entity("amxperu_productofferingcharvalueuse");

            entity.Id = productOfferCharValueUse.amxperu_productofferingcharvalueuseid;
            entity.Attributes.Add("amxperu_name", productOfferCharValueUse.amxperu_name);
            entity.Attributes.Add("amxperu_productofferingcharuse", productOfferCharValueUse.amxperu_productofferingcharuse);
            entity.Attributes.Add("amxperu_value", productOfferCharValueUse.amxperu_value);

            return entity;
        }

        internal static ProductOfferingCharValueUseModel CreateOfferingCharValueUseFrom(Entity entity)
        {
            var productOfferingCharValueUse = new ProductOfferingCharValueUseModel();

            productOfferingCharValueUse.amxperu_productofferingcharvalueuseid = entity.Id;

            if (entity.Contains("amxperu_name"))
                productOfferingCharValueUse.amxperu_name = entity.Attributes["amxperu_name"].ToString();

            if (entity.Contains("amxperu_productofferingcharuse"))
                productOfferingCharValueUse.amxperu_productofferingcharuse = (EntityReference)entity.Attributes["amxperu_productofferingcharuse"];

            if (entity.Contains("amxperu_value"))
                productOfferingCharValueUse.amxperu_value = (EntityReference)entity.Attributes["amxperu_value"];

            return productOfferingCharValueUse;
        }

        internal static ColumnSet ProudctOfferingCharValueUseFields
        {
            get
            {
                return new ColumnSet(new string[] { "amxperu_productofferingcharvalueuseid"
                    ,"amxperu_name"
                    ,"amxperu_productofferingcharuse"
                    ,"amxperu_value"
                });
            }
        }
    }
}
