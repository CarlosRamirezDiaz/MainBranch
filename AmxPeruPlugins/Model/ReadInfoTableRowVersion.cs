﻿//Generated by http://xmltocsharp.azurewebsites.net/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AmxPeruPlugins.Model
{
    [XmlRoot(ElementName = "data")]
    public class Data2
    {
        [XmlElement(ElementName = "columnName")]
        public string ColumnName { get; set; }
        [XmlElement(ElementName = "columnValue")]
        public string ColumnValue { get; set; }
    }

    [XmlRoot(ElementName = "infoTableRows")]
    public class InfoTableRows2
    {
        [XmlElement(ElementName = "versionId")]
        public string VersionId { get; set; }
        [XmlElement(ElementName = "code")]
        public string Code { get; set; }
        [XmlElement(ElementName = "infoTableCode")]
        public string InfoTableCode { get; set; }
        [XmlElement(ElementName = "data")]
        public List<Data2> Data { get; set; }
        [XmlElement(ElementName = "cancel")]
        public string Cancel { get; set; }
    }

    [XmlRoot(ElementName = "labelTranslations")]
    public class LabelTranslations3
    {
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
        [XmlElement(ElementName = "language")]
        public string Language { get; set; }
    }

    [XmlRoot(ElementName = "descriptionTranslations")]
    public class DescriptionTranslations2
    {
        [XmlElement(ElementName = "text")]
        public string Text { get; set; }
        [XmlElement(ElementName = "language")]
        public string Language { get; set; }
    }

    [XmlRoot(ElementName = "infoTable")]
    public class InfoTable2
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
        [XmlElement(ElementName = "infoTableCode")]
        public string InfoTableCode { get; set; }
        [XmlElement(ElementName = "label")]
        public string Label { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "infoTableRows")]
        public List<InfoTableRows2> InfoTableRows { get; set; }
        [XmlElement(ElementName = "labelTranslations")]
        public LabelTranslations3 LabelTranslations { get; set; }
        [XmlElement(ElementName = "descriptionTranslations")]
        public DescriptionTranslations2 DescriptionTranslations { get; set; }
    }

    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body3
    {
        [XmlElement(ElementName = "infoTable")]
        public InfoTable2 InfoTable { get; set; }
    }

    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope3
    {
        [XmlElement(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public string Header { get; set; }
        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Body3 Body { get; set; }
        [XmlAttribute(AttributeName = "soapenv", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Soapenv { get; set; }
    }

}
