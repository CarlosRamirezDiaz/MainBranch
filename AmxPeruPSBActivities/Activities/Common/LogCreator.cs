using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.IO;

namespace AmxPeruPSBActivities.Activities.Common
{

    public sealed class LogCreator : CodeActivity
    {
        public InArgument<string> Log { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string log = context.GetValue(this.Log);
            StreamWriter writer = new StreamWriter(@"C:\tcrm\logs\LogActivity.txt");
            writer.WriteLine(log + " / " + DateTime.Now);
            writer.Close();
        }
    }

}
