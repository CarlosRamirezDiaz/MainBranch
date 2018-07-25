using AmxPeruPSBActivities.Model.Individual;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AmxPeruPSBActivities.Business
{
    public class AmxCoSendSurveyBusiness
    {
        List<string> _results;
        public AmxCoSendSurveyResponse AmxCoSendSurvey(OrganizationServiceProxy service, AmxCoSendSurveyRequest request)
        {
            _results = new List<string>();
            AmxCoSendSurveyResponse response = new AmxCoSendSurveyResponse();

            Guid guidcontact;

            if (Guid.TryParse(request.contactid, out guidcontact))
            {
                QueryExpression query = new QueryExpression("amx_customercontactinformation");
                query.Criteria.AddCondition("amx_individualcustomerid", ConditionOperator.Equal, guidcontact);
                query.Criteria.AddCondition("amx_primarycontacttype", ConditionOperator.Equal, true);
                query.ColumnSet.AddColumns("amx_contacttype", "amx_email", "amx_phoneno", "amx_primarycontacttype");

                EntityCollection results = service.RetrieveMultiple(query);

                string channelvalue = validateChannel(results);

                if (channelvalue != null)
                {
                    //Aqui se hace el envío al medio de contacto seleccionado
                }
                else
                {
                    addResultToList("No se encontro un medio de contacto principal.");
                }
            }
            else
            {
                addResultToList("El Guid del cliente individual tiene un formato no valido. Ejemplo: C2E31111-72DF-E711-80E7-FA163E10DFBE.");
            }

            if (_results.Count > 0)
            {
                response.ErrorDetail = _results;
                response.Error = true;
            }
            else
            {
                response.ErrorDetail = null;
                response.Error = false;
            }

            return response;
        }

        private string validateChannel(EntityCollection results)
        {
            string principalChannelValue = null;

            string cellphone = null;
            string email = null;
            string phone = null;

            if (results.Entities.Count > 0)
            {
                foreach (Entity customerContact in results.Entities)
                {
                    if (customerContact.Contains("amx_contacttype"))
                    {
                        int contacttype = customerContact.GetAttributeValue<OptionSetValue>("amx_contacttype").Value;

                        if (contacttype == 173800001)
                        {
                            if (customerContact.Contains("amx_phoneno"))
                            {
                                cellphone = customerContact.GetAttributeValue<string>("amx_phoneno");
                            }
                        }
                        else if (contacttype == 173800000)
                        {
                            if (customerContact.Contains("amx_email"))
                            {
                                email = customerContact.GetAttributeValue<string>("amx_email");
                            }
                        }
                        else if (contacttype == 173800002)
                        {
                            if (customerContact.Contains("amx_phoneno"))
                            {
                                phone = customerContact.GetAttributeValue<string>("amx_phoneno");
                            }
                        }
                    }

                }
            }
            else
            {
                addResultToList("Debe tener al menos un medio de contacto principal.");
            }

            if (cellphone != null)
            {
                principalChannelValue = cellphone;
            }
            else
            {
                if (email != null)
                {
                    principalChannelValue = email;
                }
                else
                {
                    if (phone != null)
                    {
                        principalChannelValue = phone;
                    }
                }
            }

            return principalChannelValue;
        }

        private void addResultToList(string detail)
        {
            _results.Add(detail);
        }


    }
}
