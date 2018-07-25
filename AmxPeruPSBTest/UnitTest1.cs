using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmxPeruPSBActivities.ActivitiesClaroESB;
using AmxPeruPSBWorkflows.ClaroESB;
using System.Threading;
using System.Collections.Generic;
using System.Activities;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            AutoResetEvent syncEvent = new AutoResetEvent(false);
            AutoResetEvent idleEvent = new AutoResetEvent(false);

            Dictionary<string, object> inputs = new Dictionary<string, object>()
            {
                { "bureauURL", "http://localhost:58002/Bureau/V1.0/Rest/GetBureau" },
                { "documentType", 1 },
                { "documentNumber", "666" },
                { "documentIssueDate", new DateTime(1980, 1, 21) },
                { "givenNames", "MATSUI" }
            };

            //Activity wf = new AmxPeruPSBWorkflows.ClaroESB.AmxCoBureau();
            WorkflowApplication wfApp =
        new WorkflowApplication(new AmxPeruPSBWorkflows.ClaroESB.AmxCoBureau(), inputs);

            wfApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
            {
                int Turns = Convert.ToInt32(e.Outputs["Turns"]);
                Console.WriteLine("Congratulations, you guessed the number in {0} turns.", Turns);

                syncEvent.Set();
            };

            wfApp.Run();

        }
    }
}
