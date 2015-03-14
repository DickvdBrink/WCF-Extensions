using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFExtensions
{
    internal class DefaultWcfTracelistener : TraceListener
    {
        public override void Write(string message)
        {
            Trace.Write(message);
        }

        public override void WriteLine(string message)
        {
            Trace.WriteLine(message);
        }
    }
}
