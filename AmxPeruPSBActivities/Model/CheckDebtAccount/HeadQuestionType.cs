using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.CheckDebtAccount
{
    public class HeadQuestionType
    {
        public string NOMBRE_CLIENTE { get; set; }
        public string APE_PAT_CLIENTE { get; set; }
        public string APE_MAT_CLIENTE { get; set; }
        public int DEUDA_MOVIL { get; set; }
        public int DEUDA_FIJA { get; set; }
        public int DEUDA_VENCIDA_MOVIL { get; set; }
        public int DEUDA_VENCIDA_FIJA { get; set; }
        public int DEUDA_CASTIGADA_MOVIL { get; set; }
        public int DEUDA_CASTIGADA_FIJA { get; set; }
        public string DNI_ASOCIADO { get; set; }
        public int ANTIGÜEDAD_DEUDA { get; set; }
        public int TOTAL_SERVICIOS { get; set; }
    }
}
