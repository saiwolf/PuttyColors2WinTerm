using System.Drawing;
using PuttyColors2WinTerm.Colors;

namespace PuttyColors2WinTerm.Helpers
{
    public static class Converter
    {
        public static string RGB2Hex(RGBColor rgbColor) =>
            string.Format("#{0:X2}{1:X2}{2:X2}", rgbColor.Red, rgbColor.Green, rgbColor.Blue);
    }
}
