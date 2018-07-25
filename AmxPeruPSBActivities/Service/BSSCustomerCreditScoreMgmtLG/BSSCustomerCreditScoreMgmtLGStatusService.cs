using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmxPeruPSBActivities.BSS_CUSTOMER_CREDIT_SCORE_MGMT_LG_V1;
using AmxPeruPSBActivities.Model.BSSCustomerCreditScoreMgmtLG;
using Microsoft.Xrm.Sdk.Client;

namespace AmxPeruPSBActivities.Service.BSSCustomerCreditScoreMgmtLG
{
    public class BSSCustomerCreditScoreMgmtLGStatusService
    {
        public AMXPeruBSSCustomerCreditScoreMgmtLGResponse GetBSSCustomerCreditScoreMgmtLGStatus( AMXPeruBSSCustomerCreditScoreMgmtLGRequest request, OrganizationServiceProxy organizationService)
        {
            AMXPeruBSSCustomerCreditScoreMgmtLGResponse objResponse = null;
            try
            {
                //AMXPeruRequestBuroRequestType requestMessageType = new AMXPeruRequestBuroRequestType()
                //{
                   
                //};

                getCreditScoreRequestType objReqService = new getCreditScoreRequestType()
                {
                    ConsultaBuroRequest = new ConsultaBuroRequestType()
                    {
                        documents = new Documents()
                        {
                            _documentName = request.Requestburorequesttype.Documenttype,
                            _documentNumber = Convert.ToInt32(request.Requestburorequesttype.Documentnumber)
                        },
                        customerSpecExtension = new CustomerSpecExtension()
                        {
                            lastName = request.Requestburorequesttype.Lastname,
                            name = request.Requestburorequesttype.Names,
                            _secondLastName = request.Requestburorequesttype.Motherlastname
                        },

                        TableConfig = new TableConfigType
                        {
                            customerSpec = new CustomerSpec()
                            {
                                name = request.Requestburorequesttype.Names,
                                _agreement = new Agreement[]
                                {
                                  new Agreement()
                                  {
                                      amount = new Money()
                                      {
                                          amount = request.Requestburorequesttype.Tableconfiguration.Share
                                      },
                                      _bankAccount = new BankAccount()
                                      {
                                          accountNumber = Convert.ToString(request.Requestburorequesttype.Tableconfiguration.Code)
                                      }
                                  }

                                }



                            },

                            documents = new Documents()
                            {
                                _documentId = Convert.ToInt32(request.Requestburorequesttype.Tableconfiguration.Typedocument)
                            },

                            URL = new URL()
                            {
                                path = request.Requestburorequesttype.Tableconfiguration.Url
                            }
                            
                        }
                    },

                    ListaRequestOpcional = new ListaRequestOpcionalType[]
                    {
                      new  ListaRequestOpcionalType()
                       {
                          attributeValuePair=new AttributeValuePair()
                          {
                              value = "value",
                              name = "name"
                          }
                       }
                    }
                }; 



                //BSS_CUSTOMER_CREDIT_SCORE_MGMT_LG_V1.BSS_CUSTOMER_CREDIT_SCORE_MGMT_LG objService = new BSS_CUSTOMER_CREDIT_SCORE_MGMT_LG_V1.BSS_CUSTOMER_CREDIT_SCORE_MGMT_LG();
                //objService.getCreditScore(objReqService);

                getCreditScoreResponseType objResService = new getCreditScoreResponseType()
                {
                    ConsultaBuroResponse = new ConsultaBuroResponseType()
                    {
                        customerSpec = new CustomerSpec()
                        {
                            _agreement = new Agreement[]
                            {
                                new Agreement()
                                  {
                                      _bankAccount = new BankAccount()
                                      {
                                          accountNumber = "998765234328"
                                      }
                                  }
                            }
                        },
                        utilitysFieldsExtension = new UtilityFieldsExtension()
                        {
                            text01 = "text 01"
                        },
                        Masivo = new MasivoType()
                        {
                            businessInteractionItem = new BusinessInteractionItem()
                            {
                                action = "action value"

                                
                            },
                            customerAccount = new CustomerAccount()
                            {
                                _partyAccount = new PartyAccount()
                                {
                                    creditlimit = new Money()
                                    {
                                        amount = 8000
                                    }
                                }
                            },
                            customerCreditProfile = new CustomerCreditProfile()
                            {
                                creditRiskRating = "risk rate",
                                creditScore = "credit score"
                            },
                            product = new Product()
                            {
                                popId = "popIdString"
                            },
                            customer = new Customer()
                            {
                                id = "id",
                                _customerAccount = new CustomerAccount[]
                                {
                                    new CustomerAccount()
                                    {
                                        _partyAccount = new PartyAccount()
                                        {
                                            creditlimit = new Money()
                                            {
                                                amount = 8000
                                            }
                                        }

                                    }
                                }
                            },
                            documents = new Documents()
                            {
                                _description = "document description"
                            },
                            customerSpecExtension = new CustomerSpecExtension()
                            {
                                lastName = "Last Name",
                                _secondLastName = "sec last name",
                                name = "name",
                                _age = 65,
                                _memberNumber = "memberno.",
                                birthDate = DateTime.Now
                            },
                            responseStatusExtension = new ResponseStatusExtension()
                            {
                                _reasonType = "reason type",
                                _analyzeType = "analyze type"
                            },
                            utilitysFieldsExtension = new UtilityFieldsExtension()
                            {
                                text02 = "plazo venta equipos",
                                text03 = "puntaje"
                            },
                            componentProdPrice = new ComponentProdPrice()
                            {
                                price = new Money()
                                {
                                    units = "units"
                                }
                            }

                        },
                        Corporativo = new CorporativoType()
                        {
                            customerCreditProfile = new CustomerCreditProfile()
                            {
                                creditScore = "credit score"
                            },
                            customerAccount = new CustomerAccount()
                            {
                                _partyAccount = new PartyAccount()
                                {
                                    creditlimit = new Money()
                                    {
                                        amount = 5000
                                    }
                                }
                            },
                            customerBillingCycleExtension = new CustomerBillingCycleExtension()
                            {
                                _creditCardIncome = 8000,
                                _mortgageDebtIncome = 8000,
                                _nonMortgageDebtIncome = 8000
                            },
                            Integrante = new IntegranteType[]
                            {
                                new IntegranteType()
                                {
                                    customerSpecExtension = new CustomerSpecExtension()
                                    {
                                        _memberNumber = "memberno.",
                                        fullName = "full name"
                                    },
                                    documents = new Documents()
                                    {
                                        _documentId = 324
                                    },
                                    customer = new Customer()
                                    {
                                        id = "IdCust"
                                    }

                                }

                            },
                            Representante = new RepresentanteType[]
                            {
                                new RepresentanteType()
                                {
                                    customerSpec = new CustomerSpec()
                                    {
                                        category = new AttributeValuePair()
                                        {
                                            name = "name"
                                        }
                                    },
                                    documents = new Documents()
                                    {
                                        _documentName = "document name",
                                        _description = "description",                                    
                                    },
                                    serviceDocuments = new serviceDocuments()
                                    {
                                        _Documents = new Documents()
                                        {
                                           _validFor = new TimePeriod()
                                           {
                                               startdatetime = DateTime.Now
                                           }
                                        }
                                    }
                                }

                            }
                        }
                    },

                    ListaResponseOpcional = new ListaResponseOpcionalType[]
                    {
                        new  ListaResponseOpcionalType()
                       {
                          attributeValuePair=new AttributeValuePair()
                          {
                              value = "value",
                              name = "name"
                          }
                       }
                    }

                };


                objResponse = new AMXPeruBSSCustomerCreditScoreMgmtLGResponse()
                {
                    Inquiryburoresponsetype = new AMXPeruInquiryburoresponsetype()
                    {
                        
                        Numberoperation = Convert.ToString(898),
                        Burocode =567,
                        Massiveresponse = new AMXPeruMassivetype()
                        {
                          Action = "Action",
                          Age = 23,
                          Analysis = "Analysis",
                          Lastname = "Lastname",
                          Birthdate = DateTime.Now,
                          Clienttype = "client type",
                          Creditlimit = 67,
                          Creditscore = "credscore",
                          Documentnumber = "doc no.",
                          Motherlastname = "momlast",
                          Names = "name",
                          Lcorigin = "Lcorigin",
                          Producttype = "Producttype",
                          Limitcreditequipment = "Limitcreditequipment",
                          Reasons = "Reasons",
                          Score = "Score",
                          Scorerisk = "Scorerisk",
                          Termsaleequipment = "Termsaleequipment",
                          Typecard = "Typecard"
                        },
                        Corporateresponse = new AMXPeruCorporatetype()
                        {
                            Score = Convert.ToInt32("23"),
                            Creditcardentry = Convert.ToInt32("23"),
                            Creditlimit = Convert.ToInt32("23"),
                            Mortgagedebtincome = Convert.ToInt32("23"),
                            NonMortgagedebtincome = Convert.ToInt32("23"),
                            Listmembers = new List<AMXPeruIntegraltype>()
                            {
                               new AMXPeruIntegraltype()
                               {
                                   Documentnumber = "dss",
                                   Documenttype = Convert.ToInt32("23"),
                                   Membernumber = 34,
                                   Names = "Names"
                               }
                            },
                            Listrepresentatives =new List<AMXPeruTyperepresentative>
                            {
                                new AMXPeruTyperepresentative()
                                {
                                    Datehome = DateTime.Now,
                                    Documentnumber = "Documentnumber",
                                    Documenttype = Convert.ToInt32("23"),
                                    Position = "Position",
                                    Typeperson = "Typeperson"
                                }
                            }
                        }

                        

                    },
                    Optionalresponselist = new AMXPeruOptionalresponselisttype()
                    {
                        Name= "dd",
                        Value= "dd"
                    }
                };


                return objResponse;
            }

            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
