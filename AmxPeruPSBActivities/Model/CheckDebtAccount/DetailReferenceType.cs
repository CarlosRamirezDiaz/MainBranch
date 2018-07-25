using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.CheckDebtAccount
{
    public class DetailReferenceType
    {
        public string TIPO_SERVICIO { get; set; }
        public string COD_CUENTA { get; set; }
        public string ESTADO_CUENTA { get; set; }
        public double PROMEDIO_FACTURADO { get; set; }
        public double DEUDA_CORRIENTE { get; set; }
        public double DEUDA_VENCIDA { get; set; }
        public double DEUDA_CASTIGADA { get; set; }
        public int CANT_SERVICIOS { get; set; }
        public string IND_CENTRAL_RIESGO { get; set; }
    }
}
