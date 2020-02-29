using PuttyColors2WinTerm.Colors;

namespace PuttyColors2WinTerm.Putty
{
    /// <summary>
    /// Class representation of PuTTY Color Settings.
    /// These are stored in the settings file or registry as R,G,B values.
    /// </summary>
    public class PuttyColors
    {
        public RGBColor DefaultForeground { get; set; }
        public RGBColor DefaultForegroundBold { get; set; }
        public RGBColor DefaultBackground { get; set; }
        public RGBColor DefaultBackgroundBold { get; set; }
        public RGBColor CursorText { get; set; }
        public RGBColor CursorColor { get; set; }
        public RGBColor ANSIBlack { get; set; }
        public RGBColor ANSIBlackBold { get; set; }
        public RGBColor ANSIRed { get; set; }
        public RGBColor ANSIRedBold { get; set; }
        public RGBColor ANSIGreen { get; set; }
        public RGBColor ANSIGreenBold { get; set; }
        public RGBColor ANSIYellow { get; set; }
        public RGBColor ANSIYellowBold { get; set; }
        public RGBColor ANSIBlue { get; set; }
        public RGBColor ANSIBlueBold { get; set; }
        public RGBColor ANSIMagenta { get; set; }
        public RGBColor ANSIMagentaBold { get; set; }
        public RGBColor ANSICyan { get; set; }
        public RGBColor ANSICyanBold { get; set; }
        public RGBColor ANSIWhite { get; set; }
        public RGBColor ANSIWhiteBold { get; set; }
    }
}
