using AmxPeruPSBActivities.AMXCOLOMBIA.Model;
using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Model.OrderCapture;
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
    class OfferingRepository
    {
        OrganizationServiceProxy _organizationService;

        public OfferingRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        /// <summary>
        /// Retrieve the Order Capture
        /// </summary>
        /// <param name="productCharacteristicId"></param>
        /// <returns></returns>
        public ProductCharacteristicModel GetProductCharacteristic(System.Guid productCharacteristicId)
        {
            if (productCharacteristicId == Guid.Empty)
                return new ProductCharacteristicModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_productcharacteristic",
                ColumnSet = AmxPeruPSBActivities.Repository.Factory.OfferingFactory.ProudctCharacteristicFields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_productcharacteristicid", ConditionOperator.Equal, productCharacteristicId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new ProductCharacteristicModel();

            return AmxPeruPSBActivities.Repository.Factory.OfferingFactory.CreateProductCharacteristicFrom(collection.Entities[0]);
        }

        public Guid CreateProductChar(ProductCharacteristicModel productCharacteristic)
        {
            Entity entity = AmxPeruPSBActivities.Repository.Factory.OfferingFactory.CreateProductCharacteristicEntityFrom(this._organizationService, productCharacteristic);

            return this._organizationService.Create(entity);
        }

        public void UpdateProductChar(ProductCharacteristicModel productCharacteristic)
        {
            Entity entity = AmxPeruPSBActivities.Repository.Factory.OfferingFactory.CreateProductCharacteristicEntityFrom(this._organizationService, productCharacteristic);

            this._organizationService.Update(entity);
        }

        public List<CharacteristicsValue> GetProductOfferCharValueUsesFromOfferCharUse(Guid productOfferCharUse)
        {
            List<CharacteristicsValue> listCharValue = new List<CharacteristicsValue>();

            // Get all product offering characteristic use values from product characteristic use
            var productCharUseList = GetProductOfferCharUseValuessFromOfferCharUse(productOfferCharUse);

            // Build listCharValue based on product characteristic value
            foreach(ProductOfferingCharValueUseModel prodOfferCharValueUse in productCharUseList) {
                var prodCharValue = GetProductCharValue(prodOfferCharValueUse.amxperu_value.Id);
                listCharValue.Add(new CharacteristicsValue()
                {
                    guid = prodCharValue.etel_productcharacteristicvalueid,
                    value = prodCharValue.etel_name
                });
            }
            
            return listCharValue;
        }
        
        public List<ProductOfferingCharValueUseModel> GetProductOfferCharUseValuessFromOfferCharUse(Guid productOfferCharUseId)
        {
            List<ProductOfferingCharValueUseModel> productCharUseList = new List<ProductOfferingCharValueUseModel>();

            if (productOfferCharUseId == Guid.Empty)
                return new List<ProductOfferingCharValueUseModel>();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "amxperu_productofferingcharvalueuse",
                ColumnSet = AmxPeruPSBActivities.Repository.Factory.OfferingFactory.ProudctOfferingCharValueUseFields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("amxperu_productofferingcharuse", ConditionOperator.Equal, productOfferCharUseId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);
            
            if (collection == null || collection.Entities.Count == 0)
                return productCharUseList;
            else
            {
                foreach (Entity entity in collection.Entities)
                {
                    productCharUseList.Add(AmxPeruPSBActivities.Repository.Factory.OfferingFactory.CreateOfferingCharValueUseFrom(entity));
                }
            }

            return productCharUseList;
        }

        public ProductCharacteristicValueModel GetProductCharValue(Guid productCharValueId)
        {
            List<ProductCharacteristicValueModel> productCharUseList = new List<ProductCharacteristicValueModel>();


            if (productCharValueId == Guid.Empty)
                return new ProductCharacteristicValueModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_productcharacteristicvalue",
                ColumnSet = AmxPeruPSBActivities.Repository.Factory.OfferingFactory.ProductCharValueFields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_productcharacteristicvalueid", ConditionOperator.Equal, productCharValueId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new ProductCharacteristicValueModel();

            return AmxPeruPSBActivities.Repository.Factory.OfferingFactory.CreateProductCharValueFrom(collection[0]);
        }

        public ProductCharacteristicValueModel GetProductCharValueFromProdOfferCharValueUse(Guid productCharValueId)
        {
            List<ProductCharacteristicValueModel> resourceCharValueList = new List<ProductCharacteristicValueModel>();

            if (productCharValueId == Guid.Empty)
                return new ProductCharacteristicValueModel();

            // Retrieving all Product Spec for the offering
            /*string relationshipEntityName = "amxperu_productcharacteristicvalue_amxperu_productofferingcharvalueuse_value";
            QueryExpression query = new QueryExpression("etel_productcharacteristicvalue");
            query.NoLock = true;
            query.ColumnSet = new ColumnSet(true);

            LinkEntity linkEntity1 = new LinkEntity("etel_productcharacteristicvalue", relationshipEntityName, "etel_productcharacteristicvalueid", "etel_productcharacteristicvalueid", JoinOperator.Inner);
            LinkEntity linkEntity2 = new LinkEntity(relationshipEntityName, "amxperu_productofferingcharvalueuse", "amxperu_productofferingcharvalueuseid", "amxperu_productofferingcharvalueuseid", JoinOperator.Inner);
            linkEntity1.LinkEntities.Add(linkEntity2);
            query.LinkEntities.Add(linkEntity1);

            linkEntity2.LinkCriteria = new FilterExpression();

            linkEntity2.LinkCriteria.AddCondition(new ConditionExpression("amxperu_productofferingcharvalueuseid", ConditionOperator.Equal, productOfferCharValueUseId));

            EntityCollection collection = _organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new ProductCharacteristicValueModel();

            return AmxPeruPSBActivities.Repository.Factory.OfferingFactory.CreateProductCharValueFrom(collection[0]);*/

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_productcharacteristicvalue",
                ColumnSet = AmxPeruPSBActivities.Repository.Factory.OfferingFactory.ProductCharValueUseFields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_productcharacteristicvalueid", ConditionOperator.Equal, productCharValueId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new ProductCharacteristicValueModel();

            return AmxPeruPSBActivities.Repository.Factory.OfferingFactory.CreateProductCharValueFrom(collection[0]);
        }
    }
}
