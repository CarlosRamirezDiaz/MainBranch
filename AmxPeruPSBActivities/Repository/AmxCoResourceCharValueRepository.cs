using AmxCoPSBActivities.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.Repository
{
    class AmxCoResourceCharValueRepository
    {
        OrganizationServiceProxy _organizationService;

        public AmxCoResourceCharValueRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        /// <summary>
        /// Retrieve list of resource characteristic
        /// </summary>
        /// <param name="resourceSpecId"></param>
        /// <returns></returns>
        public List<AmxCoResourceCharValueModel> GetListResourceCharacteristicValue(System.Guid resourceSpecId)
        {
            List<AmxCoResourceCharValueModel> resourceCharValueList = new List<AmxCoResourceCharValueModel>();

            if (resourceSpecId == Guid.Empty)
                return resourceCharValueList;

            /*query.AddLink("etel_productresourcespecification", "etel_productresourcespecificationid", "etel_productspecificationid", JoinOperator.Inner);
            query.LinkEntities[0].LinkCriteria.AddCondition("etel_productspecificationid", ConditionOperator.Equal, productSpecificationId);*/

            // Retrieving all Product Spec for the offering
            string relationshipEntityName = "amxperu_productresourcespec_resourcecharvalue";
            QueryExpression query = new QueryExpression("amxperu_resourcecharacteristicvalue");
            query.NoLock = true;
            query.ColumnSet = new ColumnSet(true);

            LinkEntity linkEntity1 = new LinkEntity("amxperu_resourcecharacteristicvalue", relationshipEntityName, "amxperu_resourcecharacteristicvalueid", "amxperu_resourcecharacteristicvalueid", JoinOperator.Inner);
            LinkEntity linkEntity2 = new LinkEntity(relationshipEntityName, "etel_productresourcespecification", "etel_productresourcespecificationid", "etel_productresourcespecificationid", JoinOperator.Inner);
            linkEntity1.LinkEntities.Add(linkEntity2);
            query.LinkEntities.Add(linkEntity1);

            linkEntity2.LinkCriteria = new FilterExpression();

            linkEntity2.LinkCriteria.AddCondition(new ConditionExpression("etel_productresourcespecificationid", ConditionOperator.Equal, resourceSpecId));

            EntityCollection collRecords = _organizationService.RetrieveMultiple(query);

            foreach (Entity entity in collRecords.Entities)
            {
                resourceCharValueList.Add(AmxCoPSBActivities.Repository.Factory.AmxCoResourceCharValueFactory.CreateResourceCharValueFrom(_organizationService, entity));
            }

            return resourceCharValueList;
        }

        /// <summary>
        /// Retrieve the resource characteristic value
        /// </summary>
        /// <param name="resourceCharValId"></param>
        /// <returns></returns>
        public AmxCoResourceCharValueModel GetResourceCharValue(System.Guid resourceCharValId)
        {
            if (resourceCharValId == Guid.Empty)
                return new AmxCoResourceCharValueModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "transactioncurrency",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.AmxCoResourceCharFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("amxperu_resourcecharacteristicvalueid", ConditionOperator.Equal, resourceCharValId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new AmxCoResourceCharValueModel();

            return AmxCoPSBActivities.Repository.Factory.AmxCoResourceCharValueFactory.CreateResourceCharValueFrom(_organizationService, collection.Entities[0]);
        }

        public Guid Create(AmxCoResourceCharValueModel resourceCharValue)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.AmxCoResourceCharValueFactory.CreateEntityFrom(this._organizationService, resourceCharValue);

            return this._organizationService.Create(entity);
        }

        public void Update(AmxCoResourceCharValueModel resourceCharValue)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.AmxCoResourceCharValueFactory.CreateEntityFrom(this._organizationService, resourceCharValue);

            this._organizationService.Update(entity);
        }
    }
}
