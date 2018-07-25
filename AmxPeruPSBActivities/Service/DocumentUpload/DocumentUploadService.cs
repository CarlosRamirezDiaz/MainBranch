using AmxPeruPSBActivities.CargaDocumentoOnBase_V1;
using AmxPeruPSBActivities.Model.DocumentUpload;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Service.DocumentUpload
{
    public class DocumentUploadService
    {

        public DocumentUploadResponse UploadDocument(DocumentUploadRequest docUploadRequest, OrganizationServiceProxy organizationService)
        {
            DocumentUploadResponse objResponse = new DocumentUploadResponse();


            try
            {

                List<CargaDocumentoOnBase_V1.DocumentoRequestType> objList = new List<CargaDocumentoOnBase_V1.DocumentoRequestType>();
                    if(docUploadRequest.DocumentList!=null && docUploadRequest.DocumentList.Documents.Count>0)
                {
                    foreach(var doc in docUploadRequest.DocumentList.Documents)
                    {
                        objList.Add(new CargaDocumentoOnBase_V1.DocumentoRequestType()
                        {
                          documents=new CargaDocumentoOnBase_V1.Documents()
                          {
                              _documentId=doc.CustomerID,
                              _documentName=doc.DocumentName,
                              _description=doc.TypeDocument,
                              
                              
                          },
                          documentsExtension=new CargaDocumentoOnBase_V1.DocumentsExtension()
                          {
                              ///Datatype in req obj byte[] but in service sbyte clarification needed
                             /// _attachFile=doc.FileDocument
                          }
                           ,metadatos=new CargaDocumentoOnBase_V1.AttributeValuePair[]
                           {
                              new CargaDocumentoOnBase_V1.AttributeValuePair()
                              {
                                  name=doc.ListofMetadta.FirstOrDefault().Country.ToString() ,
                                  value =doc.ListofMetadta.FirstOrDefault().Value
                              }
                           }

                        });

                    }


                }
                     

                CargaDocumentoOnBase_V1.CargarDocumentoOnBaseRequestType objMessageType = new CargaDocumentoOnBase_V1.CargarDocumentoOnBaseRequestType()

                {
                    notes = new CargaDocumentoOnBase_V1.Notes()
                    {
                        author = docUploadRequest.Users,
                    },
                    listaDocumentos= objList.ToArray()


                };




                //CargaDocumentoOnBase_V1.CargaDocumentoOnBase objService = new CargaDocumentoOnBase_V1.CargaDocumentoOnBase();
                //CargarDocumentoOnBaseResponseType responseMsgService= objService.cargarDocumentoOnBase(objMessageType);

                Random rnd = new Random();
                objResponse.DocumentId = new ResponseDocumentTypeList()
                {
                    Documents = new List<ResponseDocumentType>() {
                       new ResponseDocumentType()
                       {
                           CustomerID=rnd.Next(20000,30000) ,
                           DocumentIdOnBase= rnd.Next(24444,55555),
                           State ="OK"


                       }

                    }

                };
                objResponse.ResponseCode = "200";
                objResponse.ResponseDescription = "OK";

                return objResponse;
            }
            catch (Exception ex)
            {
                return null;
            }

        }





    }
}
