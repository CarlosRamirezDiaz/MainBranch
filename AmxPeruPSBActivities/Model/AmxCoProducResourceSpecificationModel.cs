using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.Model
{
    public class AmxCoProducResourceSpecificationModel
    {
        public Guid etel_productresourcespecificationid { get; set; }
        public string etel_name { get; set; }
        public string etel_externalid { get; set; }
        public OptionSetValue amxperu_resourcetypecode { get; set; }
        public OptionSetValue amxperu_specificationsubtypecode { get; set; }
    }

    public class AmxCoProducResourceSpecificationModelFull
    {
        public Guid etel_productresourcespecificationid { get; set; }
        public string etel_name { get; set; }
        public string etel_externalid { get; set; }
        public OptionSetValue amxperu_resourcetypecode { get; set; }
        public OptionSetValue amxperu_specificationsubtypecode { get; set; }
        public List<AmxCoResourceCharValueModel> ResourceCharValueList { get; set; }
        public AmxCoProductResourceCardinalityModel productResourceCardinality { get; set; }
    }
}
