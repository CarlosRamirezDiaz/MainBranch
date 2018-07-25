using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model
{
    public class AmxPeruCustomerContactResponse : BaseResponse
    {
        public List<Contact> listOfContacts { get; set; }
        public int successflag { get; set; }
    }
    public class Contact
    {
        public string name { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public string contactId { get; set; }
    }
}
