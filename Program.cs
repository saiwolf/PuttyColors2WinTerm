using CommandLine;
using PuttyColors2WinTerm.Putty;
using PuttyColors2WinTerm.Retrieval;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuttyColors2WinTerm
{
    static class Globals
    {
        public static string Session;
        public static LoggingLevelSwitch LogLevelSwitch { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Globals.LogLevelSwitch = new LoggingLevelSwitch();
            Globals.LogLevelSwitch.MinimumLevel = LogEventLevel.Warning;

            // Setting up the Logger...
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(Globals.LogLevelSwitch)
                .WriteTo.Console()
                .CreateLogger();
            
            try
            {                
                // Parsing Command Line...
                Parser.Default.ParseArguments<CmdOptions>(args)
                    .WithParsed(RunOptions)
                    .WithNotParsed(HandleParseError);

                Log.Information("Starting application...");

                RegistryColors regColor = GetValues.FromWin32Registry();                
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"A fatal error occurred: ");
                Log.CloseAndFlush();
                Environment.Exit(-1);
            }
        }

        static void RunOptions(CmdOptions opts)
        {
            if(opts.Verbose)
            {
                Globals.LogLevelSwitch.MinimumLevel = LogEventLevel.Verbose;
                Log.Verbose("Verbose logging has been enabled...");
            }

            Globals.Session = opts.Session;

        }
        static void HandleParseError(IEnumerable<Error> errs)
        {
            StringBuilder errorString = new StringBuilder();
            foreach(var err in errs)
            {
                errorString.Append($"{err.Tag}: {err.ToString()} ");
            }
            throw new Exception($"Error processing command line...: {errorString}");            
        }
    }
}
