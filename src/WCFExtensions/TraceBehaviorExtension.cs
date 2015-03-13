using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace WCFExtensions
{
    public class TraceBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get
            {
                return typeof(TraceRequestInterceptor);
            }
        }

        protected override object CreateBehavior()
        {
            return new TraceRequestInterceptor();
        }
    }
}
