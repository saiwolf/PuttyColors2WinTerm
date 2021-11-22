using PuttyColors2WinTerm.Colors;
using PuttyColors2WinTerm.Putty;
using Serilog.Core;
using System;

namespace PuttyColors2WinTerm
{
    public static class Globals
    {
        /// <summary>
        /// <para>Gets the value of the user's home directory depending on OS.</para>
        /// <para>From: https://stackoverflow.com/questions/1143706/getting-the-path-of-the-home-directory-in-c </para>
        /// </summary>
        public static string HomePath = Environment.OSVersion.Platform switch
        {            
            PlatformID.Win32NT => Environment.GetEnvironmentVariable("%HOMEDRIVE%%HOMEPATH%"),
            _ => Environment.GetEnvironmentVariable("HOME"),
        };

        /// <summary>
        /// Holds PuTTY session to convert.
        /// </summary>
        public static string Session { get; set; } = string.Empty;
        /// <summary>
        /// Controls logging levels.
        /// </summary>
        public static LoggingLevelSwitch? LogLevelSwitch { get; set; }
        /// <summary>
        /// Sets the JSON `name` attribute in the output.
        /// </summary>
        public static string SchemeName { get; set; } = string.Empty;
        /// <summary>
        /// Full path to registry (.reg) file for conversion. Only used if <see cref="UseRegFile"/> is <c>true</c>.
        /// </summary>
        public static string RegExportFile { get; set; } = string.Empty;
        /// <summary>
        /// Boolean controlling whether or not to import .reg file for conversion.
        /// </summary>
        public static bool UseRegFile { get; set; } = false;

        /// <summary>
        /// Boolean controlling using <see cref="DefaultPuttyColors" /> as colors to convert./>
        /// </summary>
        public static bool UseDefaultColors { get; set; } = false;
        /// <summary>
        /// Path to file to write output JSON to.
        /// </summary>
        public static string ExportJsonFile { get; set; } = string.Empty;
        /// <summary>
        /// Boolean controlling whether or not to export output JSON to a file.
        /// </summary>
        public static bool UseExportFile { get; set; }
        /// <summary>
        /// A fully initialized <see cref="PuttyColors"/> instance with PuTTY's default terminal colors.
        /// </summary>
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
