using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Business;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Crm.Sdk.Messages;
using System.IO;

namespace AmxPeruPSBActivities.Activities
{
    public sealed class AmxPeruBulkIndividualCreation : XrmAwareCodeActivity
    {
        public InArgument<AmxPeruBulkIndividualCreationRequest> inputObject { get; set; }
        public OutArgument<AmxPeruBulkIndividualCreationResponse> outputObject { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AmxPeruBulkIndividualCreationResponse __AmxperuBulkIndividualCreationResponse = null;
            try
            {

                var input = inputObject.Get(context);
                AmxPeruBulkIndividualCreationBusiness _AmxPeruBulkIndividualCreationBusiness = new AmxPeruBulkIndividualCreationBusiness();
                __AmxperuBulkIndividualCreationResponse = new AmxPeruBulkIndividualCreationResponse();
                //  __AmxperuBulkIndividualCreationResponse = _AmxPeruBulkIndividualCreationBusiness.(inputObject.Get(context), ContextProvider.OrganizationService);
                var result = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = "annotation",
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression
                    {
                        Conditions =
                      {
                          new ConditionExpression
                          (
                              "objectid", ConditionOperator.Equal,input.OrderCaptureID
                          )
                      }
                    }
                }
                  );
                if (result.Entities.Count == 0)
                {

                    List<Annotation> annotations = _AmxPeruBulkIndividualCreationBusiness.CreateMultipleAnnotationFromFile(input.OrderCaptureID, input.EncodedFile);
                    // update parent bulk order capture               
                    var bulkImport = (etel_ordercapture)ContextProvider.OrganizationService.Retrieve(etel_ordercapture.EntityLogicalName, input.OrderCaptureID, new ColumnSet(true));
                    if (bulkImport != null)
                    {
                        bulkImport.etel_hasattachment = true;
                        ContextProvider.OrganizationService.Update(bulkImport);

                        var request = new SetStateRequest
                        {
                            EntityMoniker = new Microsoft.Xrm.Sdk.EntityReference(etel_ordercapture.EntityLogicalName, input.OrderCaptureID),
                            State = new Microsoft.Xrm.Sdk.OptionSetValue(1),
                            Status = new Microsoft.Xrm.Sdk.OptionSetValue(2)

                        };
                    }
                    string fileExtension = ""; // System.IO.Path.GetExtension(input.FileName);
                    string fileNameWithoutExtension = ""; // Path.GetFileNameWithoutExtension(input.FileName);
                    // create annotations (trigger WF)
                    for (int i = 0; i < annotations.Count; i++)
                    {
                        annotations[i].FileName = string.Format("{0}_part{1}{2}", fileNameWithoutExtension, i, fileExtension);
                        annotations[i].MimeType = input.MimeType;
                        //  annotations[i].MimeType = "application/csv";
                        ContextProvider.OrganizationService.Create(annotations[i]);
                    }
                    __AmxperuBulkIndividualCreationResponse.Error = "Bulk Order Request has been initiated successfully";
                    __AmxperuBulkIndividualCreationResponse.Status = "True";

                }
                else if (result.Entities.Count != 0)
                {
                    __AmxperuBulkIndividualCreationResponse.Error = "Order Submit failed";
                    __AmxperuBulkIndividualCreationResponse.Status = "false";
                }

                context.SetValue(outputObject, __AmxperuBulkIndividualCreationResponse);

            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }
   
}
