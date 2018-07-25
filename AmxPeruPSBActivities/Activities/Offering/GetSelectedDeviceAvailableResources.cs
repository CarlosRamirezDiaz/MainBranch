using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Ericsson.PSB.Workflow.Client.Core;
using Ericsson.ETELCRM.Entities.Crm.CustomEntities;
using Ericsson.ETELCRM.CrmFoundationLibrary.BIL;
using Ericsson.ETELCRM.CrmFoundationLibrary.ServiceClient.Entities;
using Ericsson.ETELCRM.CrmFoundationLibrary.Entities;
using AmxPeruPSBActivities.Helpers;
using AmxPeruPSBActivities.Service.AvailableStocks;
using Newtonsoft.Json;
using AmxPeruPSBActivities.Model.AvailableStocks;
using AmxPeruPSBActivities.Mapping;

namespace AmxPeruPSBActivities.Activities.Offering
{
    public class AvailableResourceModel
    {
        
        public List<OrderItem> OrderItems { get; set; }

    }

    public class OrderItem
    {

        public string OrderItemId { get; set; }

        public string OfferingName { get; set; }

        public string OfferingId { get; set; }

        public List<ResourcePossibleValue> ResourcePossibleValues { get; set; }
    }


    public class ResourcePossibleValue
    {        
        public string ResourceType { get; set; }
        public string Id { get; set; }
        public List<ResourceValue> Values { get; set; }
    }

    public class ResourceValue
    {
        public string resourceId { get; set; }
        public string resourceName { get; set; }
        public string serialNumber { get; set; }
        public string orderResourceId { get; set; }

    }


    public class GetSelectedDeviceAvailableResources : XrmAwareCodeActivity
    {
        public InArgument<Guid> OrderId { get; set; }

        //public OutArgument<List<AvailableResourceModel>> ResponseModel { get; set; }
        public OutArgument<AvailableResourceModel> ResponseModel { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            AvailableResourceModel availableResource =
                new AvailableResourceModel();

            var orderId = OrderId.Get(context);

            // Get the Order : TODO
            string EntityOrder = "etel_ordercapture";
            var orders = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = EntityOrder,
                ColumnSet = new ColumnSet(true),
                Criteria =
                        new FilterExpression()
                        {
                            Conditions =
                                {
                                    new ConditionExpression("etel_ordercaptureid", ConditionOperator.Equal,orderId)
                                }
                        }
            });
            var order = orders.Entities.FirstOrDefault();

            var rcNew = new AvailableResourceModel();
            rcNew.OrderItems = new List<OrderItem>();

