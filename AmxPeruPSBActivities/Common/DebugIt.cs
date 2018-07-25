using AmxPeruCommonLibrary.Repository;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;

namespace AmxPeruPSBActivities.Common
{
    public class DebugIt : XrmAwareCodeActivity
    {
        public InArgument<Object> Value { get; set; }
        public InArgument<string> EntityName { get; set; }
        public InArgument<string> EntityId { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var value = Value.Get(context);
            var name = EntityName.Get(context);
            var id = EntityId.Get(context);
            Exception exception;
            Microsoft.Xrm.Sdk.Entity entity = null;
            try
            {
                entity = new AmxPeruRepositoryBase().RetrieveById(ContextProvider.OrganizationService, Guid.Parse(id), name);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }
    }
}
