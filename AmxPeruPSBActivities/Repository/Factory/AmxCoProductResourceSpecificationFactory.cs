using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using AmxCoPSBActivities.Model;
using AmxPeruPSBActivities.Repository;

namespace AmxCoPSBActivities.Repository.Factory
{
    class AmxCoProductResourceSpecificationFactory
    {
        internal static Entity CreateEntityFrom(OrganizationServiceProxy org, etel_productresourcespecification productResourceSpecification)
        {
            Entity entity = new Entity("etel_productresourcespecification");

            entity.Id = productResourceSpecification.Id;
            entity.Attributes.Add("etel_name", productResourceSpecification.etel_name);
            

            return entity;
        }

        internal static etel_productresourcespecification CreateProductResourceSpecificationFrom(Entity entity)
        {
            var productResourceSpecification = new etel_productresourcespecification();

            productResourceSpecification.etel_productresourcespecificationId = entity.Id;

            if (entity.Contains("etel_name"))
                productResourceSpecification.etel_name = entity.Attributes["etel_name"].ToString();


            return productResourceSpecification;
        }

        internal static AmxCoProducResourceSpecificationModelFull CreateProductResourceSpecificationFullFrom(OrganizationServiceProxy org, Entity entity)
        {
            var productResourceSpecification = new AmxCoProducResourceSpecificationModelFull();

            productResourceSpecification.etel_productresourcespecificationid = entity.Id;

            if (entity.Contains("etel_name"))
                productResourceSpecification.etel_name = entity.Attributes["etel_name"].ToString();

            if (entity.Contains("etel_externalid"))
                productResourceSpecification.etel_externalid = entity.Attributes["etel_externalid"].ToString();

            if (entity.Contains("amxperu_resourcetypecode"))
                productResourceSpecification.amxperu_resourcetypecode = (OptionSetValue)entity.Attributes["amxperu_resourcetypecode"];

            if (entity.Contains("amxperu_specificationsubtypecode"))
                productResourceSpecification.amxperu_specificationsubtypecode = (OptionSetValue) entity.Attributes["amxperu_specificationsubtypecode"];

            // Get resource characteristcs
            AmxCoResourceCharValueRepository resourceCharValueRepository = new AmxCoResourceCharValueRepository(org);
            productResourceSpecification.ResourceCharValueList = resourceCharValueRepository.GetListResourceCharacteristicValue(productResourceSpecification.etel_productresourcespecificationid);

            return productResourceSpecification;
        }        

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] { "etel_productresourcespecificationid"
                                                    ,"etel_name"});
            }
        }
    }
}
