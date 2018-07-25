using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPlugins
{
    public class IncidentResolverPlugincs : IPlugin
    {
        /// <summary>
        /// Excecute Method
        /// </summary>
        /// <param name="serviceProvider">serviceProvider</param>
        public void Execute(IServiceProvider serviceProvider)
        {
            try
            {
                // Context of the plugin
                IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = factory.CreateOrganizationService(context.UserId);

                Entity incidentResolution = (Entity)context.InputParameters["Target"];

                // Run plugin
                Run(service, incidentResolution);
            }
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException("Incident.Resolve: " + ex.Message);
            }
        }

        /// <summary>
        /// Method run
        /// </summary>
        /// <param name="service"></param>
        /// <param name="entIncidentRes"></param>
        public void Run(IOrganizationService service, Entity entIncidentRes)
        {
            //// From  incident
            //QueryExpression query = new QueryExpression("incident");

            //// Obtain columns of query
            //query.ColumnSet = new ColumnSet("statecode", "amx_state");

            //// WHERE same incident
            //query.Criteria = new FilterExpression();
            //query.Criteria.AddCondition("incidentid", ConditionOperator.Equal, entIncidentRes.Id);

            // Excecute query multiple
            Entity entityIncident = service.Retrieve("incident", entIncidentRes.Id, new ColumnSet("statecode", "amx_state"));
            //query.NoLock = true;
            //EntityCollection entityIncidentCollextion = service.RetrieveMultiple(query);
            //Entity entityIncident = entityIncidentCollextion.Entities.First();

            OptionSetValue state = (OptionSetValue)(entIncidentRes.Attributes["statecode"]);

            // Is case resolution
            if (state.Value.Equals(1))
            {
                Entity incidentModifier = new Entity(entityIncident.LogicalName);

                incidentModifier.Id = entityIncident.Id;
                incidentModifier.Attributes["amx_state"] = new EntityReference("amx_statecase", RetrieveStatusId(service, "statusResolved"));

                // Excecute method update in entity
                service.Update(incidentModifier);
            }
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
            // From
            QueryExpression query = new QueryExpression("amx_statecase");

            // Obtain columns of query
            query.ColumnSet = new ColumnSet("amx_name", "amx_code");

            // WHERE 
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("amx_code", ConditionOperator.Equal, RetrieveConfigValueAttribute(service, configAttribute));

            // Excecute query multiple
            query.NoLock = true;
            EntityCollection crmConfigurationItem = service.RetrieveMultiple(query);

            return Guid.Parse(crmConfigurationItem[0].Attributes["amx_statecaseid"].ToString());
        }
    }
}