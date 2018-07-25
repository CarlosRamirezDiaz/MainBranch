using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Model.Certicamara
{
    public class HClientPayloadResponse
    {
        public string iat { get; set; }
        public string exp { get; set; }
        public string json { get; set; }
    }

    public class HClientException
    {
        public string Codigo { get; set; }
        public string NumDedo { get; set; }
        public string Resultado { get; set; }
        public string Cedula { get; set; }
        public string minuciaHuella { get; set; }
        public string Nut { get; set; }
    }
}
