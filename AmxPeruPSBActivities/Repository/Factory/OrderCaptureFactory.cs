using AmxPeruPSBActivities.Model.OrderCapture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Client;
using Ericsson.ETELCRM.Entities.Crm.CustomEntities;

namespace AmxCoPSBActivities.Repository.Factory
{
    internal static class OrderCaptureFactory
    {
        internal static Entity CreateEntityFrom(OrganizationServiceProxy org, OrderCaptureModel orderCapture)
        {
            Entity entity = new Entity("etel_ordercapture");

            entity.Id = orderCapture.OrderCaptureId;
            entity.Attributes.Add("amxperu_installationaddressid", new EntityReference("etel_customeraddress", orderCapture.amxperu_installationaddressid));
            entity.Attributes.Add("createdby", orderCapture.CreatedBy);

            return entity;
        }

        internal static OrderCaptureModel CreateOrderCaptureFrom(Entity entity)
        {
            var orderCapture = new OrderCaptureModel();

            orderCapture.OrderCaptureId = entity.Id;

            if (entity.Contains("amxperu_installationaddressid"))
                orderCapture.amxperu_installationaddressid = (Guid)entity.Attributes["amxperu_installationaddressid"];

            if (entity.Contains("createdby"))
                orderCapture.CreatedBy = entity.GetAttributeValue<EntityReference >("createdby").Id;

            return orderCapture;
        }

        internal static AmxCoPSBActivities.AMXCOLOMBIA.Model.OrderCapture.ListOrderCapture CreateListOrderCaptureFrom(Entity entity)
        {
            var orderCapture = new AmxCoPSBActivities.AMXCOLOMBIA.Model.OrderCapture.ListOrderCapture();

            orderCapture.OrderCaptureId = entity.Id;

            if (entity.Contains("etel_name"))
                orderCapture.Name = entity.GetAttributeValue<string>("etel_name");

            if (entity.FormattedValues.Contains("etel_ordertypecode"))
                orderCapture.OrderType = entity.FormattedValues["etel_ordertypecode"].ToString();

            if (entity.FormattedValues.Contains("statuscode"))
                orderCapture.StatusReason = entity.FormattedValues["statuscode"].ToString();

            if (entity.FormattedValues.Contains("createdon"))
                orderCapture.CreatedOn = entity.FormattedValues["createdon"].ToString();
            else if (entity.Contains("createdon"))
                orderCapture.CreatedOn = entity.GetAttributeValue<DateTime>("createdon").ToShortDateString();

            if (entity.Contains("etel_externalorderid"))
                orderCapture.ExternalOrderId = entity.GetAttributeValue<string>("etel_externalorderid");

            if (entity.Contains("etel_shoppingcardid"))
                orderCapture.ShoppingCardId = entity.GetAttributeValue<string>("etel_shoppingcardid");

            if (entity.Contains("etel_sourcesystem"))
                orderCapture.SourceSystem = entity.GetAttributeValue<string>("etel_sourcesystem");

            if (entity.Contains("etel_subscriptionid"))
                orderCapture.SubscriptionName = entity.GetAttributeValue<EntityReference>("etel_subscriptionid").Name;

            if (entity.FormattedValues.Contains("amx_cancelreason"))
                orderCapture.CancelReasonName = entity.FormattedValues["amx_cancelreason"].ToString();

            if (entity.FormattedValues.Contains("amx_postponereason"))
                orderCapture.PostponeReasonName = entity.FormattedValues["amx_postponereason"].ToString();

            return orderCapture;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] {
                    "etel_ordercaptureid",
                    "amxperu_installationaddressid",
                    "etel_name",
                    "etel_ordertypecode",
                    "etel_externalorderid",
                    "etel_shoppingcardid",
                    "etel_sourcesystem",
                    "etel_subscriptionid",
                    "createdby",
                    "createdon",
                    "statuscode",
                    "statecode",
                    "amx_postponereason",
                    "amx_cancelreason"
                });
            }
        }
    }
}
