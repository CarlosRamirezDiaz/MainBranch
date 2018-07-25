using AmxPeruPSBActivities.Model.BiSpecification;
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
    internal class BISpecificationRepository
    {
        OrganizationServiceProxy _organizationService;

        public BISpecificationRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        public BISpecificationModel GetById(Guid biSpecificationId)
        {
            if (biSpecificationId == Guid.Empty)
                return new BISpecificationModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_businessinteractionspecification",
                ColumnSet = AmxPeruPSBActivities.Repository.Factory.BISpecificationFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_businessinteractionspecificationid", ConditionOperator.Equal, biSpecificationId);

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new BISpecificationModel();

            return AmxPeruPSBActivities.Repository.Factory.BISpecificationFactory.CreateFrom(collection.Entities[0]);
        }

        public BISpecificationModel GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new BISpecificationModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_businessinteractionspecification",
                ColumnSet = AmxPeruPSBActivities.Repository.Factory.BISpecificationFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_name", ConditionOperator.Equal, name);

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new BISpecificationModel();

            return AmxPeruPSBActivities.Repository.Factory.BISpecificationFactory.CreateFrom(collection.Entities[0]);
        }
    }
}
