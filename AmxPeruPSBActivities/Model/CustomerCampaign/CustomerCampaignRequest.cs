using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.CustomerCampaign
{
    public class CustomerCampaignRequest : BaseRequest
    {

        public string TipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public int NumeroTelefono { get; set; }

    }

    public class CampanaType
    {
        public string Numero_Telefono { get; set; }
        public string Num_Document { get; set; }
        public DateTime Fecha_Campana_Inicio { get; set; }
        public DateTime Fecha_Campana_Fin { get; set; }
        public string Canal_Aplicable { get; set; }
        public string Estado_Campana { get; set; }
        public string Codigo_Campana { get; set; }
        public string Nombre_Campana { get; set; }
        public string Descripcion_Campana { get; set; }
    }
}
