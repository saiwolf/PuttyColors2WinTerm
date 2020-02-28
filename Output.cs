using System;
using System.Collections.Generic;
using System.Text.Json;
using PuttyColors2WinTerm.Putty;
using PuttyColors2WinTerm.WinTerminal;
using PuttyColors2WinTerm.Helpers;

namespace PuttyColors2WinTerm
{
    public static class Output
    {
        private static string ToJson(RegistryColors regColors)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            WinTerminalScheme scheme = new WinTerminalScheme
            {
                Black = Converter.RGB2Hex(regColors.ANSIBlack),
                BrightBlack = Converter.RGB2Hex(regColors.ANSIBlackBold)
            };


        }
    }
}
