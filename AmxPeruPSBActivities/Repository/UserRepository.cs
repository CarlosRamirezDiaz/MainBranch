using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Model.User;

namespace AmxPeruPSBActivities.Repository
{
    public class UserRepository
    {
        OrganizationServiceProxy _organizationService;

        public UserRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        public UserModel GetFirst(System.Guid id)
        {
            if (id == Guid.Empty)
                return new UserModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "systemuser",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.UserFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("systemuserid", ConditionOperator.Equal, id);

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new UserModel();

            return AmxCoPSBActivities.Repository.Factory.UserFactory.CreateUserFrom(collection.Entities[0]);
        }

        public Guid Create(UserModel userModel)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.UserFactory.CreateEntityFrom(userModel);

            return this._organizationService.Create(entity);
        }
    }
}
