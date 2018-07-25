using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Threading.Tasks;
using AmxCoPSBActivities.ModelClaroESB.Listas;
using Newtonsoft.Json;
using AmxPeruPSBActivities.Repository;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using AmxPeruPSBActivities.Model.CreditProfile;
using AmxPeruPSBActivities.Service.SendNotification;
using AmxPeruPSBActivities.Model.OrderCapture;
using AmxPeruPSBActivities.Model.User;
using AmxPeruPSBActivities.Model.Listas;
using Microsoft.Xrm.Sdk;
using System.Web.Script.Serialization;

namespace AmxCoPSBActivities.BusinessClaroESB
{

    public class AmxCoListasBusiness
    {
        #region Variables
        private string fetchContactCustomerInfo = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                      <entity name='amx_customercontactinformation'>
                                                        <attribute name='amx_customercontactinformationid' />
                                                        <attribute name='amx_name' />
                                                        <attribute name='createdon' />
                                                        <attribute name='amx_contacttype' />
                                                        <attribute name='amx_primarycontacttype' />
                                                        <attribute name='amx_phoneno' />
                                                        <attribute name='amx_individualcustomerid' />
                                                        <attribute name='amx_email' />
                                                        <attribute name='amx_contactinformation' />
                                                        <order attribute='amx_name' descending='false' />
                                                        <filter type='and'>
                                                          <condition attribute='amx_individualcustomerid' operator='eq' value='{0}' />
                                                        </filter>
                                                      </entity>
                                                    </fetch>";

        #endregion

