using CommandLine;

namespace PuttyColors2WinTerm
{
    /// <summary>
    /// Options class for CommandLineParser.
    /// </summary>
    public class CmdOptions
    {
        [Option('v', "verbose",
            Required = false,
            Default = false,
            HelpText = "Turn on verbose output.")]
        public bool Verbose { get; set; }

        [Option('s', "session",
            Required = false,
            Default = "Default%20Settings",
            HelpText = "puTTY session to convert.")]
        public string Session { get; set; }

        [Option('n', "scheme-name",
            Required = false,
            Default = "Default Scheme",
            HelpText = "Value of `name` JSON attribute in output.")]
        public string SchemeName { get; set; }
        
        [Option('r', "reg-file",
            Required = false,
            HelpText = "Import a Registry File (.reg) for conversion instead of searching for User Settings.")]
        public string RegExportFile { get; set; }
    }
}
