using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk.Query;

namespace AmxCoPSBActivities.Repository.Factory
{
    internal static class AmxCoProductResourceCardinalityFactory
    {
        internal static Entity CreateEntityFrom(OrganizationServiceProxy org, AmxCoProductResourceCardinalityModel productCardinality)
        {
            Entity entity = new Entity("amxperu_productresourcecardinality");

            entity.Id = productCardinality.amxperu_productresourcecardinalityid;
            entity.Attributes.Add("amxperu_name", productCardinality.amxperu_name);
            entity.Attributes.Add("amxperu_productresourcespecificationid", new EntityReference("amxperu_productresourcespecificationid", productCardinality.amxperu_productresourcespecificationid));
            entity.Attributes.Add("amxperu_productspecificationid", new EntityReference("amxperu_productspecificationid", productCardinality.amxperu_productspecificationid));
            entity.Attributes.Add("amxperu_targetcardinalitymax", productCardinality.amxperu_targetcardinalitymax);
            entity.Attributes.Add("amxperu_targetcardinalitymin", productCardinality.amxperu_targetcardinalitymin);

            return entity;
        }

        internal static AmxCoProductResourceCardinalityModel CreateProductResourceCardinalityFrom(Entity entity)
        {
            var productResourceCardinality = new AmxCoProductResourceCardinalityModel();

            productResourceCardinality.amxperu_productresourcecardinalityid = entity.Id;

            if (entity.Contains("amxperu_name"))
                productResourceCardinality.amxperu_name = entity.Attributes["amxperu_name"].ToString();
            if (entity.Contains("amxperu_productresourcespecificationid"))
                productResourceCardinality.amxperu_productresourcespecificationid = ((EntityReference)entity.Attributes["amxperu_productresourcespecificationid"]).Id;
            if (entity.Contains("amxperu_productspecificationid"))
                productResourceCardinality.amxperu_productspecificationid = ((EntityReference)entity.Attributes["amxperu_productspecificationid"]).Id;
            if (entity.Contains("amxperu_targetcardinalitymax"))
                productResourceCardinality.amxperu_targetcardinalitymax = (int)entity.Attributes["amxperu_targetcardinalitymax"];
            if (entity.Contains("amxperu_targetcardinalitymin"))
                productResourceCardinality.amxperu_targetcardinalitymin = (int)entity.Attributes["amxperu_targetcardinalitymin"];

            return productResourceCardinality;
        }

        internal static ColumnSet Fields
        {
            get
            {
                return new ColumnSet(new string[] { "amxperu_productresourcecardinalityid"
                    ,"amxperu_name"
                    ,"amxperu_productresourcespecificationid"
                    ,"amxperu_productspecificationid"
                    ,"amxperu_targetcardinalitymax"
                    ,"amxperu_targetcardinalitymin"});
            }
        }
    }
}
