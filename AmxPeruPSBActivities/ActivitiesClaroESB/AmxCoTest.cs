using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace AmxPeruPSBActivities.ActivitiesClaroESB
{

    public sealed class AmxCoTest : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> Name { get; set; }
        public InArgument<string> Surname { get; set; }

        public OutArgument<string> MyOutArg { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            string text1 = Name.Get(context);
            string text2 = context.GetValue(this.Surname);
            MyOutArg.Set(context, "The text is " + text1);

            //Console.WriteLine("My Name is " + text1);
            //Console.WriteLine("My Surname is " + text2);
        }
    }
}
