using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm.CustomEntities;
using Ericsson.ETELCRM.Entities.Crm;
using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Repository;

namespace AmxCoPSBActivities.Repository.Factory
{
    class AmxCoProductOfferingFactory
    {
        internal static Entity CreateEntityFrom(OrganizationServiceProxy org, ProductOffering productOffering)
        {
            Entity entity = new Entity("etel_ordercapture");

            entity.Id = new Guid(productOffering.ProductOfferingId);
            entity.Attributes.Add("etel_productspecificationid", new EntityReference("product", productOffering.ProductSpecification));
            entity.Attributes.Add("name", productOffering.OfferingName);
            entity.Attributes.Add("etel_parentofferingid", productOffering.ParentOfferingId);
            entity.Attributes.Add("parentproductid", productOffering.ParentProductId);

            return entity;
        }

        internal static ProductOffering CreateProductOfferingFrom(Entity entity)
        {
            var productOffering = new ProductOffering();

            productOffering.ProductOfferingId = entity.Id.ToString();

            if (entity.Contains("name"))
                productOffering.OfferingName = entity.Attributes["name"].ToString();

            if (entity.Contains("etel_productspecificationid"))
                productOffering.ProductSpecification = ((EntityReference)entity.Attributes["etel_productspecificationid"]).Id;

            if (entity.Contains("etel_parentofferingid"))
                productOffering.ParentOfferingId = entity.Attributes["etel_parentofferingid"].ToString();

            if (entity.Contains("parentproductid"))
                productOffering.ParentProductId = entity.Attributes["parentproductid"].ToString();

            return productOffering;
        }

        internal static ProductOfferingFull CreateProductOfferingFullFrom(OrganizationServiceProxy org, Entity entity)
        {
            var productOffering = new ProductOfferingFull();

            productOffering.ProductOfferingId = entity.Id.ToString();

            if (entity.Contains("name"))
                productOffering.OfferingName = entity.Attributes["name"].ToString();
            
            if (entity.Contains("etel_parentofferingid"))
                productOffering.ParentOfferingId = entity.Attributes["etel_parentofferingid"].ToString();

            if (entity.Contains("parentproductid"))
                productOffering.ParentProductId = entity.Attributes["parentproductid"].ToString();

            if (entity.Contains("etel_productspecificationid"))
                productOffering.ProductSpecificationId = ((EntityReference)entity.Attributes["etel_productspecificationid"]).Id;

            AmxCoProductSpecificationRepository productSpecRepository = new AmxCoProductSpecificationRepository(org);
            productOffering.ProductSpecification = productSpecRepository.GetProductSpecificationFull(productOffering.ProductSpecificationId);

            return productOffering;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] { "productid"
                                                    ,"name"
                                                    ,"etel_productspecificationid"
                                                    ,"etel_parentofferingid"
                                                    ,"parentproductid"});
            }
        }
    }
}
