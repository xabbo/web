namespace Xabbo.Web.Util;

internal static class VersionUtil
{
    public static readonly string SemanticVersion;

    static VersionUtil()
    {
        if (typeof(VersionUtil).Assembly
            .GetType("GitVersionInformation")
            ?.GetField("SemVer")
            ?.GetValue(null) is not string semanticVersion)
        {
            throw new Exception("Failed to retrieve semantic version from GitVersionInformation.");
        }

        SemanticVersion = semanticVersion;
    }
}
