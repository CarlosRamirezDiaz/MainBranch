using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.SendNotification;

namespace AmxPeruPSBActivities.Model.SendNotification
{
    public class AmxperuSendNotificationRequest
    {
        public string Description { get; set; }

        public string DispatchID { get; set; }

        public string ExternalIDs { get; set; }

        public string MailSender { get; set; }

        public string MailRecipient { get; set; }

        public string SubjectMail { get; set; }

        public string BodyMail { get; set; }

        public string Text01 { get; set; }

        public string Text02 { get; set; }

        public string Text03 { get; set; }

        public string TemplateID { get; set; }

        public DateTime InteractionDate { get; set; }

        public string regardingentityId { get; set; }

        public string regardingentityname { get; set; }

        public List<Documents> Documentslist { get; set; }

        public List<KeyValuePair> AttributeValuePair { get; set; }

       // public List<Product> ExternalIDs { get; set; }
    }

    public class Documents
    {
        public string DocumentName { get; set; }

        public string Description { get; set; }

        public Base64FormattingOptions OutputFile { get; set; }
    }

    public class KeyValuePair
    {
        public string nameField { get; set; }
        public string valueField { get; set; }

    }

    public class Product
    {
        public string ExternalIDs { get; set; }
    }

    
}
