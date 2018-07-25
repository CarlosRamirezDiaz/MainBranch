using AmxPeruPSBActivities.Model.OrderCapture;
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
    public class OrderCaptureRepository
    {
        OrganizationServiceProxy _organizationService;

        public OrderCaptureRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        /// <summary>
        /// Retrieve the Order Capture
        /// </summary>
        /// <param name="orderCaptureId"></param>
        /// <returns></returns>
        public OrderCaptureModel GetOrderCapture(System.Guid orderCaptureId)
        {
            if (orderCaptureId == Guid.Empty)
                return new OrderCaptureModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_ordercapture",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.OrderCaptureFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_ordercaptureid", ConditionOperator.Equal, orderCaptureId);
            
            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new OrderCaptureModel();

            return AmxCoPSBActivities.Repository.Factory.OrderCaptureFactory.CreateOrderCaptureFrom(collection.Entities[0]);
        }

        public Guid Create(OrderCaptureModel orderCapture)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.OrderCaptureFactory.CreateEntityFrom(this._organizationService, orderCapture);

            return this._organizationService.Create(entity);
        }

        public void Update(OrderCaptureModel orderCapture)
        {
            Entity entity = AmxCoPSBActivities.Repository.Factory.OrderCaptureFactory.CreateEntityFrom(this._organizationService, orderCapture);
            
            this._organizationService.Update(entity);
        }

        public List<AmxCoPSBActivities.AMXCOLOMBIA.Model.OrderCapture.ListOrderCapture> ListOrderCaptureByIndividualAndDate(Guid individualId, DateTime dateStart, DateTime dateEnd, int statusCode, int stateCode)
        {
            if (individualId == Guid.Empty)
                return new List<AmxCoPSBActivities.AMXCOLOMBIA.Model.OrderCapture.ListOrderCapture>();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_ordercapture",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.OrderCaptureFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_individualcustomerid", ConditionOperator.Equal, individualId);
            query.Criteria.AddCondition("createdon", ConditionOperator.OnOrAfter, dateStart);
            query.Criteria.AddCondition("createdon", ConditionOperator.OnOrBefore, dateEnd);

            if (statusCode > 0)
                query.Criteria.AddCondition("statuscode", ConditionOperator.Equal, statusCode);

            if (stateCode > -1)
                query.Criteria.AddCondition("statecode", ConditionOperator.Equal, stateCode);

            query.AddOrder("createdon", OrderType.Descending);

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            var returnValue = new List<AmxCoPSBActivities.AMXCOLOMBIA.Model.OrderCapture.ListOrderCapture>();

            if (collection == null || collection.Entities.Count == 0)
                return returnValue;

            foreach (var item in collection.Entities)
                returnValue.Add(AmxCoPSBActivities.Repository.Factory.OrderCaptureFactory.CreateListOrderCaptureFrom(item));

            return returnValue;
        }
    }
}
