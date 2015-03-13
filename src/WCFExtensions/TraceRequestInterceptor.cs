using System;
using System.Collections.Generic;
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

        #region IClientMessageInspector

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            System.ServiceModel.Description.IEndpointBehavior a;
            throw new NotImplementedException();
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDispatchMessageInspector

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            throw new NotImplementedException();
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
