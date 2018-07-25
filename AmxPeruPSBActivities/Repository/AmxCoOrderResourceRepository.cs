using AmxCoPSBActivities.AMXCOLOMBIA.Model;
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
    public class AmxCoOrderResourceRepository
    {
        OrganizationServiceProxy _organizationService;

        public AmxCoOrderResourceRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        /// <summary>
        /// Retrieve the Order Capture
        /// </summary>
        /// <param name="orderCaptureId"></param>
        /// <returns></returns>
        public AmxCoOrderResourceModel GetOrderResource(System.Guid currencyId)
        {
            if (currencyId == Guid.Empty)
                return new AmxCoOrderResourceModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_orderresource",
                ColumnSet = AmxPeruPSBActivities.Repository.Factory.AmxCoOrderResourceFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_orderresourceid", ConditionOperator.Equal, currencyId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new AmxCoOrderResourceModel();

            return AmxPeruPSBActivities.Repository.Factory.AmxCoOrderResourceFactory.CreateOrderResourceFrom(collection.Entities[0]);
        }

        public Guid Create(AmxCoOrderResourceModel orderResource)
        {
            Entity entity = AmxPeruPSBActivities.Repository.Factory.AmxCoOrderResourceFactory.CreateEntityFrom(this._organizationService, orderResource);

            return this._organizationService.Create(entity);
        }

        public void Update(AmxCoOrderResourceModel orderResource)
        {
            Entity entity = AmxPeruPSBActivities.Repository.Factory.AmxCoOrderResourceFactory.CreateEntityFrom(this._organizationService, orderResource);

            this._organizationService.Update(entity);
        }
    }
}
