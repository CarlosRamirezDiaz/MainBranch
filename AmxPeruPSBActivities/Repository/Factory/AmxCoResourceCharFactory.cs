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

namespace AmxCoPSBActivities.Repository.Factory
{
    class AmxCoResourceCharFactory
    {
        internal static Entity CreateEntityFrom(OrganizationServiceProxy org, AmxCoResourceCharModel resourceChar)
        {
            Entity entity = new Entity("amxperu_resourcecharacteristic");

            entity.Id = resourceChar.amxperu_resourcecharacteristicid;
            entity.Attributes.Add("amxperu_defaultvalue", resourceChar.amxperu_defaultvalue);
            entity.Attributes.Add("amxperu_name", resourceChar.amxperu_name);
            entity.Attributes.Add("amxperu_datatype", resourceChar.amxperu_datatype);

            return entity;
        }

        internal static AmxCoResourceCharModel CreateResourceCharFrom(Entity entity)
        {
            var resourceChar = new AmxCoResourceCharModel();

            resourceChar.amxperu_resourcecharacteristicid = entity.Id;

            if (entity.Contains("amxperu_defaultvalue"))
                resourceChar.amxperu_defaultvalue = entity.Attributes["amxperu_defaultvalue"].ToString();
            if (entity.Contains("amxperu_name"))
                resourceChar.amxperu_name = entity.Attributes["amxperu_name"].ToString();
            if (entity.Contains("amxperu_datatype"))
                resourceChar.amxperu_datatype = (OptionSetValue)entity.Attributes["amxperu_datatype"];

            return resourceChar;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] { "amxperu_resourcecharacteristicid"
                                                    ,"amxperu_defaultvalue"
                                                    ,"amxperu_name"
                                                    ,"amxperu_datatype"});
            }
        }
    }
}
