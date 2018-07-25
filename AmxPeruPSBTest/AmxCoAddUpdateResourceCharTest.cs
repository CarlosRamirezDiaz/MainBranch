using AmxCoPSBActivities.AMXCOLOMBIA.Activities.Configuration;
using AmxCoPSBActivities.AMXCOLOMBIA.Model;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model;
using AmxPeruPSBActivities.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using Newtonsoft.Json;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static AmxPeruTest.Helpers.TestHelper;

namespace AmxPeruPSBTest
{
    [TestClass]
    public class AmxCoAddUpdateResourceCharTest
    {
        [TestMethod]
        public void AddUpdateResourceCharTest()
        {
            var updateResourceBusiness = new AmxPeruPSBActivities.AMXCOLOMBIA.Business.AddUpdateOrderResourceBusiness();
            AmxCoOrderResourceModelInput orderResource = new AmxCoOrderResourceModelInput();
            List<AmxCoOrderResourceCharModelInput> orderResourceCharList = new List<AmxCoOrderResourceCharModelInput>();
            AmxCoCreateUpdateResourceCharInput resourceCharInput = new AmxCoCreateUpdateResourceCharInput();

            //Build elements order resource
            /*orderResource.etel_name = "LRS Cuenta Correo";
            orderResource.etel_offeringid = "406AFCF4-FAA9-E711-80E2-FA163E105D63";
            orderResource.etel_productresourcespecification = "C32110E5-01AA-E711-80E2-FA163E105D63";
            orderResource.etel_value = "Cuenta Correo";
            orderResource.etel_orderitemid = "DAD4BF55-5CE0-E711-80E7-FA163E10DFBE";*/

            orderResource.etel_orderresourceid = null;
            orderResource.etel_orderitemid = "461acb6e-a2f7-e711-80ec-fa163e10dfbe";
            orderResource.etel_offeringid = "406afcf4-faa9-e711-80e2-fa163e105d63";
            orderResource.etel_name = "LRS Cuenta Correo";
            orderResource.etel_productresourcespecification = "c32110e5-01aa-e711-80e2-fa163e105d63";
            orderResource.etel_value = null;

            //Build elements order resource char
            orderResourceCharList.Add(new AmxCoOrderResourceCharModelInput
            {
                /*amx_resource_characteristic = "1BE1976E-E3E0-E711-80E7-FA163E10DFBE",
                amx_resource_characteristicvalue = "12498545-E4E0-E711-80E7-FA163E10DFBE",
                etel_selectedvalue = "TESTE1@teste.com",
                etel_datatypecode = "831260000",
                etel_value = "TESTE1@teste.com"*/

                etel_orderresourcecharactericid = "",
                etel_orderresourceid = null,
                amx_resource_characteristic = "1be1976e-e3e0-e711-80e7-fa163e10dfbe",
                amx_resource_characteristicvalue = "12498545-e4e0-e711-80e7-fa163e10dfbe",
                etel_selectedvalue = "",
                etel_datatypecode = "831260000",
                etel_value = "TESTESTESTES"
            }
            );
            /*orderResourceCharList.Add(new AmxCoOrderResourceCharModelInput
            {
                etel_orderresourcecharactericid = "",
                    etel_orderresourceid = null,
                    amx_resource_characteristic = "1BE1976E-E3E0-E711-80E7-FA163E10DFBE",
                    amx_resource_characteristicvalue = "12498545-E4E0-E711-80E7-FA163E10DFBE",
                    etel_selectedvalue = "",
                    etel_datatypecode = "831260000",
                    etel_value = "asdasdf@asdf.com"
            }
            );*/

            var _org = OrganizationProxy.GetOrganizationProxy();

            orderResource.orderResourceCharInputList = orderResourceCharList;

            resourceCharInput.orderResourceInputList = new List<AmxCoOrderResourceModelInput>();
            resourceCharInput.orderResourceInputList.Add(orderResource);


            var input = new Dictionary<string, object>()
            {
                {"inputModel", resourceCharInput }
            };

            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            var json = JsonConvert.SerializeObject(input, jsonSerializerSettings);

            try
            {
                // Business
                //updateResourceBusiness.CreateUpdateOrderResource(_org, orderResource, orderResourceCharList);

                // WF
                var result = WorkflowHelper.PrepareFor<AmxPeruPSBWorkflows.AMX_COLOMBIA.AmxCoCreteUpdateResourceChar>(input)
                        .ConfigureFor("connectionString", ConfigurationHelper.URL)
                        .Invoke();

                result.Count();
            }
            catch (Exception ex)
            { ex.Message.ToString(); }
        }
    }
}
