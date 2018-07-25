using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.BIBillingAccountCreate
{
    public class BIBillingAccountCreateModel
    {
        public Guid Id { get; set; }
        public Guid IndividualCustomerId { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
