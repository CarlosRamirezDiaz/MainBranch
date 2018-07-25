using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Microsoft.Xrm.Sdk.Workflow;
using Microsoft.Xrm.Sdk;

namespace AmxWorkflowPlugin
{

    public sealed class GetTodayDate : CodeActivity
    {
        // Define an activity input argument of type string
        [Output("Today Date")]
        public OutArgument<DateTime> TodayDate { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext executionContext)
        {
            try
            {
                TodayDate.Set(executionContext, DateTime.Today.AddDays(1).AddMinutes(-1));

            }
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException(ex.Message);
            }
        }
    }
}
