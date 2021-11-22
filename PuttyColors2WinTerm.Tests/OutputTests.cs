using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PuttyColors2WinTerm.Tests
{
    [TestClass()]
    public class OutputTests
    {
        [TestMethod()]
        public void ToJsonTest()
        {
            Globals.Session = "Default%20Session";
            Globals.SchemeName = "Default Scheme";
            var defaultPuttyColors = Globals.DefaultPuttyColors;
            string testJSON = Output.GenerateJson(defaultPuttyColors);

            WinTerminal.WinTerminalSchemes testPOCO = System.Text.Json.JsonSerializer.Deserialize<WinTerminal.WinTerminalSchemes>(testJSON);
            
            foreach (var scheme in testPOCO.Schemes)
            {
                Assert.IsNotNull(scheme.Name);
                Assert.AreEqual(scheme.Background, Helpers.Converter.RGB2Hex(defaultPuttyColors.DefaultBackground));
                Assert.AreEqual(scheme.Foreground, Helpers.Converter.RGB2Hex(defaultPuttyColors.DefaultForeground));
                Assert.AreEqual(scheme.Black, Helpers.Converter.RGB2Hex(defaultPuttyColors.ANSIBlack));
                Assert.AreEqual(scheme.Blue, Helpers.Converter.RGB2Hex(defaultPuttyColors.ANSIBlue));
                Assert.AreEqual(scheme.BrightBlack, Helpers.Converter.RGB2Hex(defaultPuttyColors.ANSIBlackBold));
                Assert.AreEqual(scheme.BrightBlue, Helpers.Converter.RGB2Hex(defaultPuttyColors.ANSIBlueBold));
                Assert.AreEqual(scheme.BrightCyan, Helpers.Converter.RGB2Hex(defaultPuttyColors.ANSICyanBold));
                Assert.AreEqual(scheme.BrightGreen, Helpers.Converter.RGB2Hex(defaultPuttyColors.ANSIGreenBold));
                Assert.AreEqual(scheme.BrightPurple, Helpers.Converter.RGB2Hex(defaultPuttyColors.ANSIMagentaBold));
                Assert.AreEqual(scheme.BrightRed, Helpers.Converter.RGB2Hex(defaultPuttyColors.ANSIRedBold));
                Assert.AreEqual(scheme.BrightWhite, Helpers.Converter.RGB2Hex(defaultPuttyColors.ANSIWhiteBold));
                Assert.AreEqual(scheme.BrightYellow, Helpers.Converter.RGB2Hex(defaultPuttyColors.ANSIYellowBold));
                Assert.AreEqual(scheme.Cyan, Helpers.Converter.RGB2Hex(defaultPuttyColors.ANSICyan));
                Assert.AreEqual(scheme.Green, Helpers.Converter.RGB2Hex(defaultPuttyColors.ANSIGreen));
                Assert.AreEqual(scheme.Purple, Helpers.Converter.RGB2Hex(defaultPuttyColors.ANSIMagenta));
                Assert.AreEqual(scheme.Red, Helpers.Converter.RGB2Hex(defaultPuttyColors.ANSIRed));
                Assert.AreEqual(scheme.White, Helpers.Converter.RGB2Hex(defaultPuttyColors.ANSIWhite));
                Assert.AreEqual(scheme.Yellow, Helpers.Converter.RGB2Hex(defaultPuttyColors.ANSIYellow));
            }
        }
    }
}