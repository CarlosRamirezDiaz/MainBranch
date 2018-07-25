using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using AmxCoPSBActivities.AMXCOLOMBIA.Model;
using Microsoft.Xrm.Sdk.Query;

namespace AmxPeruPSBActivities.Repository.Factory
{
    internal static class AmxCoOrderResourceFactory
    {
        internal static Entity CreateEntityFrom(OrganizationServiceProxy org, AmxCoOrderResourceModel orderResource)
        {
            Entity entity = new Entity("etel_orderresource");

            entity.Id = orderResource.etel_orderresourceid;
            entity.Attributes.Add("etel_orderitemid", orderResource.etel_orderitemid);
            entity.Attributes.Add("etel_offeringid", orderResource.etel_offeringid);
            entity.Attributes.Add("etel_name", orderResource.etel_name);
            entity.Attributes.Add("etel_productresourcespecification", orderResource.etel_productresourcespecification);
            entity.Attributes.Add("etel_value", orderResource.etel_value);
            
            return entity;
        }

        internal static AmxCoOrderResourceModel CreateOrderResourceFrom(Entity entity)
        {
            var orderResource = new AmxCoOrderResourceModel();

            orderResource.etel_orderresourceid = entity.Id;

            if (entity.Contains("etel_orderitemid"))
                orderResource.etel_orderitemid = (EntityReference)entity.Attributes["etel_orderitemid"];
            if (entity.Contains("etel_offeringid"))
                orderResource.etel_offeringid = (EntityReference)entity.Attributes["etel_offeringid"];
            if (entity.Contains("etel_name"))
                orderResource.etel_name = entity.Attributes["etel_name"].ToString();
            if (entity.Contains("etel_productresourcespecification"))
                orderResource.etel_productresourcespecification = (EntityReference)entity.Attributes["etel_productresourcespecification"];
            if (entity.Contains("etel_value"))
                orderResource.etel_value = entity.Attributes["etel_value"].ToString();

            return orderResource;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] {
                    "etel_orderresourceid"
                    ,"etel_orderitemid"
                    ,"etel_offeringid"
                    ,"etel_name"
                    ,"etel_productresourcespecification"
                    ,"etel_value"});
            }
        }
    }
}
