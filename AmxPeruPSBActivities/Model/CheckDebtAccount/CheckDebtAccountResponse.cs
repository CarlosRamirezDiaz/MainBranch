using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.CheckDebtAccount
{
    public class CheckDebtAccountResponse
    {
        public List<HeadQuestionType> CABECERA_CONSULTA { get; set; }
        public List<DetailReferenceType> DETALLE_CONSULTA { get; set; }
        public string CodigoRespuesta { get; set; }
        public string DescripcionRespuesta { get; set; }
    }
}
