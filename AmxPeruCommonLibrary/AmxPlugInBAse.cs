using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruCommonLibrary
{
    using System;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.Linq;
    using Microsoft.Xrm.Sdk;
    using Ericsson.ETELCRM.CrmFoundationLibrary.Business;
    using Ericsson.ETELCRM.CrmFoundationLibrary.Integration;
    using Ericsson.ETELCRM.Business;
    using Ericsson.ETELCRM.Integration.PerformanceCounter;
    using Ericsson.ETELCRM.CrmFoundationLibrary.Exceptions.BaseExceptions;
    using System.ServiceModel;
    using Ericsson.ETELCRM.CrmFoundationLibrary.ServiceClient.Entities;
    using Ericsson.ETELCRM.Integration.Logging;
    using Ericsson.ETELCRM.CrmFoundationLibrary.UtilitiesLibrary;
    using Ericsson.ETELCRM.CrmFoundationLibrary;
    using Ericsson.ETELCRM.CrmFoundationLibrary.Exceptions;

    /// <summary>
    /// Base class for MS CRM Plugins
    /// </summary>
    /// <typeparam name="T">Action class name</typeparam>    
    public abstract class AmxPlugInBase<T> : IPlugin
        where T : IBusinessBase
    {
        private const string ErrorPrefix = "[PluginContext]-";
        private string _secureConfig = null;
        private string _unsecureConfig = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="PlugInBase{T}"/> class.
        /// </summary>
        // ReSharper disable once PublicConstructorInAbstractClass
        public AmxPlugInBase()
        {
            ServicePointManager.ServerCertificateValidationCallback = IgnoreCertificateErrorHandler;
        }

        public AmxPlugInBase(string unsecureConfig, string secureConfig)
        {
            ServicePointManager.ServerCertificateValidationCallback = IgnoreCertificateErrorHandler;
            _secureConfig = secureConfig;
            _unsecureConfig = unsecureConfig;
        }

        /// <summary>
        /// Certification callback check
        /// </summary>
        /// <param name="sender">certificate sender</param>
        /// <param name="certificate">certificate instance</param>
        /// <param name="chain">certificate chain</param>
        /// <param name="errors">certificate policy errors</param>
        /// <returns>Invalidates security errors</returns>
        public static bool IgnoreCertificateErrorHandler(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        /// <summary>
        /// External api users should not trigger some plugins, 
        /// Added this control as a virtual 
        /// override on plugins which shouldnt be work.
        /// </summary>
        /// <param name="actionContext">
        /// The action context.
        /// </param>
        protected virtual bool IsNotExternalAPIUser(IActionContext actionContext, string organizationName)
        {
            actionContext.TracingService.Trace("InitiatingUserId : " + actionContext.Context.InitiatingUserId + ", UserId : " + actionContext.Context.UserId);

            bool result = actionContext.Resolve<ISystemUserBusiness>().IsExistInExternalAPIUsers(actionContext.Context.InitiatingUserId, organizationName);
            if (result)
                return false;

            return true;
        }

        /// <summary>
        /// Plugin's execute method invokes activity invoker class's invoke method        
        /// </summary>
        /// <param name="serviceProvider">MS CRM Service Provider</param>
        /// <exception cref="InvalidPluginExecutionException">Throws if the plugin execution is failed.</exception>        
        public void Execute(IServiceProvider serviceProvider)
        {

           

            IPluginExecutionContext context;
            var pluginFullName = typeof(T).FullName;

            ITracingService tracingService;
            IOrganizationServiceFactory organizationServiceFactory;
            using (new PerformanceTracker(string.Format("Preparing the action execution for '{0}'", pluginFullName)))
            {
                context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
                //if this plugIn is RefreshCacheManager PlugIn and this entity is not a cacheable entity then return
                if (typeof(T) == typeof(IRefreshCacheManager))
                {
                    if (!string.IsNullOrWhiteSpace(_unsecureConfig))
                    {
                        var _separator = ",";
                        var cacheableEntiyNames = _unsecureConfig.ToLower().Split(_separator.ToCharArray()).ToList();
                        string[] AcceptedMessagesCrUD = new string[] { "Create", "Update", "Delete" };
                        if (AcceptedMessagesCrUD.Contains(context.MessageName))
                        {
                            if (!cacheableEntiyNames.Contains(context.PrimaryEntityName))
                            {
                                throw new Exception("PlugInBase Exception 1");
                                return;
                            }
                        }
                    }
                }
                organizationServiceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            }

            var actionContext = BusinessInitializer.BuildPlugInContext(context, organizationServiceFactory, tracingService, serviceProvider);

            actionContext.TracingService.Trace("InitiatingUserId : " + actionContext.Context.InitiatingUserId + ", UserId : " + actionContext.Context.UserId);

            if (!IsNotExternalAPIUser(actionContext, context.OrganizationName))
            {
                throw new Exception("PlugInBase Exception 2");
                return;
            }

            try
            {
                if (!this.OnBeforeActionExecution(actionContext))
                {
                    throw new Exception("PlugInBase Exception 3");
                    return;
                }

                using (new PerformanceTracker(string.Format("Initializing the action '{0}'", pluginFullName)))
                {
                    throw new Exception("PlugInBase Exception 4");
                    this.OnActionExecution(actionContext);
                }

                this.AfterActionExecution(actionContext);
            }
            catch (ExceptionBase customException)
            {
                throw new InvalidPluginExecutionException(
                    LogError(actionContext, customException, serviceProvider),
                    customException);
            }
            catch (FaultException<BILException> bilException)
            {
                var error = actionContext.Resolve<ILogger>().GetExceptionBaseDataForBIL(actionContext, (bilException as FaultException<BILException>).Detail, bilException.Message);
                string errorText = LogError(actionContext, error, serviceProvider);
                throw new InvalidPluginExecutionException(errorText, bilException);
            }
            catch (RestClientFaultException bilException)
            {
                var error = actionContext.Resolve<ILogger>().GetExceptionBaseDataForBIL(actionContext, (bilException as RestClientFaultException).RestClientFault, bilException.Message);
                string errorText = LogError(actionContext, error, serviceProvider);
                throw new InvalidPluginExecutionException(errorText, bilException);
            }
            catch (FaultException orgServiceFault)
            {
                CoreException coreException = actionContext.Resolve<ILogger>().GetExceptionBaseData(orgServiceFault);

                string errorText = LogError(actionContext, coreException, serviceProvider);
                throw new InvalidPluginExecutionException(errorText, orgServiceFault);
            }
            catch (InvalidPluginExecutionException)
            {
                throw;
            }
            catch (EndpointNotFoundException e)
            {
                string errorCode = TranslationConstants.err_99010;
                var serviceError = new CriticalUserLevelException(errorCode, e);
                serviceError.ErrorCode = errorCode;

                string errorText = LogError(actionContext, serviceError, serviceProvider);
                throw new InvalidPluginExecutionException(errorText, e);
            }
            catch (Exception unknownException)
            {
                CoreException coreException = actionContext.Resolve<ILogger>().GetExceptionBaseData(unknownException);
                throw new InvalidPluginExecutionException(LogError(actionContext, coreException, serviceProvider), coreException);
            }
            finally
            {
                actionContext.Pop();
            }
        }

        /// <summary>
        /// The after action execution.
        /// </summary>
        /// <param name="actionContext">
        /// The action context.
        /// </param>
        // ReSharper disable once VirtualMemberNeverOverriden.Global
        protected virtual void AfterActionExecution(IActionContext actionContext)
        {
        }

        /// <summary>
        /// The on action execution.
        /// </summary>
        /// <param name="actionContext">
        /// The action context.
        /// </param>
        // ReSharper disable once VirtualMemberNeverOverriden.Global
        protected virtual void OnActionExecution(IActionContext actionContext)
        {
            BusinessProcessInvoker.Invoke<T>(actionContext);
        }

        /// <summary>
        /// The on before action execution.
        /// </summary>
        /// <param name="actionContext">
        /// The action context.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        // ReSharper disable once VirtualMemberNeverOverriden.Global
        protected virtual bool OnBeforeActionExecution(IActionContext actionContext)
        {
            return true;
        }

        /// <summary>
        /// Logs Error
        /// </summary>
        /// <param name="actionContext">Action context</param>
        /// <param name="customException">Exception base object</param>
        /// <param name="serviceProvider">service provider</param>
        /// <returns>Logged error message</returns>
        private string LogError(IActionContext actionContext, ExceptionBase customException, IServiceProvider serviceProvider)
        {
            return string.Concat(ErrorPrefix, actionContext.Resolve<ILogger>().Log(actionContext, customException, ExceptionContextDetail.CreatePlugInInfo(serviceProvider, actionContext)));
        }
    }
}
