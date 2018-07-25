using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Microsoft.Xrm.Sdk.Workflow;
using Microsoft.Xrm.Sdk;

namespace AmxWorkflowPlugin
{

    public sealed class GetTomorrowDate : CodeActivity
    {
        [Output("Tomorrow Date")]
        public OutArgument<DateTime> TomorrowDate { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext executionContext)
        {
            try
            {
                TomorrowDate.Set(executionContext, DateTime.Today.AddDays(2).AddMinutes(-1));

            }
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException(ex.Message);
            }
        }
    }
}
