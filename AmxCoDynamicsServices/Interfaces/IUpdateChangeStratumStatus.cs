using AmxDynamicsServices;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace AmxDynamicsServices
{
    [ServiceContract]
    public interface IUpdateChangeStratumStatus
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/UpdateChangeStratumStatus")]
        UpdateChangeStratumStatusResponse UpdateChangeStratumStatusInCrm(UpdateChangeStratumStatusRequest request);
    }
}