        #region Public methods
        /// <summary>
        /// Retrieve the Listas
        /// </summary>
        /// <param name="listasURL"></param>
        /// <param name="individualCustomerId"></param>
        /// <param name="_org"></param>
        /// <returns></returns>
        public AmxCoGetListsResponse GetListas(string listasURL, Guid individualCustomerId, OrganizationServiceProxy _org)
        {
            var response = new AmxCoGetListsResponse();
            string Lista = "NINGUNA"; string docType = ""; string areaCode; string telephone = string.Empty; string email = string.Empty; string primaryEmail = string.Empty; string primaryFixed = string.Empty; string primaryMobile = string.Empty;
            string jsonRequest = string.Empty; string jsonResponse = string.Empty; string error = string.Empty;
            // eheldma: Retrieve customer's information to send to Listas
            var individualRepository = new IndividualCustomerRepository(_org);
            var individual = individualRepository.GetById(individualCustomerId);
            if (individual.IndividualCustomerId == Guid.Empty)
                throw new Exception("Individual Customer not found for Id: " + individualCustomerId);

            var common = new AmxCoPSBActivities.BusinessClaroESB.AmxCoClaroESBCommon(_org);
            var customerContactInfoEntityColl = _org.RetrieveMultiple(new FetchExpression(string.Format(fetchContactCustomerInfo, individualCustomerId.ToString())));
            foreach (var ent in customerContactInfoEntityColl.Entities)
            {
                if (ent.Contains("amx_email") && Convert.ToBoolean(ent["amx_primarycontacttype"]) && ((OptionSetValue)ent["amx_contacttype"]).Value == 173800000) { primaryEmail = ent["amx_email"].ToString(); }
                else if (ent.Contains("amx_email") && ((OptionSetValue)ent["amx_contacttype"]).Value == 173800000) { email = ent["amx_email"].ToString(); }

                if (ent.Contains("amx_phoneno") && Convert.ToBoolean(ent["amx_primarycontacttype"]) && ((OptionSetValue)ent["amx_contacttype"]).Value == 173800002) { primaryFixed = ent["amx_phoneno"].ToString(); }
                else if (ent.Contains("amx_phoneno") && ((OptionSetValue)ent["amx_contacttype"]).Value == 173800002) { telephone = ent["amx_phoneno"].ToString(); }

                if (ent.Contains("amx_phoneno") && Convert.ToBoolean(ent["amx_primarycontacttype"]) && ((OptionSetValue)ent["amx_contacttype"]).Value == 173800001) { primaryMobile  = ent["amx_phoneno"].ToString(); }
                else if (ent.Contains("amx_phoneno") && ((OptionSetValue)ent["amx_contacttype"]).Value == 173800001) { telephone = ent["amx_phoneno"].ToString(); }
            }
            email = !string.IsNullOrEmpty(primaryEmail) ? primaryEmail : email;
            telephone = !string.IsNullOrEmpty(primaryFixed) ? primaryFixed : !string.IsNullOrEmpty(primaryMobile) ? primaryMobile : telephone;

            // Get document type
            docType = GetDocumentType(individual);
            //var request = GetInfoListsRequest.GetListasRequestFactory("PRESENCIAL", "VENTA", docType, individual.DocumentNumber, areaCode, telephone, email);
            var request = new GetInfoListsRequest
            {
                channel = "PRESENCIAL",
                typeProcess = "VENTA",
                document = new Document { typeDocument = docType, numberDocument = individual.DocumentNumber },
                phone = new Phone { areaCode = "57", phone = telephone },
                mail = email,
            };           
            if (!common.RestCall<GetInfoListsRequest>(listasURL, request, out jsonRequest, out jsonResponse, out error))
            {
                response.Success = false;
                response.Error = error;
                return response;
            }
            var getInfoListsResponse = JsonConvert.DeserializeObject<ModelClaroESB.Listas.GetInfoListsResponse>(jsonResponse);
            #region Update Customer with List Info
            Entity Customer = new Entity("contact", individual.IndividualCustomerId);
            Boolean customerInListaClientes = false; Boolean customerInListaTelefonos = false; Boolean customerInListaCorreos = false;
            for (int i = 0; i <= 2; i++)
            {
                if (getInfoListsResponse.infoList[i].lists == null)
                { }
                else
                {
                    if (getInfoListsResponse.infoList[i].lists.list == "CLIENTES")
                    {
                        Customer.Attributes.Add("amx_listasinternas_clientesreason", getInfoListsResponse.infoList[i].lists.reason);
                        Customer.Attributes.Add("amx_listasinternas_clientesaction", getInfoListsResponse.infoList[i].lists.action);
                        Customer.Attributes.Add("amx_listasinternas_clientescodreason", getInfoListsResponse.infoList[i].lists.codReason);
                        Customer.Attributes.Add("amx_listasinternas_clientescodaction", getInfoListsResponse.infoList[i].lists.codAction);
                        customerInListaClientes = true;
                    }
                    else if (getInfoListsResponse.infoList[i].lists.list == "TELEFONOS")
                    {
                        Customer.Attributes.Add("amx_listasinternas_telefonosreason", getInfoListsResponse.infoList[i].lists.reason);
                        Customer.Attributes.Add("amx_listasinternas_telefonosaction", getInfoListsResponse.infoList[i].lists.action);
                        Customer.Attributes.Add("amx_listasinternas_telefonoscodreason", getInfoListsResponse.infoList[i].lists.codReason);
                        Customer.Attributes.Add("amx_listasinternas_telefonoscodaction", getInfoListsResponse.infoList[i].lists.codAction);
                        customerInListaTelefonos = true;
                    }
                    else if (getInfoListsResponse.infoList[i].lists.list == "CORREOS")
                    {
                        Customer.Attributes.Add("amx_listasinternas_correosreason", getInfoListsResponse.infoList[i].lists.reason);
                        Customer.Attributes.Add("amx_listasinternas_correosaction", getInfoListsResponse.infoList[i].lists.action);
                        Customer.Attributes.Add("amx_listasinternas_correoscodreason", getInfoListsResponse.infoList[i].lists.codReason);
                        Customer.Attributes.Add("amx_listasinternas_correoscodaction", getInfoListsResponse.infoList[i].lists.codAction);
                        customerInListaCorreos = true;

                    }
                }
            }
            // This was removed due to new response
            if (!customerInListaClientes)
            {
                Customer.Attributes.Add("amx_listasinternas_clientesreason", "");
                Customer.Attributes.Add("amx_listasinternas_clientesaction", "");
                Customer.Attributes.Add("amx_listasinternas_clientescodreason", "");
                Customer.Attributes.Add("amx_listasinternas_clientescodaction", "");
            }
            if (!customerInListaTelefonos)
            {
                Customer.Attributes.Add("amx_listasinternas_telefonosreason", "");
                Customer.Attributes.Add("amx_listasinternas_telefonosaction", "");
                Customer.Attributes.Add("amx_listasinternas_telefonoscodreason", "");
                Customer.Attributes.Add("amx_listasinternas_telefonoscodaction", "");
            }
            if (!customerInListaCorreos)
            {
                Customer.Attributes.Add("amx_listasinternas_correosreason", "");
                Customer.Attributes.Add("amx_listasinternas_correosaction", "");
                Customer.Attributes.Add("amx_listasinternas_correoscodreason", "");
                Customer.Attributes.Add("amx_listasinternas_correoscodaction", "");
            }
            _org.Update(Customer);
            #endregion
           
            /* eheldma: his was removed due to new response
             * 
            if (customerInListaClientes) {
                Lista = "CLIENTES";
            }
            if (customerInListaTelefonos) {
                Lista = Lista + ", TELEFONOS";
            }
            if (customerInListaCorreos) {
                Lista = Lista + ", CORREOS";
            }

            */
            if (customerInListaClientes) { response.clientes = true; } else { response.clientes = false; }
            if (customerInListaTelefonos) { response.telefonos = true; } else { response.telefonos = false; }
            if (customerInListaCorreos) { response.correos = true; } else { response.correos = false; }
            return response;

        }

