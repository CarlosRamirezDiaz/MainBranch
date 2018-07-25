using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using AmxPeruCommonLibrary;
using AmxSoapServicesActivities.StorageMediumSearch;
using System.IO;

namespace AmxSoapServicesActivities.Activities
{

    public sealed class StorageMediumSearchActivity : XrmAwareCodeActivity
    {
        public InArgument<string> Endpoint { get; set; }
        //public OutArgument<string> SIMNumber { get; set; }
        public OutArgument<storageMediumSearchResponse> Response { get; set; }


        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var endPoint = Endpoint.Get(context); // "http://localhost:1010/wsi/services/ws_CIL_7_StorageMediumSearchService.wsdl";
            var username = "ADMX";

            using (var proxy = new AmxPeruGenericProxy<StorageMediumSearchService>(endPoint, username))
            {
                var factory = proxy.Channel;
                var storageMediumSearchRequest = new storageMediumSearchRequest()
                {
                    inputAttributes = new StorageMediumSearch.inputAttributes()
                    {
                        plcodePub = "COLCM",
                        submIdPub = "GSMi",
                        reservation = true,
                        srchCount = "5"
                    },
                    sessionChangeRequest = new StorageMediumSearch.sessionChangeRequest()
                    {
                        values = new StorageMediumSearch.valuesListpartRequest[1] {
                            new StorageMediumSearch.valuesListpartRequest()
                            {
                                key = "BU_ID",
                                value = "2"
                            }
                        }

                    }
                };

                var storageMediumSearchRequest1 = new storageMediumSearchRequest1()
                {
                    storageMediumSearchRequest = storageMediumSearchRequest
                };
                var response = factory.storageMediumSearch(storageMediumSearchRequest1);
                var storageMediumSearchResponse = response.storageMediumSearchResponse;
                if (storageMediumSearchResponse.searchIsComplete && storageMediumSearchResponse.allStoragemediums.Length > 0)
                {
                    context.SetValue(Response, storageMediumSearchResponse);
                }
            }
        }
    }
}
