using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Text;

namespace PI.Incident.NotifyAdvisor
{
    public class NotifyAdvisor : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            try
            {
                IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = factory.CreateOrganizationService(context.UserId);

                Entity incidentResolution = (Entity)context.InputParameters["Target"];
                Run(service, incidentResolution);
            }
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException(ex.Message);
            }
        }

        public void Run(IOrganizationService service, Entity entIncidentRes)
        {
            Guid incidentid = entIncidentRes.GetAttributeValue<EntityReference>("incidentid").Id;

            Entity Entincident = service.Retrieve("incident", incidentid, new ColumnSet("amx_ordercapture", "ownerid"));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Buen día," + Environment.NewLine);
            sb.AppendLine("Se realizo y cerro el caso correctamente. por favor comunicarse con el cliente para continuar con la venta: " + Environment.NewLine);

            if (Entincident.Contains("amx_ordercapture"))
            {
                string ordercap = Entincident.GetAttributeValue<EntityReference>("amx_ordercapture").Name;
                sb.AppendLine(ordercap);
            }

            Entity entTask = new Entity("task");
            entTask["regardingobjectid"] = new EntityReference("incident", incidentid);
            entTask["description"] = sb.ToString();
            entTask["ownerid"] = Entincident.GetAttributeValue<EntityReference>("ownerid");
            entTask["subject"] = "Notificación Caso Cerrado";

            service.Create(entTask);
        }
    }
}
