using AmxDynamicsActivities;
using AmxPeruPlugins;
using AmxPeruPSBActivities.Business;
using AmxPeruPSBActivities.Model.InternalExternalAccount;
using AmxPeruPSBActivities.Model.StratumChange;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            //mtdStratumChangeCreateBiLog();
            //StratumChangeCreateItemBusiness();
            //PreResolveCaseNotify();
            //mtdGenerateSimulation();
            //mtdStratumChangeReplicate();
            //AssigmentBillingAccount();
            CreateItemsAccountWithDataBSCSBusiness();
            //mtdUpdateCustomersContactInformation();
            //StratumChangeCreateCaseBusiness();
            //createCaseForRisk();
            //AmcCoGenerateSimulationBusiness

            //D184C7DE-2E18-E811-80ED-FA163E10DFBE
        }

        private static void mtdStratumChangeCreateBiLog()
        {
            OrganizationServiceProxy service = TestProjects.CRMConnection.CRMConnection.GetCRMConnection(TestProjects.CRMConnection.CRMConnection.ColDesaTrial, "comcel\\spabloa", "Sqdm2018*.");
            StratumChangeCreateBILog test = new StratumChangeCreateBILog();
            EntityReference erStratum = new EntityReference("amx_stratumchange", new Guid("CA84C7DE-2E18-E811-80ED-FA163E10DFBE"));
            test.Run(service, erStratum);
        }
        private static void StratumChangeCreateItemBusiness()
        {
            StratumChangeCreateItemRequest objResquest = new StratumChangeCreateItemRequest();
            OrganizationServiceProxy service = TestProjects.CRMConnection.CRMConnection.GetCRMConnection(TestProjects.CRMConnection.CRMConnection.ColDesaTrial, "comcel\\spabloa", "Sqdm2018*.");
            AmxCoStratumChangeCreateItemBusiness test = new AmxCoStratumChangeCreateItemBusiness();
            objResquest.idStratum = "E73EE017-9317-E811-80ED-FA163E10DFBE";
            objResquest.idUser = "91A8AD1D-12FB-E711-80ED-FA163E10DFBE";
            test.CreateItemsItemAddress(objResquest, service);
        }


        private static void mtdGenerateSimulation()
        {
            OrganizationServiceProxy service = TestProjects.CRMConnection.CRMConnection.GetCRMConnection(TestProjects.CRMConnection.CRMConnection.ColDesaTrial, "comcel\\spabloa", "Sqdm2018*.");
            AmcCoGenerateSimulationBusiness test = new AmcCoGenerateSimulationBusiness();
            AmcCoGenerateSimulationRequest objRequest = new AmcCoGenerateSimulationRequest();
            objRequest.ContractId = "3B8DB508-A61D-E811-80ED-FA163E10DFBE";
            objRequest.CustomerId = "902eee75-4814-e811-80ed-fa163e10dfbe";
            test.SimularionBilling(objRequest, service);
        }

        private static void mtdStratumChangeReplicate()
        {
            OrganizationServiceProxy service = TestProjects.CRMConnection.CRMConnection.GetCRMConnection(TestProjects.CRMConnection.CRMConnection.ColDesaTrial, "comcel\\spabloa", "Sqdm2018*.");
            StratumChangeReplicateFromBI test = new StratumChangeReplicateFromBI();
            EntityReference erStratum = new EntityReference("amx_stratumchange", new Guid("E11AD542-2F10-E811-80ED-FA163E10DFBE"));
            test.Run(service, erStratum, "Cambio de estrato 3 a estrato 2");
        }

        private static void mtdUpdateCustomersContactInformation()
        {
            OrganizationServiceProxy service = TestProjects.CRMConnection.CRMConnection.GetCRMConnection(TestProjects.CRMConnection.CRMConnection.ColDesaTrial, "comcel\\spabloa", "Sqdm2018*.");
            UpdateCustomersContactInformation test = new UpdateCustomersContactInformation();
            EntityReference erProduct = new EntityReference("contact", new Guid("A747F092-AF0E-E811-80ED-FA163E10DFBE"));
            test.Run(service, erProduct);
        }

        private static void StratumChangeCreateCaseBusiness()
        {
            OrganizationServiceProxy service = TestProjects.CRMConnection.CRMConnection.GetCRMConnection(TestProjects.CRMConnection.CRMConnection.ColDesaTrial, "comcel\\spabloa", "Sqdm2018*.");
            AmxCoStratumChangeCreateCaseBusiness test = new AmxCoStratumChangeCreateCaseBusiness();
            test.StratumChangeCreateCase("9A40BA1D-4110-E811-80ED-FA163E10DFBE", service);
        }

        private static void createCaseForRisk()
        {
            OrganizationServiceProxy service = TestProjects.CRMConnection.CRMConnection.GetCRMConnection(TestProjects.CRMConnection.CRMConnection.ColDesaTrial, "comcel\\spabloa", "Sqdm2018*.");
            OrderCaptureCreateCaseCreditRisk test = new OrderCaptureCreateCaseCreditRisk();
            EntityReference erProduct = new EntityReference("etel_ordercapture", new Guid("87CEE323-490C-E811-80ED-FA163E10DFBE"));
            test.Run(service, erProduct);
        }

        private static void CreateItemsAccountWithDataBSCSBusiness()
        {
            OrganizationServiceProxy service = TestProjects.CRMConnection.CRMConnection.GetCRMConnection(TestProjects.CRMConnection.CRMConnection.ColDesaTrial, "comcel\\spabloa", "Sqdm2018*.");
            AmxCoCreateItemsBABusiness test = new AmxCoCreateItemsBABusiness();
            test.CreateItemsAccountWithDataBSCS("c85bb36b-7618-e811-80ed-fa163e10dfbe", service, new Guid("BC2AAE3D-05A3-E711-80DD-FA163E106136"));
        }

        private static void AssigmentBillingAccount()
        {
            AmxCoBillingAccountAssignmentRequest objResquest = new AmxCoBillingAccountAssignmentRequest();
            OrganizationServiceProxy service = TestProjects.CRMConnection.CRMConnection.GetCRMConnection(TestProjects.CRMConnection.CRMConnection.ColDesaTrial, "comcel\\spabloa", "Sqdm2018*.");
            AmxCoBAAssignmentBusiness test = new AmxCoBAAssignmentBusiness();
            objResquest.BillingAccountId = "34E9734A-7815-E811-80ED-FA163E10DFBE";
            objResquest.ContractId = "FC4F972F-9F15-E811-80ED-FA163E10DFBE";
            test.AssignmentContractInBA(objResquest, service);
        }

        private static void PreResolveCaseNotify()
        {            
            OrganizationServiceProxy service = TestProjects.CRMConnection.CRMConnection.GetCRMConnection(TestProjects.CRMConnection.CRMConnection.ColDesaTrial, "comcel\\spabloa", "Sqdm2018*.");
            PreResolveCaseNotifyAdvisor test = new PreResolveCaseNotifyAdvisor();
            Entity incidentResolution = new Entity("incidentresolution", Guid.Parse("7668BA85-E10D-E811-80ED-FA163E10DFBC"));
            incidentResolution["incidentid"] = new EntityReference("incident", Guid.Parse("7668BA85-E10D-E811-80ED-FA163E10DFBE"));
            test.Run(service, incidentResolution, Guid.Parse("91A8AD1D-12FB-E711-80ED-FA163E10DFBE"));
        }        
    }
}
