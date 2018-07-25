using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;

namespace AmxPeruPSBActivities.Activities.Order
{

    public sealed class GetOrderCaptureAddressActivity : XrmAwareCodeActivity
    {
        public InArgument<Guid> OrderCaptureId { get; set; }
        public OutArgument<string> AddressId { get; set; }
        public OutArgument<string> AddressName { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var orderCaptureId = OrderCaptureId.Get(context);

            var addressQueryExpression = new QueryExpression(etel_ordercapture.EntityLogicalName);
            addressQueryExpression.ColumnSet = new ColumnSet("amxperu_installationaddressid");
            addressQueryExpression.Criteria.AddCondition("etel_ordercaptureid",ConditionOperator.Equal, orderCaptureId);

            //var tLinkEntity = new LinkEntity(etel_ordercapture.EntityLogicalName, etel_customeraddress.EntityLogicalName, "amxperu_installationaddressid", "etel_customeraddressid", JoinOperator.Inner);
            //tLinkEntity.Columns = new ColumnSet(true);
            //addressQueryExpression.LinkEntities.Add(tLinkEntity);

            var orderCapture = ContextProvider.OrganizationService.RetrieveMultiple(addressQueryExpression).Entities.FirstOrDefault();
            var addressId = orderCapture.Contains("amxperu_installationaddressid") ? ((EntityReference)orderCapture.Attributes["amxperu_installationaddressid"]).Id.ToString() : "";
            var addressName = orderCapture.Contains("amxperu_installationaddressid") ? ((EntityReference)orderCapture.Attributes["amxperu_installationaddressid"]).Name : "";

            AddressId.Set(context, addressId);
            AddressName.Set(context, addressName);
        }
    }
}
