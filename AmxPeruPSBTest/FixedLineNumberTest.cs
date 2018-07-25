using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static AmxPeruTest.Helpers.TestHelper;
using AmxPeruPSBWorkflows;
using AmxPeruPSBActivities.Activities.LinePortability;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class FixedLineNumberTest
    {
        [TestMethod]
        public void FixedLineNumberService()
        {
            try
            {
                var input = new Dictionary<string, object>()
                {
                    { "addressId", "6b31f523-7910-e811-80ed-fa163e10dfbe"},
                    { "customerId", "FD042196-7810-E811-80ED-FA163E10DFBE" },
                    { "endPoint" , "http://localhost:58002/NetCracker/V1.0" },
                    { "numberToBeReleased" , "5713931687" },
                    { "numberToBeReserved" , "5713931686" },
                    { "serviceType" , "getNumbers" }
                };
                var result = WorkflowHelper.PrepareFor<FixedLineNumberService>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .ConfigureXrmDataContext()
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void RetrievePhoneNumberActivity()
        {
            try
            {
                var input = new Dictionary<string, object>()
                {
                    { "AddressId", "112fe807-f70f-e811-80ed-fa163e10dfbe"},
                    { "CustomerId", "5E41E6B6-F4BF-E711-80E5-FA163E10DFBE" },
                    { "EndPoint" , "http://localhost:58002/NetCracker/V1.0" },
                    { "OrderItemId" , "4850f4e9-682b-e811-80ef-fa163e10dfbe" }
                };
                var result = WorkflowHelper.PrepareFor<RetrievePhoneNumberActivity>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .ConfigureXrmDataContext()
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void ReservePhoneNumberActivity()
        {
            try
            {
                var input = new Dictionary<string, object>()
                {
                    { "AddressId", "112fe807-f70f-e811-80ed-fa163e10dfbe"},
                    { "CustomerId", "5E41E6B6-F4BF-E711-80E5-FA163E10DFBE" },
                    { "EndPoint" , "http://localhost:58002/NetCracker/V1.0" },
                    { "NumberToBeReleased" , "5713939132" },
                    { "NumberToBeReserved" , "5713939135" },
                    { "OrderItemId" , "4850f4e9-682b-e811-80ef-fa163e10dfbe" }
                };
                var result = WorkflowHelper.PrepareFor<ReservePhoneNumberActivity>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .ConfigureXrmDataContext()
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
