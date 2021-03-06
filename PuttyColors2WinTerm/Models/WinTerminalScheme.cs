﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PuttyColors2WinTerm.WinTerminal
{
    /// <summary>
    /// Meta-class for generating a proper 'schemes' JSON object.
    /// </summary>
    public class WinTerminalSchemes
    {
        public WinTerminalSchemes()
        {
            Schemes = new List<WinTerminalScheme>();
        }

        [JsonPropertyName("schemes")]
        public IList<WinTerminalScheme> Schemes { get; set; }
    }
    /// <summary>
    /// A C# Class represting the JSON config values of a
    /// Windows Terminal profile color scheme.
    /// </summary>
    public class WinTerminalScheme
    {
        [JsonPropertyName("black")]
        public string Black { get; set; }

        [JsonPropertyName("blue")]
        public string Blue { get; set; }

        [JsonPropertyName("brightBlack")]
        public string BrightBlack { get; set; }

        [JsonPropertyName("brightBlue")]
        public string BrightBlue { get; set; }

        [JsonPropertyName("brightCyan")]
        public string BrightCyan { get; set; }

        [JsonPropertyName("brightGreen")]
        public string BrightGreen { get; set; }

        [JsonPropertyName("brightPurple")]
        public string BrightPurple { get; set; }

        [JsonPropertyName("brightRed")]
        public string BrightRed { get; set; }

        [JsonPropertyName("brightWhite")]
        public string BrightWhite { get; set; }

        [JsonPropertyName("brightYellow")]
        public string BrightYellow { get; set; }

        [JsonPropertyName("cyan")]
        public string Cyan { get; set; }

        [JsonPropertyName("background")]
        public string Background { get; set; }

        [JsonPropertyName("foreground")]
        public string Foreground { get; set; }

        [JsonPropertyName("green")]
        public string Green { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("purple")]
        public string Purple { get; set; }

        [JsonPropertyName("red")]
        public string Red { get; set; }

        [JsonPropertyName("white")]
        public string White { get; set; }

        [JsonPropertyName("yellow")]
        public string Yellow { get; set; }
    }
}
