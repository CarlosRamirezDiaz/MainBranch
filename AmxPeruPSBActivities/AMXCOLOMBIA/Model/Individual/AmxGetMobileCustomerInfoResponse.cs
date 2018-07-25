using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Model.Individual
{
    public class AmxGetMobileCustomerInfoResponse
    {
        /// <summary>
        /// CustomerId :   Customer id
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Fullname of customer
        /// </summary>
        public string Fullname { get; set; }

        /// <summary>
        /// document number
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// document type id
        /// </summary>
        public string DocumentType { get; set; }

        /// <summary>
        /// Document Type Name
        /// </summary>
        public string DocumentTypeName { get; internal set; }

        /// <summary>
        /// MailAddress: Street and county for mail
        /// </summary>
        public string MailAddress { get; set; }

        /// <summary>
        /// Mail City in addrees
        /// </summary>
        public string MailAdrressCity { get; set; }

        /// <summary>
        /// Contact Telefone 1 - landline
        /// </summary>
        public string ContactPhoneNumber1 { get; set; }

        /// <summary>
        /// Contact Telefone 2 - mobile
        /// </summary>
        public string ContactPhoneNumber2 { get; set; }

        /// <summary>
        /// Service Activation date
        /// </summary>
        public DateTime ActivationDate { get; set; }
    }
}
