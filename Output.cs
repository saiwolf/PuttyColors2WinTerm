using PuttyColors2WinTerm.Helpers;
using PuttyColors2WinTerm.Putty;
using PuttyColors2WinTerm.WinTerminal;
using System.Text.Json;

namespace PuttyColors2WinTerm
{
    public static class Output
    {
        public static string ToJson(PuttyColors puttyColors)
        {
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            WinTerminalScheme scheme = new WinTerminalScheme
            {
                Name = Globals.SchemeName,
                Background = Converter.RGB2Hex(puttyColors.DefaultBackground),
                Foreground = Converter.RGB2Hex(puttyColors.DefaultForeground),
                Black = Converter.RGB2Hex(puttyColors.ANSIBlack),                
                Blue = Converter.RGB2Hex(puttyColors.ANSIBlue),
                BrightBlack = Converter.RGB2Hex(puttyColors.ANSIBlackBold),
                BrightBlue = Converter.RGB2Hex(puttyColors.ANSIBlueBold),
                BrightCyan = Converter.RGB2Hex(puttyColors.ANSICyanBold),
                BrightGreen = Converter.RGB2Hex(puttyColors.ANSIGreenBold),
                BrightPurple = Converter.RGB2Hex(puttyColors.ANSIMagentaBold),
                BrightRed = Converter.RGB2Hex(puttyColors.ANSIRedBold),
                BrightWhite = Converter.RGB2Hex(puttyColors.ANSIWhiteBold),
                BrightYellow = Converter.RGB2Hex(puttyColors.ANSIYellowBold),
                Cyan = Converter.RGB2Hex(puttyColors.ANSICyan),
                Green = Converter.RGB2Hex(puttyColors.ANSIGreen),
                Purple = Converter.RGB2Hex(puttyColors.ANSIMagenta),
                Red = Converter.RGB2Hex(puttyColors.ANSIRed),
                White = Converter.RGB2Hex(puttyColors.ANSIWhite),
                Yellow = Converter.RGB2Hex(puttyColors.ANSIYellow)
            };

            return JsonSerializer.Serialize(scheme, jsonOptions);
        }
    }
}
