using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using ExternalApiActivities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Microsoft.Xrm.Sdk.Client;
using AmxPeruPSBActivities.Repository;
using AmxPeruPSBActivities.Model.CreditProfile;
using AmxPeruPSBActivities.Model.EOC;

namespace AmxPeruPSBActivities.ActivitiesClaroESB
{

    public sealed class AmxCoBureauAct : XrmAwareCodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> individualCustomerId { get; set; }
        public InArgument<string> bureauURL { get; set; }
        public InArgument<List<SRProductResponseModel>> srProducts { get; set; }
        
        public OutArgument<string> BureauResponse { get; set; }
        public OutArgument<string> CupoTotal { get; set; }
        public OutArgument<string> CupoUtilizado { get; set; }
        public OutArgument<string> CupoDisponible { get; set; }
        public OutArgument<string> CupoFinaciamiento { get; set; }
        public OutArgument<string> ListaRestricciones { get; set; }
        public OutArgument<string> PorcentajePagoInicial { get; set; }
        public OutArgument<string> ComportamientoPago { get; set; }
        public OutArgument<string> EvalucacionMora { get; set; }
        public OutArgument<string> OrdenesLealtadFidelizacion { get; set; }
        public OutArgument<string> Antiguedad { get; set; }
        public OutArgument<string> ProductosRecurrentes { get; set; }
        public OutArgument<string> CantidadLineas { get; set; }
        public OutArgument<string> AplicaCargar1aFactura { get; set; }
        public OutArgument<string> CargosAnticipados { get; set; }
        public OutArgument<Boolean> RequiereVisitaDomiciliaria { get; set; }
        public OutArgument<Boolean> EvaluacionListas { get; set; }

        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {

            // Get if customer has been checked within last expiration date
            var customerID = individualCustomerId.Get(context);

            string cupoTotal = "";
            string response = "";

            var bureauBusiness = new AmxCoPSBActivities.BusinessClaroESB.AmxCoBureauBusiness();

            string bURL = bureauURL.Get(context);

            try
            {
                response = bureauBusiness.GetBureau(bURL, new Guid(customerID), ContextProvider.OrganizationService);

                context.SetValue(BureauResponse, response);
                //context.SetValue(CupoTotal, "10000");
                
            }
            catch (Exception ex)
            {
                context.SetValue(BureauResponse, ex.Message);
            }
        }
    }
}
