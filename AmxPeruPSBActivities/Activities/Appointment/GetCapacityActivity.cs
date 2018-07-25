using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using AmxPeruPSBActivities.Model.Appointment;
using ExternalApiActivities.Common;
using Ericsson.ETELCRM.Entities.Crm;
using System.Web.Script.Serialization;
using System.IO;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System.Collections;

namespace AmxPeruPSBActivities.Activities.Appointment
{

    public sealed class GetCapacityActivity : XrmAwareCodeActivity
    {
        public InArgument<List<string>> Dates { get; set; }
        public InArgument<string> AddressId { get; set; }
        public InArgument<string> OrderCaptureId { get; set; }
        public InArgument<string> SequenceNumber { get; set; }
        public InArgument<string> DocumentId { get; set; }
        public OutArgument<GetCapacityRequestModel> GetCapacityRequest { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var tech = string.Empty;
            var node = string.Empty;
            var dateList = Dates.Get(context);
            var addressId = AddressId.Get(context);
            var orderCaptureId = OrderCaptureId.Get(context);
            var sequenceNumber = SequenceNumber.Get(context);
            var documentId = DocumentId.Get(context);
            var addressDetails = GetAddressDetails(addressId);
            var dict = GetTechCodes();
            string hhppId = String.Empty;

            if (addressDetails != null)
            {
                var techCode = addressDetails.Contains("mglHhpps.amx_technology") ? addressDetails.GetAttributeValue<AliasedValue>("mglHhpps.amx_technology")?.Value?.ToString() : "Bidireccional";
                tech = dict.Where(d => d.Key == techCode).Select(d => d.Value).FirstOrDefault();
                tech = "Bidireccional"; //Remove this line when the tech issue is resolved.
                node = addressDetails.Contains("mglHhpps.amx_codenode") ? addressDetails.GetAttributeValue<AliasedValue>("mglHhpps.amx_codenode")?.Value?.ToString() : "2B5012";
                hhppId = addressDetails.Contains("mglHhpps.amx_mgllisthhppsid") ? addressDetails.GetAttributeValue<AliasedValue>("mglHhpps.amx_mgllisthhppsid")?.Value.ToString() : "";
            }

            Header h = new Header()
            {
                transactionId = "12345679",
                system = "PRUEBA",
                user = "YFONSECA",
                password = "PRUEBA",
                requestDate = "2017-11-02T14:20:45",
                ipApplication = "PRUEBA",
                traceabilityId = "PRUEBA"
            };

            List<string> l = new List<string>()
            {
                "DNA102"
            };

            GetCapacityRequestModel capacityRequest = new GetCapacityRequestModel();
            capacityRequest.headerRequest = h;
            capacityRequest.idOrder = orderCaptureId;
            capacityRequest.documentId = documentId;
            capacityRequest.addressId = "1"; // will be parametrized with an integer value (hhpp)
            capacityRequest.appt_number = orderCaptureId + "_" + sequenceNumber;
            capacityRequest.date = dateList;
            capacityRequest.location = l;
            capacityRequest.calculateDuration = "0";
            capacityRequest.calculateTravelTime = "0";
            capacityRequest.calculateWorkSkill = "1";
            capacityRequest.returnTimeSlotInfo = "1";
            capacityRequest.determineLocationByWorkZone = "0";

            List<Fog> f1 = new List<Fog>()
            {
                new Fog { attributeName = "XA_WorkOrderSubtype", attributeValue = "IN23" },
                new Fog { attributeName = "worktype_label", attributeValue = "INT" },
                new Fog { attributeName = "XA_Red", attributeValue = tech },
                new Fog { attributeName = "XA_Idcity", attributeValue = "BOG" },
                new Fog { attributeName = "Node", attributeValue = node }
            };

            List<Fog> f2 = new List<Fog>()
            {
                new Fog { attributeName = "cambioEquipo", attributeValue = "N" },
                new Fog { attributeName = "claseOt", attributeValue = "CE" },
                new Fog { attributeName = "cuenta", attributeValue = "12313124" },
                new Fog { attributeName = "estado", attributeValue = "Abierta" },
                new Fog { attributeName = "estadoUnidad", attributeValue = "E" },
                new Fog { attributeName = "origen", attributeValue = "W" },
                new Fog { attributeName = "purchase", attributeValue = "N" },
                new Fog { attributeName = "segmento", attributeValue = "2" },
                new Fog { attributeName = "servAfectado", attributeValue = "Internet" },
                new Fog { attributeName = "tecnologia", attributeValue = "Docsis 2" },
                new Fog { attributeName = "tipVen", attributeValue = "1" },
                new Fog { attributeName = "tipoTrabajo", attributeValue = "Instalacion" },
                new Fog { attributeName = "subtipotrabajo", attributeValue = "Instalacion" }
            };

            Inventory i = new Inventory()
            {
                type = "DBV",
                manufacture = "DBV",
                family = "DECO"
            };

            capacityRequest.activityField = f1;
            capacityRequest.infoOrderAct = f2;
            capacityRequest.inventory = i;

            //////////////// EOC Request Log ypala ///////////
            var jsonPayLoadPostedToClaro = new JavaScriptSerializer().Serialize(capacityRequest);
            Microsoft.Xrm.Sdk.Entity _logRequest = new Microsoft.Xrm.Sdk.Entity("etel_exceptionlog");
            _logRequest.Attributes.Add("etel_name", "PayloadToClaro_GetCapacityTest_" + DateTime.Now);
            _logRequest.Attributes.Add("etel_stacktrace", jsonPayLoadPostedToClaro);
            _logRequest.Attributes.Add("etel_sourcesystem", "PSB_AmxPeruNewSubscription_GetCapacityReq");
            _logRequest.Attributes.Add("etel_server", "psb_hostServer");
            _logRequest.Id = ContextProvider.OrganizationService.Create(_logRequest);
            //Logging the Payload to ExceptionLog Entity for Easy Debugging : Pre Post to EOC 
            ////////////////////

            GetCapacityRequest.Set(context, capacityRequest);
        }

