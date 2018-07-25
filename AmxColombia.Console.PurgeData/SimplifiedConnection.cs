using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;

namespace AmxColombia.Console.PurgeData
{
    /// <summary>
    /// This sample uses the CrmConnection class found in the Microsoft.Xrm.Client
    /// namespace to connect to and authenticate with the organization web service.
    /// 
    /// Next, the sample demonstrates how to do basic entity operations like create,
    /// retrieve, update, and delete.</summary>
    /// <remarks>
    /// At run-time, you will be given the option to delete all the database
    /// records created by this program.
    /// 
    /// No helper code from CrmServiceHelpers.cs is used in this sample.</remarks>
    /// <see cref="http://msdn.microsoft.com/en-us/library/gg695810.aspx"/>
    public class SimplifiedConnection
    {
        #region Class Level Members

        private IOrganizationService _orgService;

        #endregion Class Level Members

        /// <summary>
        /// The Run() method first connects to the Organization service. Afterwards,
        /// basic create, retrieve, update, and delete entity operations are performed.
        /// </summary>
        /// <param name="connectionString">Provides service connection information.</param>
        /// <param name="promptforDelete">When True, the user will be prompted to delete all
        /// created entities.</param>
        public IOrganizationService Connect(String connectionString)
        {
            try
            {
                // Connect to the CRM web service using a connection string.
                CrmServiceClient conn = new Microsoft.Xrm.Tooling.Connector.CrmServiceClient(connectionString);

                if (!conn.IsReady)
                {
                    System.Console.WriteLine("Error: {0}", conn.LastCrmError);
                    return null;
                }

                // Cast the proxy client to the IOrganizationService interface.
                _orgService = (IOrganizationService)conn.OrganizationWebProxyClient != null ? (IOrganizationService)conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;
                
                // Obtain information about the logged on user from the web service.
                Guid userid = ((WhoAmIResponse)_orgService.Execute(new WhoAmIRequest())).UserId;
                Entity systemUser = _orgService.Retrieve("systemuser", userid, new ColumnSet(new string[] { "firstname", "lastname" }));
                System.Console.WriteLine("Logged on user is {0} {1}.", systemUser.GetAttributeValue<string>("firstname"), systemUser.GetAttributeValue<string>("lastname"));

                // Retrieve the version of Microsoft Dynamics CRM.
                RetrieveVersionRequest versionRequest = new RetrieveVersionRequest();
                RetrieveVersionResponse versionResponse =
                    (RetrieveVersionResponse)_orgService.Execute(versionRequest);
                System.Console.WriteLine("Microsoft Dynamics CRM version {0}.", versionResponse.Version);
            }

            // Catch any service fault exceptions that Microsoft Dynamics CRM throws.
            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>)
            {
                // You can handle an exception here or pass it back to the calling method.
                throw;
            }

            return _orgService;
        }

        #region Private Methods

        /// <summary>
        /// Gets web service connection information from the app.config file.
        /// If there is more than one available, the user is prompted to select
        /// the desired connection configuration by name.
        /// </summary>
        /// <returns>A string containing web service connection configuration information.</returns>
        public static String GetServiceConfiguration(Logger logger)
        {
            // Get available connection strings from app.config.
            int count = ConfigurationManager.ConnectionStrings.Count;

            // Create a filter list of connection strings so that we have a list of valid
            // connection strings for Microsoft Dynamics CRM only.
            List<KeyValuePair<String, String>> filteredConnectionStrings =
                new List<KeyValuePair<String, String>>();

            for (int a = 0; a < count; a++)
            {
                if (isValidConnectionString(ConfigurationManager.ConnectionStrings[a].ConnectionString))
                    filteredConnectionStrings.Add
                        (new KeyValuePair<string, string>
                            (ConfigurationManager.ConnectionStrings[a].Name,
                            ConfigurationManager.ConnectionStrings[a].ConnectionString));
            }

            // No valid connections strings found. Write out and error message.
            if (filteredConnectionStrings.Count == 0)
            {
                System.Console.WriteLine("An app.config file containing at least one valid Microsoft Dynamics CRM " +
                    "connection string configuration must exist in the run-time folder.");
                System.Console.WriteLine("\nThere are several commented out example connection strings in " +
                    "the provided app.config file. Uncomment one of them and modify the string according " +
                    "to your Microsoft Dynamics CRM installation. Then re-run the sample.");
                return null;
            }

            // If one valid connection string is found, use that.
            if (filteredConnectionStrings.Count == 1)
            {
                return filteredConnectionStrings[0].Value;
            }

            // If more than one valid connection string is found, let the user decide which to use.
            if (filteredConnectionStrings.Count > 1)
            {
                logger.Write("The following connections are available:", true);
                logger.Write("------------------------------------------------", true);

                for (int i = 0; i < filteredConnectionStrings.Count; i++)
                {
                    logger.Write(string.Format("\n({0}) {1}\t", i + 1, filteredConnectionStrings[i].Key), true);
                }

                logger.Write("", true);

                logger.Write(string.Format("\nType the number of the connection to use (1-{0}) [{0}] : ", filteredConnectionStrings.Count), true);

                String input = System.Console.ReadLine();
                int configNumber;
                if (input == String.Empty) input = filteredConnectionStrings.Count.ToString();
                if (!Int32.TryParse(input, out configNumber) || configNumber > count ||
                    configNumber == 0)
                {
                    logger.Write("Option not valid.", true);
                    return null;
                }

                return filteredConnectionStrings[configNumber - 1].Value;

            }
            return null;
        }


        /// <summary>
        /// Verifies if a connection string is valid for Microsoft Dynamics CRM.
        /// </summary>
        /// <returns>True for a valid string, otherwise False.</returns>
        private static Boolean isValidConnectionString(String connectionString)
        {
            // At a minimum, a connection string must contain one of these arguments.
            if (connectionString.Contains("Url=") ||
                connectionString.Contains("Server=") ||
                connectionString.Contains("ServiceUri="))
                return true;

            return false;
        }

        #endregion Private Methods
    }
}
