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
        public static string ToJson(RegistryColors regColors)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            WinTerminalScheme scheme = new WinTerminalScheme
            {
                Background = Converter.RGB2Hex(regColors.DefaultBackground),
                Foreground = Converter.RGB2Hex(regColors.DefaultForeground),
                Black = Converter.RGB2Hex(regColors.ANSIBlack),                
                Blue = Converter.RGB2Hex(regColors.ANSIBlue),
                BrightBlack = Converter.RGB2Hex(regColors.ANSIBlackBold),
                BrightBlue = Converter.RGB2Hex(regColors.ANSIBlueBold),
                BrightCyan = Converter.RGB2Hex(regColors.ANSICyanBold),
                BrightGreen = Converter.RGB2Hex(regColors.ANSIGreenBold),
                BrightPurple = Converter.RGB2Hex(regColors.ANSIMagentaBold),
                BrightRed = Converter.RGB2Hex(regColors.ANSIRedBold),
                BrightWhite = Converter.RGB2Hex(regColors.ANSIWhiteBold),
                BrightYellow = Converter.RGB2Hex(regColors.ANSIYellowBold),
                Cyan = Converter.RGB2Hex(regColors.ANSICyan),
                Green = Converter.RGB2Hex(regColors.ANSIGreen),
                Purple = Converter.RGB2Hex(regColors.ANSIMagenta),
                Red = Converter.RGB2Hex(regColors.ANSIRed),
                White = Converter.RGB2Hex(regColors.ANSIWhite),
                Yellow = Converter.RGB2Hex(regColors.ANSIYellow)
            };

            return JsonSerializer.Serialize(scheme, jsonOptions);
        }
    }
}
