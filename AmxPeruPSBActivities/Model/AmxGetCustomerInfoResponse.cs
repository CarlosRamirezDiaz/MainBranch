using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model.Individual;

namespace AmxPSBActivities.Model
{
    public class AmxGetCustomerInfoResponse : AmxPeruPSBActivities.Model.BaseResponse
    {
        public string customerId { get; set; }
        public bool activeFlag { get; set; }
        public string corporateName { get; set; }
        public string segment { get; set; }
        public int customerType { get; set; }
        public bool protectedData { get; set; }
        public int preferredContactMethod { get; set; }
        public bool doNotMail { get; set; }
        public bool doNotEmail { get; set; }
        public bool doNotPhone { get; set; }
        public string preferredDay { get; set; }
        public string preferredTime { get; set; }
        public bool sendMaterial { get; set; }
        public string blackListStatusCode { get; set; }
        public string blackListStatusReason { get; set; }
        public string name { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string companyName { get; set; }
        public int documentType { get; set; }
        public string documentNumber { get; set; }
        public string email { get; set; }
        public string alternateEmail { get; set; }
        public string birthPlace { get; set; }
        public string phoneNumber { get; set; }
        public string principalAddressId { get; set; }
        public string principalAddress { get; set; }
        public string parentAccountId { get; set; }
        public string legalRepresentantName { get; set; }
        public string legalRepresentantPhoneNumber { get; set; }
        public string legalRepresentantId { get; set; }
        public string legalRepresentantAddress { get; set; }
        public string gender { get; set; }
        public DateTime birthDate { get; set; }
        public string nationality { get; set; }
        public int maritalStatus { get; set; }
        public List<Hobbies> hobbies { get; set; }
        public List<Interests> interests { get; set; }
        public List<SocialNetworks> socialNetworks { get; set; }

        public AmxGetCustomerInfoResponse()
        { }

        public AmxGetCustomerInfoResponse(IndividualCustomerModel individual)
        {
            this.customerId = individual.CustomerId;
            this.activeFlag = individual.ActiveFlag;
            this.corporateName = individual.CompanyName;

            if (individual.Segment != null && !string.IsNullOrEmpty(individual.Segment.Name))
                this.segment = individual.Segment.Name;
            else
                this.segment = string.Empty;

            this.name = individual.FullName;
            this.firstName = individual.FirstName;
            this.lastName = individual.LastName;
            this.companyName = individual.CompanyName;
            this.documentType = individual.DocumentType;
            this.documentNumber = individual.DocumentNumber;
            this.email = individual.Email;
            this.birthDate = individual.BirthDate;
            this.birthPlace = individual.BirthPlace;
            this.phoneNumber = individual.PhoneNumber;
            this.gender = individual.Gender;
    }
}

    public class Hobbies
    {
        public string hobbyId { get; set; }
        public string hobbyDescription { get; set; }

    }
    public class SocialNetworks
    {
        public string socialNetworktId { get; set; }
        public string socialNetworkNickname { get; set; }
    }

    public class Interests
    {
        public string interestId { get; set; }
        public string interestDescription { get; set; }
    }
}
