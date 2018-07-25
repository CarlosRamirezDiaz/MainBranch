using AmxCoPSBActivities.AMXCOLOMBIA.Model;
using AmxPeruPSBActivities.AMXCOLOMBIA.Business;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Activities.Configuration
{
    public class AmxCoCreteUpdateResourceChar : XrmAwareCodeActivity
    {
        public InArgument<AmxCoCreateUpdateResourceCharInput> inputModel { get; set; }
        public OutArgument<AmxCoCreateUpdateResourceCharInput> outputModel { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AmxCoCreateUpdateResourceCharInput _inputModel = context.GetValue(this.inputModel);

            AddUpdateOrderResourceBusiness addUpdateOrderResourcesBusiness = new AddUpdateOrderResourceBusiness();

            this.outputModel.Set(context, addUpdateOrderResourcesBusiness.CreateUpdateOrderResource(ContextProvider.OrganizationService, _inputModel));
        }
    }
}
