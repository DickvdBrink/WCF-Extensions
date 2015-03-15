[![Build status](https://ci.appveyor.com/api/projects/status/2g6eugjo5v6ierau?svg=true)](https://ci.appveyor.com/project/DickvdBrink/wcf-extensions)

# WCF-Extensions

WCF-Extensions can log the data from a request or response to anything you like. This can be helpful in a production environment where you can't sniff the trafic because of SSL certificates and breaking the production environment isn't an option either.

This projects supports writing to a [TraceListener](https://msdn.microsoft.com/en-us/library/system.diagnostics.tracelistener(v=vs.110).aspx) so it supports DebugView, EventLog, Files or even WebPage listeners. It is also possible to build your own and log to a database or an Azure Storage table.

## How to use

### Configuration

To start copy the `WCFExtensions.dll` to your WCF service `bin` folder or next to the executable of your client.

Add the below section in your `app.config` or `web.config` file in the `system.serviceModel` section.

    <extensions>
      <behaviorExtensions>
        <add name="logBehavior" type="WCFExtensions.TraceEndpointBehaviorExtension, WCFExtensions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"/>
      </behaviorExtensions>
    </extensions>

    <behaviors>
      <endpointBehaviors>
        <behavior>
          <logBehavior />
        </behavior>
      </endpointBehaviors>
    </behaviors>

You can see a full sample `app.config` configuration [here](sample-configuration/App.config).

**TODO**: provide a minimal web.config sample.

With this default configuration it will log to the [DefaultTraceListener](https://msdn.microsoft.com/en-us/library/system.diagnostics.defaulttracelistener(v=vs.110).aspx). You can check the output by using [DebugView](https://technet.microsoft.com/en-us/library/bb896647.aspx). More information is available [here](http://dickvdbrink.github.io/c%23/2015/01/09/CSharp-Logging-using-Trace-and-DebugView.html).

For more configuration options read the TraceListeners section below.

### TraceListeners

TraceListeners provide a way to log to a different output without changing the code. The default TraceListener writes to [OutputDebugString](https://msdn.microsoft.com/en-us/library/windows/desktop/aa363362(v=vs.85).aspx) which you can capture with DebugView.

The configuration below writes to a file called `output.log`. Notice the tracelistener parameter for the logbehavior.

    <system.diagnostics>
      <trace autoflush="false">
        <listeners>
          <add name="log" type="System.Diagnostics.TextWriterTraceListener" initializeData="output.log" />
        </listeners>
      </trace>
    </system.diagnostics>
     <behaviors>
      <endpointBehaviors>
        <behavior>
          <logBehavior tracelistener="log"/>
        </behavior>
      </endpointBehaviors>
    </behaviors>

There are different types of TraceListener and if you want you can create your own. More documentation is available [here](https://msdn.microsoft.com/en-us/library/system.diagnostics.tracelistener(v=vs.110).aspx).

## Building from source

### Using Visual Studio

**Requirements**
 * Visual Studio 2013 (or newer)

Just open the `WCFExtensions.sln` found in the src folder and built it like a normal project. You can also build from the commandline by calling `msbuild WCFExtensions.sln`.
