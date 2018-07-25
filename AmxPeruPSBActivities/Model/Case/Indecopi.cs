using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace AmxPeruPSBActivities.Model.Case
{    
    public class Indecopi
    {
        [Required]
        [Description("Indicates whether the case creator is of age/underage")]
        public Boolean OfAgeFlag { get; set; }

        [Description("Name of parents (if 'of age' is true).")]
        public string parentName { get; set; }

        [Required]
        [Description("Indicates whether the case creator is customer or not. ")]
        public Boolean isCustomerOfClaro { get; set; }

        [Required]
        [Description("Determine if the user creator of case has a \"power of attorney letter\", in this case, the customer should attach a document.")]
        public string CaseCreatorRole { get; set; }

        [Required]
        [Description("Name of user who creates the case")]
        public string CaseCreatorName { get; set; }

        [Required]
        [Description("Lastname of user who creates the case")]
        public string CaseCreatorLastName { get; set; }

        [Required]
        [Description("Document type for the creator of case")]
        public string CaseCreatorDocumentType { get; set; }

        [Required]
        [Description("Document number for the creator of case")]
        public string CaseCreatorDocumentNumber { get; set; }
    }
}
