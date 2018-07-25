using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model.BIBillingAccountCreate;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;

namespace AmxPeruPSBActivities.Repository
{
    public class BIBillingAccountCreateRepository
    {
        OrganizationServiceProxy _organizationService;

        public BIBillingAccountCreateRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        public BIBillingAccountCreateModel GetFirst(System.Guid individualCustomerId)
        {
            if (individualCustomerId == Guid.Empty)
                return new BIBillingAccountCreateModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_bi_billingaccountcreate",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.BIBillingAccountCreateFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_customerindividualid", ConditionOperator.Equal, individualCustomerId);

            query.AddOrder("createdon", OrderType.Ascending);
            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            //if (collection == null || collection.Entities.Count == 0)
            //    return new BIBillingAcccountCreateModel();

            return AmxCoPSBActivities.Repository.Factory.BIBillingAccountCreateFactory.CreateBIBillingAccountCreateFrom(collection.Entities[0]);
        }

        public Guid Create(BIBillingAccountCreateModel biBillngAccountCreateModel)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.BIBillingAccountCreateFactory.CreateEntityFrom(biBillngAccountCreateModel);

            return this._organizationService.Create(entity);
        }


    }
}
