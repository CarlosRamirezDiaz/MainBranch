using AmxCoPSBActivities.Repository;
using AmxPeruPSBActivities.AMXCOLOMBIA.Business.BI_Log;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.BI_Log;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.BillCycle;
using AmxPeruPSBActivities.Common;
using AmxPeruPSBActivities.Repository;
using Microsoft.Xrm.Sdk.Client;
using Newtonsoft.Json;
using System;


namespace AmxPeruPSBActivities.AMXCOLOMBIA.Business.BillCycleChange
{
    public class BillCycleChangeSubmitToEOC
    {
        #region Declaration
        private OrganizationServiceProxy service = null;

        string jsonResponse = string.Empty;

        string error = string.Empty;

        private AmxHTTPCallEOC _amxHTTPCallEOC;
        private AmxHTTPCallEOC amxHTTPCallEOC
        {
            get
            {
                if (this._amxHTTPCallEOC == null)
                    this._amxHTTPCallEOC = new AmxHTTPCallEOC(service);
                return this._amxHTTPCallEOC;
            }
        }
        #endregion

        /// <summary>
        /// This method is to submit customer bill cycle change information to EOC system
        /// </summary>
        /// <param name="billCycleChangeEOCRequest">Bill cycle change input parameters</param>
        /// <param name="service">CRM Service</param>
        /// <returns></returns>
        public bool SubmitEOCForBillCycleChange(BillCycleChangeEOCRequest billCycleChangeEOCRequest, OrganizationServiceProxy service, BILogSchema biLogSchema)
        {
            AMXCommon.Common com = new AMXCommon.Common();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (billCycleChangeEOCRequest == null)
                return false;

            var eocBiURL = CRMConfiguration.GetStringValue("EOC_BI_EndPoint", service);
            // eocBiURL = @"http://localhost:7005/eoc/bi/"; // only for unit test

            var successCall = amxHTTPCallEOC.RestCall<BillCycleChangeEOCRequest>(eocBiURL, billCycleChangeEOCRequest, out jsonResponse, out error, "POST");

            #region Create EOC Log
            if (com.RetrieveCrmConfiguration("IS_EOC_LOG", service) == "YES")
            {
                var jsonRequestLog = billCycleChangeEOCRequest;
                var jsonResponseLog = jsonResponse;
                var errorLog = error;
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                var logRepository = new EOCRequestLogRepository(service);
                logRepository.Create(eocBiURL, successCall, elapsedMs, jsonResponseLog.ToString(), jsonResponseLog, error);
            }
            #endregion

            #region CreateBILogActivity
            if (successCall)
            {
                AmxBiLogBusiness biLog = new AmxBiLogBusiness(service);
                if (biLogSchema.LoggedInUserId != Guid.Empty && biLogSchema.BillCycleChangeRecordGuid != Guid.Empty)
                    biLog.CreateBILogValues(service, biLogSchema);
            }
            #endregion

            if (!successCall)
            {
                throw new Exception(error);
            }

            #region If Required
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                DateFormatString = "dd/MM/yyyy HH:mm:ss"
            };
            var responseObject = JsonConvert.DeserializeObject(jsonResponse, settings);
            #endregion

            return successCall;
        }

       
    }
}
