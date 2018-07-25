using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPlugins
{
    public class PostUpdateTaskRegardingField : IPlugin
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

                if (_IPluginExecutionContext.Depth < 4 && _IPluginExecutionContext.InputParameters.Contains("Target") && _IPluginExecutionContext.InputParameters["Target"] is Entity)
                {
                    Entity target = (Entity)_IPluginExecutionContext.InputParameters["Target"];
                    // Entity _entity = (Entity)_IPluginExecutionContext.PostEntityImages["TaskPostImage"];
                    Entity _entity = _service.Retrieve(target.LogicalName, target.Id, new Microsoft.Xrm.Sdk.Query.ColumnSet("regardingobjectid"));
                    if (_entity.Contains("regardingobjectid") && ((EntityReference)_entity.Attributes["regardingobjectid"]).LogicalName == "incident")
                    {


                        Entity caseEntity = new Entity(((EntityReference)_entity.Attributes["regardingobjectid"]).LogicalName, ((EntityReference)_entity.Attributes["regardingobjectid"]).Id);
                        caseEntity["amxperu_associatedopentask"] = true;
                        _service.Update(caseEntity);

                    }
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
