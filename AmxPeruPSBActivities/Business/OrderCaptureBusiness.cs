using AmxPeruPSBActivities.Model.OrderCaptureSubmit;
using AmxPeruPSBActivities.Repository;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Business
{
    class OrderCaptureBusiness
    {
        XrmDataContext _xrmDataContext { set; get; }

        OrganizationServiceProxy _org = null;

        public OrderCaptureBusiness(OrganizationServiceProxy org)
        {
            this._org = org;
        }

        public OrderCaptureBusiness()
        {
        }

        public etel_ordercapture RetrieveById(Guid guid)
        {
            var queryResult = _xrmDataContext.etel_ordercaptureSet.Where(t => t.Id == guid);
            etel_ordercapture result = queryResult.FirstOrDefault();

            return result;
        }

        public SubmitOrderRequest retrieveEOCBiRequest(Guid OrderCaptureId, OrganizationServiceProxy _org, XrmDataContext dataContext, CodeActivityContext context)
        {
            this._org = _org;
            var orderCaptureId = OrderCaptureId;
            
            var query = from orderCapture in dataContext.etel_ordercaptureSet
                        where orderCapture.Id == orderCaptureId
                        select orderCapture;
            var orderCaptureEntity = query.FirstOrDefault();

            var listOrderItem = (new OrderItemRepository(_org)).RetrieveOrderItemModelByOrder(OrderCaptureId);

            string externalId = string.Empty;

            SubmitOrderRequest request = new SubmitOrderRequest()
            {
                createdDate = DateTime.Now.ToString(CultureInfo.CurrentCulture.DateTimeFormat.SortableDateTimePattern),
                description = orderCaptureEntity.etel_name,
                run = true,
                requestedCompletionDate = DateTime.Now.AddDays(5).ToString(CultureInfo.CurrentCulture.DateTimeFormat.SortableDateTimePattern),
            };

            request.orderItems = new List<AmxPeruPSBActivities.Model.OrderCaptureSubmit.OrderItem>();
             
            var optionSetOption = GetoptionsetMetadata("etel_orderitem", "amx_action");

            long referece = 0;

            foreach (var item in listOrderItem)
            {
                var crmOffering = _org.Retrieve(Ericsson.ETELCRM.Entities.Crm.Product.EntityLogicalName,
                    item.etel_offeringid.Id, new ColumnSet(true));

                // Get Customized Order Item model
                var orderItemRepository = new OrderItemRepository(_org);

                AmxPeruPSBActivities.Model.OrderCaptureSubmit.OrderItem orderItem = new AmxPeruPSBActivities.Model.OrderCaptureSubmit.OrderItem();
                orderItem.item = new Item();

                orderItem.item.id = (referece++).ToString();

                // Obtaining order item action amx_action
                orderItem.item.action = GetoptionsetText(optionSetOption, item.amx_action);

                orderItem.item.orderType = "ProductOfferingOrder";
                orderItem.item.productOffering = new ProductOffering() { id = (crmOffering as Ericsson.ETELCRM.Entities.Crm.Product).etel_externalid };
                
                orderItem.item.attrs = new List<Attr>();
                orderItem.item.attrs.Add(new Attr() { name = "OrderItemId", value = item.Id.ToString() });

                if(item.etel_parentorderitemid != null)
                {
                    orderItem.item.relatedOrderItems = new List<RelatedOrderItem>()
                            {
                                new RelatedOrderItem()
                                {
                                    //role = "ReliesOn",
                                    role = "ChildOf",
                                    //relatedBasicPoCode = orderItem.item.productOffering.id
                                    reference = (request.orderItems.Find(x => x.item.attrs.Find(y => y.name.Equals("OrderItemId")).value.Equals(item.etel_parentorderitemid.Id.ToString()))).item.id
                                }
                            };
                }
                

                request.orderItems.Add(orderItem);
            }
            
            return request;
        }

        public Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata GetoptionsetMetadata(string entityName, string attributeName)
        {
            string AttributeName = attributeName;
            string EntityLogicalName = entityName;
            RetrieveEntityRequest retrieveDetails = new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.All,
                LogicalName = EntityLogicalName
            };
            RetrieveEntityResponse retrieveEntityResponseObj = (RetrieveEntityResponse)_org.Execute(retrieveDetails);
            Microsoft.Xrm.Sdk.Metadata.EntityMetadata metadata = retrieveEntityResponseObj.EntityMetadata;
            Microsoft.Xrm.Sdk.Metadata.PicklistAttributeMetadata picklistMetadata = metadata.Attributes.FirstOrDefault(attribute => String.Equals(attribute.LogicalName, attributeName, StringComparison.OrdinalIgnoreCase)) as Microsoft.Xrm.Sdk.Metadata.PicklistAttributeMetadata;
            Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata options = picklistMetadata.OptionSet;

            return options;
        }

        public string GetoptionsetText(Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata options, OptionSetValue optionSetValue)
        {
            IList<OptionMetadata> OptionsList = (from o in options.Options
                                                 where o.Value.Value == optionSetValue.Value
                                                 select o).ToList();
            string optionsetLabel = (OptionsList.First()).Label.UserLocalizedLabel.Label;
            return optionsetLabel;
        }
    }
}
