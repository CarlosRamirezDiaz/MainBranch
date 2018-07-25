using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Model
{
   public class AmxCoTechnicianAppGetResourceResponce
    {
        public List<Techproperties> techproperties { get; set; }
    }
    public class Techproperties
    {
        public string attributeName { get; set; }
        public string attributeValue { get; set; }
    }

    
}
