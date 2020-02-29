using Microsoft.Win32;
using PuttyColors2WinTerm.Colors;
using PuttyColors2WinTerm.Putty;
using RegFileParser;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;

namespace PuttyColors2WinTerm.Retrieval
{
    /// <summary>
    /// Exactly what it says on the tin.
    /// </summary>
    public static class GetValues
    {
        // 
        /// <summary>
        /// A constant for the registry partial path to PuTTY's settings.
        /// This may become dynamic in future builds as a command line option.
        /// </summary>
        const string regPuttyKey = @"Software\SimonTatham\PuTTY\Sessions\";

        /// <summary>
        /// Maps the raw RGB settings to an <see cref="PuttyColors"/> instance.
        /// </summary>
        /// <param name="colorList">A Dictionary of settings keys and values.</param>
        /// <returns>A fully intialized <see cref="PuttyColors"/> instance.</returns>
        private static PuttyColors MapRegColor(Dictionary<string, string> colorList)
        {
            PuttyColors puttyColors = new PuttyColors();

            if (colorList.Count > 0)
            {
                foreach (KeyValuePair<string, string> color in colorList)
                {
                    string[] splitString = color.Value.Split(',');
                    int r = int.Parse(splitString[0]);
                    int g = int.Parse(splitString[1]);
                    int b = int.Parse(splitString[2]);

                    // TODO: There's probably a better way to do this...
                    switch (color.Key)
                    {
                        case "Colour0":
                            puttyColors.DefaultBackground = new RGBColor(r, g, b);
                            break;
                        case "Colour1":
                            puttyColors.DefaultBackgroundBold = new RGBColor(r, g, b);
                            break;
                        case "Colour2":
                            puttyColors.DefaultForeground = new RGBColor(r, g, b);
                            break;
                        case "Colour3":
                            puttyColors.DefaultForegroundBold = new RGBColor(r, g, b);
                            break;
                        case "Colour4":
                            puttyColors.CursorText = new RGBColor(r, g, b);
                            break;
                        case "Colour5":
                            puttyColors.CursorColor = new RGBColor(r, g, b);
                            break;
                        case "Colour6":
                            puttyColors.ANSIBlack = new RGBColor(r, g, b);
                            break;
                        case "Colour7":
                            puttyColors.ANSIBlackBold = new RGBColor(r, g, b);
                            break;
                        case "Colour8":
                            puttyColors.ANSIRed = new RGBColor(r, g, b);
                            break;
                        case "Colour9":
                            puttyColors.ANSIRedBold = new RGBColor(r, g, b);
                            break;
                        case "Colour10":
                            puttyColors.ANSIGreen = new RGBColor(r, g, b);
                            break;
                        case "Colour11":
                            puttyColors.ANSIGreenBold = new RGBColor(r, g, b);
                            break;
                        case "Colour12":
                            puttyColors.ANSIYellow = new RGBColor(r, g, b);
                            break;
                        case "Colour13":
                            puttyColors.ANSIYellowBold = new RGBColor(r, g, b);
                            break;
                        case "Colour14":
                            puttyColors.ANSIBlue = new RGBColor(r, g, b);
                            break;
                        case "Colour15":
                            puttyColors.ANSIBlueBold = new RGBColor(r, g, b);
                            break;
                        case "Colour16":
                            puttyColors.ANSIMagenta = new RGBColor(r, g, b);
                            break;
                        case "Colour17":
                            puttyColors.ANSIMagentaBold = new RGBColor(r, g, b);
                            break;
                        case "Colour18":
                            puttyColors.ANSICyan = new RGBColor(r, g, b);
                            break;
                        case "Colour19":
                            puttyColors.ANSICyanBold = new RGBColor(r, g, b);
                            break;
                        case "Colour20":
                            puttyColors.ANSIWhite = new RGBColor(r, g, b);
                            break;
                        case "Colour21":
                            puttyColors.ANSIWhiteBold = new RGBColor(r, g, b);
                            break;
                        default:
                            break;
                    }
                }

                return puttyColors;
            }
            else
            {
                throw new Exception("Failed to retrieve color list from registry export file.");
            }
        }

        /// <summary>
        /// Retrieves PuTTY color settings from the Windows Registry and maps them to
        /// an <see cref="PuttyColors"/> instance.
        /// </summary>
        /// <returns>An initialized <see cref="PuttyColors"/> instance.</returns>
        public static PuttyColors FromWin32Registry()
        {
            Dictionary<string, string> colorList = new Dictionary<string, string>();
            PuttyColors puttyColors = new PuttyColors();            

            Log.Verbose($"PuTTY Key: HKEY_CURRENT_USER\\{regPuttyKey + Globals.Session}");

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(regPuttyKey + Globals.Session))
            {
                if (key != null)
                {
                    int i;
                    for (i = 0; i <= 21; i++)
                    {
                        var name = $"Colour{i}";
                        var value = Convert.ToString(key.GetValue(name));
                        colorList.Add(name, value);
                    }

                    puttyColors = MapRegColor(colorList);
                }
                else
                {                    
                    throw new Exception($"Could not open PuTTY Registry Key for session: {Globals.Session}!");
                }
            }

            return puttyColors;
        }

        /// <summary>
        /// <para>
        /// Retrieves PuTTY color settings from a registry export file (.reg) and maps them to
        /// an <see cref="PuttyColors"/> instance.
        /// </para>
        /// <para>
        /// Uses `RegFileParser` library from https://www.codeproject.com/Tips/125573/Registry-Export-File-reg-Parser
        /// </para>
        /// </summary>
        /// <returns>An initialized <see cref="PuttyColors"/> instance.</returns>
        public static PuttyColors FromRegFile()
        {
            Dictionary<string, string> colorList = new Dictionary<string, string>();
            
            if(File.Exists($@"{Globals.RegExportFile}"))
            {
                try
                {
                    RegFileObject regFile = new RegFileObject($@"{Globals.RegExportFile}");
                    PuttyColors puttyColors = new PuttyColors();

                    var data = regFile.RegValues[$@"HKEY_CURRENT_USER\{regPuttyKey}{Globals.Session}"];

                    if (data != null)
                    {
                        int i;
                        for (i = 0; i <= 21; i++)
                        {
                            var name = $"Colour{i}";
                            var value = data[name].Value;
                            colorList.Add(name, value);
                        }

                        puttyColors = MapRegColor(colorList);
                    }
                    else
                    {
                        throw new Exception($"No data for session: {Globals.Session} found in Registry Export File: {Globals.RegExportFile}!");
                    }

                    return puttyColors;
                }
                catch (KeyNotFoundException)
                {
                    Log.Error($"The file {Path.GetFileName(Globals.RegExportFile)} did not contain any data for the session: {Globals.Session}");
                    throw;
                }
                catch (Exception)
                {
                    Log.Error($"An exception has occurred.");
                    throw;
                }
                
            }
            else
            {
                throw new IOException($"Registry Export File could not be opened. {Globals.RegExportFile}");
            }
        }
    }
}
