using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AMXCommon;

namespace AmxPeruPlugins.AMXColPlugins
{
    public class AMXContactPostCreatePlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {            
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {                
                Entity entity = (Entity)context.InputParameters["Target"];
                if (entity.LogicalName != "contact") return;

                IOrganizationServiceFactory orgServiceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService orgService = orgServiceFactory.CreateOrganizationService(context.UserId);
                try
                {
                    var individualCustomerBusiness = new AMXCommon.AMXIndividualCustomerBusiness();

                    individualCustomerBusiness.CreateCustomerContactInfo(context, entity, orgService);

                    individualCustomerBusiness.CreateBiHeader(context, entity, orgService);
                }

                catch (FaultException<OrganizationServiceFault> ex)
                {
                    throw new InvalidPluginExecutionException("An error occurred in Individual create plugin.", ex);
                }
                catch (Exception ex)
                {
                    tracingService.Trace("An error occurred in Individual create plugin: {0}", ex.ToString());
                    throw;
                }
            }
        }
    }
}
