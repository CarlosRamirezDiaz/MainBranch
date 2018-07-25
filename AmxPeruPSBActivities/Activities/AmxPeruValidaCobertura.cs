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
    public sealed class AmxPeruValidaCobertura : XrmAwareCodeActivity
    {
        public InArgument<AMxperuValidaCoberturaRequest> inputObject { get; set; }
        public OutArgument<AMxperuValidaCoberturaResponse> outputObject { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AMxperuValidaCoberturaResponse _amxPeruValidaCoberturaResponse = null;
            try
            {
                AmxPeruValidaCoberturaBusiness _AmxPeruValidaCoberturaBusiness = new AmxPeruValidaCoberturaBusiness();
                _amxPeruValidaCoberturaResponse = _AmxPeruValidaCoberturaBusiness.AMxperuValidaCobertura(inputObject.Get(context), ContextProvider.OrganizationService);
                context.SetValue(outputObject, _amxPeruValidaCoberturaResponse);

            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }
    }
