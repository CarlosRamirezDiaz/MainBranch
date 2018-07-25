using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Model
{
    public class cmtDireccionRequestDto
    {        
        public string codigoDane { get; set; }
        public string direccion { get; set; }
        public string segmento { get; set; }
        public string proyecto { get; set; }
        public bool isDth { get; set; }
        public string nodoGestion { get; set; }
        public string user { get; set; }
        public string estrato { get; set; }
        public cmtDireccionTabuladaDto cmtDireccionTabuladaDto { get; set; }        
    }
    public class MGLHeaderRequest {
        public string transactionId { get; set; }
        public string system { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string requestDate { get; set; }
        public string ipApplication { get; set; }
    }

    public class AddressMGLtechDetails {
        public string idDireccion { get; set; }
        public string segmento { get; set; }
        public string residencial { get; set; }
        public string proyecto { get; set; }
    }
}
