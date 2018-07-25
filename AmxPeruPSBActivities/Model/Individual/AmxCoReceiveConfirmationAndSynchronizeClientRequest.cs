using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.Individual
{
    public class AmxCoReceiveConfirmationAndSynchronizeClientRequest
    {
        public string BiLogId { get; set; }
        public bool Confirmation { get; set; }
        public string email { get; set; }
        public string anniversary { get; set; }
        public int gendercode { get; set; }
        public string nickname { get; set; }
        public string address { get; set; }
        public string phoneno { get; set; }
        public string cellphoneno { get; set; }        
    }
}
