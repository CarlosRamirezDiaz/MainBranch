using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;

namespace AmxPeruPSBActivities.Repository
{
    public class AmxCoProductResourceCardinalityRepository
    {
        OrganizationServiceProxy _organizationService;

        public AmxCoProductResourceCardinalityRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        /// <summary>
        /// Retrieve the Order Capture
        /// </summary>
        /// <param name="orderCaptureId"></param>
        /// <returns></returns>
        public AmxCoProductResourceCardinalityModel GetProductResourceCardinality(System.Guid cardinalityId)
        {
            if (cardinalityId == Guid.Empty)
                return new AmxCoProductResourceCardinalityModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "amxperu_productresourcecardinality",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.AmxCoProductResourceCardinalityFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("amxperu_productresourcecardinalityid", ConditionOperator.Equal, cardinalityId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new AmxCoProductResourceCardinalityModel();

            return AmxCoPSBActivities.Repository.Factory.AmxCoProductResourceCardinalityFactory.CreateProductResourceCardinalityFrom(collection.Entities[0]);
        }

        /// <summary>
        /// Retrieve the Order Capture
        /// </summary>
        /// <param name="orderCaptureId"></param>
        /// <returns></returns>
        public List<AmxCoProductResourceCardinalityModel> GetProductCardinalityFromProductSpec(System.Guid productSpecId)
        {
            List<AmxCoProductResourceCardinalityModel> productCardinalityList = new List<AmxCoProductResourceCardinalityModel>();

            if (productSpecId == Guid.Empty)
                return productCardinalityList;

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "amxperu_productresourcecardinality",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.AmxCoProductResourceCardinalityFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("amxperu_productspecificationid", ConditionOperator.Equal, productSpecId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new List<AmxCoProductResourceCardinalityModel>();
            
            foreach(Entity entity in collection.Entities)
                productCardinalityList.Add(AmxCoPSBActivities.Repository.Factory.AmxCoProductResourceCardinalityFactory.CreateProductResourceCardinalityFrom(entity));

            return productCardinalityList;
        }

        public Guid Create(AmxCoProductResourceCardinalityModel productResourceCardinality)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.AmxCoProductResourceCardinalityFactory.CreateEntityFrom(this._organizationService, productResourceCardinality);

            return this._organizationService.Create(entity);
        }

        public void Update(AmxCoProductResourceCardinalityModel productResourceCardinality)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.AmxCoProductResourceCardinalityFactory.CreateEntityFrom(this._organizationService, productResourceCardinality);

            this._organizationService.Update(entity);
        }
    }
}
