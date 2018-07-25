using Ericsson.ETELCRM.Business.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.CrmFoundationLibrary.Integration;
using AmxPeruCommonLibrary.Actions.BusinessInteraction;

namespace AmxPeruCommonLibrary
{
    public class AmxPeruBusinessConfigurationBootstrapper : BusinessConfigurationBootstrapper
    {
        public override void SetupDependencies(IDependencyResolver resolver)
        {
            base.SetupDependencies(resolver);
            resolver.Register<IBIAffiliateDiaffiliateBlacklistServiceAction, BIAffiliateDiaffiliateBlacklistServiceAction>();
            resolver.Register<IBIAffiliateDiaffiliateDataProtectionAction, BIAffiliateDiaffiliateDataProtectionAction>();
            resolver.Register<IBIAffiliateDisaffiliatetoWhitePageAction, BIAffiliateDisaffiliatetoWhitePageAction>();
        }
    }
}
