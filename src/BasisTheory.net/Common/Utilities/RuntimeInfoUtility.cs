using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Runtime.Versioning;
using static System.Runtime.InteropServices.RuntimeInformation;

namespace BasisTheory.net.Common.Utilities
{
    // code largely borrowed from <a href="https://github.com/dotnet/BenchmarkDotNet">BenchmarkDotNet</a> project.
    internal static class RuntimeInfoUtility
    {
        internal static bool IsMono { get; } = Type.GetType("Mono.Runtime") != null;

        internal static bool IsNetFramework =>
            FrameworkDescription.StartsWith(".NET Framework", StringComparison.OrdinalIgnoreCase);

        internal static bool IsNetNative =>
            FrameworkDescription.StartsWith(".NET Native", StringComparison.OrdinalIgnoreCase);

        internal static bool IsNetCore
            => ((Environment.Version.Major >= 5) ||
                FrameworkDescription.StartsWith(".NET Core", StringComparison.OrdinalIgnoreCase))
               && !string.IsNullOrEmpty(typeof(object).Assembly.Location);

        internal static bool IsRunningInContainer =>
            string.Equals(Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER"), "true");

        public static string GetRuntimeVersion()
        {
            if (IsMono)
            {
                return GetMonoVersion();
            }
            else if (IsNetFramework)
            {
                return GetNetFrameworkVersion();
            }
            else if (IsNetCore)
            {
                return GetNetCoreVersion();
            }

            return "unknown/unknown";
        }

        internal static string GetMonoVersion()
        {
            var monoRuntimeType = Type.GetType("Mono.Runtime");
            var monoDisplayName = monoRuntimeType?.GetMethod("GetDisplayName",
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (monoDisplayName == null) return "unknown";

            var version = monoDisplayName.Invoke(null, null)?.ToString();
            if (version == null) return "Mono/unknown";

            int bracket1 = version.IndexOf('('), bracket2 = version.IndexOf(')');
            if (bracket1 == -1 || bracket2 == -1) return $"Mono/{version}";

            var comment = version.Substring(bracket1 + 1, bracket2 - bracket1 - 1);
            var commentParts = comment.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (commentParts.Length > 2)
                version = version[..bracket1] + $"({commentParts[0]} {commentParts[1]})";

            return $"Mono/{version}";
        }

        internal static string GetNetFrameworkVersion()
        {
            var frameworkDescription = FrameworkDescription;
            var frameworkVersion = new string(frameworkDescription.SkipWhile(c => !char.IsDigit(c)).ToArray());

            return $".NET Framework/{frameworkVersion}";
        }

        internal static string GetNetCoreVersion()
        {
            var coreclrAssemblyInfo = FileVersionInfo.GetVersionInfo(typeof(object).GetTypeInfo().Assembly.Location);
            var corefxAssemblyInfo = FileVersionInfo.GetVersionInfo(typeof(Regex).GetTypeInfo().Assembly.Location);

            if (TryGetNetCoreVersion(out var version) && version >= new Version(5, 0))
            {
                // after the merge of dotnet/corefx and dotnet/coreclr into dotnet/runtime the version should always be the same
                Debug.Assert(coreclrAssemblyInfo.FileVersion == corefxAssemblyInfo.FileVersion);

                return $".NET/{version} ({coreclrAssemblyInfo.FileVersion})";
            }

            var runtimeVersion = version != default ? version.ToString() : "?";

            return
                $".NET Core/{runtimeVersion} (CoreCLR {coreclrAssemblyInfo.FileVersion}, CoreFX {corefxAssemblyInfo.FileVersion})";
        }

        internal static bool TryGetNetCoreVersion(out Version version)
        {
            // we can't just use System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription
            // because it can be null and it reports versions like 4.6.* for .NET Core 2.*

            // for .NET 5+ we can use Environment.Version
            if (Environment.Version.Major >= 5)
            {
                version = Environment.Version;
                return true;
            }

            var runtimeDirectory = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
            if (TryGetVersionFromRuntimeDirectory(runtimeDirectory, out version))
            {
                return true;
            }

            var systemPrivateCoreLib = FileVersionInfo.GetVersionInfo(typeof(object).Assembly.Location);
            // systemPrivateCoreLib.Product*Part properties return 0 so we have to implement some ugly parsing...
            if (TryGetVersionFromProductInfo(systemPrivateCoreLib.ProductVersion, systemPrivateCoreLib.ProductName,
                    out version))
            {
                return true;
            }

            // it's OK to use this method only after checking the previous ones
            // because we might have a benchmark app build for .NET Core X but executed using CoreRun Y
            // example: -f netcoreapp3.1 --corerun $omittedForBrevity\Microsoft.NETCore.App\7.0.0\CoreRun.exe - built as 3.1, run as 7.0 (#1576)
            var frameworkName = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()
                ?.FrameworkName;
            if (TryGetVersionFromFrameworkName(frameworkName, out version))
            {
                return true;
            }

            if (IsRunningInContainer)
            {
                return Version.TryParse(Environment.GetEnvironmentVariable("DOTNET_VERSION"), out version)
                       || Version.TryParse(Environment.GetEnvironmentVariable("ASPNETCORE_VERSION"), out version);
            }

            version = null;
            return false;
        }

        // sample input:
        // for dotnet run: C:\Program Files\dotnet\shared\Microsoft.NETCore.App\2.1.12\
        // for dotnet publish: C:\Users\adsitnik\source\repos\ConsoleApp25\ConsoleApp25\bin\Release\netcoreapp2.0\win-x64\publish\
        internal static bool TryGetVersionFromRuntimeDirectory(string runtimeDirectory, out Version version)
        {
            if (!string.IsNullOrEmpty(runtimeDirectory) &&
                Version.TryParse(GetParsableVersionPart(new DirectoryInfo(runtimeDirectory).Name), out version))
            {
                return true;
            }

            version = null;
            return false;
        }

        // sample input:
        // 2.0: 4.6.26614.01 @BuiltBy: dlab14-DDVSOWINAGE018 @Commit: a536e7eec55c538c94639cefe295aa672996bf9b, Microsoft .NET Framework
        // 2.1: 4.6.27817.01 @BuiltBy: dlab14-DDVSOWINAGE101 @Branch: release/2.1 @SrcCode: https://github.com/dotnet/coreclr/tree/6f78fbb3f964b4f407a2efb713a186384a167e5c, Microsoft .NET Framework
        // 2.2: 4.6.27817.03 @BuiltBy: dlab14-DDVSOWINAGE101 @Branch: release/2.2 @SrcCode: https://github.com/dotnet/coreclr/tree/ce1d090d33b400a25620c0145046471495067cc7, Microsoft .NET Framework
        // 3.0: 3.0.0-preview8.19379.2+ac25be694a5385a6a1496db40de932df0689b742, Microsoft .NET Core
        // 5.0: 5.0.0-alpha1.19413.7+0ecefa44c9d66adb8a997d5778dc6c246ad393a7, Microsoft .NET Core
        internal static bool TryGetVersionFromProductInfo(string productVersion, string productName,
            out Version version)
        {
            if (!string.IsNullOrEmpty(productVersion) && !string.IsNullOrEmpty(productName))
            {
                if (productName.IndexOf(".NET Core", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    string parsableVersion = GetParsableVersionPart(productVersion);
                    if (Version.TryParse(productVersion, out version) || Version.TryParse(parsableVersion, out version))
                    {
                        return true;
                    }
                }

                // yes, .NET Core 2.X has a product name == .NET Framework...
                if (productName.IndexOf(".NET Framework", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    const string releaseVersionPrefix = "release/";
                    int releaseVersionIndex = productVersion.IndexOf(releaseVersionPrefix);
                    if (releaseVersionIndex > 0)
                    {
                        string releaseVersion =
                            GetParsableVersionPart(
                                productVersion.Substring(releaseVersionIndex + releaseVersionPrefix.Length));

                        return Version.TryParse(releaseVersion, out version);
                    }
                }
            }

            version = null;
            return false;
        }

        // sample input:
        // .NETCoreApp,Version=v2.0
        // .NETCoreApp,Version=v2.1
        internal static bool TryGetVersionFromFrameworkName(string frameworkName, out Version version)
        {
            const string versionPrefix = ".NETCoreApp,Version=v";
            if (!string.IsNullOrEmpty(frameworkName) && frameworkName.StartsWith(versionPrefix))
            {
                string frameworkVersion = GetParsableVersionPart(frameworkName.Substring(versionPrefix.Length));

                return Version.TryParse(frameworkVersion, out version);
            }

            version = null;
            return false;
        }

        private static string GetParsableVersionPart(string fullVersionName) =>
            new string(fullVersionName.TakeWhile(c => char.IsDigit(c) || c == '.').ToArray());
    }
}