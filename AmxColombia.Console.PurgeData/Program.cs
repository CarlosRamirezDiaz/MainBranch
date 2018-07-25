using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AmxColombia.Console.PurgeData
{
    class Program
    {
        static DateTime IndividualCreatedOnBefore;
        /// <summary>
        /// Standard Main() method used by most SDK samples.
        /// </summary>
        /// <param name="args"></param>
        static public void Main(string[] args)
        {
            var logger = new Logger("AmxColombia.Console.PurgeData");

            logger.Write("Start v01.02", true);
            var startTime = DateTime.Now;
            try
            {
                if (!ReadParameters(logger))
                {
                    return;
                }

                // Obtain connection configuration information for the Microsoft Dynamics
                // CRM organization web service.
                String connectionString = SimplifiedConnection.GetServiceConfiguration(logger);
                logger.Write(connectionString, true);
                logger.Write(string.Format("Delete Individuals created on and before date: {0}", IndividualCreatedOnBefore.ToString("yyyy/MM/dd")), true);

                if (connectionString != null)
                {
                    SimplifiedConnection app = new SimplifiedConnection();
                    var _orgService = app.Connect(connectionString);

                    var relations = new Dictionary<string, string>();
                    relations.Add("contact_etel_bi_logs", "etel_bi_log");
                    relations.Add("etel_contact_etel_bi_log", "etel_bi_log");
                    relations.Add("etel_individualcustomer_biheader", "etel_bi_header");
                    relations.Add("etel_contact_etel_creditprofile_individualid", "etel_creditprofile");
                    relations.Add("etel_contact_etel_customeraddress", "etel_customeraddress");
                    relations.Add("amx_contact_amx_evidentelog", "amx_evidentelog");
                    relations.Add("etel_contact_etel_appointmentlog_individualcustomerid", "etel_appointmentlog");
                    relations.Add("etel_contact_ordercapture_individualcustomerid", "etel_ordercapture");
                    relations.Add("etel_contact_ordercapture_sourceindividualcustomerid", "etel_ordercapture");
                    relations.Add("etel_contact_etel_ordercapture_targetindividualcustomerid", "etel_ordercapture");


                    RetrieveEntityRequest retrieveBankAccountEntityRequest = new RetrieveEntityRequest
                    {
                        EntityFilters = EntityFilters.Relationships,
                        LogicalName = "contact"
                    };
                    RetrieveEntityResponse retrieveBankAccountEntityResponse = (RetrieveEntityResponse)_orgService.Execute(retrieveBankAccountEntityRequest);

                    var oneToNRelationships = retrieveBankAccountEntityResponse.EntityMetadata.OneToManyRelationships;

                    foreach(var relationShip in oneToNRelationships)
                    {
                        if (relationShip.CascadeConfiguration.Delete != CascadeType.Restrict)
                            continue;

                        if (relationShip.ReferencingEntity == "contact")
                            continue;

                        if (!relations.ContainsKey(relationShip.ReferencedEntityNavigationPropertyName.ToLower()))
                            relations.Add(relationShip.ReferencedEntityNavigationPropertyName, relationShip.ReferencingEntity);
                    }

                    Purge("contact", IndividualCreatedOnBefore, relations, _orgService);
                }
            }

            catch (FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> ex)
            {
                logger.Write("The application terminated with an error.", true);
                logger.Write(string.Format("Timestamp: {0}", ex.Detail.Timestamp), true);
                logger.Write(string.Format("Code: {0}", ex.Detail.ErrorCode), true);
                logger.Write(string.Format("Message: {0}", ex.Detail.Message), true);
                logger.Write(string.Format("Trace: {0}", ex.Detail.TraceText), true);
                logger.Write(string.Format("Inner Fault: {0}",
                    null == ex.Detail.InnerFault ? "No Inner Fault" : "Has Inner Fault"), true);
            }
            catch (System.TimeoutException ex)
            {
                logger.Write(string.Format("The application terminated with an error."), true);
                logger.Write(string.Format("Message: {0}", ex.Message), true);
                logger.Write(string.Format("Stack Trace: {0}", ex.StackTrace), true);
                logger.Write(string.Format("Inner Fault: {0}", null == ex.InnerException.Message ? "No Inner Fault" : ex.InnerException.Message), true);
            }
            catch (System.Exception ex)
            {
                logger.Write(string.Format("The application terminated with an error."), true);
                logger.Write(string.Format(ex.Message), true);

                // Display the details of the inner exception.
                if (ex.InnerException != null)
                {
                    logger.Write(string.Format(ex.InnerException.Message), true);

                    FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault> fe = ex.InnerException
                        as FaultException<Microsoft.Xrm.Sdk.OrganizationServiceFault>;
                    if (fe != null)
                    {
                        logger.Write(string.Format("Timestamp: {0}", fe.Detail.Timestamp), true);
                        logger.Write(string.Format("Code: {0}", fe.Detail.ErrorCode), true);
                        logger.Write(string.Format("Message: {0}", fe.Detail.Message), true);
                        logger.Write(string.Format("Trace: {0}", fe.Detail.TraceText), true);
                        logger.Write(string.Format("Inner Fault: {0}", null == fe.Detail.InnerFault ? "No Inner Fault" : "Has Inner Fault"), true);
                    }
                }
            }

            // Additional exceptions to catch: SecurityTokenValidationException, ExpiredSecurityTokenException,
            // SecurityAccessDeniedException, MessageSecurityException, and SecurityNegotiationException.

            finally
            {
                logger.Write("", true);
                logger.Write("===========================================================", true);

                var durationTime = DateTime.Now.Subtract(startTime);
                logger.Write(string.Format("End Process. Time elapsed {0:00}:{1:00}:{2:00}", durationTime.Hours, durationTime.Minutes, durationTime.Seconds), true);
                logger.Write("Press <Enter> to exit.", true);
                System.Console.ReadLine();
            }
        }

        private static bool ReadParameters(Logger logger)
        {
            var sCreatedOnBefore = ConfigurationManager.AppSettings["IndividualCreatedOnAndBefore"];

            DateTime createdOnBefore = DateTime.Now.Date;
           if (!DateTime.TryParse(sCreatedOnBefore, new System.Globalization.CultureInfo("en-US"), System.Globalization.DateTimeStyles.AssumeLocal, out createdOnBefore))
            {
                logger.Write(string.Format("{0} {1}", sCreatedOnBefore, "error: IndividualCreatedOnAndBefore is not a date value."), true);
                return false;
            }
            IndividualCreatedOnBefore = createdOnBefore;
            return true;
        }
        private static void Purge(string entityName, DateTime createdOn, Dictionary<string, string> relations,  IOrganizationService _orgService)
        {
            var logger = new Logger("AmxColombia.Console.PurgeData");

            var query = new QueryExpression(entityName);
            query.ColumnSet.AddColumn("fullname");
            query.NoLock = true;

            query.Criteria.AddCondition("createdon", ConditionOperator.OnOrBefore, createdOn.Date);

            var collection = _orgService.RetrieveMultiple(query);

            foreach(var individual in collection.Entities)
            {
                if (individual.Contains("fullname"))
                    logger.Write(individual.GetAttributeValue<string>("fullname"), true);
                else
                    logger.Write(individual.GetAttributeValue<Guid>("contactid").ToString(), true);

                var request = new RetrieveRequest();
                request.ColumnSet = new ColumnSet(true);
                request.Target = new EntityReference("contact", individual.Id);
                request.RelatedEntitiesQuery = new RelationshipQueryCollection();

                foreach (var relation in relations)
                {
                    var RelatedQuery = new QueryExpression(relation.Value);
                    RelatedQuery.ColumnSet = new ColumnSet();
                    request.RelatedEntitiesQuery.Add(new Relationship(relation.Key), RelatedQuery);
                }

                var response = (RetrieveResponse)_orgService.Execute(request);

                foreach (var relatedEntity in response.Entity.RelatedEntities)
                {
                    logger.Write(string.Format(" {0} {1}", relatedEntity.Value.EntityName, relatedEntity.Value.Entities.Count), true);
                    foreach (var entity in relatedEntity.Value.Entities)
                    {
                        _orgService.Delete(entity.LogicalName, entity.Id);
                    }
                    //_orgService.Delete(relatedEntity)
                }
                logger.Write(string.Format(" Prepare to delete "), true);
                _orgService.Delete(individual.LogicalName, individual.Id);
            }
        }
    }
}
