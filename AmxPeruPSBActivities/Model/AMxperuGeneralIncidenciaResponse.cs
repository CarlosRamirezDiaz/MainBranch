using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AMxperuGeneralIncidenciaResponse
    {
        public string code { get; set; }
        public string message { get; set; }
        public string _ticketRemedy { get; set; }
        //public CustomerProblemExtension CustomerProblemExtension  { get; set; }
        //public ResponseStatus ResponseStatus { get; set; }
    }
public class CustomerProblemExtension
{
    public string _ticketRemedy;
    
}
    public class ResponseStatus
    {
        public string code { get; set; }
        public string message { get; set; }
    }
  
}
