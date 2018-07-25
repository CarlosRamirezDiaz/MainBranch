using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.ModelClaroESB.Digiturno
{
    public class UpdateUserTurnRequest
    {
        public int idTurn { get; set; }
        public NationalIdentityCard NationalIdentityCardIdentification { get; set; }
        public IndividualName individualName { get; set; }
        public PartyRoleCategory partyRoleCategory { get; set; }
        public TelephoneNumber[] telephoneNumber { get; set; }
        public Customer customer { get; set; }
    }

    public class NationalIdentityCard
    {
        public string typeIdentity { get; set; }
        public string identityCard { get; set; }
    }

    public class IndividualName
    {
        public string givenNames { get; set; }
        public string familyNames { get; set; }
    }

    public class PartyRoleCategory
    {
        public string categoryName { get; set; }
    }

    public class TelephoneNumber
    {
        public string number { get; set; }
        public string type { get; set; }
    }
    public class Customer
    {
        public string ID { get; set; }
    }
}
