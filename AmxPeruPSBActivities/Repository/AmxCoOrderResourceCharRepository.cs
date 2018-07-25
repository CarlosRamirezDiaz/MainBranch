using AmxPeruPSBActivities.AMXCOLOMBIA.Model;
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
    class AmxCoOrderResourceCharRepository
    {
        OrganizationServiceProxy _organizationService;

        public AmxCoOrderResourceCharRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        /// <summary>
        /// Retrieve the Order Capture
        /// </summary>
        /// <param name="orderCaptureId"></param>
        /// <returns></returns>
        public AmxCoOrderResourceCharModel GetOrderResourceChar(System.Guid orderResourceCharId)
        {
            if (orderResourceCharId == Guid.Empty)
                return new AmxCoOrderResourceCharModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_orderresourcecharacteric",
                ColumnSet = AmxPeruPSBActivities.Repository.Factory.AmxCoOrderResourceFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_orderresourcecharactericid", ConditionOperator.Equal, orderResourceCharId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new AmxCoOrderResourceCharModel();

            return AmxPeruPSBActivities.Repository.Factory.AmxCoOrderResourceCharFactory.CreateOrderResourceCharFrom(collection.Entities[0]);
        }

        public Guid Create(AmxCoOrderResourceCharModel orderResourceChar)
        {
            Entity entity = AmxPeruPSBActivities.Repository.Factory.AmxCoOrderResourceCharFactory.CreateEntityFrom(this._organizationService, orderResourceChar);

            return this._organizationService.Create(entity);
        }

        public void Update(AmxCoOrderResourceCharModel orderResourceChar)
        {
            Entity entity = AmxPeruPSBActivities.Repository.Factory.AmxCoOrderResourceCharFactory.CreateEntityFrom(this._organizationService, orderResourceChar);

            this._organizationService.Update(entity);
        }
    }
}
