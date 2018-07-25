using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System.Web.Script.Serialization;
using AmxPeruPSBActivities.TechnicianAppGetResource;
using System.ServiceModel;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model;
using AmxPeruPSBActivities.Business;
using System.Net;
using System.Xml;
using System.IO;

namespace AmxPeruPSBActivities.Business
{
   public class AmxCoTechnicianAppGetResourceBusiness
    {
        
        public static string GetResourceInfo(AmxCoTechnicianAppGetResourceRequest req,string uri)
        {
            string technicianDetails = string.Empty;
            string Name = string.Empty;
            string Id = string.Empty;
            string parent_id = string.Empty;
            AmxCoTechnicianAppGetResourceBusiness obj = new AmxCoTechnicianAppGetResourceBusiness();
            var passwordDate = DateTime.Now.ToString("o").Remove(19, 8);
            var md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(passwordDate + "b85ed53b1b6b5c6ddf71afd69a47293e");
            byte[] hash = md5.ComputeHash(inputBytes);
            var password = obj.ToHex(hash, false);

            TechnicianAppGetResource.GetResourceRequest Oreourcereq = new TechnicianAppGetResource.GetResourceRequest
            {
                headerRequest = new TechnicianAppGetResource.HeaderRequest
                {
                    ipApplication=req.getResourceRequest.headerRequest.ipApplication,
                    traceabilityId= req.getResourceRequest.headerRequest.traceabilityId,
                    transactionId = req.getResourceRequest.headerRequest.transactionId,
                    system = req.getResourceRequest.headerRequest.system,
                    password =password, //req.getResourceRequest.headerRequest.password,
                    user = req.getResourceRequest.headerRequest.user,
                    requestDate =Convert.ToDateTime(passwordDate) //Convert.ToDateTime(req.getResourceRequest.headerRequest.requestDate)
                },
                
                company= req.getResourceRequest.company,
                id = req.getResourceRequest.id,
                date = req.getResourceRequest.date
               
            
            };
            var binding = new BasicHttpBinding { Name = "GetResorce", OpenTimeout = new TimeSpan(0, 15, 0), CloseTimeout = new TimeSpan(0, 15, 0), ReceiveTimeout = new TimeSpan(0, 15, 0), SendTimeout = new TimeSpan(0, 15, 0), };
            binding.MaxReceivedMessageSize = Int32.MaxValue;
            binding.MaxBufferSize = Int32.MaxValue;
            //var configValue = new AmxPeruPSBActivities.Repository.ConfigurationRepository().GetString(("");
            EndpointAddress endpointAddress = new EndpointAddress(uri);

            try
            {
                var client = new ConsultTechnicianInterfaceClient(binding, endpointAddress);
            
                var Oresp = new GetResourceResponse1();
                var headerResponse = new HeaderResponse();
                var Oresponce = new GetResourceResponse { };
                Oresponce = client.GetResource(Oreourcereq);
                if (Oresponce.Properties != null)
                {
                    foreach (var prop in Oresponce.Properties)
                    {
                        if (prop.attributeName == "name")
                        {
                            Name = prop.attributeValue;
                        }
                        if (prop.attributeName == "id")
                        {
                            Id = prop.attributeValue;
                        }
                        if (prop.attributeName == "parent_id")
                        {
                            parent_id = prop.attributeValue;
                        }
                    }
                    technicianDetails = Name + ";" + Id + ";" + parent_id;
                }
                return technicianDetails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
           
        }
        public string ToHex(byte[] bytes, bool upperCase)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));

            return result.ToString();
        }
    }
}
