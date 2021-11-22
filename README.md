# Putty2WinTerminal

## License

This software is licensed under the [BSD 3-Clause "New" or "Revised" License](https://github.com/saiwolf/PuttyColors2WinTerm/blob/master/LICENSE). Any third party software maintains its own licensing and copyright.

## Introduction

A simple [.NET 6](https://dotnet.microsoft.com/) console program that does one specific thing: 

It converts PuTTY Session Colors from various sources into a JSON structure that you can easily paste into your Windows Terminal [`profiles.json`](https://github.com/microsoft/terminal/blob/master/doc/cascadia/SettingsSchema.md) under [`schemes`](https://github.com/microsoft/terminal/blob/master/doc/cascadia/SettingsSchema.md#schemes).

It will automatically determine the OS.

The binaries provided are self-contained single binary files produced with `dotnet publish`. This removes the requirement on having the .NET Core Runtime installed.

**NOTE:** If you're on a *NIX based OS, then there are [minimum requirements](https://docs.microsoft.com/en-us/dotnet/core/install/dependencies?tabs=netcore31&pivots=os-linux) to be met imposed by .NET Core.

Sources So Far:

1. The Windows Registry. (Only on Windows)
2. Default PuTTY settings directory on *NIX OSes. `~/.putty/sessions/` (Only on a *NIX based OS)
3. A Registry Export (.reg) file which is OS agnostic.

## Operating System Support

* Windows
* Any *NIX based OS. (Linux, Unix, BSD, MacOS, etc)

## Usage
Windows: `PuttyColors2WinTerm.exe --help`
*NIX: `./PuttyColors2WinTerm --help`:

```
  -v, --verbose        (Default: false) Turn on verbose output.

  -s, --session        (Default: Default%20Settings) puTTY session to convert.

  -n, --scheme-name    (Default: Default Scheme) Value of `name` JSON attribute in output.

  -r, --reg-file       Import a Registry File (.reg) for conversion instead of searching for User Settings.

  --help               Display this help screen.

  --version            Display version information.
```

## Software Used
* [.Net 6](https://dotnet.microsoft.com/) - A free, cross-platform, open source developer platform for building many different types of applications.
    * [Microsoft.Win32.Registry](https://github.com/dotnet/corefx) - Provides support for accessing and modifying the Windows Registry.
    * [System.Text.Json](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-overview) - Replaces [Newtonsoft.Json](https://www.newtonsoft.com/json) in .Net 3x. Lightweight and generally faster.
* [CommandLineParser](https://github.com/commandlineparser/commandline) - Terse syntax C# command line parser for .NET.
* [Registry Export File Parser](https://www.codeproject.com/Tips/125573/Registry-Export-File-reg-Parser) - Parses a Windows Registry file for Analysis and Comparison.
* [Serilog](https://github.com/serilog/serilog) - Simple .NET logging with fully-structured events.
	* [Serilog.Sinks.Console](https://github.com/serilog/serilog-sinks-console) - Write log events to System.Console as text or JSON, with ANSI theme support.