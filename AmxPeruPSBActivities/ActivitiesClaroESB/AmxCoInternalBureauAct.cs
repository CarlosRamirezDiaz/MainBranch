using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

using Ericsson.ETELCRM.Entities.Crm;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using ExternalApiActivities.Common;
using AmxPeruPSBActivities.Repository;
using AmxPeruPSBActivities.Model.CreditProfile;
using AmxPeruPSBActivities.Model.EOC;


namespace AmxPeruPSBActivities.ActivitiesClaroESB
{

    public sealed class AmxCoInternalBureauAct : XrmAwareCodeActivity
    {
        public InArgument<string> individualCustomerId { get; set; }
        public InArgument<List<SRProductResponseModel>> srProducts { get; set; }

        public OutArgument<string> internalBureauResponse { get; set; }
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
        public OutArgument<String> RequiereVisitaDomiciliaria { get; set; }
        public OutArgument<String> EvaluacionListas { get; set; }



        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {
            int ageScore = 0;
            int customerSinceScore = 0;
            int activeLinesScore = 0;
            Double ageWeight = 12.5;
            Double customerSinceWeight = 12.5;
            Double activeLinesWeight = 12.5;
            Double internalValidationScore = 0;
            Double billingScore = 0;
            Double internalBureauScore = 0;
            string response;

            int customeractivation = 0;


            OrganizationServiceProxy _org = ContextProvider.OrganizationService;

            var customerID = individualCustomerId.Get(context);
            var srProductList = srProducts.Get(context);

            Guid individualId = new Guid(customerID);
            var individualRepository = new IndividualCustomerRepository(_org);
            var individual = individualRepository.GetById(individualId);
            if (individual.IndividualCustomerId == Guid.Empty)
                throw new Exception("Individual Customer not found for Id: " + individualCustomerId);

            // Calculate customer age Score

            DateTime birthDate = individual.BirthDate;
            var dateNow = DateTime.Now;
            //var customerAge = (dateNow.Month - birthDate.Month) + 12 * (dateNow.Year - birthDate.Year);
            var customerAge = dateNow.Year - birthDate.Year;
            if (customerAge >= 18 && customerAge <= 35) { ageScore = 90; }
            else if (customerAge >= 36 && customerAge <= 48) { ageScore = 100; }
            else if (customerAge >= 49 && customerAge <= 57) { ageScore = 80; }
            else if (customerAge >= 58) { ageScore = 60; }

            // Get customer first activation date Score

            Entity Customer = new Entity("contact", individual.IndividualCustomerId);

            if (individual.CustomerSince == DateTime.Parse("01/01/0001"))
            {
                var customerStatus = individual.StatusCode;
                if (customerStatus == "Active")
                {
                    var biBillingAccountCreateRepository = new BIBillingAccountCreateRepository(_org);
                    var existbiBillingAccountCreate = biBillingAccountCreateRepository.GetFirst(individualId);
                    var firstbicreatedon = existbiBillingAccountCreate.CreatedOn;
                    customeractivation = (dateNow.Month - firstbicreatedon.Month) + 12 * (dateNow.Year - firstbicreatedon.Year);
                    Customer.Attributes.Add("amx_customersince", firstbicreatedon);
                    _org.Update(Customer);
                }

            }
            else customeractivation = (dateNow.Month - individual.CustomerSince.Month) + 12 * (dateNow.Year - individual.CustomerSince.Year);

            if (customeractivation >= 12 && customeractivation <= 24) { customerSinceScore = 80; }
            else if (customeractivation > 24) { customerSinceScore = 100; }
            else customerSinceScore = 0;

            // Get customer's number of lines
            var customerNumberOfLines = srProductList.Count;
            if (customerNumberOfLines == 0) { activeLinesScore = 0; }
            else if (customerNumberOfLines > 0 && customerNumberOfLines <=5) { activeLinesScore = 100; }
            else if (customerNumberOfLines > 5) { activeLinesScore = 80; }
            
            // Calculate internal validation score
            internalValidationScore = (0.01 * ageWeight * ageScore) + (0.01 * customerSinceWeight * customerSinceScore) + (0.01 * activeLinesWeight * activeLinesScore);

            // Calculate internal bureau score
            internalBureauScore = billingScore * 0.5 + internalValidationScore * 0.5;

            // Save to Credit Profile
            var creditProfileRepository = new CreditProfileRepository(_org);
            var existCreditProfile = creditProfileRepository.GetLastBy(individualId, DateTime.Now.Date.AddHours(-24));
            var creditProfile = new CreditProfileModel();
            creditProfile.BuroInternoScoreCustomerAge = Convert.ToInt32(0.01 * ageWeight * ageScore);
            creditProfile.BuroInternoScoreCustomerSince = Convert.ToInt32(0.01 * ageWeight * customerSinceScore);
            creditProfile.BuroInternoScoreActiveLines = Convert.ToInt32(0.01 * activeLinesWeight * activeLinesScore);
            creditProfile.BuroInternoScore = Convert.ToInt32(internalBureauScore);
            creditProfile.BureauDate = DateTime.Now;
            creditProfile.BureauSource = "Interno";
            creditProfile.IndividualCustomerId = individualId;
            creditProfileRepository.Create(creditProfile);

            response = "OK";

            context.SetValue(internalBureauResponse, response);
            //context.SetValue(CupoTotal, "50000");
            context.SetValue(Antiguedad, customeractivation.ToString());
            context.SetValue(CantidadLineas, customerNumberOfLines.ToString());

        }
    }
}
