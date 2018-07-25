using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using AmxCoPSBActivities.Repository.Factory;
using AmxCoPSBActivities.Model;

namespace AmxPeruPSBActivities.Repository
{
    class AmxCoProductOfferringRepository
    {
        OrganizationServiceProxy _organizationService;

        public AmxCoProductOfferringRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        /// <summary>
        /// Retrieve the Order Capture
        /// </summary>
        /// <param name="orderCaptureId"></param>
        /// <returns></returns>
        public ProductOffering GetProductOffering(System.Guid productOfferingId)
        {
            if (productOfferingId == Guid.Empty)
                return new ProductOffering();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "product",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.AmxCoProductOfferingFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("productid", ConditionOperator.Equal, productOfferingId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new ProductOffering();

            return AmxCoPSBActivities.Repository.Factory.AmxCoProductOfferingFactory.CreateProductOfferingFrom(collection.Entities[0]);
        }

        public ProductOfferingFull GetProductOfferingFull(System.Guid productOfferingId)
        {
            if (productOfferingId == Guid.Empty)
                return new ProductOfferingFull();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "product",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.AmxCoProductOfferingFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("productid", ConditionOperator.Equal, productOfferingId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new ProductOfferingFull();


            return AmxCoPSBActivities.Repository.Factory.AmxCoProductOfferingFactory.CreateProductOfferingFullFrom(_organizationService, collection.Entities[0]);
        }

        public ProductOffering GetProductOfferingByExternalId(string externalId)
        {
            if (string.IsNullOrEmpty(externalId))
                return new ProductOffering();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "product",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.AmxCoProductOfferingFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_externalid", ConditionOperator.Equal, externalId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new ProductOffering();

            return AmxCoPSBActivities.Repository.Factory.AmxCoProductOfferingFactory.CreateProductOfferingFrom(collection.Entities[0]);
        }

        public Boolean HasResourceCharToConfigure(ProductOfferingFull productOfferingFull)
        {
            if (productOfferingFull == null || productOfferingFull.ProductSpecification == null || productOfferingFull.ProductSpecification.ProductResourceSpecList == null
                || productOfferingFull.ProductSpecification.ProductResourceSpecList.Count() == 0)
                return false;

            // Loop through product resource specification list
            foreach(AmxCoProducResourceSpecificationModelFull resourceSpec in productOfferingFull.ProductSpecification.ProductResourceSpecList)
            {
                // Loop through resource char value
                if (resourceSpec.ResourceCharValueList == null || resourceSpec.ResourceCharValueList.Count() == 0)
                    return false;
            }

            return true;
        }

        public Guid Create(ProductOffering productOffering)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.AmxCoProductOfferingFactory.CreateEntityFrom(this._organizationService, productOffering);

            return this._organizationService.Create(entity);
        }

        public void Update(ProductOffering productOffering)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.AmxCoProductOfferingFactory.CreateEntityFrom(this._organizationService, productOffering);

            this._organizationService.Update(entity);
        }
    }
}
