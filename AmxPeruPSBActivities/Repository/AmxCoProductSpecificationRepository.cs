using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Model;
using AmxCoPSBActivities.Repository.Factory;
using AmxCoPSBActivities.Model;

namespace AmxCoPSBActivities.Repository
{
    class AmxCoProductSpecificationRepository
    {
        OrganizationServiceProxy _organizationService;

        public AmxCoProductSpecificationRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        public AmxCoProductSpecificationModelFull GetProductSpecificationFull(Guid productSpecId)
        {
            if (productSpecId == Guid.Empty)
                return new AmxCoProductSpecificationModelFull();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_productspecification",
                ColumnSet = AmxCodPSBActivities.Repository.Factory.AmxCoProductSpecificationFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_productspecificationid", ConditionOperator.Equal, productSpecId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new AmxCoProductSpecificationModelFull();

            return AmxCodPSBActivities.Repository.Factory.AmxCoProductSpecificationFactory.CreateProductSpecificationFullFrom(_organizationService, collection.Entities[0]);
        }
    }
}
