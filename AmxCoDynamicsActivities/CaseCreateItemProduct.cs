using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace AmxDynamicsActivities
{
    public class CaseCreateItemProduct : CodeActivity
    {
        [Input("Incident")]
        [ReferenceTarget("incident")]
        [RequiredArgument]
        public InArgument<EntityReference> InIncident { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(context.UserId);

            this.Run(service, InIncident.Get(executionContext));
        }

        public void Run(IOrganizationService service, EntityReference erIncident)
        {
            Entity eIncident = service.Retrieve(erIncident.LogicalName, erIncident.Id, new ColumnSet("amx_productsjson"));

            if (eIncident != null)
            {
                if (eIncident.Contains("amx_productsjson"))
                {
                    bool booGenerate = true;
                    string familiesInCase = string.Empty;
                    ListFamilies families = new ListFamilies();
                    families.lstFamilies = (List<Family>)convertJsonToObjeto(typeof(List<Family>), eIncident["amx_productsjson"].ToString());

                    foreach (Family fam in families.lstFamilies)
                    {
                        if (string.IsNullOrEmpty(fam.name.Trim()))
                        {
                            if (fam.products[0].poExternalId.Equals("NoAp") && fam.products[0].check)
                                booGenerate = false;
                        }
                    }

                    if (booGenerate)
                    {
                        QueryExpression query = new QueryExpression("amx_productsincase");
                        query.ColumnSet = new ColumnSet("amx_externalid");
                        query.Criteria.AddCondition("amx_case", ConditionOperator.Equal, erIncident.Id);
                        query.Orders.Add(new OrderExpression("amx_productfamily", OrderType.Ascending));

                        EntityCollection ecProducts = service.RetrieveMultiple(query);

                        if (ecProducts.Entities.Count > 0)
                        {
                            foreach (Entity eProdDel in ecProducts.Entities)
                            {
                                service.Delete(eProdDel.LogicalName, eProdDel.Id);
                            }
                        }

                        foreach (Family family in families.lstFamilies)
                        {
                            foreach (Product prod in family.products)
                            {
                                if (prod.check)
                                {
                                    Entity eProductNew = new Entity("amx_productsincase");
                                    eProductNew["amx_productfamily"] = prod.family;
                                    eProductNew["amx_product"] = prod.name;
                                    eProductNew["amx_name"] = prod.name;
                                    eProductNew["amx_externalid"] = prod.poExternalId;
                                    eProductNew["amx_case"] = erIncident;

                                    if (prod.poExternalId.Contains("Int"))
                                    {
                                        eProductNew["amx_businessname"] = new OptionSetValue(1);
                                    }
                                    else if (prod.poExternalId.Contains("Tv"))
                                    {
                                        eProductNew["amx_businessname"] = new OptionSetValue(1);
                                    }
                                    else if (prod.poExternalId.Contains("Tel"))
                                    {
                                        eProductNew["amx_businessname"] = new OptionSetValue(1);
                                    }
                                    else if (prod.poExternalId.Contains("Mov"))
                                    {
                                        eProductNew["amx_businessname"] = new OptionSetValue(2);
                                    }

                                    service.Create(eProductNew);

                                    if (string.IsNullOrEmpty(familiesInCase))
                                        familiesInCase = prod.family;
                                    else if (!familiesInCase.Contains(prod.family))
                                        familiesInCase = familiesInCase + "," + prod.family;
                                }
                            }
                        }

                        Entity incidentUpdate = new Entity(erIncident.LogicalName);
                        incidentUpdate.Id = erIncident.Id;
                        incidentUpdate["amx_productfamily"] = familiesInCase;

                        service.Update(incidentUpdate);
                    }
                }
            }
        }

        private Object convertJsonToObjeto(Type tipo, String json)
        {
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(tipo);
            Object objeto = dataContractJsonSerializer.ReadObject(new MemoryStream(Encoding.Default.GetBytes(json)));
            return objeto;
        }

        private string convertObjetoToJson(object objeto)
        {
            MemoryStream memoryStream = new MemoryStream();

            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(objeto.GetType());
            dataContractJsonSerializer.WriteObject(memoryStream, objeto);

            String json = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());

            return json;
        }
    }

    [DataContract]
    public class ListFamilies
    {
        [DataMember]
        public List<Family> lstFamilies { get; set; }
    }

    [DataContract]
    public class Family
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public bool check { get; set; }

        [DataMember]
        public List<Product> products { get; set; }
    }

    [DataContract]
    public class Product
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string family { get; set; }
        [DataMember]
        public string poExternalId { get; set; }
        [DataMember]
        public string srParentPoId { get; set; }
        [DataMember]
        public bool check { get; set; }
    }
}
