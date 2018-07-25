using AmxCoPSBActivities.Model.ProductOfferingPrice;
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
    class AmxCoProductOfferingPriceRepository
    {
        OrganizationServiceProxy _organizationService;

        Dictionary<string, string> priceCodeTranslation =
            new Dictionary<string, string>() { { "831260002", "M" }, { "831260000", "D" } };

        public AmxCoProductOfferingPriceRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        public string GetPriceCodeTranslation(string s)
        {
            return priceCodeTranslation[s];
        }

        /// <summary>
        /// Retrieve the Order Capture
        /// </summary>
        /// <param name="orderCaptureId"></param>
        /// <returns></returns>
        public AmxCoProductOfferingPriceModel GetProductOfferingPrice(System.Guid productOfferingPriceId)
        {
            if (productOfferingPriceId == Guid.Empty)
                return new AmxCoProductOfferingPriceModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "amxperu_productofferingprice",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.AmxCoProductOfferingPriceFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("amxperu_productofferingpriceid", ConditionOperator.Equal, productOfferingPriceId);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new AmxCoProductOfferingPriceModel();

            return AmxCoPSBActivities.Repository.Factory.AmxCoProductOfferingPriceFactory.CreateProductOfferingPriceFrom(collection.Entities[0]);
        }

        public Guid Create(AmxCoProductOfferingPriceModel orderCapture)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.AmxCoProductOfferingPriceFactory.CreateEntityFrom(orderCapture);

            return this._organizationService.Create(entity);
        }

        public void Update(AmxCoProductOfferingPriceModel orderCapture)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.AmxCoProductOfferingPriceFactory.CreateEntityFrom(orderCapture);

            this._organizationService.Update(entity);
        }
    }
}
