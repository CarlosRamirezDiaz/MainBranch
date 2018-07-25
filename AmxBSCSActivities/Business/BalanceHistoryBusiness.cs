using Ericsson.PSB.Workflow.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxSoapServicesActivities.Business
{
    public class BalanceHistoryBusiness
    {
        public void ListBalanceHistory(BalanceHistoryRead.balanceHistoryReadRequest request, UserIdentityExtension identityExtension)
        {
            var endPoint = @"http://localhost:9090/wsi/services";

            const string _sessionBU_ID_Key = "BU_ID";
            const string _sessionBU_ID_Value = "2";

            using (var factory = new BSCSServiceProxy<AmxSoapServicesActivities.BalanceHistoryRead.BalanceHistoryReadService>(endPoint, identityExtension.GetIdentity().Name))
            {

                //start to create session change Req
                var _sessionChangeValues = new List<BalanceHistoryRead.valuesListpartRequest>();
                _sessionChangeValues.Add(new BalanceHistoryRead.valuesListpartRequest()
                {
                    key = _sessionBU_ID_Key,
                    value = _sessionBU_ID_Value
                });
                var _sessionChangeReq = new BalanceHistoryRead.sessionChangeRequest();
                _sessionChangeReq.values = _sessionChangeValues.ToArray();

                request.sessionChangeRequest = _sessionChangeReq;

                BalanceHistoryRead.balanceHistoryReadResponse1 response = new BalanceHistoryRead.balanceHistoryReadResponse1();

                try
                {
                    response = factory.Channel.balanceHistoryRead(new BalanceHistoryRead.balanceHistoryReadRequest1()
                    {
                        balanceHistoryReadRequest = request
                    });

                    int x = response.balanceHistoryReadResponse.balances.Count();

                    //List<AmxSoapServicesActivities.Model.ContractsSearchResponse> resp = new List<AmxSoapServicesActivities.Model.ContractsSearchResponse>();
                    for (int i = 0; i < x; i++)
                    {
                        //AmxSoapServicesActivities.Model.ContractsSearchResponse respmsg = new AmxSoapServicesActivities.Model.ContractsSearchResponse();

                        //resp.Add(respmsg);
                    }


                    //return resp;
                }
                catch (Exception ex)
                {
                    //List<AmxSoapServicesActivities.Model.ContractsSearchResponse> resp = new List<AmxSoapServicesActivities.Model.ContractsSearchResponse>();
                    //return resp;
                }
            }
        }
    }
}