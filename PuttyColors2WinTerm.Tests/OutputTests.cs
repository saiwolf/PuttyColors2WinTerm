using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuttyColors2WinTerm;
using System;
using System.Collections.Generic;
using System.Text;

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
            string testJSON = "{\r\n  \"black\": \"#000000\",\r\n  \"blue\": \"#0000BB\",\r\n  \"brightBlack\": \"#555555\",\r\n  \"brightBlue\": \"#5555FF\",\r\n  \"brightCyan\": \"#55FFFF\",\r\n  \"brightGreen\": \"#55FF55\",\r\n  \"brightPurple\": \"#FF55FF\",\r\n  \"brightRed\": \"#FF5555\",\r\n  \"brightWhite\": \"#FFFFFF\",\r\n  \"brightYellow\": \"#FFFF55\",\r\n  \"cyan\": \"#00BBBB\",\r\n  \"background\": \"#000000\",\r\n  \"foreground\": \"#BBBBBB\",\r\n  \"green\": \"#00BB00\",\r\n  \"name\": \"Default Scheme\",\r\n  \"purple\": \"#BB00BB\",\r\n  \"red\": \"#BB0000\",\r\n  \"white\": \"#BBBBBB\",\r\n  \"yellow\": \"#BBBB00\"\r\n}";

            string outputJSON = Output.GenerateJson(defaultPuttyColors);
            
            Assert.AreEqual(testJSON, outputJSON);
        }
    }
}