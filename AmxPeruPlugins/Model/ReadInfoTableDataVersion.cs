﻿//Generated by http://xmltocsharp.azurewebsites.net/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AmxPeruPlugins.Model
{
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


}