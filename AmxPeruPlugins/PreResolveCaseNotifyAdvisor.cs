using AmxPeruPlugins.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Text;

namespace AmxPeruPlugins
{
    public class PreResolveCaseNotifyAdvisor : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            try
            {
                IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = factory.CreateOrganizationService(context.UserId);

                Entity incidentResolution = (Entity)context.InputParameters["Target"];
                Run(service, incidentResolution, context.UserId);
            }
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException(ex.Message);
            }
        }

        public void Run(IOrganizationService service, Entity entIncidentRes, Guid userId)
        {            
            Guid incidentid = entIncidentRes.GetAttributeValue<EntityReference>("incidentid").Id;

            Entity Entincident = service.Retrieve("incident", incidentid, new ColumnSet("amx_ordercapture", "ownerid", "amx_bimanagerwithcustomer"));

            TraslationManage objTraslate = new TraslationManage();
            EntityCollection ecTraslate = objTraslate.getTraslateFormMessage("IncidentCloseNotification", userId, service);
            string messageTask = string.Empty;
            string subjectTask = string.Empty;

            foreach (Entity eTras in ecTraslate.Entities)
            {
                if (eTras["etel_code"].ToString().Equals("MessageTask")) { messageTask = eTras["etel_message"].ToString(); }
                else if (eTras["etel_code"].ToString().Equals("SubjectTask")) { subjectTask = eTras["etel_message"].ToString(); }
            }

            if (Entincident.Contains("amx_ordercapture"))
            {
                string ordercap = Entincident.GetAttributeValue<EntityReference>("amx_ordercapture").Name;
                string.Format(messageTask, ordercap);
            }

            Entity entTask = new Entity("task");
            entTask["regardingobjectid"] = new EntityReference("incident", incidentid);
            entTask["description"] = messageTask;
            if(Entincident.Contains("amx_bimanagerwithcustomer")) entTask["ownerid"] = Entincident.GetAttributeValue<EntityReference>("amx_bimanagerwithcustomer");
            entTask["subject"] = subjectTask;

            service.Create(entTask);
        }
    }
}
