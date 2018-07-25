using Ericsson.ETELCRM.CrmFoundationLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Helpers
{
    class ConfigurationBuilder
    {
        public static RestConfigurationModel Build(string configurationString, string ermsAuthtoken = "", string userName = "")
        {
            var headers = new Dictionary<string, string> {
                    { "erms-auth-token", ermsAuthtoken }
            };
            if (!String.IsNullOrWhiteSpace(userName))
            {
                headers.Add("tcrm-username", userName);
            }
            //In the future this string can be turned into something like this;
            //Url=http://address/;CN=...;
            return new RestConfigurationModel
            {
                Url = configurationString,
                Headers = headers
            };
        }

    }
}
