using AmxPeruPSBActivities.Model;
using AmxPeruPSBActivities.Model.AffiliateDisaffiliate;
using AmxPeruPSBActivities.Model.Case;
using AmxPeruPSBActivities.Model.Individual;
using AmxPeruPSBActivities.Model.Task;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;
using System.Web.Script;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using AmxCoPSBActivities.Model.Evidente;
using AmxCoPSBActivities.ModelClaroESB.Bureau;
using System.Activities;
using AmxCoPSBActivities.ModelClaroESB.Evidente;
using AmxCoPSBActivities.Model.TorreDeControl;
using AmxPeruPSBWorkflows;
using AmxSoapServicesWorkflows;
using AmxSoapServicesActivities.ContractsSearchService;


namespace AmxPeruPSBTest
{
    [TestClass]
    public class AmxCoClaroESBTest
    {
        private Newtonsoft.Json.Formatting jsonSerializerSettings;

        [TestMethod]
        public void CustomerBiographicTest()
        {
            var input = new Dictionary<string, object>()
            {
               
               { "individualCustomerId", "099B11B1-A5C0-E711-80E5-FA163E10DFBE"} //Hector Antonio Gutierrez
               //{ "individualCustomerId", "EF7B50FB-D3CE-E711-80E6-FA163E10DFBE" } // Claudia Betzabe : Active
               //{ "individualCustomerId", "4AC58F57-A6C0-E711-80E5-FA163E10DFBE" } // Anderson Isamu : Active
               //{ "individualCustomerId", "EF7B50FB-D3CE-E711-80E6-FA163E10DFBE" }
            };

            try
            {
                /*var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.ClaroESB.CustomerBiographic>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();*/



                /*foreach (KeyValuePair<string, Object> item in result)
                {
                    var parameter = item.Key;
                    var parameter2 = item.Value;
                }*/
            }
            catch (Exception ex)
            {


            }

            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }


