using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AmxPeruPSBActivities.Model.Case
{
   public  class CaseResponse  : BaseResponse
    {
        [Required]
        public int SuccessFlag { get; set; }

        [Required]
        public string CaseId { get; set; }

        public string OsiptelCaseId { get; set; }

        public string IndecopiCaseId { get; set; }
    }
}
