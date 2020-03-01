using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuttyColors2WinTerm.Retrieval;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PuttyColors2WinTerm.Tests
{
    [TestClass()]
    public class GetValuesTests
    {
        public GetValuesTests()
        {
            Globals.Session = "Default%20Settings";
        }

        private static bool NotWindows()
        {
            return !RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        }

        private static bool NotLinuxNorMacOS()
        {
            return !RuntimeInformation.IsOSPlatform(OSPlatform.Linux) &&
                   !RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        }

        [TestMethodWithIgnoreIfSupport()]
        [IgnoreIf(nameof(NotWindows))]
        public void FromWin32RegistryTest()
        {
            var fw32r = GetValues.FromWin32Registry();
            var testPutty = new Putty.PuttyColors();

            Assert.IsNotNull(fw32r);
            Assert.AreEqual(fw32r.GetType(), testPutty.GetType());                        
        }

        [TestMethod()]
        public void FromRegFileTest()
        {
            Globals.UseRegFile = true;
            Globals.RegExportFile = ".\\putty.reg";

            var fromRegFile = GetValues.FromRegFile();
            var background = fromRegFile.DefaultBackground;
            var tempRgb = new Colors.RGBColor(0, 43, 54);

            Assert.AreEqual(tempRgb.Red, background.Red);
            Assert.AreEqual(tempRgb.Green, background.Green);
            Assert.AreEqual(tempRgb.Green, background.Green);
        }

        [TestMethodWithIgnoreIfSupport()]
        [IgnoreIf(nameof(NotLinuxNorMacOS))]
        public void FromNixFileTest()
        {
            
        }
    }
}