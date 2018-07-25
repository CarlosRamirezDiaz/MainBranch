using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPlugins
{
    public class PostCreateCustomerDocument : IPlugin
    {
        Entity _entity = null;
        ITracingService _ITracingService = null;
        IPluginExecutionContext _IPluginExecutionContext = null;
        IOrganizationServiceFactory _factory = null;
        IOrganizationService _service = null;

        public void Execute(IServiceProvider _provider)
        {
            //Extract the tracing service for use in plug-in debugging.
            try
            {
                _ITracingService = (ITracingService)_provider.GetService(typeof(ITracingService));
                _IPluginExecutionContext = (IPluginExecutionContext)_provider.GetService(typeof(IPluginExecutionContext));
                _factory = (IOrganizationServiceFactory)_provider.GetService(typeof(IOrganizationServiceFactory));
                _service = (IOrganizationService)_factory.CreateOrganizationService(_IPluginExecutionContext.UserId);

                if (_IPluginExecutionContext.Depth < 2 && _IPluginExecutionContext.InputParameters.Contains("Target") && _IPluginExecutionContext.InputParameters["Target"] is Entity)
                {
                    _entity = (Entity)_IPluginExecutionContext.InputParameters["Target"];

                    QueryExpression qe = new QueryExpression();
                    //Provide Configuration Entity Name 
                    qe.EntityName = "annotation";
                    qe.ColumnSet = new ColumnSet(new string[] { "filename", "documentbody" });
                    qe.Criteria.AddCondition("objectid", ConditionOperator.Equal, _entity.Id);

                    EntityCollection receiptNotesCallection = _service.RetrieveMultiple(qe);
                    if (receiptNotesCallection.Entities.Count > 0)
                    {
                        foreach (Entity receiptNote in receiptNotesCallection.Entities)
                        {
                            var remoteAddress = new System.ServiceModel.EndpointAddress("http://localhost:120/FileUpload.svc");

                            //using (var fileUploadService = new Service1Client(new System.ServiceModel.BasicHttpBinding(), remoteAddress))
                            //{
                            //    //set timeout
                            //    fileUploadService.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 0, 50);
                            //    string filePath = fileUploadService.UploadFile(receiptNote.Attributes["filename"].ToString(), receiptNote.Attributes["documentbody"].ToString());
                            //    _ITracingService.Trace("FilePath--" + filePath);
                            string filePath = "C:/CustomerDocument/" + receiptNote.Attributes["filename"].ToString();
                            Entity postEntityImage = (Entity)_IPluginExecutionContext.PostEntityImages["PostImage"];
                            postEntityImage["amxperu_filepath"] = filePath;
                            _service.Update(postEntityImage);

                            //}
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _ITracingService.Trace("Exception: {0}", e.ToString());
                throw;
            }


        }


    }
}
