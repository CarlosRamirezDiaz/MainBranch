using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.ConsultaDocumentoOnBase
{
    public class AMXPeruConsultaDocumentoOnBaseResponse: BaseResponse
    {
        public byte[] documento { get; set; }

        public string codigoRespuesta { get; set; }

        public string descripcionRespuesta { get; set; }
    }
}
