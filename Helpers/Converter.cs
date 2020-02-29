using PuttyColors2WinTerm.Colors;

namespace PuttyColors2WinTerm.Helpers
{
    /// <summary>
    /// Class that contains functions that convert from one value to another.
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// <para>
        /// Converts a <see cref="RGBColor"/> instance into an HTML compliant Hex color string.
        /// </para>
        /// </summary>
        /// <param name="rgbColor">The <see cref="RGBColor"/> instance to convert.</param>
        /// <returns>A HTML compliant Hex color string.</returns>
        public static string RGB2Hex(RGBColor rgbColor) =>
            string.Format("#{0:X2}{1:X2}{2:X2}", rgbColor.Red, rgbColor.Green, rgbColor.Blue);
    }
}
