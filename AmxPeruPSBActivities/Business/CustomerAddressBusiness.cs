using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Business
{
    public class CustomerAddressBusiness
    {
        XrmDataContextProvider ContextProvider;

        public CustomerAddressBusiness(XrmDataContextProvider contextProvider)
        {
            ContextProvider = contextProvider;
        }


        public string GetAddressTechnology(string addressId)
        {
            var addressQueryExpression = new QueryExpression();
            addressQueryExpression.EntityName = etel_customeraddress.EntityLogicalName;
            addressQueryExpression.Criteria.AddCondition("etel_customeraddressid", ConditionOperator.Equal, addressId);

            LinkEntity mglTech = new LinkEntity(etel_customeraddress.EntityLogicalName, "amx_bimgltechnicaldetails", "etel_customeraddressid", "amx_customeraddressid", JoinOperator.Inner);
            mglTech.EntityAlias = "mglTech";
            addressQueryExpression.LinkEntities.Add(mglTech);

            LinkEntity mglHhpps = new LinkEntity("amx_bimgltechnicaldetails", "amx_bimgllisthhpps", "amx_bimgltechnicaldetailsid", "amx_mgllisthhppsid", JoinOperator.Inner);
            mglHhpps.Columns = new ColumnSet("amx_technology", "amx_codenode");
            mglHhpps.EntityAlias = "mglHhpps";
            mglTech.LinkEntities.Add(mglHhpps);
            var addressList = ContextProvider.OrganizationService.RetrieveMultiple(addressQueryExpression)?.Entities?.ToList();
            //var t = ContextProvider.OrganizationService.RetrieveMultiple(addressQueryExpression)?.Entities?.FirstOrDefault();
            string addressTechList = string.Empty;
            foreach (var address in addressList)
            {
                addressTechList += address.GetAttributeValue<AliasedValue>("mglHhpps.amx_technology")?.Value?.ToString() + ";";
            }

            return addressTechList;
        }

        public string RetrieveEstratoByAddressId(string addressId)
        {
            QueryExpression mglTechEntity = new QueryExpression("amx_bimgltechnicaldetails");
            mglTechEntity.ColumnSet = new ColumnSet("amx_stratum");
            mglTechEntity.Criteria.AddCondition("amx_customeraddressid", ConditionOperator.Equal, new Guid(addressId));
            var mgl = ContextProvider.OrganizationService.RetrieveMultiple(mglTechEntity).Entities.FirstOrDefault();
            return (mgl?.Attributes.Keys.Contains("amx_stratum")).HasValue ? mgl["amx_stratum"].ToString() : null;
        }
    }
}
