using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AMXCommon
{
    public class AMXIndividualCustomerBusiness
    {
        /// <summary>
        /// Create Customer Contact Information
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        /// <param name="service"></param>
        public void CreateCustomerContactInfo(IPluginExecutionContext context, Entity entity, IOrganizationService service)
        {
            string jsonText = string.Empty; Guid contactId = Guid.Empty;
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            try
            {
                if (context.MessageName.ToLower() == "create" && context.Stage == 40)
                {
                    jsonText = entity.Contains("amx_ccinfojsontext") ? entity["amx_ccinfojsontext"].ToString() : "";
                    contactId = context.PrimaryEntityId;
                    if (jsonText != "")
                    {
                        jsonText = "{'customerContactInfo' :" + jsonText + "}";
                        var jsonResultObj = json_serializer.Deserialize(jsonText, typeof(CustomerContactInformations));
                        List<CustomerContactInfo> cusInfoList = ((CustomerContactInformations)jsonResultObj).customerContactInfo;
                        new AMXIndividualCustomerRepository().CreateCustomerContactInformation(cusInfoList, contactId, service);
                    }
                }                    
            }
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException("An error occurred in Individual create plugin.", ex);
            }
        }

        public void CreateBiHeader(IPluginExecutionContext context, Entity entity, IOrganizationService orgService)
        {
            try
            {
                if (context.MessageName.ToLower() == "create" && context.Stage == 40)
                {
                    var contactId = context.PrimaryEntityId;

                    var repository = new AMXCommon.Repository.BiHeader.BiHeaderRepository();

                    var activeBiHeader = repository.GetActiveBiHeader(context.UserId, orgService);

                    if (activeBiHeader != null)
                        repository.CloseBiHeader(activeBiHeader.Id, orgService);

                    var newBiHeader = new AMXCommon.Model.BiHeader.BiHeaderModel();

                    if (entity.Contains("amx_channelinteractionid"))
                    {
                        newBiHeader.ChannelInteractionId = entity.GetAttributeValue<string>("amx_channelinteractionid");
                        newBiHeader.Subject = string.Format("Digiturno: {0}", newBiHeader.ChannelInteractionId);
                    }
                    else
                    {
                        newBiHeader.Subject = "New prospect";
                    }
                    newBiHeader.CsrId = context.UserId;
                    newBiHeader.IndividualCustomerId = context.PrimaryEntityId;

                    repository.Create(newBiHeader, orgService);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException("An error occurred in Individual create BiHeader plugin.", ex);
            }
        }
    }

}
