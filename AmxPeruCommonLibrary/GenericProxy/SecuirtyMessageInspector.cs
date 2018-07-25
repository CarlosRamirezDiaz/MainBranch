using Ericsson.ETELCRM.CrmCachingLibrary.Caching;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace AmxPeruCommonLibrary
{    

    public class SecuirtyMessageInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {            
            request.Headers.Add(new BSCSHeader("UsernameToken-49", "ADMX", "ADMX"));                        

            return null;
        }
    }
}