        [TestMethod]
        public void BSCSContractsSearchTest()
        {

            var input = new Dictionary<string, object>()
            {
               
               //{ "individualCustomerId", "099B11B1-A5C0-E711-80E5-FA163E10DFBE"} //Hector Antonio Gutierrez
               //{ "individualCustomerId", "EF7B50FB-D3CE-E711-80E6-FA163E10DFBE" } // Claudia Betzabe : Active
               //{ "individualCustomerId", "4AC58F57-A6C0-E711-80E5-FA163E10DFBE" } // Anderson Isamu : Active
               //{ "individualCustomerId", "EF7B50FB-D3CE-E711-80E6-FA163E10DFBE" }
               { "individualCustomerId", "F67197E7-F0AD-E711-80E2-FA163E105D63" }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxSoapServicesWorkflows.ContractsSearchById>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();

                foreach (KeyValuePair<string, Object> item in result)
                {
                    var parameter = item.Key;
                    var parameter2 = item.Value;
                }
            }
            catch (Exception ex)
            {
                
            }


            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void TorreDeControl()
        {
            var request = new AmxCoTorreDeControlRequest();
            request.typeCostumer = "{1CD7DC0F-B9B5-E711-80E4-FA163E106136}"; //Anderson Arakaki
            request.pushType = "SINGLE";

            var test1 = new List<AmxCoTorreDeControlRequest.AmxCoMessageBoxInt>();
            test1.Add(new AmxCoTorreDeControlRequest.AmxCoMessageBoxInt { customerId = "123456789", customerBox = "11111" });
            //test1.Add(new AmxCoTorreDeControlRequest.AmxCoMessageBoxInt { customerId = "987654321", customerBox = "22222" });
            var test2 = new List<AmxCoTorreDeControlRequest.AmxCoMessageBoxInt>();
            test2.Add(new AmxCoTorreDeControlRequest.AmxCoMessageBoxInt { customerId = "123456789", customerBox = "helder@ericsson.com" });
           // test2.Add(new AmxCoTorreDeControlRequest.AmxCoMessageBoxInt { customerId = "matsui@ericsson.com", customerBox = "test 2" });

            request.messageBox = new List<AmxCoTorreDeControlRequest.AmxCoMessageBoxExt>();
            request.messageBox.Add(new AmxCoTorreDeControlRequest.AmxCoMessageBoxExt() { messageChannel = "SMS", messageBox = test1 });
            request.messageBox.Add(new AmxCoTorreDeControlRequest.AmxCoMessageBoxExt() { messageChannel = "SMTP", messageBox = test2 });
            request.profileId = new List<string> { "SMTP_FS_TCRM1", "SMS_FS_TCRM1" };
            request.communicationType = new List<string> { "REGULATORIO" };
            request.communicationOrigin = "TCRM";
            request.deliveryReceipts = "NO";
            request.contentType = "MESSAGE";
            request.messageContent = "La Fecha de Agenda y Franja Horaria de la Orden de Trabajo No. {{etel_appointmentlog:amx_appointmentnumber}} ha sido cancelada.Yo Usuario Responsable de esta Accion, Certifico que esta cancelacion se ha realizado mediante acuerdo con el suscriptor el cual ha sido debidamente informado.Todos lo Hacemos Posible........Tu Lo Haces Posible.....Somos Claro.";

            var input = new Dictionary<string, object>()
            {
                { "request", request }
            };
            var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
            var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);
            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.ClaroESB.AmxCoTorreDeControl>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();
            }
            catch (Exception ex)
            { }

            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void GetCustomerProductFromSRTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "uri", "http://localhost:57005/eoc/sr/v1/product/?relatedParties.reference=CUST9000000001&relatedParties.role=Customer" } 
            };

            try
            {
                /*var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AmxCoGetCustomerProductsFromSR>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();*/
            }
            catch (Exception ex)
            { }

            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void UpdateListFlowTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "individualCustomerId", "099B11B1-A5C0-E711-80E5-FA163E10DFBE" },  //Hector Antonio Gutierrez
                { "orderId", "95471953-DEE4-E711-80E9-FA163E10DFBE" },
                { "idReason", "248" }
            };

            //Dictionary<string, object> parameters = new Dictionary<string, object>();
            //parameters.Add("individualCustomerId", "099B11B1-A5C0-E711-80E5-FA163E10DFBE");
            //parameters.Add("list", "CLIENTE");
            //parameters.Add("idReason", "22");

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.ClaroESB.AmxCoUpdateList>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();
            }
            catch (Exception ex)
            { }

            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void GetInfoListsFlowTest()
        {
            var input = new Dictionary<string, object>()
            {
                //{ "individualCustomerId", "099B11B1-A5C0-E711-80E5-FA163E10DFBE"} //Hector Antonio Gutierrez
                //{ "individualCustomerId", "4AC58F57-A6C0-E711-80E5-FA163E10DFBE" } // Anderson Isamu : Active
                //{ "individualCustomerId", "EF7B50FB-D3CE-E711-80E6-FA163E10DFBE" } // Claudia Betzabe : Active
                //{ "individualCustomerId", "5E41E6B6-F4BF-E711-80E5-FA163E10DFBE" }
                //{ "individualCustomerId", "5E41E6B6-F4BF-E711-80E5-FA163E10DFBE" }
                { "individualCustomerId", "00AAC8A7-000E-E811-80ED-FA163E10DFBE" }

            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.ClaroESB.AmxCoGetInfoLists>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();

                var res = result.Values;

            }
            catch (Exception ex)
            { }

            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
                        
        }

        [TestMethod]
        public void BureauTest()
        {
            var input = new Dictionary<string, object>()
            {
               
               //{ "individualCustomerId", "099B11B1-A5C0-E711-80E5-FA163E10DFBE"} //Hector Antonio Gutierrez
               //{ "individualCustomerId", "EF7B50FB-D3CE-E711-80E6-FA163E10DFBE" } // Claudia Betzabe : Active
               { "individualCustomerId", "4AC58F57-A6C0-E711-80E5-FA163E10DFBE" } // Anderson Isamu : Active
                , { "uri", "http://localhost:57005/eoc/sr/v1/product/?relatedParties.reference=CUST9000000001&relatedParties.role=Customer" }
               //{ "individualCustomerId", "EF7B50FB-D3CE-E711-80E6-FA163E10DFBE" }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.ClaroESB.AmxCoBureau>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();



                foreach (KeyValuePair<string, Object> item in result)
                {
                    var parameter = item.Key;
                    var parameter2 = item.Value;
                }
            }
            catch (Exception ex)
            {
                

            }

           // string cupo = 

            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void GetBureauTestFlow()
        {

            //var BureauBusiness = new AmxCoPSBActivities.BusinessClaroESB.AmxCoBureauBusiness();
            DateTime datadehoje = new DateTime(123890);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("documentType", 1);
            parameters.Add("documentNumber", "666");
            parameters.Add("issueDate", datadehoje);
            parameters.Add("lastName", "Matsui");
            parameters.Add("bureauURL", "http://localhost:58002/Bureau/V1.0/Rest/GetBureau");
             //Activity workflow1 = new AmxPeruPSBWorkflows.ClaroESB.AmxCoBureau();
             //var result = WorkflowInvoker.Invoke(workflow1, parameters);
             //string greeting = (string)result["response"];

             /*var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.ClaroESB.AmxCoBureau>(parameters)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();*/


            //int documentType = 1;
            //string documentNumber = "666";
            //DateTime issueDate = new DateTime(1999, 6, 1);
            //string lastName = "GUITERREZ";

            //var response = BureauBusiness.GetBureau("http://localhost:8089/Bureau/V1.0/Rest/GetBureau", documentType, 
            //    documentNumber, issueDate, lastName);


            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void GetQuestionnaireTest()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();
            var evidenteBusiness = new AmxCoPSBActivities.BusinessClaroESB.AmxCoEvidenteBusiness(_org);

            var request = new AmxCoGetQuestionnaireRequest();
            //request.ContactId = new Guid("60ECE394-2BC0-E711-80E5-FA163E10DFBE"); //Sandoval
            //request.ContactId = new Guid("{1CD7DC0F-B9B5-E711-80E4-FA163E106136}"); //Anderson Arakaki
            //request.ContactId = new Guid("{E058D51E-1917-E811-80ED-FA163E10DFBE}"); //ARANDA MONTES JENYFER ALEJANDRA
            //request.ContactId = new Guid("{D11085EA-D717-E811-80ED-FA163E10DFBE}"); //SANCHEZ - 1012432653
            request.ContactId = new Guid("{FED27126-DB17-E811-80ED-FA163E10DFBE}"); //OSPINA - 52797983
            
            request.codeQuestionnaire = "7060";

            var evidenteURL = "http://localhost:8002/Evident/V1.0/Rest/GetQuestionnaire";

            try
            {
                var response = evidenteBusiness.GetQuestionnaire(request, evidenteURL);
            }
            catch (Exception ex)
            { }

            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void EvaluateQuestionnaireTest()
        {
            var _org = OrganizationProxy.GetOrganizationProxy();

            var evidenteBusiness = new AmxCoPSBActivities.BusinessClaroESB.AmxCoEvidenteBusiness(_org);

            var request = new AmxCoEvaluateQuestionnaireRequest();
            request.codeQuestionnaire = "7060";
            request.questionnaireSequence = "13599312";
            request.identificationNumber = "1064434718";
            request.codeIdentificationType = "1";
            request.answers = new List<AmxCoEvaluateQuestionnaireAnswer>();

            request.answers.Add(new AmxCoEvaluateQuestionnaireAnswer() { sequenceQuestion = 5, sequenceAnswer = 4135609 });
            request.answers.Add(new AmxCoEvaluateQuestionnaireAnswer() { sequenceQuestion = 49, sequenceAnswer = 4135614 });
            request.answers.Add(new AmxCoEvaluateQuestionnaireAnswer() { sequenceQuestion = 90, sequenceAnswer = 4135619 });
            request.answers.Add(new AmxCoEvaluateQuestionnaireAnswer() { sequenceQuestion = 1, sequenceAnswer = 4135605 });
            request.answers.Add(new AmxCoEvaluateQuestionnaireAnswer() { sequenceQuestion = 38, sequenceAnswer = 4135613 });

            var evidenteURL = "http://localhost:8002/Evident/V1.0/Rest/EvaluateQuestionnaire";

            try
            {
                var response = evidenteBusiness.EvaluateQuestionnaire(request, evidenteURL, Guid.Empty, Guid.Empty);
            }
            catch (Exception ex)
            { }

            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void EvidenteEvaluateQuestionnaireFlowTest()
        {
            var request = new AmxCoEvaluateQuestionnaireRequest();
            request.codeQuestionnaire = "7060";
            request.questionnaireSequence = "13599312";
            request.identificationNumber = "1064434718";
            request.codeIdentificationType = "1";
            request.answers = new List<AmxCoEvaluateQuestionnaireAnswer>();

            request.answers.Add(new AmxCoEvaluateQuestionnaireAnswer() { sequenceQuestion = 5, sequenceAnswer = 4135609 });
            request.answers.Add(new AmxCoEvaluateQuestionnaireAnswer() { sequenceQuestion = 49, sequenceAnswer = 4135614 });
            request.answers.Add(new AmxCoEvaluateQuestionnaireAnswer() { sequenceQuestion = 90, sequenceAnswer = 4135619 });
            request.answers.Add(new AmxCoEvaluateQuestionnaireAnswer() { sequenceQuestion = 1, sequenceAnswer = 4135605 });
            request.answers.Add(new AmxCoEvaluateQuestionnaireAnswer() { sequenceQuestion = 38, sequenceAnswer = 4135613 });

            var input = new Dictionary<string, object>()
            {
                { "request", request }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.ClaroESB.AmxCoEvidenteEvaluateQuestionnaire>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();
            }
            catch (Exception ex)
            { }

            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void EvidenteGetQuestionnaireFlowTest()
        {
            var input = new Dictionary<string, object>()
            {
                { "request",
                    new AmxCoGetQuestionnaireRequest
                    {
                        //ContactId = new Guid("60ECE394-2BC0-E711-80E5-FA163E10DFBE") //Sandoval
                        ContactId = new Guid("{1CD7DC0F-B9B5-E711-80E4-FA163E106136}") //Anderson Arakaki
                    }
                }
            };
            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.ClaroESB.AmxCoEvidenteGetQuestionnaire>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();
            }
            catch (Exception ex)
            { }

            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void SarglaftConsultListBusinessTest()
        {
            var sarglaftBusiness = new AmxCoPSBActivities.BusinessClaroESB.AmxCoSarglaftBusiness();

            var ClaroESB_Sarglaft_ConsultLists_Endpoint = @"http://localhost:8002/ListsSarglaft/V1.0/Rest/ConsultLists";
            //var fullName = "Cesar Battisti";
            //var fullName = "chapo guzman";
            var ponctuation = 95;
            var customerId = "E058D51E-1917-E811-80ED-FA163E10DFBE";
            var fullName = "MARIA ARANDA MONTES";
            //{ "FullName":"MARIA ARANDA MONTES","IndividualCustomerId":"{E058D51E-1917-E811-80ED-FA163E10DFBE}"}

            var _org = OrganizationProxy.GetOrganizationProxy();

            try
            {
                var response = sarglaftBusiness.ConsultLists(ClaroESB_Sarglaft_ConsultLists_Endpoint, fullName, customerId, ponctuation, _org);
            }
            catch (Exception ex)
            { }

            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void SarglaftConsultListFlowTest()
        {
            //var input = new Dictionary<string, object>()
            //{
            //    { "FullName", "chapo guzman" },
            //    { "Punctuation", 95},
            //    { "IndividualCustomerId", "8E4CA788-52B0-E711-80E3-FA163E106136" }
            //};

            var input = new Dictionary<string, object>()
            {
                { "FullName", "MARIA ARANDA MONTES" },
                { "Punctuation", 95},
                { "IndividualCustomerId", "E058D51E-1917-E811-80ED-FA163E10DFBE" }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.ClaroESB.AmxCoSarglaftConsultLists>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();
            }
            catch (Exception ex)
            { }

            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }

        [TestMethod]
        public void SarglaftConsultListActivityTest()
        {
            //var input = new Dictionary<string, object>()
            //{
            //    { "FullName", "chapo guzman" },
            //    { "Punctuation", 95},
            //    { "IndividualCustomerId", "8E4CA788-52B0-E711-80E3-FA163E106136" }
            //};

            var input = new Dictionary<string, object>()
            {
                { "FullName", "MARIA ARANDA MONTES" },
                { "Punctuation", 95},
                { "IndividualCustomerId", "E058D51E-1917-E811-80ED-FA163E10DFBE" }
            };

            try
            {
                var result = WorkflowHelper.PrepareFor<AmxCoPSBActivities.ActivitiesClaroESB.AmxCoSarglaft>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .ConfigureXrmDataContext()
                        .Invoke();
            }
            catch (Exception ex)
            { }

            // wait for recording logs
            var waittask = Task.Delay(5 * 1000);
            Task.WaitAll(new Task[] { waittask });
        }
    }
}
