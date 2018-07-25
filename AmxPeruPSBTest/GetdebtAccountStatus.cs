
using ExternalApiWorkflows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class GetdebtAccountStatus
    {

        //[TestMethod]
        //public void GetStatusofdebtAccount()
        //{
            

        //    var input = new Dictionary<string, object>()
        //    {
        //       { "request",
        //            new AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountRequest
        //            {
        //                AplicationId ="00838",
        //                CustomerExternalId="884847",
        //                CustomerType=676,
        //                DocumentId="9888" ,
        //                DocumentNumber="89977" ,
        //                UserApplication="77665",
        //                Channel="yfdfdrsdg"
        //            }

        //            }
        //    };

        //    try
        //    {

        //        var result = WorkflowHelper.PrepareFor<GetDebtAccountStatus>(input)
        //                    .ConfigureFor("connectionString", ConfigurationHelper.URL)
        //                    .ConfigureXrmDataContext()
        //                    .Invoke();
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //}

        [TestMethod]
        public void GetCustomerSubscription()
        {


            //{"request":{"$type":"ExternalApiActivities.Models.CustomerSubscriptionsRequestModel, ExternalApiActivities","customerId":"IND00001","startDate":"/Date(1497166098000)/","endDate":"/Date(1505114898000)/","orgTimezoneOffset":0,"languagecode":"1033"}}

            var input = new Dictionary<string, object>()
            {
               { "request",
                    new ExternalApiActivities.Models.CustomerSubscriptionsRequestModel
                    {
                       customerId="IND00001",
                                                                  startDate = DateTime.Now.AddMonths(-3),
                                                                  endDate =                  DateTime.Now,
                                                                  orgTimezoneOffset = 0,
                                                                  languagecode = "1033"
                    }

                    }
            };


            try
            {

                //var result = WorkflowHelper.PrepareFor<RetrieveCustomerSubscriptions>(input)
                //            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                //            .ConfigureXrmDataContext()
                //            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
