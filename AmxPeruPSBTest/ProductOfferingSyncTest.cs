using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using static AmxPeruTest.Helpers.TestHelper;
using AmxPeruPSBWorkflows;
using Newtonsoft.Json;

namespace AmxPeruPSBTest
{

    [XmlRoot(ElementName = "labelTranslations")]
    public class LabelTranslations
    {
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
        [XmlElement(ElementName = "language")]
        public string Language { get; set; }
    }

    [XmlRoot(ElementName = "infoModelAttributes")]
    public class InfoModelAttributes
    {
        [XmlElement(ElementName = "infoModelCode")]
        public string InfoModelCode { get; set; }
        [XmlElement(ElementName = "attributeCode")]
        public string AttributeCode { get; set; }
        [XmlElement(ElementName = "modelAttrName")]
        public string ModelAttrName { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "label")]
        public string Label { get; set; }
        [XmlElement(ElementName = "sequence")]
        public string Sequence { get; set; }
        [XmlElement(ElementName = "isSearch")]
        public string IsSearch { get; set; }
        [XmlElement(ElementName = "createDate")]
        public string CreateDate { get; set; }
        [XmlElement(ElementName = "createdBy")]
        public string CreatedBy { get; set; }
        [XmlElement(ElementName = "updateDate")]
        public string UpdateDate { get; set; }
        [XmlElement(ElementName = "updatedBy")]
        public string UpdatedBy { get; set; }
        [XmlElement(ElementName = "projectCode")]
        public string ProjectCode { get; set; }
        [XmlElement(ElementName = "labelTranslations")]
        public LabelTranslations LabelTranslations { get; set; }
        [XmlElement(ElementName = "isNull")]
        public string IsNull { get; set; }
    }

    [XmlRoot(ElementName = "infoModel")]
    public class InfoModel
    {
        [XmlElement(ElementName = "infoModelCode")]
        public string InfoModelCode { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "startDate")]
        public string StartDate { get; set; }
        [XmlElement(ElementName = "label")]
        public string Label { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "createDate")]
        public string CreateDate { get; set; }
        [XmlElement(ElementName = "createdBy")]
        public string CreatedBy { get; set; }
        [XmlElement(ElementName = "updateDate")]
        public string UpdateDate { get; set; }
        [XmlElement(ElementName = "updatedBy")]
        public string UpdatedBy { get; set; }
        [XmlElement(ElementName = "infoModelAttributes")]
        public List<InfoModelAttributes> InfoModelAttributes { get; set; }
        [XmlElement(ElementName = "projectCode")]
        public string ProjectCode { get; set; }
        [XmlElement(ElementName = "labelTranslations")]
        public LabelTranslations LabelTranslations { get; set; }
    }

    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body
    {
        [XmlElement(ElementName = "infoModel")]
        public InfoModel InfoModel { get; set; }
    }

    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope
    {
        [XmlElement(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public string Header { get; set; }
        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Body Body { get; set; }
        [XmlAttribute(AttributeName = "soapenv", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Soapenv { get; set; }
    }

    [XmlRoot(ElementName = "labelTranslations")]
    public class LabelTranslations2
    {
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
        [XmlElement(ElementName = "language")]
        public string Language { get; set; }
    }

    [XmlRoot(ElementName = "descriptionTranslations")]
    public class DescriptionTranslations
    {
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
        [XmlElement(ElementName = "language")]
        public string Language { get; set; }
    }

    [XmlRoot(ElementName = "infoTable")]
    public class InfoTable
    {
        [XmlElement(ElementName = "infoModelCode")]
        public string InfoModelCode { get; set; }
        [XmlElement(ElementName = "startDate")]
        public string StartDate { get; set; }
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "createDate")]
        public string CreateDate { get; set; }
        [XmlElement(ElementName = "createdBy")]
        public string CreatedBy { get; set; }
        [XmlElement(ElementName = "updateDate")]
        public string UpdateDate { get; set; }
        [XmlElement(ElementName = "updatedBy")]
        public string UpdatedBy { get; set; }
        [XmlElement(ElementName = "projectCode")]
        public string ProjectCode { get; set; }
        [XmlElement(ElementName = "versionCommitDate")]
        public string VersionCommitDate { get; set; }
        [XmlElement(ElementName = "versionId")]
        public string VersionId { get; set; }
        [XmlElement(ElementName = "data")]
        public string Data { get; set; }
        [XmlElement(ElementName = "infoTableCode")]
        public string InfoTableCode { get; set; }
        [XmlElement(ElementName = "label")]
        public string Label { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "labelTranslations")]
        public LabelTranslations2 LabelTranslations { get; set; }
        [XmlElement(ElementName = "descriptionTranslations")]
        public DescriptionTranslations DescriptionTranslations { get; set; }
    }

    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body2
    {
        [XmlElement(ElementName = "infoTable")]
        public InfoTable InfoTable { get; set; }
    }

    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope2
    {
        [XmlElement(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public string Header { get; set; }
        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Body2 Body { get; set; }
        [XmlAttribute(AttributeName = "soapenv", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Soapenv { get; set; }
    }

    public class InfoTableRecords
    {
        public Data infoTableRecords { get; set; }
    }

    public class Data
    {
        public List<string> data { get; set; }
    }

    [TestClass]
    public class ProductOfferingSyncTest
    {
        private static T DeserializeInnerSoapObject<T>(string soapResponse)
        {
            XmlDocument x = new XmlDocument();
            x.LoadXml(soapResponse);
            var soapBody = x.GetElementsByTagName("soapenv:Body")[0];
            string innerObject = soapBody.InnerXml;
            XmlSerializer deserializer = new XmlSerializer(typeof(T));

            using (StringReader reader = new StringReader(innerObject))
            {
                return (T)deserializer.Deserialize(reader);
            }
        }

        [TestMethod]
        public void ECMInfoTableTransfer()
        {
            bool successFlag = false;
            string SoapXmlText = @"<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/'>
                                       <soapenv:Header/>
                                           <soapenv:Body>
                                              <infoTableSearchDS>
                                                 <!--Optional:-->
                                                 <infoTableCode>DisponibilidadTelefonia</infoTableCode>
                                                 <!--Optional:-->
                                                 <status>DEF</status>
                                                 <!--Optional:-->
                                                 <startDate>2017-08-17T16:00:00-05:00</startDate>
                                              </infoTableSearchDS>
                                           </soapenv:Body>
                                    </soapenv:Envelope>";

            string BscsApiUri = string.Empty;
            try
            {
                //Get the bascs api uri from crm config
                BscsApiUri = "http://localhost:57004/ecm/services/InfoTableMaintenanceV2?wsdl";

                HttpWebRequest request = CreateWebRequest(BscsApiUri, "ReadInfoTable");
                XmlDocument soapEnvelopeXml = new XmlDocument();
                soapEnvelopeXml.LoadXml(SoapXmlText);
                using (Stream stream = request.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }

                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        string soapResult = rd.ReadToEnd();

                        var y = DeserializeInnerSoapObject<InfoTable>(soapResult);

                        var x = "{\"infoTableRecords\": {\"data\":[\"Residential,claroMax99_1,iPhone6s,32,Silver,0,0,0.0,0.0,0.0,2470.0,2470.0,2470.0,IP6S32SILVER,Apple\nResidential,claroMax99_1,iPhone6s,32,Silver,12,24,0.0,2.0,0.0,2402.0,2402.0,2402.0,IP6S32SILVER,Apple\nResidential,claroMax99_1,iPhone6s,32,Silver,24,24,0.0,1.0,0.0,2402.0,2402.0,2402.0,IP6S32SILVER,Apple\nResidential,claroMax99_1,iPhone6s,32,Black,0,0,0.0,0.0,0.0,2470.0,2470.0,2470.0,IP6S32BLACK,Apple\nResidential,claroMax99_1,iPhone6s,32,Black,12,24,0.0,2.0,0.0,2402.0,2402.0,2402.0,IP6S32BLACK,Apple\nResidential,claroMax99_1,iPhone6s,32,Black,24,24,0.0,1.0,0.0,2402.0,2402.0,2402.0,IP6S32BLACK,Apple\nResidential,claroMax99_1,iPhone6s,32,Gold,0,0,0.0,0.0,0.0,2470.0,2470.0,2470.0,IP6S32GOLD,Apple\nResidential,claroMax99_1,iPhone6s,32,Gold,12,24,0.0,2.0,0.0,2402.0,2402.0,2402.0,IP6S32GOLD,Apple\nResidential,claroMax99_1,iPhone6s,32,Gold,24,24,0.0,1.0,0.0,2402.0,2402.0,2402.0,IP6S32GOLD,Apple\nResidential,claroMax99_1,iPhone6s,32,Rose Gold,0,0,0.0,0.0,0.0,2470.0,2470.0,2470.0,IP6S32ROSE,Apple\nResidential,claroMax99_1,iPhone6s,32,Rose Gold,12,24,0.0,2.0,0.0,2402.0,2402.0,2402.0,IP6S32ROSE,Apple\nResidential,claroMax99_1,iPhone6s,32,Rose Gold,24,24,0.0,1.0,0.0,2402.0,2402.0,2402.0,IP6S32ROSE,Apple\nResidential,claroMax99_1,iPhone6s,128,Silver,0,0,0.0,0.0,0.0,2864.0,2864.0,2864.0,IP6S128SILVER,Apple\nResidential,claroMax99_1,iPhone6s,128,Silver,12,24,0.0,2.0,0.0,2796.0,2796.0,2796.0,IP6S128SILVER,Apple\nResidential,claroMax99_1,iPhone6s,128,Silver,24,24,0.0,1.0,0.0,2796.0,2796.0,2796.0,IP6S128SILVER,Apple\nResidential,claroMax99_1,iPhone6s,128,Black,0,0,0.0,0.0,0.0,2864.0,2864.0,2864.0,IP6S128BLACK,Apple\nResidential,claroMax99_1,iPhone6s,128,Black,12,24,0.0,2.0,0.0,2796.0,2796.0,2796.0,IP6S128BLACK,Apple\nResidential,claroMax99_1,iPhone6s,128,Black,24,24,0.0,1.0,0.0,2796.0,2796.0,2796.0,IP6S128BLACK,Apple\nResidential,claroMax99_1,iPhone6s,128,Gold,0,0,0.0,0.0,0.0,2864.0,2864.0,2864.0,IP6S128GOLD,Apple\nResidential,claroMax99_1,iPhone6s,128,Gold,12,24,0.0,2.0,0.0,2796.0,2796.0,2796.0,IP6S128GOLD,Apple\nResidential,claroMax99_1,iPhone6s,128,Gold,24,24,0.0,1.0,0.0,2796.0,2796.0,2796.0,IP6S128GOLD,Apple\nResidential,claroMax99_1,iPhone6s,128,Rose Gold,0,0,0.0,0.0,0.0,2864.0,2864.0,2864.0,IP6S128ROSE,Apple\nResidential,claroMax99_1,iPhone6s,128,Rose Gold,12,24,0.0,2.0,0.0,2796.0,2796.0,2796.0,IP6S128ROSE,Apple\nResidential,claroMax99_1,iPhone6s,128,Rose Gold,24,24,0.0,1.0,0.0,2796.0,2796.0,2796.0,IP6S128ROSE,Apple\nResidential,claroMax99_1,GalaxyS7,32,Silver,0,0,0.0,0.0,0.0,2613.0,2613.0,2613.0,GALS7SILVER,Samsung\nResidential,claroMax99_1,GalaxyS7,32,Silver,12,24,0.0,2.0,0.0,2545.0,2545.0,2545.0,GALS7SILVER,Samsung\nResidential,claroMax99_1,GalaxyS7,32,Silver,24,24,0.0,1.0,0.0,2545.0,2545.0,2545.0,GALS7SILVER,Samsung\nResidential,claroMax99_1,GalaxyS7,32,Black,0,0,0.0,0.0,0.0,2613.0,2613.0,2613.0,GALS7BLACK,Samsung\nResidential,claroMax99_1,GalaxyS7,32,Black,12,24,0.0,2.0,0.0,2545.0,2545.0,2545.0,GALS7BLACK,Samsung\nResidential,claroMax99_1,GalaxyS7,32,Black,24,24,0.0,1.0,0.0,2545.0,2545.0,2545.0,GALS7BLACK,Samsung\nResidential,claroMax99_1,GalaxyS7,32,Gold,0,0,0.0,0.0,0.0,2613.0,2613.0,2613.0,GALS7GOLD,Samsung\nResidential,claroMax99_1,GalaxyS7,32,Gold,12,24,0.0,2.0,0.0,2545.0,2545.0,2545.0,GALS7GOLD,Samsung\nResidential,claroMax99_1,GalaxyS7,32,Gold,24,24,0.0,1.0,0.0,2545.0,2545.0,2545.0,GALS7GOLD,Samsung\nResidential,claroMax99_1,GalaxyS7,32,Rose Gold,0,0,0.0,0.0,0.0,2613.0,2613.0,2613.0,GALS7ROSE,Samsung\nResidential,claroMax99_1,GalaxyS7,32,Rose Gold,12,24,0.0,2.0,0.0,2545.0,2545.0,2545.0,GALS7ROSE,Samsung\nResidential,claroMax99_1,GalaxyS7,32,Rose Gold,24,24,0.0,1.0,0.0,2545.0,2545.0,2545.0,GALS7ROSE,Samsung\nResidential,claroMax99_1,GalaxyS7,32,White,0,0,0.0,0.0,0.0,2613.0,2613.0,2613.0,GALS7WHITE,Samsung\nResidential,claroMax99_1,GalaxyS7,32,White,12,24,0.0,2.0,0.0,2545.0,2545.0,2545.0,GALS7WHITE,Samsung\nResidential,claroMax99_1,GalaxyS7,32,White,24,24,0.0,1.0,0.0,2545.0,2545.0,2545.0,GALS7WHITE,Samsung\nResidential,claroMax189_1,iPhone6s,32,Silver,0,0,0.0,0.0,0.0,2480.0,2480.0,2480.0,IP6S32SILVER,Apple\nResidential,claroMax189_1,iPhone6s,32,Silver,12,24,0.0,2.0,0.0,2405.0,2405.0,2405.0,IP6S32SILVER,Apple\nResidential,claroMax189_1,iPhone6s,32,Silver,24,24,0.0,1.0,0.0,2405.0,2405.0,2405.0,IP6S32SILVER,Apple\nResidential,claroMax189_1,iPhone6s,32,Black,0,0,0.0,0.0,0.0,2480.0,2480.0,2480.0,IP6S32BLACK,Apple\nResidential,claroMax189_1,iPhone6s,32,Black,12,24,0.0,2.0,0.0,2405.0,2405.0,2405.0,IP6S32BLACK,Apple\nResidential,claroMax189_1,iPhone6s,32,Black,24,24,0.0,1.0,0.0,2405.0,2405.0,2405.0,IP6S32BLACK,Apple\nResidential,claroMax189_1,iPhone6s,32,Gold,0,0,0.0,0.0,0.0,2480.0,2480.0,2480.0,IP6S32GOLD,Apple\nResidential,claroMax189_1,iPhone6s,32,Gold,12,24,0.0,2.0,0.0,2405.0,2405.0,2405.0,IP6S32GOLD,Apple\nResidential,claroMax189_1,iPhone6s,32,Gold,24,24,0.0,1.0,0.0,2405.0,2405.0,2405.0,IP6S32GOLD,Apple\nResidential,claroMax189_1,iPhone6s,32,Rose Gold,0,0,0.0,0.0,0.0,2480.0,2480.0,2480.0,IP6S32ROSE,Apple\nResidential,claroMax189_1,iPhone6s,32,Rose Gold,12,24,0.0,2.0,0.0,2405.0,2405.0,2405.0,IP6S32ROSE,Apple\nResidential,claroMax189_1,iPhone6s,32,Rose Gold,24,24,0.0,1.0,0.0,2405.0,2405.0,2405.0,IP6S32ROSE,Apple\nResidential,claroMax189_1,iPhone6s,128,Silver,0,0,0.0,0.0,0.0,2868.0,2868.0,2868.0,IP6S128SILVER,Apple\nResidential,claroMax189_1,iPhone6s,128,Silver,12,24,0.0,2.0,0.0,2799.0,2799.0,2799.0,IP6S128SILVER,Apple\nResidential,claroMax189_1,iPhone6s,128,Silver,24,24,0.0,1.0,0.0,2799.0,2799.0,2799.0,IP6S128SILVER,Apple\nResidential,claroMax189_1,iPhone6s,128,Black,0,0,0.0,0.0,0.0,2868.0,2868.0,2868.0,IP6S128BLACK,Apple\nResidential,claroMax189_1,iPhone6s,128,Black,12,24,0.0,2.0,0.0,2799.0,2799.0,2799.0,IP6S128BLACK,Apple\nResidential,claroMax189_1,iPhone6s,128,Black,24,24,0.0,1.0,0.0,2799.0,2799.0,2799.0,IP6S128BLACK,Apple\nResidential,claroMax189_1,iPhone6s,128,Gold,0,0,0.0,0.0,0.0,2868.0,2868.0,2868.0,IP6S128GOLD,Apple\nResidential,claroMax189_1,iPhone6s,128,Gold,12,24,0.0,2.0,0.0,2799.0,2799.0,2799.0,IP6S128GOLD,Apple\nResidential,claroMax189_1,iPhone6s,128,Gold,24,24,0.0,1.0,0.0,2799.0,2799.0,2799.0,IP6S128GOLD,Apple\nResidential,claroMax189_1,iPhone6s,128,Rose Gold,0,0,0.0,0.0,0.0,2868.0,2868.0,2868.0,IP6S128ROSE,Apple\nResidential,claroMax189_1,iPhone6s,128,Rose Gold,12,24,0.0,2.0,0.0,2799.0,2799.0,2799.0,IP6S128ROSE,Apple\nResidential,claroMax189_1,iPhone6s,128,Rose Gold,24,24,0.0,1.0,0.0,2799.0,2799.0,2799.0,IP6S128ROSE,Apple\nResidential,claroMax189_1,GalaxyS7,32,Silver,0,0,0.0,0.0,0.0,2614.0,2614.0,2614.0,GALS7SILVER,Samsung\nResidential,claroMax189_1,GalaxyS7,32,Silver,12,24,0.0,2.0,0.0,2546.0,2546.0,2546.0,GALS7SILVER,Samsung\nResidential,claroMax189_1,GalaxyS7,32,Silver,24,24,0.0,1.0,0.0,2546.0,2546.0,2546.0,GALS7SILVER,Samsung\nResidential,claroMax189_1,GalaxyS7,32,Black,0,0,0.0,0.0,0.0,2614.0,2614.0,2614.0,GALS7BLACK,Samsung\nResidential,claroMax189_1,GalaxyS7,32,Black,12,24,0.0,2.0,0.0,2546.0,2546.0,2546.0,GALS7BLACK,Samsung\nResidential,claroMax189_1,GalaxyS7,32,Black,24,24,0.0,1.0,0.0,2546.0,2546.0,2546.0,GALS7BLACK,Samsung\nResidential,claroMax189_1,GalaxyS7,32,Gold,0,0,0.0,0.0,0.0,2614.0,2614.0,2614.0,GALS7GOLD,Samsung\nResidential,claroMax189_1,GalaxyS7,32,Gold,12,24,0.0,2.0,0.0,2546.0,2546.0,2546.0,GALS7GOLD,Samsung\nResidential,claroMax189_1,GalaxyS7,32,Gold,24,24,0.0,1.0,0.0,2546.0,2546.0,2546.0,GALS7GOLD,Samsung\nResidential,claroMax189_1,GalaxyS7,32,Rose Gold,0,0,0.0,0.0,0.0,2614.0,2614.0,2614.0,GALS7ROSE,Samsung\nResidential,claroMax189_1,GalaxyS7,32,Rose Gold,12,24,0.0,2.0,0.0,2546.0,2546.0,2546.0,GALS7ROSE,Samsung\nResidential,claroMax189_1,GalaxyS7,32,Rose Gold,24,24,0.0,1.0,0.0,2546.0,2546.0,2546.0,GALS7ROSE,Samsung\nResidential,claroMax189_1,GalaxyS7,32,White,0,0,0.0,0.0,0.0,2614.0,2614.0,2614.0,GALS7WHITE,Samsung\nResidential,claroMax189_1,GalaxyS7,32,White,12,24,0.0,2.0,0.0,2546.0,2546.0,2546.0,GALS7WHITE,Samsung\nResidential,claroMax189_1,GalaxyS7,32,White,24,24,0.0,1.0,0.0,2546.0,2546.0,2546.0,GALS7WHITE,Samsung\nResidential,claroMax15_1,iPhone6s,32,Silver,0,0,0.0,0.0,0.0,2490.0,2490.0,2490.0,IP6S32SILVER,Apple\nResidential,claroMax15_1,iPhone6s,32,Silver,12,24,0.0,2.0,0.0,2400.0,2400.0,2400.0,IP6S32SILVER,Apple\nResidential,claroMax15_1,iPhone6s,32,Silver,24,24,0.0,1.0,0.0,2400.0,2400.0,2400.0,IP6S32SILVER,Apple\nResidential,claroMax15_1,iPhone6s,32,Black,0,0,0.0,0.0,0.0,2490.0,2490.0,2490.0,IP6S32BLACK,Apple\nResidential,claroMax15_1,iPhone6s,32,Black,12,24,0.0,2.0,0.0,2400.0,2400.0,2400.0,IP6S32BLACK,Apple\nResidential,claroMax15_1,iPhone6s,32,Black,24,24,0.0,1.0,0.0,2400.0,2400.0,2400.0,IP6S32BLACK,Apple\nResidential,claroMax15_1,iPhone6s,32,Gold,0,0,0.0,0.0,0.0,2490.0,2490.0,2490.0,IP6S32GOLD,Apple\nResidential,claroMax15_1,iPhone6s,32,Gold,12,24,0.0,2.0,0.0,2400.0,2400.0,2400.0,IP6S32GOLD,Apple\nResidential,claroMax15_1,iPhone6s,32,Gold,24,24,0.0,1.0,0.0,2400.0,2400.0,2400.0,IP6S32GOLD,Apple\nResidential,claroMax15_1,iPhone6s,32,Rose Gold,0,0,0.0,0.0,0.0,2490.0,2490.0,2490.0,IP6S32ROSE,Apple\nResidential,claroMax15_1,iPhone6s,32,Rose Gold,12,24,0.0,2.0,0.0,2400.0,2400.0,2400.0,IP6S32ROSE,Apple\nResidential,claroMax15_1,iPhone6s,32,Rose Gold,24,24,0.0,1.0,0.0,2400.0,2400.0,2400.0,IP6S32ROSE,Apple\nResidential,claroMax15_1,iPhone6s,128,Silver,0,0,0.0,0.0,0.0,2888.0,2888.0,2888.0,IP6S128SILVER,Apple\nResidential,claroMax15_1,iPhone6s,128,Silver,12,24,0.0,2.0,0.0,2800.0,2800.0,2800.0,IP6S128SILVER,Apple\nResidential,claroMax15_1,iPhone6s,128,Silver,24,24,0.0,1.0,0.0,2800.0,2800.0,2800.0,IP6S128SILVER,Apple\nResidential,claroMax15_1,iPhone6s,128,Black,0,0,0.0,0.0,0.0,2888.0,2888.0,2888.0,IP6S128BLACK,Apple\nResidential,claroMax15_1,iPhone6s,128,Black,12,24,0.0,2.0,0.0,2800.0,2800.0,2800.0,IP6S128BLACK,Apple\nResidential,claroMax15_1,iPhone6s,128,Black,24,24,0.0,1.0,0.0,2800.0,2800.0,2800.0,IP6S128BLACK,Apple\nResidential,claroMax15_1,iPhone6s,128,Gold,0,0,0.0,0.0,0.0,2888.0,2888.0,2888.0,IP6S128GOLD,Apple\nResidential,claroMax15_1,iPhone6s,128,Gold,12,24,0.0,2.0,0.0,2800.0,2800.0,2800.0,IP6S128GOLD,Apple\nResidential,claroMax15_1,iPhone6s,128,Gold,24,24,0.0,1.0,0.0,2800.0,2800.0,2800.0,IP6S128GOLD,Apple\nResidential,claroMax15_1,iPhone6s,128,Rose Gold,0,0,0.0,0.0,0.0,2888.0,2888.0,2888.0,IP6S128ROSE,Apple\nResidential,claroMax15_1,iPhone6s,128,Rose Gold,12,24,0.0,2.0,0.0,2800.0,2800.0,2800.0,IP6S128ROSE,Apple\nResidential,claroMax15_1,iPhone6s,128,Rose Gold,24,24,0.0,1.0,0.0,2800.0,2800.0,2800.0,IP6S128ROSE,Apple\nResidential,claroMax15_1,GalaxyS7,32,Silver,0,0,0.0,0.0,0.0,2615.0,2615.0,2615.0,GALS7SILVER,Samsung\nResidential,claroMax15_1,GalaxyS7,32,Silver,12,24,0.0,2.0,0.0,2547.0,2547.0,2547.0,GALS7SILVER,Samsung\nResidential,claroMax15_1,GalaxyS7,32,Silver,24,24,0.0,1.0,0.0,2547.0,2547.0,2547.0,GALS7SILVER,Samsung\nResidential,claroMax15_1,GalaxyS7,32,Black,0,0,0.0,0.0,0.0,2615.0,2615.0,2615.0,GALS7BLACK,Samsung\nResidential,claroMax15_1,GalaxyS7,32,Black,12,24,0.0,2.0,0.0,2547.0,2547.0,2547.0,GALS7BLACK,Samsung\nResidential,claroMax15_1,GalaxyS7,32,Black,24,24,0.0,1.0,0.0,2547.0,2547.0,2547.0,GALS7BLACK,Samsung\nResidential,claroMax15_1,GalaxyS7,32,Gold,0,0,0.0,0.0,0.0,2615.0,2615.0,2615.0,GALS7GOLD,Samsung\nResidential,claroMax15_1,GalaxyS7,32,Gold,12,24,0.0,2.0,0.0,2547.0,2547.0,2547.0,GALS7GOLD,Samsung\nResidential,claroMax15_1,GalaxyS7,32,Gold,24,24,0.0,1.0,0.0,2547.0,2547.0,2547.0,GALS7GOLD,Samsung\nResidential,claroMax15_1,GalaxyS7,32,Rose Gold,0,0,0.0,0.0,0.0,2615.0,2615.0,2615.0,GALS7ROSE,Samsung\nResidential,claroMax15_1,GalaxyS7,32,Rose Gold,12,24,0.0,2.0,0.0,2547.0,2547.0,2547.0,GALS7ROSE,Samsung\nResidential,claroMax15_1,GalaxyS7,32,Rose Gold,24,24,0.0,1.0,0.0,2547.0,2547.0,2547.0,GALS7ROSE,Samsung\nResidential,claroMax15_1,GalaxyS7,32,White,0,0,0.0,0.0,0.0,2615.0,2615.0,2615.0,GALS7WHITE,Samsung\nResidential,claroMax15_1,GalaxyS7,32,White,12,24,0.0,2.0,0.0,2547.0,2547.0,2547.0,GALS7WHITE,Samsung\nResidential,claroMax15_1,GalaxyS7,32,White,24,24,0.0,1.0,0.0,2547.0,2547.0,2547.0,GALS7WHITE,Samsung\nResidential,prepagoTUN,iPhone6s,32,Silver,0,0,0.0,0.0,0.0,2499.0,2499.0,2499.0,IP6S32SILVER,Apple\nResidential,prepagoTUN,iPhone6s,32,Silver,12,24,0.0,2.0,0.0,2403.0,2403.0,2403.0,IP6S32SILVER,Apple\nResidential,prepagoTUN,iPhone6s,32,Silver,24,24,0.0,1.0,0.0,2403.0,2403.0,2403.0,IP6S32SILVER,Apple\nResidential,prepagoTUN,iPhone6s,32,Black,0,0,0.0,0.0,0.0,2499.0,2499.0,2499.0,IP6S32BLACK,Apple\nResidential,prepagoTUN,iPhone6s,32,Black,12,24,0.0,2.0,0.0,2403.0,2403.0,2403.0,IP6S32BLACK,Apple\nResidential,prepagoTUN,iPhone6s,32,Black,24,24,0.0,1.0,0.0,2403.0,2403.0,2403.0,IP6S32BLACK,Apple\nResidential,prepagoTUN,iPhone6s,32,Gold,0,0,0.0,0.0,0.0,2499.0,2499.0,2499.0,IP6S32GOLD,Apple\nResidential,prepagoTUN,iPhone6s,32,Gold,12,24,0.0,2.0,0.0,2403.0,2403.0,2403.0,IP6S32GOLD,Apple\nResidential,prepagoTUN,iPhone6s,32,Gold,24,24,0.0,1.0,0.0,2403.0,2403.0,2403.0,IP6S32GOLD,Apple\nResidential,prepagoTUN,iPhone6s,32,Rose Gold,0,0,0.0,0.0,0.0,2499.0,2499.0,2499.0,IP6S32ROSE,Apple\nResidential,prepagoTUN,iPhone6s,32,Rose Gold,12,24,0.0,2.0,0.0,2403.0,2403.0,2403.0,IP6S32ROSE,Apple\nResidential,prepagoTUN,iPhone6s,32,Rose Gold,24,24,0.0,1.0,0.0,2403.0,2403.0,2403.0,IP6S32ROSE,Apple\nResidential,prepagoTUN,iPhone6s,128,Silver,0,0,0.0,0.0,0.0,2889.0,2889.0,2889.0,IP6S128SILVER,Apple\nResidential,prepagoTUN,iPhone6s,128,Silver,12,24,0.0,2.0,0.0,2805.0,2805.0,2805.0,IP6S128SILVER,Apple\nResidential,prepagoTUN,iPhone6s,128,Silver,24,24,0.0,1.0,0.0,2805.0,2805.0,2805.0,IP6S128SILVER,Apple\nResidential,prepagoTUN,iPhone6s,128,Black,0,0,0.0,0.0,0.0,2889.0,2889.0,2889.0,IP6S128BLACK,Apple\nResidential,prepagoTUN,iPhone6s,128,Black,12,24,0.0,2.0,0.0,2805.0,2805.0,2805.0,IP6S128BLACK,Apple\nResidential,prepagoTUN,iPhone6s,128,Black,24,24,0.0,1.0,0.0,2805.0,2805.0,2805.0,IP6S128BLACK,Apple\nResidential,prepagoTUN,iPhone6s,128,Gold,0,0,0.0,0.0,0.0,2889.0,2889.0,2889.0,IP6S128GOLD,Apple\nResidential,prepagoTUN,iPhone6s,128,Gold,12,24,0.0,2.0,0.0,2805.0,2805.0,2805.0,IP6S128GOLD,Apple\nResidential,prepagoTUN,iPhone6s,128,Gold,24,24,0.0,1.0,0.0,2805.0,2805.0,2805.0,IP6S128GOLD,Apple\nResidential,prepagoTUN,iPhone6s,128,Rose Gold,0,0,0.0,0.0,0.0,2889.0,2889.0,2889.0,IP6S128ROSE,Apple\nResidential,prepagoTUN,iPhone6s,128,Rose Gold,12,24,0.0,2.0,0.0,2805.0,2805.0,2805.0,IP6S128ROSE,Apple\nResidential,prepagoTUN,iPhone6s,128,Rose Gold,24,24,0.0,1.0,0.0,2805.0,2805.0,2805.0,IP6S128ROSE,Apple\nResidential,prepagoTUN,GalaxyS7,32,Silver,0,0,0.0,0.0,0.0,2616.0,2616.0,2616.0,GALS7SILVER,Samsung\nResidential,prepagoTUN,GalaxyS7,32,Silver,12,24,0.0,2.0,0.0,2548.0,2548.0,2548.0,GALS7SILVER,Samsung\nResidential,prepagoTUN,GalaxyS7,32,Silver,24,24,0.0,1.0,0.0,2548.0,2548.0,2548.0,GALS7SILVER,Samsung\nResidential,prepagoTUN,GalaxyS7,32,Black,0,0,0.0,0.0,0.0,2616.0,2616.0,2616.0,GALS7BLACK,Samsung\nResidential,prepagoTUN,GalaxyS7,32,Black,12,24,0.0,2.0,0.0,2548.0,2548.0,2548.0,GALS7BLACK,Samsung\nResidential,prepagoTUN,GalaxyS7,32,Black,24,24,0.0,1.0,0.0,2548.0,2548.0,2548.0,GALS7BLACK,Samsung\nResidential,prepagoTUN,GalaxyS7,32,Gold,0,0,0.0,0.0,0.0,2616.0,2616.0,2616.0,GALS7GOLD,Samsung\nResidential,prepagoTUN,GalaxyS7,32,Gold,12,24,0.0,2.0,0.0,2548.0,2548.0,2548.0,GALS7GOLD,Samsung\nResidential,prepagoTUN,GalaxyS7,32,Gold,24,24,0.0,1.0,0.0,2548.0,2548.0,2548.0,GALS7GOLD,Samsung\nResidential,prepagoTUN,GalaxyS7,32,Rose Gold,0,0,0.0,0.0,0.0,2616.0,2616.0,2616.0,GALS7ROSE,Samsung\nResidential,prepagoTUN,GalaxyS7,32,Rose Gold,12,24,0.0,2.0,0.0,2548.0,2548.0,2548.0,GALS7ROSE,Samsung\nResidential,prepagoTUN,GalaxyS7,32,Rose Gold,24,24,0.0,1.0,0.0,2548.0,2548.0,2548.0,GALS7ROSE,Samsung\nResidential,prepagoTUN,GalaxyS7,32,White,0,0,0.0,0.0,0.0,2616.0,2616.0,2616.0,GALS7WHITE,Samsung\nResidential,prepagoTUN,GalaxyS7,32,White,12,24,0.0,2.0,0.0,2548.0,2548.0,2548.0,GALS7WHITE,Samsung\nResidential,prepagoTUN,GalaxyS7,32,White,24,24,0.0,1.0,0.0,2548.0,2548.0,2548.0,GALS7WHITE,Samsung\nResidential,SIMPLE_SALES_PO,iPhone6s,32,Silver,0,0,0.00,0.00,0.0,2200.0,2200.0,2470.0,IP6S32SILVER,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,32,Silver,12,24,0.00,2.00,0.0,1980.0,1980.0,2402.0,IP6S32SILVER,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,32,Silver,24,24,0.00,1.00,0.0,1980.0,1980.0,2402.0,IP6S32SILVER,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,32,Black,0,0,0.00,0.00,0.0,1690.0,1690.0,2470.0,IP6S32BLACK,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,32,Black,12,24,0.00,2.00,0.0,1980.0,1980.0,2402.0,IP6S32BLACK,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,32,Black,24,24,0.00,1.00,0.0,1980.0,1980.0,2402.0,IP6S32BLACK,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,32,Gold,0,0,0.00,0.00,0.0,1690.0,1690.0,2470.0,IP6S32GOLD,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,32,Gold,12,24,0.00,2.00,0.0,1980.0,1980.0,2402.0,IP6S32GOLD,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,32,Gold,24,24,0.00,1.00,0.0,1980.0,1980.0,2402.0,IP6S32GOLD,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,32,Rose Gold,24,24,0.00,0.00,0.0,1690.0,1690.0,2470.0,IP6S32ROSE,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,32,Rose Gold,24,24,0.00,2.00,0.0,1980.0,1980.0,2402.0,IP6S32ROSE,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,32,Rose Gold,24,24,0.00,1.00,0.0,1980.0,1980.0,2402.0,IP6S32ROSE,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,128,Silver,0,0,0.00,0.00,0.0,2400.0,2400.0,2864.0,IP6S128SILVER,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,128,Silver,12,24,0.00,2.00,0.0,2296.0,2296.0,2796.0,IP6S128SILVER,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,128,Silver,24,24,0.00,1.00,0.0,2296.0,2296.0,2796.0,IP6S128SILVER,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,128,Black,0,0,0.00,0.00,0.0,2400.0,2400.0,2864.0,IP6S128BLACK,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,128,Black,12,24,0.00,2.00,0.0,2296.0,2296.0,2796.0,IP6S128BLACK,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,128,Black,24,24,0.00,1.00,0.0,2296.0,2296.0,2796.0,IP6S128BLACK,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,128,Gold,0,0,0.00,0.00,0.0,2400.0,2400.0,2864.0,IP6S128GOLD,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,128,Gold,12,24,0.00,2.00,0.0,2296.0,2296.0,2796.0,IP6S128GOLD,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,128,Gold,24,24,0.00,1.00,0.0,2296.0,2296.0,2796.0,IP6S128GOLD,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,128,Rose Gold,0,0,0.00,0.00,0.0,2400.0,2400.0,2864.0,IP6S128ROSE,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,128,Rose Gold,12,24,0.00,2.00,0.0,2296.0,2296.0,2796.0,IP6S128ROSE,Apple\nResidential,SIMPLE_SALES_PO,iPhone6s,128,Rose Gold,24,24,0.00,1.00,0.0,2296.0,2296.0,2796.0,IP6S128ROSE,Apple\nResidential,SIMPLE_SALES_PO,GalaxyS7,32,Silver,0,0,0.0,0.0,0.0,2617.0,2617.0,2617.0,GALS7SILVER,Samsung\nResidential,SIMPLE_SALES_PO,GalaxyS7,32,Silver,12,24,0.0,2.0,0.0,2549.0,2549.0,2549.0,GALS7SILVER,Samsung\nResidential,SIMPLE_SALES_PO,GalaxyS7,32,Silver,24,24,0.0,1.0,0.0,2549.0,2549.0,2549.0,GALS7SILVER,Samsung\nResidential,SIMPLE_SALES_PO,GalaxyS7,32,Black,0,0,0.0,0.0,0.0,2617.0,2617.0,2617.0,GALS7BLACK,Samsung\nResidential,SIMPLE_SALES_PO,GalaxyS7,32,Black,12,24,0.0,2.0,0.0,2549.0,2549.0,2549.0,GALS7BLACK,Samsung\nResidential,SIMPLE_SALES_PO,GalaxyS7,32,Black,24,24,0.0,1.0,0.0,2549.0,2549.0,2549.0,GALS7BLACK,Samsung\nResidential,SIMPLE_SALES_PO,GalaxyS7,32,Gold,0,0,0.0,0.0,0.0,2617.0,2617.0,2617.0,GALS7GOLD,Samsung\nResidential,SIMPLE_SALES_PO,GalaxyS7,32,Gold,12,24,0.0,2.0,0.0,2549.0,2549.0,2549.0,GALS7GOLD,Samsung\nResidential,SIMPLE_SALES_PO,GalaxyS7,32,Gold,24,24,0.0,1.0,0.0,2549.0,2549.0,2549.0,GALS7GOLD,Samsung\nResidential,SIMPLE_SALES_PO,GalaxyS7,32,Rose Gold,0,0,0.0,0.0,0.0,2617.0,2617.0,2617.0,GALS7ROSE,Samsung\nResidential,SIMPLE_SALES_PO,GalaxyS7,32,Rose Gold,12,24,0.0,2.0,0.0,2549.0,2549.0,2549.0,GALS7ROSE,Samsung\nResidential,SIMPLE_SALES_PO,GalaxyS7,32,Rose Gold,24,24,0.0,1.0,0.0,2549.0,2549.0,2549.0,GALS7ROSE,Samsung\nResidential,SIMPLE_SALES_PO,GalaxyS7,32,White,0,0,0.0,0.0,0.0,2617.0,2617.0,2617.0,GALS7WHITE,Samsung\nResidential,SIMPLE_SALES_PO,GalaxyS7,32,White,12,24,0.0,2.0,0.0,2549.0,2549.0,2549.0,GALS7WHITE,Samsung\nResidential,SIMPLE_SALES_PO,GalaxyS7,32,White,24,24,0.0,1.0,0.0,2549.0,2549.0,2549.0,GALS7WHITE,Samsung\"]}}";
                        var j = Newtonsoft.Json.JsonConvert.DeserializeObject(x, typeof(InfoTableRecords));


                        successFlag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        public void ECMInfoModelTransfer()
        {
            bool successFlag = false;
            string SoapXmlText = @"<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/'> 
                                    <soapenv:Header/>
                                                       <soapenv:Body>
                                                          <infoModelSearchDS>
                                                             <!--Optional:-->
                                                             <infoModelCode>deviceInfoModel</infoModelCode>
                                                             <!--Optional:-->
                                                             <label>?</label>
                                                          </infoModelSearchDS>
                                                       </soapenv:Body>
                                    </soapenv:Envelope>";

            string BscsApiUri = string.Empty;
            try
            {
                //Get the bascs api uri from crm config
                BscsApiUri = "http://localhost:57004/ecm/services/InfoModelMaintenanceV2?wsdl";

                HttpWebRequest request = CreateWebRequest(BscsApiUri, "ReadInfoModel");
                XmlDocument soapEnvelopeXml = new XmlDocument();
                soapEnvelopeXml.LoadXml(SoapXmlText);
                using (Stream stream = request.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }

                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        string soapResult = rd.ReadToEnd();

                        var y = DeserializeInnerSoapObject<InfoModel>(soapResult);

                        successFlag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        public void ProductOfferingTransferTest()
        {
            var request = "{\"ProductOfferingList\":[{\"ExternalId\":\"PO_TvPosServicioTV_Cv\",\"Name\":\"PO Tv Pos Servicio TV Cv\",\"ProductSpecification\":{\"ExternalId\":\"PS_TvPosServicioTV_CV\",\"Name\":\"PS_TvPosServicioTV_CV\",\"CFSSList\":[{\"ExternalId\":\"CFSS_TvPosServicioTV_CV\",\"Name\":\"CFSS_TvPosServicioTV_CV\",\"ServiceTechnicalType\":\"BASIC\"}],\"ResourceSpecificationList\":[{\"ExternalId\":\"LRS_TvPosServicioTV_CV\",\"Name\":\"LRS Tv Pos Servicio TV CV\",\"ResourceCharacteristicList\":[{\"ExternalId\":\"numberingPlan\",\"Name\":\"Numbering Plan\",\"Editable\":true,\"DataType\":\"Combobox\",\"DefaultValue\":\"E.164\",\"CharacteristicValueList\":[{\"ExternalId\":\"numberingPlan\",\"Value\":\"E.164\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"resourceNumber\",\"Name\":\"Resource Number\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"resourceNumber\",\"IsDefaultValue\":true}]}],\"ResourceType\":\"LogicalResourceSpec\",\"SpecificationSubType\":\"ISDN\"}]},\"CharacteristicList\":[{\"ExternalId\":\"reasonCode\",\"Name\":\"Reason Code\",\"Editable\":true,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"reasonCode\",\"IsDefaultValue\":true}]}],\"ProductTechnicalType\":\"Basic\",\"StartDate\":\"2017-12-12T15:45:00.000Z\",\"IsSellable\":0,\"Description\":\"CBiO Base Product Offering Basic for Charging System\",\"OfferType\":\"Contract\",\"OfferSubType\":\"Television\",\"IsRollback\":0}]}";
            //var request = "{\"ProductOfferingList\":[{\"ExternalId\":\"Test23\",\"Name\":\"Test23\",\"ProductSpecification\":{\"ExternalId\":\"psMobPostConexionMax\",\"Name\":\"psMobPostConexionMax\",\"CFSSList\":[{\"ExternalId\":\"cfssBasicMobPostMassiveCurrentZM\",\"Name\":\"cfssBasicMobPostMassiveCurrentZM\",\"CharacteristicList\":[{\"ExternalId\":\"specificationSubtype\",\"Name\":\"Customer Facing Service Type\",\"Editable\":false,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"specificationSubtype\",\"IsDefaultValue\":true}]}]},{\"ExternalId\":\"cfssMobPostRpcUnlimitedInc\",\"Name\":\"cfssMobPostRpcUnlimitedInc\",\"CharacteristicList\":[{\"ExternalId\":\"CHARGING_ENGINE\",\"Name\":\"Charging Engine\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"CS\",\"CharacteristicValueList\":[{\"ExternalId\":\"CHARGING_ENGINE\",\"Value\":\"CS\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"specificationSubtype\",\"Name\":\"Customer Facing Service Type\",\"Editable\":false,\"DataType\":\"Combobox\",\"DefaultValue\":\"Voice\",\"CharacteristicValueList\":[{\"ExternalId\":\"specificationSubtype\",\"Value\":\"Voice\",\"IsDefaultValue\":true}]}]},{\"ExternalId\":\"cfssMobPostVSDInc_Max\",\"Name\":\"cfssMobPostVSDInc_Max\",\"CharacteristicList\":[{\"ExternalId\":\"CHARGING_ENGINE\",\"Name\":\"Charging Engine\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"ANY\",\"CharacteristicValueList\":[{\"ExternalId\":\"CHARGING_ENGINE\",\"Value\":\"ANY\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"PamIndicatorReactivation\",\"Name\":\"PamIndicatorReactivation\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"2\",\"CharacteristicValueList\":[{\"ExternalId\":\"PamIndicatorReactivation\",\"Value\":\"2\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"PamIndicatorSuspension\",\"Name\":\"PamIndicatorSuspension\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"1\",\"CharacteristicValueList\":[{\"ExternalId\":\"PamIndicatorSuspension\",\"Value\":\"1\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"barData\",\"Name\":\"barData\",\"Editable\":true,\"DataType\":\"Number\",\"DefaultValue\":\"0\",\"CharacteristicValueList\":[{\"ExternalId\":\"barData\",\"Value\":\"0\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"barIncomingMMS\",\"Name\":\"barIncomingMMS\",\"Editable\":true,\"DataType\":\"Number\",\"DefaultValue\":\"0\",\"CharacteristicValueList\":[{\"ExternalId\":\"barIncomingMMS\",\"Value\":\"0\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"barIncomingSMS\",\"Name\":\"barIncomingSMS\",\"Editable\":true,\"DataType\":\"Number\",\"DefaultValue\":\"0\",\"CharacteristicValueList\":[{\"ExternalId\":\"barIncomingSMS\",\"Value\":\"0\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"barIncomingVoice\",\"Name\":\"barIncomingVoice\",\"Editable\":true,\"DataType\":\"Number\",\"DefaultValue\":\"0\",\"CharacteristicValueList\":[{\"ExternalId\":\"barIncomingVoice\",\"Value\":\"0\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"barOutgoingMMS\",\"Name\":\"barOutgoingMMS\",\"Editable\":true,\"DataType\":\"Number\",\"DefaultValue\":\"0\",\"CharacteristicValueList\":[{\"ExternalId\":\"barOutgoingMMS\",\"Value\":\"0\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"barOutgoingSMS\",\"Name\":\"barOutgoingSMS\",\"Editable\":true,\"DataType\":\"Number\",\"DefaultValue\":\"0\",\"CharacteristicValueList\":[{\"ExternalId\":\"barOutgoingSMS\",\"Value\":\"0\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"barOutgoingVoice\",\"Name\":\"barOutgoingVoice\",\"Editable\":true,\"DataType\":\"Number\",\"DefaultValue\":\"0\",\"CharacteristicValueList\":[{\"ExternalId\":\"barOutgoingVoice\",\"Value\":\"0\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"barRoamingData\",\"Name\":\"barRoamingData\",\"Editable\":true,\"DataType\":\"Number\",\"DefaultValue\":\"0\",\"CharacteristicValueList\":[{\"ExternalId\":\"barRoamingData\",\"Value\":\"0\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"barRoamingSMS\",\"Name\":\"barRoamingSMS\",\"Editable\":true,\"DataType\":\"Number\",\"DefaultValue\":\"0\",\"CharacteristicValueList\":[{\"ExternalId\":\"barRoamingSMS\",\"Value\":\"0\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"barRoamingVoice\",\"Name\":\"barRoamingVoice\",\"Editable\":true,\"DataType\":\"Number\",\"DefaultValue\":\"0\",\"CharacteristicValueList\":[{\"ExternalId\":\"barRoamingVoice\",\"Value\":\"0\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"specificationSubtype\",\"Name\":\"Customer Facing Service Type\",\"Editable\":false,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"specificationSubtype\",\"IsDefaultValue\":true}]}]},{\"ExternalId\":\"cfssMobPost_NotInc_Max\",\"Name\":\"cfssMobPost_NotInc_Max\",\"CharacteristicList\":[{\"ExternalId\":\"CHARGING_ENGINE\",\"Name\":\"Charging Engine\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"CS\",\"CharacteristicValueList\":[{\"ExternalId\":\"CHARGING_ENGINE\",\"Value\":\"CS\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"Community1\",\"Name\":\"community1\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"Community1\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"Community2\",\"Name\":\"community2\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"Community2\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"Community3\",\"Name\":\"community3\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"Community3\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"community1\",\"Name\":\"Community1\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"community1\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"community2\",\"Name\":\"Community2\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"community2\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"community3\",\"Name\":\"Community3\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"community3\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"pamIndicatorCreditLimit\",\"Name\":\"pamIndicatorCreditLimit\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"3\",\"CharacteristicValueList\":[{\"ExternalId\":\"pamIndicatorCreditLimit\",\"Value\":\"3\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"shortCode\",\"Name\":\"shortCode\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"shortCode\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"specificationSubtype\",\"Name\":\"Customer Facing Service Type\",\"Editable\":false,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"specificationSubtype\",\"IsDefaultValue\":true}]}]},{\"ExternalId\":\"cfssMobPost_Prepaid_Max\",\"Name\":\"cfssMobPost_Prepaid_Max\",\"CharacteristicList\":[{\"ExternalId\":\"specificationSubtype\",\"Name\":\"Customer Facing Service Type\",\"Editable\":false,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"specificationSubtype\",\"IsDefaultValue\":true}]}]}]},\"CharacteristicList\":[{\"ExternalId\":\"BlackList\",\"Name\":\"BlackList\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"BlackList\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"CreditLimitUsageThreshold_7000\",\"Name\":\"CreditLimitUsageThreshold_7000\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"9999999999999999\",\"CharacteristicValueList\":[{\"ExternalId\":\"CreditLimitUsageThreshold_7000\",\"Value\":\"9999999999999999\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"FAFCount\",\"Name\":\"FAFCount\",\"Editable\":false,\"DataType\":\"Text\",\"DefaultValue\":\"6\",\"CharacteristicValueList\":[{\"ExternalId\":\"FAFCount\",\"Value\":\"6\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"FAFList\",\"Name\":\"FAFList\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"FAFList\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"FAFMode\",\"Name\":\"FAFMode\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"FAFMode\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"FAFPlusCount\",\"Name\":\"FAFPlusCount\",\"Editable\":false,\"DataType\":\"Text\",\"DefaultValue\":\"14\",\"CharacteristicValueList\":[{\"ExternalId\":\"FAFPlusCount\",\"Value\":\"14\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"LDINumber\",\"Name\":\"LDI Number\",\"Editable\":true,\"DataType\":\"Decimal\",\"CharacteristicValueList\":[{\"ExternalId\":\"LDINumber\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"LDNNumber\",\"Name\":\"LDN Number\",\"Editable\":true,\"DataType\":\"Decimal\",\"CharacteristicValueList\":[{\"ExternalId\":\"LDNNumber\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"PrepaidEmptyLimit\",\"Name\":\"PrepaidEmptyLimit\",\"Editable\":true,\"DataType\":\"Combobox\",\"DefaultValue\":\"0.000000\",\"CharacteristicValueList\":[{\"ExternalId\":\"PrepaidEmptyLimit\",\"Value\":\"0.000000\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"reasonCode\",\"Name\":\"Reason Code\",\"Editable\":true,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"reasonCode\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"refillAmount\",\"Name\":\"refillAmount\",\"Editable\":true,\"DataType\":\"Decimal\",\"CharacteristicValueList\":[{\"ExternalId\":\"refillAmount\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"specialCase\",\"Name\":\"specialCase\",\"Editable\":true,\"DataType\":\"Combobox\",\"DefaultValue\":\"claroEmployee\",\"CharacteristicValueList\":[{\"ExternalId\":\"specialCase\",\"Value\":\"claroEmployee\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"specificationSubSubtype\",\"Name\":\"Offer SubType\",\"Editable\":false,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"specificationSubSubtype\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"specificationSubtype\",\"Name\":\"Offer Type\",\"Editable\":false,\"DataType\":\"Combobox\",\"DefaultValue\":\"Product\",\"CharacteristicValueList\":[{\"ExternalId\":\"specificationSubtype\",\"Value\":\"Product\",\"IsDefaultValue\":true}]}],\"POPList\":[{\"ExternalId\":\"CT_FAF_Chg\",\"Value\":\"7\",\"PriceType\":\"One Time\"},{\"ExternalId\":\"ctPam_ResetFU_VSD_Max\",\"Value\":\"0\",\"PriceType\":\"Recurring\"},{\"ExternalId\":\"ctPam_SetMA_Max\",\"Value\":\"0\",\"PriceType\":\"Recurring\"},{\"ExternalId\":\"ctRecMonth\",\"Value\":\"99\",\"PriceType\":\"Recurring\"},{\"ExternalId\":\"ctRecMonthTope\",\"Value\":\"0\",\"PriceType\":\"Recurring\"},{\"ExternalId\":\"ctUSG_Inc_Max_VSD\",\"Value\":\"0\",\"PriceType\":\"Per Use\"},{\"ExternalId\":\"ctUSG_NotInc_Max\",\"Value\":\"0\",\"PriceType\":\"Per Use\"},{\"ExternalId\":\"ctUSG_Prepaid_Max\",\"Value\":\"0\",\"PriceType\":\"Per Use\"}],\"AddonlList\":[{\"AddonExternalId\":\"claroMusica\", \"RelationType\":\"Contains\"},{\"AddonExternalId\":\"claroVASOffers\",\"RelationType\":\"ChangeableTo\"},{\"AddonExternalId\":\"claroVideo\", \"RelationType\":\"Optional\"}],\"OptionalList\":[{\"OptionalExternalId\":\"claroMusica\", \"RelationType\":\"Contains\"},{\"OptionalExternalId\":\"claroVASOffers\",\"RelationType\":\"ChangeableTo\"},{\"OptionalExternalId\":\"claroVideo\", \"RelationType\":\"Optional\"}],\"ProductTechnicalType\":\"Basic\",\"StartDate\":\"2017-10-16\",\"IsSellable\":1,\"OfferType\":\"Product\",\"OfferSubType\":\"Security\",\"Description\":\"This is a description\",\"IsRollback\":false}]}";
            var input = new Dictionary<string, object>()
            {
                {"input", request}
            };

            try
            {
                var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
                var jsonObject = JsonConvert.SerializeObject(input, jsonSerializerSettings);

                var result = WorkflowHelper.PrepareFor<ProductOfferingSync>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        public HttpWebRequest CreateWebRequest(string BscsApiUri, string header)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(BscsApiUri);
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            webRequest.Headers.Add("SOAPAction:" + header);

            string username = "upadmin";
            string password = "upadmin";

            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));

            webRequest.Headers.Add("Authorization", "Basic " + svcCredentials);

            return webRequest;
        }
    }
}
