using AmxPeruPSBActivities.Model.SeeCreditAssessment;
using Ericsson.ETELCRM.Entities.Crm;
using System;
using ExternalApiActivities.Common;
using System.Activities;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Activities.External
{
    public class ConsultaEvaluacionCrediticia : XrmAwareCodeActivity
    {
        public InArgument<AMXPeruSeeCreditAssessmentRequest> _requestModel { get; set; }
        public OutArgument<AMXPeruSeeCreditAssessmentResponse> _responseModel { get; set; }       
        
        
        protected override void Execute(XrmDataContext dataContext, CodeActivityContext context)
        {            
            AMXPeruSeeCreditAssessmentResponse returnModel = new AMXPeruSeeCreditAssessmentResponse();  //set debug_point here for Unit Testing from CreateCaseTest.cs
            var _serviceRequestObj = new AMXPeruSeeCreditAssessmentRequest();

            returnModel.DecisionID = "testID";
            returnModel.Offering = new AMXPeruOfferingType()
            {
                Autonomy = new AMXPeruAutonomyType()
                {
                    Amountofadditionalruclines = 0,
                    Amountcfforruc = 0,
                    Numberoflinerenovations = "test",
                    Numberoflinesmax = 0,
                    Typeofautonomyfixedcharge = "test"
                },
                Consumercontrol = "test",
                Costofinstallation = 0,
                Share = new AMXPeruQuotaType()
                {
                    Initialpercentage = 0,
                    Quanity = 0
                },
                Warranty = new AMXPeruWarrantyType()
                {
                    Amountofapplicationsrent = 0,
                    Amountofguarantee = 0,
                    Icannotremember = "test",
                    Monthhomerentals = 0,
                    Monthlyapplicationfrequency = 0,                    
                    Typeofguarantee = "Test"
                },
                Creditlimitcollection = 0,
                Amountautomaticstop = 0,
                Optionofquotas = new AMXPeruOptionsType()
                {
                    Maximumquota = 0,
                    Maximumstop = 0,
                    Showanswer = "test"
                },
                Prioritypublish = "test",
                Rentexonerationprocess = "test",
                Idvalidatorprocess = "test",
                Internalvalidationprocessclaro = "test",
                Restriction = "test",
                Additionalresults = new AMXPeruAdditionalResultsType()
                {
                    Paymentcapacity = "test",
                    Consolidatedbehavior = 0,
                    Paymentbehaviorc1 = 0,
                    Costtotalequipment = 0,
                    Customerrenewalfactor = 0,
                    Salepricetotalequipment = 0,
                    Riskinclaro = "test",
                    Riskoffer = "test",
                    Customerdebtfactor = 0,
                    Risktotalequipment = 0,
                    Risktotallegalrep = "test"

                },
                Topost = "test",
            };

            #region Set response object
            _responseModel.Set(context, returnModel);
            #endregion
        }





    }
}
