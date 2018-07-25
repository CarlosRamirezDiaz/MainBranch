using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.CustomerCampaign
{
    public class CustomerCampaignResponse : BaseResponse
    {

        public CustomerCampaignResponse()
        {
            ListaCampana = new List<CampanaType>();
        }

        public List<CampanaType> ListaCampana { get; set; }
        public string CodigoRespuesta { get; set; }
        public string DescripcionRespuesta { get; set; }

    }
}
