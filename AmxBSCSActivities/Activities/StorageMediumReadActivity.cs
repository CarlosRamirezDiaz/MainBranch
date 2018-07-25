using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using AmxSoapServicesActivities.StorageMediumRead;
using AmxPeruCommonLibrary;

namespace AmxSoapServicesActivities.Activities
{

    public sealed class StorageMediumReadActivity : XrmAwareCodeActivity
    {
        public InArgument<long> SmId { get; set; }
        public InArgument<string> Endpoint { get; set; }
        public OutArgument<storageMediumReadOutputDTO> Response { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var id = SmId.Get(context);
            var endPoint = Endpoint.Get(context);
            var username = "ADMX";

            using (var proxy = new AmxPeruGenericProxy<StorageMediumReadService>(endPoint, username))
            {
                var factory = proxy.Channel;

                var storageMediumReadRequest = new storageMediumReadRequest()
                {
                    inputAttributes = new StorageMediumRead.inputAttributes()
                    {
                        storageMediumReadInputDTO = new storageMediumReadInputDTO()
                        {
                            id = id
                        }
                    },
                    sessionChangeRequest = new StorageMediumRead.sessionChangeRequest()
                    {
                        values = new StorageMediumRead.valuesListpartRequest[1] {
                            new StorageMediumRead.valuesListpartRequest()
                            {
                                key = "BU_ID",
                                value = "2"
                            }
                        }
                    }
                };

                var storageMediumReadRequest1 = new storageMediumReadRequest1()
                {
                    storageMediumReadRequest = storageMediumReadRequest
                };

                var response = factory.storageMediumRead(storageMediumReadRequest1);

                var storageMediumReadResponse = response.storageMediumReadResponse;

                context.SetValue(Response, storageMediumReadResponse.storageMediumReadOutputDTO);
            }
        }
    }
}
