using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities
{
   public sealed class AmxPeruValidaDireccion : XrmAwareCodeActivity
    {
        public InArgument<AMxperuValidaDireccionRequest> inputObject { get; set; }
        public OutArgument<AMxperuValidaDireccionResponse> outputObject { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AMxperuValidaDireccionResponse _AmxperuValidaDireccionResponse = null;
            try
            {
                AmxPeruValidaDireccionBusiness _AmxPeruValidaDireccionBusiness = new AmxPeruValidaDireccionBusiness();
                _AmxperuValidaDireccionResponse = _AmxPeruValidaDireccionBusiness.AmxperuValidaDireccion(inputObject.Get(context), ContextProvider.OrganizationService);
                context.SetValue(outputObject, _AmxperuValidaDireccionResponse);

            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }
}
