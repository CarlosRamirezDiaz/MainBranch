using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxWorkflowPlugin
{
    public sealed partial class GetPreviousDayDateTime : CodeActivity
    {
        [Input("Current Date")]
        public InArgument<DateTime> CurrentDate { get; set; }
        [Input("Previous Day Time")]
        public InArgument<string> PreviousDayTime { get; set; }
        [Output("Response Date")]
        public OutArgument<DateTime> ResponseDate { get; set; }
        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
            try
            { 
                var currentDate = CurrentDate.Get(executionContext);
                var previousDayTime = PreviousDayTime.Get(executionContext);
                var responseDate = SetHoursMinutes(previousDayTime, currentDate);
                ResponseDate.Set(executionContext, responseDate);

            }
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException(ex.Message);
            }
        }

        private DateTime SetHoursMinutes(string previousDayTime, DateTime currentDate)
        {
            DateTime date = new DateTime();
            int hours = 0; int minutes = 0;
            var dateStringArray = previousDayTime.Split(':');
            hours = dateStringArray.Length > 0 ? Convert.ToInt32(dateStringArray[0]) : 0;
            minutes = dateStringArray.Length > 1 ? Convert.ToInt32(dateStringArray[1]) : 0;
            date = currentDate.AddDays(-1).AddHours(0).AddMinutes(0);
            date = new DateTime(date.Year, date.Month, date.Day, hours, minutes, 0);
            return date;
        }
    }
}

