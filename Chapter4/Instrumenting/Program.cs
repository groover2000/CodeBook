using System.Diagnostics;
using Microsoft.Extensions.Configuration;


Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "log.txt"))));

Trace.AutoFlush = true;

Debug.WriteLine("I am watching");
Trace.WriteLine("Trace watching");


ConfigurationBuilder builder = new();

builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",
                                                                    optional: true, reloadOnChange: true);

IConfigurationRoot configuration = builder.Build();
TraceSwitch ts = new(
    displayName: "PactSwitch",
    description: "This switch is set via JSON config");

configuration.GetSection("PacktSwitch").Bind(ts);

Trace.WriteLineIf(ts.TraceError, "Trace error");
Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
Trace.WriteLineIf(ts.TraceInfo, "Trace information");
Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");