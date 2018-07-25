using AmxPeruPSBActivities.Model.OrderMilestone;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruPSBActivities.Business
{
    public class AmxPeruSetOrderMilestoneBusiness
    {
        Guid RelatedOrderGuid = Guid.Empty;

        OrganizationServiceProxy OrgService = null;

        public AmxPeruSetOrderMilestoneResponse SetOrderStatus(AmxPeruSetOrderMilestoneRequest request, OrganizationServiceProxy OrgService)
        {
            AmxPeruSetOrderMilestoneResponse _AmxPeruSetOrderMilestoneResponse = null;

            //request.CRMOrderId = "ORDMD0000030";
            //request.EOCOrderId = "EOC_ORD_30";
            //request.EOCQuoteId = "EOC_QUOTE_12345";
            //request.Description = "Order status update : Error Encountered";
            //request.ErrorCode = "12345";
            //request.OrderFulFillmentStatusCode = OrderFulFillmentStatusCode.Completed;
            //request.MileStone = "Milestone";
            //request.PointOfNoReturn = false;

            try
            {
                //comment is added
                _AmxPeruSetOrderMilestoneResponse = new AmxPeruSetOrderMilestoneResponse();

                if (request != null)
                {
                    //Fetch the Order GUID
                    GetOrderGuid(request.CRMOrderId);

                    bool isOrderMileStoneCreated = CreateOrderMileStoneEntry(request);
                    if (isOrderMileStoneCreated)
                    {
                        //Craete BI Log
                        if (request.OrderFulFillmentStatusCode == OrderFulFillmentStatusCode.Completed)
                        {
                            //  CreateBiLog(request);
                        }
                        _AmxPeruSetOrderMilestoneResponse.MilestoneServiceStatus = "OrderMilestoneSuccess";// Constants.OrderMilestoneSuccess;
                    }
                }
                else
                {
                    _AmxPeruSetOrderMilestoneResponse.Error = "Incoming Request is null.";// Constants.tIncomingRequestNull;
                    _AmxPeruSetOrderMilestoneResponse.Status = "NOK";// Constants.StatusNotOK;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _AmxPeruSetOrderMilestoneResponse;
        }

        #region [Private Methods]
        /// <summary>
        /// This method creates a record in TCRM Order Milestone entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private bool CreateOrderMileStoneEntry(AmxPeruSetOrderMilestoneRequest request)
        {
            bool flag = false;

            try
            {
                Microsoft.Xrm.Sdk.Entity _entity = new Microsoft.Xrm.Sdk.Entity("amxbase_ordermilestone");
                if (!string.IsNullOrEmpty(request.MileStone))
                {
                    _entity.Attributes.Add("amxbase_name", request.MileStone.ToString());
                }
                else
                {
                    //etel_name is primary field
                    //throw exception if the name is Not Specified
                    throw new Exception("TCRM: Milestone value is NULL or Empty");//Constants.tMilestoneIsNull
                }

                //  Setting Admin of CRM as ownermapping_statuscode of record.
                //  _entity.Attributes.Add("ownerid", new Microsoft.Xrm.Sdk.EntityReference("systemuser", GetOwnerGuid(ConfigurationManager.AppSettings["AdminUser"].ToString())));


                _entity.Attributes.Add("amxbase_crmorderid", new Microsoft.Xrm.Sdk.EntityReference("etel_ordercapture", RelatedOrderGuid));

                if (!string.IsNullOrEmpty(request.EOCOrderId))
                {
                    _entity.Attributes.Add("amxbase_eocorderid", request.EOCOrderId);
                }

                if (!string.IsNullOrEmpty(request.EOCQuoteId))
                {
                    _entity.Attributes.Add("amxbase_eocquoteid", request.EOCQuoteId);
                }

                _entity.Attributes.Add("amxbase_ponr", request.PointOfNoReturn);
                if (!string.IsNullOrEmpty(request.Description))
                {
                    _entity.Attributes.Add("amxbase_desc", request.Description);
                }
                if (!string.IsNullOrEmpty(request.ErrorCode))
                {
                    _entity.Attributes.Add("amxbase_errorcode", request.ErrorCode);
                }
                _entity.Attributes.Add("amxbase_milestone", new Microsoft.Xrm.Sdk.OptionSetValue(GetInt32ValueOrderFullfillmentStatus(request.OrderFulFillmentStatusCode)));

                Guid CreatedMileStoneRecordGuid = OrgService.Create(_entity);
                if (CreatedMileStoneRecordGuid != Guid.Empty)
                {
                    UpdateOrderInCrmWithStatus(RelatedOrderGuid, request);
                }

                flag = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return flag;
        }

        /// <summary>
        /// This method updates the Order Status in CRM
        /// </summary>
        /// <param name="relatedOrderGuid"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        private bool UpdateOrderInCrmWithStatus(Guid relatedOrderGuid, AmxPeruSetOrderMilestoneRequest request)
        {
            bool OrderUpdated = false;

            try
            {
                Microsoft.Xrm.Sdk.Entity _Entity = new Microsoft.Xrm.Sdk.Entity("etel_ordercapture", relatedOrderGuid);
                _Entity.Attributes.Add("amxbase_milestonestatus", new Microsoft.Xrm.Sdk.OptionSetValue(GetInt32ValueOrderFullfillmentStatus(request.OrderFulFillmentStatusCode)));
                _Entity.Attributes.Add("amxbase_eocorderid", request.EOCOrderId);
                _Entity.Attributes.Add("amxbase_eocquoteid", request.EOCQuoteId);
                OrgService.Update(_Entity);
                OrderUpdated = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return OrderUpdated;
        }

        /// <summary>
        /// This Method maps the Order Fullfillment Status values as per Input and CRM stored values
        /// Can be configured later if the MileStone Incoming and CRM Values are not matching
        /// Case items can be discarded as per business cases; i.e. the no of statuses need to be updated @ order level
        /// </summary>
        /// <param name="orderFulFillmentStatusCode"></param>
        /// <returns></returns>
        private int GetInt32ValueOrderFullfillmentStatus(OrderFulFillmentStatusCode orderFulFillmentStatusCode)
        {
            int optionSetValue = -1;

            try
            {
                int OrderStatusFullfillmentStatusNew = 1;
                int OrderStatusFullfillmentStatusInProgress = 2;
                int OrderStatusFullfillmentStatusError = 3;
                int OrderStatusFullfillmentStatusCompleted = 4;
                int OrderStatusFullfillmentStatusCancelled = 5;
                int OrderStatusFullfillmentStatusAmended = 6;

                switch (orderFulFillmentStatusCode)
                {

                    case OrderFulFillmentStatusCode.New:
                        optionSetValue = OrderStatusFullfillmentStatusNew;
                        break;
                    case OrderFulFillmentStatusCode.InProgress:
                        optionSetValue = OrderStatusFullfillmentStatusInProgress;
                        break;
                    case OrderFulFillmentStatusCode.Error:
                        optionSetValue = OrderStatusFullfillmentStatusError;
                        break;
                    case OrderFulFillmentStatusCode.Completed:
                        optionSetValue = OrderStatusFullfillmentStatusCompleted;
                        break;
                    case OrderFulFillmentStatusCode.Cancelled:
                        optionSetValue = OrderStatusFullfillmentStatusCancelled;
                        break;
                    case OrderFulFillmentStatusCode.Amended:
                        optionSetValue = OrderStatusFullfillmentStatusAmended;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return optionSetValue;
        }

        /// <summary>
        /// This Method fetches the Order Guid via Order External Id
        /// </summary>
        /// <param name="orderID"></param>
        private void GetOrderGuid(string CRMOrderID)
        {
            try
            {
                string OrderCaptureGuidFetchXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                            <entity name='etel_ordercapture'>
                                                            <attribute name='etel_ordercaptureid' />
                                                            <attribute name='etel_name' />
                                                            <filter type='and'>
                                                                <condition attribute='etel_name' operator='eq' value='{0}' />
                                                            </filter>
                                                            </entity>
                                                        </fetch>";

                string fetchXml = string.Format(OrderCaptureGuidFetchXml, CRMOrderID);
                Microsoft.Xrm.Sdk.EntityCollection _EntityCollection = OrgService.RetrieveMultiple(new Microsoft.Xrm.Sdk.Query.FetchExpression(fetchXml));
                if (_EntityCollection != null)
                {
                    if (_EntityCollection.Entities.Count > 0)
                    {
                        RelatedOrderGuid = new Guid(_EntityCollection.Entities[0].Attributes["etel_ordercaptureid"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Method fetches the Owner/User Guid from CRM via Owner Name
        /// </summary>
        /// <param name="ownerUserName"></param>
        /// <returns></returns>
        private Guid GetOwnerGuid(string ownerUserName)
        {
            Guid ownerGuid = Guid.Empty;

            try
            {
                string OwerUserNameFethXML = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                      <entity name='systemuser'>
                                                        <attribute name='businessunitid' />
                                                        <attribute name='systemuserid' />
                                                        <order attribute='fullname' descending='false' />
                                                        <filter type='and'>
                                                          <condition attribute='domainname' operator='eq' value='{0}' />
                                                        </filter>
                                                      </entity>
                                                    </fetch>";
                string fetchXml = string.Format(OwerUserNameFethXML, ownerUserName);
                Microsoft.Xrm.Sdk.EntityCollection _EntityCollection = OrgService.RetrieveMultiple(new Microsoft.Xrm.Sdk.Query.FetchExpression(fetchXml));

                if (_EntityCollection != null)
                {
                    if (_EntityCollection.Entities.Count > 0)
                    {
                        ownerGuid = new Guid(_EntityCollection.Entities[0].Attributes["systemuserid"].ToString());
                    }
                }

                return ownerGuid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

    }
}
