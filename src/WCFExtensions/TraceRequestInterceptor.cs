using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace WCFExtensions
{
    public class TraceRequestInterceptor : IClientMessageInspector, IDispatchMessageInspector
    {
        private const string DEFAULT_CLIENT_SEND_FORMAT = "{0} Request to: {1}\r\nAction: {2}\r\nBody: {3}";
        private const string DEFAULT_CLIENT_RECIEVE_FORMAT = "{0} Reply from: {1}\r\nAction: {2}\r\nBody: {3}";

        private const string DEFAULT_SERVER_SEND_FORMAT = "{0} Reply to: {1}\r\nAction: {2}\r\nBody: {3}";
        private const string DEFAULT_SERVER_RECIEVE_FORMAT = "{0} Request from: {1}\r\nAction: {2}\r\nBody: {3}";

        private TraceListener listener;

        public TraceRequestInterceptor(TraceListener listener)
        {
            this.listener = listener;
        }

        #region IClientMessageInspector

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            State s = correlationState as State;
            string log = string.Format(DEFAULT_CLIENT_RECIEVE_FORMAT, DateTime.Now, s.RemoteAddress, s.Action, reply.ToString());
            this.listener.WriteLine(log);
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            string action = request.Headers.Action;
            Uri remoteUri = channel.RemoteAddress.Uri;
            string log = string.Format(DEFAULT_CLIENT_SEND_FORMAT, DateTime.Now, remoteUri, action, request.ToString());
            this.listener.WriteLine(log.ToString());
            return new State { RemoteAddress = remoteUri.ToString(), Action = action };
        }

        #endregion

        #region IDispatchMessageInspector

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            string action = request.Headers.Action;
            RemoteEndpointMessageProperty RE = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
            string remoteUri = RE.Address;
            string log = string.Format(DEFAULT_SERVER_RECIEVE_FORMAT, DateTime.Now, remoteUri, action, request.ToString());
            this.listener.WriteLine(log);
            return new State { RemoteAddress = remoteUri, Action = action };
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            State s = correlationState as State;
            string log = string.Format(DEFAULT_SERVER_SEND_FORMAT, DateTime.Now, s.RemoteAddress, s.Action, reply.ToString());
            this.listener.WriteLine(log);
        }

        #endregion

        private class State
        {
            public string RemoteAddress;
            public string Action;
        }
    }
}
