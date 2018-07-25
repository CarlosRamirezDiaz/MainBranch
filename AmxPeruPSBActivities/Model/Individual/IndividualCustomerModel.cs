using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.Individual
{
    public class IndividualCustomerModel
    {
        public Guid IndividualCustomerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }
        public int DocumentType { get; set; }
        public DateTime DocumentIssueDate { get; set; }
        public DateTime BirthDate { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public string Email { get; internal set; }
        public string CompanyName { get; internal set; }
        public string BirthPlace { get; internal set; }
        public string Nationality { get; internal set; }
        public string CustomerId { get; internal set; }
        public bool ActiveFlag { get; internal set; }
        public string Gender { get; internal set; }
        public int StateCode { get; internal set; }
        public string StatusCode { get; internal set; }
        public string ListasInternasClientesReason { get; internal set; }
        public DateTime CustomerSince { get; internal set; }
        public Segment Segment { get; set; }
        public DateTime BiographicValidationDate { get; set; }
    }
}
