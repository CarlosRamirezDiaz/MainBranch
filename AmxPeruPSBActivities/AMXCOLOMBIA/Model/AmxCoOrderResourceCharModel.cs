using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Model
{
    public class AmxCoOrderResourceCharModel
    {
        public AmxCoOrderResourceCharModel()
        {
        }

        public AmxCoOrderResourceCharModel(AmxCoOrderResourceCharModelInput orderResourceCharModelInput)
        {
            if (!String.IsNullOrEmpty(orderResourceCharModelInput.etel_orderresourcecharactericid))
                etel_orderresourcecharactericid = new Guid(orderResourceCharModelInput.etel_orderresourcecharactericid);

            if (!String.IsNullOrEmpty(orderResourceCharModelInput.etel_orderresourceid))
                etel_orderresourceid = new EntityReference("etel_orderresource", new Guid(orderResourceCharModelInput.etel_orderresourceid));

            if (!String.IsNullOrEmpty(orderResourceCharModelInput.amx_resource_characteristic))
                amx_resource_characteristic = new EntityReference("amxperu_resourcecharacteristic", new Guid(orderResourceCharModelInput.amx_resource_characteristic));

            if (!String.IsNullOrEmpty(orderResourceCharModelInput.amx_resource_characteristicvalue))
                amx_resource_characteristicvalue = new EntityReference("amxperu_resourcecharacteristicvalue", new Guid(orderResourceCharModelInput.amx_resource_characteristicvalue));

            if (!String.IsNullOrEmpty(orderResourceCharModelInput.etel_selectedvalue))
                etel_selectedvalue = orderResourceCharModelInput.etel_selectedvalue;

            if (!String.IsNullOrEmpty(orderResourceCharModelInput.etel_datatypecode))
                if (int.TryParse(orderResourceCharModelInput.etel_datatypecode, out int i))
                    etel_datatypecode = new OptionSetValue(int.Parse(orderResourceCharModelInput.etel_datatypecode));
              
            if (!String.IsNullOrEmpty(orderResourceCharModelInput.etel_value))
                etel_value = orderResourceCharModelInput.etel_value;

            if (!String.IsNullOrEmpty(orderResourceCharModelInput.etel_name))
                etel_name = orderResourceCharModelInput.etel_name;
        }

        public Guid etel_orderresourcecharactericid { get; set; }
        public EntityReference etel_orderresourceid { get; set; }
        public EntityReference amx_resource_characteristic { get; set; }
        public EntityReference amx_resource_characteristicvalue { get; set; }
        public String etel_selectedvalue { get; set; }
        public OptionSetValue etel_datatypecode { get; set; }
        public String etel_value { get; set; }
        public String etel_name { get; set; }
    }

    public class AmxCoOrderResourceCharModelInput
    {
        public String etel_orderresourcecharactericid { get; set; }
        public String etel_orderresourceid { get; set; }
        public String amx_resource_characteristic { get; set; }
        public String amx_resource_characteristicvalue { get; set; }
        public String etel_selectedvalue { get; set; }
        public String etel_datatypecode { get; set; }
        public String etel_value { get; set; }
        public String etel_name { get; set; }
    }
}
