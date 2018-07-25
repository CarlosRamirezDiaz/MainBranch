using Ericsson.ETELCRM.Business.WCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;
using System.Xml.Serialization;

namespace AmxSoapServicesActivities.Business
{
    public class BSCSServiceProxy<T> : GenericServiceProxy<T>
    {
        public BSCSServiceProxy(string url, string userName,
            GenericWCFProxyFactory.TimeoutParameters timeoutParameters, bool isMtom = false)
            : base(url, userName, timeoutParameters, isMtom)
        {

        }

        public BSCSServiceProxy(string url, string userName,
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

    public class SecurityBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new SecuirtyMessageInspector());
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }

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

    public class BSCSHeader : MessageHeader
    {
        private readonly UsernameToken _usernameToken;


        public BSCSHeader(string id, string username, string password)
        {
            _usernameToken = new UsernameToken(id, username, password);
        }

        public override string Name
        {
            get { return "Security"; }
        }

        public override string Namespace
        {
            get { return "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"; }
        }

        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UsernameToken));
            serializer.Serialize(writer, _usernameToken);
        }
    }

    [XmlRoot(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
    public class UsernameToken
    {
        public UsernameToken()
        {
        }

        public UsernameToken(string id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = new Password() { Value = password };
        }

        [XmlAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")]
        public string Id { get; set; }

        [XmlElement]
        public string Username { get; set; }

        [XmlElement]
        public Password Password { get; set; }
    }

    public class Password
    {
        public Password()
        {
            Type = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText";
        }

        [XmlAttribute]
        public string Type { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}
