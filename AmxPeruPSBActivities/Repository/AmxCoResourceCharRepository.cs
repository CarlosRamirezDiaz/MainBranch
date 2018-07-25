using AmxCoPSBActivities.Model;
using AmxPeruPSBActivities.Model;
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
    class AmxCoResourceCharRepository
    {
        OrganizationServiceProxy _organizationService;

        public AmxCoResourceCharRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        /// <summary>
        /// Retrieve the Order Capture
        /// </summary>
        /// <param name="orderCaptureId"></param>
        /// <returns></returns>
        public AmxCoResourceCharModel GetResourceChar(System.Guid resourceCharId)
        {
            if (resourceCharId == Guid.Empty)
                return new AmxCoResourceCharModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "amxperu_resourcecharacteristic",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.AmxCoResourceCharFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("amxperu_resourcecharacteristicid", ConditionOperator.Equal, resourceCharId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new AmxCoResourceCharModel();

            return AmxCoPSBActivities.Repository.Factory.AmxCoResourceCharFactory.CreateResourceCharFrom(collection.Entities[0]);
        }

        public Guid Create(AmxCoResourceCharModel resourceChar)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.AmxCoResourceCharFactory.CreateEntityFrom(this._organizationService, resourceChar);

            return this._organizationService.Create(entity);
        }

        public void Update(AmxCoResourceCharModel resourceChar)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.AmxCoResourceCharFactory.CreateEntityFrom(this._organizationService, resourceChar);

            this._organizationService.Update(entity);
        }
    }
}
