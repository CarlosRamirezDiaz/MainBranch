using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
 public class AMxperuValidaCoberturaResponse : BaseResponse
    {
        public TechnologiesType technologies { get; set; }
        public ProjectsType Projects { get; set; }
    }
    public class TechnologiesType
    {
        public ListTechnologiesType ListTechnologies { get; set; }
    }
    public class ListTechnologiesType
    {
        public string Type { get; set; }
        public string Plane { get; set; }
    
    }
    public class ProjectsType
    {
        public string TecnologiaProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public DateTime FechaFinProyecto { get; set; }

    }
}
