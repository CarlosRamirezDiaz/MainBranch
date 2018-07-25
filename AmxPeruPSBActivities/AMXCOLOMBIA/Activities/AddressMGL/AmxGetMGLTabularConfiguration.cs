using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;

namespace AmxPeruPSBActivities.AMXCOLOMBIA
{
    public class AmxGetMGLTabularConfiguration : XrmAwareCodeActivity
    {
        #region Input/Output Arguments
        public InArgument<string> TipoRed { get; set; }
        public InArgument<string> HeaderRequestStr { get; set; }
        public InArgument<string> MGLUser { get; set; }
        public InArgument<string> HostUrl { get; set; }
        public OutArgument<string> MGLConfigurationResponse { get; set; }

        #endregion
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var tipoRed = TipoRed.Get(context);
            string jsonResponseStr = null;
            if (tipoRed != null)
            {
                jsonResponseStr = new AmxGetCustomerAddressBusiness()
                    .GetMGLTabularConfiguration(tipoRed, MGLUser.Get(context), HostUrl.Get(context), HeaderRequestStr.Get(context), ContextProvider.OrganizationService);
            }
            MGLConfigurationResponse.Set(context, jsonResponseStr);
        }
    }
}
