using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruCommonLibrary;
using Ericsson.PSB.Workflow.Client.Core;
using AmxPeruCommonLibrary.ServiceContracts.Model;

namespace AmxPeruPSBActivities.Activities
{
    public class ProductCfsReadServiceActivity : XrmAwareCodeActivity
    {
        public InArgument<string> EndPoint { get; set; }

        public InArgument<string> ContractId { get; set; }

        public OutArgument<productCfsReadResponse1> productresponse { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var endPoint = EndPoint.Get(context);
            var contractId = ContractId.Get(context);

            const string _sessionBU_ID_Key = "BU_ID";
            const string _sessionBU_ID_Value = "2";

            var identityExtension = context.GetExtension<UserIdentityExtension>();

            using (var factory = new AmxPeruGenericProxy<ProductCfsReadService>(endPoint, identityExtension.GetIdentity().Name))
            {
                var _inputAttr = new inputAttributes()
                {
                    productCfsReadInputDTO = new productCfsReadInputDTO()
                    {
                        contractIdPub = contractId                        
                    }
                };


                var _sessionChangeReq = new sessionChangeRequest();
                var _sessionChangeValues = new List<valuesListpartRequest>();
                _sessionChangeValues.Add(new valuesListpartRequest()
                {
                    key = _sessionBU_ID_Key,
                    value = _sessionBU_ID_Value
                });
                _sessionChangeReq.values = _sessionChangeValues.ToArray();

                var request = new productCfsReadRequest();
                request.inputAttributes = _inputAttr;

                request.sessionChangeRequest = _sessionChangeReq;


                var response = factory.Channel.productCfsRead(new productCfsReadRequest1()
                {
                    productCfsReadRequest = request
                });
                productresponse.Set(context, response);
                //  response
                // foreach (var p in response.productCfsReadResponse.productCfsReadOutputDTO.products)


            }
        }
    }
}
