using System;
using CommandLine;

namespace PuttyColors2WinTerm
{
    public class CmdOptions
    {
        [Option('s', "session",
            Required = true,
            HelpText = "puTTY session to convert.")]
        public string Session { get; set; }
    }
}
