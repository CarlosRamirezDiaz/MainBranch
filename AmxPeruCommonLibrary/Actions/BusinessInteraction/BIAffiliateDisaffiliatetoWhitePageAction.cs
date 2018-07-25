using Ericsson.ETELCRM.Actions.CRM.BusinessInteractions;
using Ericsson.ETELCRM.CrmFoundationLibrary.Business;
using Ericsson.ETELCRM.CrmFoundationLibrary.Integration;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruCommonLibrary.Actions.BusinessInteraction
{
    public class BIAffiliateDisaffiliatetoWhitePageAction : BusinessInteractionAction<Entity>, IBIAffiliateDisaffiliatetoWhitePageAction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BiBillCycleChangeAction"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public BIAffiliateDisaffiliatetoWhitePageAction(IActionContext context)  : base(context)
        {
        }

    }
    public interface IBIAffiliateDisaffiliatetoWhitePageAction : IBusinessBase
    {
    }
}
