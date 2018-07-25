using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Repository;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.Business
{
    public class AmxCoGetConfigurableItemsBusiness
    {
        public ConfigurableItemsModel GetConfigurableItems(OrganizationServiceProxy _org, OrderItemsBasketModel orderItemsBasket)
        {
            ConfigurableItemsModel configurableItems = new ConfigurableItemsModel();
            configurableItems.orderItemsBasket = new OrderItemsBasketModel();
            configurableItems.orderItemsBasket.listOfOrderBasketOrderItems = new List<OrderBasketOrderItem>();

            // Loop through basket and add only configurable items
            configurableItems.productOfferingFullList = new List<ProductOfferingFull>();
            AmxCoProductOfferringRepository productOfferingRepository = new AmxCoProductOfferringRepository(_org);

            // Create list of product offering full
            foreach (OrderBasketOrderItem orderItem in orderItemsBasket.listOfOrderBasketOrderItems)
            {
                configurableItems.productOfferingFullList.Add(productOfferingRepository.GetProductOfferingFull(new Guid(orderItem.offeringGuid)));
            }

            // Loop through order items basket if the po has resource characteristics to be configured
            foreach (OrderBasketOrderItem orderItem in orderItemsBasket.listOfOrderBasketOrderItems)
            {
                // Find the offering
                ProductOfferingFull fullOffering = configurableItems.productOfferingFullList.Find(x => x.ProductOfferingId == orderItem.offeringGuid);
                orderItem.Configurable = productOfferingRepository.HasResourceCharToConfigure(fullOffering);
                
                if (orderItem.Configurable == true)
                {             
                    configurableItems.hasConfigurableItems = true;
                }
                configurableItems.orderItemsBasket.listOfOrderBasketOrderItems.Add(orderItem);
            }           

            return configurableItems;
        }

        public void AddOrderItemHierarchy(OrderBasketOrderItem orderItem,
                                          OrderItemsBasketModel orderItemsBasket,
                                          OrderItemsBasketModel configurableItemsBasket)
        {
            if (!orderItem.ParentOrder)
            {
                OrderBasketOrderItem parentOrderItem = (OrderBasketOrderItem)orderItemsBasket.listOfOrderBasketOrderItems.Find(x => x.guid == orderItem.ParentOrderItemId);
                AddOrderItemHierarchy(parentOrderItem, orderItemsBasket, configurableItemsBasket);
            }

            if (configurableItemsBasket.listOfOrderBasketOrderItems == null || !configurableItemsBasket.listOfOrderBasketOrderItems.Exists(x => x.guid == orderItem.guid))
                configurableItemsBasket.listOfOrderBasketOrderItems.Add(orderItem);
        }
    }
}