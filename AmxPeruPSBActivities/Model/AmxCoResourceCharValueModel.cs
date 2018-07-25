
using AmxPeruPSBActivities.Model;
using Ericsson.ETELCRM.Entities.Crm.CustomEntities;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.Model
{
    public class AmxCoResourceCharValueModel
    {
        public Guid amxperu_resourcecharacteristicvalueid { get; set; }
        public string amxperu_name { get; set; }
        public AmxCoResourceCharModel resourceCharacteristic { get; set; }
    }
}
