﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
//using AmxPeruPSBActivities.Model.Eligibility;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Helpers;
using Microsoft.Xrm.Sdk.Query;

namespace AmxPeruPSBActivities.Activities.Eligibility
{

    public sealed class ApplyEligibilityRule : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> Text { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            string text = context.GetValue(this.Text);
        }

    }
}
