using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;
using System.Web.Script;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using System.Activities;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class AmxCoGetMobileCustomerInfoTest
    {
        [TestMethod]
        public void GetMobileCustomerInfoTest()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();

            var getMobileCustomerInfoBusiness = new AmxPeruPSBActivities.AMXCOLOMBIA.Business.Individual.AmxGetMobileCustomerInfoBusiness(_org);

            var mobileNumber = "11111";

            try
            {
                var response = getMobileCustomerInfoBusiness.GetMobileCustomerInfo(mobileNumber);
            }
            catch (Exception ex)
            { }
        }

        [TestMethod]
        public void GetMobileCustomerInfoFlowTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "mobileNumber", "123456789"  }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.AmxGetMobileCustomerInfo>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}

