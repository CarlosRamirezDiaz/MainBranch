using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System.Web.Script.Serialization;
using AmxPeruPSBActivities.TechnicianAppGetResource;
using System.ServiceModel;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model;
using AmxPeruPSBActivities.Business;
namespace AmxPeruPSBActivities.AMXCOLOMBIA.Activities
{

    public sealed class AmxCoTechnicianAppGetResourceActivity : XrmAwareCodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<AmxCoTechnicianAppGetResourceRequest> GetResourceReq { get; set; }
        public InArgument<string> Uri { get; set; }
        public OutArgument<string> Message { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            try
            {
                var req = GetResourceReq.Get(context);
                var uri = Uri.Get(context);
                var Oresponce = AmxCoTechnicianAppGetResourceBusiness.GetResourceInfo(req, uri);
                Message.Set(context, Oresponce);
            }
            catch(Exception ex)
            {
                throw  ex;
            }
        }
    }
}
