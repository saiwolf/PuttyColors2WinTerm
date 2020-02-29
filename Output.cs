using PuttyColors2WinTerm.Helpers;
using PuttyColors2WinTerm.Putty;
using PuttyColors2WinTerm.WinTerminal;
using System.Text.Json;

namespace PuttyColors2WinTerm
{
    /// <summary>
    /// Exactly what it says on the tin.
    /// </summary>
    public static class Output
    {
        /// <summary>
        /// Converts an <see cref="PuttyColors"/> instance to serialized Json compliant
        /// with a Windows Terminal Configuration.
        /// </summary>
        /// <param name="puttyColors">The <see cref="PuttyColors"/> instance to convert.</param>
        /// <returns>A serialized JSON string compliant with a Windows Terminal Configuration.</returns>
        public static string ToJson(PuttyColors puttyColors)
        {
            // Setting some default options for JSON Serialization.
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            //
            // Mapping between color schemes.
            // PuTTY's RGB values are converted into HTML compliant Hex colors
            // and are assigned to their proper Windows Terminal Counterparts.
            //
            // NOTE: PuTTY's Magenta is mapped to Windows Terminal's 'Purple'
            // on purpose.
            //
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

            // Turn the C# class into a serialized Json string and return it.
            return JsonSerializer.Serialize(scheme, jsonOptions);
        }
    }
}
