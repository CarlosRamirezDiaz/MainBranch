using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPlugins
{
    public class IncidentWithCompleteAnswer : IPlugin
    {

        /// <summary>
        /// Method Executer of custom activity
        /// </summary>
        /// <param name="executionContext">Context custom activity</param>
        public void Execute(IServiceProvider serviceProvider)
        {
            try
            {
                // Initialize Target Entity reference
                Entity entity = null;

                // Workflow Context
                IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = factory.CreateOrganizationService(context.UserId);

                // The InputParameters collection contains all the data passed in the message request.
                if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
                {
                    // Obtain the target entity from the input parameters.
                    entity = (Entity)context.InputParameters["Target"];

                    // Plan B
                    // RetrieveTargetEntity(service, context);
                    Run(service, entity);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException("Incident.WithComplete: " +  ex.Message);
            }
        }

        /// <summary>
        /// IncidentWithCompleteAnswer - run Method
        /// </summary>
        /// <param name="service">Services Organization context</param>
        /// <param name="erIncident"></param>
        /// <returns>Validation "With Response" all subcases</returns>
        public void Run(IOrganizationService service, Entity entity)
        {
            // Value of validation to Return
            bool result = true;            

            // Get statusWithAnswercode
            string statusWithAnswer = RetrieveConfigValueAttribute(service, "statusWithAnswer");

            //// From  incident
            //QueryExpression query = new QueryExpression("incident");

            //// Obtain columns of query
            //query.ColumnSet = new ColumnSet("statecode", "amx_state", "parentcaseid");

            //// WHERE same incident
            //query.Criteria = new FilterExpression();
            //query.Criteria.AddCondition("incidentid", ConditionOperator.Equal, entity.Id);

            // Excecute query multiple
            Entity entityIncident = service.Retrieve("incident", entity.Id, new ColumnSet("statecode", "amx_state", "parentcaseid"));
            //query.NoLock = true;
            //EntityCollection entityIncidentCollextion = service.RetrieveMultiple(query);
            //Entity entityIncident = entityIncidentCollextion.Entities.First();

            // Contain parent
            if (entityIncident.Contains("parentcaseid"))
            {
                // Get parent case id of reference incident
                Guid parentId = entityIncident.GetAttributeValue<EntityReference>("parentcaseid").Id;

                // Validate that parentcaseid contains data
                if (parentId != null)
                {
                    //---------------------------//
                    // Query - Get case of parent
                    //---------------------------//

                    // FROM "incident"
                    QueryExpression query2 = new QueryExpression("incident");

                    // Obtain columns of query
                    // SELECT "parentcaseid", "amx_state", "amx_substate", "statecode", "statuscode", "ticketnumber", "amx_code"
                    query2.ColumnSet = new ColumnSet("ticketnumber", "parentcaseid", "amx_state", "statecode", "statuscode");

                    // INNER JOIN amx_statecase incidentState ON (amx_state = amx_statecaseId)
                    LinkEntity link = query2.AddLink("amx_statecase", "amx_state", "amx_statecaseid", JoinOperator.Inner);
                    link.Columns.AddColumn("amx_code");
                    link.EntityAlias = "incidentState";

                    // WHERE parentcaseid = <parentId>
                    query2.Criteria = new FilterExpression();
                    query2.Criteria.AddCondition("incident", "parentcaseid", ConditionOperator.Equal, parentId);

                    // Excecute query multiple
                    query2.NoLock = true;
                    EntityCollection subIncidents = service.RetrieveMultiple(query2);

                    // return data in query
                    if (subIncidents.Entities.Count > 0)
                    {
                        // Go through all the elements of the query to process them, "with response"
                        foreach (var incident in subIncidents.Entities)
                        {
                            result &= ((Microsoft.Xrm.Sdk.AliasedValue)incident.Attributes["incidentState.amx_code"]).Value.Equals(statusWithAnswer);
                        }

                        // Validate if all sub-cases are in the status "With an Answer" 
                        if (result)
                        {
                            // Get Entity of parent
                            Entity parentContext = RetrieveEntity(service, "incident", "incidentid", parentId);

                            Entity parentModify = new Entity(parentContext.LogicalName);

                            parentModify.Id = parentContext.Id;

                            Guid StatusID = RetrieveStatusId(service, "statusClosedEscalations");

                            //TODO: Question
                            // Set amx_state of parent
                            parentModify["amx_state"] = new EntityReference("amx_statecase", StatusID);

                            // Excecute method update in entity
                            service.Update(parentModify);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method that Retrieve Target Entity
        /// </summary>
        /// <param name="service">IOrganizationService</param>
        /// <param name="context">IWorkflowContext</param>
        /// <returns>Entity of context</returns>
        private static Entity RetrieveTargetEntityContext(IOrganizationService service, IPluginExecutionContext context)
        {
            // From  incident
            QueryExpression query = new QueryExpression(context.PrimaryEntityName);

            // Obtain columns of query
            query.ColumnSet = new ColumnSet(true);

            // WHERE same incident
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("incidentid", ConditionOperator.Equal, context.PrimaryEntityId);

            // Excecute query multiple
            //Entity entityIncident = service.Retrieve("incident", entity.Id, new ColumnSet("statecode", "amx_state", "parentcaseid"));
            query.NoLock = true;
            EntityCollection entityIncidentCollextion = service.RetrieveMultiple(query);
            Entity entityIncident = entityIncidentCollextion.Entities.First();

            return entityIncident;
        }


        /// <summary>
        /// Method that Retrieve entity from Guid
        /// </summary>
        /// <param name="service">IOrganizationService</param>
        /// <param name="entityName">Entity name</param>
        /// <param name="entityId">Entity name</param>
        /// <returns>Consulted entity</returns>
        private static Entity RetrieveEntity(IOrganizationService service, string entityName, string key, Guid entityId)
        {
            // From  amx_statecase
            QueryExpression query = new QueryExpression(entityName);

            // Obtain columns of query
            query.ColumnSet = new ColumnSet(true);

            // WHERE same id
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition(key, ConditionOperator.Equal, entityId);

            // Not lock query
            query.NoLock = true;

            // Return excecute query
            return service.RetrieveMultiple(query).Entities.First(); //service.Retrieve(entityName, entityId, new ColumnSet(true));
        }

        private static string RetrieveConfigValueAttribute(IOrganizationService service, string configAttribute)
        {
            QueryExpression query = new QueryExpression("etel_crmconfiguration");

            // Obtain columns of query
            query.ColumnSet = new ColumnSet("etel_name", "etel_value");

            // WHERE 
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_name", ConditionOperator.Equal, configAttribute);

            // Excecute query multiple
            EntityCollection crmConfigurationItem = service.RetrieveMultiple(query);

            return crmConfigurationItem[0].Attributes["etel_value"].ToString();
        }

        /// <summary>
        /// Get Guid Status
        /// </summary>
        /// <param name="service"></param>
        /// <param name="configAttribute"></param>
        /// <returns></returns>
        private static Guid RetrieveStatusId(IOrganizationService service, string configAttribute)
        {
            QueryExpression query = new QueryExpression("amx_statecase");

            // Obtain columns of query
            query.ColumnSet = new ColumnSet("amx_name", "amx_code");

            // WHERE 
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("amx_code", ConditionOperator.Equal, RetrieveConfigValueAttribute(service, configAttribute));

            // Excecute query multiple
            EntityCollection crmConfigurationItem = service.RetrieveMultiple(query);

            return Guid.Parse(crmConfigurationItem[0].Attributes["amx_statecaseid"].ToString());
        }
    }
}