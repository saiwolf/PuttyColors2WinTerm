using System;
using System.Collections.Generic;
using System.Reflection;
using CommandLine;
using PuttyColors2WinTerm.Putty;
using PuttyColors2WinTerm.Retrieval;

namespace PuttyColors2WinTerm
{
    static class Globals
    {
        public static string Session;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CmdOptions>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError);

            RegistryColors regColor = GetValues.FromWin32Registry();
            PropertyInfo[] props = typeof(RegistryColors).GetProperties();

            
            
            foreach (PropertyInfo property in props)
            {
                
            }

        }

        static void RunOptions(CmdOptions opts)
        {
            Globals.Session = opts.Session;
        }
        static void HandleParseError(IEnumerable<Error> errs)
        {
            Environment.Exit(0);
        }
    }
}
