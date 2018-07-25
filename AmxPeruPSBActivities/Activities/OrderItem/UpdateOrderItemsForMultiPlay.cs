using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Business;
using ExternalApiActivities.Common;
using System;

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class UpdateOrderItemsForMultiPlay : XrmAwareCodeActivity
    {
        public InArgument<string> Estrato { get; set; }
        public InArgument<List<Entity>> OrderItemList { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var estrato = Estrato.Get(context);
            var orderItemListAcceso = OrderItemList.Get(context);

            OfferingsBusiness offeringBusines = new OfferingsBusiness(ContextProvider);
            var infoTableResult = offeringBusines.RetrieveInfoTableRecordsByInfoTableName("PrecioNPlay");

            var accesoOffering = orderItemListAcceso.Where(o => o.GetAttributeValue<AliasedValue>("product.etel_externalid")?.Value?.ToString().ToLower() == "PO_AccesoHFC".ToLower()).FirstOrDefault();
            var permanenciaOffering = orderItemListAcceso.Where(o => o.GetAttributeValue<AliasedValue>("product.etel_externalid")?.Value?.ToString().ToLower() == "po_permanencia12".ToLower()).FirstOrDefault();

            if (accesoOffering != null || permanenciaOffering != null)
            {
                SetAccesoPrice(offeringBusines, accesoOffering, permanenciaOffering);
            }

            var orderItemList = orderItemListAcceso.Where(p => ((OptionSetValue)p.GetAttributeValue<AliasedValue>("product.etel_offertypecode")?.Value)?.Value == (int)AmxPeruCommonLibrary.OptionSets.etel_offertypecode.Optional &&
                                                               ((OptionSetValue)p.GetAttributeValue<AliasedValue>("product.amxperu_offertypecode")?.Value)?.Value == (int)AmxPeruCommonLibrary.OptionSets.amxperu_offertypecode.Plan);

            var tvPO = orderItemList.Where(o => o.GetAttributeValue<AliasedValue>("etel_orderitem.amx_family")?.Value?.ToString() == "Television")
                                    .Select(o => o.GetAttributeValue<AliasedValue>("product.etel_externalid")?.Value?.ToString())
                                    .FirstOrDefault() ?? "x";

            var internetPO = orderItemList.Where(o => o.GetAttributeValue<AliasedValue>("etel_orderitem.amx_family")?.Value?.ToString() == "Internet")
                                    .Select(o => o.GetAttributeValue<AliasedValue>("product.etel_externalid")?.Value?.ToString())
                                    .FirstOrDefault() ?? "x";

            var telephonyPO = orderItemList.Where(o => o.GetAttributeValue<AliasedValue>("etel_orderitem.amx_family")?.Value?.ToString() == "Telephony")
                                    .Select(o => o.GetAttributeValue<AliasedValue>("product.etel_externalid")?.Value?.ToString())
                                    .FirstOrDefault() ?? "x";

            foreach (var item in infoTableResult)
            {
                var columns = item?.GetAttributeValue<AliasedValue>("amxperu_infotablerecord.amxperu_columns")?.Value?.ToString().Split(',');
                var data = item?.GetAttributeValue<AliasedValue>("amxperu_infotablerecord.amxperu_name")?.Value?.ToString().Split(',');

                var estratoValue = data[Array.FindIndex(columns, c => c == "Estrato")];
                var internetPOValue = data[Array.FindIndex(columns, c => c == "po_internet")];
                var internetPriceValue = data[Array.FindIndex(columns, c => c == "precio_internet")];
                var tvValue = data[Array.FindIndex(columns, c => c == "po_tv")];
                var tvPriceValue = data[Array.FindIndex(columns, c => c == "precio_tv")];
                var telephonyValue = data[Array.FindIndex(columns, c => c == "po_telefonia")];
                var telephonyPriceValue = data[Array.FindIndex(columns, c => c == "precio_telefonia")];

                if (estratoValue == estrato && internetPOValue == internetPO && tvValue == tvPO && telephonyValue == telephonyPO)
                {
                    if (internetPOValue != "x")
                    {
                        UpdateOfferingPrice(internetPOValue, internetPriceValue, orderItemList);
                    }
                    if (tvValue != "x")
                    {
                        UpdateOfferingPrice(tvValue, tvPriceValue, orderItemList);
                    }
                    if (telephonyValue != "x")
                    {
                        UpdateOfferingPrice(telephonyValue, telephonyPriceValue, orderItemList);
                    }

                    return;
                }
            }
        }

        public void SetAccesoPrice(OfferingsBusiness offeringBusines, Entity accesoOffering, Entity permanenciaOffering)
        {
            var entity = new Entity(etel_orderitem.EntityLogicalName);
            entity.Id = (Guid)accesoOffering.GetAttributeValue<AliasedValue>("etel_orderitem.etel_orderitemid")?.Value;

            var infoTableResult = offeringBusines.RetrieveInfoTableRecordsByInfoTableName("PrecioBaseOfertasCompartidas");

            if (permanenciaOffering == null)
            {
                foreach (var item in infoTableResult)
                {
                    var columns = item?.GetAttributeValue<AliasedValue>("amxperu_infotablerecord.amxperu_columns")?.Value?.ToString().Split(',');
                    var data = item?.GetAttributeValue<AliasedValue>("amxperu_infotablerecord.amxperu_name")?.Value?.ToString().Split(',');

                    var permanencia = Array.FindIndex(data, c => c == "PO_Permanencia12");

                    if (permanencia == -1)
                    {
                        entity.Attributes["etel_onetimecharge"] = new Money(Convert.ToDecimal(data[Array.FindIndex(columns, c => c == "Valor")]));
                    }
                }
            }
            else
            {
                var permanenciaPrice = new Money();
                var accesoPrice = new Money();

                foreach (var item in infoTableResult)
                {
                    var columns = item?.GetAttributeValue<AliasedValue>("amxperu_infotablerecord.amxperu_columns")?.Value?.ToString().Split(',');
                    var data = item?.GetAttributeValue<AliasedValue>("amxperu_infotablerecord.amxperu_name")?.Value?.ToString().Split(',');

                    var permanencia = Array.FindIndex(data, c => c == "PO_Permanencia12");

                    if (permanencia == -1)
                    {
                        permanenciaPrice.Value = Convert.ToDecimal(data[Array.FindIndex(columns, c => c == "Valor")]);
                    }
                    else
                    {
                        accesoPrice.Value = Convert.ToDecimal(data[Array.FindIndex(columns, c => c == "Valor")]);
                    }
                }

                entity.Attributes["etel_onetimecharge"] = permanenciaPrice;
                entity.Attributes["etel_extendedonetimecharge"] = accesoPrice;
            }

            ContextProvider.OrganizationService.Update(entity);
        }

        public void UpdateOfferingPrice(string externalId, string price, IEnumerable<Entity> orderItemList)
        {
            var orderItem = orderItemList.Where(o => o.GetAttributeValue<AliasedValue>("product.etel_externalid")?.Value?.ToString() == externalId).FirstOrDefault();
            var orderItemId = (Guid)orderItem.GetAttributeValue<AliasedValue>("etel_orderitem.etel_orderitemid")?.Value;

            var entity = new Entity(etel_orderitem.EntityLogicalName);
            entity.Id = orderItemId;
            entity.Attributes["etel_recurringcharge"] = new Money(Convert.ToDecimal(price));
            entity.Attributes["etel_extendedrecurringcharge"] = orderItem.GetAttributeValue<AliasedValue>("etel_orderitem.etel_recurringcharge")?.Value;
            ContextProvider.OrganizationService.Update(entity);
        }
    }
}
