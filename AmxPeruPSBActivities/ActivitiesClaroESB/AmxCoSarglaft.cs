using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.ActivitiesClaroESB
{
    public class AmxCoSarglaft : XrmAwareCodeActivity
    {
        public InArgument<string> FullName { get; set; }
        public InArgument<int> Punctuation { get; set; }
        public InArgument<string> SarglaftURL { get; set; }
        public OutArgument<string> Findinglists { get; set; }
        public InArgument<string> CustomerId { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var sarglaftBusiness = new AmxCoPSBActivities.BusinessClaroESB.AmxCoSarglaftBusiness();

            var _response = sarglaftBusiness.ConsultLists(SarglaftURL.Get(context), FullName.Get(context), CustomerId.Get(context), Punctuation.Get(context), ContextProvider.OrganizationService);
            
            Findinglists.Set(context, _response);
        }

    }
}
