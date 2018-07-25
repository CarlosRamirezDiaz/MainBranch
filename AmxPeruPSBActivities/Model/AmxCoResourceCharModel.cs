using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.Model
{
    public class AmxCoResourceCharModel
    {
        public Guid amxperu_resourcecharacteristicid { get; set; }
        public string amxperu_defaultvalue { get; set; }
        public string amxperu_name { get; set; }
        public OptionSetValue amxperu_datatype { get; set; }
    }
}
