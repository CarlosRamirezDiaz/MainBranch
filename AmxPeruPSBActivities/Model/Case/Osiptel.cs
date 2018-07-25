using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace AmxPeruPSBActivities.Model.Case
{
   public class Osiptel
    {
        [Required]
        [Description("Determine if the user creator of case has a \"power of attorney letter\", in this case, the customer should attach a document.")]
        public Boolean PaymentDocumentType { get; set; }
    }
}
