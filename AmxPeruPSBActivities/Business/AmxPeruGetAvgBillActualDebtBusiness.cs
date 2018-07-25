using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.Model;
using System.ServiceModel;
using System.Configuration;
using Microsoft.Xrm.Sdk;
using Ericsson.ETELCRM.CrmFoundationLibrary.UtilitiesLibrary;
using Microsoft.Xrm.Sdk.Client;
using AmxPeruPSBActivities.BillAvgBilling;
using Microsoft.Xrm.Sdk.Query;
using System.ServiceModel.Channels;
using System.Xml.Serialization;
using System.Xml;

namespace AmxPeruPSBActivities.Business
{
   public class AmxPeruGetAvgBillActualDebtBusiness 
    {
        IOrganizationService OrgService = null;
        int? AvgBill = -1;
        int? ActualDebt = -1;
        Guid CutomerGuid = Guid.Empty;
        public AmxPeruGetAvgBillDebtLimitResponse FetchDataFromOACBSCS(AmxPeruGetAvgBillDebtLimitRequest request, OrganizationServiceProxy organizationService)
        {
            AmxPeruGetAvgBillDebtLimitResponse _GetAvgBillDebtLimitResponse = null;

            try
            {
                _GetAvgBillDebtLimitResponse = new AmxPeruGetAvgBillDebtLimitResponse();
                bool allowBillCycleChange = ValidateActualDebtAvgBill(request, organizationService);

                _GetAvgBillDebtLimitResponse.AllowBillCycleChange = allowBillCycleChange;
                // _GetAvgBillDebtLimitResponse.Status = AmxPeruCommon.Constants.StatusOK;
                _GetAvgBillDebtLimitResponse.Status = "OK";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _GetAvgBillDebtLimitResponse;
        }

        private bool ValidateActualDebtAvgBill(AmxPeruGetAvgBillDebtLimitRequest request, OrganizationServiceProxy organizationService)
        {
            bool flag = false;
            int CustomerTypeCode = -1;
            int paymentBehavior = -1;
            int compareValueGreaterThan24Months = -1;
            int compareValueLesserThan24Months = -1;

            try
            {
                if (request.CustomerType == 1)
                {
                    CustomerTypeCode = 2;
                }
                else if (request.CustomerType == 2)
                {
                    CustomerTypeCode = 1;
                }

                paymentBehavior = GetPaymentBehaviorOfCustomer(request,organizationService);

                string fetchXml = string.Format(FetchPaymentBehavior, CustomerTypeCode, paymentBehavior);
                EntityCollection paymentBehaviorData = organizationService.RetrieveMultiple(new FetchExpression(fetchXml));
                if (paymentBehaviorData != null && paymentBehaviorData.Entities.Count > 0)
                {
                    if (paymentBehaviorData.Entities[0].Attributes.Contains("amxperu_more24months"))
                    {
                        compareValueLesserThan24Months = Convert.ToInt32(paymentBehaviorData.Entities[0].Attributes["amxperu_more24months"].ToString());
                    }

                    if (paymentBehaviorData.Entities[0].Attributes.Contains("amxperu_less24months"))
                    {
                        compareValueLesserThan24Months = Convert.ToInt32(paymentBehaviorData.Entities[0].Attributes["amxperu_less24months"].ToString());
                    }
                }

                if (compareValueGreaterThan24Months >= 0 && compareValueLesserThan24Months >= 0)
                {
                    AvgBill = GetAvgBillFromBscs(request.CustomerExternalId);

                    if (ActualDebt >= 0 && AvgBill >= 0)
                    {
                        //Implement Logic
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return flag;
        }

        private int? GetAvgBillFromBscs(string customerExternalID)

        {
            int? AvgBillAamount = -1;
            
            try
            {
                var input = new BillAvgBilling.nkAverageBillReadRequest()
                {
                    inputAttributes = new BillAvgBilling.inputAttributes
                    {
                        csIdPub = customerExternalID
                    }
                };
                var output = BSCSHelper.Call_BSCS_nkAverageBillReadRequest(input);
                AvgBillAamount = Convert.ToInt32(output.averageBillAmount);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return AvgBillAamount;
        }
        
       
        private int GetPaymentBehaviorOfCustomer(AmxPeruGetAvgBillDebtLimitRequest request, OrganizationServiceProxy organizationService)
        {
            int paymentBehavior = -1;
            string customerTypeCode = string.Empty;
            string customerPrimaryFieldId = string.Empty;

            try
            {
                if (request.CustomerType == 1)
                {
                    customerTypeCode = "contact";
                    customerPrimaryFieldId = "contactid";
                }
                else if (request.CustomerType == 2)
                {
                    customerTypeCode = "account";
                    customerPrimaryFieldId = "accountid";
                }

                string fetchXml = string.Format(FetchPaymentBehaviorForCutomer, customerTypeCode, customerPrimaryFieldId, request.CustomerExternalId);
                EntityCollection _EntityCollection = organizationService.RetrieveMultiple(new FetchExpression(fetchXml));
                if (_EntityCollection != null && _EntityCollection.Entities.Count > 0)
                {
                    if (_EntityCollection.Entities[0].Attributes.Contains("amxperu_paymentbehavior"))
                    {
                        paymentBehavior = Convert.ToInt32(_EntityCollection.Entities[0].Attributes["amxperu_paymentbehavior"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return paymentBehavior;
        }

        private static string FetchPaymentBehavior = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                          <entity name='amxperu_debtlimitallowance'>
                                                            <attribute name='amxperu_debtlimitallowanceid' />
                                                            <attribute name='statuscode' />
                                                            <attribute name='statecode' />
                                                         <attribute name='amxperu_paymentbehavior' />
                                                            <attribute name='amxperu_name' />
                                                            <attribute name='modifiedonbehalfby' />
                                                            <attribute name='amxperu_customertype' />
                                                            <attribute name='createdon' />
                                                            <attribute name='amxperu_more24months' />
                                                            <attribute name='amxperu_less24months' />
                                                            <order attribute='statuscode' descending='false' />
                                                            <filter type='and'>
                                                              <condition attribute='amxperu_customertype' operator='eq' value='{0}' />
                                                              <condition attribute='amxperu_paymentbehavior' operator='eq' value='{1}' />
                                                            </filter>
                                                          </entity>
                                                        </fetch>";

        public static string FetchPaymentBehaviorForCutomer = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                                          <entity name='{0}'>
                                                                            <attribute name='{1}' />
                                                                            <attribute name='amxperu_paymentbehavior' />
                                                                            <order attribute='amxperu_paymentbehavior' descending='false' />
                                                                            <filter type='and'>
                                                                              <condition attribute='etel_externalid' operator='eq' value='{2}' />
                                                                            </filter>
                                                                          </entity>
                                                                        </fetch>";
    }

   

    #region Call BSCS Method
    public class BSCSHelper: MessageHeader
    {
        private readonly UsernameToken _usernameToken;

        public static BillAvgBilling.nkAverageBillReadResponse Call_BSCS_nkAverageBillReadRequest(BillAvgBilling.nkAverageBillReadRequest input)
        {
            BasicHttpBinding binding = new BasicHttpBinding
            {
                Name = "bscsServiceBinding",
                OpenTimeout = new TimeSpan(0, 15, 0),
                CloseTimeout = new TimeSpan(0, 15, 0),
                ReceiveTimeout = new TimeSpan(0, 15, 0),
                SendTimeout = new TimeSpan(0, 15, 0),
            };

            EndpointAddress _EndpointAddress = new EndpointAddress("http://10.103.27.183:20103/wsi/services/ws_CIL_7_NkAverageBillReadService");
            var client = new BillAvgBilling.NkAverageBillReadServiceClient(binding, _EndpointAddress);

            using (new OperationContextScope(client.InnerChannel))
            {
                OperationContext.Current.OutgoingMessageHeaders.Add(
                    new BSCSHelper("UsernameToken-49", "ADMX", "ADMX"));

                BillAvgBilling.nkAverageBillReadResponse res = client.nkAverageBillRead(input);

                return res;
            }
        }

        public BSCSHelper(string id, string username, string password)
        {
            _usernameToken = new UsernameToken(id, username, password);
        }

        public override string Name
        {
            get { return "Security"; }
        }

        public override string Namespace
        {
            get { return "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"; }
        }

        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UsernameToken));
            serializer.Serialize(writer, _usernameToken);
        }
    }


    [XmlRoot(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
    public class UsernameToken
    {
        public UsernameToken()
        {
        }

        public UsernameToken(string id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = new Password() { Value = password };
        }

        [XmlAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")]
        public string Id { get; set; }

        [XmlElement]
        public string Username { get; set; }

        [XmlElement]
        public Password Password { get; set; }
    }

    public class Password
    {
        public Password()
        {
            Type = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText";
        }

        [XmlAttribute]
        public string Type { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
    #endregion


   

}
