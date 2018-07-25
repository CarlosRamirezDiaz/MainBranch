using Ericsson.ETELCRM.Entities.Crm;
using ExternalApiActivities.Common;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxCoPSBActivities.OrderCapture
{
    public class RetrieveOrderCapture : XrmAwareCodeActivity
    {
        public InArgument<ExternalApiActivities.Models.OrderCaptureRequestModel> request { get; set; }
        public OutArgument<List<AmxCoPSBActivities.AMXCOLOMBIA.Model.OrderCapture.ListOrderCapture>> ordercapturelistmodel { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            var business = new AmxCoPSBActivities.AMXCOLOMBIA.Business.OrderCapture.RetrieveOrderCaptureBusiness(ContextProvider.OrganizationService);

            var accountNumber = request.Get(context).customerId;
            var dateStart = request.Get(context).startDate;
            var dateEnd = request.Get(context).endDate;
            var viewType = (int)request.Get(context).viewtype;

            var _response =  business.RetrieveOrderCaptureByIndividualAndDate(accountNumber, dateStart, dateEnd, viewType);

            ordercapturelistmodel.Set(context, _response);
        }
    }
}
