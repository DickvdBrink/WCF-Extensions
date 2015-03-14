using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace WCFExtensions
{
    public class TraceEndpointBehaviorExtension : BehaviorExtensionElement
    {

        [ConfigurationProperty("tracelistener", IsRequired = false)]
        public virtual string TraceListenerName
        {
            get { return this["tracelistener"] as string; }
            set { this["tracelistener"] = value; }
        }

        public override Type BehaviorType
        {
            get
            {
                return typeof(TraceEndpointBehavior);
            }
        }

        protected override object CreateBehavior()
        {
            TraceListener listener = null;
            string name = this.TraceListenerName;
            if (!string.IsNullOrEmpty(name))
            {
                listener = Trace.Listeners[name];
                if(listener == null)
                {
                    throw new KeyNotFoundException("Listener not found: " + name);
                }
            }

            return new TraceEndpointBehavior(listener ?? new DefaultWcfTracelistener());
        }
    }
}
