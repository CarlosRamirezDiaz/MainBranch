using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Repository;
using AmxCoPSBActivities.Model;

namespace AmxCodPSBActivities.Repository.Factory
{
    public class AmxCoProductSpecificationFactory
    {
        internal static Entity CreateEntityFrom(OrganizationServiceProxy org, AmxCoProductSpecificationModel productSpec)
        {
            Entity entity = new Entity("etel_productspecification");

            entity.Id = productSpec.etel_productspecificationid;
            entity.Attributes.Add("etel_name", productSpec.etel_name);
            entity.Attributes.Add("etel_externalid", productSpec.etel_externalid);
            entity.Attributes.Add("etel_specificationtypecode", productSpec.etel_specificationtypecode);
            entity.Attributes.Add("etel_servicetypecode", productSpec.etel_specificationtypecode);

            return entity;
        }

        internal static AmxCoProductSpecificationModel CreateProductSpecificationFrom(Entity entity)
        {
            var productSpec = new AmxCoProductSpecificationModel();

            productSpec.etel_productspecificationid = entity.Id;
            
            if (entity.Contains("etel_name"))
                productSpec.etel_name = entity.Attributes["etel_name"].ToString();
            if (entity.Contains("etel_externalid"))
                productSpec.etel_externalid = entity.Attributes["etel_externalid"].ToString();
            if (entity.Contains("etel_specificationtypecode"))
                productSpec.etel_specificationtypecode = (OptionSetValue) entity.Attributes["etel_specificationtypecode"];
            if (entity.Contains("etel_servicetypecode"))
                productSpec.etel_servicetypecode = (OptionSetValue) entity.Attributes["etel_servicetypecode"];
            
            return productSpec;
        }

        internal static AmxCoProductSpecificationModelFull CreateProductSpecificationFullFrom(OrganizationServiceProxy org, Entity entity)
        {
            var productSpec = new AmxCoProductSpecificationModelFull();

            productSpec.etel_productspecificationid = entity.Id;

            if (entity.Contains("etel_name"))
                productSpec.etel_name = entity.Attributes["etel_name"].ToString();
            if (entity.Contains("etel_externalid"))
                productSpec.etel_externalid = entity.Attributes["etel_externalid"].ToString();
            if (entity.Contains("etel_specificationtypecode"))
                productSpec.etel_specificationtypecode = (OptionSetValue)entity.Attributes["etel_specificationtypecode"];
            if (entity.Contains("etel_servicetypecode"))
                productSpec.etel_servicetypecode = (OptionSetValue)entity.Attributes["etel_servicetypecode"];

            // Build Product resource specification list
            productSpec.ProductResourceSpecList = (new AmxCoProductResourceSpecificationRepository(org)).GetListProductResourceSpecificationFull(productSpec.etel_productspecificationid);
            
            return productSpec;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] { "etel_productspecificationid"
                                                    ,"etel_name"
                                                    ,"etel_externalid"
                                                    ,"etel_specificationtypecode"
                                                    ,"etel_servicetypecode"});
            }
        }
    }
}
