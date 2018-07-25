using Ericsson.ETELCRM.Business;
using Ericsson.ETELCRM.Entities.Crm;
using Ericsson.ETELCRM.Repository;
using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Service.AvailableStocks
{
    class AvailableStockBroker
    {
        public string GetAvailableStock(CodeActivityContext context, string partNumber, string userId)
        {
            PsbConfigurationBusiness configurationBusiness = new PsbConfigurationBusiness(context);
            //var url = configurationBusiness.RetrieveCrmConfigurationByName(CRMConfigurationEntry.BIL_IndividualPaymentDeposit_URL.ToString());

            var url = "http://10.103.27.154:9002/api/V1/ManageInventoryFacade/GetSellableStockLevel";
            url = "http://10.61.100.13:9002/api/V1/ManageInventoryFacade/GetSellableStockLevel";

            var request = new {
                PartNumber = partNumber,
                // Agregated = true,
                // UserId = userId,
            };

            var availableStockRequest = Newtonsoft.Json.JsonConvert.SerializeObject(request);

            return SendRestRequest(availableStockRequest, url);
            // return "{\r\n    \"$type\": \"<>f__AnonymousType12`2[[System.Collections.Generic.IEnumerable`1[[Ericsson.ERMS.Entities.IM.Models.StockLevelItem, Ericsson.ERMS.Entities]], mscorlib],[<>f__AnonymousType41`4[[System.Int32, mscorlib],[System.Int32, mscorlib],[System.Int32, mscorlib],[System.Int32, mscorlib]], Ericsson.ERMS.Facade]], Ericsson.ERMS.Facade\",\r\n    \"Items\": [\r\n        {\r\n            \"$type\": \"Ericsson.ERMS.Entities.IM.Models.StockLevelItem, Ericsson.ERMS.Entities\",\r\n            \"Description\": \"iPhone 6\",\r\n            \"ProductSpecificationId\": \"d34cf602-4370-454f-ac11-46401a0429dc\",\r\n            \"CharacteristicDescription\": \"Screen Type: Gorilla Glass,Internal Memory: 16 GB,Color: Black\",\r\n            \"CharacteristicHashCode\": \"8768C46CBF927558588D6162A18AE058B563E2A6240D0DB8F6E04E5432FC77EA42920C04CA38FFCE827C31757EC1B008A83234E7C3981D186BFD0C7CB95351F7\",\r\n            \"Status\": 1,\r\n            \"Quantity\": 3,\r\n            \"SalesOrganizationRoleName\": \"CAC1 Lima\",\r\n            \"SalesOrganizationRoleId\": \"a9eccae4-e88a-48bb-8e7c-2864c1a1aa11\",\r\n            \"PlaceName\": \"CAC 1 Lima Sales Inventory\",\r\n            \"PlaceId\": \"87e88ed7-4119-4469-b371-0102419dec80\",\r\n            \"PlaceType\": 2,\r\n            \"LockingBIType\": 0,\r\n            \"LockingBIId\": \"00000000-0000-0000-0000-000000000000\",\r\n            \"LockingBICode\": null,\r\n            \"TotalRecords\": 6,\r\n            \"Article\": \"AIP6\",\r\n            \"StartSerialNumber\": \"N/A\",\r\n            \"EndSerialNumber\": \"N/A\"\r\n        },\r\n        {\r\n            \"$type\": \"Ericsson.ERMS.Entities.IM.Models.StockLevelItem, Ericsson.ERMS.Entities\",\r\n            \"Description\": \"iPhone 6\",\r\n            \"ProductSpecificationId\": \"d34cf602-4370-454f-ac11-46401a0429dc\",\r\n            \"CharacteristicDescription\": \"Screen Type: Gorilla Glass,Internal Memory: 16 GB,Color: Black\",\r\n            \"CharacteristicHashCode\": \"8768C46CBF927558588D6162A18AE058B563E2A6240D0DB8F6E04E5432FC77EA42920C04CA38FFCE827C31757EC1B008A83234E7C3981D186BFD0C7CB95351F7\",\r\n            \"Status\": 1,\r\n            \"Quantity\": 1,\r\n            \"SalesOrganizationRoleName\": \"CAC1 Lima\",\r\n            \"SalesOrganizationRoleId\": \"a9eccae4-e88a-48bb-8e7c-2864c1a1aa11\",\r\n            \"PlaceName\": \"CAC 1 Lima Sales Inventory\",\r\n            \"PlaceId\": \"87e88ed7-4119-4469-b371-0102419dec80\",\r\n            \"PlaceType\": 2,\r\n            \"LockingBIType\": 0,\r\n            \"LockingBIId\": \"2d444c1c-a56e-40de-8e58-5310ab20e716\",\r\n            \"LockingBICode\": \"PT-137\",\r\n            \"TotalRecords\": 6,\r\n            \"Article\": \"AIP6\",\r\n            \"StartSerialNumber\": \"N/A\",\r\n            \"EndSerialNumber\": \"N/A\"\r\n        },\r\n        {\r\n            \"$type\": \"Ericsson.ERMS.Entities.IM.Models.StockLevelItem, Ericsson.ERMS.Entities\",\r\n            \"Description\": \"iPhone 6\",\r\n            \"ProductSpecificationId\": \"d34cf602-4370-454f-ac11-46401a0429dc\",\r\n            \"CharacteristicDescription\": \"Screen Type: Gorilla Glass,Internal Memory: 16 GB,Color: Black\",\r\n            \"CharacteristicHashCode\": \"8768C46CBF927558588D6162A18AE058B563E2A6240D0DB8F6E04E5432FC77EA42920C04CA38FFCE827C31757EC1B008A83234E7C3981D186BFD0C7CB95351F7\",\r\n            \"Status\": 1,\r\n            \"Quantity\": 3,\r\n            \"SalesOrganizationRoleName\": \"CAC1 Lima\",\r\n            \"SalesOrganizationRoleId\": \"a9eccae4-e88a-48bb-8e7c-2864c1a1aa11\",\r\n            \"PlaceName\": \"CAC 1 Lima Sales Inventory\",\r\n            \"PlaceId\": \"87e88ed7-4119-4469-b371-0102419dec80\",\r\n            \"PlaceType\": 2,\r\n            \"LockingBIType\": 0,\r\n            \"LockingBIId\": \"8a2a1f30-487f-4f19-a2e4-892187593398\",\r\n            \"LockingBICode\": \"PT-143\",\r\n            \"TotalRecords\": 6,\r\n            \"Article\": \"AIP6\",\r\n            \"StartSerialNumber\": \"N/A\",\r\n            \"EndSerialNumber\": \"N/A\"\r\n        },\r\n        {\r\n            \"$type\": \"Ericsson.ERMS.Entities.IM.Models.StockLevelItem, Ericsson.ERMS.Entities\",\r\n            \"Description\": \"iPhone 6\",\r\n            \"ProductSpecificationId\": \"d34cf602-4370-454f-ac11-46401a0429dc\",\r\n            \"CharacteristicDescription\": \"Screen Type: Gorilla Glass,Internal Memory: 16 GB,Color: Black\",\r\n            \"CharacteristicHashCode\": \"8768C46CBF927558588D6162A18AE058B563E2A6240D0DB8F6E04E5432FC77EA42920C04CA38FFCE827C31757EC1B008A83234E7C3981D186BFD0C7CB95351F7\",\r\n            \"Status\": 1,\r\n            \"Quantity\": 1,\r\n            \"SalesOrganizationRoleName\": \"CAC1 Lima\",\r\n            \"SalesOrganizationRoleId\": \"a9eccae4-e88a-48bb-8e7c-2864c1a1aa11\",\r\n            \"PlaceName\": \"CAC 1 Lima Sales Inventory\",\r\n            \"PlaceId\": \"87e88ed7-4119-4469-b371-0102419dec80\",\r\n            \"PlaceType\": 2,\r\n            \"LockingBIType\": 0,\r\n            \"LockingBIId\": \"28efa3a8-59b7-464a-90e8-a7b7ef03a998\",\r\n            \"LockingBICode\": \"PT-140\",\r\n            \"TotalRecords\": 6,\r\n            \"Article\": \"AIP6\",\r\n            \"StartSerialNumber\": \"N/A\",\r\n            \"EndSerialNumber\": \"N/A\"\r\n        },\r\n        {\r\n            \"$type\": \"Ericsson.ERMS.Entities.IM.Models.StockLevelItem, Ericsson.ERMS.Entities\",\r\n            \"Description\": \"iPhone 6\",\r\n            \"ProductSpecificationId\": \"d34cf602-4370-454f-ac11-46401a0429dc\",\r\n            \"CharacteristicDescription\": \"Screen Type: Gorilla Glass,Internal Memory: 16 GB,Color: Black\",\r\n            \"CharacteristicHashCode\": \"8768C46CBF927558588D6162A18AE058B563E2A6240D0DB8F6E04E5432FC77EA42920C04CA38FFCE827C31757EC1B008A83234E7C3981D186BFD0C7CB95351F7\",\r\n            \"Status\": 1,\r\n            \"Quantity\": 2,\r\n            \"SalesOrganizationRoleName\": \"CAC1 Lima\",\r\n            \"SalesOrganizationRoleId\": \"a9eccae4-e88a-48bb-8e7c-2864c1a1aa11\",\r\n            \"PlaceName\": \"CAC 1 Lima Sales Inventory\",\r\n            \"PlaceId\": \"87e88ed7-4119-4469-b371-0102419dec80\",\r\n            \"PlaceType\": 2,\r\n            \"LockingBIType\": 0,\r\n            \"LockingBIId\": \"a435a8a9-22ac-4641-891a-ae84960f6323\",\r\n            \"LockingBICode\": \"PT-139\",\r\n            \"TotalRecords\": 6,\r\n            \"Article\": \"AIP6\",\r\n            \"StartSerialNumber\": \"N/A\",\r\n            \"EndSerialNumber\": \"N/A\"\r\n        },\r\n        {\r\n            \"$type\": \"Ericsson.ERMS.Entities.IM.Models.StockLevelItem, Ericsson.ERMS.Entities\",\r\n            \"Description\": \"iPhone 6\",\r\n            \"ProductSpecificationId\": \"d34cf602-4370-454f-ac11-46401a0429dc\",\r\n            \"CharacteristicDescription\": \"Screen Type: Gorilla Glass,Internal Memory: 16 GB,Color: Black\",\r\n            \"CharacteristicHashCode\": \"8768C46CBF927558588D6162A18AE058B563E2A6240D0DB8F6E04E5432FC77EA42920C04CA38FFCE827C31757EC1B008A83234E7C3981D186BFD0C7CB95351F7\",\r\n            \"Status\": 1,\r\n            \"Quantity\": 2,\r\n            \"SalesOrganizationRoleName\": \"CAC1 Lima\",\r\n            \"SalesOrganizationRoleId\": \"a9eccae4-e88a-48bb-8e7c-2864c1a1aa11\",\r\n            \"PlaceName\": \"CAC 1 Lima Sales Inventory\",\r\n            \"PlaceId\": \"87e88ed7-4119-4469-b371-0102419dec80\",\r\n            \"PlaceType\": 2,\r\n            \"LockingBIType\": 0,\r\n            \"LockingBIId\": \"f3ef19c5-cf19-4575-92ba-e92217eabab2\",\r\n            \"LockingBICode\": \"PT-142\",\r\n            \"TotalRecords\": 6,\r\n            \"Article\": \"AIP6\",\r\n            \"StartSerialNumber\": \"N/A\",\r\n            \"EndSerialNumber\": \"N/A\"\r\n        }\r\n    ],\r\n    \"PageInfo\": {\r\n        \"$type\": \"<>f__AnonymousType41`4[[System.Int32, mscorlib],[System.Int32, mscorlib],[System.Int32, mscorlib],[System.Int32, mscorlib]], Ericsson.ERMS.Facade\",\r\n        \"PageSize\": 2147483646,\r\n        \"CurrentPage\": 1,\r\n        \"TotalCount\": 6,\r\n        \"TotalPages\": 1\r\n    }\r\n}\r\n";
        }

        private static string SendRestRequest(string request, string url)
        {
            var jsonResponse = string.Empty;

            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Credentials = new NetworkCredential("dtcuser", "Ericsson2016", "TCRM32LAB");
            webrequest.Method = "POST";
            webrequest.ContentType = "application/json";
            using (Stream webStream = webrequest.GetRequestStream())

            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(request);
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
    }
}
