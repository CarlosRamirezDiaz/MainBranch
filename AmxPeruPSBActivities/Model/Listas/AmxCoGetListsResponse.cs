using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.Listas
{
    public class AmxCoGetListsResponse : BaseResponse
    {
        public Boolean clientes { get; set; }
        public Boolean telefonos { get; set; }
        public Boolean correos { get; set; }
    }
}
