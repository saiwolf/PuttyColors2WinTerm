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
        public static string Session { get; set; } = string.Empty;
        public static LoggingLevelSwitch LogLevelSwitch { get; set; }
        public static string SchemeName { get; set; } = string.Empty;
        public static string RegExportFile { get; set; } = string.Empty;
        public static bool UseRegFile { get; set; } = false;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Globals.LogLevelSwitch = new LoggingLevelSwitch
            {
                MinimumLevel = LogEventLevel.Warning
            };

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

                PuttyColors puttyColors = new PuttyColors();

                if(Globals.UseRegFile)
                {
                    puttyColors = GetValues.FromRegFile();
                }
                else
                {
                    puttyColors = GetValues.FromWin32Registry();
                }

                string jsonOutput = Output.ToJson(puttyColors);

                if (string.IsNullOrEmpty(jsonOutput) || string.IsNullOrWhiteSpace(jsonOutput))
                    throw new Exception("No JSON Produced. Exiting.");

                Console.WriteLine(jsonOutput);
            }
            catch (Exception ex)
            {
#if DEBUG
                Log.Fatal(ex, $"A fatal error occurred...");
#else
                Log.Fatal($"A fatal error occurred... {ex.Message}");
#endif
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

            if(!string.IsNullOrEmpty(opts.RegExportFile))
            {
                Globals.UseRegFile = true;
                Globals.RegExportFile = opts.RegExportFile;
                Log.Verbose("Importing from Registry File...");
            }

            Globals.Session = opts.Session;

            Globals.SchemeName = string.IsNullOrEmpty(opts.SchemeName) ? "Default Scheme" : opts.SchemeName;            
        }
        static void HandleParseError(IEnumerable<Error> errs)
        {
            StringBuilder errorString = new StringBuilder();
            foreach(var err in errs)
            {
                switch (err.Tag)
                {
                    case ErrorType.HelpRequestedError:
                        Environment.Exit(0);
                        break;
                    case ErrorType.VersionRequestedError:
                        Environment.Exit(0);
                        break;
                    case ErrorType.UnknownOptionError:
                        Environment.Exit(-1);
                        break;
                    default:
                        errorString.Append($"{err.Tag}: {err.ToString()} ");
                        throw new Exception($"Error processing command line...: {errorString}");
                }
            }                        
        }
    }
}
