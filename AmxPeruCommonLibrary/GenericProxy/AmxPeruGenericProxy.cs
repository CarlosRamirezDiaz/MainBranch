using Ericsson.ETELCRM.Business.WCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AmxPeruCommonLibrary
{
    public class AmxPeruGenericProxy<T> : GenericServiceProxy<T>
    {
        public AmxPeruGenericProxy(string url, string userName, 
            GenericWCFProxyFactory.TimeoutParameters timeoutParameters, bool isMtom = false) 
            : base(url, userName, timeoutParameters, isMtom)
        {

        }

        public AmxPeruGenericProxy(string url, string userName, 
            bool isMtom = false) : base(url, userName,
            new GenericWCFProxyFactory.TimeoutParameters()
            {
                OpenTimeout = new TimeSpan(0, 15, 0),
                ReceivedTimeout = new TimeSpan(0, 15, 0),
                SendTimeout = new TimeSpan(0, 15, 0)
            }, isMtom)
        {

        }

        protected override void SetFactoryProperties(ChannelFactory<T> factoryChannel)
        {
            base.SetFactoryProperties(factoryChannel);
            factoryChannel.Endpoint.EndpointBehaviors.Add(new SecurityBehavior());
        }
    }
}
