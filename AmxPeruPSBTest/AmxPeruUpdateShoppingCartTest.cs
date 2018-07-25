using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static AmxPeruTest.Helpers.TestHelper;
using AmxPeruPSBActivities.Activities.OrderItem;
using AmxPeruPSBActivities.Model;
using System.Collections.Generic;
using AmxPeruPSBWorkflows;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class AmxPeruUpdateShoppingCartTest
    {

        [TestMethod]
        public void GetOrderBasketSuccess()
        {
            var input = new Dictionary<string, object>()
            {

                {"orderGuid","C4806320-0CC2-E711-80E5-FA163E10DFBE" }
               
             };

            try
            {

                //var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.GetOrderBasket>(input)
                //            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                //            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void AmxPeruUpdateShoppingCartTestSuccess()
        {


            var chars = new List<Characteristics>{
                 new Characteristics
                            {
                                guid = Guid.Parse("b6a6f92e-d4a9-e711-80e2-fa163e106136"),
                                guidOfProdChar= Guid.Parse("b6a6f92e-d4a9-e711-80e2-fa163e106136"),
                                type = "notcfss",
                                name = "Velocidad Subida",
                                dataType =831260000,
                                editable = false,
                                inputValue = "2 Megas",
                                ProdCharValues = new List<CharacteristicsValue>
                                {
                                    new CharacteristicsValue{ guid = Guid.Parse("1eda6e72-dead-e711-80e2-fa163e105d63"),value="1"},
                                    new CharacteristicsValue{ guid = Guid.Parse("fad9813a-e0ad-e711-80e2-fa163e105d63"),value="2"},
                                    new CharacteristicsValue{ guid = Guid.Parse("deea6c54-e0ad-e711-80e2-fa163e105d63"),value="3"},
                                    new CharacteristicsValue{ guid = Guid.Parse("77285760-e0ad-e711-80e2-fa163e105d63"),value="4"},
                                    new CharacteristicsValue{ guid = Guid.Parse("3377ce76-e0ad-e711-80e2-fa163e105d63"),value="5"},
                                    new CharacteristicsValue{ guid = Guid.Parse("e65b8e8a-e0ad-e711-80e2-fa163e105d63"),value="6"}

                                },
                                selectedProdCharValues = null
                            },
                new Characteristics
                            {
                                guid = Guid.Parse("a7f0961d-d4a9-e711-80e2-fa163e106136"),
                                guidOfProdChar= Guid.Parse("a7f0961d-d4a9-e711-80e2-fa163e106136"),
                                type = "notcfss",
                                name = "Velocidad Bajada",
                                dataType =831260000,
                                editable = false,
                                inputValue = "10 Megas",
                                ProdCharValues = new List<CharacteristicsValue>
                                {
                                    new CharacteristicsValue{ guid = Guid.Parse("1eda6e72-dead-e711-80e2-fa163e105d63"),value="1"},
                                    new CharacteristicsValue{ guid = Guid.Parse("fad9813a-e0ad-e711-80e2-fa163e105d63"),value="2"},
                                    new CharacteristicsValue{ guid = Guid.Parse("deea6c54-e0ad-e711-80e2-fa163e105d63"),value="3"},
                                    new CharacteristicsValue{ guid = Guid.Parse("77285760-e0ad-e711-80e2-fa163e105d63"),value="4"},
                                    new CharacteristicsValue{ guid = Guid.Parse("3377ce76-e0ad-e711-80e2-fa163e105d63"),value="5"},
                                    new CharacteristicsValue{ guid = Guid.Parse("e65b8e8a-e0ad-e711-80e2-fa163e105d63"),value="6"}

                                },
                                selectedProdCharValues = null
                            },
                            new Characteristics
                            {
                                guid = Guid.Parse("fee54905-c8aa-e711-80e2-fa163e105d63"),
                                guidOfProdChar= Guid.Parse("fee54905-c8aa-e711-80e2-fa163e105d63"),
                                type = "notcfss",
                                name = "Estrato1",
                                dataType =831260000,
                                editable = true,
                                inputValue = "3",
                                ProdCharValues = new List<CharacteristicsValue>
                                {
                                    new CharacteristicsValue{ guid = Guid.Parse("1eda6e72-dead-e711-80e2-fa163e105d63"),value="1"},
                                    new CharacteristicsValue{ guid = Guid.Parse("fad9813a-e0ad-e711-80e2-fa163e105d63"),value="2"},
                                    new CharacteristicsValue{ guid = Guid.Parse("deea6c54-e0ad-e711-80e2-fa163e105d63"),value="3"},
                                    new CharacteristicsValue{ guid = Guid.Parse("77285760-e0ad-e711-80e2-fa163e105d63"),value="4"},
                                    new CharacteristicsValue{ guid = Guid.Parse("3377ce76-e0ad-e711-80e2-fa163e105d63"),value="5"},
                                    new CharacteristicsValue{ guid = Guid.Parse("e65b8e8a-e0ad-e711-80e2-fa163e105d63"),value="6"}
                                
                                },
                                selectedProdCharValues = null
                            },
                            new Characteristics
                            {
                                guid = Guid.Parse("cd2ca4da-d3a9-e711-80e2-fa163e106136"),
                                guidOfProdChar= Guid.Parse("cd2ca4da-d3a9-e711-80e2-fa163e106136"),
                                type = "notcfss",
                                name = "Max Cuenta Correos",
                                dataType =831260000,
                                editable = true,
                                inputValue = "5",
                                ProdCharValues = new List<CharacteristicsValue>
                                {
                                    new CharacteristicsValue{ guid = Guid.Parse("1eda6e72-dead-e711-80e2-fa163e105d63"),value="1"},
                                    new CharacteristicsValue{ guid = Guid.Parse("fad9813a-e0ad-e711-80e2-fa163e105d63"),value="2"},
                                    new CharacteristicsValue{ guid = Guid.Parse("deea6c54-e0ad-e711-80e2-fa163e105d63"),value="3"},
                                    new CharacteristicsValue{ guid = Guid.Parse("77285760-e0ad-e711-80e2-fa163e105d63"),value="4"},
                                    new CharacteristicsValue{ guid = Guid.Parse("3377ce76-e0ad-e711-80e2-fa163e105d63"),value="5"},
                                    new CharacteristicsValue{ guid = Guid.Parse("e65b8e8a-e0ad-e711-80e2-fa163e105d63"),value="6"}

                                },
                                selectedProdCharValues = null
                            },
                            new Characteristics
                            {
                                guid = Guid.Parse("baf834f0-d3a9-e711-80e2-fa163e106136"),
                                guidOfProdChar= Guid.Parse("baf834f0-d3a9-e711-80e2-fa163e106136"),
                                type = "notcfss",
                                name = "Max Puntos Cableados",
                                dataType =831260000,
                                editable = false,
                                inputValue = "1",
                                ProdCharValues = new List<CharacteristicsValue>
                                {
                                    new CharacteristicsValue{ guid = Guid.Parse("1eda6e72-dead-e711-80e2-fa163e105d63"),value="1"},
                                    new CharacteristicsValue{ guid = Guid.Parse("fad9813a-e0ad-e711-80e2-fa163e105d63"),value="2"},
                                    new CharacteristicsValue{ guid = Guid.Parse("deea6c54-e0ad-e711-80e2-fa163e105d63"),value="3"},
                                    new CharacteristicsValue{ guid = Guid.Parse("77285760-e0ad-e711-80e2-fa163e105d63"),value="4"},
                                    new CharacteristicsValue{ guid = Guid.Parse("3377ce76-e0ad-e711-80e2-fa163e105d63"),value="5"},
                                    new CharacteristicsValue{ guid = Guid.Parse("e65b8e8a-e0ad-e711-80e2-fa163e105d63"),value="6"}

                                },
                                selectedProdCharValues = null
                            },
                            new Characteristics
                            {
                                guid = Guid.Parse("f4c36507-d4a9-e711-80e2-fa163e106136"),
                                guidOfProdChar= Guid.Parse("f4c36507-d4a9-e711-80e2-fa163e106136"),
                                type = "notcfss",
                                name = "Nro Puntos Cableadoss",
                                dataType =831260000,
                                editable = false,
                                inputValue = "0",
                                ProdCharValues = new List<CharacteristicsValue>
                                {
                                    new CharacteristicsValue{ guid = Guid.Parse("1eda6e72-dead-e711-80e2-fa163e105d63"),value="1"},
                                    new CharacteristicsValue{ guid = Guid.Parse("fad9813a-e0ad-e711-80e2-fa163e105d63"),value="2"},
                                    new CharacteristicsValue{ guid = Guid.Parse("deea6c54-e0ad-e711-80e2-fa163e105d63"),value="3"},
                                    new CharacteristicsValue{ guid = Guid.Parse("77285760-e0ad-e711-80e2-fa163e105d63"),value="4"},
                                    new CharacteristicsValue{ guid = Guid.Parse("3377ce76-e0ad-e711-80e2-fa163e105d63"),value="5"},
                                    new CharacteristicsValue{ guid = Guid.Parse("e65b8e8a-e0ad-e711-80e2-fa163e105d63"),value="6"}

                                },
                                selectedProdCharValues = null
                            }
            };

            var chars2 = new List<Characteristics>{
                 new Characteristics
                            {
                                guid = Guid.Parse("b6a6f92e-d4a9-e711-80e2-fa163e106136"),
                                guidOfProdChar= Guid.Parse("b6a6f92e-d4a9-e711-80e2-fa163e106136"),
                                type = "notcfss",
                                name = "Velocidad Subida",
                                dataType =831260000,
                                editable = false,
                                inputValue = "2 Megas",
                                ProdCharValues = new List<CharacteristicsValue>
                                {
                                    new CharacteristicsValue{ guid = Guid.Parse("1eda6e72-dead-e711-80e2-fa163e105d63"),value="1"},
                                    new CharacteristicsValue{ guid = Guid.Parse("fad9813a-e0ad-e711-80e2-fa163e105d63"),value="2"},
                                    new CharacteristicsValue{ guid = Guid.Parse("deea6c54-e0ad-e711-80e2-fa163e105d63"),value="3"},
                                    new CharacteristicsValue{ guid = Guid.Parse("77285760-e0ad-e711-80e2-fa163e105d63"),value="4"},
                                    new CharacteristicsValue{ guid = Guid.Parse("3377ce76-e0ad-e711-80e2-fa163e105d63"),value="5"},
                                    new CharacteristicsValue{ guid = Guid.Parse("e65b8e8a-e0ad-e711-80e2-fa163e105d63"),value="6"}

                                },
                                selectedProdCharValues = null
                            },
                new Characteristics
                            {
                                guid = Guid.Parse("a7f0961d-d4a9-e711-80e2-fa163e106136"),
                                guidOfProdChar= Guid.Parse("a7f0961d-d4a9-e711-80e2-fa163e106136"),
                                type = "notcfss",
                                name = "Velocidad Bajada",
                                dataType =831260000,
                                editable = false,
                                inputValue = "10 Megas",
                                ProdCharValues = new List<CharacteristicsValue>
                                {
                                    new CharacteristicsValue{ guid = Guid.Parse("1eda6e72-dead-e711-80e2-fa163e105d63"),value="1"},
                                    new CharacteristicsValue{ guid = Guid.Parse("fad9813a-e0ad-e711-80e2-fa163e105d63"),value="2"},
                                    new CharacteristicsValue{ guid = Guid.Parse("deea6c54-e0ad-e711-80e2-fa163e105d63"),value="3"},
                                    new CharacteristicsValue{ guid = Guid.Parse("77285760-e0ad-e711-80e2-fa163e105d63"),value="4"},
                                    new CharacteristicsValue{ guid = Guid.Parse("3377ce76-e0ad-e711-80e2-fa163e105d63"),value="5"},
                                    new CharacteristicsValue{ guid = Guid.Parse("e65b8e8a-e0ad-e711-80e2-fa163e105d63"),value="6"}

                                },
                                selectedProdCharValues = null
                            },
                            new Characteristics
                            {
                                guid = Guid.Parse("fee54905-c8aa-e711-80e2-fa163e105d63"),
                                guidOfProdChar= Guid.Parse("fee54905-c8aa-e711-80e2-fa163e105d63"),
                                type = "notcfss",
                                name = "Estrato1",
                                dataType =831260000,
                                editable = true,
                                inputValue = "1",
                                ProdCharValues = new List<CharacteristicsValue>
                                {
                                    new CharacteristicsValue{ guid = Guid.Parse("1eda6e72-dead-e711-80e2-fa163e105d63"),value="1"},
                                    new CharacteristicsValue{ guid = Guid.Parse("fad9813a-e0ad-e711-80e2-fa163e105d63"),value="2"},
                                    new CharacteristicsValue{ guid = Guid.Parse("deea6c54-e0ad-e711-80e2-fa163e105d63"),value="3"},
                                    new CharacteristicsValue{ guid = Guid.Parse("77285760-e0ad-e711-80e2-fa163e105d63"),value="4"},
                                    new CharacteristicsValue{ guid = Guid.Parse("3377ce76-e0ad-e711-80e2-fa163e105d63"),value="5"},
                                    new CharacteristicsValue{ guid = Guid.Parse("e65b8e8a-e0ad-e711-80e2-fa163e105d63"),value="6"}

                                },
                                selectedProdCharValues = null
                            },
                            new Characteristics
                            {
                                guid = Guid.Parse("cd2ca4da-d3a9-e711-80e2-fa163e106136"),
                                guidOfProdChar= Guid.Parse("cd2ca4da-d3a9-e711-80e2-fa163e106136"),
                                type = "notcfss",
                                name = "Max Cuenta Correos",
                                dataType =831260000,
                                editable = true,
                                inputValue = "5",
                                ProdCharValues = new List<CharacteristicsValue>
                                {
                                    new CharacteristicsValue{ guid = Guid.Parse("1eda6e72-dead-e711-80e2-fa163e105d63"),value="1"},
                                    new CharacteristicsValue{ guid = Guid.Parse("fad9813a-e0ad-e711-80e2-fa163e105d63"),value="2"},
                                    new CharacteristicsValue{ guid = Guid.Parse("deea6c54-e0ad-e711-80e2-fa163e105d63"),value="3"},
                                    new CharacteristicsValue{ guid = Guid.Parse("77285760-e0ad-e711-80e2-fa163e105d63"),value="4"},
                                    new CharacteristicsValue{ guid = Guid.Parse("3377ce76-e0ad-e711-80e2-fa163e105d63"),value="5"},
                                    new CharacteristicsValue{ guid = Guid.Parse("e65b8e8a-e0ad-e711-80e2-fa163e105d63"),value="6"}

                                },
                                selectedProdCharValues = null
                            },
                            new Characteristics
                            {
                                guid = Guid.Parse("baf834f0-d3a9-e711-80e2-fa163e106136"),
                                guidOfProdChar= Guid.Parse("baf834f0-d3a9-e711-80e2-fa163e106136"),
                                type = "notcfss",
                                name = "Max Puntos Cableados",
                                dataType =831260000,
                                editable = false,
                                inputValue = "1",
                                ProdCharValues = new List<CharacteristicsValue>
                                {
                                    new CharacteristicsValue{ guid = Guid.Parse("1eda6e72-dead-e711-80e2-fa163e105d63"),value="1"},
                                    new CharacteristicsValue{ guid = Guid.Parse("fad9813a-e0ad-e711-80e2-fa163e105d63"),value="2"},
                                    new CharacteristicsValue{ guid = Guid.Parse("deea6c54-e0ad-e711-80e2-fa163e105d63"),value="3"},
                                    new CharacteristicsValue{ guid = Guid.Parse("77285760-e0ad-e711-80e2-fa163e105d63"),value="4"},
                                    new CharacteristicsValue{ guid = Guid.Parse("3377ce76-e0ad-e711-80e2-fa163e105d63"),value="5"},
                                    new CharacteristicsValue{ guid = Guid.Parse("e65b8e8a-e0ad-e711-80e2-fa163e105d63"),value="6"}

                                },
                                selectedProdCharValues = null
                            },
                            new Characteristics
                            {
                                guid = Guid.Parse("f4c36507-d4a9-e711-80e2-fa163e106136"),
                                guidOfProdChar= Guid.Parse("f4c36507-d4a9-e711-80e2-fa163e106136"),
                                type = "notcfss",
                                name = "Nro Puntos Cableadoss",
                                dataType =831260000,
                                editable = false,
                                inputValue = "0",
                                ProdCharValues = new List<CharacteristicsValue>
                                {
                                    new CharacteristicsValue{ guid = Guid.Parse("1eda6e72-dead-e711-80e2-fa163e105d63"),value="1"},
                                    new CharacteristicsValue{ guid = Guid.Parse("fad9813a-e0ad-e711-80e2-fa163e105d63"),value="2"},
                                    new CharacteristicsValue{ guid = Guid.Parse("deea6c54-e0ad-e711-80e2-fa163e105d63"),value="3"},
                                    new CharacteristicsValue{ guid = Guid.Parse("77285760-e0ad-e711-80e2-fa163e105d63"),value="4"},
                                    new CharacteristicsValue{ guid = Guid.Parse("3377ce76-e0ad-e711-80e2-fa163e105d63"),value="5"},
                                    new CharacteristicsValue{ guid = Guid.Parse("e65b8e8a-e0ad-e711-80e2-fa163e105d63"),value="6"}

                                },
                                selectedProdCharValues = null
                            }
            };

            var p = new ProductCharacteristicsModel
            {
                message = "updateShoppingCart",
                listOrderItems = new List<orderItem>
                {
                    // new orderItem{
                    //    guid = Guid.Parse("5ef2ef94-f6c1-e711-80e5-fa163e10dfbe"),
                    //    OfferingGuid = Guid.Parse("1ad1d488-fca9-e711-80e2-fa163e105d63"),
                    //    OfferingType = Guid.Empty,
                    //    name = "Equipo CPE HFC R2",
                    //    listProdChar =  new List<Characteristics>(),
                    //    PriceConfigurationGuid= Guid.Empty,
                    //    DepositPrice = null,
                    //    RecurringPrice = null,
                    //    OneTimePrice= null,
                    //    CheckOutPrice= null
                    //},
                    //new orderItem{
                    //    guid = Guid.Parse("19f2ef94-f6c1-e711-80e5-fa163e10dfbe"),
                    //    OfferingGuid = Guid.Parse("27c31fdd-c8bf-e711-80e5-fa163e10dfbe"),
                    //    OfferingType = Guid.Empty,
                    //    name = "Acceso HFC",
                    //    listProdChar =  new List<Characteristics>(),
                    //    PriceConfigurationGuid= Guid.Empty,
                    //    DepositPrice = null,
                    //    RecurringPrice = null,
                    //    OneTimePrice= null,
                    //    CheckOutPrice= null
                    //},
                    //new orderItem{
                    //    guid = Guid.Parse("0419ea30-f6c1-e711-80e5-fa163e10dfbe"),
                    //    OfferingGuid = Guid.Parse("222ea950-d5a9-e711-80e2-fa163e106136"),
                    //    OfferingType = Guid.Empty,
                    //    name = "Servicio Internet",
                    //    listProdChar =  new List<Characteristics>(),
                    //    PriceConfigurationGuid= Guid.Empty,
                    //    DepositPrice = null,
                    //    RecurringPrice = null,
                    //    OneTimePrice= null,
                    //    CheckOutPrice= null
                    //},
                    
                    new orderItem{
                        guid = Guid.Parse("c5ab417c-0cc2-e711-80e5-fa163e10dfbe"),
                        OfferingGuid = Guid.Parse("5a08abe0-b7a9-e711-80e2-fa163e106136"),
                        OfferingType = Guid.Empty,
                        name = "Plan Internet 10 Megas",
                        listProdChar =  chars,
                        PriceConfigurationGuid= Guid.Empty,
                        DepositPrice = null,
                        RecurringPrice = null,
                        OneTimePrice= null,
                        CheckOutPrice= null},new orderItem
                {
                    guid = Guid.Parse("15af8582-0cc2-e711-80e5-fa163e10dfbe"),
                    OfferingGuid = Guid.Parse("6208abe0-b7a9-e711-80e2-fa163e106136"),
                    OfferingType = Guid.Empty,
                    name = "Plan Internet 50 Megas",
                    listProdChar = chars2,
                    PriceConfigurationGuid = Guid.Empty,
                    DepositPrice = null,
                    RecurringPrice = null,
                    OneTimePrice = null,
                    CheckOutPrice = null
                },
            }            
            };


            var input = new Dictionary<string, object>()
            {
                { "ProductCharacteristicsModel",p }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.UpdateShoppingCart>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .ConfigureXrmDataContext()
                            .Invoke();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
