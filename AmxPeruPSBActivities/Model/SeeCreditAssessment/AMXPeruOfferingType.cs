using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.SeeCreditAssessment
{
    public class AMXPeruOfferingType
    {
        public AMXPeruAutonomyType Autonomy { get; set; }
        public string Consumercontrol { get; set; }
        public double Costofinstallation { get; set; }
        public AMXPeruQuotaType Share { get; set; }
        public AMXPeruWarrantyType Warranty { get; set; }
        public double Creditlimitcollection { get; set; }
        public double Amountautomaticstop { get; set; }
        public AMXPeruOptionsType Optionofquotas { get; set; }
        public string Prioritypublish { get; set; }
        public string Rentexonerationprocess { get; set; }
        public string Idvalidatorprocess { get; set; }
        public string Internalvalidationprocessclaro { get; set; }
        public string Topost { get; set; }
        public string Restriction { get; set; }
        public AMXPeruAdditionalResultsType Additionalresults { get; set; }

    }
}
