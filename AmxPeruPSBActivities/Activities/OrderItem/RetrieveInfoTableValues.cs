using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using System.Text.RegularExpressions;
using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk.Query;

namespace AmxPeruPSBActivities.Activities.OrderItem
{
    public class RetrieveInfoTableValues : XrmAwareCodeActivity
    {
        public InArgument<string> Estrato { get; set; }
        public InArgument<List<Entity>> OrderItemList { get; set; }
        public OutArgument<Tv> Tv { get; set; }
        public OutArgument<Internet> Internet { get; set; }
        public OutArgument<Telephony> Telephony { get; set; }
        public OutArgument<List<Entity>> InfoTableValues { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var tv = new Tv();
            var internet = new Internet();
            var telephony = new Telephony();
            var estratoValue = Estrato.Get(context);
            var orderItemListAcceso = OrderItemList.Get(context);

            var accesoOffering = orderItemListAcceso.Where(o => o.GetAttributeValue<AliasedValue>("product.etel_externalid")?.Value?.ToString() == "PO_AccesoHFC").FirstOrDefault();
            var permanenciaOffering = orderItemListAcceso.Where(o => o.GetAttributeValue<AliasedValue>("product.etel_externalid")?.Value?.ToString() == "PO_Permanencia12").FirstOrDefault();

            if (accesoOffering != null || permanenciaOffering != null)
            {
                SetAccesoPrice(accesoOffering, permanenciaOffering);
            }

            var orderItemList = orderItemListAcceso.Where(p => ((OptionSetValue)p.GetAttributeValue<AliasedValue>("product.etel_offertypecode")?.Value)?.Value == (int)AmxPeruCommonLibrary.OptionSets.etel_offertypecode.Optional &&
                                                               ((OptionSetValue)p.GetAttributeValue<AliasedValue>("product.amxperu_offertypecode")?.Value)?.Value == (int)AmxPeruCommonLibrary.OptionSets.amxperu_offertypecode.Plan)
                                                   .ToList();

            foreach (var orderItem in orderItemList)
            {
                if (Regex.IsMatch(orderItem.GetAttributeValue<AliasedValue>("product.etel_externalid")?.Value?.ToString(), "TV", RegexOptions.IgnoreCase))
                {
                    tv.OrderItemId = (Guid)orderItem.GetAttributeValue<AliasedValue>("etel_orderitem.etel_orderitemid")?.Value;
                    tv.ExternalId = orderItem.GetAttributeValue<AliasedValue>("product.etel_externalid")?.Value?.ToString();
                    tv.RecurringAmount = ((Money)orderItem.GetAttributeValue<AliasedValue>("etel_orderitem.etel_recurringcharge")?.Value)?.Value;
                }
                else if (Regex.IsMatch(orderItem.GetAttributeValue<AliasedValue>("product.etel_externalid")?.Value?.ToString(), "PO_Int", RegexOptions.IgnoreCase))
                {
                    internet.OrderItemId = (Guid)orderItem.GetAttributeValue<AliasedValue>("etel_orderitem.etel_orderitemid")?.Value;
                    internet.ExternalId = orderItem.GetAttributeValue<AliasedValue>("product.etel_externalid")?.Value?.ToString();
                    internet.RecurringAmount = ((Money)orderItem.GetAttributeValue<AliasedValue>("etel_orderitem.etel_recurringcharge")?.Value)?.Value;
                }
                else if (Regex.IsMatch(orderItem.GetAttributeValue<AliasedValue>("product.etel_externalid")?.Value?.ToString(), "Tel", RegexOptions.IgnoreCase))
                {
                    telephony.OrderItemId = (Guid)orderItem.GetAttributeValue<AliasedValue>("etel_orderitem.etel_orderitemid")?.Value;
                    telephony.ExternalId = orderItem.GetAttributeValue<AliasedValue>("product.etel_externalid")?.Value?.ToString();
                    telephony.RecurringAmount = ((Money)orderItem.GetAttributeValue<AliasedValue>("etel_orderitem.etel_recurringcharge")?.Value)?.Value;
                }
            }

            var infoTableValues = GetMultiPlayProduct(tv.ExternalId, internet.ExternalId, telephony.ExternalId, estratoValue);

            Tv.Set(context, tv);
            Internet.Set(context, internet);
            Telephony.Set(context, telephony);
            InfoTableValues.Set(context, infoTableValues);
        }

