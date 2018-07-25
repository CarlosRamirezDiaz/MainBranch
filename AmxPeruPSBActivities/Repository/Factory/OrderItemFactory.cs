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
using AmxPeruPSBActivities.Model;

namespace AmxCoPSBActivities.Repository.Factory
{
    internal static class OrderItemFactory
    {
        internal static Entity CreateEntityFrom(OrganizationServiceProxy org, OrderItemModel orderItem)
        {
            Entity entity = new Entity("etel_orderitem");

            entity.Id = orderItem.Id;
            entity.Attributes.Add("amx_action", orderItem.amx_action);
            entity.Attributes.Add("amx_billingaccountexternalid", orderItem.amx_billingaccountexternalid);
            entity.Attributes.Add("amx_productsrid", orderItem.amx_productsrid);
            entity.Attributes.Add("etel_recurringcharge", orderItem.etel_recurringcharge);
            entity.Attributes.Add("etel_recurringcharge_base", orderItem.etel_recurringcharge_base);
            entity.Attributes.Add("amx_popexternalid", orderItem.amx_popexternalid);
            entity.Attributes.Add("etel_onetimecharge", orderItem.etel_onetimecharge);
            entity.Attributes.Add("etel_onetimecharge_base", orderItem.etel_onetimecharge_base);
            entity.Attributes.Add("amx_appointmentlogid", orderItem.amx_appointmentlogid);
            entity.Attributes.Add("etel_offeringid", orderItem.etel_offeringid);
            entity.Attributes.Add("etel_parentorderitemid", orderItem.etel_parentorderitemid);

            return entity;
        }

        internal static OrderItemModel CreateOrderItemFrom(Entity entity)
        {
            var orderItem = new OrderItemModel();

            orderItem.Id = entity.Id;

            if (entity.Contains("amx_action"))
                orderItem.amx_action = (OptionSetValue)entity.Attributes["amx_action"];

            if (entity.Contains("amx_billingaccountexternalid"))
                orderItem.amx_billingaccountexternalid = entity.Attributes["amx_billingaccountexternalid"].ToString();

            if (entity.Contains("amx_productsrid"))
                orderItem.amx_productsrid = entity.Attributes["amx_productsrid"].ToString();

            if (entity.Contains("etel_recurringcharge"))
                orderItem.etel_recurringcharge = (Money)entity.Attributes["etel_recurringcharge"];

            if (entity.Contains("etel_recurringcharge_base"))
                orderItem.etel_recurringcharge_base = (Money)entity.Attributes["etel_recurringcharge_base"];

            if (entity.Contains("etel_onetimecharge"))
                orderItem.etel_onetimecharge = (Money)entity.Attributes["etel_onetimecharge"];

            if (entity.Contains("etel_onetimecharge_base"))
                orderItem.etel_onetimecharge_base = (Money)entity.Attributes["etel_onetimecharge_base"];

            if (entity.Contains("amx_popexternalid"))
                orderItem.amx_popexternalid = entity.Attributes["amx_popexternalid"].ToString();

            if (entity.Contains("amx_appointmentlogid"))
                orderItem.amx_appointmentlogid = (EntityReference)entity.Attributes["amx_appointmentlogid"];

            if (entity.Contains("etel_offeringid"))
                orderItem.etel_offeringid = (EntityReference)entity.Attributes["etel_offeringid"];

            if (entity.Contains("etel_parentorderitemid"))
                orderItem.etel_parentorderitemid = (EntityReference)entity.Attributes["etel_parentorderitemid"];

            return orderItem;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] { "etel_orderitemid"
                                                    , "amx_action"
                                                    , "amx_billingaccountexternalid"
                                                    , "amx_productsrid"
                                                    , "etel_recurringcharge"
                                                    , "etel_recurringcharge_base"
                                                    , "amx_popexternalid"
                                                    , "etel_onetimecharge"
                                                    , "etel_onetimecharge_base"
                                                    , "amx_appointmentlogid"
                                                    , "etel_offeringid"
                                                    , "etel_parentorderitemid"});
            }
        }
    }
}
