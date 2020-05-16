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

                // A blank `PuttyColors` class for use below.
                PuttyColors puttyColors = new PuttyColors();

                // Checking if we're suppose to get our putty Config
                // from a registry file (.reg) rather than searching elsewhere.
                if(Globals.UseRegFile)
                {
                    puttyColors = GetValues.FromRegFile();
                }
                else
                {
                    // Search the Windows Registry if the OS is Windows
                    if (Helpers.OperatingSystem.IsWindows())
                    {
                        puttyColors = GetValues.FromWin32Registry();
                    }
                    // Else, assume a NIX OS and search ~/.putty
                    else
                    {
                        puttyColors = GetValues.FromNixFile();
                    }
                }

                // Check if we're exporting the output to a file or not.
                // Yes: Write it to the specified file.
                // No: Print it to Console.
                if(Globals.UseExportFile)
                {
                    Output.WriteJsonToFile(puttyColors);
                }
                else
                {
                    Output.WriteJsonToConsole(puttyColors);
                }

                // Signal app shutdown. App will exit with 0 status code.
                Log.Verbose("Application shuting down...");
            }
            // Main program error handler. Exceptions in other methods should bubble up to here.
            catch (Exception ex)
            {
                // The compiler conditional #if DEBUG controls if the exception details are displayed to the user
                // or not. In DEBUG builds, this information could help troubleshoot issues. In Release builds,
                // hide it to keep information concise and clean.
#if DEBUG
                Log.Fatal(ex, $"A fatal error occurred...");
#else
                Log.Fatal($"A fatal error occurred... {ex.Message}");
#endif
                // Flush the logs.
                Log.CloseAndFlush();
                // Exit with an abnormal exit code: -1
                Environment.Exit(-1);
            }
        }

        /// <summary>
        /// Function that exposes command line arguments passed and handles them.
        /// </summary>
        /// <param name="opts">Command Line arguments passed to program.</param>
        static void RunOptions(CmdOptions opts)
        {
            // If true, turn on verbose logging by setting Log Level Switch
            // and indicating to the user that Verbose logging is now turned on.
            if(opts.Verbose)
            {
                Globals.LogLevelSwitch.MinimumLevel = LogEventLevel.Verbose;
                Log.Verbose("Verbose logging has been enabled...");
            }

            // If the RegExportFile property isn't blank, then we set
            // the Globals UseRegFile and RegExportFile and inform the user
            // that we're importing settings from a Registry file instead of normal operation.
            if(!string.IsNullOrEmpty(opts.RegExportFile))
            {
                Globals.UseRegFile = true;
                Globals.RegExportFile = opts.RegExportFile;
                Log.Verbose("Importing from Registry File...");
            }

            // If the JsonExportFile property isn't blank, then we set
            // the Globals UseExportFile and ExportJsonFile and inform the user
            // that we're exporting the generated JSON to the supplied file instead
            // of printing it to Console.
            if(!string.IsNullOrEmpty(opts.JsonExportFile))
            {
                Globals.UseExportFile = true;
                Globals.ExportJsonFile = opts.JsonExportFile;
                Log.Verbose($"Exporting to JSON file: {opts.JsonExportFile}");
            }

            // Set the Globals Session property to Session command line argument passed, if it was passed to begin with.
            Globals.Session = opts.Session;
            // Set the Globals SchemeName property to SchemeName command line argument
            // passed, or set it to the default "Default Scheme" if the value is Null/Empty.
            Globals.SchemeName = string.IsNullOrEmpty(opts.SchemeName) ? "Default Scheme" : opts.SchemeName;            
        }
        /// <summary>
        /// Function that handles errors during parsing command line arguments.
        /// </summary>
        /// <param name="errs">Enumerable collection of type <see cref="Error"/></param>
        static void HandleParseError(IEnumerable<Error> errs)
        {
            // Start a StringBuilder error string.
            StringBuilder errorString = new StringBuilder();

            // We need to loop through `errs` to append all the errors to `errorString`.
            foreach(var err in errs)
            {
                // There are three types of errors in CommandLineParser that aren't really errors per se.
                // HelpRequested, VersionRequested, and UnknownOption.
                // The switch statement checks for these errors and exits the app if they're present.
                //
                // Else, it appends `err.Tag` and `err` to the `errorString` StringBuilder and casts
                // it to a string to show as an Exception.
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
