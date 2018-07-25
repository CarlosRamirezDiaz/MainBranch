using AmxPeruPSBActivities.Activities.Order;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.EOC;
using AmxPeruPSBActivities.Common;
using AmxPeruPSBActivities.Model.EOC;
using AmxPeruPSBActivities.Model.OrderCaptureSubmit;
using AmxPeruPSBActivities.Repository;
using Microsoft.Xrm.Sdk.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Business.EOC
{
    public class EocBiBusiness
    {
        private OrganizationServiceProxy _org = null;

        private ConfigurationRepository _configurationRepository;
        private ConfigurationRepository configurationRepository
        {
            get
            {
                if (this._configurationRepository == null)
                    this._configurationRepository = new ConfigurationRepository(this._org);
                return this._configurationRepository;
            }
        }

        private MglHHPPsRepository _mglHHPPsRepository;
        private MglHHPPsRepository mglHHPPsRepository
        {
            get
            {
                if (this._mglHHPPsRepository == null)
                    this._mglHHPPsRepository = new MglHHPPsRepository(this._org);
                return this._mglHHPPsRepository;
            }
        }

        private AmxHTTPCallEOC _amxHTTPCallEOC;
        private AmxHTTPCallEOC amxHTTPCallEOC
        {
            get
            {
                if (this._amxHTTPCallEOC == null)
                    this._amxHTTPCallEOC = new AmxHTTPCallEOC(this._org);
                return this._amxHTTPCallEOC;
            }
        }

        private AmxCoProductOfferringRepository _productOfferringRepository = null;
        private AmxCoProductOfferringRepository productOfferringRepository
        {
            get
            {
                if (this._productOfferringRepository == null)
                    this._productOfferringRepository = new AmxCoProductOfferringRepository(this._org);
                return this._productOfferringRepository;
            }
        }

        public EocBiBusiness(OrganizationServiceProxy org)
        {
            this._org = org;
        }

        public EocBiResponseModel GetEocBusinessInteraction(SubmitOrderRequest submitOrderCapture)
        {
            if (submitOrderCapture == null)
                return null;

            var eocBiURL = CRMConfiguration.GetStringValue("EOC_BI_EndPoint", this._org);

            //var eocBiURL = @"http://localhost:57005/eoc/bi/"; // only for unit test

            string jsonResponse = string.Empty;
            string error = string.Empty;

            var successCall = this.amxHTTPCallEOC.RestCall<SubmitOrderRequest>(eocBiURL, submitOrderCapture, out jsonResponse, out error, "POST");

            if (!successCall)
            {
                throw new Exception(error);
            }

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DateFormatString = "dd/MM/yyyy HH:mm:ss"
            };
            var responseObject = JsonConvert.DeserializeObject<EocBiResponseModel>(jsonResponse, settings);

            return responseObject;
        }

        public List<RequiredAppointment> GetRequiredAppointments(SubmitOrderRequest submitOrderRequest, Guid orderCaptureId, ref string hasBi)
        {
            var eocBI = this.GetEocBusinessInteraction(submitOrderRequest);

            hasBi = this.HasBi(eocBI);

            return this.GetRequiredAppointments(eocBI, orderCaptureId);
        }

        public List<RequiredAppointment> GetRequiredAppointments(EocBiResponseModel eocBi, Guid orderCaptureId)
        {
            if (eocBi == null || !eocBi.hasBI)
                return new List<RequiredAppointment>(); ;

            if (eocBi.orderItems == null || eocBi.orderItems.Count <= 0)
                return new List<RequiredAppointment>(); ;

            string address_HHPPS_Technology = "Bidireccional";
            bool address_HHPPS_State_Basic = true;

            var requiredAppointmentsTemp = new List<RequiredAppointmentOrderItem>();

            foreach (var orderItem in eocBi.orderItems)
            {
                if (orderItem.item == null || orderItem.item.relatedBusinessInteractions == null)
                    continue;

                var newOrderItem = new RequiredAppointmentOrderItem();

                var mglHHPPs = this.mglHHPPsRepository.GetByOrderItem(orderCaptureId, orderItem.item.id);
                if (!string.IsNullOrEmpty(mglHHPPs.Technology))
                    newOrderItem.Technology = mglHHPPs.Technology;

                foreach (var relatedWorkOrder in orderItem.item.relatedOrderItems)
                {
                    if (relatedWorkOrder.role == "ChildOf" && !string.IsNullOrEmpty(relatedWorkOrder.reference))
                        newOrderItem.relatedBIref.Add(relatedWorkOrder.reference);
                }

                foreach (var relatedBi in orderItem.item.relatedBusinessInteractions)
                {
                    // Only BI ´s WorkOrder
                    if (relatedBi.getCharacteristicBiTypeValue() != "workOrder")
                        continue;

                    // Technology must be the same as the Instalation Address Techonology
                    var technology = relatedBi.getCharacteristicValue("BI_technology");
                    if (!string.IsNullOrEmpty(technology) && technology != address_HHPPS_Technology)
                        continue;

                    var workOrderCode = relatedBi.getCharacteristicValue("workOrderCode");

                    // If more related services in the same access. Acepts only multiplo instalation option
                    if (newOrderItem.relatedBIref.Count > 1 && workOrderCode != "IN23")
                        continue;

                    //if (address_HHPPS_State_Basic)
                    //{
                    //    if (!("INBAS,IN23".Contains(workOrderCode)))
                    //        continue;
                    //}
                    //else
                    //{
                    //    if (!("INCAB,IN23".Contains(workOrderCode)))
                    //        continue;
                    //}

                    var newBusinessInteraction = new BusinessInteraction();

                    newBusinessInteraction.technology = technology;
                    newBusinessInteraction.workOrderCode = workOrderCode;
                    newBusinessInteraction.workOrderDuration = relatedBi.getCharacteristicValue("workOrderDuration");
                    newBusinessInteraction.workOrderSla = relatedBi.getCharacteristicValue("workOrderSLA");
                    newBusinessInteraction.biType = relatedBi.getCharacteristicValue("BI_type");
                    newBusinessInteraction.serviceOrderType = relatedBi.getCharacteristicValue("tipodeOrdendeServicio");
                    newBusinessInteraction.serviceOrderSubType = relatedBi.getCharacteristicValue("subtipodeOrdendeServicio");
                    newBusinessInteraction.displayValue = relatedBi.getCharacteristicDisplayValue("ordenDeTrabajo");

                    newOrderItem.BusinessInteractions.Add(newBusinessInteraction);
                }

                if (newOrderItem.BusinessInteractions.Count > 0)
                {
                    newOrderItem.BIobjectId = orderItem.item.id;
                    newOrderItem.itemAction = orderItem.item.action;
                    newOrderItem.itemId = orderItem.item.id;
                    newOrderItem.itemName = orderItem.item.productOffering.id;
                    var productOfferring = this.productOfferringRepository.GetProductOfferingByExternalId(newOrderItem.itemName);
                    newOrderItem.OfferingName = productOfferring.OfferingName;
                    //newRequiredAppointment.relatedAddress = orderItem.item.
                    newOrderItem.serviceOrderType = orderItem.item.orderType;    // (calculated using itemAction + hhpp technology + parentServices)
                    //serviceOrderType(calculated using item action)
                    //serviceOrderSubType(calculated using itemAction + hhpp technology)
                    //workOrderType(calculated using itemAction + hhpp technology + parentServices)

                    newOrderItem.BIdeliveryOptions = this.getBIDeliveryOptions(newOrderItem.BIobjectId, eocBi.orderItems);
                    requiredAppointmentsTemp.Add(newOrderItem);
                }
            }

            // Calculate the required Appointments
            var requiredAppointments = new List<RequiredAppointment>();
            foreach (var ordem in requiredAppointmentsTemp)
            {
                RequiredAppointment appointmentWithSameReference = null;
                foreach (var relatedBi in ordem.relatedBIref)
                {
                    appointmentWithSameReference = requiredAppointments.Find(a => a.OrdemItems.Exists(o => o.relatedBIref.Exists(rbi => rbi == relatedBi)));
                    if (appointmentWithSameReference != null)
                    {
                        appointmentWithSameReference.OrdemItems.Add(ordem);
                        break;
                    }
                }
                if (appointmentWithSameReference == null)
                {
                    appointmentWithSameReference = new RequiredAppointment();
                    appointmentWithSameReference.OrdemItems.Add(ordem);
                    requiredAppointments.Add(appointmentWithSameReference);
                }
            }

            return requiredAppointments;
        }

        private List<string> getBIDeliveryOptions(string bIobjectId, List<EocBiResponseModelItem> orderItems)
        {
            List<string> deliveryOptions = new List<string>();

            foreach (var orderItem in orderItems)
            {
                if (orderItem.item.id != bIobjectId)
                    continue;

                if (orderItem.item == null || orderItem.item.relatedBusinessInteractions == null)
                    continue;

                foreach (var relatedBi in orderItem.item.relatedBusinessInteractions)
                {
                    // Only BI ´s Delivery
                    if (relatedBi.getCharacteristicBiTypeValue() != "delivery")
                        continue;

                    deliveryOptions.Add(relatedBi.id);
                }
            }

            return deliveryOptions;
        }


        private string HasBi(EocBiResponseModel eocBi)
        {
            return eocBi.hasBI.ToString();
        }

    }
}
