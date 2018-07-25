using AmxPeruPSBActivities.AMXCOLOMBIA.Activities.BillCycleChange;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class BillCycleChangeSubmitEOCTest
    {
        [TestMethod]
        public void SubmitEOCToBillCycleChange()
        {
            var input = new Dictionary<string, object>()
            {
                { "BillCycleChangeEOCRequest",
                    new AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle.BillCycleChangeEOCRequest
                    {
                       createdDate = DateTime.Now,  //"2018-02-19T07:04:26.917Z",
                       version = 1,
                       requestedCompletionDate= DateTime.Now, //"2018-03-19T07=04=26.917Z",
                       description = "Add CCOI for change Bill Cycle",
                       relatedParties = new RelatedParty
                       {
                            reference = 220,
                            role="Customer,"
                       },
                       relatedEntities = new RelatedEntity
                       {
                            reference = "",
                            type = ""
                       },
                       orderItems = new OrderItems
                       {
                            item = new Item
                            {
                                action = "omCBIOBillCyclePOOIAction",
                                orderType="CustomerChangeOrder",
                                attrs = new List<Attributes>
                                {
                                    new Attributes
                                    {
                                         name = "BillCycleId #05",
                                         value = "05"
                                    },
                                    new Attributes
                                    {
                                        name = "Billcycle #20",
                                         value = "20"
                                    }
                                },
                            }
                       },
                       run = true
                    }
                },
                 { "BILogSchemaRequest",
                    new AmxPeruPSBActivities.AMXCOLOMBIA.Model.BI_Log.BILogSchema
                    {
                        Subject = "Modify Bill Cycle",
                       Description = "Bill Cycle Modified successfully",
                       Channel = "Call Center",
                       BillCycleChangeRecordGuid = new Guid("951FA34B-E61A-E811-80ED-FA163E10DFBE"),
                       LoggedInUserId = new Guid("10B5BFC4-5A00-E811-80ED-FA163E10DFBE"),
                       CustomerId = new Guid("5CA0DA3A-6912-E811-80ED-FA163E10DFBE")

                    }
                }

            };

            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxCoSubmitBillCycleChangeToEOC>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.CRMDEVURL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
