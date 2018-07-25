using ExternalApiActivities.Common;
using System;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using AmxPeruCommonLibrary;
using Ericsson.PSB.Workflow.Client.Core;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using AmxPeruPSBActivities.Common;
using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model.OrderCaptureSubmit;

namespace AmxPeruPSBActivities.Activities.LinePortability
{
    public class ReservePhoneNumberActivity : XrmAwareCodeActivity
    {
        public InArgument<string> AddressId { get; set; }
        public InArgument<string> CustomerId { get; set; }
        public InArgument<string> EndPoint { get; set; }
        public InArgument<string> NumberToBeReleased { get; set; }
        public InArgument<string> NumberToBeReserved { get; set; }
        public InArgument<string> OrderItemId { get; set; }
        public OutArgument<List<string>> NumberList { get; set; }
        public OutArgument<string> Result { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var addressId = AddressId.Get(context);
            var contactId = CustomerId.Get(context);
            var endPoint = EndPoint.Get(context);
            var numberToBeReleased = NumberToBeReleased.Get(context);
            var numberToBeReserved = NumberToBeReserved.Get(context);
            var orderItemId = OrderItemId.Get(context);
            var identityExtension = context.GetExtension<UserIdentityExtension>();

            QueryExpression contactEntity = new QueryExpression();
            contactEntity.EntityName = "contact";
            contactEntity.ColumnSet = new ColumnSet("fullname", "etel_iddocumentnumber", "amxperu_documenttype");
            contactEntity.Criteria.Conditions.Add(new ConditionExpression("contactid", ConditionOperator.Equal, contactId));
            contactEntity.Criteria = new FilterExpression { Conditions = { new ConditionExpression("contactid", ConditionOperator.Equal, contactId) } };

            LinkEntity addressEntity = new LinkEntity(Contact.EntityLogicalName, etel_customeraddress.EntityLogicalName, "contactid", "etel_individualcustomerid", JoinOperator.Inner);
            addressEntity.EntityAlias = "address";
            addressEntity.Columns = new ColumnSet("etel_name", "etel_postalcode");
            addressEntity.LinkCriteria.AddCondition("etel_customeraddressid", ConditionOperator.Equal, addressId);
            contactEntity.LinkEntities.Add(addressEntity);

            LinkEntity cityAreaEntity = new LinkEntity(etel_customeraddress.EntityLogicalName, "amx_cityarea", "amx_cityarea", "amx_cityareaid", JoinOperator.Inner);
            cityAreaEntity.EntityAlias = "cityarea";
            cityAreaEntity.Columns = new ColumnSet("amx_cityareacode");
            addressEntity.LinkEntities.Add(cityAreaEntity);

            var result = ContextProvider.OrganizationService.RetrieveMultiple(contactEntity)?.Entities?.FirstOrDefault();
            var customerName = (result?.Contains("fullname")).HasValue ? result?.Attributes["fullname"]?.ToString() : string.Empty;
            var idNumber = (result?.Contains("etel_iddocumentnumber")).HasValue ? result?.Attributes["etel_iddocumentnumber"].ToString() : string.Empty;
            var idType = (result?.Contains("amxperu_documenttype")).HasValue ? OptionSet.RetrieveDocumentTypeByValue(((OptionSetValue)result?.Attributes["amxperu_documenttype"]).Value) : string.Empty;
            var address = result?.GetAttributeValue<AliasedValue>("address.etel_name")?.Value?.ToString();
            var zipCode = result?.GetAttributeValue<AliasedValue>("address.etel_postalcode")?.Value?.ToString();
            var cityArea = result?.GetAttributeValue<AliasedValue>("cityarea.amx_cityareacode")?.Value?.ToString();

            using (var factory = new AmxPeruGenericProxy<NM_ptt>(endPoint, identityExtension.GetIdentity().Name))
            {
                var requestId = Guid.NewGuid().ToString();
                var header = new HeaderRequest()
                {
                    transactionId = "10001",
                    system = "sistema",
                    user = "user1",
                    password = "pwd1234",
                    requestDate = DateTime.Now,
                    ipApplication = "100",
                    traceabilityId = "100"
                };

                try
                {
                    var releaseNumberRequest = new updateNumbersRequest(new updateNumbers_TYPE()
                    {
                        headerRequest = header,
                        crm_in_use = "TCRM",
                        country_code = "57 ",
                        area_code = "1", //cityArea, -- db value causes no number issue, needs to be clarified. 
                        request_id = requestId,
                        transaction_id = requestId,
                        city_code = zipCode,
                        status = "Available",
                        list_of_numbers = new NumberElement3[] { new NumberElement3 { number = numberToBeReleased.Substring(3) } }
                    });

                    var resultReleaseNumber = factory.Channel.updateNumbers(releaseNumberRequest);
                    if (resultReleaseNumber?.updateNumbersResp?.code == "300")
                    {
                        requestId = Guid.NewGuid().ToString();
                        var reserveNumberRequest = new reserveNumbersRequest(new reserveNumbers_TYPE()
                        {
                            headerRequest = header,
                            crm_in_use = "TCRM",
                            country_code = "57 ",
                            account_id = "1234",
                            area_code = "1", //cityArea, -- db value causes no number issue, needs to be clarified. 
                            request_id = requestId,
                            transaction_id = requestId,
                            customer_name = customerName,
                            customer_id = idNumber,
                            customer_id_type = idType,
                            customer_location = address,
                            list_of_numbers = new NumberElement2[] { new NumberElement2 { number = numberToBeReserved.Substring(3) } }

                        });

                        var resultReserveNumber = factory.Channel.reserveNumbers(reserveNumberRequest);
                        if (resultReserveNumber?.reserveNumbersResp?.code == "300")
                        {
                            OrderResourceBusiness orderResourceBusiness = new OrderResourceBusiness(ContextProvider);

                            var orderResourceList = orderResourceBusiness.RetrieveOrderResourceCharacteristicsByOrderItemId(new Guid(orderItemId))?
                                                      .GroupBy(x => x.GetAttributeValue<AliasedValue>("etel_orderresource.etel_orderresourceid")?.Value, (key, value) => new { orderResourceId = key, Entities = value.ToList() });

                            foreach (var orderResource in orderResourceList)
                            {
                                var orderResourceCharId = orderResource.Entities.Where(r => r?.GetAttributeValue<AliasedValue>("amxperu_resourcecharacteristic.amxperu_externalid")?.Value?.ToString() == "resourceNumber")
                                                                              .Select(r => (Guid)r?.GetAttributeValue<AliasedValue>("etel_orderresourcecharacteric.etel_orderresourcecharactericid")?.Value)
                                                                              .FirstOrDefault();

                                var orderResourceChar = new etel_orderresourcecharacteric();
                                orderResourceChar.Id = orderResourceCharId;
                                orderResourceChar.etel_value = numberToBeReserved;

                                ContextProvider.OrganizationService.Update(orderResourceChar);

                            }

                            Result.Set(context, "OK");

                        }
                    }
                }
                catch (FaultException faultException)
                {
                    throw faultException;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            };
        }
    }
}
