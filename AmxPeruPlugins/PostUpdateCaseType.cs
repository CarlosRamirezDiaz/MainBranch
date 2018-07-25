using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPlugins
{
    public class PostUpdateCaseType : IPlugin
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
                    Entity _entity = (Entity)_IPluginExecutionContext.InputParameters["Target"];
                    // Entity _entity = _service.Retrieve(target.LogicalName, target.Id, new Microsoft.Xrm.Sdk.Query.ColumnSet("regardingobjectid"));
                    if (_entity.Contains("amxperu_casetype") && ((EntityReference)_entity.Attributes["amxperu_casetype"]).LogicalName == "amxperu_casetype")
                    {
                        Entity caseType = _service.Retrieve(((EntityReference)_entity.Attributes["amxperu_casetype"]).LogicalName, ((EntityReference)_entity.Attributes["amxperu_casetype"]).Id, new ColumnSet("amxperu_casesubject"));

                        if (caseType.Contains("amxperu_casesubject"))
                        {
                            Entity postImage = new Entity(_entity.LogicalName, _entity.Id);// (Entity)_IPluginExecutionContext.PostEntityImages["CaseImage"];
                            postImage["subjectid"] = (EntityReference)(caseType.Attributes["amxperu_casesubject"]);
                            _service.Update(postImage);
                        }


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
