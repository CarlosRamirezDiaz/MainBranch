using AmxPeruCommonLibrary.Repository.Offering;
using AmxPeruPSBActivities.Model;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Activities;

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class UpdateShoppingCartDevice : XrmAwareCodeActivity
    {
        public InArgument<ProductCharacteristicsModel> ProductCharacteristicsModel { get; set; }
        public OutArgument<string> status { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            ProductCharacteristicsModel _ProductCharacteristicsModel = new Model.ProductCharacteristicsModel();
            _ProductCharacteristicsModel = ProductCharacteristicsModel.Get(context);            

            try
            {
                foreach (orderItem orderitem in _ProductCharacteristicsModel.listOrderItems)
                {
                    #region [Update Characteristics]
                    foreach (Characteristics characteristic in orderitem.listProdChar)
                    {
                        Guid orderProdutCharacteristicGuid = Guid.Empty;

                        //Get the Order Item Product Characteristic Record
                        EntityCollection orderProductCharacteristic = ContextProvider.OrganizationService.RetrieveMultiple(new QueryExpression
                        {
                            EntityName = "etel_orderproductcharacteristic",
                            ColumnSet = new ColumnSet(true),
                            Criteria =
                                        new FilterExpression()
                                        {
                                            Conditions =
                                                {
                                                            new ConditionExpression("etel_orderitemid", ConditionOperator.Equal, orderitem.guid),
                                                            new ConditionExpression("etel_characteristicid", ConditionOperator.Equal, characteristic.guid)
                                                }
                                        }
                        });

                        //Records should be found if Prod Char or CFSS char already Created
                        if (orderProductCharacteristic.Entities.Count > 0)
                        {
                            orderProdutCharacteristicGuid = orderProductCharacteristic.Entities[0].Id;
                        }
                        else
                        {
                            //Creates the CFSS Characteristics for OrderItem in TCRM
                            //"cfss" is a custom identifier values, passed while Reading the Product Characteristics, to ideitify if this char is cfss or noncfss
                            //That Same Model is used to Send Back to UpdateShoppingCart Workflow to for updating values & creating cfss Characteristics for OrderItem Characteristics
                            if (characteristic.type == "cfss")
                            {
                                Microsoft.Xrm.Sdk.Entity orderProdCharForCfss = new Microsoft.Xrm.Sdk.Entity("etel_orderproductcharacteristic");
                                orderProdCharForCfss.Attributes.Add("amxperu_iscfss", true);
                                orderProdCharForCfss.Attributes.Add("etel_orderitemid", new EntityReference("etel_orderitem", orderitem.guid));
                                orderProdCharForCfss.Attributes.Add("etel_characteristicid", new EntityReference("etel_productcharacteristic", characteristic.guidOfProdChar));
                                orderProdutCharacteristicGuid = ContextProvider.OrganizationService.Create(orderProdCharForCfss);
                            }
                        }

                        //Update Order Product Characteristic
                        Entity productcharacteristicForOrder = new Entity();
                        productcharacteristicForOrder.LogicalName = "etel_orderproductcharacteristic";
                        productcharacteristicForOrder.Id = orderProdutCharacteristicGuid;

                        if (characteristic.selectedProdCharValues != null)
                        {
                            productcharacteristicForOrder.Attributes.Add("etel_characteristicvalueid", new EntityReference("etel_productcharacteristicvalue", characteristic.selectedProdCharValues.guid));
                            productcharacteristicForOrder.Attributes.Add("etel_value", characteristic.selectedProdCharValues.value);
                        }
                        else
                        {
                            productcharacteristicForOrder.Attributes.Add("etel_characteristicid", new EntityReference("etel_productcharacteristic", characteristic.guidOfProdChar));
                            productcharacteristicForOrder.Attributes.Add("etel_value", characteristic.inputValue);
                        }
                        ContextProvider.OrganizationService.Update(productcharacteristicForOrder);
                    }
                    #endregion

                    #region [Update Pricing]

                    //Get the POP Configuration that Matches with the Scenario
                    AmxPeruOfferingRepository offeringRepository = new AmxPeruOfferingRepository();

                    QueryExpression orderProcharacteristics = new QueryExpression("etel_orderproductcharacteristic");
                    orderProcharacteristics.ColumnSet = new ColumnSet(true);
                    orderProcharacteristics.Criteria.AddCondition("etel_orderitemid", ConditionOperator.Equal, orderitem.guid);
                    EntityCollection prodCharCollection = ContextProvider.OrganizationService.RetrieveMultiple(orderProcharacteristics);
                    EntityCollection POPs = offeringRepository.RetrievePOPsByCharValueList(ContextProvider.OrganizationService, 
                                                                                            orderitem.OfferingGuid, 
                                                                                            prodCharCollection);

                    //There Must always be ONE Unique POP Config for a PO 
                    //by the Combination of ProductCharacteristics associated with the PO & the POP Char of the POPConfig Associated with PO
                    orderitem.PriceConfigurationGuid = (POPs.Entities[0].Attributes["amxperu_popconfiguration"] as EntityReference).Id;

                    int Deposit = 0, OneTimeCharge = 0, RecurringCharge = 0;

                    foreach (var price in POPs.Entities)
                    {
                        var priceType = (OptionSetValue)price.Attributes["amxperu_pricetypecode"];
                        int priceValue = Convert.ToInt32(((Money)price.Attributes["amxperu_price"]).Value);

                        switch (priceType.Value)
                        {
                            case (int)etel_pricetypecode.Deposit:
                                Deposit = Deposit + priceValue;
                                orderitem.DepositPrice = Deposit.ToString();
                                break;
                            case (int)etel_pricetypecode.OneTime:
                                OneTimeCharge = OneTimeCharge + priceValue;
                                orderitem.OneTimePrice = OneTimeCharge.ToString();
                                break;
                            case (int)etel_pricetypecode.Recurring:
                                RecurringCharge = RecurringCharge + priceValue;
                                orderitem.RecurringPrice = RecurringCharge.ToString();
                                break;
                            default:
                                break;
                        }
                    }

                    //Update the POP config record & Prices @ Order Item Level
                    if (orderitem.PriceConfigurationGuid != null)
                    {
                        Entity etel_orderitemRecord = new Entity();
                        etel_orderitemRecord.LogicalName = "etel_orderitem";
                        etel_orderitemRecord.Id = orderitem.guid;
                        etel_orderitemRecord.Attributes.Add("amxperu_offeringpriceconfigurationid", new EntityReference("amxperu_productofferingpriceconfiguration", orderitem.PriceConfigurationGuid));

                        etel_orderitemRecord.Attributes.Add("etel_depositamount", new Money(Deposit));
                        etel_orderitemRecord.Attributes.Add("etel_recurringcharge", new Money(RecurringCharge));
                        etel_orderitemRecord.Attributes.Add("etel_onetimecharge", new Money(OneTimeCharge));
                        //etel_orderitemRecord.Attributes.Add("amxperu_checkoutprice", );

                        ContextProvider.OrganizationService.Update(etel_orderitemRecord);
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string ShoppingCartUpdateStatus = "success";
            status.Set(context, ShoppingCartUpdateStatus);
        }
    }
}