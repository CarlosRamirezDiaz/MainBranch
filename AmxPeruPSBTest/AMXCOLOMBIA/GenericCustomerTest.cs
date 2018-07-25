using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using static AmxPeruTest.Helpers.TestHelper;
using System.Collections.Generic;

namespace AmxPeruPSBTest.AMXCOLOMBIA
{
    [TestClass]
    public class GenericCustomerTest
    {
        [TestMethod]
        public void CreateGenericCustomer()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();

            Entity genericCustomer = new Entity
            {
                Id = new Guid("4A7E32EE-3ED9-E711-80E6-FA163E10DFBE"),
                LogicalName = "contact",
                Attributes = new AttributeCollection {

                         new KeyValuePair<string, object>("firstname", "Generic"),
                         new KeyValuePair<string, object>("lastname", "Customer"),
                         new KeyValuePair<string, object>("amxperu_documenttype", new OptionSetValue(1)),
                         new KeyValuePair<string, object>("etel_iddocumentnumber", "0000000000"),
                         new KeyValuePair<string, object>("etel_accountnumber", "IND04956")
                    }
            };

            _org.Create(genericCustomer);
        }
    }
}
