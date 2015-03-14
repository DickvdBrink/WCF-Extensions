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

        #region IClientMessageInspector

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            Trace.WriteLine(reply.ToString());
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            Trace.WriteLine(request.ToString());
            return null;
        }

        #endregion

        #region IDispatchMessageInspector

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            Trace.WriteLine(request.ToString());
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            Trace.WriteLine(reply.ToString());
        }

        #endregion
    }
}
