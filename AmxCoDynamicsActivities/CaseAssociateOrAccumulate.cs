using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Linq;

namespace AmxDynamicsActivities
{
    public class CaseAssociateOrAccumulate : CodeActivity
    {
        [Input("Case")]
        [ReferenceTarget("incident")]
        [RequiredArgument]
        public InArgument<EntityReference> InIncident { get; set; }

        /// <summary>
        /// Exceute method
        /// </summary>
        /// <param name="executionContext"></param>
        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            this.Run(service, InIncident.Get(executionContext));
        }

        public void Run(IOrganizationService service, EntityReference erIncident)
        {
            // Get object current Incident 
            Entity eIncident = service.Retrieve(erIncident.LogicalName, erIncident.Id, new ColumnSet(true));

            // Variables acces
            bool booValidateAccomulationCase = false;
            bool booValidateAssociationCase = false;
            bool booValidateMatrixCase = false;

            // List of products for business
            List<EntityCollection> lstProductsByBN = new List<EntityCollection>();

            EntityCollection ecProductsInCase = new EntityCollection();

            // Update products x family
            EntityCollection _newProdsxFam = new EntityCollection();
            StringBuilder familyText = new StringBuilder();

            // Family List
            List<EntityCollection> lstProductXFamily;

            // Item not selection business
            int intBackBN = 0;
            int intCountBusinessName = 0;

            LinkEntity leProducts = new LinkEntity();
            EntityCollection ecProductsBN = null;

            EntityCollection ecIncidents = new EntityCollection();

            // Group list of families
            List<string> familyGroup = new List<string>();

            // Get incident
            if (eIncident != null)
            {
                Entity eIncidentUpdate = new Entity(erIncident.LogicalName);
                eIncidentUpdate.Id = erIncident.Id;

                // From incident
                QueryExpression query = new QueryExpression(erIncident.LogicalName);

                lstProductXFamily = new List<EntityCollection>();

                // Contain individuals
                if (eIncident.Contains("customerid"))
                {
                    #region Get Products

                    // From amx_productsincase
                    QueryExpression queryProducts = new QueryExpression("amx_productsincase");

                    // Select "amx_productsincaseid", "amx_businessname"
                    queryProducts.ColumnSet = new ColumnSet("amx_productsincaseid", "amx_businessname", "amx_case", "amx_product", "amx_contracttype", "amx_selected", "amx_partnerproduct", "amx_name", "amx_productfamily", "amx_externalid");

                    // Where "amx_case" = case in progress
                    queryProducts.Criteria.AddCondition("amx_case", ConditionOperator.Equal, erIncident.Id);

                    // product register is active
                    queryProducts.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);

                    // Order By "amx_businessname" ASC
                    queryProducts.Orders.Add(new OrderExpression("amx_businessname", OrderType.Ascending));

                    // Excecute query
                    ecProductsInCase = service.RetrieveMultiple(queryProducts);

                    #region Group of Families

                    // Get Family element
                    foreach (Entity familyElement in ecProductsInCase.Entities)//int i = 0; i < ecProductsInCase.Entities.Count; i++)
                    {
                        if (!familyGroup.Contains(familyElement["amx_productfamily"].ToString()))
                        {
                            familyGroup.Add(familyElement["amx_productfamily"].ToString());
                        }
                    }

                    // Is multiPlay case
                    if (familyGroup.Count > 1)
                        eIncidentUpdate["amx_multiplay"] = true;
                    else
                        eIncidentUpdate["amx_multiplay"] = false;

                    #endregion

                    #endregion

                    #region Acomulation Query

                    // Accomulation case
                    if (eIncident.Contains("amxperu_casecategory")
                        && eIncident.Contains("amxperu_casesubcategory")
                        && eIncident.Contains("amxperu_casesubsubcategory")
                        && ecProductsInCase.Entities.Count > 0
                        && !(bool)eIncidentUpdate["amx_multiplay"]
                        && !eIncident.Contains("amx_resource"))
                    {
                        //// From
                        //QueryExpression query = new QueryExpression(erIncident.LogicalName);
                        // Select
                        query.ColumnSet = new ColumnSet("incidentid", "amx_caselevel");
                        // Filters
                        // Active Case
                        query.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
                        // Level Case mpt equal I y III
                        query.Criteria.AddCondition("amx_caselevel", ConditionOperator.Equal, 2);
                        // The same individual of context 
                        query.Criteria.AddCondition("customerid", ConditionOperator.Equal, ((EntityReference)eIncident["customerid"]).Id);
                        // The same parameter
                        query.Criteria.AddCondition("amxperu_casecategory", ConditionOperator.Equal, ((EntityReference)eIncident["amxperu_casecategory"]).Id);
                        query.Criteria.AddCondition("amxperu_casesubcategory", ConditionOperator.Equal, ((EntityReference)eIncident["amxperu_casesubcategory"]).Id);
                        query.Criteria.AddCondition("amxperu_casesubsubcategory", ConditionOperator.Equal, ((EntityReference)eIncident["amxperu_casesubsubcategory"]).Id);
                        query.Criteria.AddCondition("createdon", ConditionOperator.LastXDays, Convert.ToInt32(RetrieveConfigValueAttribute(service, "maxSLAAccumulation")));
                        query.Criteria.AddCondition("incidentid", ConditionOperator.NotEqual, erIncident.Id);

                        query.Orders.Add(new OrderExpression("amx_caselevel", OrderType.Descending));

                        // Inner Join amx_productsincase with incident
                        leProducts = new LinkEntity(erIncident.LogicalName, "amx_productsincase", "incidentid", "amx_case", JoinOperator.Inner);
                        leProducts.Columns = new ColumnSet("amx_businessname", "amx_case", "amx_product", "amx_partnerproduct", "amx_name", "amx_productfamily");
                        leProducts.LinkCriteria.FilterOperator = LogicalOperator.Or;

                        // Where Join for amx_productfamily  
                        leProducts.LinkCriteria.AddCondition("amx_productfamily", ConditionOperator.Equal, familyGroup[0]);

                        // Join link
                        query.LinkEntities.Add(leProducts);

                        ecIncidents = service.RetrieveMultiple(query);

                        if (ecIncidents.Entities.Count > 0)
                            booValidateAccomulationCase = true;
                    }

                    #endregion

                    #region Association Query

                    // Valide contain idividual and tipe process Association
                    if (!booValidateAccomulationCase
                        && ecProductsInCase.Entities.Count > 0)
                    {
                        intBackBN = 0;
                        query = new QueryExpression("incident");
                        // From incident
                        //QueryExpression query = new QueryExpression(erIncident.LogicalName);
                        // Select "incidentid", "amx_caselevel", "amx_caseid"
                        query.ColumnSet = new ColumnSet("incidentid", "amx_caselevel", "amx_caseid", "amx_productfamily", "amx_cun");

                        // Where
                        // Active Case
                        query.Criteria.AddCondition("statecode", ConditionOperator.Equal, 0);
                        // Level Case mpt equal III
                        query.Criteria.AddCondition("amx_caselevel", ConditionOperator.NotEqual, 3);
                        // The same individual of context 
                        query.Criteria.AddCondition("customerid", ConditionOperator.Equal, ((EntityReference)eIncident["customerid"]).Id);
                        // No same incident number
                        query.Criteria.AddCondition("incidentid", ConditionOperator.NotEqual, erIncident.Id);
                        // TODO: create new case multiplay
                                                
                        // Order By case level
                        query.Orders.Add(new OrderExpression("amx_caselevel", OrderType.Ascending));

                        // Inner Join amx_productsincase with incident
                        leProducts = new LinkEntity(erIncident.LogicalName, "amx_productsincase", "incidentid", "amx_case", JoinOperator.Inner);
                        leProducts.Columns = new ColumnSet("amx_businessname");
                        leProducts.LinkCriteria.FilterOperator = LogicalOperator.Or;

                        // Go through the product to get the business
                        foreach (Entity eBusinessName in ecProductsInCase.Entities)
                        {
                            if (eBusinessName.Contains("amx_businessname"))
                            {
                                // Business selection in product
                                int currentBN = ((OptionSetValue)eBusinessName["amx_businessname"]).Value;
                                // Valide not selection
                                if (currentBN != intBackBN)
                                {
                                    // Where Join for amx_businessname  
                                    leProducts.LinkCriteria.AddCondition("amx_businessname", ConditionOperator.Equal, currentBN);
                                    intCountBusinessName = intCountBusinessName + 1;
                                    intBackBN = currentBN;

                                    // valide business of in products
                                    if (ecProductsBN != null) lstProductsByBN.Add(ecProductsBN);
                                    ecProductsBN = new EntityCollection();
                                    ecProductsBN.Entities.Add(eBusinessName);
                                }
                                else
                                {
                                    // Add business found in the products
                                    ecProductsBN.Entities.Add(eBusinessName);
                                }
                            }
                        }

                        // null business products
                        if (ecProductsBN != null) lstProductsByBN.Add(ecProductsBN);

                        // Join link
                        query.LinkEntities.Add(leProducts);

                        ecIncidents = service.RetrieveMultiple(query);

                        if (ecIncidents.Entities.Count > 0
                        && !(bool)eIncidentUpdate["amx_multiplay"]
                        && !eIncident.Contains("amx_resource"))
                            booValidateAssociationCase = true;
                        else
                            booValidateMatrixCase = true;
                    }

                    #endregion 

                    #region Accomulation

                    // If same typing of case - Accomulation
                    if (booValidateAccomulationCase
                        && ecIncidents.Entities.Count > 0)
                    {
                        Entity eCurrentIncident = ecIncidents.Entities[0];
                        //eIncidentUpdate["parentcaseid"] = new EntityReference(eCurrentIncident.LogicalName, eCurrentIncident.Id);
                        eIncidentUpdate["amxperu_associatedcase"] = new EntityReference(eCurrentIncident.LogicalName, eCurrentIncident.Id);
                        // Assing same product family
                        eIncidentUpdate["amx_productfamily"] = ((Microsoft.Xrm.Sdk.AliasedValue)(ecIncidents.Entities[0]["amx_productsincase1.amx_productfamily"])).Value;
                        // Assing same business name
                        eIncidentUpdate["amx_businessname"] = ecIncidents[0].FormattedValues["amx_productsincase1.amx_businessname"];
                        // Assing state accumulation
                        eIncidentUpdate["amx_state"] = new EntityReference("amx_statecase", RetrieveStatusId(service, "statusAccumulation"));
                        // Inherit cun from father
                        if(ecIncidents.Entities[0].Contains("amx_cun")) eIncidentUpdate["amx_cun"] = ecIncidents.Entities[0]["amx_cun"];

                        int intLevel = ((OptionSetValue)eCurrentIncident["amx_caselevel"]).Value;

                        if (intLevel == 1)
                            eIncidentUpdate["amx_caselevel"] = new OptionSetValue(2);
                        else if (intLevel == 2)
                            eIncidentUpdate["amx_caselevel"] = new OptionSetValue(3);

                        // Accomulate case
                        booValidateAccomulationCase = true;
                    }

                    #endregion

                    #region Association

                    else if (booValidateAssociationCase)
                    {
                        // Incident with same business and Bi header
                        if (ecIncidents.Entities.Count > 0 && ((EntityReference)ecIncidents.Entities[0]["amx_caseid"]).Id.Equals(((EntityReference)eIncident["amx_caseid"]).Id))
                        {
                            // Case level I - Matriz associate
                            Entity eCurrentIncident = ecIncidents.Entities[0];
                            //eIncidentUpdate["parentcaseid"] = new EntityReference(eCurrentIncident.LogicalName, eCurrentIncident.Id);
                            eIncidentUpdate["amxperu_associatedcase"] = new EntityReference(eCurrentIncident.LogicalName, eCurrentIncident.Id);
                            // Assing same family
                            eIncidentUpdate["amx_productfamily"] = ecIncidents.Entities[ecIncidents.Entities.Count - 1]["amx_productfamily"];
                            // Assing same business name
                            eIncidentUpdate["amx_businessname"] = ecIncidents[ecIncidents.Entities.Count - 1].FormattedValues["amx_productsincase1.amx_businessname"];
                            //Assign Cun
                            if(ecIncidents.Entities[ecIncidents.Entities.Count - 1].Contains("amx_cun")) eIncidentUpdate["amx_cun"] = ecIncidents.Entities[ecIncidents.Entities.Count - 1]["amx_cun"]; 

                            // Contain case level
                            if (eCurrentIncident.Contains("amx_caselevel"))
                            {
                                // Case Level of case Matrix 
                                int intLevel = ((OptionSetValue)eCurrentIncident["amx_caselevel"]).Value;
                                // Set level associate
                                if (intLevel == 1 || intLevel == 2)
                                {
                                    eIncidentUpdate["amx_caselevel"] = new OptionSetValue(2);
                                }

                                booValidateAssociationCase = true;
                            }
                        }
                    }
                    #endregion

                    #region Case Matriz

                    if (booValidateMatrixCase || (bool)eIncidentUpdate["amx_multiplay"] || eIncident.Contains("amx_resource"))
                    {
                        // Start product family 
                        string families = string.Empty;
                        // Contain family assigned
                        if (eIncident.Contains("amx_productfamily"))
                            families = eIncident["amx_productfamily"].ToString();

                        // Go Through Business Name for create subcase
                        foreach (EntityCollection prod in lstProductsByBN)// int posChild = 0; posChild < lstProductsByBN.Count; posChild++)
                        {
                            // Create subIncident
                            Entity eSubIncident = new Entity(erIncident.LogicalName);

                            lstProductXFamily = new List<EntityCollection>();

                            // Clone entity
                            EntityClone(eIncident, out eSubIncident);

                            // Set level case I a matriz case
                            eIncidentUpdate["amx_caselevel"] = new OptionSetValue(1);

                            // Set subcase level
                            eSubIncident["parentcaseid"] = new EntityReference(erIncident.LogicalName, erIncident.Id);
                            //eSubIncident["amxperu_associatedcase"] = new EntityReference(erIncident.LogicalName, erIncident.Id);
                            
                            // Update products x family
                            _newProdsxFam = GenerateCasesFamilies(prod, out lstProductXFamily);

                            // Set family x subcase
                            familyText = new StringBuilder();

                            // Go through families an set products in JSON
                            foreach (Entity family in _newProdsxFam.Entities)
                            {
                                eSubIncident["amx_businessname"] = family.FormattedValues["amx_businessname"];
                                eSubIncident["amx_caselevel"] = new OptionSetValue(2);

                                string familiesInCase = string.Empty;
                                ListFamilies _families = new ListFamilies();
                                _families.lstFamilies = (List<Family>)convertJsonToObject(typeof(List<Family>), eIncident["amx_productsjson"].ToString());

                                familyText.Append(family["amx_productfamily"].ToString());
                                familyText.Append("|");

                                foreach (Family familyJSON in _families.lstFamilies)
                                {
                                    foreach (Product prodJSON in familyJSON.products.FindAll(x => !x.family.Equals(family["amx_productfamily"].ToString())))
                                    {
                                        prodJSON.check = false;
                                    }
                                }

                                eSubIncident["amx_productfamily"] = familyText.Remove(familyText.Length - 1, 1).ToString();
                                eSubIncident["amx_productsjson"] = convertObjectToJson(_families.lstFamilies);

                                Guid guidSubIncident = service.Create(eSubIncident);

                                Entity incidentFix = new Entity("incident");
                                incidentFix.Id = guidSubIncident;
                                incidentFix["amx_resource"] = null;

                                service.Update(incidentFix);
                            }
                        }
                    }

                    #endregion

                    #region Evaluate status pending for files

                    if (eIncident.Contains("amx_caselevel") && ((OptionSetValue)eIncidentUpdate["amx_caselevel"]).Value.Equals(1))
                    {
                        if (eIncident.Contains("amx_requiresupport") && (bool)eIncident["amx_requiresupport"])
                        {
                            QueryExpression queryDocuments = new QueryExpression("amx_documentspercase");

                            queryDocuments.ColumnSet = new ColumnSet("amx_documentspercaseid", "amx_caseid");
                            queryDocuments.NoLock = true;
                            queryDocuments.Criteria = new FilterExpression();
                            queryDocuments.Criteria.AddCondition("amx_caseid", ConditionOperator.Equal, "{" + erIncident?.Id.ToString()?.ToUpper() + "}");
                            EntityCollection documentsCollection = service.RetrieveMultiple(queryDocuments);

                            if (documentsCollection.Entities.Any())
                            {
                                eIncidentUpdate["amx_hasfile"] = true;
                            }
                        }
                    }

                    #endregion

                    service.Update(eIncidentUpdate);
                }
            }
        }

        #region Utilities
        
        /// <summary>
        /// Method that clones an entity
        /// </summary>
        /// <param name="entityOrigin">Entity Origin</param>
        /// <param name="entityClone">Entity Clone</param>
        private void EntityClone(Entity entityOrigin, out Entity entityClone)
        {
            // Entity process
            Entity entityProcess = new Entity(entityOrigin.LogicalName);

            // Assing attibute to new subcase
            foreach (var key in entityOrigin.Attributes)
            {
                if (!key.Key.Equals("amx_caselevel") && !key.Key.Equals("parentcaseid") && !key.Key.Equals("incidentid")
                    && !key.Key.Equals("amxperu_associatedcase") && !key.Key.Equals("createdon") && !key.Key.Equals("amx_multiplay")
                    && !key.Key.Equals("amx_productfamily") && !key.Key.Equals("amx_cungenerated") && !key.Key.Equals("amx_cun"))
                {
                    entityProcess.Attributes.Add(key.Key, key.Value);
                }
            }

            entityClone = entityProcess;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstProdByBN"></param>
        /// <param name="posChild"></param>
        /// <param name="lstProductXFamily"></param>
        /// <param name="newProdsxFam"></param>
        private EntityCollection GenerateCasesFamilies(EntityCollection ProdByBN, out List<EntityCollection> lstProductXFamily)
        {
            EntityCollection productFamily = new EntityCollection();

            // List products x Family
            List<EntityCollection> lstProductXFamilyOut = new List<EntityCollection>();
            EntityCollection newProdsxFamOut = null;

            // Current family selected
            string currentFamily = string.Empty;

            // Crear subcasos por familia
            EntityCollection ecPrd = ProdByBN;

            // Go through products
            foreach (Entity pr in ecPrd.Entities)
            {
                if (currentFamily != "" && !currentFamily.Equals(pr["amx_productfamily"].ToString()))
                {
                    newProdsxFamOut.Entities.Add(pr);
                }
                else
                {
                    if (newProdsxFamOut != null)
                        lstProductXFamilyOut.Add(newProdsxFamOut);

                    newProdsxFamOut = new EntityCollection();
                    newProdsxFamOut.Entities.Add(pr);
                    currentFamily = pr["amx_productfamily"].ToString();
                }
            }

            if (newProdsxFamOut != null)
            {
                if (newProdsxFamOut.Entities.Count > 0)
                {
                    lstProductXFamilyOut.Add(newProdsxFamOut);
                }
            }

            // Assign listProducts of Family
            lstProductXFamily = lstProductXFamilyOut;

            // Products x Family
            return newProdsxFamOut;
        }

        /// <summary>
        /// Get configuration value
        /// </summary>
        /// <param name="service"></param>
        /// <param name="configAttribute"></param>
        /// <returns>Query value</returns>
        private static string RetrieveConfigValueAttribute(IOrganizationService service, string configAttribute)
        {
            QueryExpression query = new QueryExpression("etel_crmconfiguration");

            // Obtain columns of query
            query.ColumnSet = new ColumnSet("etel_name", "etel_value");

            // WHERE 
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("etel_name", ConditionOperator.Equal, configAttribute);

            // Excecute query multiple
            EntityCollection crmConfigurationItem = service.RetrieveMultiple(query);

            return crmConfigurationItem[0].Attributes["etel_value"].ToString();
        }

        /// <summary>
        /// Get Guid Status
        /// </summary>
        /// <param name="service"></param>
        /// <param name="configAttribute"></param>
        /// <returns></returns>
        private static Guid RetrieveStatusId(IOrganizationService service, string configAttribute)
        {
            QueryExpression query = new QueryExpression("amx_statecase");

            // Obtain columns of query
            query.ColumnSet = new ColumnSet("amx_name", "amx_code");

            // WHERE 
            query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("amx_code", ConditionOperator.Equal, RetrieveConfigValueAttribute(service, configAttribute));

            // Excecute query multiple
            EntityCollection crmConfigurationItem = service.RetrieveMultiple(query);

            return Guid.Parse(crmConfigurationItem[0].Attributes["amx_statecaseid"].ToString());
        }

        private Object convertJsonToObject(Type type, String json)
        {
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(type);
            Object objeto = dataContractJsonSerializer.ReadObject(new MemoryStream(Encoding.Default.GetBytes(json)));
            return objeto;
        }

        private string convertObjectToJson(object objectJSON)
        {
            MemoryStream memoryStream = new MemoryStream();

            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(objectJSON.GetType());
            dataContractJsonSerializer.WriteObject(memoryStream, objectJSON);

            String json = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());

            return json;
        }

        #endregion
    }
}