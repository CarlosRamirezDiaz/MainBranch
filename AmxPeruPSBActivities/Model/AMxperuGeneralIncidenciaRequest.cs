
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AMxperuGeneralIncidenciaRequest
    {
        public CustomerSpec customerSpec { get; set; }
        public KnownProblemDescription KnownProblemDescription { get; set; }
        public BusinessInteractionItem BusinessInteractionItem { get; set; }
        public CustomerProblemExtensions CustomerProblemExtension { get; set; }
        public CustomerProblem CustomerProblem { get; set; }
    }
    public class CustomerSpec
    {
        public string name { get; set; }
        public string lastName { get; set; }
    }

    public class KnownProblemDescription
    {
        public string Description { get; set; }
        public string name { get; set; }
    }
    public class BusinessInteractionItem
    {
        public string id { get; set; }
    }
    public class CustomerProblemExtensions
    {
        public string _typification { get; set; }
        public string _affectedServices { get; set; }
        public string _affectedZone { get; set; }
    }
    public class CustomerProblem
    {
        public string severity { get; set; }
    }
}
