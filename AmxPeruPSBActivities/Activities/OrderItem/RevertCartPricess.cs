using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AmxPeruPSBActivities.Activities.OrderItem
{

    public sealed class RevertCartPricess : XrmAwareCodeActivity
    {
        public InArgument<Guid> OrderCaptureId { get; set; }

        public InArgument<bool> IsRemovedItemPermanencia { get; set; }


        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            Guid orderCaptureId = context.GetValue(OrderCaptureId);
            bool isRemovedItemPermanencia = context.GetValue(IsRemovedItemPermanencia);

            var orderItemQuery = new QueryExpression("etel_orderitem");
            orderItemQuery.ColumnSet = new ColumnSet(new string[] { "etel_orderitemid"
                    , "etel_recurringcharge"
                    , "etel_onetimecharge"
                    , "etel_extendedrecurringcharge"
                    , "etel_extendedonetimecharge"});

            orderItemQuery.Criteria = new FilterExpression();
            orderItemQuery.Criteria.AddCondition("etel_orderid", ConditionOperator.Equal, orderCaptureId);

            if (isRemovedItemPermanencia)
            {
                orderItemQuery.Criteria.AddCondition("etel_extendedonetimecharge", ConditionOperator.NotNull);
                orderItemQuery.Criteria.AddCondition("amx_offertypecode", ConditionOperator.Equal, (int)AmxPeruCommonLibrary.OptionSets.amx_offertypecode.Addon_Service);
            }
            else
            {
                orderItemQuery.Criteria.AddCondition("etel_extendedrecurringcharge", ConditionOperator.NotNull);
            }

            var orderItemList = ContextProvider.OrganizationService.RetrieveMultiple(orderItemQuery).Entities;
            

            foreach (var orderItem in orderItemList)
            {
                var orderItemEntity = new Entity(etel_orderitem.EntityLogicalName);
                orderItemEntity.Id = orderItem.Id;
                if (isRemovedItemPermanencia)
                {
                    orderItemEntity.Attributes["etel_onetimecharge"] = orderItem.Attributes["etel_extendedonetimecharge"];
                }
                else
                {
                    orderItemEntity.Attributes["etel_recurringcharge"] = orderItem.Attributes["etel_extendedrecurringcharge"];
                }
                orderItemEntity.Attributes["etel_extendedrecurringcharge"] = null;
                orderItemEntity.Attributes["etel_extendedonetimecharge"] = null;
                ContextProvider.OrganizationService.Update(orderItemEntity);
            }
        }
    }
}
