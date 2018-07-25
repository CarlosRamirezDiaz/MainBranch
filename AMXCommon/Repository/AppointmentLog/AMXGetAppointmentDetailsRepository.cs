using AMXCommon.Model.AppointmentLog;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AMXCommon.Repository.AppointmentLog
{
    public class AMXGetAppointmentDetailsRepository
    {
        #region Variables
        private string fetchAppointmentLog = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                              <entity name='etel_appointmentlog'>
                                                <attribute name='etel_appointmentlogid' />                                                
                                                <attribute name='etel_name' />
                                                <attribute name='etel_individualcustomerid' />
                                                <attribute name='etel_externalid' />
                                                <attribute name='etel_appointmentdate' />
                                                <attribute name='amx_workorderid' />
                                                <attribute name='amx_workflowordersubtype' />
                                                <attribute name='amx_timeslot' />
                                                <attribute name='amx_duration' />
                                                <attribute name='amx_confirmationstatus' />
                                                <attribute name='amx_appointmentnumber' />
                                                <attribute name='amx_addressid' />
                                                <attribute name='amx_address' />
                                                <order attribute='etel_name' descending='false' />
                                                <filter type='and'>
                                                  <condition attribute='statecode' operator='eq' value='0' />
                                                </filter>
                                                <link-entity name='contact' from='contactid' to='etel_individualcustomerid' alias='ae'>
                                                  <attribute name='etel_accountnumber' />
                                                  <attribute name='fullname' />
                                                  <attribute name='amx_ccinfojsontext' />
                                                  <filter type='and'>
                                                    <condition attribute='etel_iddocumentnumber' operator='eq' value='{0}' />
                                                  </filter>
                                                </link-entity>
                                              </entity>
                                            </fetch>";

        #endregion

        #region Public Methods
        /// <summary>
        /// Get All Appointment logs based on Document Id
        /// </summary>
        /// <param name="service"></param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        public AMXGetAppointmentDetailsResponseModel GetAppointmentDetails(IOrganizationService service, string documentId)
        {
            string primaryPhone = string.Empty;
            string secondaryPhone = string.Empty;
            var response = new AMXGetAppointmentDetailsResponseModel();
            response.appointmentList = new List<Model.AppointmentLog.AppointmentLog>();
            try
            {
                var entityCollection = service.RetrieveMultiple(new FetchExpression(string.Format(fetchAppointmentLog, documentId)));
                if (entityCollection.Entities.Count > 0) {
                    var entity = entityCollection.Entities[0];
                    if (entity.Contains("ae.amx_ccinfojsontext"))
                    {
                        var resPhoneInfo = GetCustomerContactInfo(((AliasedValue)entity["ae.amx_ccinfojsontext"]).Value.ToString());
                        var phoneinfo = resPhoneInfo.Split(';');
                        primaryPhone = phoneinfo.Length > 0 ? phoneinfo[0] : string.Empty;
                        secondaryPhone = phoneinfo.Length > 1 ? phoneinfo[1] : string.Empty;
                    }
                }
                foreach (var entity in entityCollection.Entities)
                {
                    response.appointmentList.Add(new Model.AppointmentLog.AppointmentLog
                    {
                        address = entity.Contains("amx_address") ? entity["amx_address"].ToString() : "",
                        customerName = entity.Contains("ae.fullname") ? ((AliasedValue)entity["ae.fullname"]).Value.ToString() : "",
                        primaryPhone = primaryPhone,
                        secondaryPhone = secondaryPhone,
                        appointmentDate = entity.Contains("etel_appointmentdate") ? Convert.ToDateTime(entity["etel_appointmentdate"].ToString()) : DateTime.MinValue,
                        timeSlot = entity.Contains("amx_timeslot") ? entity["amx_timeslot"].ToString() : "",
                        appointmentNumber = entity.Contains("amx_appointmentnumber") ? entity["amx_appointmentnumber"].ToString() : "",
                        id = entity.Contains("amx_workorderid") ? entity["amx_workorderid"].ToString() : "",
                        workTypeLabel = entity.Contains("amx_workflowordersubtype") ? entity["amx_workflowordersubtype"].ToString() : "",
                        cancelado = entity.Contains("amx_confirmationstatus") ? ((OptionSetValue)entity["amx_confirmationstatus"]).Value == 173800000 ? 1 : 0 : 0 //173800000 - Confirmed, 173800001 - Pending
                    });
                }
                response.responseStatus = new ResponseStatus { code = 1, description = "Success" };
            }
            catch (Exception ex)
            {
                response.responseStatus = new ResponseStatus { code = 0, description = "Failed. Error while retrieving Appointment log for the customer" };
            }
            return response;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Get Customer Contact Info
        /// </summary>
        /// <param name="conInfo"></param>
        /// <returns></returns>
        public string GetCustomerContactInfo(string conInfo)
        {
            string primaryPhone = string.Empty;
            string secondaryPhone = string.Empty;
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            var jsonText = "{'customerContactInfo' :" + conInfo + "}";
            var jsonResultObj = json_serializer.Deserialize(jsonText, typeof(CustomerContactInformations));
            List<CustomerContactInfo> cusInfoList = ((CustomerContactInformations)jsonResultObj).customerContactInfo;
            foreach (var li in cusInfoList)
            {
                if (li.contacttype == 173800001 && li.isprimary == 1)
                {
                    primaryPhone = li.mobileInfo;
                }
                else if (li.contacttype == 173800001 && li.isprimary == 0)
                {
                    secondaryPhone = li.mobileInfo;
                }
            }
            return primaryPhone + ";" + secondaryPhone;
        }

        #endregion
    }
}
