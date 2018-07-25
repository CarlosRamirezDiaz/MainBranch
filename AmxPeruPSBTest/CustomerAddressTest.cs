using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Model.AffiliateDisaffiliate;
using AmxPeruPSBActivities.Model.Case;
using AmxPeruPSBActivities.Model.Task;
using ExternalApiActivities.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class CustomerAddressTest
    {
        [TestMethod]
        public void CreateAddress()
        {
            var input = new Dictionary<string, object>()
            {
                { "input", "{\"ProductOfferingList\":[{\"ExternalId\":\"claroMax189\",\"Name\":\"Claro Max 189\",\"ProductSpecification\":{\"ExternalId\":\"psMobPostConexionMax\",\"Name\":\"psMobPostConexionMax\",\"CFSSList\":[{\"ExternalId\":\"cfssBasicMobPostMassiveCurrentZM\",\"Name\":\"cfssBasicMobPostMassiveCurrentZM\",\"CharacteristicList\":[{\"ExternalId\":\"CHARGING_ENGINE\",\"Name\":\"Charging Engine\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"CS\",\"CharacteristicValueList\":[{\"ExternalId\":\"CHARGING_ENGINE\",\"Value\":\"CS\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"MARKET\",\"Name\":\"Market public key\",\"Editable\":true,\"DataType\":\"Combobox\",\"DefaultValue\":\"GSM\",\"CharacteristicValueList\":[{\"ExternalId\":\"MARKET\",\"Value\":\"GSM\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"MSISDNNP\",\"Name\":\"Numbering plan public key\",\"Editable\":true,\"DataType\":\"Combobox\",\"DefaultValue\":\"E.164\",\"CharacteristicValueList\":[{\"ExternalId\":\"MSISDNNP\",\"Value\":\"E.164\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"specificationSubtype\",\"Name\":\"Customer Facing Service Type\",\"Editable\":false,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"specificationSubtype\",\"IsDefaultValue\":true}]}]},{\"ExternalId\":\"cfssMobNetworkProvisioning\",\"Name\":\"cfssMobNetworkProvisioning\",\"CharacteristicList\":[{\"ExternalId\":\"APN_VALUE\",\"Name\":\"APN Value\",\"Editable\":true,\"DataType\":\"Combobox\",\"DefaultValue\":\"10.20.30.40\",\"CharacteristicValueList\":[{\"ExternalId\":\"APN_VALUE\",\"Value\":\"10.20.30.40\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"specificationSubtype\",\"Name\":\"Customer Facing Service Type\",\"Editable\":false,\"DataType\":\"Combobox\",\"DefaultValue\":\"NetworkProvisioning\",\"CharacteristicValueList\":[{\"ExternalId\":\"specificationSubtype\",\"Value\":\"NetworkProvisioning\",\"IsDefaultValue\":true}]}]},{\"ExternalId\":\"cfssMobPostRpcUnlimitedInc\",\"Name\":\"cfssMobPostRpcUnlimitedInc\",\"CharacteristicList\":[{\"ExternalId\":\"CHARGING_ENGINE\",\"Name\":\"Charging Engine\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"CS\",\"CharacteristicValueList\":[{\"ExternalId\":\"CHARGING_ENGINE\",\"Value\":\"CS\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"specificationSubtype\",\"Name\":\"Customer Facing Service Type\",\"Editable\":false,\"DataType\":\"Combobox\",\"DefaultValue\":\"Voice\",\"CharacteristicValueList\":[{\"ExternalId\":\"specificationSubtype\",\"Value\":\"Voice\",\"IsDefaultValue\":true}]}]},{\"ExternalId\":\"cfssMobPostVSDInc_Max\",\"Name\":\"cfssMobPostVSDInc_Max\",\"CharacteristicList\":[{\"ExternalId\":\"CHARGING_ENGINE\",\"Name\":\"Charging Engine\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"ANY\",\"CharacteristicValueList\":[{\"ExternalId\":\"CHARGING_ENGINE\",\"Value\":\"ANY\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"PamIndicatorReactivation\",\"Name\":\"PamIndicatorReactivation\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"2\",\"CharacteristicValueList\":[{\"ExternalId\":\"PamIndicatorReactivation\",\"Value\":\"2\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"PamIndicatorSuspension\",\"Name\":\"PamIndicatorSuspension\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"1\",\"CharacteristicValueList\":[{\"ExternalId\":\"PamIndicatorSuspension\",\"Value\":\"1\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"specificationSubtype\",\"Name\":\"Customer Facing Service Type\",\"Editable\":false,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"specificationSubtype\",\"IsDefaultValue\":true}]}]},{\"ExternalId\":\"cfssMobPost_NotInc_Max\",\"Name\":\"cfssMobPost_NotInc_Max\",\"CharacteristicList\":[{\"ExternalId\":\"CHARGING_ENGINE\",\"Name\":\"Charging Engine\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"CS\",\"CharacteristicValueList\":[{\"ExternalId\":\"CHARGING_ENGINE\",\"Value\":\"CS\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"Community1\",\"Name\":\"community1\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"Community1\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"Community2\",\"Name\":\"community2\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"Community2\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"Community3\",\"Name\":\"community3\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"Community3\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"community1\",\"Name\":\"Community1\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"community1\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"community2\",\"Name\":\"Community2\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"community2\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"community3\",\"Name\":\"Community3\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"community3\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"pamIndicatorCreditLimit\",\"Name\":\"pamIndicatorCreditLimit\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"3\",\"CharacteristicValueList\":[{\"ExternalId\":\"pamIndicatorCreditLimit\",\"Value\":\"3\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"shortCode\",\"Name\":\"shortCode\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"shortCode\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"specificationSubtype\",\"Name\":\"Customer Facing Service Type\",\"Editable\":false,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"specificationSubtype\",\"IsDefaultValue\":true}]}]},{\"ExternalId\":\"cfssMobPost_Prepaid_Max\",\"Name\":\"cfssMobPost_Prepaid_Max\",\"CharacteristicList\":[{\"ExternalId\":\"CHARGING_ENGINE\",\"Name\":\"Charging Engine\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"CS\",\"CharacteristicValueList\":[{\"ExternalId\":\"CHARGING_ENGINE\",\"Value\":\"CS\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"specificationSubtype\",\"Name\":\"Customer Facing Service Type\",\"Editable\":false,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"specificationSubtype\",\"IsDefaultValue\":true}]}]}],\"ResourceSpecificationList\":[{\"ExternalId\":\"lrs_MSISDN\",\"Name\":\"lrs_MSISDN\",\"ResourceCharacteristicList\":[{\"ExternalId\":\"SDP_ID\",\"Name\":\"SDP ID\",\"Editable\":true,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"SDP_ID\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"network\",\"Name\":\"Network\",\"Editable\":true,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"network\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"numberingPlan\",\"Name\":\"Numbering Plan\",\"Editable\":true,\"DataType\":\"Combobox\",\"DefaultValue\":\"E.164\",\"CharacteristicValueList\":[{\"ExternalId\":\"numberingPlan\",\"Value\":\"E.164\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"resourceNumber\",\"Name\":\"Resource Number\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"resourceNumber\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"specificationSubtype\",\"Name\":\"Logical Resource Type\",\"Editable\":false,\"DataType\":\"Combobox\",\"DefaultValue\":\"MSISDN\",\"CharacteristicValueList\":[{\"ExternalId\":\"specificationSubtype\",\"Value\":\"MSISDN\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"subMarket\",\"Name\":\"Sub Market\",\"Editable\":true,\"DataType\":\"Combobox\",\"DefaultValue\":\"GSM\",\"CharacteristicValueList\":[{\"ExternalId\":\"subMarket\",\"Value\":\"GSM\",\"IsDefaultValue\":true}]}],\"ResourceType\":\"LogicalResourceSpec\",\"SpecificationSubType\":\"MSISDN\"}]},\"CharacteristicList\":[{\"ExternalId\":\"CreditLimitUsageThreshold_7000\",\"Name\":\"CreditLimitUsageThreshold_7000\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"4000\",\"CharacteristicValueList\":[{\"ExternalId\":\"CreditLimitUsageThreshold_7000\",\"Value\":\"4000\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"FAFCount\",\"Name\":\"FAFCount\",\"Editable\":false,\"DataType\":\"Text\",\"DefaultValue\":\"6\",\"CharacteristicValueList\":[{\"ExternalId\":\"FAFCount\",\"Value\":\"6\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"FAFList\",\"Name\":\"FAFList\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"FAFList\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"FAFMode\",\"Name\":\"FAFMode\",\"Editable\":true,\"DataType\":\"Text\",\"CharacteristicValueList\":[{\"ExternalId\":\"FAFMode\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"FAFPlusCount\",\"Name\":\"FAFPlusCount\",\"Editable\":false,\"DataType\":\"Text\",\"DefaultValue\":\"14\",\"CharacteristicValueList\":[{\"ExternalId\":\"FAFPlusCount\",\"Value\":\"14\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"PrepaidEmptyLimit\",\"Name\":\"PrepaidEmptyLimit\",\"Editable\":true,\"DataType\":\"Combobox\",\"DefaultValue\":\"0.000000\",\"CharacteristicValueList\":[{\"ExternalId\":\"PrepaidEmptyLimit\",\"Value\":\"0.000000\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"family\",\"Name\":\"Family\",\"Editable\":false,\"DataType\":\"Combobox\",\"DefaultValue\":\"Mobile\",\"CharacteristicValueList\":[{\"ExternalId\":\"family\",\"Value\":\"Mobile\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"reasonCode\",\"Name\":\"Reason Code\",\"Editable\":true,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"reasonCode\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"specificationSubSubtype\",\"Name\":\"Offer SubType\",\"Editable\":false,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"specificationSubSubtype\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"specificationSubtype\",\"Name\":\"Offer Type\",\"Editable\":false,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"specificationSubtype\",\"IsDefaultValue\":true}]}],\"POPList\":[{\"ExternalId\":\"CT_FAF_Chg\",\"Value\":\"7\",\"PriceType\":\"One Time\"},{\"ExternalId\":\"ctPam_ResetFU_VSD_Max\",\"Value\":\"0\",\"PriceType\":\"Recurring\",\"CharacteristicList\":[{\"ExternalId\":\"pamScheduleId\",\"Name\":\"pamScheduleId\",\"Editable\":false,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"pamScheduleId\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"pamScheduleType\",\"Name\":\"pamScheduleType\",\"Editable\":false,\"DataType\":\"Combobox\",\"DefaultValue\":\"BillCycle\",\"CharacteristicValueList\":[{\"ExternalId\":\"pamScheduleType\",\"Value\":\"BillCycle\",\"IsDefaultValue\":true}]}]},{\"ExternalId\":\"ctPam_SetMA_Max\",\"Value\":\"0\",\"PriceType\":\"Recurring\",\"CharacteristicList\":[{\"ExternalId\":\"canRefill\",\"Name\":\"canRefill\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"0\",\"CharacteristicValueList\":[{\"ExternalId\":\"canRefill\",\"Value\":\"0\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"pamIndicatorCreditLimit\",\"Name\":\"pamIndicatorCreditLimit\",\"Editable\":true,\"DataType\":\"Text\",\"DefaultValue\":\"3\",\"CharacteristicValueList\":[{\"ExternalId\":\"pamIndicatorCreditLimit\",\"Value\":\"3\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"pamScheduleId\",\"Name\":\"pamScheduleId\",\"Editable\":false,\"DataType\":\"Combobox\",\"CharacteristicValueList\":[{\"ExternalId\":\"pamScheduleId\",\"IsDefaultValue\":true}]},{\"ExternalId\":\"pamScheduleType\",\"Name\":\"pamScheduleType\",\"Editable\":false,\"DataType\":\"Combobox\",\"DefaultValue\":\"BillCycle\",\"CharacteristicValueList\":[{\"ExternalId\":\"pamScheduleType\",\"Value\":\"BillCycle\",\"IsDefaultValue\":true}]}]},{\"ExternalId\":\"ctRecMonth\",\"Value\":\"189\",\"PriceType\":\"Recurring\"},{\"ExternalId\":\"ctRecMonthTope\",\"Value\":\"0\",\"PriceType\":\"Recurring\"},{\"ExternalId\":\"ctUSG_Inc_Max_VSD\",\"Value\":\"0\",\"PriceType\":\"Per Use\"},{\"ExternalId\":\"ctUSG_NotInc_Max\",\"Value\":\"0\",\"PriceType\":\"Per Use\"},{\"ExternalId\":\"ctUSG_Prepaid_Max\",\"Value\":\"0\",\"PriceType\":\"Per Use\"}],\"AddonList\":[{\"AddonExternalId\":\"cargaMontonLlamaNomasPeruS10\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"cargaMontonLlamaNomasPeruS3\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"cargaMontonLlamaNomasPeruS6\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"cargaMontonLlamaNomasPeru_MIG\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"cargaMontonMix10S\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"cargaMontonMix20S\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"cargaMontonMix5S\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"cargaMontonMix_MIG\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"cargaMontonNoche10S\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"cargaMontonNoche20S\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"cargaMontonNoche5S\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"cargaMontonNoche_MIG\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"cargaMontonNumerosFrecuentesS10\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"cargaMontonNumerosFrecuentesS20\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"cargaMontonNumerosFrecuentesS5\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"cargaMontonNumerosFrecuentes_MIG\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"facebookTwitter1SAddOn\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"facebookTwitter20SAddOn\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"facebookTwitter5SAddOn\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"internet100MBAddOnR2\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"internet10dias\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"internet15dias\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"internet1GBAddOnR2\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"internet1dia\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"internet1hora\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"internet200MBAddOnR2\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"internet2GBAddOnR2\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"internet30dias\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"internet3GBAddOnR2\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"internet3dias\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"internet500MBAddOnR2\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"internet5dias\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"internet5soles\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"internet6dias\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"internetAddOn_MIG\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"mmsAddOn_MIG\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"redesSocialesAddOn\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"smsAdd10\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"smsAdd100\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"smsAdd200\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"smsAdd30\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"smsAdd500\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"smsAdd60\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"smsAddOn_MIG\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"voiceAddOn_MIG\",\"RelationType\":\"optional\"},{\"AddonExternalId\":\"whatsAppAddOn\",\"RelationType\":\"optional\"}],\"OptionalList\":[{\"OptionalExternalId\":\"BonoCM289OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"BonoCM29OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"BonoCM39OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"BonoCMC189OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"BonoCMC219OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"BonoCMC29OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"BonoCMC39OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"InternetClaro200MBR_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"InternetClaro500MBR_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"PaqueteCC2Net100OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"PaqueteCC2Net30OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"PaqueteCC2Net40OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"PaqueteCC2Net65OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"PaqueteCC2Net80OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan100MINUTOS_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan200MINUTOS_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan30MINUTOS_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan60MINUTOS_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlanNFSMS10000_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlanNFSMS1000_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlanNFSMS11000_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlanNFSMS12000_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlanNFSMS15500_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlanNFSMS16000_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlanNFSMS2500_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlanNFSMS3500_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlanNFSMS5000_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlanNFSMS500_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlanNFSMS6000_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlanNFSMS6500_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlanNFSMS7000_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_10GB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_1GB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_2GB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_3GB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_4GB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_5GB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_6GB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_8GB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_MMS10_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_MMS40_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_NFMin10000_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_NFMin1000_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_NFMin1500_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_NFMin2000_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_NFMin2500_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_NFMin3000_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_NFMin3500_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_NFMin4000_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_NFMin4500_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_NFMin500_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_NFMin5500_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_NFMin6000_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_NFMin6500_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"actPlan_NFMin7000_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional1000SMSOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional100SMSOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional10GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional150SMSOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional15GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional1GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional200MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional2GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional2_5GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional300SMSOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional3GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional4GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional500MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional500SMSOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional50MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional5GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional6GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicional9GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicionalInternacional100OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicionalInternacional200OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicionalInternacional30OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicionalInternacional60OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicionalMBS100OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicionalMBS10OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicionalMBS200OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicionalMBS20OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicionalMBS30OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicionalMBS60OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicionalMinLDI40OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicionalMinLDI70OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicionalMinRPC100OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicionalMinRPC300OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicionalMinRPC50OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"adicionalRedesSocialesOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono1000MinNFOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono1000SMSOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono100MB10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono100MinCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono100MinOffNetOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono100MinOnNet10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono100MinOnNetFijoOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono100MinOnNetOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono100SMSCDN10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono100SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono10GB10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono10MinCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono10SMSOnNet_10MMSOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono1200SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono120MinTodoDestOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono126MinOnNetOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono129MinCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono12MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono130MinOnNetOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono149MinCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono14MinCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono150MinCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono150MinOnNet10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono150SMSCD_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono150SMSOnNetOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono16MinCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono180MinCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono1GB10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono1GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono2000SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono200MB10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono200MinCDCCOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono200MinCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono200MinOnNetOffRPCOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono200MinTodoDestOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono200SMSCDN10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono200SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono20MB10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono20MinCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono20MinCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono20MinOnNet10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono20MinOnNetOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono250MinCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono25MinCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono25MinOnNetFijoOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono2GB10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono2GBCEOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono2GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono300MinCDMOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono300MinCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono300SMSCDN10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono300SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono334MinOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono350MinCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono400MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono400SMSCDN10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono400SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono40MinCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono40MinOnNetFijoOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono40MinOnNetOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono450SMSCD_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono500MB10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono500MinCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono500MinNFOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono500SMSCDN10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono500SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono50MinOnNetOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono50MinOnNetTLVOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono50MinTodoDestOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono50MinutosCDIOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono50SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono50SMSCD_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono55MinOnNetFijoOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono5GB10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono5GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono600MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono600MinCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono60MinOnNet10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono60MinOnNetOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono60SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono65MinCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono6MinOnNetOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono700SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono70MinOnNetOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono75MinCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bono75MinTodoDestOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoCHAT10OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoCHAT15OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoCM119OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoCM149OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoCM189OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoCM49OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoCM59OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoCM69OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoCM79OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoCM99OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoCMCH119OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoCMCH149OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoCMCH49OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoCMCH59OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoCMCH69OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoCMCH79OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoCMCH99OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMax10GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMax1GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMax1_5GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMax2GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMax30GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMax3GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMax400MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMax4GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMax5GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMax600MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMax6GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMax8GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMaxChip10GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMaxChip15GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMaxChip1_5GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMaxChip25GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMaxChip2GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMaxChip3GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMaxChip4GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMaxChip500MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMaxChip6GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMaxChip700MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoClaroMaxChip8GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFacebookTwitterOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFideliFacebookTwitterOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad100MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad100MinOnnetOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad100SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad10GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad1200SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad120MinTdoDesOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad150MinOnnetOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad1GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad1_5GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad200MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad200MinTdoDesOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad200SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad20MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad20MinOnnetOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad250MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad2GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad2_25GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad2_5GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad300SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad375MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad3GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad3_75GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad400SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad500MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad50MinTdoDestOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad5GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad60MinOnnetOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad700SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad750MB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad75MinTdoDestOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidad7_5GB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidadLDI30MinOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidadLDI70MinOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidadRPC100OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidadRPC200OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidadRPC300OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoFidelidadRPC500OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInterbank200MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro1000MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro100MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro10GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro10MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro1372MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro150MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro15GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro17_5GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro1GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro1GBSFOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro1_5GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro1_75GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro200MBMOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro250MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro2GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro2_25GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro2_5GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro300MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro350MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro375MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro3GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro3_5GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro3_75GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro450MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro4GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro4_5GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro500MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro50MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro5GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro5_25GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro700MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro750MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro75MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro800MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro875MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro8GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro8_75GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoInternetClaro9GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoLDI30MinOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoLDI70MinOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoLluvia100SMSOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoLluvia200SMSOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoMMS50OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoMinSMSIlim3LDI_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoMixOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoRPC10010SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoRPC100OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoRPC150OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoRPC20010SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoRPC200OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoRPC30010SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoRPC300OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoRPC40010SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoRPC400OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoRPC500OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoRPC50OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoRPC800OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoRPCCC10SMSCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoRPCIlimitadoOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoRecurrente25MinutosOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoRecurrente5MinutosOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoSF2000SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoSF350MinCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoSF500MinCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoSF600MinCDNOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoTeenOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"bonoWhatsappIlimitadoOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"chat10OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"chat15OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"chat15_35GOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro1000MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro100MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro10GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro10MB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro120MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro150MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro1GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro200MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro25MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro2GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro300MB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro30MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro3GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro3GB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro450MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro4GB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro500MB_35GOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro500MB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro50MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro5GBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro60MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro700MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro75MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaro800MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaroFidelidad10GB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaroFidelidad1GB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaroFidelidad5GB_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaroSF10240MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaroSF1024MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaroSF3072MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaroSF500MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaroSF5120MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetClaroSF700MBOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"internetMovilIlimitadoPlusOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"miCiudad_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"numFrecuentesIlimitados_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paq100MinCDIOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paq100MinOnNetFijoOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paq10GBPLUS_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paq1GBPLUS_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paq25MinOnNetFijoOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paq2GBPLUS_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paq3GBPLUS_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paq40MinOnNetFijoOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paq500MBPLUS_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paq55MinOnNetFijoOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paq5GBPLUS_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquetRPC100OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquetRPC150OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquetRPC200OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquetRPC400OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquetRPC50OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquetRPC60OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquete1000SMSM_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquete100SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquete1200SMSOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquete150SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquete150SMSOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquete2000SMSOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquete200SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquete20MinNumFrecuentes_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquete250SMSMOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquete300SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquete300SMSOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquete400SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquete450SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquete500SMSCDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquete500SMSM_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquete50SMSOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paquete700SMSOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCC2NET10_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCC2SMS1000OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCC2SMS100OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCC2SMS10OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCC2SMS200OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCC2SMS20OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCC2SMS300OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCC2SMS400OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCC2SMS500OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCC2SMS50OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCCMB500OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCCNet100OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCCNet10OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCCNet25OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCCNet40OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCCNet65OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCCNet80OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCCSMS1000OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCCSMS100OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCCSMS10OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCCSMS200OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCCSMS20OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCCSMS300OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCCSMS400OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCCSMS500OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteCCSMS50OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteInternacional30OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteInternacional70OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteMMS10OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteMMS20OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteMin100CDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteMin25CDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteMin40CDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteMin55CDOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteRPC300OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteRPC500OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteRPC800OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteTodDest120OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteTodDest200OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteTodDest50OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteTodDest75OptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteVideoLlamada15MinOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"paqueteVideoLlamada30MinOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"rPCClaroCorte_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"rPCClaro_LegR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"redesSocialesOpt\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"redesSocialesOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingCorporativoRRC500MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingMundo10MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingMundo5MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingMundoClaroClub10MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingMundoClaroClub15MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingMundoClaroClub30MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingMundoClaroClub50MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingMundoClaroClub5MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingRRC100MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingRRC10MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingRRC15MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingRRC250mb\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingRRC30MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingRRC500MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingRRC50MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingRRCClaroClub100MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingRRCClaroClub10MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingRRCClaroClub15MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingRRCClaroClub250MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingRRCClaroClub30MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingRRCClaroClub50MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"roamingRRCRenta500MB\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"rpcIlimitadoOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"sf1ClaroOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"sf2ClaroOptR2\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"voice30LDI\",\"RelationType\":\"optional\"},{\"OptionalExternalId\":\"whatsAppOptR2\",\"RelationType\":\"optional\"}],\"ProductTechnicalType\":\"Basic\",\"StartDate\":\"2018-11-05T06:25:00.000Z\",\"IsSellable\":true,\"Description\":\"CBiO Claro Max 189 Product Offering Basic for Charging System\",\"IsRollback\":true,\"AttachmentList\":[{\"ExternalId\":\"1a846bba95da433e92fa48b10feb299e\",\"Name\":\"User manual related to offering\",\"Type\":\"userManualAttachment\",\"MimeType\":\"text/plain\",\"AttachmentName\":\"newPcap.txt\",\"AttachmentCode\":\"claroMax198Attachment1\",\"URL\":\"/cwf/t/catalogAttachment?id=1a846bba95da433e92fa48b10feb299e\"}]}]}"

                }

            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.ProductOfferingSync>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }    
        [TestMethod]
        public void ModifyAddress()
    {
        var input = new Dictionary<string, object>()
            {
                { "CustomerAddressRequest",
                    new AmxPeruCustomerAddressRequest
                    {
                        CustomerType =1,
                        AddressType= 2,
                        ZoneType= 250000001,
                        Department= "4",
                        Province= "15",
                        District= "2",
                        ZIPPostalCode= "123356",
                        Country= "51",
                        Longitude= "12",
                        Latitude= "23",
                        BlockEdifice= 250000002,
                        ApartmentTypeInterior= 250000001,
                        UrbanizationType= 250000000,
                        PopulationZone=250000001,
                        ReferenceDescription= "TEST STRING",
                        Square= "TEST",
                        Allotment= "TEST",
                        Number= "3622",
                        Grouping= "TEST STRING",
                        Street1= 250000010,
                        Street2= "Test",
                        Street3= "Test",
                        BuildType= 250000001,
                        Normalized= true,
                        CustomerExternalId= "CUST0000000096",
                        CustomerAddressID="947c0cf5-5b8d-e711-812a-00505601173a"
                    }

                }

            };

        try
        {

            var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruModifyCustomerAddress>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
        [TestMethod]
        public void CreateProspect()
        {
            var input = new Dictionary<string, object>()
            {
                { "ProspectRequest",
                    new AxmPeruCreateProspectRequest
                    {
                        CustomerType =1,
                        documentType=1,
                        documentNumber="I2109089",
                        firstName="Harry",
                        lastName="Potter",
                        companyName="TestCompany",
                        email="harryPotter@test.com",
                        phone="765342567"
                    }

                }

            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruCreateProspect>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }


        [TestMethod]
        public void GetAddressTechnology()
        {
            var input = new Dictionary<string, object>()
            {
                { "addressId","dba747dd-1ae5-e711-80e9-fa163e10dfbe" }
               // { "addressId","926be8dd-2bca-e711-80e6-fa163e10dfbe" }
               
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.GetAddressAvailableTechnology>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }


        [TestMethod]
        public void LinePortabilityTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "lineNumberList", new List<string>(){ "51997884688", "51997884698", "50997884698" } },
                { "currentCarrier" , "Entel" },
                { "currentPlan" , "PrePaid" },
                { "serviceType" , "Mobile" },                

            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruLinePortabilityQuery>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }



        [TestMethod]
        public void GetAddress()
        {
            var input = new Dictionary<string, object>()
            {
                { "CustomerAddressRequest",
                    new AmxPeruGetCustomerAddressRequest
                    {
                        CustomerExternalId= "CUST0000000096",
                        CustomerType=1,
                        documentType= 2,
                        documentNumber= "J99001278",
                    }
                }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruGetCustomerAddress>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        [TestMethod]
        public void GetContact()
        {
            var input = new Dictionary<string, object>()
            {
                { "CustomerContactRequest",
                    new AxmPeruCustomerContactRequest
                    {
                        CustomerExternalId= "CUST0000000096"
                    }
                }

            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruGetCustomerContact>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        [TestMethod]
        public void GetCustomerInfo()
        {
            var input = new Dictionary<string, object>()
            {
                { "CustomerRequest",
                    new AmxPeruGetCustomerInfoRequest
                    {
                        CustomerExternalId= "",
                        CustomerType=1,
                        documentType=1,
                        documentNumber="12341234",
                        customerName="",
                        msisdn=""
                    }
                }

            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruGetCustomerInfo>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        [TestMethod]
        public void GetCustomerSpecialCase()
        {
            var input = new Dictionary<string, object>()
            {
                { "Request",
                    new AmxPeruGetCustomerSpecialCasesRequest
                    {
                        CustomerExternalId= "CUST0000000096",
                        CustomerType=1
                    }
                }

            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruGetCustomerSpecialCases>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        [TestMethod]
        public void CreateCaseNew()
        {
            var input = new Dictionary<string, object>()
            {

                { "request",
                    new CaseRequest
                    {CustomerType=1,
                        CaseTitle = "Test Case"+ DateTime.Now,
                        CaseType = "Informatives",
                        caseTypeCategory1="Balance and Consumption",
                        caseTypeCategory2="Balance Clarification/Consultation",
                        caseTypeCategory3="",
                        caseTypeCategory4="",
                        Priority=1,
                        Severity=318580000,
                        Origin=1,
                        CustomerId ="CUST0000000096",
                        CaseParentId="CAS-00000-B7C9X8",
                        Status=0,
                        Documents =   new List<Documents>()
                        {new Documents(){DocumentId="1",DocumentName="First Document",DocumentIdOnbase="HFDMIDF"},
                        new Documents(){DocumentId="2", DocumentName="Second Document",DocumentIdOnbase="KKVGIOH"}
                        },
                        Description ="Sample Description for Test"
                    }

                    }

            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.CraeteCase>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        [TestMethod]
        public void DataProtection()
        {
            var input = new Dictionary<string, object>()
            {
                { "DataProtectionRequest",
                    new AmxPeruDataProtectionRequest
                    {
                        DataProtectionValue= 250000001,
                        CustomerID="B43FDF45-1D79-E711-8126-00505601173A"
                    }
                }

            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruAffiliateDisaffiliateDataProtection>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        [TestMethod]
        public void BlacklistService()
        {
            var input = new Dictionary<string, object>()
            {
                {
                    "BlacklistRequest" , new AffiliateDisaffilateBlacklistRequest
                    {
                        ContractID= "CONTR0000000104",
                        CustomerExternalId="CUST0000000096",
                        PromotionsBlackList= "true",
                        SurveysBlackList= "true",
                        ClaroVASBlackList= "false",
                        ExternalVASBlackList= "false"
                     }
                }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxPeruAffiliateDisaffiliateBlacklist>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        [TestMethod]
        public void GetCTIService()
        {
            var input = new Dictionary<string, object>()
            {
                { "CTIRequest",
                    new AmxPeruCTIServiceRequest
                    {
                        CustomerExternalId= "CUST0000000096",
                        CustomerType=1,
                        DocumentType=1,
                        DocumentNumber="J990012782",
                        MSISDN="99880011"
                    }
                }

            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AamxPeruCTIService>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        [TestMethod]
        public void CreateTask()
        {
            var input = new Dictionary<string, object>()
            {
                { "CreateTaskRequest",
                    new AmxPeruCreateTaskRequest
                    {
                        CustomerExternalId= "CUST0000000096",
                        CustomerType=1,
                        Subject="Test task",
                        BIRequired=true,
                        Description="Task Creation",
                        Duration=4,
                        ScheduledEnd=DateTime.Today,
                        TaskType=2,
                        OwnerName="Admin User",
                        OwnerType="systemuser",
                        RegardingType = "contact",
                        RegardingColumnName = "etel_externalid",
                        RegardingColumnValue = "CUST0000000096",
                        Channel="ERMS",
                        ServiceId="22566"
                    }
                }

            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.CreateTask>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        
    }
}
