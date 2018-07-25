using AmxDynamicsServices;
using AmxPeruPSBActivities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmxDynamicsServices
{
    public class UpdateChangeStratumStatus: IUpdateChangeStratumStatus
    {
        UpdateChangeStratumStatusResponse _UpdateChangeStratumStatusResponse = null;
        UpdateChangeStratumStatusBusiness _UpdateChangeStratumStatusBusiness = null;

        public UpdateChangeStratumStatus()
        {
            _UpdateChangeStratumStatusBusiness = new UpdateChangeStratumStatusBusiness();
        }

        UpdateChangeStratumStatusResponse IUpdateChangeStratumStatus.UpdateChangeStratumStatusInCrm(UpdateChangeStratumStatusRequest request)
        {
            try
            {
                if (request != null)
                {
                    _UpdateChangeStratumStatusResponse = new UpdateChangeStratumStatusResponse();
                    _UpdateChangeStratumStatusResponse = _UpdateChangeStratumStatusBusiness.UpdateChangeStratumStatusInCRM(request);
                    _UpdateChangeStratumStatusResponse.Status = AmxPeruConstants.StatusOK;
                }
            }
            catch (Exception ex)
            {
                _UpdateChangeStratumStatusResponse.Error = ex.Message;
                _UpdateChangeStratumStatusResponse.Status = AmxPeruConstants.StatusNotOK;
            }

            AMXCommon.Common.FormatResponse();
            return _UpdateChangeStratumStatusResponse;
        }
    }
}
