using AmxPeruPSBActivities.Activities.Offering;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Model.Case;
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
    public class CreateTaskAndBILOG
    {
        [TestMethod]
        public void CreateTaskAndBILOGSuccess()
        {
            var input = new Dictionary<string, object>()
            {
                {"Channel", "ERMS" },
                { "Subject", "TestSubject" },
                { "Duration","5"},
                {"Description", "sampleDescription" },
                {"ServiceId","ServiceId"},
                {"ScheduledEnd",DateTime.Today},
                {"OwnerName","Niloy"},
                {"OwnerType", "systemuser" },
                { "RegardingType", "contact" },
                { "RegardingColumnName","etel_externalid"},
                {"BIRequired",true},
                {"TaskType","2"},
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.CreateTaskUpdated>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void ReserveResourceInERMSTest()
        {
            //var input = new Dictionary<string, object>()
            //{

            //    {
            //        "orderResourceId", "062B6CAE-CD84-E711-8126-00505601173A"                                        
            //    }
            //};

            var input = new Dictionary<string, object>()
            {
                { "OrderResourceId", new Guid("062B6CAE-CD84-E711-8126-00505601173A") },
                { "PartNumber", "ClaroSimNano" },
                { "ResourceId", "8951100000000070008" }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<ReserveResourceInERMS>(input)
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
