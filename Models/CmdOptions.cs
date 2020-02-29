using CommandLine;

namespace PuttyColors2WinTerm
{
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

        // Not in use yet.
        [Option('f', "file",
            Required = false,
            Hidden = true,
            HelpText = "Output JSON to file instead of STDIN.")]
        public string JsonFile { get; set; }
    }
}
