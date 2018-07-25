using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Newtonsoft.Json;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Activities
{
    public class AMXClaroESBLogActivity : XrmAwareCodeActivity
    {
        public InArgument<string> Url { get; set; }
        public InArgument<bool> IsSuccess { get; set; }
        public InArgument<long> ElapsedTime { get; set; }
        public InArgument<Object> RequestStr { get; set; }
        public InArgument<Object> ResponseStr { get; set; }
        public InArgument<string> ErrorStr { get; set; }
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var logRepository = new AmxCoPSBActivities.Repository.ClaroESBLogRepository(ContextProvider.OrganizationService);
            var jsonRequestString = JsonConvert.SerializeObject(RequestStr.Get(context), Formatting.Indented);
            var jsonResposeString = JsonConvert.SerializeObject(ResponseStr.Get(context), Formatting.Indented);
            logRepository.Create(Url.Get(context), IsSuccess.Get(context), ElapsedTime.Get(context),
                jsonRequestString, jsonResposeString, ErrorStr.Get(context));
        }
    }
}
