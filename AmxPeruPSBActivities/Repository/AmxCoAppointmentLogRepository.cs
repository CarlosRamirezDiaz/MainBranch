using AmxPeruPSBActivities.AMXCOLOMBIA.Model;
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
    class AmxCoAppointmentLogRepository
    {
        OrganizationServiceProxy _organizationService;

        public AmxCoAppointmentLogRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }

        /// <summary>
        /// Retrieve the Appointment log
        /// </summary>
        /// <param name="etel_appointmentlogid"></param>
        /// <returns></returns>
        public AmxCoAppointmentLogModel GetAppointmentLog(System.Guid etel_appointmentlogid)
        {
            if (etel_appointmentlogid == Guid.Empty)
                return new AmxCoAppointmentLogModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_appointmentlog",
                ColumnSet = AmxPeruPSBActivities.Repository.Factory.AmxCoAppointmentLogFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_appointmentlogid", ConditionOperator.Equal, etel_appointmentlogid);

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new AmxCoAppointmentLogModel();

            return AmxPeruPSBActivities.Repository.Factory.AmxCoAppointmentLogFactory.CreateAppointmentLogFrom(collection.Entities[0]);
        }

        public Guid Create(AmxCoAppointmentLogModel appointmentLogModel)
        {
            Entity entity = AmxPeruPSBActivities.Repository.Factory.AmxCoAppointmentLogFactory.CreateEntityFrom(this._organizationService, appointmentLogModel);

            return this._organizationService.Create(entity);
        }

        public void Update(AmxCoAppointmentLogModel appointmentLogModel)
        {
            Entity entity = AmxPeruPSBActivities.Repository.Factory.AmxCoAppointmentLogFactory.CreateEntityFrom(this._organizationService, appointmentLogModel);

            this._organizationService.Update(entity);
        }

        /// <summary>
        /// Retrieve the Appointment logs for one order name
        /// </summary>
        /// <param name="orderName"></param>
        /// <returns></returns>
        public List<AmxCoAppointmentLogModel> GetAppointmentLogFromOrderName(String orderName)
        {
            if (String.IsNullOrEmpty(orderName))
                return new List<AmxCoAppointmentLogModel>();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_appointmentlog",
                ColumnSet = AmxPeruPSBActivities.Repository.Factory.AmxCoAppointmentLogFactory.Fields
            };
            
            query.Criteria.AddFilter(new FilterExpression
            {
                FilterOperator = LogicalOperator.And,
                Conditions =
                {
                    new ConditionExpression("etel_name", ConditionOperator.BeginsWith, orderName)
                },
            });

            query.Criteria.AddFilter(new FilterExpression
            {
                FilterOperator = LogicalOperator.Or,
                Conditions =
                {
                    new ConditionExpression("etel_appointmentstatus", ConditionOperator.Equal, "831260000"),
                    new ConditionExpression("etel_appointmentstatus", ConditionOperator.NotNull)
                }
            });

            query.TopCount = 1;

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new List<AmxCoAppointmentLogModel>();

            List<AmxCoAppointmentLogModel> listAppointmentLog = new List<AmxCoAppointmentLogModel>();
            foreach (Entity entity in collection.Entities)
            {
                listAppointmentLog.Add(AmxPeruPSBActivities.Repository.Factory.AmxCoAppointmentLogFactory.CreateAppointmentLogFrom(entity));
            }

            return listAppointmentLog;
        }

        /// <summary>
        /// Retrieves the customized appointment log list by order id
        /// </summary>
        /// <param name="orderId">Order Id</param>
        /// <returns>Appointment Log List</returns>
        public AmxCoAppointmentLogModel RetrieveAppointmentLogByOrderItem(System.Guid orderItemId)
        {
            if (orderItemId == Guid.Empty)
                return new AmxCoAppointmentLogModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "etel_orderitem",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.OrderItemFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_orderitemid", ConditionOperator.Equal, orderItemId);
            
            var collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0 || ! collection.Entities[0].Contains("amx_appointmentlogid"))
                return new AmxCoAppointmentLogModel();
            
            return GetAppointmentLog(((EntityReference)collection.Entities[0].Attributes["amx_appointmentlogid"]).Id);
        }
    }
}
