using AmxPeruPSBActivities.Model.Individual;
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
    public class IndividualCustomerRepository
    {
        OrganizationServiceProxy _organizationService;

        public IndividualCustomerRepository(OrganizationServiceProxy org)
        {
            this._organizationService = org;
        }


        /// <summary>
        /// Retrieve the Individual Info
        /// </summary>
        /// <param name="individualCustomerId"></param>
        /// <returns></returns>
        public IndividualCustomerModel GetById(System.Guid individualCustomerId)
        {
            if (individualCustomerId == Guid.Empty)
                return new IndividualCustomerModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "contact",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.IndividualCustomerFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("contactid", ConditionOperator.Equal, individualCustomerId);

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new IndividualCustomerModel();

            var entity = collection.Entities[0];

            return AmxCoPSBActivities.Repository.Factory.IndividualCustomerFactory.CreateIndividualFrom(entity);
        }

        public IndividualCustomerModel GetByDocumentNumber(string documentNumber, int documentType)
        {
            if (string.IsNullOrEmpty(documentNumber))
                return new IndividualCustomerModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "contact",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.IndividualCustomerFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_iddocumentnumber", ConditionOperator.Equal, documentNumber);
            if (documentType > 0)
                query.Criteria.AddCondition("amxperu_documenttype", ConditionOperator.Equal, documentType);

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new IndividualCustomerModel();

            var entity = collection.Entities[0];

            return AmxCoPSBActivities.Repository.Factory.IndividualCustomerFactory.CreateIndividualFrom(entity);
        }

        public IndividualCustomerModel GetByAccountNumber(string accountNumber)
        {
            if (string.IsNullOrEmpty(accountNumber))
                return new IndividualCustomerModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "contact",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.IndividualCustomerFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_externalid", ConditionOperator.Equal, accountNumber);

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new IndividualCustomerModel();

            var entity = collection.Entities[0];

            return AmxCoPSBActivities.Repository.Factory.IndividualCustomerFactory.CreateIndividualFrom(entity);
        }

        public IndividualCustomerModel GetByCustomerName(string customerName)
        {
            if (string.IsNullOrEmpty(customerName))
                return new IndividualCustomerModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "contact",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.IndividualCustomerFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("fullname", ConditionOperator.Equal, customerName);

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new IndividualCustomerModel();

            var entity = collection.Entities[0];

            return AmxCoPSBActivities.Repository.Factory.IndividualCustomerFactory.CreateIndividualFrom(entity);
        }

        public List<IndividualCustomerModel> ListByTelephoneNumber(string telephoneNumber)
        {
            if (string.IsNullOrEmpty(telephoneNumber))
                return new List<IndividualCustomerModel>();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "contact",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.IndividualCustomerFactory.Fields
            };

            query.Criteria = new FilterExpression(LogicalOperator.Or);
            query.Criteria.AddCondition("mobilephone", ConditionOperator.Equal, telephoneNumber);
            query.Criteria.AddCondition("telephone1", ConditionOperator.Equal, telephoneNumber);
            query.Criteria.AddCondition("telephone2", ConditionOperator.Equal, telephoneNumber);
            query.Criteria.AddCondition("telephone3", ConditionOperator.Equal, telephoneNumber);

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new List<IndividualCustomerModel>();

            var list = new List<IndividualCustomerModel>();
            foreach(var entity in collection.Entities)
                list.Add(AmxCoPSBActivities.Repository.Factory.IndividualCustomerFactory.CreateIndividualFrom(entity));

            return list;
        }

        public IndividualCustomerModel GetByCRMAccountNumber(string crmAccountNumber)
        {
            if (string.IsNullOrEmpty(crmAccountNumber))
                return new IndividualCustomerModel();

            QueryExpression query = new QueryExpression
            {
                NoLock = true,
                EntityName = "contact",
                ColumnSet = AmxCoPSBActivities.Repository.Factory.IndividualCustomerFactory.Fields
            };

            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_accountnumber", ConditionOperator.Equal, crmAccountNumber);

            EntityCollection collection = this._organizationService.RetrieveMultiple(query);

            if (collection == null || collection.Entities.Count == 0)
                return new IndividualCustomerModel();

            var entity = collection.Entities[0];

            return AmxCoPSBActivities.Repository.Factory.IndividualCustomerFactory.CreateIndividualFrom(entity);
        }
    }
}
