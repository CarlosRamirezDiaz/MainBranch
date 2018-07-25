using AmxPeruPSBActivities.AMXCOLOMBIA.Model;
using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.AMXCOLOMBIA.Model
{
    public class AmxCoOrderResourceModel
    {
        public AmxCoOrderResourceModel()
        {
        }

        public AmxCoOrderResourceModel(AmxCoOrderResourceModelInput orderResourceModelInput)
        {
            if(!String.IsNullOrEmpty(orderResourceModelInput.etel_orderresourceid))
                this.etel_orderresourceid = new Guid(orderResourceModelInput.etel_orderresourceid);

            if (!String.IsNullOrEmpty(orderResourceModelInput.etel_orderresourceid))
                this.etel_orderitemid = new EntityReference("etel_orderitem", new Guid(orderResourceModelInput.etel_orderitemid));

            if (!String.IsNullOrEmpty(orderResourceModelInput.etel_offeringid))
                this.etel_offeringid = new EntityReference("product", new Guid(orderResourceModelInput.etel_offeringid));

            if (!String.IsNullOrEmpty(orderResourceModelInput.etel_name))
                this.etel_name = orderResourceModelInput.etel_name;

            if (!String.IsNullOrEmpty(orderResourceModelInput.etel_productresourcespecification))
                this.etel_productresourcespecification = new EntityReference("etel_productresourcespecification", new Guid(orderResourceModelInput.etel_productresourcespecification));

            if (!String.IsNullOrEmpty(orderResourceModelInput.etel_value))
                this.etel_value = orderResourceModelInput.etel_value;

            this.orderResourceCharList = new List<AmxCoOrderResourceCharModel>();
            foreach (AmxCoOrderResourceCharModelInput orderResourceCharModelInput in orderResourceModelInput.orderResourceCharInputList)
                this.orderResourceCharList.Add(new AmxCoOrderResourceCharModel(orderResourceCharModelInput));
        }

        public Guid etel_orderresourceid { get; set; }
        public EntityReference etel_orderitemid { get; set; }
        public EntityReference etel_offeringid { get; set; }
        public string etel_name { get; set; }
        public EntityReference etel_productresourcespecification { get; set; }
        public string etel_value { get; set; }
        public List<AmxCoOrderResourceCharModel> orderResourceCharList { get; set; }
    }

    public class AmxCoOrderResourceModelInput
    {
        public string etel_orderresourceid { get; set; }
        public string etel_orderitemid { get; set; }
        public string etel_offeringid { get; set; }
        public string etel_name { get; set; }
        public string etel_productresourcespecification { get; set; }
        public string etel_value { get; set; }
        public List<AmxCoOrderResourceCharModelInput> orderResourceCharInputList { get; set; }
    }

    public class AmxCoCreateUpdateResourceCharInput
    {
        public List<AmxCoOrderResourceModelInput> orderResourceInputList { get; set; }
    }
}
