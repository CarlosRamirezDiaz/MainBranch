using AmxCoPSBActivities.Repository.Factory;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model;
using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model.OrderCapture;
using AmxPeruPSBActivities.Model.OrderCaptureSubmit;
using AmxPeruPSBActivities.Repository;
using Ericsson.ETELCRM.Entities.Crm;
using Ericsson.ETELCRM.Entities.Crm.CustomEntities;
using ExternalApiActivities.Common;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AmxPeruPSBActivities.Activities.Order
{
    public class SubmitOrderCapture : XrmAwareCodeActivity
    {
        public InArgument<Guid> OrderCaptureId { get; set; }

        public InArgument<Contact> IndividualCustomer { get; set; }

        public InArgument<Account> CorporateCustomer { get; set; }

        public InArgument<List<OptionSet>> ResourceTypeCodes { get; set; }

        public OutArgument<SubmitOrderRequest> SubmitRequest { get; set; }

        CustomerAddressBusiness customerAddressBusiness;

        BillingAccountBusiness billingAccountBusiness;

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            billingAccountBusiness = new BillingAccountBusiness(ContextProvider);
            customerAddressBusiness = new CustomerAddressBusiness(ContextProvider);

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
            string firstName = string.Empty;
            string lastName = string.Empty;
            string corporateName = string.Empty;
            List<string> customerEmailList = new List<string>();
            bool isContact = orderCaptureEntity.etel_individualcustomerid != null;
            Guid? accountGuid = null;
            Guid? contactGuid = null;

            if (orderCaptureEntity.etel_individualcustomerid != null)
            {
                var contact = (Contact)ContextProvider.OrganizationService.Retrieve(Contact.EntityLogicalName,
                    orderCaptureEntity.etel_individualcustomerid.Id,
                    new ColumnSet(true));

                externalId = contact.etel_externalid;
                firstName = contact.FirstName;
                lastName = contact.LastName;
                contactGuid = contact.ContactId;
                customerEmailList.Add(contact.EMailAddress1);
                customerEmailList.Add(contact.EMailAddress2);
                customerEmailList.Add(contact.EMailAddress3);

                if (orderCaptureEntity.etel_ordertypecode.Value == (int)etel_ordertypecode.NewSubscription && (contact as Contact).StatusCode.Value != (int)contact_statuscode.Active)
                {
                    SetEntityState(
                        new EntityReference(Contact.EntityLogicalName, orderCaptureEntity.etel_individualcustomerid.Id),
                         (int)ContactState.Active, (int)contact_statuscode.Active);
                }

            }
            else if (orderCaptureEntity.etel_corporatecustomerid != null)
            {
                var account = (Account)ContextProvider.OrganizationService.Retrieve(Account.EntityLogicalName,
                    orderCaptureEntity.etel_corporatecustomerid.Id,
                    new ColumnSet(true));

                externalId = account.etel_externalid;
                accountGuid = account.AccountId;

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

            // Get all addresss from order items to build request. Remove duplicates and add to request
            var addressList = new List<Microsoft.Xrm.Sdk.Entity>();
            foreach (var item in orderItems)
            {
                addressList.AddRange(RetrieveRelatedAddress(item));
            }
            request.relatedEntities = new List<RelatedEntity>();

            addressList = addressList.GroupBy(x => x.Id).Select(x => x.First()).ToList<Microsoft.Xrm.Sdk.Entity>();
            AddRelatedAddressToRequest(addressList, request);

            // Get all customer accounts and appointment logs from order items to build request. Remove duplicates and add to request
            var customerAccountList = new List<String>();
            var appointmentLogList = new List<AmxCoAppointmentLogModel>();
            var orderResourceList = new List<etel_orderresource>();
            foreach (var item in orderItems)
            {
                var customerAccount = RetrieveRelatedAccountFromOrderItem(item.Id);
                if (customerAccount != null) customerAccountList.Add(customerAccount);

                var appointmentLog = RetrieveRelatedAppointmentLogFromOrderItem(item.Id);
                if (appointmentLog.etel_appointmentlogid != Guid.Empty && appointmentLogList.Find(x => x.etel_name.Equals(appointmentLog.etel_name)) == null)
                    appointmentLogList.Add(appointmentLog);
            }

            customerAccountList = customerAccountList.Distinct().ToList<String>();
            AddRelatedAccountsToRequest(customerAccountList, request.relatedEntities);
            AddRelatedAppointmentToRequest(appointmentLogList, request.relatedEntities);


            //TODO: 
            //var billingAccountEmailList = billingAccountBusiness.RetrieveBillingAccountByCustomerId(accountGuid, contactGuid)
            //                                                    .Where(b => b.Attributes.Contains("amxperu_emailaddress"))
            //                                                    .Select(b => b.Attributes["amxperu_emailaddress"]?.ToString())
            //                                                    .ToList();

            //for (int i = 0; i < billingAccountEmailList.Count; i++)
            //{
            //    customerInfoAttributeList.Add(new Model.OrderCaptureSubmit.Attribute() { name = "EMAIL" + (i + 1).ToString(), value = billingAccountEmailList[i] });
            //}

            var customerInfoAttributeList = new List<Model.OrderCaptureSubmit.Attribute>();
            customerInfoAttributeList.Add(new Model.OrderCaptureSubmit.Attribute() { name = "FIRSTNAME", value = firstName });
            customerInfoAttributeList.Add(new Model.OrderCaptureSubmit.Attribute() { name = "LASTNAME", value = lastName });

            for (int i = 0; i < customerEmailList.Where(c=>c != null)?.ToList().Count; i++)
            {
                customerInfoAttributeList.Add(new Model.OrderCaptureSubmit.Attribute() { name = "EMAIL" + (i + 1).ToString(), value = customerEmailList[i] });
            }

            var partyCustomer = new Party()
            {
                CustomerInformation = new CustomerInformation()
                {
                    attributes = customerInfoAttributeList
                }
            };

            RelatedParty relatedParty = new RelatedParty()
            {
                role = "Customer",
                reference = externalId,
                party = partyCustomer

            };

            request.relatedParties = new List<RelatedParty>();
            request.relatedParties.Add(relatedParty);

            request.orderItems = new List<Model.OrderCaptureSubmit.OrderItem>();

            var basicOfferingOrderItems = orderItems.Where(a => a.etel_parentorderitemid is null).ToList();

            // Initialize ID for order items
            Double referenceNumber = 0;

            // Initialize ID for contracts
            Double contractRef = 0;

            // TO CHANGE - ADD
            etel_orderitem eMTA = new etel_orderitem();

            foreach (var item in basicOfferingOrderItems)
            {
                var crmOffering = ContextProvider.OrganizationService.Retrieve(Ericsson.ETELCRM.Entities.Crm.Product.EntityLogicalName,
                    item.etel_offeringid.Id, new ColumnSet(true));

                // Get Customized Order Item model
                var orderItemRepository = new OrderItemRepository(ContextProvider.OrganizationService);
                var orderItemModel = orderItemRepository.RetrieveCustomizedOrderItemByOrder(item.Id);

                Model.OrderCaptureSubmit.OrderItem orderItem = new Model.OrderCaptureSubmit.OrderItem();
                orderItem.item = new Item();

                orderItem.item.relatedEntities = new List<RelatedEntity>();

                if (item.etel_offeringid.Name == "Servicio Telefonia Fija" || item.etel_offeringid.Name == "Segunda Linea Telefonia Fija")
                {
                    orderItem.item.relatedEntities.Add(new RelatedEntity()
                    {
                        type = "Contract",
                        name = "ContractId",
                        reference = "CONT000" + contractRef++,
                        entity = new Model.OrderCaptureSubmit.Entity()
                        {
                            contractCreationInformation = new ContractCreationInformation()
                            {
                                attributes = new List<Model.OrderCaptureSubmit.Attribute>()
                            {
                                new Model.OrderCaptureSubmit.Attribute() {name="MARKET",value="ISD"},
                                new Model.OrderCaptureSubmit.Attribute() {name="SUBMARKET",value="ISDNe"},
                                new Model.OrderCaptureSubmit.Attribute() {name="NETWORK",value="DUMCO"},
                            }
                            }
                        }
                    });
                }
                else
                {
                    if (item.etel_offeringid.Name == "Servicio Movil Prepago")
                    {
                        orderItem.item.relatedEntities.Add(new RelatedEntity()
                        {
                            type = "Contract",
                            name = "ContractId",
                            reference = "CONT000" + contractRef++,
                            entity = new Model.OrderCaptureSubmit.Entity()
                            {
                                contractCreationInformation = new ContractCreationInformation()
                                {
                                    attributes = new List<Model.OrderCaptureSubmit.Attribute>()
                            {
                                new Model.OrderCaptureSubmit.Attribute() {name="MARKET",value="GSM"},
                                new Model.OrderCaptureSubmit.Attribute() {name="SUBMARKET",value="GSMi"},
                                new Model.OrderCaptureSubmit.Attribute() {name="NETWORK",value="COLCM"},
                            }
                                }
                            }
                        });
                    }
                    else
                    {
                        orderItem.item.relatedEntities.Add(new RelatedEntity()
                        {
                            type = "Contract",
                            name = "ContractId",
                            reference = "CONT000" + contractRef++,
                            entity = new Model.OrderCaptureSubmit.Entity()
                            {
                                contractCreationInformation = new ContractCreationInformation()
                                {
                                    attributes = new List<Model.OrderCaptureSubmit.Attribute>()
                            {
                                new Model.OrderCaptureSubmit.Attribute() {name="MARKET",value="ISD"},
                                new Model.OrderCaptureSubmit.Attribute() {name="SUBMARKET",value="ISDNi"},
                                new Model.OrderCaptureSubmit.Attribute() {name="NETWORK",value="DUMCO"},
                            }
                                }
                            }
                        });
                    }
                }

                // Add the related addresses to basic po
                var basicPoAddressList = new List<Microsoft.Xrm.Sdk.Entity>();
                basicPoAddressList.AddRange(RetrieveRelatedAddress(item));
                AddRelatedAddressesToOrderItem(basicPoAddressList, request.relatedEntities, orderItem.item.relatedEntities);

                // Add related account to basic po
                var basicPoAccount = RetrieveRelatedAccountFromOrderItem(item.Id);
                if (basicPoAccount != null) AddRelatedAccountToOrderItem(basicPoAccount, request.relatedEntities, orderItem.item.relatedEntities);

                // Add related appointment to basic po
                var basicPoAppointmentLog = RetrieveRelatedAppointmentLogFromOrderItem(item.Id);
                if (basicPoAppointmentLog != null) AddRelatedAppointmentLogToOrderItem(basicPoAppointmentLog, request.relatedEntities, orderItem.item.relatedEntities);

                Model.OrderCaptureSubmit.Resource simCardResource = new Model.OrderCaptureSubmit.Resource();
                orderItem.item.resources = RetrieveRelatedOrderResourceFromOrderItem(item.Id, ref simCardResource) ?? null;

                // Obtaining order item action amx_action
                orderItem.item.action = RetrieveAction(item.Id);

                orderItem.item.orderType = "ProductOfferingOrder";
                orderItem.item.productOffering = new ProductOffering() { id = (crmOffering as Ericsson.ETELCRM.Entities.Crm.Product).etel_externalid };

                //Associate the reference id and increment counter
                orderItem.item.id = Convert.ToString(referenceNumber);
                referenceNumber++;

                orderItem.item.product = new Model.OrderCaptureSubmit.Product();

                // Associate the SR product id to request product id
                if (orderItemModel.amx_productsrid != null) orderItem.item.product.productId = orderItemModel.amx_productsrid;

                orderItem.item.attrs = new List<Attr>();
                orderItem.item.attrs.Add(new Attr() { name = "CrmOrderId", value = orderCaptureEntity.etel_name });

                // Getting product characteristic from offer and adding to request
                orderItem.item.product.productCharacteristics = new List<ProductCharacteristic>();
                AddCharacteristicsToOrderItem(item.etel_offeringid.Id, orderItem.item);

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

                AddRelatedPriceTypeOrderItem(orderItemModel, orderItem.item.product.productPrices);

                request.orderItems.Add(orderItem);

                // Iterates through child POs
                List<etel_orderitem> childPOOfThisOfferings = new List<etel_orderitem>();
                foreach (var optional in orderItems)
                {
                    if (optional.Attributes.Contains("etel_parentorderitemid"))
                    {
                        if (optional.etel_parentorderitemid.Id == item.Id)
                        {
                            childPOOfThisOfferings.Add(optional);
                        }
                    }
                }

                //Add PO to request
                foreach (var optional in childPOOfThisOfferings)
                {
                    AddPO(orderItem, optional, orderItems, request, ref referenceNumber, (referenceNumber - 1));
                }


                eMTA = orderItems.Find(x => x.etel_offeringid.Name.Contains("Docsis"));
            }

            if (eMTA != null && eMTA.Id != Guid.Empty)
                AddPOeMTA(eMTA, orderItems, request, ref referenceNumber);

            var jsonPayLoadPostedToEoc = new JavaScriptSerializer().Serialize(request);
            SubmitRequest.Set(context, request);
        }

        // Finds each child po and adds to the request
        public void AddPOeMTA(etel_orderitem orderItemToAdd, List<etel_orderitem> orderItems, SubmitOrderRequest request, ref double referenceNumber)
        {
            // First add the optional po to output list (request for submit)
            var crmChildOffering = ContextProvider.OrganizationService.Retrieve(Ericsson.ETELCRM.Entities.Crm.Product.EntityLogicalName,
                        orderItemToAdd.etel_offeringid.Id, new ColumnSet(true));

            // Get Customized Order Item model
            var orderItemRepository = new OrderItemRepository(ContextProvider.OrganizationService);
            var orderItemModel = orderItemRepository.RetrieveCustomizedOrderItemByOrder(orderItemToAdd.Id);

            Model.OrderCaptureSubmit.OrderItem childOrderItem = new Model.OrderCaptureSubmit.OrderItem();

            var relatedOrderItems = new List<RelatedOrderItem>();
            // Find the fixed phone and internet services and create relation
            var parentItem = request.orderItems.Find(x => x.item.productOffering.id.Equals("PO_TelPosBasic"));
            if (parentItem != null)
                relatedOrderItems.Add(new RelatedOrderItem()
                {
                    //role = "ReliesOn",
                    role = "ChildOf",
                    //relatedBasicPoCode = orderItem.item.productOffering.id
                    reference = parentItem.item.id
                });

            parentItem = request.orderItems.Find(x => x.item.productOffering.id.Equals("PO_IntDatPosServInternet"));
            if (parentItem != null)
                relatedOrderItems.Add(new RelatedOrderItem()
                {
                    //role = "ReliesOn",
                    role = "ChildOf",
                    //relatedBasicPoCode = orderItem.item.productOffering.id
                    reference = parentItem.item.id
                });

            parentItem = request.orderItems.Find(x => x.item.productOffering.id.Equals("PO_TelPosSegundaLinea"));
            if (parentItem != null)
                relatedOrderItems.Add(new RelatedOrderItem()
                {
                    //role = "ReliesOn",
                    role = "ChildOf",
                    //relatedBasicPoCode = orderItem.item.productOffering.id
                    reference = parentItem.item.id
                });

            childOrderItem.item = new Item()
            {
                action = RetrieveAction(orderItemToAdd.Id),
                orderType = "ProductOfferingOrder",
                id = Convert.ToString(referenceNumber),
                productOffering = new ProductOffering()
                {
                    id = (crmChildOffering as Ericsson.ETELCRM.Entities.Crm.Product).etel_externalid
                },
                relatedOrderItems = relatedOrderItems,


            };
            childOrderItem.item.id = referenceNumber.ToString();
            referenceNumber++;

            // Add the related addresses to po
            var poAddressList = new List<Microsoft.Xrm.Sdk.Entity>();
            childOrderItem.item.relatedEntities = new List<RelatedEntity>();
            poAddressList.AddRange(RetrieveRelatedAddress(orderItemToAdd));
            AddRelatedAddressesToOrderItem(poAddressList, request.relatedEntities, childOrderItem.item.relatedEntities);

            // Add related account to basic po
            var poAccount = RetrieveRelatedAccountFromOrderItem(orderItemToAdd.Id);
            if (poAccount != null) AddRelatedAccountToOrderItem(poAccount, request.relatedEntities, childOrderItem.item.relatedEntities);

            // Add related appointment to basic po
            var poAppointmentLog = RetrieveRelatedAppointmentLogFromOrderItem(orderItemToAdd.Id);
            if (poAppointmentLog != null) AddRelatedAppointmentLogToOrderItem(poAppointmentLog, request.relatedEntities, childOrderItem.item.relatedEntities);

            Model.OrderCaptureSubmit.Resource simCardResource = new Model.OrderCaptureSubmit.Resource();
            childOrderItem.item.resources = RetrieveRelatedOrderResourceFromOrderItem(orderItemToAdd.Id, ref simCardResource) ?? null;

            // Obtaining order item action amx_action
            childOrderItem.item.action = RetrieveAction(orderItemToAdd.Id);

            // Getting product characteristic from offer and adding to request
            childOrderItem.item.product = new Model.OrderCaptureSubmit.Product();
            childOrderItem.item.product.productCharacteristics = new List<ProductCharacteristic>();
            AddCharacteristicsToOrderItem(orderItemToAdd.etel_offeringid.Id, childOrderItem.item);

            // Loop through product prices and add to item
            childOrderItem.item.product = new AmxPeruPSBActivities.Model.OrderCaptureSubmit.Product();
            childOrderItem.item.product.productPrices = new List<ProductPrice>();
            /*var priceList = RetrieveRelatedPrices(orderItemToAdd);
            AddRelatedPricessToOrderItem(priceList, childOrderItem.item.product.productPricess);*/
            AddRelatedPriceTypeOrderItem(orderItemModel, childOrderItem.item.product.productPrices);

            // Associate the SR product id to request product id
            if (orderItemModel.amx_productsrid != null) childOrderItem.item.product.productId = orderItemModel.amx_productsrid;

            request.orderItems.Add(childOrderItem);
        }

        // Finds each child po and adds to the request
        public void AddPO(Model.OrderCaptureSubmit.OrderItem parentOrderItem, etel_orderitem orderItemToAdd, List<etel_orderitem> orderItems, SubmitOrderRequest request, ref double referenceNumber, double basicPOReference)
        {
            // First add the optional po to output list (request for submit)
            var crmChildOffering = ContextProvider.OrganizationService.Retrieve(Ericsson.ETELCRM.Entities.Crm.Product.EntityLogicalName,
                        orderItemToAdd.etel_offeringid.Id, new ColumnSet(true));

            // Get Customized Order Item model
            var orderItemRepository = new OrderItemRepository(ContextProvider.OrganizationService);
            var orderItemModel = orderItemRepository.RetrieveCustomizedOrderItemByOrder(orderItemToAdd.Id);

            Model.OrderCaptureSubmit.OrderItem childOrderItem = new Model.OrderCaptureSubmit.OrderItem();

            childOrderItem.item = new Item()
            {
                action = RetrieveAction(orderItemToAdd.Id),
                orderType = "ProductOfferingOrder",
                id = Convert.ToString(referenceNumber),
                productOffering = new ProductOffering()
                {
                    id = (crmChildOffering as Ericsson.ETELCRM.Entities.Crm.Product).etel_externalid
                },
                relatedOrderItems = new List<RelatedOrderItem>()
                            {
                                new RelatedOrderItem()
                                {
                                    //role = "ReliesOn",
                                    role = "ChildOf",
                                    //relatedBasicPoCode = orderItem.item.productOffering.id
                                    reference = basicPOReference.ToString()
                                }
                            }
            };
            childOrderItem.item.id = referenceNumber.ToString();
            referenceNumber++;

            // Add the related addresses to po
            var poAddressList = new List<Microsoft.Xrm.Sdk.Entity>();
            childOrderItem.item.relatedEntities = new List<RelatedEntity>();
            poAddressList.AddRange(RetrieveRelatedAddress(orderItemToAdd));
            AddRelatedAddressesToOrderItem(poAddressList, request.relatedEntities, childOrderItem.item.relatedEntities);

            // Add related account to basic po
            var poAccount = RetrieveRelatedAccountFromOrderItem(orderItemToAdd.Id);
            if (poAccount != null) AddRelatedAccountToOrderItem(poAccount, request.relatedEntities, childOrderItem.item.relatedEntities);

            // Add related appointment to basic po
            var poAppointmentLog = RetrieveRelatedAppointmentLogFromOrderItem(orderItemToAdd.Id);
            if (poAppointmentLog != null) AddRelatedAppointmentLogToOrderItem(poAppointmentLog, request.relatedEntities, childOrderItem.item.relatedEntities);

            Model.OrderCaptureSubmit.Resource simCardResource = new Model.OrderCaptureSubmit.Resource();
            childOrderItem.item.resources = RetrieveRelatedOrderResourceFromOrderItem(orderItemToAdd.Id, ref simCardResource) ?? null;

            // Add the sim card resource to the related basic po
            if(simCardResource.resourceSpecification != null)
                request.orderItems.Find(x => x.item.id.Equals(basicPOReference.ToString())).item.resources.Add(simCardResource);

            // Obtaining order item action amx_action
            childOrderItem.item.action = RetrieveAction(orderItemToAdd.Id);

            // Getting product characteristic from offer and adding to request
            childOrderItem.item.product = new Model.OrderCaptureSubmit.Product();
            childOrderItem.item.product.productCharacteristics = new List<ProductCharacteristic>();
            AddCharacteristicsToOrderItem(orderItemToAdd.etel_offeringid.Id, childOrderItem.item);

            // Loop through product prices and add to item
            childOrderItem.item.product = new AmxPeruPSBActivities.Model.OrderCaptureSubmit.Product();
            childOrderItem.item.product.productPrices = new List<ProductPrice>();
            /*var priceList = RetrieveRelatedPrices(orderItemToAdd);
            AddRelatedPricessToOrderItem(priceList, childOrderItem.item.product.productPricess);*/
            AddRelatedPriceTypeOrderItem(orderItemModel, childOrderItem.item.product.productPrices);

            // Associate the SR product id to request product id
            if (orderItemModel.amx_productsrid != null) childOrderItem.item.product.productId = orderItemModel.amx_productsrid;

            request.orderItems.Add(childOrderItem);

            // Iterates through child POs
            List<etel_orderitem> childPOOfThisOfferings = new List<etel_orderitem>();
            foreach (var optional in orderItems)
            {

                if (optional.Attributes.Contains("etel_parentorderitemid"))
                {
                    // Exclude docsis from the request
                    if (optional.etel_parentorderitemid.Id == orderItemToAdd.Id && !optional.etel_offeringid.Name.Contains("Docsis"))
                    {
                        childPOOfThisOfferings.Add(optional);
                    }
                }
            }

            if (childPOOfThisOfferings.Count() > 0)
            {
                foreach (var childItem in childPOOfThisOfferings)
                {
                    AddPO(childOrderItem, childItem, orderItems, request, ref referenceNumber, basicPOReference);
                }
            }
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

        public List<Microsoft.Xrm.Sdk.Entity> RetrieveRelatedAddress(etel_orderitem orderItem)
        {
            var relatedAddresses = new List<Microsoft.Xrm.Sdk.Entity>();

            ConditionExpression condition = new ConditionExpression();
            condition.AttributeName = "amx_orderitemid";
            condition.Operator = ConditionOperator.Equal;
            condition.Values.Add(orderItem.Id.ToString());

            ColumnSet columns = new ColumnSet("amx_customeraddressid");

            QueryExpression query1 = new QueryExpression();
            query1.ColumnSet = columns;
            query1.EntityName = "amx_orderitemcustomeraddress";
            query1.Criteria.AddCondition(condition);

            EntityCollection result1 = ContextProvider.OrganizationService.RetrieveMultiple(query1);

            foreach (var entity in result1.Entities)
            {
                relatedAddresses.Add(RetrieveAddressFromGuid(((EntityReference)entity.Attributes["amx_customeraddressid"]).Id));
            }

            return relatedAddresses;
        }

        public List<Microsoft.Xrm.Sdk.Entity> RetrieveRelatedPrices(etel_orderitem orderItem)
        {
            var relatedPrices = new List<Microsoft.Xrm.Sdk.Entity>();

            ConditionExpression condition = new ConditionExpression();
            condition.AttributeName = "amx_orderitemid";
            condition.Operator = ConditionOperator.Equal;
            condition.Values.Add(orderItem.Id.ToString());

            ColumnSet columns = new ColumnSet("amx_popid");

            QueryExpression query1 = new QueryExpression();
            query1.ColumnSet = columns;
            query1.EntityName = "amx_orderitempop";
            query1.Criteria.AddCondition(condition);

            EntityCollection result1 = ContextProvider.OrganizationService.RetrieveMultiple(query1);

            foreach (var entity in result1.Entities)
            {
                var productOfferingPriceRepository = new AmxCoProductOfferingPriceRepository(ContextProvider.OrganizationService);
                var productOfferingPriceModel = productOfferingPriceRepository.GetProductOfferingPrice(((EntityReference)entity.Attributes["amx_popid"]).Id);
                relatedPrices.Add(AmxCoProductOfferingPriceFactory.CreateEntityFrom(productOfferingPriceModel));
            }

            return relatedPrices;
        }

        public Microsoft.Xrm.Sdk.Entity RetrieveAddressFromGuid(Guid guid)
        {
            // Instaniate an account object.
            Microsoft.Xrm.Sdk.Entity address = new Microsoft.Xrm.Sdk.Entity("etel_customeraddress");
            ColumnSet attributes = new ColumnSet(new string[] { "etel_customeraddressid", "etel_name", "amx_cityarea", "etel_cityid",
                "amxperu_district", "etel_addressnumber", "amx_addressid", "etel_postalcode" });

            address = ContextProvider.OrganizationService.Retrieve(address.LogicalName, guid, attributes);

            return address;
        }

        public RelatedEntity SetEntityAddress(Microsoft.Xrm.Sdk.Entity address, Double addressReference)
        {
            /* Verify null values in in request */
            var addressName = (address.Attributes.Keys.Contains("etel_name") ? address["etel_name"].ToString() : null);
            var addressCityArea = (address.Attributes.Keys.Contains("amx_cityarea") ? ((EntityReference)address["amx_cityarea"]).Name : null);
            var addressCityId = (address.Attributes.Keys.Contains("etel_cityid") ? ((EntityReference)address["etel_cityid"]).Name : null);
            var addressDistrict = (address.Attributes.Keys.Contains("amxperu_district") ? ((EntityReference)address["amxperu_district"]).Name : null);
            var addressCustomerId = (address.Attributes.Keys.Contains("etel_customeraddressid") ? address["etel_customeraddressid"].ToString() : null);
            var addressNumber = (address.Attributes.Keys.Contains("etel_addressnumber") ? address["etel_addressnumber"].ToString() : null);
            var addressId = (address.Attributes.Keys.Contains("amx_addressid") ? address["amx_addressid"].ToString() : null);
            var addressDane = (address.Attributes.Keys.Contains("etel_postalcode") ? address["etel_postalcode"].ToString() : null);

            // Get Claro City Code
            var cityEntity = RetrieveRelatedCity(((EntityReference)address["etel_cityid"]).Id.ToString());
            var addressCityClaroCode = (cityEntity.Attributes.Keys.Contains("amx_clarocode") ? cityEntity["amx_clarocode"].ToString() : null);
            var estrato = customerAddressBusiness.RetrieveEstratoByAddressId(address["etel_customeraddressid"].ToString());

            var addressEntity = new RelatedEntity()
            {
                type = "Place",
                reference = addressReference.ToString(),
                entity = new Model.OrderCaptureSubmit.Entity()
                {
                    locationInformation = new LocationInformation()
                    {
                        attributes = new List<Model.OrderCaptureSubmit.Attribute>()
                            {
                                new Model.OrderCaptureSubmit.Attribute() {name="DIRECCION",value = addressName},
                                new Model.OrderCaptureSubmit.Attribute() {name="REGIONAL",value=addressCityArea},
                                new Model.OrderCaptureSubmit.Attribute() {name="CIUDAD",value=addressCityId},
                                new Model.OrderCaptureSubmit.Attribute() {name="CITY_CODE",value=addressCityClaroCode},
                                new Model.OrderCaptureSubmit.Attribute() {name="DISCTRICTO",value = addressDistrict},
                                new Model.OrderCaptureSubmit.Attribute() {name="ID",value=addressId},
                                new Model.OrderCaptureSubmit.Attribute() {name="NUMBER",value=addressNumber},
                                new Model.OrderCaptureSubmit.Attribute() {name="TCRMID",value=addressCustomerId},
                                new Model.OrderCaptureSubmit.Attribute() {name="DANE",value=addressDane},
                                new Model.OrderCaptureSubmit.Attribute() {name="ESTRATO",value=estrato}
                            }
                    }
                }
            };

            return addressEntity;
        }

        public ProductPrice SetEntityPrice(Microsoft.Xrm.Sdk.Entity price)
        {
            // Decalre offering price repository to retrieve the period code
            var productOfferingPriceRepository = new AmxCoProductOfferingPriceRepository(ContextProvider.OrganizationService);

            /* Verify null values in in request */
            var priceExternalId = (price.Attributes.Keys.Contains("amxperu_externalid") && price["amxperu_externalid"] != null ? price["amxperu_externalid"].ToString() : null);
            var priceName = (price.Attributes.Keys.Contains("amxperu_name") && price["amxperu_name"] != null ? price["amxperu_name"].ToString() : null);
            var pricePeriodCode = (price.Attributes.Keys.Contains("amxperu_periodcode") && price["amxperu_periodcode"] != null ? productOfferingPriceRepository.GetPriceCodeTranslation(((OptionSetValue)price["amxperu_periodcode"]).Value.ToString()) : null);
            var priceValue = (price.Attributes.Keys.Contains("amxperu_price") && price["amxperu_price"] != null ? ((Money)price["amxperu_price"]).Value.ToString("0.00") : null);
            var priceBase = (price.Attributes.Keys.Contains("amxperu_price_base") && price["amxperu_price_base"] != null ? ((Money)price["amxperu_price_base"]).Value.ToString("0.00") : null);
            var priceTypeCode = (price.Attributes.Keys.Contains("amxperu_pricetypecode") && price["amxperu_pricetypecode"] != null ? GetoptionsetText(price.LogicalName, "amxperu_pricetypecode", ((OptionSetValue)price["amxperu_pricetypecode"]).Value, ContextProvider.OrganizationService) : null);
            var priceOfferingId = (price.Attributes.Keys.Contains("amxperu_productofferingid") && price["amxperu_productofferingid"] != null ? ((EntityReference)price["amxperu_productofferingid"]).Id.ToString() : null);
            String priceCurrency = null;

            // Going to DB to retrieve currency entity and get iso code
            if (price.Attributes.Keys.Contains("transactioncurrencyid") && price["transactioncurrencyid"] != null)
            {
                var currencyRepository = new AmxCoCurrencyRepository(ContextProvider.OrganizationService);
                var currencyModel = currencyRepository.GetCurrency(((EntityReference)price["transactioncurrencyid"]).Id);
                priceCurrency = currencyModel.isocurrencycode;
            }

            var productPrice = new ProductPrice()
            {
                amount = priceValue,
                taxCode = null,
                frequency = pricePeriodCode,
                currency = priceCurrency,
                chargeTypeCode = null,
                popId = priceName,
                priceType = priceTypeCode,
                characteristics = null,
                name = priceName,
                externalIds = priceExternalId,
                unitOfMeasure = null,
                description = priceName
            };

            return productPrice;
        }

        public static string GetoptionsetText(string entityName, string attributeName, int optionSetValue, IOrganizationService service)
        {
            string AttributeName = attributeName;
            string EntityLogicalName = entityName;
            RetrieveEntityRequest retrieveDetails = new RetrieveEntityRequest
            {
                EntityFilters = EntityFilters.All,
                LogicalName = EntityLogicalName
            };
            RetrieveEntityResponse retrieveEntityResponseObj = (RetrieveEntityResponse)service.Execute(retrieveDetails);
            Microsoft.Xrm.Sdk.Metadata.EntityMetadata metadata = retrieveEntityResponseObj.EntityMetadata;
            Microsoft.Xrm.Sdk.Metadata.PicklistAttributeMetadata picklistMetadata = metadata.Attributes.FirstOrDefault(attribute => String.Equals(attribute.LogicalName, attributeName, StringComparison.OrdinalIgnoreCase)) as Microsoft.Xrm.Sdk.Metadata.PicklistAttributeMetadata;
            Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata options = picklistMetadata.OptionSet;
            IList<OptionMetadata> OptionsList = (from o in options.Options
                                                 where o.Value.Value == optionSetValue
                                                 select o).ToList();
            string optionsetLabel = (OptionsList.First()).Label.UserLocalizedLabel.Label;
            return optionsetLabel;
        }

        public RelatedEntity SetEntityAddressRelation(String addressReference)
        {
            var addressEntity = new RelatedEntity()
            {
                type = "Place",
                reference = addressReference
            };

            return addressEntity;
        }

        public RelatedEntity SetEntityAccountRelation(String customerAccountReference)
        {
            var customerAccountEntity = new RelatedEntity()
            {
                type = "CustomerAccount",
                reference = customerAccountReference
            };

            return customerAccountEntity;
        }

        public RelatedEntity SetEntityAppointmentLogRelation(String appointmentLogReference)
        {
            var appointmentEntity = new RelatedEntity()
            {
                type = "Appointment",
                reference = appointmentLogReference
            };

            return appointmentEntity;
        }

        public void AddRelatedAddressToRequest(List<Microsoft.Xrm.Sdk.Entity> addressList, SubmitOrderRequest request)
        {
            Double addresReference = 0;
            foreach (var address in addressList)
            {
                request.relatedEntities.Add(SetEntityAddress(address, addresReference++));
            }
        }

        public void AddRelatedPricessToOrderItem(List<Microsoft.Xrm.Sdk.Entity> priceList, List<ProductPrice> requestListProductPrice)
        {
            foreach (var price in priceList)
            {
                requestListProductPrice.Add(SetEntityPrice(price));
            }
        }

        public void AddRelatedAddressesToOrderItem(List<Microsoft.Xrm.Sdk.Entity> poAddressList, List<RelatedEntity> fullAddressList, List<RelatedEntity> orderItemRelatedEntities)
        {
            var relatedEntity = new RelatedEntity();

            foreach (var address in poAddressList)
            {
                relatedEntity = fullAddressList.Find(x => x.entity.locationInformation.attributes.Find(y => y.name.Equals("TCRMID")).value.Equals(address.Attributes["etel_customeraddressid"].ToString()));
                if (relatedEntity != null)
                {
                    orderItemRelatedEntities.Add(SetEntityAddressRelation(relatedEntity.reference));
                }
            }
        }

        public String RetrieveAction(Guid Id)
        {
            var orderItemRepository = new OrderItemRepository(ContextProvider.OrganizationService);
            var orderItemModel = orderItemRepository.RetrieveCustomizedOrderItemByOrder(Id);

            return GetoptionsetText("etel_orderitem", "amx_action", orderItemModel.amx_action.Value, ContextProvider.OrganizationService);
        }

        public String RetrieveRelatedAccountFromOrderItem(Guid Id)
        {
            var orderItemRepository = new OrderItemRepository(ContextProvider.OrganizationService);
            var orderItemModel = orderItemRepository.RetrieveCustomizedOrderItemByOrder(Id);

            return orderItemModel.amx_billingaccountexternalid;
        }

        public AmxCoAppointmentLogModel RetrieveRelatedAppointmentLogFromOrderItem(Guid Id)
        {
            var appointmentLogRepository = new AmxCoAppointmentLogRepository(ContextProvider.OrganizationService);
            var appointmentLog = appointmentLogRepository.RetrieveAppointmentLogByOrderItem(Id);

            return appointmentLog;
        }

        public List<Model.OrderCaptureSubmit.Resource> RetrieveRelatedOrderResourceFromOrderItem(Guid orderItemId, ref Model.OrderCaptureSubmit.Resource simCardResource)
        {
            var orderItemResourceList = new List<Model.OrderCaptureSubmit.Resource>();

            List<ResourceCharacteristic> resourceCharList;
            Model.OrderCaptureSubmit.Resource orderItemResource;

            OrderResourceBusiness orderResourceBusiness = new OrderResourceBusiness(ContextProvider);

            var orderResources = orderResourceBusiness.RetrieveOrderResourceCharacteristicsByOrderItemId(orderItemId)?
                                                      .GroupBy(x => x.GetAttributeValue<AliasedValue>("etel_orderresource.etel_orderresourceid")?.Value, (key, value) => new { orderResourceId = key, Entities = value.ToList() });

            foreach (var orderResource in orderResources)
            {
                orderItemResource = new Model.OrderCaptureSubmit.Resource();
                resourceCharList = new List<ResourceCharacteristic>();

                foreach (var item in orderResource.Entities)
                {
                    if (item?.GetAttributeValue<AliasedValue>("etel_orderresourcecharacteric.etel_value") != null)
                    {
                        var resourceCharModel = new ResourceCharacteristic
                        {
                            name = item?.GetAttributeValue<AliasedValue>("amxperu_resourcecharacteristic.amxperu_externalid")?.Value?.ToString(),
                            value = item?.GetAttributeValue<AliasedValue>("etel_orderresourcecharacteric.etel_value")?.Value?.ToString()
                        };

                        resourceCharList.Add(resourceCharModel);
                    }
                }
                orderItemResource.resourceCharacteristics = resourceCharList;
                orderItemResource.resourceSpecification = orderResource?.Entities?.GroupBy(x => x.Attributes["etel_externalid"])?.FirstOrDefault()?.Key?.ToString();
                orderItemResource.isLogical = ((OptionSetValue)orderResource?.Entities?.GroupBy(x => x.Attributes["amxperu_resourcetypecode"])?.FirstOrDefault()?.Key)?.Value == 1; //1 is logical resource

                // Do not add sim card phisical resource to the list
                if (!orderItemResource.resourceSpecification.Equals("PRS_MovSimCard"))
                {
                    orderItemResourceList.Add(orderItemResource);
                    simCardResource = null;
                }
                else simCardResource = orderItemResource;
            }

            return orderItemResourceList;
        }

        public RelatedEntity SetEntityAccount(String account, Double reference)
        {
            var relatedEntity = new RelatedEntity()
            {
                type = "CustomerAccount",
                name = account,
                reference = reference.ToString()
            };

            return relatedEntity;
        }

        public void AddRelatedAccountsToRequest(List<String> customerAccountList, List<RelatedEntity> requestRelatedEntities)
        {
            Double reference = 0;

            foreach (var custoMerAccount in customerAccountList)
            {
                requestRelatedEntities.Add(SetEntityAccount(custoMerAccount, reference++));
            }
        }

        public void AddRelatedAccountToOrderItem(String accountToAdd, List<RelatedEntity> fullRelatedEntityList, List<RelatedEntity> orderItemRelatedEntities)
        {
            var relatedEntity = new RelatedEntity();

            foreach (var account in fullRelatedEntityList.Where(x => x.type.Equals("CustomerAccount")))
            {
                relatedEntity = fullRelatedEntityList.Find(x => !string.IsNullOrWhiteSpace(x.name) && x.name.Equals(accountToAdd));
                if (relatedEntity != null && account.name.Equals(accountToAdd))
                {
                    orderItemRelatedEntities.Add(SetEntityAccountRelation(relatedEntity.reference));
                }
            }
        }

        public void AddRelatedAppointmentLogToOrderItem(AmxCoAppointmentLogModel appoointmentLogToAdd, List<RelatedEntity> fullRelatedEntityList, List<RelatedEntity> orderItemRelatedEntities)
        {
            var relatedEntity = new RelatedEntity();

            foreach (var appointment in fullRelatedEntityList.Where(x => x.type.Equals("Appointment")))
            {
                if (appointment.name.Equals(appoointmentLogToAdd.etel_name))
                {
                    orderItemRelatedEntities.Add(SetEntityAppointmentLogRelation(appointment.reference));
                }
            }
        }

        public void AddRelatedPriceTypeOrderItem(Model.OrderItemModel orderItem, List<ProductPrice> requestListProductPrice)
        {
            if (requestListProductPrice == null)
                requestListProductPrice = new List<ProductPrice>();
            if (orderItem.etel_recurringcharge != null)
            { requestListProductPrice.Add(SetEntityPriceTypeMonthly(orderItem)); }
            if (orderItem.etel_onetimecharge != null)
            { requestListProductPrice.Add(SetEntityPriceTypeOneTime(orderItem)); }

        }

        public ProductPrice SetEntityPriceTypeMonthly(Model.OrderItemModel orderItem)
        {
            // Getting recurring
            var productPrice = new ProductPrice()
            {
                amount = orderItem.etel_recurringcharge.Value.ToString("0.00"),
                taxCode = null,
                frequency = "M",
                currency = "COP",
                chargeTypeCode = null,
                popId = orderItem.amx_popexternalid,
                priceType = "Recurring",
                characteristics = new List<ProductCharacteristic>() {
                    new ProductCharacteristic(){
                        name = "billingPricingType",
                        value = orderItem.amx_popexternalid}
                },
                externalIds = orderItem.amx_popexternalid,
                unitOfMeasure = null
            };

            return productPrice;
        }

        public ProductPrice SetEntityPriceTypeOneTime(Model.OrderItemModel orderItem)
        {
            // Getting recurring
            var productPrice = new ProductPrice()
            {
                amount = orderItem.etel_onetimecharge.Value.ToString("0.00"),
                taxCode = null,
                frequency = "O",
                currency = "COP",
                chargeTypeCode = null,
                popId = orderItem.amx_popexternalid,
                priceType = "One-Time",
                characteristics = new List<ProductCharacteristic>() {
                    new ProductCharacteristic(){
                        name = "billingPricingType",
                        value = orderItem.amx_popexternalid}
                },
                externalIds = orderItem.amx_popexternalid,
                unitOfMeasure = null

            };

            return productPrice;
        }

        public AmxCoAppointmentLogModel GetAppointmentLogByOrder(String orderName)
        {
            AmxCoAppointmentLogRepository appointmentLogRepository = new AmxCoAppointmentLogRepository(ContextProvider.OrganizationService);
            List<AmxCoAppointmentLogModel> listAppointmentLog = appointmentLogRepository.GetAppointmentLogFromOrderName(orderName);

            if (listAppointmentLog.Count() > 0)
                return listAppointmentLog[0];
            else return new AmxCoAppointmentLogModel();
        }

        public void AddRelatedAppointmentToRequest(List<AmxCoAppointmentLogModel> appointmentLogList, List<RelatedEntity> requestRelatedEntities)
        {
            Double reference = 0;

            foreach (AmxCoAppointmentLogModel appointmentLog in appointmentLogList)
            {
                requestRelatedEntities.Add(SetAppointment(appointmentLog, reference++));
            }
        }

        RelatedEntity SetAppointment(AmxCoAppointmentLogModel appointmentLog, Double reference)
        {
            var relatedEntity = new RelatedEntity()
            {
                type = "Appointment",
                name = appointmentLog.etel_name,
                reference = reference.ToString(),
                entity = new Model.OrderCaptureSubmit.Entity()
                {
                    appointmentInformation = new AppointmentInformation()
                    {
                        attributes = new List<Model.OrderCaptureSubmit.Attribute>(){
                            new Model.OrderCaptureSubmit.Attribute() {name="WorkOrderId",value=appointmentLog.amx_workorderid},
                            new Model.OrderCaptureSubmit.Attribute() {name="TechnicianId",value=""}
                        }
                    }
                }
            };

            return relatedEntity;
        }

        public Microsoft.Xrm.Sdk.Entity RetrieveRelatedCity(String guid)
        {
            var relatedCity = new Microsoft.Xrm.Sdk.Entity();

            ConditionExpression condition = new ConditionExpression();
            condition.AttributeName = "etel_cityid";
            condition.Operator = ConditionOperator.Equal;
            condition.Values.Add(guid);

            ColumnSet columns = new ColumnSet("amx_clarocode");

            QueryExpression query1 = new QueryExpression();
            query1.ColumnSet = columns;
            query1.EntityName = "etel_city";
            query1.Criteria.AddCondition(condition);

            var results = ContextProvider.OrganizationService.RetrieveMultiple(query1);

            if (results.Entities.Count() > 0)
                relatedCity = results[0];

            return relatedCity;
        }

        public void AddCharacteristicsToOrderItem(Guid offeringId, Item item)
        {
            OfferingsBusiness offeringBusiness = new OfferingsBusiness(ContextProvider);
            List<AmxPeruPSBActivities.Model.Characteristics> offeringCharacteristics = offeringBusiness.GetProductCharacteristics(offeringId);

            if (offeringCharacteristics.Count() > 0)
            {
                if (item.attrs == null)
                    item.attrs = new List<Attr>();
                foreach (AmxPeruPSBActivities.Model.Characteristics prodChar in offeringCharacteristics)
                {
                    // Add the product characteristic if not editable and has default value
                    if (!prodChar.editable && prodChar.inputValue != null && prodChar.inputValue != "")
                        item.attrs.Add(new Attr() { name = prodChar.etel_externalid, value = prodChar.inputValue });
                    // Add the product characteristic values
                    if (prodChar.ProdCharValues != null)
                        foreach (AmxPeruPSBActivities.Model.CharacteristicsValue charValue in prodChar.ProdCharValues)
                        {
                            if (charValue.value != null && charValue.value != "")
                                item.attrs.Add(new Attr() { name = prodChar.etel_externalid, value = charValue.value });
                        }
                }

            }

        }
    }
}