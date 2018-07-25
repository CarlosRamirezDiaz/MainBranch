using AmxPeruPSBActivities.Model.OrderCaptureSubmit;
using Ericsson.ETELCRM.Entities.Crm;
using Ericsson.ETELCRM.Entities.Crm.CustomEntities;
using ExternalApiActivities.Common;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.Order
{
    public class ProcessEocResponse : XrmAwareCodeActivity
    {

        public InArgument<Guid> OrderCaptureId { get; set; }

        public InArgument<Contact> IndividualCustomer { get; set; }

        public InArgument<Account> CorporateCustomer { get; set; }

        public InArgument<List<OptionSet>> ResourceTypeCodes { get; set; }

        public OutArgument<SubmitOrderRequest> SubmitRequest { get; set; }


        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var orderCaptureId = OrderCaptureId.Get(context);
            var query = from orderCapture in dataContext.etel_ordercaptureSet
                        where orderCapture.Id == orderCaptureId
                        select orderCapture;
            var orderCaptureEntity = query.FirstOrDefault();

            var query2 = from OrderItem in dataContext.etel_orderitemSet
                         where OrderItem.etel_orderid.Id == orderCaptureId
                         select OrderItem;
            var orderItems = query2.ToList();

            string externalId = string.Empty;
            if (orderCaptureEntity.etel_individualcustomerid != null)
            {
                var contact = ContextProvider.OrganizationService.Retrieve(Contact.EntityLogicalName,
                    orderCaptureEntity.etel_individualcustomerid.Id,
                    new ColumnSet(true));

                externalId = (contact as Contact).etel_externalid;

                if (orderCaptureEntity.etel_ordertypecode.Value == (int)etel_ordertypecode.NewSubscription && (contact as Contact).StatusCode.Value != (int)contact_statuscode.Active)
                {
                    SetEntityState(
                        new EntityReference(Contact.EntityLogicalName, orderCaptureEntity.etel_individualcustomerid.Id),
                         (int)ContactState.Active, (int)contact_statuscode.Active);
                }

            }
            else if (orderCaptureEntity.etel_corporatecustomerid != null)
            {
                var account = ContextProvider.OrganizationService.Retrieve(Account.EntityLogicalName,
                    orderCaptureEntity.etel_corporatecustomerid.Id,
                    new ColumnSet(true));

                externalId = (account as Account).etel_externalid;

                if (orderCaptureEntity.etel_ordertypecode.Value == (int)etel_ordertypecode.NewSubscription && (account as Account).StatusCode.Value != (int)account_statuscode.Active)
                {
                    SetEntityState(new EntityReference(Account.EntityLogicalName, orderCaptureEntity.etel_corporatecustomerid.Id),
                        (int)ContactState.Active, (int)contact_statuscode.Active);
                }
            }


            SubmitOrderRequest request = new SubmitOrderRequest()
            {
                createdDate = DateTime.Now.ToString(CultureInfo.CurrentCulture.DateTimeFormat.SortableDateTimePattern),
                description = orderCaptureEntity.etel_name,
                run = true,
                requestedCompletionDate = DateTime.Now.AddDays(5).ToString(CultureInfo.CurrentCulture.DateTimeFormat.SortableDateTimePattern),
            };

            RelatedParty relatedParty = new RelatedParty()
            {
                role = "Customer",
                reference = externalId
            };

            request.relatedParties = new List<RelatedParty>();
            request.relatedParties.Add(relatedParty);


            request.orderItems = new List<Model.OrderCaptureSubmit.OrderItem>();

            var basicOfferingOrderItems = orderItems.Where(a => a.etel_parentorderitemid is null).ToList();

            foreach (var item in basicOfferingOrderItems)
            {
                var crmOffering = ContextProvider.OrganizationService.Retrieve(Ericsson.ETELCRM.Entities.Crm.Product.EntityLogicalName,
                    item.etel_offeringid.Id, new ColumnSet(true));


                Model.OrderCaptureSubmit.OrderItem orderItem = new Model.OrderCaptureSubmit.OrderItem();
                orderItem.item = new Item();


                orderItem.item.relatedEntities = new List<RelatedEntity>();
                orderItem.item.relatedEntities.Add(new RelatedEntity()
                {
                    type = "Contract",
                    name = "ContractId",
                    reference = "CONT000",
                    entity = new Model.OrderCaptureSubmit.Entity()
                    {
                        contractCreationInformation = new ContractCreationInformation()
                        {
                            attributes = new List<Model.OrderCaptureSubmit.Attribute>()
                            {
                                new Model.OrderCaptureSubmit.Attribute() {name="MARKET",value="GSM"},
                                new Model.OrderCaptureSubmit.Attribute() {name="SUBMARKET",value="GSM"},
                                new Model.OrderCaptureSubmit.Attribute() {name="NETWORK",value="PERTM"},
                                new Model.OrderCaptureSubmit.Attribute() {name="CO_SIGNED_DATE",value="2017-03-22"},
                                new Model.OrderCaptureSubmit.Attribute() {name="CALL_DETAIL",value="R"},
                                new Model.OrderCaptureSubmit.Attribute() {name="CO_OP_DIR",value="false"},
                                new Model.OrderCaptureSubmit.Attribute() {name="CO_PSTN_DIR",value="true"},
                                new Model.OrderCaptureSubmit.Attribute() {name="SDP_ID",value="SDP01"}
                            }
                        }
                    }
                });

                orderItem.item.action = "Add";
                orderItem.item.orderType = "ProductOfferingOrder";
                orderItem.item.productOffering = new ProductOffering() { id = (crmOffering as Ericsson.ETELCRM.Entities.Crm.Product).etel_externalid };

                orderItem.item.product = new Model.OrderCaptureSubmit.Product();
                orderItem.item.product.productCharacteristics = new List<ProductCharacteristic>();

                orderItem.item.attrs = new List<Attr>();
                orderItem.item.attrs.Add(new Attr() { name = "CrmOrderId", value = orderCaptureEntity.etel_name });

                var resultproductcharacteristic = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = "etel_orderproductcharacteristic",
                    ColumnSet = new ColumnSet(true),
                    Criteria =
                    new FilterExpression()
                    {
                        Conditions =
                            {
                                    new ConditionExpression("etel_orderitemid", ConditionOperator.Equal,item.Id),
                            }
                    }
                });

                ////Check for Editable as NO : these can't be sent to EOC
                //List<Guid> charNotToSendToEOC = new List<Guid>();
                //string fetchProdOfferingCharUse = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                //                                      <entity name='amxperu_productofferingcharuse'>
                //                                        <attribute name='amxperu_productofferingcharuseid' />
                //                                        <attribute name='amxperu_name' />
                //                                        <attribute name='amxperu_editable' />
                //                                        <attribute name='amxperu_characteristic' />
                //                                        <filter type='and'>
                //                                          <condition attribute='amxperu_productoffering' operator='eq' uitype='product' value='{0}' />
                //                                        </filter>
                //                                      </entity>
                //                                    </fetch>";
                //fetchProdOfferingCharUse = string.Format(fetchProdOfferingCharUse, item.etel_offeringid.Id.ToString());
                //EntityCollection _EntityCollection = ContextProvider.OrganizationService.RetrieveMultiple(new FetchExpression(fetchProdOfferingCharUse));
                //if (_EntityCollection != null)
                //{
                //    if (_EntityCollection.Entities.Count > 0)
                //    {
                //        foreach (Microsoft.Xrm.Sdk.Entity prodCharUse in _EntityCollection.Entities)
                //        {
                //            if (prodCharUse.Attributes.Contains("amxperu_editable"))
                //            {
                //                if (!(bool)prodCharUse.Attributes["amxperu_editable"])
                //                {
                //                    charNotToSendToEOC.Add((prodCharUse.Attributes["amxperu_characteristic"] as Microsoft.Xrm.Sdk.EntityReference).Id);
                //                }
                //            }
                //        }
                //    }
                //}
                ////Check for Editable as NO : these can't be sent to EOC

                foreach (var prodCharEntity in resultproductcharacteristic.Entities)
                {
                    ProductCharacteristic attr = new ProductCharacteristic();

                    var resultcharacteristic = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
                    {
                        EntityName = etel_productcharacteristic.EntityLogicalName,
                        ColumnSet = new ColumnSet(true),
                        Criteria =
                        new FilterExpression()
                        {
                            Conditions =
                                {
                                        new ConditionExpression("etel_productcharacteristicid", ConditionOperator.Equal,
                                        ((etel_orderproductcharacteristic)prodCharEntity).etel_characteristicid.Id)
                                }
                        }
                    });

                    var charac = resultcharacteristic.Entities.FirstOrDefault();

                    attr.name = (charac as etel_productcharacteristic).etel_externalid;
                    attr.value = ((etel_orderproductcharacteristic)prodCharEntity).etel_value != null
                        ? ((etel_orderproductcharacteristic)prodCharEntity).etel_value
                        : (prodCharEntity.Attributes.Contains("etel_characteristicvalueid")) ? ((etel_orderproductcharacteristic)prodCharEntity).etel_characteristicvalueid.Name : string.Empty;
                    //TODO get char values

                    if (!string.IsNullOrEmpty(attr.value))
                    {
                        orderItem.item.product.productCharacteristics.Add(attr);
                    }
                }

                orderItem.item.resources = new List<Model.OrderCaptureSubmit.Resource>();



                // Get all the order resources for each order item
                string EntityOrderResource = "etel_orderresource";
                var orderResources = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
                {
                    EntityName = EntityOrderResource,
                    ColumnSet = new ColumnSet(true),
                    Criteria =
                            new FilterExpression()
                            {
                                Conditions =
                                    {
                                        new ConditionExpression("etel_orderitemid", ConditionOperator.Equal,item.Id)
                                    }
                            }
                });


                var resourceTypeCodes = ResourceTypeCodes.Get(context);

                foreach (var orderResource in orderResources.Entities)
                {
                    Model.OrderCaptureSubmit.Resource resource = new Model.OrderCaptureSubmit.Resource();
                    resource.resourceCharacteristics = new List<ResourceCharacteristic>();
                    //orderResource//resource spec.//etel_prod..res..spec..
                    var etel_prod_res_spec_id = (orderResource as etel_orderresource).etel_productresourcespecification.Id;

                    var prodResSpec = ContextProvider.OrganizationService.Retrieve(etel_productresourcespecification.EntityLogicalName,
                    etel_prod_res_spec_id, new ColumnSet(true));

                    var resourceType = (resourceTypeCodes == null || (prodResSpec as etel_productresourcespecification).etel_resourcetypecode == null)
                        ? null
                        : resourceTypeCodes.FirstOrDefault(x => x.Value == (prodResSpec as etel_productresourcespecification).etel_resourcetypecode.Value);

                    var resourcenumber = (orderResource as etel_orderresource).etel_value;
                    string msisdn = resourcenumber;

                    resource.resourceSpecification = (prodResSpec as etel_productresourcespecification).etel_externalid;

                    if ((orderResource as etel_orderresource).etel_imsinumber != null)
                    {
                        resource.resourceCharacteristics = new List<ResourceCharacteristic>();
                        resource.resourceCharacteristics.Add(new ResourceCharacteristic() { name = "IMSI", value = (orderResource as etel_orderresource).etel_imsinumber });
                    }

                    //TODO: get product resource chars
                    if (resource.resourceSpecification == "prs_SIM")
                    {
                        resource.resourceCharacteristics = new List<ResourceCharacteristic>();
                        resource.resourceCharacteristics.Add(new ResourceCharacteristic() { name = "serialNumber", value = resourcenumber });
                        resource.resourceCharacteristics.Add(new ResourceCharacteristic() { name = "numberingPlan", value = "E.164" });
                        resource.isLogical = false;
                    }
                    else
                    {
                        resource.resourceCharacteristics = new List<ResourceCharacteristic>();
                        resource.resourceCharacteristics.Add(new ResourceCharacteristic() { name = "resourceNumber", value = msisdn });
                        resource.resourceCharacteristics.Add(new ResourceCharacteristic() { name = "SDP_ID", value = "SDP01" });
                        request.relatedParties.Add(new RelatedParty() { role = "MSISDN", reference = msisdn });
                        resource.isLogical = true;
                    }

                    orderItem.item.resources.Add(resource);

                }

                //Add optional PO to request
                //var optioanlPOOfThisOfferings = orderItems.Where(a => a.etel_parentorderitemid.Id == item.Id).ToList();
                List<etel_orderitem> optioanlPOOfThisOfferings = new List<etel_orderitem>();
                foreach (var optional in orderItems)
                {
                    if (optional.Attributes.Contains("etel_parentorderitemid"))
                    {
                        if (optional.etel_parentorderitemid.Id == item.Id)
                        {
                            optioanlPOOfThisOfferings.Add(optional);
                        }
                    }
                }

                if(optioanlPOOfThisOfferings.Count() > 0)
                {
                    foreach (var optItem in optioanlPOOfThisOfferings)
                    {
                        
                        var crmOptOffering = ContextProvider.OrganizationService.Retrieve(Ericsson.ETELCRM.Entities.Crm.Product.EntityLogicalName,
                            optItem.etel_offeringid.Id, new ColumnSet(true));

                        Model.OrderCaptureSubmit.OrderItem optOrderItem = new Model.OrderCaptureSubmit.OrderItem();
                        optOrderItem.item = new Item()
                        {
                            action = "Add",
                            orderType = "ProductOfferingOrder",
                            productOffering = new ProductOffering()
                            {
                                id = (crmOptOffering as Ericsson.ETELCRM.Entities.Crm.Product).etel_externalid
                            },
                            relatedOrderItems = new List<RelatedOrderItem>()
                            {
                                new RelatedOrderItem()
                                {
                                    role = "ReliesOn",
                                    relatedBasicPoCode = orderItem.item.productOffering.id
                                }
                            }
                        };

                        request.orderItems.Add(optOrderItem);
                    }
                }               


                request.orderItems.Add(orderItem);
            }


            SubmitRequest.Set(context, request);

        }


        public void SetEntityState(EntityReference entityRef, int stateCodeValue, int statusCodeValue)
        {
            var request = new SetStateRequest
            {
                EntityMoniker = entityRef,
                State = new OptionSetValue(stateCodeValue),
                Status = new OptionSetValue(statusCodeValue)
            };

            ContextProvider.OrganizationService.Execute(request);
        }
    }
}
