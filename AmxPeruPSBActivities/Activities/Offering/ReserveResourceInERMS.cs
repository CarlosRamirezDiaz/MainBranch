using AmxPeruPSBActivities.Model.AvailableStocks;
using AmxPeruPSBActivities.Model.ERMSReserveResource;
using Ericsson.ETELCRM.Business;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace AmxPeruPSBActivities.Activities.Offering
{
    public class ReservationResponseModel
    {
        public string Status { get; set; }
        public string resourceId { get; set; }
        public string returnVal { get; set; }
    }

    public class ReserveResourceInERMS : XrmAwareCodeActivity
    {
        public InArgument<Guid> OrderResourceId { get; set; }
        public InArgument<string> PartNumber { get; set; }
        public InArgument<string> ResourceId { get; set; }
        //public OutArgument<string> BiHeaderId { get; set; }
        public OutArgument<ReservationResponseModel> ResponseModel { get; set; }

        Dictionary<string, string> listOfConfigKeyValues = new Dictionary<string, string>();

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {

            //Get Config values
            string fetchConfigVal = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                          <entity name='amxperu_amxconfigurations'>
                                            <attribute name='amxperu_amxconfigurationsid' />
                                            <attribute name='amxperu_name' />
                                            <attribute name='amxperu_value' />
                                            <attribute name='createdon' />
                                            <order attribute='amxperu_name' descending='false' />
                                            <filter type='and'>
                                              <filter type='or'>
                                                <condition attribute='amxperu_name' operator='eq' value='ErmsApplicationUser' />
                                                <condition attribute='amxperu_name' operator='eq' value='ErmsUserPassword' />
                                                <condition attribute='amxperu_name' operator='eq' value='ActiveDirectoryDomainName' />
                                                <condition attribute='amxperu_name' operator='eq' value='ErmsApplicationUriExternal' />
                                                <condition attribute='amxperu_name' operator='eq' value='ErmsApplicationUserGuid' />
                                              </filter>
                                            </filter>
                                          </entity>
                                        </fetch>";

            EntityCollection configCollection = ContextProvider.OrganizationService.RetrieveMultiple(new FetchExpression(fetchConfigVal));
            if (configCollection != null)
            {
                if (configCollection.Entities.Count > 0)
                {
                    foreach (Entity configItem in configCollection.Entities)
                    {
                        listOfConfigKeyValues.Add(configItem.Attributes["amxperu_name"].ToString(), configItem.Attributes["amxperu_value"].ToString());
                    }
                }
            }
            //Get Config values

            var orderResourceId = OrderResourceId.Get(context);
            var partNumber = PartNumber.Get(context);
            var resourceId = ResourceId.Get(context);

            //CallERMSServicesToReserveResource(context, partNumber, resourceId);
            var retFromErms = CallERMSServicesToReserveResource(context, partNumber, resourceId);

            if (retFromErms != "Failure")
            {
                UpdateTRCM(orderResourceId.ToString(), resourceId);
                //UpdateTRCM(orderResourceId.ToString(), resourceId, retFromErms);
                ReservationResponseModel model = new ReservationResponseModel()
                {
                    resourceId = resourceId,
                    Status = "success",
                    returnVal = retFromErms
                };
                ResponseModel.Set(context, model);
            }
            else
            {
                ReservationResponseModel model1 = new ReservationResponseModel()
                {
                    resourceId = resourceId,
                    Status = "failure"
                };
                ResponseModel.Set(context, model1);
            }
        }

        protected void UpdateTRCM(string orderResourceId, string resource, string returnValFromService = "")
        {
            try
            {
                Entity orderResource = new Entity();
                orderResource.LogicalName = "etel_orderresource";
                orderResource.Id = new Guid(orderResourceId); //order resource id
                orderResource.Attributes["etel_value"] = resource; //selected resource value from screen;
                orderResource.Attributes["etel_reservationid"] = returnValFromService;
                ContextProvider.OrganizationService.Update(orderResource);
            }
            catch
            {

            }
        }

        public string CallERMSServicesToReserveResource(CodeActivityContext context, string partNumber, string resourceId)
        {
            try
            {
                string ermsIp = string.Empty;
                listOfConfigKeyValues.TryGetValue("ErmsApplicationUriExternal", out ermsIp);

                string ermsUderGuid = string.Empty;
                listOfConfigKeyValues.TryGetValue("ErmsApplicationUserGuid", out ermsUderGuid);

                //Testing from Local
                //ermsIp = "10.103.27.154:9002";

                PsbConfigurationBusiness configurationBusiness = new PsbConfigurationBusiness(context);

                //TODO:User Guid is Hard Coded
                #region Create BI Session in ERMS
                var urlsession =
                    //String.Format("http://{0}/api/V1/DTCLabSessionFacade/GetOrStartSession?UserId=86206844-685a-45a7-a75e-b5b373eec756", ermsIp);
                    String.Format("http://{0}/api/V1/DTCLabSessionFacade/GetOrStartSession?UserId=" + ermsUderGuid, ermsIp);
                var response = SendGetRequest(urlsession);
                #endregion

                #region /GetAvailableStock
                //var _ermsMEthodBroker = new AvailableStockBroker();
                //var ermsResponse = _ermsMEthodBroker.GetAvailableStock(context, partNumber, Identity?.Name);
                //var ermsResult = (AvailableStockResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(ermsResponse, typeof(AvailableStockResponse));

                var urlForGetStock = String.Format("http://{0}/api/V1/ManageInventoryFacade/GetSellableStockLevel", ermsIp);
                var request = new { PartNumber = partNumber, PageSize = Int32.MaxValue - 1 };
                var availableStockRequest = Newtonsoft.Json.JsonConvert.SerializeObject(request);
                var ermsResponse = SendRestRequest(availableStockRequest, urlForGetStock);
                var ermsResult = (AvailableStockResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(ermsResponse,
                    typeof(AvailableStockResponse));
                #endregion

                var SIM_To_Reserve =
                    ermsResult.Items.Where(a => a.StartSerialNumber == resourceId).FirstOrDefault();

                #region Retrieve Single Product (SIM): Return Object: obj_GetProductsBySerialNumberWithSpecs
                var url = String.Format("http://{0}/api/V1/IMFacade/GetProductsBySerialNumberWithSpecs", ermsIp);

                #region Json Request
                var request_GetProductsBySerialNumberWithSpecs = "{" +
                                        "	\"SerialNumber\":\"" + resourceId + "\"," +
                                        "	\"ProductSpecificationId\": \"" + SIM_To_Reserve.ProductSpecificationId + "\"" +
                                        "}";
                #endregion

                var response_GetProductsBySerialNumberWithSpecs = SendRestRequest(request_GetProductsBySerialNumberWithSpecs, url);
                var obj_GetProductsBySerialNumberWithSpecs =
                    (GetProductsBySerialNumberWithSpecsResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(response_GetProductsBySerialNumberWithSpecs, typeof(GetProductsBySerialNumberWithSpecsResponse));
                #endregion

                var product = obj_GetProductsBySerialNumberWithSpecs.Products.FirstOrDefault();

                #region /SaveAsDraft : Return Id: obj_SaveDraft
                url = String.Format("http://{0}/api/V1/IMFacade/SaveAsDraft", ermsIp);

                #region Json Request
                var request1_SaveDraft = "{" +
                                        "   \"BusinessInteraction\":{" +
                                        "      \"$type\":\"Ericsson.ERMS.Facade.Models.ViewModels.ProductReservationModel, Ericsson.ERMS.Facade\"," +
                                        "      \"ReservationDuration\":{" +
                                        "         \"Value\":1," +
                                        "         \"Unit\":2" +
                                        "      }," +
                                        "      \"CustomFields\":{" +
                                        "         \"$type\":\"System.Collections.Hashtable, mscorlib\"" +
                                        "      }" +
                                        "   }" +
                                        "}";
                #endregion

                var response1_SaveDraft = SendRestRequest(request1_SaveDraft, url);
                var obj_SaveDraft =
                    (SaveAsDraftResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(response1_SaveDraft, typeof(SaveAsDraftResponse));
                #endregion

                #region /SaveItem
                url = String.Format("http://{0}/api/V1/IMFacade/SaveItem", ermsIp);

                #region Json Request
                var request2_SaveItem = "{" +
                                        "   \"Item\":{" +
                                        "      \"$type\":\"Ericsson.ERMS.Facade.Models.ViewModels.ProductReservationItemModel, Ericsson.ERMS.Facade\"," +
                                        "      \"BusinessInteraction\":{" +
                                        "         \"$type\":\"Ericsson.ERMS.Facade.Models.ViewModels.ProductReservationModel, Ericsson.ERMS.Facade\"," +
                                        "         \"ReservationDuration\":{" +
                                        "            \"Value\":1," +
                                        "            \"Unit\":2" +
                                        "         }," +
                                        "         \"Id\":\"{draftId}\"," +
                                        "         \"CreateDate\":\"Mon, 21 Aug 2017 08:47:39 GMT\"," +
                                        "         \"Description\":null," +
                                        "         \"Code\":\"{code}\"," +
                                        "         \"Status\":0," +
                                        "         \"SubmitDate\":null," +
                                        "         \"CustomFields\":{" +
                                        "            \"$type\":\"System.Collections.Hashtable, mscorlib\"" +
                                        "         }" +
                                        "      }," +
                                        "      \"Product\":{" +
                                        "         \"$type\":\"Ericsson.ERMS.Facade.Models.ViewModels.ProductComponentModel, Ericsson.ERMS.Facade\"," +
                                        "         \"Id\":\"{productId}\"," +
                                        "         \"Description\":\"{description}\"," +
                                        "         \"ProductTrackingType\":{trackingType}," +
                                        "         \"StartSerialNumber\":\"{startSerial}\"," +
                                        "         \"EndSerialNumber\":\"{endSerial}\"," +
                                        "         \"SerialText\":\"\"," +
                                        "         \"Quantity\":1," +
                                        "         \"CharacteristicDescription\":\"{chDescription}\"," +
                                        "         \"Status\":1" +
                                        "      }," +
                                        "      \"ProductSpecification\":{" +
                                        "         \"$type\":\"Ericsson.ERMS.Facade.Models.ViewModels.AtomicProductSpecificationModel, Ericsson.ERMS.Facade\"" +
                                        "      }," +
                                        "      \"Status\":1," +
                                        "      \"Quantity\":1," +
                                        "      \"StartSerial\":\"{prodSpecStart}\"," +
                                        "      \"EndSerial\":\"{prodSpecEnd}\"" +
                                        "   }" +
                                        "}";

                //request2_SaveItem
                //request2_SaveItem = System.IO.File.ReadAllText(@"c:\json\req.txt");
                request2_SaveItem = request2_SaveItem.Replace("{draftId}", obj_SaveDraft.Id);
                request2_SaveItem = request2_SaveItem.Replace("{code}", obj_SaveDraft.Code);
                request2_SaveItem = request2_SaveItem.Replace("{productId}", product.Id);
                request2_SaveItem = request2_SaveItem.Replace("{description}", SIM_To_Reserve.Description);
                request2_SaveItem = request2_SaveItem.Replace("{trackingType}", product.ProductTrackingType.ToString());
                request2_SaveItem = request2_SaveItem.Replace("{startSerial}", SIM_To_Reserve.StartSerialNumber);
                request2_SaveItem = request2_SaveItem.Replace("{endSerial}", SIM_To_Reserve.StartSerialNumber);
                request2_SaveItem = request2_SaveItem.Replace("{chDescription}", SIM_To_Reserve.CharacteristicDescription);
                request2_SaveItem = request2_SaveItem.Replace("{prodSpecStart}", SIM_To_Reserve.StartSerialNumber);
                request2_SaveItem = request2_SaveItem.Replace("{prodSpecEnd}", SIM_To_Reserve.StartSerialNumber);

                #endregion

                var response2_SaveItem = SendRestRequest(request2_SaveItem, url);
                var obj_SaveItem =
                    (SaveItemResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(response2_SaveItem, typeof(SaveItemResponse));

                url = String.Format("http://{0}/api/V1/IMFacade/Submit", ermsIp);
                var json = "{\"BusinessInteractionId\":\"" + obj_SaveDraft.Id + "\"}";
                var res = SendRestRequest(json, url); //Response From ERMS After Reserve

                return obj_SaveItem.BusinessInteractionItemId;
                #endregion
            }
            catch (Exception ex)
            {
                return "Failure";
            }
        }

        private string SendRestRequest(string PaymentDeposit, string url)
        {
            var jsonResponse = string.Empty;

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);

            string ermsUser = string.Empty;
            string ermsUserPassword = string.Empty;
            string ermsUserDomain = string.Empty;
            listOfConfigKeyValues.TryGetValue("ErmsApplicationUser", out ermsUser);
            listOfConfigKeyValues.TryGetValue("ErmsUserPassword", out ermsUserPassword);
            listOfConfigKeyValues.TryGetValue("ActiveDirectoryDomainName", out ermsUserDomain);

            webrequest.Credentials = new NetworkCredential(ermsUser, ermsUserPassword, ermsUserDomain);
            webrequest.Method = "POST";
            webrequest.ContentType = "application/json";
            using (Stream webStream = webrequest.GetRequestStream())

            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(PaymentDeposit);
            }

            var webResponse = (HttpWebResponse)webrequest.GetResponse();
            using (Stream webStream = webResponse.GetResponseStream())
            {
                if (webStream != null)
                {
                    using (StreamReader responseReader = new StreamReader(webStream))
                    {
                        jsonResponse = responseReader.ReadToEnd();
                    }
                }
            }

            return jsonResponse;
        }

        private string SendGetRequest(string url)
        {
            var jsonResponse = string.Empty;

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            //webrequest.Credentials = new NetworkCredential("ermsuser", "Ericsson2016", "TCRM32LAB");
            webrequest.Credentials = new NetworkCredential("dtcuser", "Ericsson2016", "TCRM32LAB");
            webrequest.Method = "GET";

            var webResponse = (HttpWebResponse)webrequest.GetResponse();
            using (Stream webStream = webResponse.GetResponseStream())
            {
                if (webStream != null)
                {
                    using (StreamReader responseReader = new StreamReader(webStream))
                    {
                        jsonResponse = responseReader.ReadToEnd();
                    }
                }
            }

            return jsonResponse;
        }
    }
}
