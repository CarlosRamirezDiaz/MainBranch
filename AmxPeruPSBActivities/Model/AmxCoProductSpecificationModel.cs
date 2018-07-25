using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.Model
{
    public class AmxCoProductSpecificationModel
    {
        public Guid etel_productspecificationid { get; set; }
        public string etel_name { get; set; }
        public string etel_externalid { get; set; }
        public OptionSetValue etel_specificationtypecode { get; set; }
        public OptionSetValue etel_servicetypecode { get; set; }
    }

    public class AmxCoProductSpecificationModelFull
    {
        public Guid etel_productspecificationid { get; set; }
        public string etel_name { get; set; }
        public string etel_externalid { get; set; }
        public OptionSetValue etel_specificationtypecode { get; set; }
        public OptionSetValue etel_servicetypecode { get; set; }
        public List<AmxCoProducResourceSpecificationModelFull> ProductResourceSpecList { get; set; }
    }
}
