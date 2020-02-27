using System.Runtime.InteropServices;

namespace PuttyColors2WinTerm.Helpers
{
    /// <summary>
    /// From: https://mariusschulz.com/blog/detecting-the-operating-system-in-net-core
    /// </summary>
    public static class OperatingSystem
    {
        public static bool IsWindows() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static bool IsMacOS() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        public static bool IsLinux() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        public static bool IsFreeBsd() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD);
    }
}
