using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmxPeruPSBActivities.Model.OrderCaptureSubmit;
using System.Collections.Generic;
using System.Activities;
using static AmxPeruTest.Helpers.TestHelper;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model.EOC;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Crm.Sdk.Messages;
using AmxPeruPSBActivities.AMXCOLOMBIA.Business.EOC;
using Microsoft.Xrm.Sdk.Client;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class AmxCoEocApiBiTest
    {
        [TestMethod]
        public void EOCBiTest()
        {
            var orderSubmitRequest = new SubmitOrderRequest();

            orderSubmitRequest.createdDate = DateTime.Now.ToString();
            orderSubmitRequest.description = "BI API Consuming Unit Test";
            orderSubmitRequest.run = true;
            orderSubmitRequest.version = 0;

            orderSubmitRequest.orderItems = new System.Collections.Generic.List<OrderItem>();

            var itemAttrs = new System.Collections.Generic.List<Attr>();
            itemAttrs.Add(new Attr
            {
                name = "CrmOrderId",
                value = "ORDMD0000056"
            });

            orderSubmitRequest.orderItems.Add(new OrderItem()
            {
                item = new Item()
                {
                    id = "000",
                    orderType = "ProductOfferingOrder",
                    action = "Add",
                    attrs = itemAttrs,
                    productOffering = new ProductOffering()
                    {
                        id = "PO_IntDatPosServInternet"
                    },
                    //                    relatedEntities = new System.Collections.Generic.List<RelatedEntity>()
                }
            });

            orderSubmitRequest.orderItems.Add(new OrderItem()
            {
                item = new Item()
                {
                    id = "001",
                    orderType = "ProductOfferingOrder",
                    action = "Add",
                    attrs = itemAttrs,
                    productOffering = new ProductOffering()
                    {
                        id = "PO_IntDatPosInternet20"
                    },
                    relatedOrderItems = new System.Collections.Generic.List<RelatedOrderItem>() {new RelatedOrderItem(){
                               role = "ChildOf",
                               reference = "000"
                    } }
                }
            });

            orderSubmitRequest.orderItems.Add(new OrderItem()
            {
                item = new Item()
                {
                    id = "002",
                    orderType = "ProductOfferingOrder",
                    action = "Add",
                    attrs = itemAttrs,
                    productOffering = new ProductOffering()
                    {
                        id = "PO_AccesoHFC"
                    },
                    relatedOrderItems = new System.Collections.Generic.List<RelatedOrderItem>() {new RelatedOrderItem(){
                               role = "ChildOf",
                               reference = "000"
                    } }
                }
            });

            orderSubmitRequest.orderItems.Add(new OrderItem()
            {
                item = new Item()
                {
                    id = "003",
                    orderType = "ProductOfferingOrder",
                    action = "Add",
                    attrs = itemAttrs,
                    productOffering = new ProductOffering()
                    {
                        id = "PO_IntDatPosPtoCableado"
                    },
                    relatedOrderItems = new System.Collections.Generic.List<RelatedOrderItem>() {new RelatedOrderItem(){
                               role = "ChildOf",
                               reference = "000"
                    } }
                }
            });

            orderSubmitRequest.orderItems.Add(new OrderItem()
            {
                item = new Item()
                {
                    id = "003",
                    orderType = "ProductOfferingOrder",
                    action = "Add",
                    attrs = itemAttrs,
                    productOffering = new ProductOffering()
                    {
                        id = "PO_EqCPEHFCR2"
                    },
                    relatedOrderItems = new System.Collections.Generic.List<RelatedOrderItem>() {new RelatedOrderItem(){
                               role = "ChildOf",
                               reference = "000"
                    } }
                }
            });


            var httpCallActivity = new Ericsson.PSB.Workflow.Activities.AmxHttpCall<SubmitOrderRequest, SubmitOrderResponse>();

            var input1 = new Dictionary<string, object>
            {
                { "Uri", @"http://localhost:7005/eoc/bi/"},
                { "Method", "POST" },
                { "TimeoutTicks", "30000" },
                { "RequestParameter", orderSubmitRequest }
            };

            // WorkflowInvoker.Invoke<SubmitOrderRequest>(httpCallActivity, input1);

            var _org = OrganizationProxy.GetOrganizationProxy();
            var eocBiURL = @"http://localhost:7005/eoc/bi/";
            string jsonResponse = string.Empty;
            string error = string.Empty;

            //var amxHTTPCallEOC = new AmxPeruPSBActivities.Common.AmxHTTPCallEOC(_org);

            //var result = amxHTTPCallEOC.RestCall<SubmitOrderRequest>(eocBiURL, orderSubmitRequest, out jsonResponse, out error, "POST");

            //// wait for recording logs
            //var waittask = Task.Delay(10 * 1000);
            //Task.WaitAll(new Task[] { waittask });

            jsonResponse = File.ReadAllText(@"AmxCoEocApiBiTest_SampleFile.txt");

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DateFormatString = "dd/MM/yyyy HH:mm:ss"
            };
            var responseObject = JsonConvert.DeserializeObject<EocBiResponseModel>(jsonResponse, settings);
        }

        [TestMethod]
        public void GetRequiredAppointmentsTest()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();
            var orderCaptureId = new Guid("F25013A2-8616-E811-80ED-FA163E10DFBE");

            var eocBusiness = new EocBiBusiness(_org);

            var eocBIResponse = File.ReadAllText(@"ResponseSampleFiles\AmxCoEocApiBiTest_SampleFile.txt");

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DateFormatString = "dd/MM/yyyy HH:mm:ss"
            };
            var responseObject = JsonConvert.DeserializeObject<EocBiResponseModel>(eocBIResponse, settings);

            var requiredAppointmens = eocBusiness.GetRequiredAppointments(responseObject, orderCaptureId);
        }

        [TestMethod]
        public void EOCBiStressTest()
        {
            var orderCaptures = this.ListLastOrderCaptures();

            var _org = OrganizationProxy.GetOrganizationProxy();
            var eocBiURL = @"http://localhost:7005/eoc/bi/";
            string jsonResponse = string.Empty;
            string error = string.Empty;

            var amxHTTPCallEOC = new AmxPeruPSBActivities.Common.AmxHTTPCallEOC(_org);
            int count = 1;
            foreach (var orderCaptureId in orderCaptures)
            {
                System.Diagnostics.Debug.WriteLine(count++);
                if (count < 0)
                    continue;

                var input = new Dictionary<string, object>()
                {
                    { "OrderCaptureId", orderCaptureId },
                    { "IndividualCustomer", null },
                    { "CorporateCustomer", null },
                    { "ResourceTypeCodes", null }
                };

                var SubmitOrderCaptureResponse = WorkflowHelper.PrepareFor<AmxPeruPSBActivities.Activities.Order.SubmitOrderCapture>(input)
                                .ConfigureFor("connectionString", ConfigurationHelper.URL)
                                .ConfigureXrmDataContext()
                                .Invoke();

                if (SubmitOrderCaptureResponse != null 
                    && SubmitOrderCaptureResponse.Count > 0)
                {
                    var orderSubmitRequest = SubmitOrderCaptureResponse["SubmitRequest"] as SubmitOrderRequest;

                    if (orderSubmitRequest.orderItems.Count <= 0)
                        continue;

                    var successCall = amxHTTPCallEOC.RestCall<SubmitOrderRequest>(eocBiURL, orderSubmitRequest, out jsonResponse, out error, "POST");

                    if (!successCall)
                    {
                        System.Diagnostics.Debug.WriteLine(error);
                        continue;
                    }

                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Include,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                        DateFormatString = "dd/MM/yyyy HH:mm:ss"
                    };
                    var responseObject = JsonConvert.DeserializeObject<EocBiResponseModel>(jsonResponse, settings);

                    System.Diagnostics.Debug.WriteLine(responseObject.description + " - " + responseObject.hasBI.ToString());

                    if (responseObject.hasBI)
                        continue;
                }
            }
            // wait for recording logs
            var waittask = Task.Delay(10 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }


        private List<Guid> ListLastOrderCaptures()
        {
            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_ordercapture"
            };

            query.ColumnSet.AddColumn("etel_ordercaptureid");

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("createdon", ConditionOperator.OnOrAfter, DateTime.Now.Date.AddDays(-15));

            query.AddOrder("createdon", OrderType.Descending);

            var _org = OrganizationProxy.GetOrganizationProxy();
            EntityCollection collection = _org.RetrieveMultiple(query);

            var returnValue = new List<Guid>();

            if (collection == null || collection.Entities.Count == 0)
                return returnValue;

            foreach (var item in collection.Entities)
                returnValue.Add(item.Id);

            return returnValue;
        }

        [TestMethod]
        public void SolutionComponents()
        {
            //perform a retrievemultiple on solutioncomponent entities for the given solution
            RetrieveMultipleRequest rmr = new RetrieveMultipleRequest();
            RetrieveMultipleResponse resp = new RetrieveMultipleResponse();
            QueryExpression query = new QueryExpression()
            {
                EntityName = "solutioncomponent",
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression
                {
                    FilterOperator = LogicalOperator.And,
                    Conditions =
                       {
                           new ConditionExpression
                           {
                               AttributeName = "solutionid",
                               Operator = ConditionOperator.Equal,
                               Values = { "A1459198-88CF-40B5-A59F-C5B3EABC3A6D" }
                           }
                       }
                }
            };

            rmr.Query = query;

            var _org = OrganizationProxy.GetOrganizationProxy();

            resp = (RetrieveMultipleResponse)_org.Execute(rmr);

            //use RemoveSolutionComponentRequest to remove solution elements from solution.
            foreach (var sc in resp.EntityCollection.Entities)
            {
                if (sc.GetAttributeValue<DateTime>("createdon").Date != new DateTime(2018, 1, 31))
                    continue;

                if (sc.GetAttributeValue<EntityReference>("createdby").Id != new Guid("30163661-05A3-E711-80DD-FA163E106136"))
                    continue;

                RemoveSolutionComponentRequest removereq = new RemoveSolutionComponentRequest();
                removereq.SolutionUniqueName = "AMXColombia_Patch_a1459198";

                removereq.ComponentId = sc.GetAttributeValue<Guid>("objectid");
                removereq.ComponentType = sc.GetAttributeValue<OptionSetValue>("componenttype").Value;
                try
                {
                    RemoveSolutionComponentResponse removeresp = (RemoveSolutionComponentResponse)_org.Execute(removereq);
                }
                catch { }
            }
        }
    }
}
