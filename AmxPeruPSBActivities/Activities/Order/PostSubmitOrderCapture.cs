using AmxPeruPSBActivities.Model.OrderCaptureSubmit;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AmxPeruPSBActivities.Activities.Order
{
    public class PostSubmitOrderCapture : XrmAwareCodeActivity
    {
        public InArgument<Guid> OrderCaptureId { get; set; }
        //public InArgument<string> EocErrosReason { get; set; }
        public InArgument<string> EOCId { get; set; }
        public OutArgument<string> CrmSubscriptionStatus { get; set; }

        List<Guid> listOfSubscriptionCreated = new List<Guid>();

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                Guid orderCaptureId = OrderCaptureId.Get(context);
                string eocResponseId = EOCId.Get(context);
                //string eocErrorResponse = EocErrosReason.Get(context);

                if (!string.IsNullOrEmpty(eocResponseId))
                {

                    string path = @"c:\tcrm\logs\earande.txt";
                    System.IO.FileStream fs = null;
                    if (File.Exists(path))
                    { fs = File.Open(path, FileMode.Append); }
                    else { fs = File.Create(path); }

                    Microsoft.Xrm.Sdk.Entity orderCaptureRecord = new Microsoft.Xrm.Sdk.Entity("etel_ordercapture");
                    orderCaptureRecord.Id = orderCaptureId;
                    orderCaptureRecord.Attributes.Add("etel_externalorderid", eocResponseId);
                    ContextProvider.OrganizationService.Update(orderCaptureRecord);
                    fs.Write(Encoding.ASCII.GetBytes("\r\n SET EXTERNAL AND STATUS OK 1!!"), 0, "\r\n SET EXTERNAL AND STATUS OK 1!!".Length);

                    SetStateRequest _SetStateRequest = new SetStateRequest
                    {
                        EntityMoniker = new EntityReference("etel_ordercapture", orderCaptureId),
                        State = new OptionSetValue(0),
                        Status = new OptionSetValue(831260009) //Submitted
                    };
                    ContextProvider.OrganizationService.Execute(_SetStateRequest);

                    fs.Write(Encoding.ASCII.GetBytes("\r\n SET EXTERNAL AND STATUS OK 2!!"), 0, "\r\n SET EXTERNAL AND STATUS OK 2!!".Length);
                    fs.Write(Encoding.ASCII.GetBytes("\r\n"), 0, "\r\n".Length);
                    fs.Close();
                }
                CrmSubscriptionStatus.Set(context, "success");
            }
            catch (Exception ex)
            {
                throw new Exception("PostSubmit EOC Error" + ex.Message);
            }
        }
    }
}