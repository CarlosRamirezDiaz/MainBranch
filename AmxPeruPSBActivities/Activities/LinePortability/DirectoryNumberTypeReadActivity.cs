using AmxPeruCommonLibrary;
using AmxPeruCommonLibrary.ServiceContracts.Model;
using AmxPeruCommonLibrary.ServiceContracts.Services;
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
    public class DirectoryNumberTypeReadActivity : XrmAwareCodeActivity
    {

        public InArgument<string> EndPoint { get; set; }
        public InArgument<string> LineNumber { get; set; }

        public OutArgument<GenericDirectoryNumberReadResponseModel> LineNumberTypeResponse { get; set; }


        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var endPoint = EndPoint.Get(context);
            var lineNumber = LineNumber.Get(context);
            var identityExtension = context.GetExtension<UserIdentityExtension>();

            const string _npCodePub = "E.164";
            const string _sessionBU_ID_Key = "BU_ID";
            const string _sessionBU_ID_Value = "2";

            using (var factory = new AmxPeruGenericProxy<GenericDirectoryNumberReadService>(endPoint, identityExtension.GetIdentity().Name))
            {
                //create input Attr
                var _inputAttr = new inputAttributes()
                {
                    dirnum = lineNumber,
                    npcodePub = _npCodePub
                };
                // end create input Attr

                //start to create session change Req
                var _sessionChangeReq = new sessionChangeRequest();
                var _sessionChangeValues = new List<valuesListpartRequest>();
                _sessionChangeValues.Add(new valuesListpartRequest()
                {
                    key = _sessionBU_ID_Key,
                    value = _sessionBU_ID_Value
                });
                _sessionChangeReq.values = _sessionChangeValues.ToArray();
                //end create session change req

                //create whole request
                var request = new genericDirectoryNumberReadRequest1();
                request.genericDirectoryNumberReadRequest = new genericDirectoryNumberReadRequest();
                request.genericDirectoryNumberReadRequest.inputAttributes = _inputAttr;
                request.genericDirectoryNumberReadRequest.sessionChangeRequest = _sessionChangeReq;

                try
                {
                    var response = factory.Channel.genericDirectoryNumberRead(request);
                    if (response.genericDirectoryNumberReadResponse != null)
                    {
                        var modelResponse = new GenericDirectoryNumberReadResponseModel();
                        modelResponse.dnStatus = response.genericDirectoryNumberReadResponse.dnStatus;
                        modelResponse.dirnum = response.genericDirectoryNumberReadResponse.dirnum;
                        LineNumberTypeResponse.Set(context, modelResponse);
                    }



                }
                catch (System.ServiceModel.FaultException faultException)
                {
                    //this fault for directory number is not found
                    LineNumberTypeResponse.Set(context, new GenericDirectoryNumberReadResponseModel()
                    {
                        dnStatus = "NotClaro",
                        dirnum = lineNumber
                    });
                }

            };
        }
    }
}
