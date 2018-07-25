using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.CheckDebtAccount
{
    public class CheckDebtAccountRequest : BaseRequest
    {
        public string AplicationId { get; set; }
        public string UserApplication { get; set; }
        public string DocumentId { get; set; }
        public string DocumentNumber { get; set; }
    }
}