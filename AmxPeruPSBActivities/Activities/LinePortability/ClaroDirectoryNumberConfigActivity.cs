using AmxPeruCommonLibrary;
using AmxPeruCommonLibrary.BssServiceConfigMgmt;
using AmxPeruPSBActivities.Model.DirectoryNumberRead;
using Ericsson.ETELCRM.Entities.Crm;
using Ericsson.PSB.Workflow.Client.Core;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.LinePortability
{
    public class ClaroDirectoryNumberConfigActivity : XrmAwareCodeActivity
    {

        public InArgument<string> EndPoint { get; set; }
        public InArgument<List<string>> LineNumberList { get; set; }
        public InArgument<string> CurrentCarrier { set; get; }
        public InArgument<string> CurrentPlan { set; get; }
        public InArgument<string> ServiceType { set; get; }

        public OutArgument<List<ClaroDirectoryNumberConfigResponseModel>> LineNumberTypeResponse { get; set; }


        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var endPoint = EndPoint.Get(context);
            var lineNumbers = LineNumberList.Get(context);
            var identityExtension = context.GetExtension<UserIdentityExtension>();


            using (var factory = new AmxPeruGenericProxy<ServiceConfigMgmtLgPortChannel>(endPoint, identityExtension.GetIdentity().Name))
            {
                //return sample response to client
                var response = new List<ClaroDirectoryNumberConfigResponseModel>();
                for (int i = 0; i < lineNumbers.Count; i++)
                {
                    try
                    {
                        response.Add(new ClaroDirectoryNumberConfigResponseModel()
                        {
                            PhoneNumber = lineNumbers[i],
                            Provider = "Claro",
                            Status = (i % 2) == 0 ? "Successfull" : "PendingPayment"
                        });
                    }
                    catch (Exception ex)
                    {
                        //this fault for directory number is not found
                        response.Add(new ClaroDirectoryNumberConfigResponseModel()
                        {
                            PhoneNumber = lineNumbers[i],
                            Provider = "Claro",
                            Status = "Error From Claro Servis"
                        });
                    }
                }
                LineNumberTypeResponse.Set(context, response);
            };
        }
    }
}
