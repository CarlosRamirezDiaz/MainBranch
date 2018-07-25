using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPlugins
{
    public class PostCreateCaseAutomaticRouting : IPlugin
    {
        #region [Execute Method]
        public void Execute(IServiceProvider serviceProvider)
        {
            try
            {
                ITracingService _ITracingService = null;
                IPluginExecutionContext _IPluginExecutionContext = null;
                IOrganizationServiceFactory _factory = null;
                IOrganizationService _service = null;

                _ITracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
                _IPluginExecutionContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                _factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                _service = (IOrganizationService)_factory.CreateOrganizationService(_IPluginExecutionContext.UserId);
                if (_IPluginExecutionContext.InputParameters.Contains("Target") && _IPluginExecutionContext.InputParameters["Target"] is Entity)
                {

                    Entity targetEntityReference = (Entity)_IPluginExecutionContext.InputParameters["Target"];

                    ApplyRoutingRuleRequest routingRuleRequest = new ApplyRoutingRuleRequest();
                    routingRuleRequest.Target = new EntityReference(targetEntityReference.LogicalName, targetEntityReference.Id);
                    _service.Execute(routingRuleRequest);
                }

            }
            catch (InvalidPluginExecutionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