        public void SetAccesoPrice(Entity accesoOffering, Entity permanenciaOffering)
        {
            var accesoPopConfig = "accesoHFC_POPConfig";
            var permanenciaPopConfig = "accesoHFC_POPPermanenciaConfig";

            QueryExpression popConfigEntity = new QueryExpression();
            popConfigEntity.EntityName = "amxperu_productofferingpriceconfiguration";
            popConfigEntity.ColumnSet = new ColumnSet("amxperu_name", "amxperu_productoffering");
            popConfigEntity.Criteria = new FilterExpression
            {
                Conditions = { new ConditionExpression("amxperu_name", ConditionOperator.In, new List<string>() { accesoPopConfig, permanenciaPopConfig }) }
            };

            LinkEntity popEntity = new LinkEntity("amxperu_productofferingpriceconfiguration", "amxperu_productofferingprice", "amxperu_productofferingpriceconfigurationid", "amxperu_popconfiguration", JoinOperator.Inner);
            popEntity.Columns = new ColumnSet("amxperu_price", "amxperu_pricetypecode", "amxperu_periodcode", "amxperu_externalid");
            popEntity.EntityAlias = "pop";
            popConfigEntity.LinkEntities.Add(popEntity);

            var popList = ContextProvider.OrganizationService.RetrieveMultiple(popConfigEntity)?.Entities?.ToList();

            var accesoPop = popList.Where(p => p.Attributes["amxperu_name"]?.ToString() == accesoPopConfig).FirstOrDefault();
            var permanenciaPop = popList.Where(p => p.Attributes["amxperu_name"]?.ToString() == permanenciaPopConfig).FirstOrDefault();

            var entity = new Entity(etel_orderitem.EntityLogicalName);
            entity.Id = (Guid)accesoOffering.GetAttributeValue<AliasedValue>("etel_orderitem.etel_orderitemid")?.Value;
            if (permanenciaOffering == null)
                entity.Attributes["etel_onetimecharge"] = (Money)(accesoPop.GetAttributeValue<AliasedValue>("pop.amxperu_price")?.Value);
            else
            {
                entity.Attributes["etel_onetimecharge"] = (Money)(permanenciaPop.GetAttributeValue<AliasedValue>("pop.amxperu_price")?.Value);
                entity.Attributes["etel_extendedonetimecharge"] = (Money)(accesoPop.GetAttributeValue<AliasedValue>("pop.amxperu_price")?.Value);
            }
            ContextProvider.OrganizationService.Update(entity);
        }

        public List<Entity> GetMultiPlayProduct(string tvExternalId, string internetExternalId, string telephonyExternalId, string estratoValue)
        {
            var tv = GetInfoTableValues("PO TV", tvExternalId)?.Select(p => (Guid)p.GetAttributeValue<AliasedValue>("amxperu_infotablerecord.amxperu_infotablerecordid")?.Value)?.ToList();
            var internet = GetInfoTableValues("PO Internet", internetExternalId)?.Select(p => (Guid)p.GetAttributeValue<AliasedValue>("amxperu_infotablerecord.amxperu_infotablerecordid")?.Value)?.ToList();
            var telephony = GetInfoTableValues("PO Telefonia", telephonyExternalId)?.Select(p => (Guid)p.GetAttributeValue<AliasedValue>("amxperu_infotablerecord.amxperu_infotablerecordid")?.Value)?.ToList();
            var estrato = GetInfoTableValues("Estrato", estratoValue)?.Select(p => (Guid)p.GetAttributeValue<AliasedValue>("amxperu_infotablerecord.amxperu_infotablerecordid")?.Value)?.ToList();

            var infoTableId = internet.Intersect(tv)
                                      .Intersect(telephony)
                                      .Intersect(estrato)
                                      .FirstOrDefault();

            return GetInfoTableValues(infoTableId: infoTableId);
        }

        public List<Entity> GetInfoTableValues(string attribute = null, string externalId = null, Guid? infoTableId = null)
        {
            QueryExpression valueEntity = new QueryExpression();
            valueEntity.EntityName = "amxperu_infotablevalue";
            valueEntity.ColumnSet = new ColumnSet("amxperu_infomodelattribute", "amxperu_name");
            if (infoTableId == null)
            {
                valueEntity.Criteria.AddCondition("amxperu_infomodelattributename", ConditionOperator.Equal, attribute);

                if (string.IsNullOrEmpty(externalId))
                    valueEntity.Criteria.AddCondition("amxperu_name", ConditionOperator.Null);
                else
                    valueEntity.Criteria.AddCondition("amxperu_name", ConditionOperator.Equal, externalId);
            }

            LinkEntity valueRecordEntity = new LinkEntity("amxperu_infotablevalue", "amxperu_infotablevalue_infotablerecord", "amxperu_infotablevalueid", "amxperu_infotablevalueid", JoinOperator.Inner);
            valueRecordEntity.EntityAlias = "amxperu_infotablevalue_infotablerecord";
            valueEntity.LinkEntities.Add(valueRecordEntity);

            LinkEntity recordEntity = new LinkEntity("amxperu_infotablevalue_infotablerecord", "amxperu_infotablerecord", "amxperu_infotablerecordid", "amxperu_infotablerecordid", JoinOperator.Inner);
            recordEntity.EntityAlias = "amxperu_infotablerecord";
            recordEntity.Columns = new ColumnSet("amxperu_infotablerecordid");
            if (infoTableId != null)
                recordEntity.LinkCriteria.AddCondition(new ConditionExpression("amxperu_infotablerecordid", ConditionOperator.Equal, infoTableId.Value));
            valueRecordEntity.LinkEntities.Add(recordEntity);

            var infoTableValues = ContextProvider.OrganizationService
                                           .RetrieveMultiple(valueEntity)?
                                           .Entities?
                                           .ToList();

            return infoTableValues;
        }
    }
}
