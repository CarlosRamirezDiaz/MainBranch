using AmxCoPSBActivities.Model;
using AmxPeruPSBActivities.AMXCOLOMBIA.Model.BI_Log;
using AmxPeruPSBActivities.Repository;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.AMXCOLOMBIA.Business.BI_Log
{
    public class AmxBiLogBusiness
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

        public AmxBiLogBusiness(OrganizationServiceProxy org)
        {
            this._org = org;
        }

        /// <summary>
        /// Create a new Bi log
        /// </summary>
        /// <param name="AmxBiLogAddRequest">BI Log parameters</param>
        /// <returns></returns>
        public BaseResponse<AmxBiLogAddResponse> AddBiLog(AmxBiLogAddRequest request)
        {
            var returnValue = new BaseResponse<AmxBiLogAddResponse>();

            returnValue.Success = true;

            // dummy values
            returnValue.Value = new AmxBiLogAddResponse();

            return returnValue;
        }

        /// <summary>
        /// Method used to create BI log activity
        /// </summary>
        /// <param name="OrgService"></param>
        /// <param name="biLogSchema"></param>
        public void CreateBILogValues(IOrganizationService OrgService, BILogSchema biLogSchema)
        {
            try
            {
                Entity biLogActivity = new Entity("etel_bi_log");
                string fetchXmlBiHeader = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                      <entity name='etel_bi_header'>
                                        <attribute name='activityid' />
                                        <attribute name='createdon' />
                                        <order attribute='subject' descending='false' />
                                        <filter type='and'>
                                          <condition attribute='createdby' operator='eq' value='{0}' />
                                          <condition attribute='etel_headerstatus' operator='eq' value='1' />
                                        </filter>
                                      </entity>
                                    </fetch>";

                fetchXmlBiHeader = string.Format(fetchXmlBiHeader, biLogSchema.LoggedInUserId);
                EntityCollection entityCollection = OrgService.RetrieveMultiple(new FetchExpression(fetchXmlBiHeader));
                if (entityCollection.Entities.Count > 0)
                    biLogSchema.BiHeaderRecordGuid = new Guid(entityCollection.Entities[0].Attributes["activityid"].ToString());
                biLogActivity["etel_bi_headerid"] = biLogSchema.BiHeaderRecordGuid != Guid.Empty ? new EntityReference("etel_bi_header", biLogSchema.BiHeaderRecordGuid) : null;
                biLogActivity.Attributes.Add("scheduledend", DateTime.Now);
                biLogActivity.Attributes.Add("subject", biLogSchema.Subject);
                biLogActivity.Attributes.Add("etel_description", biLogSchema.Description);
                biLogActivity.Attributes.Add("etel_customerchannel", biLogSchema.Channel);
                biLogActivity.Attributes.Add("regardingobjectid", new EntityReference("amx_bibillcyclechange", biLogSchema.BillCycleChangeRecordGuid));
                Entity party1 = new Entity("activityparty");
                party1["partyid"] = new EntityReference("contact", biLogSchema.CustomerId);
                EntityCollection entCollection = new EntityCollection();
                entCollection.Entities.Add(party1);
                biLogActivity.Attributes.Add("customers", entCollection);
                biLogActivity.Attributes.Add("etel_individualcustomerid",new EntityReference("contact", biLogSchema.CustomerId));
                Guid CreatedBiLogGuid = OrgService.Create(biLogActivity);
                if (CreatedBiLogGuid != null)
                {
                    EntityReference moniker = new EntityReference();
                    moniker.LogicalName = "etel_bi_log";
                    moniker.Id = CreatedBiLogGuid;
                    OrganizationRequest orgrequest = new OrganizationRequest() { RequestName = "SetState" };
                    orgrequest["EntityMoniker"] = moniker;
                    OptionSetValue state = new OptionSetValue(1);
                    OptionSetValue status = new OptionSetValue(2);
                    orgrequest["State"] = state;
                    orgrequest["Status"] = status;
                    OrgService.Execute(orgrequest);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
