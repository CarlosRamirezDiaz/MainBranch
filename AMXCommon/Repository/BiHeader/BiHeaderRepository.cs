using AMXCommon.Model.BiHeader;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMXCommon.Repository.BiHeader
{
    public class BiHeaderRepository
    {
        #region Variables
        private string fetchBiHeader = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' no-lock='true' distinct='false'>
                                              <entity name='etel_bi_header'>
                                                <attribute name='activityid' />                                                
                                                <attribute name='subject' /> 
                                                <attribute name='etel_individualcustomerid' />
                                                <attribute name='etel_channelinteractionid' />
                                                <attribute name='etel_accountid' />
                                                <attribute name='statecode' />
                                                <attribute name='statuscode' />
                                                <order attribute='createdon' descending='true' />
                                                <filter type='and'>
                                                    <condition attribute='ownerid' operator='eq' value='{0}' />
                                                    <condition attribute='etel_headerstatus' operator='eq' value='true' />
                                                </filter>
                                              </entity>
                                            </fetch>";

        #endregion

        public void Create(BiHeaderModel biModel, IOrganizationService service)
        {
            try
            {
                Entity biHeader = new Entity
                {
                    LogicalName = "etel_bi_header",
                    Attributes = new AttributeCollection {

                         new KeyValuePair<string, object>("etel_headerstatus", true),
                         new KeyValuePair<string, object>("etel_customerrequired", true),
                         new KeyValuePair<string, object>("etel_channelinteractionstarttime", DateTime.Now),
                         new KeyValuePair<string, object>("etel_biheaderstarttime", DateTime.Now),
                         new KeyValuePair<string, object>("subject", biModel.Subject),
                         new KeyValuePair<string, object>("etel_channelinteractionid", biModel.ChannelInteractionId),
                         new KeyValuePair<string, object>("etel_csrid", biModel.CsrId.ToString().Replace("{","").Replace("}",""))
                    }
                };

                if (biModel.AccountId != Guid.Empty)
                {
                    biHeader.Attributes.Add("etel_accountid", new EntityReference("account", biModel.AccountId));
                    biHeader.Attributes.Add("etel_customeridtext", biModel.AccountId.ToString().Replace("{", "").Replace("}", ""));
                    //biHeader.Attributes.Add("etel_customername",);
                }
                else if (biModel.IndividualCustomerId != Guid.Empty)
                {
                    biHeader.Attributes.Add("etel_individualcustomerid", new EntityReference("contact", biModel.IndividualCustomerId));
                    biHeader.Attributes.Add("etel_customeridtext", biModel.IndividualCustomerId.ToString().Replace("{", "").Replace("}", ""));
                    //biHeader.Attributes.Add("etel_customername",);
                }
                //createHeader.Subject = 'Digiturno: ' + amxco_ctiCustomerSearch.DigiturnoTurnoId;
                //createHeader.etel_channelinteractionid = amxco_ctiCustomerSearch.DigiturnoTurnoId;

                service.Create(biHeader);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed. Error while creating BiHeader." + ex.Message);
            }

        }

        public void CloseBiHeader(Guid biHeaderId, IOrganizationService service)
        {
            try
            {
                Entity biHeader = new Entity
                {
                    Id = biHeaderId,
                    LogicalName = "etel_bi_header",
                    Attributes = new AttributeCollection {

                         new KeyValuePair<string, object>("etel_headerstatus", false),
                         new KeyValuePair<string, object>("statecode", new OptionSetValue(2)),
                         new KeyValuePair<string, object>("statuscode", new OptionSetValue(3)),
                         new KeyValuePair<string, object>("etel_biheaderendtime", DateTime.Now),
                    }
                };
                service.Update(biHeader);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed. Error while closing BiHeader." + ex.Message);
            }
        }

        public Entity GetActiveBiHeader(Guid userId, IOrganizationService service)
        {
            try
            {
                var entityCollection = service.RetrieveMultiple(new FetchExpression(string.Format(fetchBiHeader, userId)));
                if (entityCollection.Entities.Count > 0)
                {
                    return entityCollection.Entities[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed. Error while retrieving BiHeader." + ex.Message);
            }
            return null;
        }
    }
}

