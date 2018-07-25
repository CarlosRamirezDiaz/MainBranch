using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Ericsson.ETELCRM.Entities.Crm;
using System.Activities;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using AmxPeruPSBActivities.Model.OrderCapture;
using AmxPeruCommonLibrary.OptionSets;
using AmxPeruPSBActivities.Business;

namespace AmxPeruPSBActivities.Activities.Offering
{
    public class RetrieveOptionalOfferingsFromInfoTable : XrmAwareCodeActivity
    {
        public InArgument<string> Estrato { get; set; }
        public InArgument<Entity> ParentOffering { get; set; }
        public InArgument<List<Entity>> OfferingEntityList { get; set; }
        public OutArgument<List<ProductOfferingItem>> OptionalOfferingList { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var estrato = Estrato.Get(context);
            var parentOfferingId = ParentOffering.Get(context)?.Attributes["productid"]?.ToString();
            var parentOfferingExternalId = ParentOffering.Get(context).Attributes["etel_externalid"]?.ToString();
            var offeringEntityList = OfferingEntityList.Get(context);

            var infoTableName = GetInfoTableName(parentOfferingExternalId);
            var productOfferingExternalIdList = offeringEntityList.Select(o => o.GetAttributeValue<AliasedValue>("product.etel_externalid")?.Value?.ToString()?.ToLower()).ToList();
            var optionalOfferingList = MapOptionalPOs(offeringEntityList);

            OfferingsBusiness offeringBusines = new OfferingsBusiness(ContextProvider);
            var infoTableResult = offeringBusines.RetrieveInfoTableRecordsByInfoTableName(infoTableName);

            foreach (var item in infoTableResult)
            {
                var columns = item?.GetAttributeValue<AliasedValue>("amxperu_infotablerecord.amxperu_columns")?.Value?.ToString().Split(',');
                var data = item?.GetAttributeValue<AliasedValue>("amxperu_infotablerecord.amxperu_name")?.Value?.ToString().Split(',');

                var estratoValue = data[Array.FindIndex(columns, c => c == "Estrato")];
                var productIdValue = data[Array.FindIndex(columns, c => c == "PO_ID")];
                var technologyValue = data[Array.FindIndex(columns, c => c == "Tecnologia")];
                var amountValue = data[Array.FindIndex(columns, c => c == "Valor")];
                var popExternalIdValue = data[Array.FindIndex(columns, c => c == "EcmPoPID")];
                var priceTypeValue = data[Array.FindIndex(columns, c => c == "EcmChargeFrequency")];
                var currencyValue = data[Array.FindIndex(columns, c => c == "EcmCurrency")];

                if ((estratoValue == estrato || estratoValue.ToLower() == "Todos".ToLower() || string.IsNullOrWhiteSpace(estratoValue)) && productOfferingExternalIdList.Contains(productIdValue.ToLower()))
                {
                    var productOffering = optionalOfferingList.Where(p => p.ExternalId == productIdValue).FirstOrDefault();

                    productOffering.Currency = currencyValue;
                    productOffering.Technology = technologyValue;
                    productOffering.ParentOfferingGuid = parentOfferingId;

                    MapPrices(Convert.ToDecimal(amountValue), priceTypeValue, popExternalIdValue, productOffering);
                }
            }

            OptionalOfferingList.Set(context, optionalOfferingList);
        }

        private List<ProductOfferingItem> MapOptionalPOs(List<Entity> offeringEntityList)
        {
            var optionalOfferingList = new List<ProductOfferingItem>();
            ProductOfferingItem offeringModel;

            foreach (var productOffering in offeringEntityList)
            {
                offeringModel = new ProductOfferingItem();

                var offeringType = ((OptionSetValue)productOffering.GetAttributeValue<AliasedValue>("product.etel_offertypecode")?.Value)?.Value;
                var subOfferingType = ((OptionSetValue)productOffering.GetAttributeValue<AliasedValue>("product.amxperu_offertypecode")?.Value)?.Value;

                offeringModel.OfferingId = productOffering.GetAttributeValue<AliasedValue>("product.productid")?.Value?.ToString();
                offeringModel.OfferingName = productOffering.GetAttributeValue<AliasedValue>("product.name")?.Value?.ToString();
                offeringModel.ParentOfferingGuid = productOffering.GetAttributeValue<AliasedValue>("product.etel_parentofferingid")?.Value?.ToString();
                offeringModel.ExternalId = productOffering.GetAttributeValue<AliasedValue>("product.etel_externalid")?.Value?.ToString();
                //offeringModel.Currency = currencyValue;
                offeringModel.OfferingTypeCode = offeringType?.ToString();
                offeringModel.OfferingTypeText = offeringType != null ? ((AmxPeruCommonLibrary.OptionSets.etel_offertypecode)offeringType).ToString() : "";
                offeringModel.SubOfferingTypeCode = subOfferingType?.ToString();
                offeringModel.SubOfferingTypeText = subOfferingType != null ? ((amxperu_offertypecode)subOfferingType).ToString() : "";
                offeringModel.IsBasicPO = false;
                offeringModel.IsSelleable = true;
                //offeringModel.Technology = technologyValue;
                //offeringModel.ParentOfferingGuid = parentOfferingId;

                optionalOfferingList.Add(offeringModel);
            }

            return optionalOfferingList;
        }

        private void MapPrices(decimal? price, string priceType, string popExternalId, ProductOfferingItem offering)
        {
            switch (priceType)
            {
                case "O":
                    var oneTime = new OneTime();
                    oneTime.Amount = price;
                    oneTime.PopExternalId = popExternalId;
                    if (offering.OneTime == null)
                        offering.OneTime = new List<OneTime>();
                    offering.OneTime.Add(oneTime);
                    break;

                case "M":
                case "D":
                    var recurring = new Recurring();
                    recurring.Amount = price;
                    recurring.Period = priceType == "M" ? "Monthly" : "Daily";
                    recurring.PopExternalId = popExternalId;
                    if (offering.Recurring == null)
                        offering.Recurring = new List<Recurring>();
                    offering.Recurring.Add(recurring);
                    break;
                default:
                    break;
            }
        }

        private string GetInfoTableName(string externalId)
        {
            var dictionary = new Dictionary<string, string>()
            {
                {"PO_IntDatPosServInternet", "PrecioBaseInternet" },
                {"PO_TvPosServicioTV_Cv", "PrecioBaseTV" },
                {"PO_TelPosBasic", "PrecioBaseTelefonia" },
                {"PO_TelPosSegundaLinea", "PrecioBaseTelefoniaExt" },
                {"PO_MovPreBasico", "PrecioBaseMovilPre" }
            };

            return dictionary.Where(d => d.Key == externalId).Select(d => d.Value).FirstOrDefault();
        }
    }
}