        private Entity GetAddressDetails(string addressId)
        {
            QueryExpression address = new QueryExpression();
            address.EntityName = etel_customeraddress.EntityLogicalName;
            address.Criteria.AddCondition("etel_customeraddressid", ConditionOperator.Equal, addressId);

            LinkEntity city = new LinkEntity(etel_customeraddress.EntityLogicalName, etel_city.EntityLogicalName, "etel_cityid", "etel_cityid", JoinOperator.Inner);
            city.EntityAlias = etel_customeraddress.EntityLogicalName;
            address.LinkEntities.Add(city);

            LinkEntity mglTech = new LinkEntity(etel_customeraddress.EntityLogicalName, "amx_bimgltechnicaldetails", "etel_customeraddressid", "amx_customeraddressid", JoinOperator.Inner);
            mglTech.EntityAlias = "mglTech";
            address.LinkEntities.Add(mglTech);

            LinkEntity mglHhpps = new LinkEntity("amx_bimgltechnicaldetails", "amx_bimgllisthhpps", "amx_bimgltechnicaldetailsid", "amx_mgllisthhppsid", JoinOperator.Inner);
            mglHhpps.Columns = new ColumnSet("amx_technology", "amx_codenode");
            mglHhpps.EntityAlias = "mglHhpps";
            mglTech.LinkEntities.Add(mglHhpps);

            return ContextProvider.OrganizationService.RetrieveMultiple(address)?.Entities?.FirstOrDefault();
        }

        private Dictionary<string, string> GetTechCodes()
        {
            return new Dictionary<string, string>()
            {
                { "LTE", "LTE" },
                { "MOV", "Movil"},
                { "DTH", "DTH"},
                { "FTTH", "Fibra FTTH"},
                { "FOU", "Fibra Optica Unifilar"},
                { "FOG", "Fibra Optica GPON"},
                { "U", "Unidireccional"},
                { "B", "Bidireccional"}
            };
        }
    }
}