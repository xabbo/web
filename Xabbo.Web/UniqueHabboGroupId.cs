using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Xabbo.Web;

/// <summary>
/// Represents a globally unique Habbo group identifier.
/// </summary>
public sealed class UniqueHabboGroupId : UniqueHabboId
{
    public static readonly UniqueHabboGroupId None = new();

    private static readonly Regex
        RegexUniqueGroupId = new(@"^g-hh[a-z0-9]{2}-[0-9a-f]{32}$", RegexOptions.Compiled);

    private UniqueHabboGroupId()
        : base(UniqueHabboIdType.Group)
    { }

    public UniqueHabboGroupId(string hotel, string hash)
        : base(UniqueHabboIdType.User, hotel, hash)
    { }

    public static explicit operator UniqueHabboGroupId(string uniqueId) => Parse(uniqueId);

    public static new bool IsValid(string uniqueId) => RegexUniqueGroupId.IsMatch(uniqueId);

    public static UniqueHabboGroupId Parse(string s)
        => TryParse(s, out var uniqueId) ? uniqueId : throw new FormatException($"Invalid unique group ID format: '{s}'.");

    public static bool TryParse(string s, [NotNullWhen(true)] out UniqueHabboGroupId? uniqueId)
        => (uniqueId = IsValid(s) ? new(s[2..4], s[^32..]) : null) is not null;
}
