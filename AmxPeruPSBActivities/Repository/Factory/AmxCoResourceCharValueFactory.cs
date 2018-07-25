using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk.Query;
using AmxCoPSBActivities.Model;
using AmxPeruPSBActivities.Repository;

namespace AmxCoPSBActivities.Repository.Factory
{
    class AmxCoResourceCharValueFactory
    {
        internal static Entity CreateEntityFrom(OrganizationServiceProxy org, AmxCoResourceCharValueModel resourceCharValue)
        {
            Entity entity = new Entity("AmxCoResourceCharValueModel");

            entity.Id = resourceCharValue.amxperu_resourcecharacteristicvalueid;
            entity.Attributes.Add("amxperu_name", resourceCharValue.amxperu_name);
            entity.Attributes.Add("amxperu_resourcecharacteristicid", new EntityReference("amxperu_resourcecharacteristic", resourceCharValue.resourceCharacteristic.amxperu_resourcecharacteristicid));

            return entity;
        }

        internal static AmxCoResourceCharValueModel CreateResourceCharValueFrom(OrganizationServiceProxy org, Entity entity)
        {
            var resourceCharValue = new AmxCoResourceCharValueModel();

            resourceCharValue.amxperu_resourcecharacteristicvalueid = entity.Id;

            if (entity.Contains("amxperu_name"))
                resourceCharValue.amxperu_name = entity.Attributes["amxperu_name"].ToString();

            if (entity.Contains("amxperu_resourcecharacteristicid")) {
                AmxCoResourceCharRepository resourceCharRepository = new AmxCoResourceCharRepository(org);
                resourceCharValue.resourceCharacteristic = resourceCharRepository.GetResourceChar(((EntityReference)entity.Attributes["amxperu_resourcecharacteristicid"]).Id);
            }

            return resourceCharValue;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] { "amxperu_name"
                                                    ,"amxperu_resourcecharacteristicid"});
            }
        }
    }
}
