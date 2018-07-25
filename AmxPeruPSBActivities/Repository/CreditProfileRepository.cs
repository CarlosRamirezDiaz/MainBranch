using AmxPeruPSBActivities.Model.CreditProfile;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
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
    public class CreditProfileRepository
    {
        OrganizationServiceProxy _organizationService;

        public CreditProfileRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        /// <summary>
        /// Retrieve the last Credit Profile
        /// </summary>
        /// <param name="individualCustomerId"></param>
        /// <param name="bureauDate"></param>
        /// <returns></returns>
        public CreditProfileModel GetLastBy(System.Guid individualCustomerId, DateTime bureauDate)
        {
            if (individualCustomerId == Guid.Empty)
                return new CreditProfileModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_creditprofile",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.CreditProfileFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_individualid", ConditionOperator.Equal, individualCustomerId);
            query.Criteria.AddCondition("amxco_bureaudate", ConditionOperator.GreaterEqual, bureauDate);

            query.AddOrder("amxco_bureaudate", OrderType.Descending);
            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new CreditProfileModel();

            return AmxCoPSBActivities.Repository.Factory.CreditProfileFactory.CreateCreditProfileFrom(collection.Entities[0]);
        }

        public Guid Create(CreditProfileModel creditProfile)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.CreditProfileFactory.CreateEntityFrom(creditProfile);

            return this._organizationService.Create(entity);
        }
    }
}
