using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xrm.Sdk;
using System.Activities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;

namespace AmxPeruPSBActivities.Activities
{

    public sealed class UpdateGenericEntityFieldsActivity : XrmAwareCodeActivity
    {
        public InArgument<Guid> EntityId { get; set; }
        public InArgument<string> EntityName { get; set; }
        public InArgument<List<string>> FieldNames { get; set; }
        public InArgument<List<string>> FieldValues { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var entityId = EntityId.Get(context);
            var entityName = EntityName.Get(context);
            var fieldNames = FieldNames.Get(context);
            var fieldValues = FieldValues.Get(context);

            Entity genericEntity = new Entity();
            genericEntity.LogicalName = entityName;
            genericEntity.Id = entityId;

            for (int i = 0; i < fieldNames.Count; i++)
            {
                genericEntity.Attributes[fieldNames[i]] = fieldValues[i];
            }

            ContextProvider.OrganizationService.Update(genericEntity);
        }
    }
}
