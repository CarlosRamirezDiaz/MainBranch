using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.ValidAddressCoverage
{
    public class ValidAddressCoverageResponse
    {
        public string Technologies { get; set; }
        public string Projects { get; set; }
    }

    public class Technologies
    {
        public string Listtechnologies { get; set; }
    }

    public class Projects
    {
        public string Tecnologiaproyecto { get; set; }
        public string Nombreproyecto { get; set; }
        public string Fechafinproyecto { get; set; }
    }

    public class Listtechnologies
    {
        public string Type { get; set; }
        public string Plane { get; set; }
    }
}
