using AmxPeruPSBActivities.Model.CustomerAccountStatement;
using Microsoft.Xrm.Sdk.Client;
using AmxPeruPSBActivities.ConsultaEstadoCuenta_v1;
using System;
using System.Collections.Generic;

namespace AmxPeruPSBActivities.Service.CustomerAccountStatement
{
    public class ConsultationAccountStatusService
    {
        public AMXPeruAccountConsultationResponse GetConsultationAccountStatus(AMXPeruAccountConsultationRequest request, OrganizationServiceProxy organizationService)
        {

            request.ApplicationCode = "pCodAplicacion";
            request.UserApplication = "pUsuarioAplic";
            request.QueryType = "pTipoConsulta";
            request.ServiceType = "pTipoServicio";
            request.CLIAccountNo = "pCliNroCuenta";

            consultarEstadoCuentaRequestType requestMessageType = new consultarEstadoCuentaRequestType()
            {              


                headerRequestType = new HeaderRequestType1()
                {
                    usuarioAplicacion = request.UserApplication,
                    idTransaccionNegocio = request.TransactionId
                },
                businessInteractionSpec = new BusinessInteractionSpec()
                {

                },
                customerAccount = new CustomerAccount()
                {
                    _partyAccount = new PartyAccount()
                    {
                        accountstatus = request.BalanceEnquryFlag,
                        accounttype = request.ServiceType,

                    }
                },
                customerContactSpec = new CustomerContactSpec()
                {

                    phoneNumber1 = request.TelephoneNo
                },
                documentsExtension = new DocumentsExtension()
                {
                    _pageCounter = Convert.ToInt32(request.PageNo),
                    _outputLength = request.PageSize

                },
                serviceCandidate = new ServiceCandidate()
                {
                    status = request.BalanceEnquryFlag,
                    validfor = new TimePeriod()
                    {
                        startdatetime = request.StartDate,
                        enddatetime = request.EndDate
                    }
                },
                utilityFields = new UtilityFields()
                {
                    text01 = string.Empty
                }

            };

            //todo: ConsultaDeudaCuenta?wsdl : implementation real service is not available

            //ConsultaEstadoCuenta_v1.ConsultaDeudaCuenta objService = new ConsultaDeudaCuenta();
            //consultarEstadoCuentaResponseType objServiceResponse = objService.consultarEstadoCuenta(requestMessageType);


            //creating mock response for test
            ResponseStatus1 _ResponseStatus1 = new ResponseStatus1();
            EstadoCuentaResponseType[] _EstadoCuentaResponseTypeArray = new EstadoCuentaResponseType[1];
            _EstadoCuentaResponseTypeArray[0] = new EstadoCuentaResponseType()
            {
                customerSpec = new CustomerSpec()
                {
                    name = "Sample_Name_1",
                    category = new AttributeValuePair() { name = "catName", value = "catValue" }
                },

                customer = new Customer() { id = "customer_sample_id_1" },
                customerCreditProfile = new CustomerCreditProfile() { creditScore = "sample_Score_890" },
                agreement = new Agreement() { amount = new Money() { amount = 125 } },
                partyPayment = new PartyPayment { remainingAmount = new Money() { amount = 200 } },
                paymentPlan = new PaymentPlan { totalAmount = new Money() { amount = 225 } },
                documents = new Documents { _validFor = new TimePeriod() { startdatetime = new System.DateTime() } },
                documentsExtension = new DocumentsExtension() { _generatedate = new System.DateTime[] { System.DateTime.Now } },
                partyAccount = new PartyAccount() { id = "party_account_id_1", accountstatus = "account_status_1" },
                geographicAddress = new GeographicAddress() { location1 = "sample_location_1" },
                timePeriod = new TimePeriod() { startdatetime = new System.DateTime() },
                onCyclePartyBill = new OnCyclePartyBill() { },
                paymentMethod = new PaymentMethod() { },
                //----Array Declaretion type----//
                detalleEstadoResponse = new DetalleEstadoResponseType[] { new DetalleEstadoResponseType()
                {
                    documentsExtension=new DocumentsExtension()
                    {
                        _fileType = "file_type_1",
                        _description = "description_1",
                        _status = -1,
                        _validFor = new TimePeriod() {startdatetime = new System.DateTime() , enddatetime = new System.DateTime() }
                    },
                    adjustmentDocuments = new adjustmentDocuments() {
                        documentNumber = "Document_Number_1",
                        description = "description_1",
                        documentId = "1"
                    },
                    financialChargeExtension = new FinancialChargeExtension() {
                        _registerDate = new System.DateTime()
                    },
                    moneyExtension = new MoneyExtension() {
                         _changeType = new decimal[] { 10, 12 },
                         _amountPEN = new decimal(8),
                         _amountUSD = new decimal(100),
                         amount = new decimal(20)
                    },
                   serviceDocuments = new serviceDocuments() {
                       _amount = new _amountType() {
                           _billingAmount = new _Amount() {
                               _Amount1 = new Money() {amount=335 },
                               _Amounting = new _Amounting() {
                                   _Money = new Money() {amount=400 }
                               }
                           },
                           _originalAmount = new _Amount() {
                               _Amount1 = new Money() {amount=500 }
                           },
                           _payingAmount = new _Amount() {
                               _Amount1 = new Money() {amount=600 }
                           },
                           _owingAmount = new _Amount() {
                               _Amount1 = new Money() {amount=700}
                           },
                           _nullAmount = new _Amount() {
                               _Amount1 = new Money() {amount=800 }
                           }
                       }
                   },
                   partyPayment = new PartyPayment() {
                       amount = new Money() {amount=805 },
                       remainingAmount = new Money() {amount=810 },
                       ID = "10"
                   },
                   paymentMethod = new PaymentMethod() {
                       validFor = new TimePeriod() {startdatetime = new System.DateTime() },
                       name = "payment_method_name"
                   },
                   utilityFields = new UtilityFields() {
                       text01 = "txt_1",
                       text02 = "txt_2",
                       text03 = "txt_3",
                       text04 = "txt_4",
                       text05 = "txt_5",
                       text06 = "txt_6"
                   },
                   partySettlement = new PartySettlement() {
                       settlementNumber = "settlement_1",
                       amount = new Money() {amount = 900 }
                   },
                   customerContactSpecExtension = new CustomerContactSpecExtension() {
                       phoneNumber1 = "phone_number_1",
                       id = "5"
                   }
                }

              }
            };

            AMXPeruAccountConsultationResponse objResponse = new AMXPeruAccountConsultationResponse()
            {

                ResponseDescription = "Response is ok. Response code 200",
                Status = "OK",
                XtAccountStatus = new List<AMXPruStateCountType>()
               {
                   
                   new AMXPruStateCountType()
                   {
                       AccountStatement="Test",
                       ActivationDate=DateTime.Now.ToLongDateString(),
                       AlternateAccountCode="0000777776666"  ,
                       BillingCycle="Second" ,
                       ClientName="Sachin Tendulkar" ,
                       ClientType  ="Premier",
                       CodeAccount ="09989888700000999" ,
                       CreditLimit  ="1000000000000" ,
                       CreditScore="780" ,
                       CurrentDebt="10",
                       DateInvoiceUlt=DateTime.Now.AddDays(-20).ToLongDateString(),
                       DetailStateType=new List<AMXPeruDetailStateType>()
                       {
                           new AMXPeruDetailStateType()
                           {
                               AmountofMoney="1200",
                               AnionIssue="test",
                               BalanceAccount="2000" ,
                               BroadcastDate=DateTime.Now.ToLongDateString(),
                               ClaimAmount="200",
                               CurrencyType="US Dollar",
                               DocOacId="09898",
                               DocumentAmount="1000",
                               DocumentBalance="300",
                               DocumentDescription="this is a test description",
                               DocumentNo="09989998",
                               Documentstatus="Active",
                               DocumentType="Invoice",
                               DollarAmount="200",
                               DueDate=DateTime.Now.AddDays(15).ToLongDateString(),
                               ExpirationDate=DateTime.Now.AddYears(1).ToLongDateString(),
                               ExpirationMonth=DateTime.Now.ToString("MMM") ,
                               ExtendedDescription="Description",
                               Fertilizer="true",
                               FinancialAmount="2000",
                               FinancialBalance="600",
                               FlagChargeAccount="883873666",
                               IHaveSoles="test",
                               IssuanceMonth= DateTime.Now.ToString("MMM"),
                               NoOperationPaid="900",
                               OutstandingBalance="400",
                               PaidForm="Client1",
                               PayDay=DateTime.Now.Day.ToString(),
                               Phone="8777377636",
                               Position="Top",
                               Registrationdate=DateTime.Now.AddDays(-90).ToLongDateString(),
                               SystemDocOrgId="00993883",
                               TicketNo="5455453443",
                               User="Client1"




                           },

                           new AMXPeruDetailStateType()
                           {
                               AmountofMoney="1200",
                               AnionIssue="test",
                               BalanceAccount="2000" ,
                               BroadcastDate="Fecha de Emisión",   //DateTime.Now.ToLongDateString(),
                               ClaimAmount="200",
                               CurrencyType="US Dollar",
                               DocOacId="09898",
                               DocumentAmount="Monto Total",
                               DocumentBalance="Saldo Restante",
                               DocumentDescription="Descripción",
                               DocumentNo="Núm. Documento",
                               Documentstatus="Estado",
                               DocumentType="Tipo",
                               DollarAmount="200",
                               DueDate="Fecha de Vencimineto",  //DateTime.Now.AddDays(15).ToLongDateString(),
                               ExpirationDate="Fecha de Vencimineto",  //DateTime.Now.AddYears(1).ToLongDateString(),
                               ExpirationMonth=DateTime.Now.ToString("MMM") ,
                               ExtendedDescription="Description",
                               Fertilizer="true",
                               FinancialAmount="2000",
                               FinancialBalance="600",
                               FlagChargeAccount="883873666",
                               IHaveSoles="test",
                               IssuanceMonth= DateTime.Now.ToString("MMM"),
                               NoOperationPaid="Núm. Pago",
                               OutstandingBalance="400",
                               PaidForm="Client1",
                               PayDay="Fecha Pago",  //DateTime.Now.Day.ToString(),
                               Phone="Teléfono",
                               Position="Top",
                               Registrationdate="Fecha Registro",  //DateTime.Now.AddDays(-90).ToLongDateString(),
                               SystemDocOrgId="00993883",
                               TicketNo="5455453443",
                               User="Client1"




                           }
                       },
                       ExpiredDebt=DateTime.Now.AddDays(240).ToLongDateString() ,
                       PayType="Cash" ,
                       TotalAmountDispute="180",
                       UBIGeoDescription="EGI kolkata",
                       UltDatePayment=DateTime.Now.AddDays(30).ToLongDateString()


                   }

               },
                Error = string.Empty,
                ReplyCode ="200"


            };



            return objResponse;


        }

    }
}
