using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model;
using Microsoft.Xrm.Sdk.Query;

namespace AmxPeruPSBActivities.Repository.Factory
{
    internal static class AmxCoOrderResourceCharFactory
    {
        internal static Entity CreateEntityFrom(OrganizationServiceProxy org, AmxCoOrderResourceCharModel orderResourcechar)
        {
            Entity entity = new Entity("etel_orderresourcecharacteric");

            entity.Id = orderResourcechar.etel_orderresourcecharactericid;
            entity.Attributes.Add("etel_orderresourceid", orderResourcechar.etel_orderresourceid);
            entity.Attributes.Add("amx_resource_characteristic", orderResourcechar.amx_resource_characteristic);
            entity.Attributes.Add("amx_resource_characteristicvalue", orderResourcechar.amx_resource_characteristicvalue);
            entity.Attributes.Add("etel_selectedvalue", orderResourcechar.etel_selectedvalue);
            entity.Attributes.Add("etel_datatypecode", orderResourcechar.etel_datatypecode);
            entity.Attributes.Add("etel_value", orderResourcechar.etel_value);

            return entity;
        }

        internal static AmxCoOrderResourceCharModel CreateOrderResourceCharFrom(Entity entity)
        {
            var orderResourceChar = new AmxCoOrderResourceCharModel();

            orderResourceChar.etel_orderresourcecharactericid = entity.Id;

            if (entity.Contains("etel_orderresourceid"))
                orderResourceChar.etel_orderresourceid = (EntityReference)entity.Attributes["etel_orderresourceid"];
            if (entity.Contains("amx_resource_characteristic"))
                orderResourceChar.amx_resource_characteristic = (EntityReference)entity.Attributes["amx_resource_characteristic"];
            if (entity.Contains("amx_resource_characteristicvalue"))
                orderResourceChar.amx_resource_characteristicvalue = (EntityReference)entity.Attributes["amx_resource_characteristicvalue"];
            if (entity.Contains("etel_selectedvalue"))
                orderResourceChar.etel_selectedvalue = entity.Attributes["etel_selectedvalue"].ToString();
            if (entity.Contains("etel_datatypecode"))
                orderResourceChar.etel_datatypecode = (OptionSetValue)entity.Attributes["etel_datatypecode"];
            if (entity.Contains("etel_value"))
                orderResourceChar.etel_value = entity.Attributes["etel_value"].ToString();

            return orderResourceChar;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] { "etel_orderresourcecharactericid"
                    ,"etel_orderresourceid"
                    ,"amx_resource_characteristic"
                    ,"amx_resource_characteristicvalue"
                    ,"etel_selectedvalue"
                    ,"etel_datatypecode"
                });
            }
        }
    }
}
