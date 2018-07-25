using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk.Query;
using System.Linq;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;
using System;
using AmxPeruPSBActivities.Model.OrderResource;

namespace AmxPeruPSBActivities.Business
{
    public class OrderResourceBusiness
    {
        XrmDataContextProvider ContextProvider;

        public OrderResourceBusiness(XrmDataContextProvider contextProvider)
        {
            ContextProvider = contextProvider;
        }

        public List<Entity> RetrieveOrderResourceCharacteristicsByOrderItemId(Guid orderItemId, string prsExternalId = null)
        {
            var prodResSpecQuery = RetrievePRSQueryObject(prsExternalId);

            LinkEntity orderResourceEntity = new LinkEntity(etel_productresourcespecification.EntityLogicalName, etel_orderresource.EntityLogicalName, "etel_productresourcespecificationid", "etel_productresourcespecification", JoinOperator.Inner);
            orderResourceEntity.EntityAlias = etel_orderresource.EntityLogicalName;
            orderResourceEntity.Columns = new ColumnSet("etel_value", "etel_orderresourceid");
            orderResourceEntity.LinkCriteria.AddCondition("etel_orderitemid", ConditionOperator.Equal, orderItemId);
            prodResSpecQuery.LinkEntities.Add(orderResourceEntity);

            LinkEntity orderResourceChar = new LinkEntity(etel_orderresource.EntityLogicalName, etel_orderresourcecharacteric.EntityLogicalName, "etel_orderresourceid", "etel_orderresourceid", JoinOperator.Inner);
            orderResourceChar.EntityAlias = etel_orderresourcecharacteric.EntityLogicalName;
            orderResourceChar.Columns = new ColumnSet("etel_value", "etel_orderresourcecharactericid");
            orderResourceEntity.LinkEntities.Add(orderResourceChar);

            LinkEntity resourceChar = new LinkEntity(etel_orderresourcecharacteric.EntityLogicalName, "amxperu_resourcecharacteristic", "amx_resource_characteristic", "amxperu_resourcecharacteristicid", JoinOperator.Inner);
            resourceChar.EntityAlias = "amxperu_resourcecharacteristic";
            resourceChar.Columns = new ColumnSet("amxperu_externalid", "amxperu_name");
            orderResourceChar.LinkEntities.Add(resourceChar);

            return ContextProvider.OrganizationService.RetrieveMultiple(prodResSpecQuery)?.Entities?.ToList();
        }

        public QueryExpression RetrievePRSQueryObject(string prsExternalId)
        {
            QueryExpression prodResSpecEntity = new QueryExpression();
            prodResSpecEntity.EntityName = etel_productresourcespecification.EntityLogicalName;
            prodResSpecEntity.ColumnSet = new ColumnSet("etel_name", "etel_externalid", "amxperu_resourcetypecode");
            if (!string.IsNullOrWhiteSpace(prsExternalId))
            {
                prodResSpecEntity.Criteria.Conditions.Add(new ConditionExpression("etel_externalid", ConditionOperator.Equal, prsExternalId));
            }
            return prodResSpecEntity;
        }

        public Guid CreateOrderResource(etel_orderitem orderItem, etel_productresourcespecification prodResSpec)
        {
            var orderResource = new etel_orderresource();
            orderResource.etel_orderitemid = orderItem.ToEntityReference();
            orderResource.etel_productresourcespecification = prodResSpec.ToEntityReference();
            orderResource.etel_name = prodResSpec.etel_name;

            return ContextProvider.OrganizationService.Create(orderResource);
        }

        public void CreateOrderResourceCharacteristics(Guid orderResourceId, List<Entity> resourceCharList, ResourceCharacteristicsModel resourceChar)
        {
            foreach (var item in resourceCharList)
            {
                var resourceCharValueItem = new etel_orderresourcecharacteric();
                resourceCharValueItem.etel_orderresourceid = new EntityReference(etel_orderresource.EntityLogicalName, orderResourceId);
                resourceCharValueItem["amx_resource_characteristic"] = new EntityReference("amxperu_resourcecharacteristic", new Guid(item?.GetAttributeValue<AliasedValue>("resourceChar.amxperu_resourcecharacteristicid")?.Value?.ToString()));
                resourceCharValueItem.etel_name = item?.GetAttributeValue<AliasedValue>("resourceChar.amxperu_name")?.Value?.ToString();

                switch (item?.GetAttributeValue<AliasedValue>("resourceChar.amxperu_externalid")?.Value?.ToString())
                {
                    case "resourceNumber":
                        resourceCharValueItem.etel_value = resourceChar.TelephoneNumber;
                        break;
                    case "SDP_ID":
                        resourceCharValueItem.etel_value = resourceChar.Sdp_Id;
                        break;
                    case "ssw_id":
                        resourceCharValueItem.etel_value = resourceChar.Ssw_Id;
                        break;
                    default:
                        break;
                }

                var resourceCharValueItemId = ContextProvider.OrganizationService.Create(resourceCharValueItem);
            }
        }

        public List<Entity> RetrieveResourceCharacteristics(string prsExternalId)
        {
            var prodResSpecQuery = RetrievePRSQueryObject(prsExternalId);

            LinkEntity prsRcvRelation = new LinkEntity(etel_productresourcespecification.EntityLogicalName, "amxperu_productresourcespec_resourcecharvalue", "etel_productresourcespecificationid", "etel_productresourcespecificationid", JoinOperator.Inner);
            prsRcvRelation.EntityAlias = "prsRcvRelation";
            prodResSpecQuery.LinkEntities.Add(prsRcvRelation);

            LinkEntity resourceCharValue = new LinkEntity("amxperu_productresourcespec_resourcecharvalue", "amxperu_resourcecharacteristicvalue", "amxperu_resourcecharacteristicvalueid", "amxperu_resourcecharacteristicvalueid", JoinOperator.Inner);
            resourceCharValue.EntityAlias = "resourceCharValue";
            prsRcvRelation.LinkEntities.Add(resourceCharValue);

            LinkEntity resourceCharr = new LinkEntity("amxperu_resourcecharacteristicvalue", "amxperu_resourcecharacteristic", "amxperu_resourcecharacteristicid", "amxperu_resourcecharacteristicid", JoinOperator.Inner);
            resourceCharr.EntityAlias = "resourceChar";
            resourceCharr.Columns = new ColumnSet("amxperu_resourcecharacteristicid", "amxperu_externalid", "amxperu_name");
            resourceCharValue.LinkEntities.Add(resourceCharr);

            return ContextProvider.OrganizationService.RetrieveMultiple(prodResSpecQuery)?.Entities?.ToList();
        }
    }
}
