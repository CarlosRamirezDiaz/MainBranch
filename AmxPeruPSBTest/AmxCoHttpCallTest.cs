using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmxPeruPSBActivities.Activities.Order;
using AmxPeruPSBActivities.Model.OrderCaptureSubmit;
using System.Activities;
using System.Collections.Generic;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class AmxCoHttpCallTest
    {
        [TestMethod]
        public void httpCallTest()
        {
            var httpCallActivity = new Ericsson.PSB.Workflow.Activities.AmxHttpCall<SubmitOrderRequest, SubmitOrderRequest>();

            var input1 = new Dictionary<string, object>
            {
                { "Uri", @"http://localhost:58002/ListsSarglaft/V1.0/Rest/ConsultLists"},
                { "Method", "PUT" },
                { "TimeoutTicks", "30000" },
                { "RequestParameter", new SubmitOrderRequest(){} }
            };

            WorkflowInvoker.Invoke<SubmitOrderRequest>(httpCallActivity, input1);
        }
    }
}
