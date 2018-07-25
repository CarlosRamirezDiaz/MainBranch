using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static AmxPeruTest.Helpers.TestHelper;
using AmxPeruPSBActivities.Activities.OrderItem;
using AmxPeruPSBActivities.Model;
using System.Collections.Generic;
using AmxPeruPSBWorkflows;
using Newtonsoft.Json;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class AmxPeruGetOfferingPricesTest
    {
        [TestMethod]
        public void ProductOfferingSyncSuccess()
        {
            var input = new Dictionary<string, object>()
            {
                   { "productOfferingRequest",
                            new AmxPeruPSBActivities.Model.ProductOfferingSync.ProductOfferingRequest
                            {
                                ProductOfferingList =
                                new List<AmxPeruPSBActivities.Model.ProductOfferingSync.ProductOffering>()
                                {
                                    new AmxPeruPSBActivities.Model.ProductOfferingSync.ProductOffering
                                    {
                                            ExternalId = "1",
                                            Name="PO1",
                                            ProductSpecification = new AmxPeruPSBActivities.Model.ProductOfferingSync.ProductSpecification()
                                            {
                                                ExternalId="1",
                                                Name="PS1",
                                                CFSSList = new List<AmxPeruPSBActivities.Model.ProductOfferingSync.CFSS>()
                                                {
                                                    new AmxPeruPSBActivities.Model.ProductOfferingSync.CFSS
                                                    {
                                                        ExternalId="1",
                                                        Name="CFSS1"
                                                    }
                                                }
                                            },
                                            CharacteristicList = new List<AmxPeruPSBActivities.Model.ProductOfferingSync.Characteristic>()
                                            {
                                                new AmxPeruPSBActivities.Model.ProductOfferingSync.Characteristic
                                                {
                                                    ExternalId="1",
                                                    Name="Char1",
                                                    CharacteristicValueList = new List<AmxPeruPSBActivities.Model.ProductOfferingSync.CharacteristicValue>()
                                                    {
                                                        new AmxPeruPSBActivities.Model.ProductOfferingSync.CharacteristicValue
                                                        {
                                                            ExternalId="1",
                                                            Value="Value1"
                                                        }
                                                    }
                                                }
                                            }                                            
                                    }
                                }
                            }
                    }
            };



            try
            {
                var jsonSerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };
                var j = Newtonsoft.Json.JsonConvert.SerializeObject(input, jsonSerializerSettings);

                var result = WorkflowHelper.PrepareFor<ProductOfferingSync>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        [TestMethod]
        public void AmxPeruGetOfferingPricesSuccess()
        {
            var input = new Dictionary<string, object>()
            {
                            { "testtest",
                            new AmxPeruOfferingPriceModel
                            {
                                OrderId="0379638E-7683-E711-8126-00505601173A",
                                OrderItemList = new List<Offering>()
                                {
                                    new Offering
                                    {
                                            OfferingId = "481E958E-867E-E711-8126-00505601173A",
                                            OrderItemId="9EC6DEAE-7683-E711-8126-00505601173A",
                                            CharacteristicList = new List<Characteristic>()
                                            {
                                                new Characteristic
                                                {
                                                    CharacteristicId="7C212435-137D-E711-8126-00505601173A",
                                                    ValueList = new List<Value>()
                                                    {
                                                        new Value
                                                        {
                                                            ValueText="",
                                                            ValueId="7CCE554A-137D-E711-8126-00505601173A"
                                                        }
                                                    }

                            },
                            new Characteristic
                            {
                                CharacteristicId="C14A1A75-137D-E711-8126-00505601173A",
                                ValueList = new List<Value>()
                                {
                                    new Value
                                    {
                                        ValueText="",
                                        ValueId="61801182-137D-E711-8126-00505601173A"
                                    }
                                }

                            }
                        }
                }
            }
        }
                            }
            };

            var x = "{\"$type\":\"AmxPeruPSBActivities.Model.AmxPeruOfferingPriceModel, AmxPeruPSBActivities\",\"OrderId\":\"E273972D-9089-E711-8126-00505601173A\",\"OrderItemList\":{\"$type\":\"System.Collections.Generic.List`1[[AmxPeruPSBActivities.Model.Offering, AmxPeruPSBActivities]], mscorlib\",\"$values\":[{\"OfferingId\":\"481e958e-867e-e711-8126-00505601173a\",\"OfferingName\":\"ClaroMax189_1\",\"OrderItemId\":\"1952c9ea-368c-e711-8129-00505601173a\",\"CharacteristicList\":{\"$type\":\"System.Collections.Generic.List`1[[AmxPeruPSBActivities.Model.Characteristic, AmxPeruPSBActivities]], mscorlib\",\"$values\":[{\"CharacteristicId\":\"c14a1a75-137d-e711-8126-00505601173a\",\"CharacteristicName\":\"FAFCount\",\"ValueList\":{\"$type\":\"System.Collections.Generic.List`1[[AmxPeruPSBActivities.Model.Value, AmxPeruPSBActivities]], mscorlib\",\"$values\":[{\"ValueId\":\"\",\"ValueText\":\"14\"}]}},{\"CharacteristicId\":\"7c212435-137d-e711-8126-00505601173a\",\"CharacteristicName\":\"FAFMode\",\"ValueList\":{\"$type\":\"System.Collections.Generic.List`1[[AmxPeruPSBActivities.Model.Value, AmxPeruPSBActivities]], mscorlib\",\"$values\":[{\"ValueId\":\"84ba96d3-147d-e711-8126-00505601173a\",\"ValueText\":\"FAFPlus\"}]}}]}},{\"OfferingId\":\"a762dcc7-897e-e711-8126-00505601173a\",\"OfferingName\":\"ClaroMax SMS 200\",\"OrderItemId\":\"90593af2-368c-e711-8129-00505601173a\",\"CharacteristicList\":{\"$type\":\"System.Collections.Generic.List`1[[AmxPeruPSBActivities.Model.Characteristic, AmxPeruPSBActivities]], mscorlib\",\"$values\":[]}}]}}";
            var j = Newtonsoft.Json.JsonConvert.DeserializeObject(x, typeof(AmxPeruOfferingPriceModel));
            input = new Dictionary<string, object>()
            {
                { "testtest",j }
            };

            try
            {

                var result = WorkflowHelper.PrepareFor<AmxPeruGetOfferingPrice>(input)
                            .ConfigureFor("connectionString", ConfigurationHelper.URL)
                            .Invoke();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}
