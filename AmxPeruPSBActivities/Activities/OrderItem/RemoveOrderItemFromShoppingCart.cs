using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk;
using q = Microsoft.Xrm.Sdk.Query;
using AmxPeruCommonLibrary.OptionSets;
using System.Web.UI.WebControls.Expressions;

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class RemoveOrderItemFromShoppingCart : XrmAwareCodeActivity
    {
        public InArgument<Guid> OrderItemId { get; set; }

        public InArgument<bool> CheckToRemove { get; set; }

        public InArgument<Guid> OrderCaptureId { get; set; }


        public OutArgument<OrderDataModel> OrderItemListDataModel { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var orderItemId = OrderItemId.Get(context);
            var orderCaptureId = OrderCaptureId.Get(context);
            var checkToRemove = CheckToRemove.Get(context);

            if (checkToRemove)
            {
                var currentOrderItem = dataContext.etel_orderitemSet.Where(o => o.Id == orderItemId).FirstOrDefault();

                if (currentOrderItem.Contains("amx_family") && currentOrderItem.Attributes["amx_family"].ToString() == "Telephony")
                {
                    var orderItemList = dataContext.etel_orderitemSet.Where(o => o.etel_orderid.Id == orderCaptureId ).ToList();
                    var tel2List = orderItemList.Where(p => p.Contains("amx_family") && p.Attributes["amx_family"].Equals("Telephony2")).ToList();
                    foreach (var tel2Item in tel2List)
                    {
                        RemoveItem(tel2Item.Id);
                    }
                }

                etel_orderitem otherPlanInCart = FindOtherPlanItemInCart(dataContext, orderCaptureId, orderItemId);
                CheckItemToRemoveOrToUpdate(dataContext, orderItemId, otherPlanInCart, currentOrderItem);
            }
            else
            {
                RemoveItem(orderItemId);
            }
            var orderModel = new OrderDataModel();
            OrderItemListDataModel.Set(context, orderModel);
        }

        void CheckItemToRemoveOrToUpdate(XrmDataContext dataContext, Guid orderItemId, etel_orderitem otherPlanInCart, etel_orderitem currentOrderItem)
        {
            var subItemList = dataContext.etel_orderitemSet.Where(o => o.etel_parentorderitemid.Id == orderItemId).ToList();

            if (subItemList.Count > 0)
            {
                foreach (var item in subItemList)
                {
                    CheckItemToRemoveOrToUpdate(dataContext, item.Id, otherPlanInCart, item);
                }

                RemoveItem(orderItemId);
            }
            else
            {
                if (otherPlanInCart != null)
                {
                    var associatedOfferings = dataContext.etel_offeringassociationSet
                                                     .Where(t => t.etel_primaryofferingid == otherPlanInCart.etel_offeringid &&
                                                                t.etel_secondaryofferingid == currentOrderItem.etel_offeringid)
                                                     .ToList();
                    if (associatedOfferings.Count > 0 && currentOrderItem.Contains("amx_family") && currentOrderItem.Attributes["amx_family"].ToString() != "Mobile")
                    {
                        // update with other plan Id as parent order item id
                        Entity orderitem = new Entity();
                        orderitem.LogicalName = "etel_orderitem";
                        orderitem.Id = currentOrderItem.Id;
                        orderitem.Attributes["etel_parentorderitemid"] = new EntityReference(etel_orderitem.EntityLogicalName, otherPlanInCart.Id);

                        ContextProvider.OrganizationService.Update(orderitem);
                    }
                    else
                    {
                        RemoveItem(orderItemId);
                    }
                }
                else
                {
                    RemoveItem(orderItemId);
                }
            }
        }

        etel_orderitem FindOtherPlanItemInCart(XrmDataContext dataContext, Guid orderCaptureId, Guid orderItemId)
        {
            var orderItem = dataContext.etel_orderitemSet.Where(o => o.Id == orderItemId).FirstOrDefault();

            var checkOtherPlansInCart = dataContext.etel_orderitemSet.Where(o => o.etel_orderid.Id == orderCaptureId &&
                                                                                 o.Id != orderItemId &&
                                                                                 o.etel_parentorderitemid.Id != orderItem.Id).ToList();

            return checkOtherPlansInCart.Where(p => p.Contains("amx_offertypecode") && ((OptionSetValue)p.Attributes["amx_offertypecode"]).Value.Equals(10)).FirstOrDefault();
        }

        void RemoveItem(Guid orderItemId)
        {
            ContextProvider.OrganizationService.Delete(etel_orderitem.EntityLogicalName, orderItemId);
        }
    }

}
