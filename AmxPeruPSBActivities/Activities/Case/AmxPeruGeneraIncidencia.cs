using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model;
using ExternalApiActivities.Common;
using System;

namespace AmxPeruPSBActivities.Activities.Case
{
    public class AmxPeruGeneraIncidenciaNew : XrmAwareCodeActivity
    {


        public InArgument<AMxperuGeneralIncidenciaRequest> inputObject { get; set; }
        public OutArgument<AMxperuGeneralIncidenciaResponse> outputObject { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AMxperuGeneralIncidenciaResponse _AmxperuGeneralIncidenciaResponse = null;
             AmxPeruGeneraIncidenciaBusiness _amxPeruGeneraIncidenciaBusiness = new AmxPeruGeneraIncidenciaBusiness();

            //_AmxperuGeneralIncidenciaResponse = _amxPeruGeneraIncidenciaBusiness.AMxperuGeneralIncidencia(inputObject.Get(context), ContextProvider.OrganizationService);

            _AmxperuGeneralIncidenciaResponse = new AMxperuGeneralIncidenciaResponse() { code = "1", message = "success", _ticketRemedy = "INC000010000007" };
            //context.SetValue(outputObject, _AmxperuGeneralIncidenciaResponse);

            outputObject.Set(context, _AmxperuGeneralIncidenciaResponse);
        }
    }
}
