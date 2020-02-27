using Microsoft.Win32;
using PuttyColors2WinTerm.Colors;
using PuttyColors2WinTerm.Putty;
using System;
using System.Collections.Generic;

namespace PuttyColors2WinTerm.Retrieval
{
    public static class GetValues
    {
        const string regPuttyKey = @"\Software\SimonTatham\PuTTY\Sessions\";

        public static RegistryColors FromWin32Registry()
        {
            Dictionary<string, string> colorList = new Dictionary<string, string>();
            RegistryColors regColors = new RegistryColors();

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\SimonTatham\PuTTY\Sessions\" + Globals.Session))
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

                            switch (color.Key.Substring(7))
                            {
                                case "0":
                                    regColors.DefaultBackground = new RGBColor(r, g, b);
                                    break;
                                case "1":
                                    regColors.DefaultBackgroundBold = new RGBColor(r, g, b);
                                    break;
                                case "2":
                                    regColors.DefaultForeground = new RGBColor(r, g, b);
                                    break;
                                case "3":
                                    regColors.DefaultForegroundBold = new RGBColor(r, g, b);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }

            return regColors;
        }
    }
}
