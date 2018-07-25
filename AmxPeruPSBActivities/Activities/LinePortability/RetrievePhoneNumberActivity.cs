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
using AmxPeruPSBActivities.Model.OrderResource;

namespace AmxPeruPSBActivities.Activities.LinePortability
{
    public class RetrievePhoneNumberActivity : XrmAwareCodeActivity
    {
        public InArgument<string> AddressId { get; set; }
        public InArgument<string> CustomerId { get; set; }
        public InArgument<string> EndPoint { get; set; }
        public InArgument<string> OrderItemId { get; set; }
        public OutArgument<List<string>> NumberList { get; set; }
        public OutArgument<string> Result { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var addressId = AddressId.Get(context);
            var contactId = CustomerId.Get(context);
            var endPoint = EndPoint.Get(context);
            var orderItemId = OrderItemId.Get(context);
            var identityExtension = context.GetExtension<UserIdentityExtension>();
            var numberList = new List<string>();

            QueryExpression contactEntity = new QueryExpression();
            contactEntity.EntityName = "contact";
            contactEntity.ColumnSet = new ColumnSet("fullname", "etel_iddocumentnumber", "amxperu_documenttype");
            contactEntity.Criteria.Conditions.Add(new ConditionExpression("contactid", ConditionOperator.Equal, contactId));

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
                OrderResourceBusiness orderResourceBusiness = new OrderResourceBusiness(ContextProvider);

                var existingResource = orderResourceBusiness.RetrieveOrderResourceCharacteristicsByOrderItemId(new Guid(orderItemId), "LRS_TelPosBasic");

                var quantity = existingResource?.Count > 0 ? "2" : "3";

                if (existingResource?.Count > 0)
                {
                    var existingNumber = existingResource.Where(r => r.GetAttributeValue<AliasedValue>("amxperu_resourcecharacteristic.amxperu_externalid")?.Value?.ToString() == "resourceNumber")
                                                         .Select(r => r.GetAttributeValue<AliasedValue>("etel_orderresourcecharacteric.etel_value")?.Value?.ToString())
                                                         .FirstOrDefault();

                    numberList.Add(existingNumber);
                }

                var getNumberResponse = new getNumbersResp_TYPE();

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

                var getNumberRequest = new getNumbersRequest(new getNumbers_TYPE()
                {
                    headerRequest = header,
                    crm_in_use = "TCRM",
                    country_code = "57",
                    segment_in_use = "Hogares",
                    segment_code_in_use = "S62",
                    category = "Normal",
                    service_in_use = "Normal",
                    service_id = "123",
                    consecutive_number = false,
                    quantity_numbers = quantity,
                    supplementary_services = new string[] { "SERV1", "SERV2" },
                    status = "Available",
                    metropolitan_area = "1",
                    request_id = requestId,
                    transaction_id = requestId,
                    area_code = "1", //cityArea, -- db value causes no number issue, needs to be clarified. 
                    city_code = zipCode,
                });

                try
                {
                    var resultGetNumber = factory.Channel.getNumbers(getNumberRequest);
                    numberList.AddRange(resultGetNumber?.getNumbersResp?.list_of_numbers?.Select(n => n.number).ToList());
                    NumberList.Set(context, numberList);
                    Result.Set(context, "OK");

                    if (existingResource?.Count > 0)
                    {
                        return;
                    }

                    requestId = Guid.NewGuid().ToString();
                    if (numberList?.Count > 0)
                    {
                        NumberList.Set(context, numberList);

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
                            list_of_numbers = new NumberElement2[] { new NumberElement2 { number = numberList[0].Substring(3) } }
                        });

                        var resultReserveNumber = factory.Channel.reserveNumbers(reserveNumberRequest);
                        if (resultReserveNumber?.reserveNumbersResp?.code == "300")
                        {
                            var prodResSpecQuery = orderResourceBusiness.RetrievePRSQueryObject("LRS_TelPosBasic");
                            var orderItem = (etel_orderitem)ContextProvider.OrganizationService.Retrieve(etel_orderitem.EntityLogicalName, new Guid(orderItemId), new ColumnSet(true));
                            var prodResSpec = (etel_productresourcespecification)ContextProvider.OrganizationService.RetrieveMultiple(prodResSpecQuery)?.Entities?.FirstOrDefault();

                            var resourceCharModel = new ResourceCharacteristicsModel();
                            resourceCharModel.TelephoneNumber = numberList[0];
                            resourceCharModel.Sdp_Id = "5";
                            resourceCharModel.Ssw_Id = resultGetNumber?.getNumbersResp?.list_of_numbers?.Select(n => n.core_network_element).ToList()[0];

                            var orderResourceId = orderResourceBusiness.CreateOrderResource(orderItem, prodResSpec);
                            var resourceCharValueList = orderResourceBusiness.RetrieveResourceCharacteristics("LRS_TelPosBasic");
                            orderResourceBusiness.CreateOrderResourceCharacteristics(orderResourceId, resourceCharValueList, resourceCharModel);

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
