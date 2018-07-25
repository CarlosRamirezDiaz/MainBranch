using AmxCoPSBActivities.Model;
using AmxCoPSBActivities.Repository;
using AmxPeruPSBActivities.Model;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Repository
{
    class AmxCoProductResourceSpecificationRepository
    {
        OrganizationServiceProxy _organizationService;

        public AmxCoProductResourceSpecificationRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        /// <summary>
        /// Retrieve the Product Spec
        /// </summary>
        /// <param name="resourceSpecId"></param>
        /// <returns></returns>
        public etel_productresourcespecification GetProductResourceSpecification(System.Guid resourceSpecId)
        {
            if (resourceSpecId == Guid.Empty)
                return new etel_productresourcespecification();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_productresourcespecification",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.AmxCoProductResourceSpecificationFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_productresourcespecificationid", ConditionOperator.Equal, resourceSpecId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new etel_productresourcespecification();

            return AmxCoPSBActivities.Repository.Factory.AmxCoProductResourceSpecificationFactory.CreateProductResourceSpecificationFrom(collection.Entities[0]);
        }

        public AmxCoProducResourceSpecificationModelFull GetProductResourceSpecificationFull(AmxCoProductResourceCardinalityModel cardinality)
        {
            if (cardinality.amxperu_productresourcespecificationid == Guid.Empty)
                return new AmxCoProducResourceSpecificationModelFull();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_productresourcespecification",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.AmxCoProductResourceSpecificationFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_productresourcespecificationid", ConditionOperator.Equal, cardinality.amxperu_productresourcespecificationid);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new AmxCoProducResourceSpecificationModelFull();

            return AmxCoPSBActivities.Repository.Factory.AmxCoProductResourceSpecificationFactory.CreateProductResourceSpecificationFullFrom(_organizationService, collection.Entities[0]);
        }

        /// <summary>
        /// Retrieve the Product Spec
        /// </summary>
        /// <param name="resourceSpecId"></param>
        /// <returns></returns>
        public List<AmxCoProducResourceSpecificationModelFull> GetListProductResourceSpecificationFull(System.Guid productSpecId)
        {
            List<AmxCoProducResourceSpecificationModelFull> productResourceSpecFull = new List<AmxCoProducResourceSpecificationModelFull>();

            if (productSpecId == Guid.Empty)
                return productResourceSpecFull;

            // Get cardinalities
            AmxCoProductResourceCardinalityRepository cardinalityRepository = new AmxCoProductResourceCardinalityRepository(_organizationService);
            List<AmxCoProductResourceCardinalityModel> cardinalityList = cardinalityRepository.GetProductCardinalityFromProductSpec(productSpecId);

            // Loop through cardinalities and get product resources
            foreach (AmxCoProductResourceCardinalityModel cardinality in cardinalityList)
            {
                AmxCoProducResourceSpecificationModelFull prodSpecFull = GetProductResourceSpecificationFull(cardinality);
                prodSpecFull.productResourceCardinality = cardinality;
                productResourceSpecFull.Add(prodSpecFull);
            }
            
            return productResourceSpecFull;
        }

        public Guid Create(etel_productresourcespecification productResourceSpecification)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.AmxCoProductResourceSpecificationFactory.CreateEntityFrom(this._organizationService, productResourceSpecification);

            return this._organizationService.Create(entity);
        }

        public void Update(etel_productresourcespecification productResourceSpecification)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.AmxCoProductResourceSpecificationFactory.CreateEntityFrom(this._organizationService, productResourceSpecification);

            this._organizationService.Update(entity);
        }
    }
}
