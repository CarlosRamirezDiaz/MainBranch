using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AmxPeruPSBActivities.Model.Case
{    
   public  class Documents
    {
        public string DocumentId { get; set; }

        public string DocumentName { get; set; }

        public string DocumentDescription { get; set; }

        public string DocumentIdOnbase  { get; set; }
    }
}