        /// <summary>
        /// Update the Listas
        /// </summary>
        /// <param name="listasURL"></param>
        /// <param name="individualCustomerId"></param>
        /// <param name="_org"></param>
        /// <param name="orderId"></param>
        /// <param name="idReason"></param>
        /// <returns></returns>
        public string UpdateList(string listasURL, Guid individualCustomerId, OrganizationServiceProxy _org, Guid orderId, string idReason)
        {
            //string areaCode;
            //string telephone;
            string identifier = " ";
            string information = " ";
            string applicant = "";

            // Retrieve customer's information to send to Listas

            var individualRepository = new IndividualCustomerRepository(_org);
            var individual = individualRepository.GetById(individualCustomerId);
            if (individual.IndividualCustomerId == Guid.Empty)
                throw new Exception("Individual Customer not found for Id: " + individualCustomerId);
            var common = new AmxCoPSBActivities.BusinessClaroESB.AmxCoClaroESBCommon(_org);

            // Assign the applicant

            var orderCaptureRepository = new OrderCaptureRepository(_org);
            var existOrderCapture = orderCaptureRepository.GetOrderCapture(orderId);
            if (existOrderCapture.OrderCaptureId == Guid.Empty)
                throw new Exception("Order not found for Id: " + orderId);
            Guid userId = existOrderCapture.CreatedBy;
            var userRepository = new UserRepository(_org);
            var existUser = userRepository.GetFirst(userId);
            applicant = existUser.FullName;


            // Get document type if listas is CLIENTES

            //if (list == "CLIENTE")
            //{
            //list = "LISTA CLIENTES";
            if (individual.DocumentType == 1) { information = "CC"; }
            else if (individual.DocumentType == 2) { information = "NI"; }
            else if (individual.DocumentType == 3) { information = "NE"; }
            else if (individual.DocumentType == 4) { information = "CE"; }
            else if (individual.DocumentType == 5) { information = "PP"; }
            else if (individual.DocumentType == 6) { information = "CD"; }
            else if (individual.DocumentType == 7) { information = "TI"; }
            else if (individual.DocumentType == 8) { information = "TE"; }
            else if (individual.DocumentType == 9) { information = "RN"; }
            identifier = individual.DocumentNumber;
            //}

            // Get telephone number and area code if lista is telefonos

            /*else if (list == "TELEFONO")
            {
                list = "LISTA TELEFONOS";
                if (string.IsNullOrEmpty(individual.PhoneNumber) || individual.PhoneNumber.Length > 8 || individual.PhoneNumber.Length < 7)
                {
                    areaCode = " ";
                    telephone = " ";
                }
                else
                {
                    areaCode = individual.PhoneNumber.Substring(0, 1);
                    telephone = individual.PhoneNumber.Substring(1, 7);
                }
                identifier = telephone;
                information = areaCode;
            }

            // Get e-mail if list is correos

            else if (list == "CORREO")
            {
                list = "LISTA CORREOS";
                if (string.IsNullOrEmpty(individual.Email))
                {
                    identifier = " ";
                }
                else
                {
                    identifier = individual.Email;
                }
                information = " ";

            }  */

            var request = UpdateListRequest.UpdateListRequestFactory("CLIENTES", idReason, applicant, identifier, information);

            string jsonRequest;
            string jsonResponse;
            string error;

            if (!common.RestCall<UpdateListRequest>(listasURL, request, out jsonRequest, out jsonResponse, out error))
            {
                return error;
            }

            var updateInfoListsResponse = JsonConvert.DeserializeObject<ModelClaroESB.Listas.GetInfoListsResponse>(jsonResponse);

            return "OK";

        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Set the Document type code based of  Individual Document type
        /// </summary>
        /// <param name="individual"></param>
        /// <returns></returns>
        private string GetDocumentType(AmxPeruPSBActivities.Model.Individual.IndividualCustomerModel individual)
        {
            string docType = string.Empty;
            switch (individual.DocumentType)
            {
                case 1:
                    docType = "CC"; break;
                case 2:
                    docType = "NI"; break;
                case 3:
                    docType = "NE"; break;
                case 4:
                    docType = "CE"; break;
                case 5:
                    docType = "PP"; break;
                case 6:
                    docType = "CD"; break;
                case 7:
                    docType = "TI"; break;
                case 8:
                    docType = "TE"; break;
                case 9:
                    docType = "RN"; break;
            }

            return docType;
        }
        #endregion
    }
}