            // Get all order items for specific order Id
            string EntityOrderItems = "etel_orderitem";
            var orderItems = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
            {
                EntityName = EntityOrderItems,
                ColumnSet = new ColumnSet(true),
                Criteria =
                        new FilterExpression()
                        {
                            Conditions =
                                {
                                    new ConditionExpression("etel_orderid", ConditionOperator.Equal,orderId)
                                }
                        }
            });

            // Get all the order resources for each order item
            string EntityOrderResource = "etel_orderresource";
            int counter = 0;
            foreach (var oi in orderItems.Entities)
            {
                OrderItem o = new OrderItem();

                o.OrderItemId = oi.Id.ToString();
                o.OfferingName = ((EntityReference)oi.Attributes["etel_offeringid"]).Name;
                o.OfferingId = ((EntityReference)oi.Attributes["etel_offeringid"]).Id.ToString();

                rcNew.OrderItems.Add(new OrderItem());
                //rcNew.OrderItems.[counter] = new OrderItem();
                rcNew.OrderItems[counter] = o;

                var orderResources = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = EntityOrderResource,
                    ColumnSet = new ColumnSet(true),
                    Criteria =
                            new FilterExpression()
                            {
                                Conditions =
                                    {
                                        new ConditionExpression("etel_orderitemid",
                                        ConditionOperator.Equal,oi.Id)
                                    }
                            }
                });

                //Entity h = new Entity();
                //h.LogicalName = "etel_orderresource";
                //h.Id = ""; //order resource id
                //h.Attributes["etel_value"] = "selected value from screen";
                //h.Attributes["etel_reservationid"] = "";

                //ContextProvider.OrganizationService.Update(h);

                // Fill the resources
                //rcNew.OrderItems[counter].ResourcePossibleValues = new List<ResourcePossibleValue>();

                foreach (var r in orderResources.Entities)
                {
                    var rc = new ResourcePossibleValue()
                    {
                        ResourceType = ((EntityReference)r.Attributes["etel_productresourcespecification"]).Name,
                        Id = ((EntityReference)r.Attributes["etel_productresourcespecification"]).Id.ToString(),
                    };

                    switch (((EntityReference)r.Attributes["etel_productresourcespecification"]).Name)
                    {
                        case "MSISDN":
                            rc.Values = GetResourceValues("MSISDN", null, Convert.ToString(order.Attributes["etel_name"]), r.Id.ToString());
                            break;
                        case "ClaroSimNano":
                        case "SIM":
                            rc.Values = GetResourceValues(((EntityReference)r.Attributes["etel_productresourcespecification"]).Name, 
                                context, 
                                ((EntityReference)r.Attributes["etel_productresourcespecification"]).Name);
                            break;
                        default:
                            break;                            
                    }

                    if (rcNew.OrderItems[counter].ResourcePossibleValues == null)
                        rcNew.OrderItems[counter].ResourcePossibleValues = new List<ResourcePossibleValue>();

                    rcNew.OrderItems[counter].ResourcePossibleValues.Add(rc);
                    
                }
                counter++;
            }
            ResponseModel.Set(context, rcNew);

            //ResponseModel.Set(context, availableResources);
        }

        protected List<ResourceValue> GetResourceValues(string resourceName, 
            CodeActivityContext context = null, string id = null, string orderResourceId = "")
        {
            try
            {
                switch (resourceName)
                {
                    case "MSISDN":
                        return GetMSISDNs(id, orderResourceId);
                    case "ClaroSimNano":
                    case "SIM":
                        return GetSIMs(context, id);
                    default:
                        return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        protected List<ResourceValue> GetMSISDNs(string orderId, string _orderResourceId)
        {
            List<ResourceValue> values = new List<ResourceValue>();

            // Call BIL
            RestConfigurationModel configuration =
                ConfigurationBuilder.Build("http://10.103.27.173:8180/BILWebServices/rs/",
                "kcwRlHZtau4PBKVCENCJktmuP1LRUxLwLqjZsVDbiWdE2BdQw91NRzHUjzPDq3Rn/bBpdgh1VqiOPs8/5WWo/g==",
                Identity?.Name);
            var _bilClient = new RetrieveResourceRestClient(configuration);

            var req = new RetrieveResourceRequest()
            {
                count = 5,
                countSpecified = true,
                resourceNameSpecified = true,
                userId = Identity?.Name,
                resourceName = resourceNameEnum.dirNum,
                orderId = orderId //"ORDMD0000076"
            };
            var response = _bilClient.Post(req);
            // Call BIL

            if (response != null)
            {
                List<ResourcePossibleValue> list =
                    new List<ResourcePossibleValue>();

                foreach (var r in response.resource)
                {
                    //list.Add(new ResourcePossibleValue()
                    //{
                    //    Value = r.serialNumber,
                    //    Id = r.resourceId
                    //});
                    //values.Add(r.serialNumber);
                    values.Add(new Offering.ResourceValue()
                    {
                        serialNumber = r.serialNumber,
                        resourceId = r.resourceId,
                        resourceName = resourceNameEnum.dirNum.ToString(),
                        orderResourceId = _orderResourceId
                    });
                }

                return values;
            }
            return null;
        }

        protected List<ResourceValue> GetSIMs(CodeActivityContext context, string partNumber)
        {
            List<ResourcePossibleValue> list = null;
            List<ResourceValue> values = new List<ResourceValue>();

            // Call ERMS
            var _ermsMEthodBroker = new AvailableStockBroker();
            var ermsResponse = _ermsMEthodBroker.GetAvailableStock(context, partNumber, Identity?.Name);

            var ermsResult = (AvailableStockResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(ermsResponse, typeof(AvailableStockResponse));
            var result = new MapSellableStockLevelToAvailableStock().Map(ermsResult);
            // Call ERMS

            if (result != null)
            {
                if (result.Count > 0)
                {
                    list = new List<ResourcePossibleValue>();
                    foreach (var i in result)
                    {
                        //list.Add(new ResourcePossibleValue() { Value = i.StartSerialNumber });
                        //values.Add(i.StartSerialNumber);
                        values.Add(new ResourceValue() { serialNumber = i.StartSerialNumber  });
                    }

                    return values;
                }
            }

            return null;
        }
    }
}
