using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AmxSoapServicesActivities.Activities
{
    [XmlType(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class SOAPEnvelopeChangeCustomerEmail
    {
        [XmlAttribute(AttributeName = "soapenv", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public string soapenva { get; set; }
        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public string xsd { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string xsi { get; set; }
        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public ResponseBodyChangeCustomerEmail<ChangeCustomerEmailWsReference.customerReadResponse> body { get; set; }
        
        //[XmlElement(ElementName = "genericDirectoryNumberSearchResponse")]
        //public ResponseBody1<directorynumbers> genericDirectoryNumberSearchResponse1 { get; set; }

        //[XmlElement(ElementName = "directorynumbers")]
        //public ResponseBody2<item> directorynumbers { get; set; }


        public XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();

        public SOAPEnvelopeChangeCustomerEmail()
        {
            xmlns.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
        }
    }

    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class ResponseBodyChangeCustomerEmail<T>
    {
        [XmlElement(ElementName = "ChangeCustomerEmailResponse", Namespace = "http://localhost:9090/wsi/services/ws_CIL_7_CustomerReadService")]
        public T ChangeCustomerEmailResponse { get; set; }
    }
}
