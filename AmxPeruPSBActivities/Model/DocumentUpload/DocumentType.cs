using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Model.DocumentUpload
{
    public class DocumentType
    {

        public int CustomerID { get; set; }
        public string TypeDocument { get; set; }
        public string DocumentName { get; set; }
        public byte[] FileDocument { get; set; }
        public List<MetaDataList> ListofMetadta { get; set; }
    }

    public class DocumentTypeList
    {
        public List<DocumentType> Documents { get; set; }
    }
    public class MetaDataList
    {
        public int Country { get; set; }
        public string Value { get; set; }

    }

    public class ResponseDocumentType
    {


        public int CustomerID { get; set; }
        public int DocumentIdOnBase { get; set; }
        public string State { get; set; }
    }
    public class ResponseDocumentTypeList
    {
        public List<ResponseDocumentType> Documents { get; set; }
    }

    public class DocumentUploadRequest : BaseRequest
    {
        public DocumentTypeList DocumentList { get; set; }
        public string Users { get; set; }
    }

    public class  DocumentUploadResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public ResponseDocumentTypeList DocumentId { get; set; }
    }
}
