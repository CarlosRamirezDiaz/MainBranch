using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.CreditScore
{
   public class AmxPeruGetCreditScoreRequest:BaseRequest
    {
        public int DocumentType { get; set; }

         public string DocumentID { get; set; }

    }
}
