using Serilog.Core;
using PuttyColors2WinTerm.Putty;
using PuttyColors2WinTerm.Colors;
using System;

namespace PuttyColors2WinTerm
{
    public static class Globals
    {
        public static string HomePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
                   Environment.OSVersion.Platform == PlatformID.MacOSX)
                    ? Environment.GetEnvironmentVariable("HOME")
                    : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
        public static string Session { get; set; } = string.Empty;
        public static LoggingLevelSwitch LogLevelSwitch { get; set; }
        public static string SchemeName { get; set; } = string.Empty;
        public static string RegExportFile { get; set; } = string.Empty;
        public static bool UseRegFile { get; set; } = false;

        public static PuttyColors DefaultPuttyColors = new PuttyColors
        {
            DefaultForeground       = new RGBColor(187, 187, 187),
            DefaultForegroundBold   = new RGBColor(255, 255, 255),
            DefaultBackground       = new RGBColor(0, 0, 0),
            DefaultBackgroundBold   = new RGBColor(85, 85, 85),
            CursorText              = new RGBColor(0, 0, 0),
            CursorColor             = new RGBColor(0, 255, 0),
            ANSIBlack               = new RGBColor(0, 0, 0),
            ANSIBlackBold           = new RGBColor(85, 85, 85),
            ANSIRed                 = new RGBColor(187, 0, 0),
            ANSIRedBold             = new RGBColor(255, 85, 85),
            ANSIGreen               = new RGBColor(0, 187, 0),
            ANSIGreenBold           = new RGBColor(85, 255, 85),
            ANSIYellow              = new RGBColor(187, 187, 0),
            ANSIYellowBold          = new RGBColor(255, 255, 85),
            ANSIBlue                = new RGBColor(0, 0, 187),
            ANSIBlueBold            = new RGBColor(85, 85, 255),
            ANSIMagenta             = new RGBColor(187, 0, 187),
            ANSIMagentaBold         = new RGBColor(255, 85, 255),
            ANSICyan                = new RGBColor(0, 187, 187),
            ANSICyanBold            = new RGBColor(85, 255, 255),
            ANSIWhite               = new RGBColor(187, 187, 187),
            ANSIWhiteBold           = new RGBColor(255, 255, 255)
        };
    }
}
