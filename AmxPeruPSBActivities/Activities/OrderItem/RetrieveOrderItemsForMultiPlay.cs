using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using Microsoft.Xrm.Sdk.Query;

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class RetrieveOrderItemsForMultiPlay : XrmAwareCodeActivity
    {
        public InArgument<string> OrderCaptureId { get; set; }
        public OutArgument<List<Entity>> OrderItemList { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var orderCaptureId = OrderCaptureId.Get(context);

            QueryExpression orderCaptureEntity = new QueryExpression();
            orderCaptureEntity.EntityName = etel_ordercapture.EntityLogicalName;
            orderCaptureEntity.ColumnSet = new ColumnSet("etel_name");
            orderCaptureEntity.Criteria.AddCondition("etel_ordercaptureid", ConditionOperator.Equal, new Guid(orderCaptureId));

            LinkEntity orderItemEntity = new LinkEntity(etel_ordercapture.EntityLogicalName, etel_orderitem.EntityLogicalName, "etel_ordercaptureid", "etel_orderid", JoinOperator.Inner);
            orderItemEntity.EntityAlias = etel_orderitem.EntityLogicalName;
            orderItemEntity.Columns = new ColumnSet("etel_orderitemid", "etel_recurringcharge", "etel_extendedrecurringcharge", "amx_family");
            orderCaptureEntity.LinkEntities.Add(orderItemEntity);

            LinkEntity productEntity = new LinkEntity(etel_orderitem.EntityLogicalName, Product.EntityLogicalName, "etel_offeringid", "productid", JoinOperator.Inner);
            productEntity.EntityAlias = Product.EntityLogicalName;
            productEntity.Columns = new ColumnSet("etel_externalid", "etel_offertypecode", "amxperu_offertypecode");
            productEntity.LinkCriteria.AddCondition(new ConditionExpression("etel_offertypecode", ConditionOperator.In, new int[] { (int)AmxPeruCommonLibrary.OptionSets.etel_offertypecode.Optional, (int)AmxPeruCommonLibrary.OptionSets.etel_offertypecode.Addon }));
            productEntity.LinkCriteria.AddCondition(new ConditionExpression("amxperu_offertypecode", ConditionOperator.In, new int[] { (int)AmxPeruCommonLibrary.OptionSets.amxperu_offertypecode.Equipment, (int)AmxPeruCommonLibrary.OptionSets.amxperu_offertypecode.Plan, (int)AmxPeruCommonLibrary.OptionSets.amxperu_offertypecode.AddonService }));
            orderItemEntity.LinkEntities.Add(productEntity);

            var orderItemList = ContextProvider.OrganizationService.RetrieveMultiple(orderCaptureEntity)?.Entities?.ToList();
            OrderItemList.Set(context, orderItemList);
        }
    }
}
