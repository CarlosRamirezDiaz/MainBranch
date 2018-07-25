using AmxPeruPSBActivities.Repository;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.AMXCOLOMBIA.Business.OrderCapture
{
    public class RetrieveOrderCaptureBusiness
    {
        OrganizationServiceProxy _org = null;
        OrderCaptureRepository _repository = null;
        IndividualCustomerRepository _individualRepository = null;

        private IndividualCustomerRepository individualRepository
        {
            get
            {
                if (this._individualRepository == null)
                    this._individualRepository = new IndividualCustomerRepository(this._org);
                return this._individualRepository;
            }

        }

        private OrderCaptureRepository repository
        {
            get
            {
                if (this._repository == null)
                    this._repository = new OrderCaptureRepository(this._org);
                return this._repository;
            }

        }

        public RetrieveOrderCaptureBusiness(OrganizationServiceProxy org)
        {
            this._org = org;
        }

        public List<AmxCoPSBActivities.AMXCOLOMBIA.Model.OrderCapture.ListOrderCapture> RetrieveOrderCaptureByIndividualAndDate(string crmAccountNumber, DateTime dateStart, DateTime dateEnd, int viewType)
        {
            var customer = this.individualRepository.GetByCRMAccountNumber(crmAccountNumber);

            if (customer.IndividualCustomerId == Guid.Empty)
                return new List<AmxCoPSBActivities.AMXCOLOMBIA.Model.OrderCapture.ListOrderCapture>();

            var stateCode = -1;
            var statusCode = 0;


            switch (viewType)
            {
                case 1: // All Orders
                    {
                        stateCode = -1;
                        statusCode = -1;
                        break;
                    }
                case 2: // Bulk Orders
                    {
                        stateCode = -1;
                        statusCode = -1;
                        break;
                    }
                case 3: // Active orders
                    {
                        stateCode = 0;
                        statusCode = -1;
                        break;
                    }
                case 4: // Draft orders
                    {
                        stateCode = 0;
                        statusCode = 1;
                        break;
                    }
                case 5: // Inactive orders
                    {
                        stateCode = 1;
                        statusCode = -1;
                        break;
                    }
            }

            var collection = this.repository.ListOrderCaptureByIndividualAndDate(customer.IndividualCustomerId, dateStart, dateEnd, statusCode, stateCode);
            for(int item=0; item < collection.Count; item++)
            {
                if (!string.IsNullOrEmpty(collection[item].CancelReasonName))
                     collection[item].CancelOrPostponeReason = collection[item].CancelReasonName;
                else if (!string.IsNullOrEmpty(collection[item].PostponeReasonName))
                    collection[item].CancelOrPostponeReason = collection[item].PostponeReasonName;
            }

            return collection;
        }
    }
}
