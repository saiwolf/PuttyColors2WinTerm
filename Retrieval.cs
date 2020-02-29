using Microsoft.Win32;
using PuttyColors2WinTerm.Colors;
using PuttyColors2WinTerm.Putty;
using System;
using System.Collections.Generic;
using Serilog;

namespace PuttyColors2WinTerm.Retrieval
{
    public static class GetValues
    {
        const string regPuttyKey = @"Software\SimonTatham\PuTTY\Sessions\";

        public static PuttyColors FromWin32Registry()
        {
            Dictionary<string, string> colorList = new Dictionary<string, string>();
            PuttyColors regColors = new PuttyColors();            

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

                    if (colorList.Count > 0)
                    {
                        foreach (KeyValuePair<string, string> color in colorList)
                        {
                            string[] splitString = color.Value.Split(',');
                            int r = int.Parse(splitString[0]);
                            int g = int.Parse(splitString[1]);
                            int b = int.Parse(splitString[2]);

                            switch (color.Key)
                            {
                                case "Colour0":
                                    regColors.DefaultBackground = new RGBColor(r, g, b);
                                    break;
                                case "Colour1":
                                    regColors.DefaultBackgroundBold = new RGBColor(r, g, b);
                                    break;
                                case "Colour2":
                                    regColors.DefaultForeground = new RGBColor(r, g, b);
                                    break;
                                case "Colour3":
                                    regColors.DefaultForegroundBold = new RGBColor(r, g, b);
                                    break;
                                case "Colour4":
                                    regColors.CursorText = new RGBColor(r, g, b);
                                    break;
                                case "Colour5":
                                    regColors.CursorColor = new RGBColor(r, g, b);
                                    break;
                                case "Colour6":
                                    regColors.ANSIBlack = new RGBColor(r, g, b);
                                    break;
                                case "Colour7":
                                    regColors.ANSIBlackBold = new RGBColor(r, g, b);
                                    break;
                                case "Colour8":
                                    regColors.ANSIRed = new RGBColor(r, g, b);
                                    break;
                                case "Colour9":
                                    regColors.ANSIRedBold = new RGBColor(r, g, b);
                                    break;
                                case "Colour10":
                                    regColors.ANSIGreen = new RGBColor(r, g, b);
                                    break;
                                case "Colour11":
                                    regColors.ANSIGreenBold = new RGBColor(r, g, b);
                                    break;
                                case "Colour12":
                                    regColors.ANSIYellow = new RGBColor(r, g, b);
                                    break;
                                case "Colour13":
                                    regColors.ANSIYellowBold = new RGBColor(r, g, b);
                                    break;
                                case "Colour14":
                                    regColors.ANSIBlue = new RGBColor(r, g, b);
                                    break;
                                case "Colour15":
                                    regColors.ANSIBlueBold = new RGBColor(r, g, b);
                                    break;
                                case "Colour16":
                                    regColors.ANSIMagenta = new RGBColor(r, g, b);
                                    break;
                                case "Colour17":
                                    regColors.ANSIMagentaBold = new RGBColor(r, g, b);
                                    break;
                                case "Colour18":
                                    regColors.ANSICyan = new RGBColor(r, g, b);
                                    break;
                                case "Colour19":
                                    regColors.ANSICyanBold = new RGBColor(r, g, b);
                                    break;
                                case "Colour20":
                                    regColors.ANSIWhite = new RGBColor(r, g, b);
                                    break;
                                case "Colour21":
                                    regColors.ANSIWhiteBold = new RGBColor(r, g, b);
                                    break;
                                default:                                    
                                    break;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Failed to retrieve color list from registry.");
                    }
                }
                else
                {                    
                    throw new Exception($"Could not open PuTTY Registry Key for session: {Globals.Session}!");
                }
            }

            return regColors;
        }
    }
}
