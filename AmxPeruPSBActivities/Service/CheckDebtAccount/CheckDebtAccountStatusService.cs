using AmxPeruPSBActivities.ConsultaDeudaCuenta_v1;
using AmxPeruPSBActivities.Model.CheckDebtAccount;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Service.CheckDebtAccount
{
    public class CheckDebtAccountStatusService
    {
        public CheckDebtAccountResponse GetDebtAccountStatus(CheckDebtAccountRequest request, OrganizationServiceProxy organizationService)
        {
            CheckDebtAccountResponse objResponse = null;

            try
            {
                /// Request object Mapping with service request object
                consultarDeudaCuentaRequestType requestMessageType = new consultarDeudaCuentaRequestType()
                {
                    headerRequest = new HeaderRequestType1()
                    {
                        idAplicacion = Convert.ToInt64(request.AplicationId)
                    ,
                        usuarioAplicacion = request.UserApplication
                    },
                    adjustmentDocuments = new adjustmentDocuments()
                    {
                        documentId = request.DocumentId,
                        documentNumber = request.DocumentNumber
                    }
                };


            //    ConsultaDeudaCuenta_v1.ConsultaDeudaCuenta objService = new ConsultaDeudaCuenta_v1.ConsultaDeudaCuenta();
             //   objService.consultarDeudaCuenta(requestMessageType);

                consultarDeudaCuentaResponseType _responseObject = new consultarDeudaCuentaResponseType()
                {
                    responseStatus = new ResponseStatus1()
                    {
                        codeResponse = "code_Response",
                        date = DateTime.Now,
                        descriptionResponse = "sample_Desc",
                        errorLocation = "sample_Error_location",
                        origin = "sample_origin",
                        status = -12
                    },
                    cabeceraConsultaResponse = new CabeceraConsultaResponseType[1]{ new CabeceraConsultaResponseType() {
                        organizationIdentificationExtension = new OrganizationIdentificationExtension()
                        {
                                _RUC = "sampleRUC"
                        },
                        agreement = new Agreement(){  amount = new Money() { amount = 4000 }},
                        customerSpec = new CustomerSpec(){ lastName = "sample_lastname" },
                        customerSpecExtension = new CustomerSpecExtension(){ _secondLastName = "second_lastname" },
                        paymentPlan  = new PaymentPlan(){ totalAmount = new Money(){ amount = 100} },
                        partyPayment = new PartyPayment()
                        {
                            amount = new Money()
                            {
                                amount = 1000
                            },
                            remainingAmount = new Money()
                            {
                                amount = 2000
                            }
                            //_paymentPlan = new PaymentPlan()
                            //{
                            //    //maxAmount = new Money()
                            //    //{
                                    
                            //    //}
                            //},


                        },
                        partyPaymentItem = new PartyPaymentItem()
                        {
                            _partyPayment  = new PartyPayment()
                            {
                                remainingAmount  = new Money()
                                {
                                    amount = 3000
                                }
                            },
                             appliedAmount  = new Money()
                            {

                                    amount = 3000

                            },

                        },
                        documents = new Documents()
                        {
                            _documentNumber = 123
                        },
                        //duration = new Duration()
                        //{
                        //    _Amount = new Money()
                        //    {
                        //        amount = 1222
                        //    }
                        //},
                        
                        serviceDocuments = new serviceDocuments()
                        {
                           _amount = new _amountType()
                           {
                               _originalAmount = new _Amount()
                               {
                                   _Amount1 = new Money()
                               }
                           }
                        },
                        detalleConsultaResponse = new DetalleConsultaResponseType[1] { new DetalleConsultaResponseType()
                        {
                            serviceSpecificationType = new ServiceSpecificationType()
                            {
                                name = "test"
                            },
                            financialChargeSpec = new FinancialChargeSpec()
                            {
                                ID = "id"
                            },
                            partyAccount = new PartyAccount()
                            {
                                accountstatus = "acc"
                            }
                         },


                        }

                    }


                    }



                };

                objResponse = new CheckDebtAccountResponse()
                {
                    CodigoRespuesta = "Ok",
                    DescripcionRespuesta="Returning mock data",
                    CABECERA_CONSULTA=new List<HeadQuestionType>()
                    {
                        new HeadQuestionType()
                        {
                            ANTIGÜEDAD_DEUDA=1 ,
                            APE_MAT_CLIENTE ="test" ,
                            APE_PAT_CLIENTE= "test",
                            DEUDA_CASTIGADA_FIJA=1,
                            DEUDA_CASTIGADA_MOVIL=0,
                            DEUDA_FIJA=1,
                            DEUDA_MOVIL=0,
                            DEUDA_VENCIDA_FIJA=1,
                            DEUDA_VENCIDA_MOVIL=0,
                            DNI_ASOCIADO="test",
                            NOMBRE_CLIENTE="test",
                            TOTAL_SERVICIOS=100
                            
                        }
                    },
                    DETALLE_CONSULTA=new List<DetailReferenceType>()
                    {
                        new DetailReferenceType()
                        {
                            CANT_SERVICIOS=1,
                            COD_CUENTA="200",
                            DEUDA_CASTIGADA=1,
                            DEUDA_CORRIENTE=1,
                            DEUDA_VENCIDA=1,
                            ESTADO_CUENTA="test",
                            IND_CENTRAL_RIESGO="test"  ,
                            PROMEDIO_FACTURADO=1,
                            TIPO_SERVICIO="test"
                        }
                    }

                };
}
            catch (Exception ex)
            {

            }
            return objResponse;

        }
    }
}
