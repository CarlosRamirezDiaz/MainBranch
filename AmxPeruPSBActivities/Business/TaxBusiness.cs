using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using AmxPeruCommonLibrary.OptionSets;
using AmxPeruPSBActivities.Model.OrderItem;

namespace AmxPeruPSBActivities.Business
{
    public class TaxBusiness
    {
        XrmDataContextProvider ContextProvider;

        public TaxBusiness()
        {

        }

        public TaxBusiness(XrmDataContextProvider contextProvider)
        {
            ContextProvider = contextProvider;
        }

        private PrivateAddressDataModel QueryAddressRelevantData(Guid addressId)
        {
            var addressQueryExpression = new QueryExpression(etel_customeraddress.EntityLogicalName);
            addressQueryExpression.Criteria.AddCondition("etel_customeraddressid", ConditionOperator.Equal, addressId);

            LinkEntity cityLinkEntity = new LinkEntity(etel_customeraddress.EntityLogicalName, etel_city.EntityLogicalName, "etel_cityid", "etel_cityid", JoinOperator.Inner);
            cityLinkEntity.EntityAlias = "City";
            cityLinkEntity.Columns = new ColumnSet("etel_code");
            addressQueryExpression.LinkEntities.Add(cityLinkEntity);

            LinkEntity districtLinkEntity = new LinkEntity(etel_customeraddress.EntityLogicalName, "amxperu_district", "amxperu_district", "amxperu_districtid", JoinOperator.Inner);
            districtLinkEntity.EntityAlias = "District";
            districtLinkEntity.Columns = new ColumnSet("amxperu_districtcode");
            addressQueryExpression.LinkEntities.Add(districtLinkEntity);

            var addressDetails = ContextProvider.OrganizationService.RetrieveMultiple(addressQueryExpression)?.Entities?.FirstOrDefault();
            var addressDataModel = new PrivateAddressDataModel()
            {
                DistrictCode = addressDetails.GetAttributeValue<AliasedValue>("District.amxperu_districtcode")?.Value?.ToString(),
                CityCode = addressDetails.GetAttributeValue<AliasedValue>("City.etel_code")?.Value?.ToString()
            };

            return addressDataModel;
        }

        private string TaxDecision(PrivateAddressDataModel addressDataModel, int selectedBasicOffering, string popExternalId)
        {
            string allStringValue = "All";
            int allIntValue = 173800000;

            var taxQueryExpression = new QueryExpression("amx_taxexceptionrules");
            taxQueryExpression.ColumnSet = new ColumnSet(new string[] { "amx_taxtype", "amx_unit", "amx_amount" });

            taxQueryExpression.Criteria.AddCondition("amx_customertype", ConditionOperator.Equal, allIntValue);
            taxQueryExpression.Criteria.AddCondition("amx_family", ConditionOperator.Equal, selectedBasicOffering);

            var popFilter = taxQueryExpression.Criteria.AddFilter(LogicalOperator.Or);
            popFilter.AddCondition("amx_productofferingid", ConditionOperator.Equal, popExternalId);
            popFilter.AddCondition("amx_productofferingid", ConditionOperator.Equal, allStringValue);

            var cityFilter = taxQueryExpression.Criteria.AddFilter(LogicalOperator.Or);
            cityFilter.AddCondition("amx_citycode", ConditionOperator.Equal, addressDataModel.CityCode);
            cityFilter.AddCondition("amx_citycode", ConditionOperator.Equal, allStringValue);

            var districtFilter = taxQueryExpression.Criteria.AddFilter(LogicalOperator.Or);
            districtFilter.AddCondition("amx_districtcode", ConditionOperator.Equal, addressDataModel.DistrictCode);
            districtFilter.AddCondition("amx_districtcode", ConditionOperator.Equal, allStringValue);

            var stratumFilter = taxQueryExpression.Criteria.AddFilter(LogicalOperator.Or);
            stratumFilter.AddCondition("amx_stratum", ConditionOperator.Equal, addressDataModel.Stratum);
            stratumFilter.AddCondition("amx_stratum", ConditionOperator.Equal, allIntValue);

            var taxResult = ContextProvider.OrganizationService.RetrieveMultiple(taxQueryExpression)?.Entities?.FirstOrDefault();
            var taxString = String.Empty;

            if (taxResult != null)
            {
                if ((int)amx_family.Telephony == selectedBasicOffering)
                {
                    taxString = "IVA:Percent:19;";
                }
                if (taxResult.Attributes.Contains("amx_unit"))
                {
                    taxString += ((amx_taxtype)((OptionSetValue)taxResult.Attributes["amx_taxtype"]).Value).ToString() + ":" + ((amx_unit)((OptionSetValue)taxResult.Attributes["amx_unit"]).Value).ToString() + ":" + taxResult.Attributes["amx_amount"].ToString();
                }
            }
            else
            {
                taxString = "IVA:Percent:19";
            }

            return taxString;
        }

        public string CalculateTax(OrderItemAddShoppingCartModel orderItemShoppingCartModel)
        {
            var addressDataModel = QueryAddressRelevantData(new Guid(orderItemShoppingCartModel.AddressId));
            addressDataModel.Stratum = int.Parse(orderItemShoppingCartModel.SelectedAddressStratum);
            var selectedBasicOffering = BasicOfferingDict[orderItemShoppingCartModel.BasicOffering];
            return TaxDecision(addressDataModel, selectedBasicOffering, orderItemShoppingCartModel.PopExternalId);
        }

        Dictionary<string, int> BasicOfferingDict = new Dictionary<string, int>()
        {
            { "Internet", 173800000 },
            { "Telephony",  173800001 },
            { "Television", 173800002 },
            { "Mobile", 173800003 },
            { "Telephony2", 173800004 }
        };
    }

    public class PrivateAddressDataModel
    {
        public string DistrictCode { get; set; }
        public string CityCode { get; set; }
        public int Stratum { get; set; }
    }
}
