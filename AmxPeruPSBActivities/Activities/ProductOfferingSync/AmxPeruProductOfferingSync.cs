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
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

namespace AmxPeruPSBActivities.Activities.ProductOfferingSync
{
    public sealed class AmxPeruProductOfferingSync : XrmAwareCodeActivity
    {
        public InArgument<string> InputString { get; set; }
        public OutArgument<bool> Result { get; set; }
        public OutArgument<string> Message { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                var input =  InputString.Get(context);
                
                //create Product Offering Sync Task

                Entity newSyncTask = new Entity("amxperu_productofferingsync");
                newSyncTask.Attributes["amxperu_name"] = DateTime.Now.ToString() + " - Product Offering Sync Task";
                var syncTaskId = ContextProvider.OrganizationService.Create(newSyncTask);

               // Create Annotation with attachment
                Annotation annotation = new Annotation();
                annotation.FileName = "ProductOfferingSyncTask.txt";
                annotation.MimeType = "text/plain";
                annotation.ObjectId = new EntityReference()
                {
                    LogicalName = "amxperu_productofferingsync",
                    Id = syncTaskId
                };

                ////below code causes annotation invisible
                ////annotation.StepId = "C";
                annotation.Subject = "Product Offering Sync Task" + DateTime.Now.ToString();
                annotation.DocumentBody = Convert.ToBase64String(Encoding.UTF8.GetBytes(input));

                var annotationId = ContextProvider.OrganizationService.Create(annotation);

                //Run WF

                context.SetValue(Result, true);
                context.SetValue(Message, "Success");

            }
            catch (Exception ex)
            {
                context.SetValue(Result, false);
                context.SetValue(Message, "Message : " + ex.Message + "InnerException : " + ex.InnerException + "StackTrace : " + ex.StackTrace + "Exception : " + ex);
            }

        }
    }
}
