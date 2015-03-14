[![Build status](https://ci.appveyor.com/api/projects/status/2g6eugjo5v6ierau?svg=true)](https://ci.appveyor.com/project/DickvdBrink/wcf-extensions)

# WCF-Extensions

WCF-Extensions can log the data from a request or response to anything you like. This can be helpful in a production environment where you can't sniff the trafic because of SSL certificates and breaking the production environment isn't an option either.

This projects supports writing to a [TraceListener](https://msdn.microsoft.com/en-us/library/system.diagnostics.tracelistener(v=vs.110).aspx) so it supports DbgView, EventLog, Files or even WebPage listeners. It is also possible to build your own and log to a database or an Azure Storage table.

## How to use

### TraceListeners

TODO: Info about tracelisteners

### Client

TODO

### Server

TODO

## Building from source

### Using Visual Studio

**Requirements**
 * Visual Studio 2013 (or newer)

Just open the `WCFExtensions.sln` found in the src folder and built it like a normal project. You can also build from the commandline by calling `msbuild WCFExtensions.sln`.
