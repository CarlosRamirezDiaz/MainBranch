using AmxPeruPSBActivities.Model.ConsultaDocumentoOnBase;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.External
{
    public class ConsultaDocumentoOnBase : XrmAwareCodeActivity
    {
        public InArgument<string> DocumentId { get; set; }

        public OutArgument<AMXPeruConsultaDocumentoOnBaseResponse> responseModel { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            #region Local Variables
            var _request = DocumentId.Get(context);
            var _serviceRequestObj = new ConsultaDocumentoOnBase_V1.consultarDocumentoOnBaseRequestType();
            var _serviceResponseObj = new ConsultaDocumentoOnBase_V1.consultarDocumentoOnBaseResponseType();
            AMXPeruConsultaDocumentoOnBaseResponse returnModel = new AMXPeruConsultaDocumentoOnBaseResponse();
            #endregion

            #region Assign request parameters
            _serviceRequestObj.adjustmentDocuments = new ConsultaDocumentoOnBase_V1.adjustmentDocuments()
            {
                documentId = _request
            };
            #endregion

            #region Call external service
            try
            {
                ConsultaDocumentoOnBase_V1.consultarDocumentoOnBaseSOAP _client =
                    new ConsultaDocumentoOnBase_V1.consultarDocumentoOnBaseSOAP();
                _serviceResponseObj = _client.consultarDocumentoOnBase(_serviceRequestObj);
            }
            catch
            {
                byte[] arr = Encoding.ASCII.GetBytes("Sample document mock data"); //System.IO.File.ReadAllBytes(@"c:\temp\test.txt");


                if (_serviceResponseObj is null)
                    _serviceResponseObj = new ConsultaDocumentoOnBase_V1.consultarDocumentoOnBaseResponseType();

                // Prepare mock data
                _serviceResponseObj.documentsExtension = new ConsultaDocumentoOnBase_V1.DocumentsExtension()
                {
                    _outputFile = arr
                };
                _serviceResponseObj.responseStatus = new ConsultaDocumentoOnBase_V1.ResponseStatus()
                {
                    code = "1",
                    message = "Mock Data",
                    status = "success"
                };
            }
            #endregion

          
                #region Assign response parameters
                returnModel.documento = _serviceResponseObj.documentsExtension._outputFile;
                returnModel.codigoRespuesta = _serviceResponseObj.responseStatus.code;
                returnModel.descripcionRespuesta = _serviceResponseObj.responseStatus.message;
            #endregion


            #region Set response object
            responseModel.Set(context, returnModel);
                #endregion
           
        }
    }
}
