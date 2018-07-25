using AmxPeruPSBActivities.Repository;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AmxPeruPSBActivities.ModelClaroESB
{
    public class ClaroESBInterfaceHeaderRequest
    {
        public string transactionId { get; set; }
        public string system { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string requestDate { get; set; }
        public string ipApplication { get; set; }

        public ClaroESBInterfaceHeaderRequest(OrganizationServiceProxy _org, string interfaceName)
        {
            this.transactionId = DateTime.Now.Ticks.ToString();
            this.requestDate = DateTime.Now.ToString("s");

            string crmConfiguration = CRMConfiguration.GetStringValue("ClaroESB_"+ interfaceName + "_Header", _org);

            var jss = new JavaScriptSerializer();
            var dict = jss.Deserialize<Dictionary<string, string>>(crmConfiguration);

            this.ipApplication = dict["ipApplication"];
            this.system = dict["system"];
            this.user = dict["user"];
            this.password = dict["password"];
        }
    }
}
