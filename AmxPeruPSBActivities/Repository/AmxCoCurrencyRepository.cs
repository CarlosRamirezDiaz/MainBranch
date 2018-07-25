using AmxPeruPSBActivities.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxCoPSBActivities.Repository.Factory;

namespace AmxPeruPSBActivities.Repository
{
    class AmxCoCurrencyRepository
    {
        OrganizationServiceProxy _organizationService;

        public AmxCoCurrencyRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        /// <summary>
        /// Retrieve the Order Capture
        /// </summary>
        /// <param name="orderCaptureId"></param>
        /// <returns></returns>
        public AmxCoCurrencyModel GetCurrency(System.Guid currencyId)
        {
            if (currencyId == Guid.Empty)
                return new AmxCoCurrencyModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "transactioncurrency",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.AmxCoCurrencyFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("transactioncurrencyid", ConditionOperator.Equal, currencyId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new AmxCoCurrencyModel();

            return AmxCoPSBActivities.Repository.Factory.AmxCoCurrencyFactory.CreateCurrencyFrom(collection.Entities[0]);
        }

        public Guid Create(AmxCoCurrencyModel orderCapture)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.AmxCoCurrencyFactory.CreateEntityFrom(this._organizationService, orderCapture);

            return this._organizationService.Create(entity);
        }

        public void Update(AmxCoCurrencyModel orderCapture)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.AmxCoCurrencyFactory.CreateEntityFrom(this._organizationService, orderCapture);

            this._organizationService.Update(entity);
        }
    }
}
